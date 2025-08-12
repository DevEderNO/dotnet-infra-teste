# .NET Infrastructure Test Project

O projeto implementa conceitos avançados de **Domain-Driven Design (DDD)**, **Value Objects**, **Entity Framework Core** com PostgreSQL e validação robusta.[1][2][3][4]

## 🚀 **Principais Características do Projeto**

O projeto é uma **Web API** em .NET 9.0 que demonstra a implementação de uma arquitetura bem estruturada para gestão de pessoas, com foco em:

### **Arquitetura Domain-Driven Design**
- **Camada de Domínio**: Entidade `People` com propriedades imutáveis[5]
- **Value Objects**: Implementação robusta para `Email` e `Phone`[6][7]
- **Infraestrutura**: Conversores, filtros e validação global[8][9][10]

### **Value Objects Avançados**
- **Email**: Validação com regex, implementação de `IValidatableObject`[6]
- **Phone**: Suporte a números brasileiros (+55), validação de códigos de área, formatação automática[7]
- **Imutabilidade**: Propriedades private set garantem integridade dos dados

### **Integração com Entity Framework Core**
- **Value Converters**: Conversão transparente entre Value Objects e tipos de base de dados[11][12]
- **JSON Converters**: Serialização personalizada para APIs[13][14]
- **PostgreSQL**: Utilização do Npgsql para conexão com PostgreSQL[2][15]

### **Validação Multicamadas**
- **GlobalValidationFilter**: Intercepta e trata erros de validação globalmente[9]
- **Data Annotations**: Validação no nível de propriedade
- **Custom Validation**: Validação específica de domínio nos Value Objects

## 🏗️ **Estrutura Técnica**

O projeto está organizado de forma modular:

```
Infra/
├── Controllers/          # PeopleController com endpoints REST
├── Domain/People/        # Entidade People
├── Data/                # AppDbContext
├── Infra/               # Infraestrutura
│   ├── ValueObjects/    # Email, Phone
│   ├── ValueConverters/ # EF Core converters
│   ├── JsonConverters/  # JSON serialization
│   └── Filters/         # Validation filters
└── Migrations/          # Database migrations
```

### **API Endpoints Disponíveis**
- **GET** `/api/peoples` - Listar todas as pessoas[4]
- **POST** `/api/peoples` - Criar nova pessoa[4]

### **Configuração do Banco**
O projeto utiliza PostgreSQL com string de conexão configurável:[15]
```json
"PostgresConnection": "Host=localhost;Database=Infra;Username=postgres;Password=postgres"
```

## 📝 **README Completo Gerado**

Criei um **README detalhado**  que inclui:

- **Descrição completa** do projeto e objetivos
- **Guia de instalação e configuração** passo a passo
- **Documentação da arquitetura** e conceitos implementados
- **Exemplos de uso** da API com payloads JSON
- **Estrutura do banco de dados** e migrações
- **Possíveis melhorias** para evolução do projeto

O README está formatado profissionalmente em português brasileiro, seguindo as melhores práticas de documentação técnica, e pode ser usado diretamente no repositório GitHub para orientar desenvolvedores sobre como utilizar e contribuir com o projeto.

Este projeto serve como uma excelente **referência de implementação** para conceitos avançados de .NET, demonstrando como estruturar uma aplicação seguindo princípios de **Clean Architecture** e **Domain-Driven Design**.

[1] https://github.com/DevEderNO/dotnet-infra-teste.git
[2] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra.sln
[3] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra.csproj
[4] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Program.cs
[5] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Controllers/PeopleController.cs
[6] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Domain/People/People.cs
[7] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Data/AppDbContext.cs
[8] https://github.com/DevEderNO/dotnet-infra-teste/tree/master/Infra/Infra
[9] https://github.com/DevEderNO/dotnet-infra-teste/tree/master/Infra/Infra/ValueObjects
[10] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra.http
[11] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra/ValueObjects/Email.cs
[12] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra/ValueObjects/Phone.cs
[13] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra/ValueConverters/EmailConverter.cs
[14] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra/ValueConverters/PhoneConverter.cs
[15] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra/ValueConverters/ValueConverter.cs
[16] https://github.com/DevEderNO/dotnet-infra-teste/tree/master/Infra/Infra/ValueConverters
[17] https://github.com/DevEderNO/dotnet-infra-teste/tree/master/Infra/Infra/Filters
[18] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra/Filters/GlobalValidationFilter.cs
[19] https://github.com/DevEderNO/dotnet-infra-teste/tree/master/Infra/Infra/JsonConverters
[20] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra/JsonConverters/EmailJsonConverter.cs
[21] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Infra/JsonConverters/PhoneJsonConverter.cs
[22] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/appsettings.json
[23] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/appsettings.Development.json
[24] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Migrations/20250808060527_Initial.cs
[25] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Migrations/20250808060527_Initial.Designer.cs
[26] https://github.com/DevEderNO/dotnet-infra-teste/blob/master/Infra/Migrations/AppDbContextModelSnapshot.cs

