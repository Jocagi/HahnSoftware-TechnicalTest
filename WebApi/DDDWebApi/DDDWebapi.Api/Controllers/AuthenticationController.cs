using Microsoft.AspNetCore.Mvc;
using DDDWebapi.Contracts.Authentication;
using DDDWebapi.Application.Services.Authentication;

namespace DDDWebapi.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            //Call service 
            var result = _authenticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );
            var response = new AuthenticationResponse(
                result.User.Id,
                result.User.FirstName,
                result.User.LastName,
                result.User.Email,
                result.Token
            );
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            Response.Headers.Add("Access-Control-Allow-Headers", "*");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            //Call service 
            var result = _authenticationService.Login(
                request.Email,
                request.Password
            );
            var response = new AuthenticationResponse(
                result.User.Id,
                result.User.FirstName,
                result.User.LastName,
                result.User.Email,
                result.Token
            );
            return Ok(response);
        }
    }
}