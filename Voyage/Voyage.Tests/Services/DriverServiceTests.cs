using FluentAssertions;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Voyage.Business.Services;
using Voyage.Common.ResponseModels;
using Voyage.DataAccess.Repositories.Interfaces;
using Voyage.Tests.TestData.Driver;

namespace Voyage.Tests.Services
{
    [TestFixture]
    public class DriverServiceTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnDriverDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestDriverRequests.Create;
            var response = TestDriverResponses.Details;

            mocker.Setup<IDriverRepository, Task<DriverDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<DriverService>();

            // Act
            var result = await service.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverRepository>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallRepository()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<IDriverRepository, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var service = mocker.CreateInstance<DriverService>();

            // Act
            var result = await service.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverRepository>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task FindAsync_WhenIdIsProvided_ShouldCallRepositoryAndReturnDriverDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var response = TestDriverResponses.NullableDetails;

            mocker.Setup<IDriverRepository, Task<DriverDetailsResponse?>>(x => x.FindAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<DriverService>();

            // Act
            var result = await service.FindAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverRepository>(x => x.FindAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task GetAsync_ShouldCallRepositoryAndReturnDriverShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestDriverResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<IDriverRepository, Task<IEnumerable<DriverShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<DriverService>();

            // Act
            var result = await service.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverRepository>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnDriverDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestDriverRequests.Update;
            var response = TestDriverResponses.NullableDetails;

            mocker.Setup<IDriverRepository, Task<DriverDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<DriverService>();

            // Act
            var result = await service.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IDriverRepository>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }
    }
}
