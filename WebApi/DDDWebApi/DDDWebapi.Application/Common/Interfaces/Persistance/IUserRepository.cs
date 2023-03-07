using DDDWebapi.Domain.Entities;

namespace DDDWebapi.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        User? GetUserByEmail (string email);

        void AddUser (User user);

    }
}