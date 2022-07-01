using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Ticket;
using Voyage.Common.ResponseModels;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides ticket endpoints.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TicketController"/> class.
        /// </summary>
        /// <param name="service">Ticket service.</param>
        public TicketController(ITicketService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Gets tickets.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TicketShortInfoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync([FromQuery] int page,[FromQuery] TicketSearchRequest request, CancellationToken cancellationToken)
        {
            return Ok(await service.GetAsync(page, request, cancellationToken));
        }

        /// <summary>
        /// Gets ticket details.
        /// </summary>
        [HttpGet("details")]
        [ProducesResponseType(typeof(TicketDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTicketDetailsAsync([FromQuery] TicketRequest request)
        {
            return Ok(await service.GetTicketDetailsAsync(request));
        }

        /// <summary>
        /// Creates ticket.
        /// </summary>
        /// <param name="request">Create ticket request information.</param>
        /// <param name="cancellationtoken">Cancellation token</param>
        [HttpPost]
        [ProducesResponseType(typeof(TicketDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(TicketRequest request, CancellationToken cancellationtoken)
        {
            return Ok(await service.CreateAsync(request, cancellationtoken));
        }

        /// <summary>
        /// Deletes ticket by request.
        /// </summary>
        /// <param name="request">Ticket request to delete.</param>
        /// <param name="cancellationtoken">Cancellation token</param>
        [HttpDelete]
        [ProducesResponseType(typeof(bool), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync([FromQuery] TicketRequest request, CancellationToken cancellationtoken)
        {
            await service.DeleteAsync(request, cancellationtoken);

            return NoContent();
        }
    }
}
