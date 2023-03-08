using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using DDDWebapi.Application.Services.Orders;
using DDDWebapi.Domain.Entities;
using DDDWebapi.Api.Controllers;


[TestFixture]
public class OrdersControllerTests
{
    private OrdersController _controller;
    private Mock<IOrderService> _orderServiceMock;

    [SetUp]
    public void Setup()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _controller = new OrdersController(_orderServiceMock.Object);
    }

    [Test]
    public async Task GetOrders_ReturnsOkResultWithOrders()
    {
        // Arrange
        var orders = new List<Order>
        {
            new Order { Id = Guid.NewGuid(), OrderDate = DateTime.UtcNow },
            new Order { Id = Guid.NewGuid(), OrderDate = DateTime.UtcNow }
        };
        _orderServiceMock.Setup(s => s.GetOrdersAsync()).ReturnsAsync(orders);

        // Act
        var result = await _controller.GetOrders();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.AreEqual(orders, okResult.Value);
    }

    [Test]
    public async Task GetOrder_WithValidId_ReturnsOkResultWithOrder()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        var order = new Order { Id = orderId, OrderDate = DateTime.UtcNow };
        _orderServiceMock.Setup(s => s.GetOrderAsync(orderId)).ReturnsAsync(order);

        // Act
        var result = await _controller.GetOrder(orderId);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.AreEqual(order, okResult.Value);
    }

    [Test]
    public async Task GetOrder_WithInvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        _orderServiceMock.Setup(s => s.GetOrderAsync(orderId)).ReturnsAsync((Order)null);

        // Act
        var result = await _controller.GetOrder(orderId);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result.Result);
    }

    [Test]
    public async Task AddOrder_WithValidOrder_ReturnsCreatedAtActionResultWithNewOrder()
    {
        // Arrange
        var newOrder = new Order { Id = Guid.NewGuid(), OrderDate = DateTime.UtcNow };
        _orderServiceMock.Setup(s => s.AddOrderAsync(newOrder)).ReturnsAsync(newOrder);

        // Act
        var result = await _controller.AddOrder(newOrder);

        // Assert
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
        var createdAtActionResult = result.Result as CreatedAtActionResult;
        Assert.AreEqual(newOrder, createdAtActionResult.Value);
    }

    [Test]
    public async Task UpdateOrder_WithValidOrder_ReturnsOkResultWithUpdatedOrder()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        var updatedOrder = new Order { Id = orderId, OrderDate = DateTime.UtcNow };
        _orderServiceMock.Setup(s => s.UpdateOrderAsync(updatedOrder)).ReturnsAsync(updatedOrder);

        // Act
        var result = await _controller.UpdateOrder(orderId, updatedOrder);

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.AreEqual(updatedOrder, okResult.Value);
    }

    [Test]
    public async Task UpdateOrder_WithMismatchedId_ReturnsBadRequestResult()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        var order = new Order { Id = Guid.NewGuid(), OrderDate = DateTime.UtcNow };

        // Act
        var result = await _controller.UpdateOrder(orderId, order);

        // Assert
        Assert.IsInstanceOf<BadRequestResult>(result.Result);
}

[Test]
public async Task UpdateOrder_WithInvalidId_ReturnsNotFoundResult()
{
    // Arrange
    var orderId = Guid.NewGuid();
    var order = new Order { Id = orderId, OrderDate = DateTime.UtcNow };
    _orderServiceMock.Setup(s => s.UpdateOrderAsync(order)).ReturnsAsync((Order)null);

    // Act
    var result = await _controller.UpdateOrder(orderId, order);

    // Assert
    Assert.IsInstanceOf<NotFoundResult>(result.Result);
}

[Test]
public async Task DeleteOrder_WithValidId_ReturnsNoContentResult()
{
    // Arrange
    var orderId = Guid.NewGuid();

    // Act
    var result = await _controller.DeleteOrder(orderId);

    // Assert
    Assert.IsInstanceOf<NoContentResult>(result);
    _orderServiceMock.Verify(s => s.DeleteOrderAsync(orderId), Times.Once);
}
}