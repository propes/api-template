using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace ApiTemplate.IntegrationTests.Fixtures;

public class TestAuthHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder,
    ClaimsPrincipal testUser
) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var ticket = new AuthenticationTicket(testUser, Scheme.Name);
        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}
