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
using Voyage.Tests.TestData.Route;

namespace Voyage.Tests.Services
{
    [TestFixture]
    public class RouteServiceTests
    {
        [Test]
        public async Task CreateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnRouteDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestRouteRequests.Create;
            var response = TestRouteResponses.Details;

            mocker.Setup<IRouteRepository, Task<RouteDetailsResponse>>(x => x.CreateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<RouteService>();

            // Act
            var result = await service.CreateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteRepository>(x => x.CreateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task DeleteAsync_WhenIdIsProvided_ShouldCallRepository()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var isDeleted = true;

            mocker.Setup<IRouteRepository, Task<bool>>(x => x.DeleteAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(isDeleted));

            var service = mocker.CreateInstance<RouteService>();

            // Act
            var result = await service.DeleteAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteRepository>(x => x.DeleteAsync(id, CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task FindAsync_WhenIdIsProvided_ShouldCallRepositoryAndReturnRouteDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var id = 1;
            var response = TestRouteResponses.NullableDetails;

            mocker.Setup<IRouteRepository, Task<RouteDetailsResponse?>>(x => x.FindAsync(id, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<RouteService>();

            // Act
            var result = await service.FindAsync(id, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteRepository>(x => x.FindAsync(id, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task GetAsync_ShouldCallRepositoryAndReturnRouteShortInfoList()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var response = TestRouteResponses.ShortInfoList;
            var page = 1;

            mocker.Setup<IRouteRepository, Task<IEnumerable<RouteShortInfoResponse>>>(x => x.GetAsync(page, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<RouteService>();

            // Act
            var result = await service.GetAsync(page, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteRepository>(x => x.GetAsync(page, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        [Test]
        public async Task UpdateAsync_WhenRequestIsProvided_ShouldCallRepositoryAndReturnRouteDetails()
        {
            // Arrange
            var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
            var request = TestRouteRequests.Update;
            var response = TestRouteResponses.NullableDetails;

            mocker.Setup<IRouteRepository, Task<RouteDetailsResponse?>>(x => x.UpdateAsync(request, CancellationToken.None))
                .Returns(Task.FromResult(response));

            var service = mocker.CreateInstance<RouteService>();

            // Act
            var result = await service.UpdateAsync(request, CancellationToken.None);

            // Assert
            mocker.Verify<IRouteRepository>(x => x.UpdateAsync(request, CancellationToken.None), Times.Once);
            result.Should().BeEquivalentTo(response);
        }

        //[Test]
        //public async Task FindByNameAsync_ShouldCallRepositoryAndReturnIenumerableOfRouteDetails()
        //{
        //    // Arrange
        //    var mocker = new AutoMocker(MockBehavior.Default, DefaultValue.Mock);
        //    var name = "Name";
        //    var response = TestRouteResponses.ShortInfoList;

        //    mocker.Setup<IRouteRepository, Task<IEnumerable<RouteDetailsResponse?>>>(x => x.FindByNameAsync(name, CancellationToken.None))
        //        .Returns(Task.FromResult(response));

        //    var service = mocker.CreateInstance<RouteService>();

        //    // Act
        //    var result = await service.FindByNameAsync(name, CancellationToken.None);

        //    // Assert
        //    mocker.Verify<IRouteRepository>(x => x.FindByNameAsync(name, CancellationToken.None), Times.Once);
        //    result.Should().BeEquivalentTo(response);
        //}
    }
}
