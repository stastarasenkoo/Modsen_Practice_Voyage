using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Passenger;
using Voyage.Common.ResponseModels;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides route endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="PassengerController"/> class.
        /// </summary>
        /// <param name="service">Passenger service.</param>
        public PassengerController(IPassengerService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets passengers.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PassengerShortInfoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] int page, CancellationToken cancellationToken)
        {
            return Ok(await service.GetAsync(page, cancellationToken));
        }

        /// <summary>
        /// Gets passenger by id.
        /// </summary>
        /// <param name="id">Passenger id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PassengerShortInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync([FromQuery] int id, CancellationToken cancellationToken)
        {
            return Ok(await service.GetByIdAsync(id, cancellationToken));
        }

        /// <summary>
        /// Creates passenger.
        /// </summary>
        /// <param name="request">Create passenger request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(typeof(PassengerDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(PassengerRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.CreateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Updates passenger's points.
        /// </summary>
        /// <param name="request">Update passenger request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPut("{information for update}")]
        [ProducesResponseType(typeof(PassengerDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(PassengerRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.UpdateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Deletes passenger by id.
        /// </summary>
        /// <param name="id">Passenger id to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PassengerDetailsResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
