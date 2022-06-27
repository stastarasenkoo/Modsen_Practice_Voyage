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
using Voyage.Tests.TestData.Transport;
using Voyage.WebAPI.Controllers;

namespace Voyage.Tests.Controllers
{
    [TestFixture]
    public class TransportControllerTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnOkResult()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTransportRequests.Create;
            var response = TestTransportResponses.Details;

            mocker.Setup<ITransportService, Task<TransportDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportService>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallService()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<ITransportService, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportService>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public async Task FindAsync_WhenIdIsProvided_ShouldCallServiceAndReturnOkResult()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var response = TestTransportResponses.NullableDetails;

            mocker.Setup<ITransportService, Task<TransportDetailsResponse?>>(x => x.FindAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.FindAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportService>(x => x.FindAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task GetAsync_ShouldCallServiceAndReturnTransportOkResult()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestTransportResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<ITransportService, Task<IEnumerable<TransportShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportService>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnTransportDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTransportRequests.Update;
            var response = TestTransportResponses.NullableDetails;

            mocker.Setup<ITransportService, Task<TransportDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITransportService>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
