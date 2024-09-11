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

public class AssetsControllerTests
{
    private readonly Mock<IAsset> _mockAssetRepository;
    private readonly Mock<ILogger<AssetsController>> _mockLogger;
    private readonly AssetsController _controller;

    public AssetsControllerTests()
    {
        _mockAssetRepository = new Mock<IAsset>();
        _mockLogger = new Mock<ILogger<AssetsController>>();
        _controller = new AssetsController(_mockAssetRepository.Object, _mockLogger.Object);
    }

    [Fact]
    public void GetAssets_ShouldReturnOkWithAssets()
    {
        // Arrange
        var mockAssets = new List<Asset>
        {
            new Asset { Id = 1, Name = "Apple", Symbol = "AAPL", Type = AssetType.Stock },
            new Asset { Id = 2, Name = "Bitcoin", Symbol = "BTC", Type = AssetType.Cryptocurrency }
        };
        _mockAssetRepository.Setup(repo => repo.GetAll()).Returns(mockAssets);

        // Act
        var result = _controller.GetAssets();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedAssets = Assert.IsAssignableFrom<IEnumerable<Asset>>(okResult.Value);
        Assert.Equal(2, returnedAssets.Count());
    }

    [Fact]
    public void GetAssets_WhenExceptionThrown_ShouldReturnInternalServerError()
    {
        // Arrange
        _mockAssetRepository.Setup(repo => repo.GetAll()).Throws(new Exception());

        // Act
        var result = _controller.GetAssets();

        // Assert
        var statusCodeResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(500, statusCodeResult.StatusCode);
    }
}

