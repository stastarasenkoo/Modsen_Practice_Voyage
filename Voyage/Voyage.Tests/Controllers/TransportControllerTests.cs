using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.ResponseModels;
using Voyage.Tests.TestData.Transport;
using Voyage.Tests.Transport.TestData;
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

            mocker.Setup<ITransportService, Task<TransportDetailsResponse>>(x => x.CreateAsync(request))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.CreateAsync(request);

            // Assert
            mocker.Verify<ITransportService>(x => x.CreateAsync(request), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallService()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<ITransportService, Task<bool>>(x => x.DeleteAsync(id))
                .Returns(Task.FromResult(isDeleted));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.DeleteAsync(id);

            // Assert
            mocker.Verify<ITransportService>(x => x.DeleteAsync(id), Times.Once);
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public async Task GetByIdAsync_WhenIdIsProvided_ShouldCallServiceAndReturnOkResult()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var response = TestTransportResponses.NullableDetails;

            mocker.Setup<ITransportService, Task<TransportDetailsResponse?>>(x => x.FindAsync(id))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.GetByIdAsync(id);

            // Assert
            mocker.Verify<ITransportService>(x => x.FindAsync(id), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task GetAsync_ShouldCallServiceAndReturnTransportOkResult()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestTransportResponses.ShortInfoList;

            mocker.Setup<ITransportService, Task<IEnumerable<TransportShortInfoResponse>>>(x => x.GetAsync())
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.GetAsync();

            // Assert
            mocker.Verify<ITransportService>(x => x.GetAsync(), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnTransportDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTransportRequests.Update;
            var response = TestTransportResponses.NullableDetails;

            mocker.Setup<ITransportService, Task<TransportDetailsResponse?>>(x => x.UpdateAsync(request))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<TransportController>();

            // Act
            var result = await controller.UpdateAsync(request);

            // Assert
            mocker.Verify<ITransportService>(x => x.UpdateAsync(request), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
