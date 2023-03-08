using DDDWebapi.Application.Common.Interfaces.Authentication;
using DDDWebapi.Application.Common.Interfaces.Persistance;
using DDDWebapi.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace DDDWebapi.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        
        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Encoding.UTF8.GetString(hashedBytes);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //Check if user does not exist
            if(_userRepository.GetUserByEmail(email) is not null)
                throw new Exception("User already exists");

            //Hash password
            string hashedPassword = HashPassword(password);

            //Create user
            var user = new User {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = hashedPassword
            };

            //Add user to database
            _userRepository.AddUser(user);

            //Create token
            var token = _jwtTokenGenerator.CreateToken(user);

            return new AuthenticationResult(
                user, 
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            //Check if user exists
            var user = _userRepository.GetUserByEmail(email);
            if(user is null)
                throw new Exception("User does not exist");

            //Hash password
            string hashedPassword = HashPassword(password);

            //Check if password is correct
            if(user.Password != hashedPassword)
                throw new Exception("Password is incorrect");

            //Create token
            var token = _jwtTokenGenerator.CreateToken(user);

            return new AuthenticationResult(
                user, 
                token);
        }
    }
}