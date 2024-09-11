using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Bank.BankFiap.Bank.Controllers;
using Bank.BankFiap.Bank.Entity;
using Bank.BankFiap.Bank.Repository;
using Bank.BankFiap.Bank.Entity.Enum;
using Bank.BankFiap.Bank.Interface;

public class TransactionControllerTests
{
    private readonly Mock<ITransaction> _mockTransactionRepository;
    private readonly Mock<ILogger<TransactionController>> _mockLogger;
    private readonly TransactionController _controller;

    public TransactionControllerTests()
    {
        _mockTransactionRepository = new Mock<ITransaction>();
        _mockLogger = new Mock<ILogger<TransactionController>>();
        _controller = new TransactionController(_mockTransactionRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public void GetTransactionsByPortfolioId_ShouldReturnOkWithTransactions()
    {
        // Arrange
        var mockTransactions = new List<Transaction>
        {
            new Transaction { Id = 1, PortfolioId = 1, AssetId = 1, Quantity = 10, UnitPrice = 150 },
            new Transaction { Id = 2, PortfolioId = 1, AssetId = 2, Quantity = 5, UnitPrice = 50000 }
        };
        _mockTransactionRepository.Setup(repo => repo.GetTransactionsByPortfolioId(1)).Returns(mockTransactions);

        // Act
        var result = _controller.GetTransactionsByPortfolioId(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedTransactions = Assert.IsAssignableFrom<IEnumerable<Transaction>>(okResult.Value);
        Assert.Equal(2, returnedTransactions.Count());
    }

    [Fact]
    public void GetTransactionsByPortfolioId_WhenExceptionThrown_ShouldReturnInternalServerError()
    {
        // Arrange
        _mockTransactionRepository.Setup(repo => repo.GetTransactionsByPortfolioId(1)).Throws(new Exception());

        // Act
        var result = _controller.GetTransactionsByPortfolioId(1);

        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
}


