using System.Globalization;
using TesteAuvo.Application.Interfaces.Services;
using TesteAuvo.Application.Services.Abstractions;
using TesteAuvo.Application.ViewModels;
using TesteAuvo.Domain.Entities;
using TesteAuvo.Domain.Interfaces;

namespace TesteAuvo.Application.Services;

public class TimeSheetClosureService : ServiceBase<TimeSheetClosure>, ITimeSheetClosureService
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;
    private readonly IBookEmployeeTimeRecordService _bookEmployeeTimeRecordService;
    private readonly IEmployeeTimeRecordService _employeeTimeRecordService;
    private readonly ITimeSheetClosureRepository _repository;
    private readonly IPaymentOrderService _paymentOrderService;

    public TimeSheetClosureService(ITimeSheetClosureRepository repository,
                                    IEmployeeService employeeService,
                                    IDepartmentService departmentService,
                                    IBookEmployeeTimeRecordService bookEmployeeTimeRecordService,
                                    IEmployeeTimeRecordService employeeTimeRecordService,
                                    IPaymentOrderService paymentOrderService) : base(repository)
    {
        _repository = repository;
        _employeeService = employeeService;
        _departmentService = departmentService;
        _bookEmployeeTimeRecordService = bookEmployeeTimeRecordService;
        _employeeTimeRecordService = employeeTimeRecordService;
        _paymentOrderService = paymentOrderService;
    }

    public async Task<IEnumerable<TimeSheetClosureViewModel>> GetTimeSheetClosureJson()
    {
        var timeSheetClosuresViewModel = new List<TimeSheetClosureViewModel>();
        
        var bookEmployeeTimeRecords = await _bookEmployeeTimeRecordService.GetAsync();
        bookEmployeeTimeRecords.ToList().ForEach(async betr => {
            var timeSheetClosures = await this.GetAsync();
            var timeSheetClosure = timeSheetClosures.FirstOrDefault(c => c.BookEmployeeTimeRecordId == betr.Id);

            if (timeSheetClosure == null) {
                timeSheetClosure = new TimeSheetClosure(Guid.NewGuid(), betr);
                await this.AddAsync(timeSheetClosure);
            }

            var employees = betr.EmployeeTimeRecords
                .Select(c => c.Employee)
                .Distinct()
                .ToList();
            
            var paymentOrdersViewModel = new List<PaymentOrderViewModel>();
            var paymentOrders = await _paymentOrderService.GetAsync();
            employees.ForEach(async employee => {
                var paymentOrder = paymentOrders.FirstOrDefault(c => c.TimeSheetClosureId == timeSheetClosure.Id && c.Employee == employee);
                if (paymentOrder == null)
                {
                    paymentOrder = new PaymentOrder(Guid.NewGuid(), employee, timeSheetClosure);
                    await _paymentOrderService.AddAsync(paymentOrder);
                }
                paymentOrder.CalculatePaymentOrder();
                await _paymentOrderService.UpdateAsync(paymentOrder);

                var paymentOrderViewModel = new PaymentOrderViewModel();
                paymentOrderViewModel.EmployeeName = paymentOrder.Employee.Name;
                paymentOrderViewModel.EmployeeId = paymentOrder.Employee.ExternalId;
                paymentOrderViewModel.TotalEarnings = paymentOrder.TotalEarnings;
                paymentOrderViewModel.OvertimeHours = paymentOrder.OvertimeHours;
                paymentOrderViewModel.DebitHours = paymentOrder.DebitHours;
                paymentOrderViewModel.AbsentDays = paymentOrder.AbsentDays;
                paymentOrderViewModel.ExtraDays = paymentOrder.ExtraDays;
                paymentOrderViewModel.WorkedDays = paymentOrder.WorkedDays;

                paymentOrdersViewModel.Add(paymentOrderViewModel);
            });

            timeSheetClosure = await this.FindByIdAsync(timeSheetClosure.Id);

            timeSheetClosure.CalculateTimeSheetClosure();

            await this.UpdateAsync(timeSheetClosure);

            var timeSheetClosureViewModel = new TimeSheetClosureViewModel();

            timeSheetClosureViewModel.DepartmentName = timeSheetClosure.BookEmployeeTimeRecord.Department.Name;
            timeSheetClosureViewModel.EffectiveMonth = CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat.GetMonthName(timeSheetClosure.BookEmployeeTimeRecord.EffectiveMonth);
            timeSheetClosureViewModel.EffectiveYear = timeSheetClosure.BookEmployeeTimeRecord.EffectiveYear;
            timeSheetClosureViewModel.TotalPayment = timeSheetClosure.TotalPayment;
            timeSheetClosureViewModel.TotalDeductions = timeSheetClosure.TotalDeductions;
            timeSheetClosureViewModel.TotalOvertime = timeSheetClosure.TotalOvertime;
            timeSheetClosureViewModel.Employees = paymentOrdersViewModel;
            timeSheetClosuresViewModel.Add(timeSheetClosureViewModel);
        });

        return timeSheetClosuresViewModel;
    }
}