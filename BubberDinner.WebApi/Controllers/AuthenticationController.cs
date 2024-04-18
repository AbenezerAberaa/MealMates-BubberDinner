
using BubberDinner.Application.Services.Authentication;
using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.WebApi.Controllers
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


        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            // Register the user
            var authResult = _authenticationService.Register(request.firstName, request.lastName, request.Email, request.Password);
            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
        
            return Ok(response);
        }

        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            // Login the user
            var authResult = _authenticationService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(authResult.User.Id, authResult.User.FirstName, authResult.User.LastName, authResult.User.Email, authResult.Token);
            return Ok(response);
        }
    }
}


