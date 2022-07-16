using Models.ViewModels.Api;
using Refit;

namespace UI.Interfaces;

public interface IProfileApi
{
    [Get("/profile")]
    Task<ProfileViewModel> Get();

    [Post("/profile")]
    Task<ProfileViewModel> Update([Body]ProfileViewModel profileViewModel);
}