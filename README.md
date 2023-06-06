# TesteAuvo

  

### Requisitos:
.NET 7.0 Runtime

  

## Para Gerar o Banco de Dados Inicial:

### Entre no diretório do projeto TesteAuvo.Infra.Data:
    cd TesteAuvo.Infra.Data

### Aplique as migrations para criar o banco de dados:
    dotnet ef database update --startup-project ../TesteAuvo.Web.Mvc

  

## Arquitetura do projeto:

  

### Direção das Dependências:

![Direção das Dependências](doc/TesteAuvo-Camadas.png?raw=true  "Camadas")

  

### Relacionamento das Entidades:

![Relacionamento das Entidades](doc/TesteAuvo-Relacionamentos.png?raw=true  "Relacionamento")
