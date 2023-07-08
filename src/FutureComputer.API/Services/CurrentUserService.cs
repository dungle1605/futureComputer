using System.Security.Claims;
using FutureComputer.Domain.Interfaces;

namespace FutureComputer.API.Services;

public class CurrentUserService : ICurrentUserService
{
    public string Email { get; }

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        Email = GetEmail(httpContextAccessor.HttpContext?.User);
    }

    private static string? GetEmail(ClaimsPrincipal principal)
    {
        return GetClaim(principal, ClaimTypes.Email);
    }

    private static string? GetClaim(ClaimsPrincipal principal, string claimType)
    {
        return principal?.Claims?.FirstOrDefault(p => p.Type.Equals(claimType))?.Type;
    }
}