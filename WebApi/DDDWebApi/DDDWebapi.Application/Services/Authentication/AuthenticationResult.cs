using DDDWebapi.Domain.Entities;

namespace DDDWebapi.Application.Services.Authentication
{
    public record AuthenticationResult
    (
        User User,
        string Token
    );
}