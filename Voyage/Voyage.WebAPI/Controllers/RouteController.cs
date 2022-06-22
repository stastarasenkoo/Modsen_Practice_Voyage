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
        /// Gets routes.
        /// </summary>
        /// /// <param name="page">Page number.</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RouteShortInfoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] int page)
        {
            return Ok(await service.GetAsync(page));
        }

        /// <summary>
        /// Gets route by id.
        /// </summary>
        /// <param name="id">Route id.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RouteShortInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await service.FindAsync(id));
        }

        /// <summary>
        /// Gets routes by name.
        /// </summary>
        /// <param name="name">Route name.</param>
        [HttpGet("search")]
        [ProducesResponseType(typeof(RouteShortInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindByNameAsync([FromQuery] string name)
        {
            return Ok(await service.FindByNameAsync(name));
        }

        /// <summary>
        /// Creates route.
        /// </summary>
        /// <param name="request">Create route request information.</param>
        [HttpPost]
        [ProducesResponseType(typeof(RouteDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateRouteRequest request)
        {
            return Ok(await service.CreateAsync(request));
        }

        /// <summary>
        /// Updates route.
        /// </summary>
        /// <param name="request">Update route request information.</param>
        [HttpPut]
        [ProducesResponseType(typeof(RouteDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateRouteRequest request)
        {
            return Ok(await service.UpdateAsync(request));
        }

        /// <summary>
        /// Deletes route by id.
        /// </summary>
        /// <param name="id">Route id to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RouteDetailsResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await service.DeleteAsync(id);

            return NoContent();
        }
    }
}
