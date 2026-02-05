using AssetTracker.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using AssetTracker.Application.DTO.Auth;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IAuthService _authService; 

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        System.Text.Encodings.Web.UrlEncoder encoder,
        IAuthService authService)
        : base(options, logger, encoder)
    {
        _authService = authService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.NoResult();

        try
        {
            var header = AuthenticationHeaderValue.Parse(Request.Headers.Authorization!);
            if (!"Basic".Equals(header.Scheme, StringComparison.OrdinalIgnoreCase))
                return AuthenticateResult.NoResult();

            var bytes = Convert.FromBase64String(header.Parameter ?? "");
            var raw = Encoding.UTF8.GetString(bytes);
            var parts = raw.Split(':', 2);

            if (parts.Length != 2)
                return AuthenticateResult.Fail("Invalid Basic auth format.");

            var username = parts[0];
            var password = parts[1];


            var ok = await _authService.VerifyLoginAsync(
                new LoginRequest(username, password)
            );

            if (!ok)
                return AuthenticateResult.Fail("Invalid username or password.");

           
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization header.");
        }
    }
}
