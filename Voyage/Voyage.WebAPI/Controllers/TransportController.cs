using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.Common.ResponseModels;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides transport endpoinst.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        /// Gets transports.
        /// </summary>
        [HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<TransportShortInfoResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAsync()
        {
            return Ok(await service.GetAsync());
        }

        /// <summary>
        /// Gets transport by id.
        /// </summary>
        /// <param name="id">Transport id.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TransportShortInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await service.FindAsync(id));
        }

        /// <summary>
        /// Creates transport.
        /// </summary>
        /// <param name="request">Create transport request information.</param>
        [HttpPost]
        [ProducesResponseType(typeof(TransportDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync(CreateTransportRequest request)
        {
            return Ok(await service.CreateAsync(request));
        }

        /// <summary>
        /// Updates transport.
        /// </summary>
        /// <param name="request">Update transport request information.</param>
        [HttpPut]
        [ProducesResponseType(typeof(TransportDetailsResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateAsync(UpdateTransportRequest request)
        {
            return Ok(await service.UpdateAsync(request));
        }

        /// <summary>
        /// Deletes transport by id.
        /// </summary>
        /// <param name="id">Transport id to delete.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TransportDetailsResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await service.DeleteAsync(id);

            return NoContent();
        }
    }
}
