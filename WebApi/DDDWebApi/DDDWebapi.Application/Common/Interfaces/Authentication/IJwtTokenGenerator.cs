namespace DDDWebapi.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string CreateToken(Guid userId, string firstName, string lastName);
    }
}