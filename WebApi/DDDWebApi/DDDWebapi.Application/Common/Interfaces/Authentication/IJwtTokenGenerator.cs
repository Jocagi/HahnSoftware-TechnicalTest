using DDDWebapi.Domain.Entities;

namespace DDDWebapi.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(User user);
    }
}