using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Refit;
using UI.Interfaces;

namespace UI.Logic;

public class JwtAuthStateProvider : AuthenticationStateProvider
{
    private readonly ISessionStorageService _sessionStorageService;
    private readonly IAccountApi _accountApi;
    private readonly ILogger<JwtAuthStateProvider> _logger;
    private static bool _keepSessionInProgress;

    public JwtAuthStateProvider(ISessionStorageService sessionStorageService, IAccountApi accountApi, ILogger<JwtAuthStateProvider> logger)
    {
        _sessionStorageService = sessionStorageService;
        _accountApi = accountApi;
        _logger = logger;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var tokenString = await _sessionStorageService.GetItemAsStringAsync("token");
        var claimsIdentity = new ClaimsIdentity();
        
        _logger.LogTrace("JWT token is {}", tokenString);
        
        if (!string.IsNullOrEmpty(tokenString) && await _accountApi.IsAuthenticated())
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(tokenString);
            var token = jsonToken as JwtSecurityToken;
            
            _logger.LogTrace("JWT token claim is {}", token?.Claims);

            if (!_keepSessionInProgress)
            {
                KeepSession();
            }

            claimsIdentity = new ClaimsIdentity(token?.Claims, "jwt");
        }

        return new AuthenticationState(new ClaimsPrincipal(claimsIdentity));
    }

    public void NotifyAuthenticationStateChanged()
    {
        base.NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    
    private async void KeepSession()
    {
        _keepSessionInProgress = true;
        
        while (!string.IsNullOrEmpty(await _sessionStorageService.GetItemAsStringAsync("token")))
        {
            try
            {
                var tokenString = await _accountApi.Refresh();
                await _sessionStorageService.SetItemAsStringAsync("token", tokenString);
            
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(tokenString);

                if (jsonToken is JwtSecurityToken token)
                {
                    var timeSpan = token.ValidTo.Subtract(DateTime.Now.Subtract(TimeSpan.FromMinutes(5)));

                    await Task.Delay(timeSpan);
                }
            }
            catch (ApiException e)
            {
                _logger.LogError(e, "Failed to keep the session alive.");
            
                await _sessionStorageService.RemoveItemAsync("token");
                
                break;
            }
        }

        _keepSessionInProgress = false;
    }
}