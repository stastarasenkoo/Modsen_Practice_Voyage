using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Transport;
using Voyage.Common.ResponseModels;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides transport endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Administrator")]
    public class TransportController : ControllerBase
    {
        private readonly ITransportService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransportController"/> class.
        /// </summary>
        /// <param name="service">Transport service.</param>
        public TransportController(ITransportService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets transport by id.
        /// </summary>
        /// <param name="id">Transport id.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransportShortInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindAsync(int id, CancellationToken cancellationToken)
        {
            return Ok(await service.FindAsync(id, cancellationToken));
        }

        /// <summary>
        /// Gets transports.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TransportShortInfoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] int page, CancellationToken cancellationToken)
        {
            return Ok(await service.GetAsync(page, cancellationToken));
        }

        /// <summary>
        /// Creates transport.
        /// </summary>
        /// <param name="request">Create transport request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(typeof(TransportDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateTransportRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.CreateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Updates transport.
        /// </summary>
        /// <param name="request">Update transport request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPut]
        [ProducesResponseType(typeof(TransportDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateTransportRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.UpdateAsync(request, cancellationToken));
        }

        /// <summary>
        /// Deletes transport by id.
        /// </summary>
        /// <param name="id">Transport id to delete.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TransportDetailsResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await service.DeleteAsync(id, cancellationToken);

            return NoContent();
        }
    }
}
