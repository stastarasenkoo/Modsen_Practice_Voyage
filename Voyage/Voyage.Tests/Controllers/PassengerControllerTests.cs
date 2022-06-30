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
using Voyage.Tests.TestData.Passanger;
using Voyage.WebAPI.Controllers;

namespace Voyage.Tests.Controllers
{
    [TestFixture]
    public class PassengerControllerTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnPassengerDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestPassengerRequests.Create;
            var response = TestPassengerResponses.Details;

            mocker.Setup<IPassengerService, Task<PassengerDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<PassengerController>();

            // Act
            var result = await controller.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerService>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallService()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<IPassengerService, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var controller = mocker.CreateInstance<PassengerController>();

            // Act
            var result = await controller.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerService>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeOfType<NoContentResult>();
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnPassengerDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestPassengerRequests.Update;
            var response = TestPassengerResponses.NullableDetails;

            mocker.Setup<IPassengerService, Task<PassengerDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<PassengerController>();

            // Act
            var result = await controller.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerService>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task GetAsync_ShouldCallServiceAndReturnPassengerShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestPassengerResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<IPassengerService, Task<IEnumerable<PassengerShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<PassengerController>();

            // Act
            var result = await controller.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerService>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Test]
        public async Task GetByIdAsync_ShouldCallServiceAndReturnPassengerShortInfo()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestPassengerResponses.Details;
            var id = 1;

            mocker.Setup<IPassengerService, Task<PassengerDetailsResponse>>(x => x.GetByIdAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<PassengerController>();

            // Act
            var result = await controller.GetByIdAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerService>(x => x.GetByIdAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}
