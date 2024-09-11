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

public class MarketValueControllerTests
{
    private readonly Mock<IMarketValue> _mockMarketValueRepository;
    private readonly Mock<ILogger<MarketValueController>> _mockLogger;
    private readonly MarketValueController _controller;

    public MarketValueControllerTests()
    {
        _mockMarketValueRepository = new Mock<IMarketValue>();
        _mockLogger = new Mock<ILogger<MarketValueController>>();
        _controller = new MarketValueController(_mockMarketValueRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public void GetMarketValueByAssetId_ShouldReturnOkWithMarketValues()
    {
        // Arrange
        var mockMarketValues = new List<MarketValue>
        {
            new MarketValue { Id = 1, AssetId = 1, Price = 150 },
            new MarketValue { Id = 2, AssetId = 1, Price = 155 }
        };
        _mockMarketValueRepository.Setup(repo => repo.GetMarketValueByAssetId(1)).Returns(mockMarketValues);

        // Act
        var result = _controller.GetMarketValueByAssetId(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedMarketValues = Assert.IsAssignableFrom<IEnumerable<MarketValue>>(okResult.Value);
        Assert.Equal(2, returnedMarketValues.Count());
    }

    [Fact]
    public void GetMarketValueByAssetId_WhenExceptionThrown_ShouldReturnInternalServerError()
    {
        // Arrange
        _mockMarketValueRepository.Setup(repo => repo.GetMarketValueByAssetId(1)).Throws(new Exception());

        // Act
        var result = _controller.GetMarketValueByAssetId(1);

        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
}


