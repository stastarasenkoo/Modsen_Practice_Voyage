using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides route endpoinst.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteController"/> class.
        /// </summary>
        /// <param name="service">Transport service.</param>
        public RouteController(IRouteService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets route by id.
        /// </summary>
        /// <param name="id">Route id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RouteShortInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindAsync(int id, CancellationToken cancellationToken)
        {
            return Ok(await service.FindAsync(id, cancellationToken));
        }

        /// <summary>
        /// Gets routes by name.
        /// </summary>
        /// <param name="name">Route name.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet("search")]
        [ProducesResponseType(typeof(RouteShortInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindByNameAsync([FromQuery] string name, CancellationToken cancellationToken)
        {
            return Ok(await service.FindByNameAsync(name, cancellationToken));
        }

        /// <summary>
        /// Gets routes.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RouteShortInfoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] int page, CancellationToken cancellationToken)
        {
            return Ok(await service.GetAsync(page, cancellationToken));
        }

        /// <summary>
        /// Creates route.
        /// </summary>
        /// <param name="request">Create route request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(typeof(RouteDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateRouteRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.CreateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Updates route.
        /// </summary>
        /// <param name="request">Update route request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPut]
        [ProducesResponseType(typeof(RouteDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateRouteRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.UpdateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Deletes route by id.
        /// </summary>
        /// <param name="id">Route id to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RouteDetailsResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
