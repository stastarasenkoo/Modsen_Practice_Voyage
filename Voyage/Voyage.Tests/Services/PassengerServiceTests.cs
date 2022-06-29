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
using Voyage.Tests.TestData.Passanger;

namespace Voyage.Tests.Services
{
    [TestFixture]
    public class PassengerServiceTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnPassengerDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestPassengerRequests.Create;
            var response = TestPassengerResponses.Details;

            mocker.Setup<IPassengerRepository, Task<PassengerDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<PassengerService>();

            // Act
            var result = await service.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerRepository>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallRepository()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<IPassengerRepository, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var service = mocker.CreateInstance<PassengerService>();

            // Act
            var result = await service.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerRepository>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnPassengerDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestPassengerRequests.Update;
            var response = TestPassengerResponses.NullableDetails;

            mocker.Setup<IPassengerRepository, Task<PassengerDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<PassengerService>();

            // Act
            var result = await service.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerRepository>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task GetAsync_ShouldCallRepositoryAndReturnPassengerShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestPassengerResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<IPassengerRepository, Task<IEnumerable<PassengerShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<PassengerService>();

            // Act
            var result = await service.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerRepository>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task GetByIdAsync_ShouldCallRepositoryAndReturnPassengerShortInfo()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestPassengerResponses.Details;
            var id = 1;

            mocker.Setup<IPassengerRepository, Task<PassengerDetailsResponse>>(x => x.GetByIdAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<PassengerService>();

            // Act
            var result = await service.GetByIdAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IPassengerRepository>(x => x.GetByIdAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }
    }
}
