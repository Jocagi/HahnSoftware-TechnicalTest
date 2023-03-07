using DDDWebapi.Domain.Entities;
using DDDWebapi.Application.Common.Interfaces.Persistance;

namespace DDDWebapi.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}