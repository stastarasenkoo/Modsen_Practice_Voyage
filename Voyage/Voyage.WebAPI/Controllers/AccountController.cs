using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels.Account;
using Voyage.DataAccess.Entities;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides account endpoinst.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="service">Transport service.</param>
        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Register user.
        /// </summary>
        /// <param name="registerRequest">Create user request information.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        [HttpPost]
        [ProducesResponseType(typeof(AppUser), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAsync(SignUpRequestModel registerRequest, CancellationToken cancellationToken)
        {
            return Ok(await service.RegisterAsync(registerRequest, cancellationToken));
        }
    }
}
