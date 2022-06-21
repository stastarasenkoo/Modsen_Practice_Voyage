﻿using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides ticket endpoinst.
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
        public async Task<IActionResult> GetAsync(GetTicketsRequest request)
        {
            return Ok(await service.GetAsync(request));
        }
        /// <summary>
        /// Creates ticket.
        /// </summary>
        /// <param name="request">Create ticket request information.</param>
        [HttpPost]
        [ProducesResponseType(typeof(TicketDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateTicketRequest request)
        {
            return Ok(await service.CreateAsync(request));
        }
        /// <summary>
        /// Deletes ticket by request.
        /// </summary>
        /// <param name="request">Ticket request to delete.</param>
        [HttpDelete("{request}")]
        [ProducesResponseType(typeof(TicketDetailsResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(DeleteTicketRequest request)
        {
            await service.DeleteAsync(request);

            return NoContent();
        }
        /// <summary>
        /// Gets ticket details.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TicketDetailsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTicketDetailsAsync(GetTicketDetailsRequest request)
        {
            return Ok(await service.GetTicketDetailsAsync(request));
        }
    }
}
