using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace UI.Logic;

public class JwtAuthStateProvider : AuthenticationStateProvider
{
    private readonly ISessionStorageService _sessionStorageService;
    private readonly ILogger<JwtAuthStateProvider> _logger;

    public JwtAuthStateProvider(ISessionStorageService sessionStorageService, ILogger<JwtAuthStateProvider> logger)
    {
        _sessionStorageService = sessionStorageService;
        _logger = logger;
        this.NotifyAuthenticationStateChanged();
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenString = await _sessionStorageService.GetItemAsStringAsync("token");
        var claimsIdentity = new ClaimsIdentity();
        
        _logger.LogTrace("JWT token is {}", tokenString);
        
        if (!string.IsNullOrEmpty(tokenString))
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(tokenString);
            var token = jsonToken as JwtSecurityToken;
            
            _logger.LogTrace("JWT token claim is {}", token?.Claims);
            
            claimsIdentity = new ClaimsIdentity(token?.Claims);
        }

        return new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
    }

    public void NotifyAuthenticationStateChanged()
    {
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}