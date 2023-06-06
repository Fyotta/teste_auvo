# teste_auvo

# Para Gerar o Banco de Dados Inicial:

# Entre no diretório do projeto TesteAuvo.Infra.Data:
cd TesteAuvo.Infra.Data

# Aplique as alterações para criar o banco de dados:
dotnet ef database update --startup-project ../TesteAuvo.Web.Mvc


![Direção das Dependências](doc/TesteAuvo-Camadas.png?raw=true "Camadas")

![Relacionamento das Entidades](doc/TesteAuvo-Relacionamentos.png?raw=true "Relacionamento")