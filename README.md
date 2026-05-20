# Sapiens Bank

Aplicação console simples para gerenciar contas bancárias.

Pré-requisitos

- .NET 10 SDK

Como executar

1. Restaurar dependências e build:

```powershell
dotnet restore
dotnet build
```

2. Executar a aplicação:

```powershell
dotnet run --project SapiensBank.csproj
```

3. Executar testes:

```powershell
dotnet test
```

Observações

- Os dados das contas são salvos em `Documents/SapiensBank/banco.json`.
- As senhas não são serializadas no arquivo (`[JsonIgnore]`).
