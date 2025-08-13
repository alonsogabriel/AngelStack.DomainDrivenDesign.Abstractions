using System.Security.Claims;

namespace DomainDrivenDesign.Abstractions.Extensions;

public static class ClaimExtensions
{
    public static Dictionary<string, string> ToDictionary(this ClaimsPrincipal user)
    {
        return user.Claims.ToDictionary(c => c.Type, c => c.Value);
    }

    public static string Get(this ClaimsPrincipal user, string claim)
    {
        if (user.ToDictionary().TryGetValue(claim, out var value) == false)
        {
            throw new ArgumentException($"Claim '{claim}' not found.", nameof(claim));
        }

        return value;
    }

    public static string GetUserId(this ClaimsPrincipal user)
    {
        var dict = user.ToDictionary();
        string[] claims = ["sub", "nameid", "id", "userId"];

        foreach (var claim in claims)
        {
            if (dict.TryGetValue(claim, out var id))
            {
                return id;
            }
        }
        return string.Empty;
    }

    public static Guid GetUserUuid(this ClaimsPrincipal user)
    {
        return user.GetUserId().ToGuid();
    }
}