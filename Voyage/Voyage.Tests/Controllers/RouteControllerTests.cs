using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.ResponseModels;
using Voyage.Tests.TestData.Route;
using Voyage.WebAPI.Controllers;

namespace Voyage.Tests.Controllers
{
    [TestFixture]
    public class RouteControllerTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnRouteDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestRouteRequests.Create;
            var response = TestRouteResponses.Details;

            mocker.Setup<IRouteService, Task<RouteDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<RouteController>();

            // Act
            var result = await controller.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteService>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallService()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<IRouteService, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var controller = mocker.CreateInstance<RouteController>();

            // Act
            var result = await controller.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteService>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public async Task FindAsync_WhenIdIsProvided_ShouldCallServiceAndReturnRouteDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var response = TestRouteResponses.NullableDetails;

            mocker.Setup<IRouteService, Task<RouteDetailsResponse?>>(x => x.FindAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<RouteController>();

            // Act
            var result = await controller.FindAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteService>(x => x.FindAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task GetAsync_ShouldCallServiceAndReturnRouteShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestRouteResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<IRouteService, Task<IEnumerable<RouteShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<RouteController>();

            // Act
            var result = await controller.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteService>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnRouteDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestRouteRequests.Update;
            var response = TestRouteResponses.NullableDetails;

            mocker.Setup<IRouteService, Task<RouteDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<RouteController>();

            // Act
            var result = await controller.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteService>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
