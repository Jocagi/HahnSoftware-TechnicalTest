using DDDWebapi.Application.Common.Interfaces.Authentication;

namespace DDDWebapi.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //Check if user already exists

            //Create user

            //Create token
            var token = _jwtTokenGenerator.CreateToken(Guid.NewGuid(), firstName, lastName);

            return new AuthenticationResult(
                Guid.NewGuid(), 
                firstName, 
                lastName, 
                email, 
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(), 
                "John", 
                "Doe", 
                email, 
                "token");
        }
    }
}