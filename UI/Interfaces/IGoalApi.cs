using Models;
using Models.ViewModels.Api;
using Refit;

namespace UI.Interfaces;

public interface IGoalApi
{
    [Get("/goal/today")]
    public Task<List<Goal>> GetTodayGaols();
    
    [Get("/goal/{id}")]
    public Task<Goal> Get([AliasAs("id")] int id);
    
    [Get("/goal")]
    public Task<List<Goal>> GetAll();
    
    [Put("/goal/{id}")]
    public Task<GoalViewModel> Update([AliasAs("id")] int id, [Body]Goal goal);
    
    [Post("/goal")]
    public Task<GoalViewModel> Save([Body]Goal goal);
    
    [Delete("/goal/{id}")]
    public Task<GoalViewModel> Delete([AliasAs("id")] int id);
}