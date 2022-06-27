using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides driver endpoinst.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Administrator")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DriverController"/> class.
        /// </summary>
        /// <param name="service">Driver service.</param>
        public DriverController(IDriverService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets driver by id.
        /// </summary>
        /// <param name="id">Driver id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DriverDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return Ok(await service.FindAsync(id, cancellationToken));
        }

        /// <summary>
        /// Gets driver by name.
        /// </summary>
        /// <param name="name">Driver name.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet("search")]
        [ProducesResponseType(typeof(DriverDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindByNameAsync([FromQuery] string name, CancellationToken cancellationToken)
        {
            return Ok(await service.FindByNameAsync(name, cancellationToken));
        }

        /// <summary>
        /// Gets drivers.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DriverShortInfoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] int page, CancellationToken cancellationToken)
        {
            return Ok(await service.GetAsync(page, cancellationToken));
        }

        /// <summary>
        /// Creates driver.
        /// </summary>
        /// <param name="request">Create driver request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(typeof(DriverDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateDriverRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.CreateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Updates driver.
        /// </summary>
        /// <param name="request">Update driver request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPut]
        [ProducesResponseType(typeof(DriverDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateDriverRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.UpdateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Deletes driver by id.
        /// </summary>
        /// <param name="id">Driver id to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DriverDetailsResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
