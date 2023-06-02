﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TesteAuvo.Infra.Data;

#nullable disable

namespace TesteAuvo.Infra.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("TesteAuvo.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("TesteAuvo.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ExternalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TesteAuvo.Domain.Entities.EmployeeTimeRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<int>("EffectiveMonth")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EffectiveYear")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("EntryTime")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("ExitTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("HourlyRate")
                        .HasColumnType("REAL");

                    b.Property<TimeOnly>("LunchPeriodEnd")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("LunchPeriodStart")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeTimeRecords");
                });

            modelBuilder.Entity("TesteAuvo.Domain.Entities.EmployeeTimeRecord", b =>
                {
                    b.HasOne("TesteAuvo.Domain.Entities.Department", "Department")
                        .WithMany("EmployeeTimeRecords")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TesteAuvo.Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeTimeRecords")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TesteAuvo.Domain.Entities.Department", b =>
                {
                    b.Navigation("EmployeeTimeRecords");
                });

            modelBuilder.Entity("TesteAuvo.Domain.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeTimeRecords");
                });
#pragma warning restore 612, 618
        }
    }
}