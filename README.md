
# Motorcycle Rental

Sistema Backend para gerenciamento de alugueis de motos.

API feita em .Net 8, sob um estrutura Clean Architecture dividida em 4 camadas: Domain, Application, Infrastructure e Presentation(API).


## Principais recursos utilizados:

- ORM com EntityFramework
- CQRS com MediatR
- Segurança(Autenticação e Autorização) com ApsNetCore Identity e JWT
- Testes com Xunit
- Logs(Console e arquivo) com Serilog
- Manipulação de imagens com AWS S3
- Message Broker com RabbitMQ
- Documentação com Swagger
- Containerização com Docker Compose e Docker
- Banco de Dados Postgres

## Composição do Projeto

- Postgres - Servidor de Banco de Dados Relacional
- PGAdmin - SGBD para gerenciamento do Postgres
- RabbitMQ - Message Broker
- Worker - RabbitMQ Consumer
- API Locação de Motos
## Execução

#### Com Docker instalado, executar no prompt de comando na raiz do projeto:

docker-compose up

#### Estes comando inicializará 3 serviços:

Postgres (localhost:5432)

PGAdmin(http://localhost:8081)

RabbitMQ. Servidor AMQP (localhost:5672) e Dashboard(http://localhost:15672)


#### **Pode iniciar o Worker e a API diretamente no Visual Studio ou utilizado o .Net CLI

##### API:

dotnet run --project .\MotorcycleRental.API\MotorcycleRental.API.csproj

##### Worker(RabbitMQ Consumer):

dotnet run --project .\MotorcycleRentMessageBrokerConsumer1\MotorcycleRentMessageBrokerConsumer1.csproj

## Migrations e Seeds

Para facilitar a execução, testes e publicação foi implementado a criação automatica de toda estrutura do banco de dados com uso de Migrations. Foi utilizado tambem o recurso Seeds, para inserção dos seguintes registros basicos:

Planos de Locação
Usuários: Admin e Biker(Entregador)
Roles: Admin e Biker
Dois registros de motos de exemplo