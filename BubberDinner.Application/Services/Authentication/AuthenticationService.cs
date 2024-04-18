using BubberDinner.Application.Common.Interfaces.Authentication;
using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Entities;

namespace BubberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }
        public AuthenticationResult Login(string Email, string Password)
        {
            // check if user exists
            if (_userRepository.GetUserByEmail(Email) is not User user)
            {
                throw new Exception("User with given email does not exist");
            }
            if (user.Password != Password)
            {
                throw new Exception("Invalid password");
            }
            // Generate token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
        {
            // check if user already exists
            if ( _userRepository.GetUserByEmail(Email) is not null)
            {
                throw new Exception("User with given email already exists");
            }
            var user = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };
            // create user
            _userRepository.AddUser(user);
            // Generate token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);    
        } 
    }
}