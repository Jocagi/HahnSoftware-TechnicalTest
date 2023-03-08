using DDDWebapi.Domain.Entities;
using DDDWebapi.Application.Common.Interfaces.Persistance;
using DDDWebapi.Infrastructure.Objects;

namespace DDDWebapi.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}