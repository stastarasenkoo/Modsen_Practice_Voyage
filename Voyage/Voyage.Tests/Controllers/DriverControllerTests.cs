using FluentAssertions;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.ResponseModels;
using Voyage.Tests.TestData.Driver;
using Voyage.WebAPI.Controllers;

namespace Voyage.Tests.Controllers
{
    [TestFixture]
    public class DriverControllerTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnDriverDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestDriverRequests.Create;
            var response = TestDriverResponses.Details;

            mocker.Setup<IDriverService, Task<DriverDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<DriverController>();

            // Act
            var result = await controller.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverService>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallService()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<IDriverService, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var controller = mocker.CreateInstance<DriverController>();

            // Act
            var result = await controller.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverService>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task GetAsync_ShouldCallServiceAndReturnDriverShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestDriverResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<IDriverService, Task<IEnumerable<DriverShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<DriverController>();

            // Act
            var result = await controller.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverService>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallServiceAndReturnDriverDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestDriverRequests.Update;
            var response = TestDriverResponses.NullableDetails;

            mocker.Setup<IDriverService, Task<DriverDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var controller = mocker.CreateInstance<DriverController>();

            // Act
            var result = await controller.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverService>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }
    }
}
