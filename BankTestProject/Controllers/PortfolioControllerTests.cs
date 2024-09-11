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

public class PortfolioControllerTests
{
    private readonly Mock<IPortfolio> _mockPortfolioRepository;
    private readonly Mock<ILogger<PortfoliosController>> _mockLogger;
    private readonly PortfoliosController _controller;

    public PortfolioControllerTests()
    {
        _mockPortfolioRepository = new Mock<IPortfolio>();
        _mockLogger = new Mock<ILogger<PortfoliosController>>();
        _controller = new PortfoliosController(_mockPortfolioRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public void GetPortfoliosByUser_ShouldReturnOkWithPortfolios()
    {
        // Arrange
        var mockPortfolios = new List<Portfolio>
        {
            new Portfolio { Id = 1, Name = "Tech Stocks", UserId = 1 },
            new Portfolio { Id = 2, Name = "Cryptos", UserId = 1 }
        };
        _mockPortfolioRepository.Setup(repo => repo.GetPortfoliosByUserId(1)).Returns(mockPortfolios);

        // Act
        var result = _controller.GetPortfoliosByUserId(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedPortfolios = Assert.IsAssignableFrom<IEnumerable<Portfolio>>(okResult.Value);
        Assert.Equal(2, returnedPortfolios.Count());
    }

    [Fact]
    public void GetPortfoliosByUser_WhenExceptionThrown_ShouldReturnInternalServerError()
    {
        // Arrange
        _mockPortfolioRepository.Setup(repo => repo.GetPortfoliosByUserId(1)).Throws(new Exception());

        // Act
        var result = _controller.GetPortfoliosByUserId(1);

        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
}

