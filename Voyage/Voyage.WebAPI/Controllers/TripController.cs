using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Trip;
using Voyage.Common.ResponseModels;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides trip endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TripController"/> class.
        /// </summary>
        /// <param name="service">Trip service.</param>
        public TripController(ITripService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets trip by id.
        /// </summary>
        /// <param name="id">Trip id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TripShortInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindAsync(int id, CancellationToken cancellationToken)
        {
            return Ok(await service.FindAsync(id, cancellationToken));
        }

        /// <summary>
        /// Gets trips.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TripShortInfoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] int page, CancellationToken cancellationToken)
        {
            return Ok(await service.GetAsync(page, cancellationToken));
        }

        /// <summary>
        /// Create trip.
        /// </summary>
        /// <param name="request">Create trip request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(typeof(TripDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateTripRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.CreateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Updates trip.
        /// </summary>
        /// <param name="request">Update trip request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPut]
        [ProducesResponseType(typeof(TripDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateTripRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.UpdateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Deletes trip by id.
        /// </summary>
        /// <param name="id">Trip id to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TripDetailsResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
