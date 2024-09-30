using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using API.Contract.IRepository;
using API.Contract.IService;
using API.Data.Dto;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] 
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        
        [HttpPost]
        [Route("api/auth/register")] 
        public IActionResult Register([FromBody] RegistorDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool isEmailExist = _accountService.CheckEmailExist(user.Email);
            if (isEmailExist)
            {
                return Conflict("Email already exists");
            }

            var result = _accountService.CreateNewRegistor(user);
            return Ok(result);
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<IActionResult> Login([FromBody][Required] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _accountService.LoginWithUser(loginDto);

            if (!result.IsSuccess)
            {
                return Unauthorized(result.message);
            }

            return Ok(result);
        }

        [HttpPut]
        [Route("api/profile/update")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDto updateProfileeDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

             string userId = User.FindFirst("userId")?.Value;
            
            return Ok(userId);
        }
    }
}
