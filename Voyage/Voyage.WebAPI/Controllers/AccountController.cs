using Microsoft.AspNetCore.Mvc;
using Voyage.Business.Services.Interfaces;
using Voyage.Common.RequestModels;
using Voyage.DataAccess.Entities;

namespace Voyage.WebAPI.Controllers
{
    /// <summary>
    /// Provides transport endpoinst.
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
        [HttpPost]
        [ProducesResponseType(typeof(RegisterModelRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAsync(RegisterModelRequest registerRequest)
        {
            var user = new AppUser
            {
                FirstName = registerRequest.FirstName,
                SecondName = registerRequest.SeconName,
                ThirdName = registerRequest.Thirdname,
                UserName = registerRequest.UserName,
                PhoneNumber = registerRequest.PhoneNumber,
                Email = registerRequest.Email,
            };

            return Ok(await service.RegisterAsync(user, registerRequest.Password));
        }
    }
}