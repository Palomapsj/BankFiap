### <div align="center">Bank Investiments 💰💹 </div>  

## Descrição 👇
O sistema Bank Investiments foi desenvolvido para oferecer aos usuários uma solução completa e eficiente para o acompanhamento de seus ativos financeiros. Com suporte a múltiplas classes de investimentos, como ações, títulos e criptomoedas, o sistema proporciona uma visão centralizada e detalhada do desempenho de cada portfólio.

Através de uma interface amigável e funcionalidades robustas, os usuários podem facilmente monitorar transações, visualizar históricos de preços e acompanhar a valorização de seus ativos em tempo real. O sistema também permite o cálculo automático de dividendos e rendimentos, além de fornecer relatórios personalizados para auxiliar na tomada de decisões de investimento.

## Funcionalidades Principais
- Gerenciamento de portfólios: Permite que cada usuário crie e organize diferentes portfólios de acordo com suas necessidades.
- Transações automatizadas: Registre a compra e venda de ativos, incluindo detalhes como quantidade, preço unitário e data da transação.
- Histórico de preços: Acompanhe o comportamento dos preços dos ativos ao longo do tempo com gráficos e relatórios detalhados.
- Cálculo de dividendos e juros: O sistema calcula automaticamente os dividendos recebidos e juros de investimentos em títulos, - fornecendo uma visão clara dos rendimentos.
- Suporte a múltiplos ativos: Inclui ações, títulos e criptomoedas, permitindo ao usuário gerenciar um portfólio diversificado.


## Tecnologias Utilizadas 👨🏽‍💻
- c#
- sql server
- net core
- Docker
- rabbitmq

## Pré-requisitos
- Sql server
- visual studio 
- rabbitmq
- Docker

## Documentação 📖
- [Microservice para gerencias filas](https://github.com/raphaelarena/ProcessingMicroservice/tree/BankProcessingMicroservice)
- [Documentação Funcional do projeto](https://github.com/Palomapsj/BankFiap/blob/main/Especifica%C3%A7%C3%A3o_funcional_Bank.docx)
- [Vídeo demonstrando o projeto](https://youtu.be/-b77WFcbVKE)

## Instalação 🔁
1. Clone o repositório:
   ```bash
   git clone https://github.com/Palomapsj/BankFiap.git
  

## Criação de tabelas no banco de dados 🎲


```bash
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);



CREATE TABLE Portfolios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    UserId INT NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);


CREATE TABLE Assets (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Symbol NVARCHAR(10) NOT NULL,
    Type INT NOT NULL,  -- 0 = Stock, 1 = Bond, 2 = Cryptocurrency
    Description NVARCHAR(255),
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE()
);


CREATE TABLE Transactions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PortfolioId INT NOT NULL,
    AssetId INT NOT NULL,
    TransactionType INT NOT NULL,  -- 0 = Buy, 1 = Sell
    Quantity DECIMAL(18, 2) NOT NULL,
    UnitPrice DECIMAL(18, 2) NOT NULL,
    TransactionDate DATETIME2 NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (PortfolioId) REFERENCES Portfolios(Id) ON DELETE CASCADE,
    FOREIGN KEY (AssetId) REFERENCES Assets(Id) ON DELETE CASCADE
);


CREATE TABLE MarketValues (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AssetId INT NOT NULL,
    ValueDate DATETIME2 NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (AssetId) REFERENCES Assets(Id) ON DELETE CASCADE
);


CREATE TABLE DividendsInterests (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PortfolioId INT NOT NULL,
    AssetId INT NOT NULL,
    PaymentType INT NOT NULL,  -- 0 = Dividend, 1 = Interest
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentDate DATETIME2 NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (PortfolioId) REFERENCES Portfolios(Id) ON DELETE CASCADE,
    FOREIGN KEY (AssetId) REFERENCES Assets(Id) ON DELETE CASCADE
);


CREATE TABLE PriceHistories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AssetId INT NOT NULL,
    QuoteDate DATETIME2 NOT NULL,
    OpeningPrice DECIMAL(18, 2) NOT NULL,
    ClosingPrice DECIMAL(18, 2) NOT NULL,
    Low DECIMAL(18, 2) NOT NULL,
    High DECIMAL(18, 2) NOT NULL,
    Volume DECIMAL(18, 2) NOT NULL,
    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (AssetId) REFERENCES Assets(Id) ON DELETE CASCADE
);


```


## Autores ✍️

- [@RaphaelArena](https://github.com/raphaelarena)
- [@PalomaPsj](https://github.com/palomapsj)


