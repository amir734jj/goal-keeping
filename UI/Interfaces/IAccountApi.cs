using Models;
using Models.ViewModels.Identities;
using Refit;

namespace UI.Interfaces;

public interface IAccountApi
{
    [Get("/users/{user}")]
    Task<User> GetUser(string user);

    [Post("/account/register")]
    Task Register([Body]RegisterViewModel registerViewModel);

    [Post("/account/login")]
    Task Login([Body]LoginViewModel loginViewModel);
}