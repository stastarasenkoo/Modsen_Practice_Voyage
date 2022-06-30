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
using Voyage.Tests.TestData.Trip;

namespace Voyage.Tests.Services
{
    [TestFixture]
    public class TripServiceTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnTripDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTripRequests.Create;
            var response = TestTripResponses.Details;

            mocker.Setup<ITripRepository, Task<TripDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TripService>();

            // Act
            var result = await service.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITripRepository>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallRepository()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<ITripRepository, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var service = mocker.CreateInstance<TripService>();

            // Act
            var result = await service.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<ITripRepository>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task FindAsync_WhenIdIsProvided_ShouldCallRepositoryAndReturnTripDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var response = TestTripResponses.NullableDetails;

            mocker.Setup<ITripRepository, Task<TripDetailsResponse?>>(x => x.FindAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TripService>();

            // Act
            var result = await service.FindAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<ITripRepository>(x => x.FindAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task GetAsync_ShouldCallRepositoryAndReturnTripShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestTripResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<ITripRepository, Task<IEnumerable<TripShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TripService>();

            // Act
            var result = await service.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<ITripRepository>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnTripDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestTripRequests.Update;
            var response = TestTripResponses.NullableDetails;

            mocker.Setup<ITripRepository, Task<TripDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<TripService>();

            // Act
            var result = await service.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<ITripRepository>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }
    }
}
