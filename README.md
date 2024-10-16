# Projeto CalculoCDB

O projeto é composto por uma aplicação WebAPI .Net e uma aplicação Web Angular.
O objetivo é realizar o cálculo de investimento, o usuário entra com os valores de investimento inicial e período em meses. Como resultado são apresentados o resultado bruto e líquido do investimento, assim como a taxa e o valor de imposto aplicado.

## Sumário

- [Instalação](#instalação)
- [Execução](#execução)
- [Testes](#testes)

## Instalação

Para instalar a aplicação, siga estes passos:

1. Pré requisitos para aplicação:

- .Net SDK 8.0
- Node.js 20

2. Clone o repositório:

```bash
git clone https://github.com/joseantonio-neto/CalculoCDB.git
```

3. Navegue para o diretório da Solution:

```bash
cd CalculoCDB
```

4. Instalar as dependências:

```bash
dotnet restore
dotnet build
```

## Execução

Para executar a aplicação, siga estes passos:

1. Iniciar a aplicação:

```bash
dotnet run --project .\CalculoCDB.Server\CalculoCDB.Server.csproj
```

2. Acesse a aplicação web Angular no endereço https://localhost:4000.

3. O swagger da API pode ser acessado no endereço http://localhost:5150/swagger/index.html. Os endpoints da API podem ser consumidos pelos endereços http://localhost:5150 e https://localhost:7118.

## Testes

Para rodar os testes aplicação, siga estes passos:

### WebAPI .Net

1. Acessa o diretório da Solution:

```bash
cd CalculoCDB
```

2. Rodar o comando:

```bash
dotnet test
```

### WebApp Angular

1. Acessa o diretório do projeto Angular:

```bash
cd CalculoCDB/calculocdb.client
```

2. Rodar o comando:

```bash
npm run test
```
