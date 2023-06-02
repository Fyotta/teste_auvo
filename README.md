# teste_auvo

# Para Gerar o Banco de Dados Inicial:

# Entre no diretório do projeto TesteAuvo.Infra.Data:
cd TesteAuvo.Infra.Data

# Adicione a migração inicial:
dotnet ef migrations add Inicial --startup-project ../TesteAuvo.Web.Mvc

# Aplique as alterações no banco de dados:
dotnet ef database update --startup-project ../TesteAuvo.Web.Mvc