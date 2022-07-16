using Models.ViewModels.Identities;
using Refit;

namespace UI.Interfaces;

public interface IAccountApi
{
    [Post("/account/register")]
    Task Register([Body]RegisterViewModel registerViewModel);

    [Post("/account/login")]
    Task<string> Login([Body]LoginViewModel loginViewModel);
    
    [Post("/account/refresh")]
    Task<string> Refresh();
    
    [Get("/account/isAuthenticated")]
    Task<bool> IsAuthenticated();
    
    [Post("/account/logout")]
    Task Logout();
}