using IdentityModel.Client;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Voyage.Common.Entities;
using Voyage.Common.RequestModels;

namespace Voyage.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole<int>> roleManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole()
        {
            await roleManager.CreateAsync(new IdentityRole<int>("admin"));
            await roleManager.CreateAsync(new IdentityRole<int>("passenger"));
            await roleManager.CreateAsync(new IdentityRole<int>("driver"));
            return Ok();            
        }       

        [HttpPost]
        [ProducesResponseType(typeof(RegisterModelRequest), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(RegisterModelRequest registerRequest)
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

            var result = await userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "admin");
                await signInManager.SignInAsync(user, false);
                return Ok();
            }

            return BadRequest(result);
        }

    }
}
