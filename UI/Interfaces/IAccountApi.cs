using Models;
using Refit;

namespace UI.Interfaces;

public interface IAccountApi
{
    [Get("/users/{user}")]
    Task<User> GetUser(string user);
}