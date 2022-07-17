using System.Diagnostics.CodeAnalysis;
using Models.ViewModels.Api;
using Refit;

namespace UI.Interfaces;

public interface IGoalApi
{
    [Get("/goal/today")]
    public Task<GoalViewModel?> GetTodayGaol();
    
    [Put("/goal/today")]
    public Task<GoalViewModel> UpdateTodayGoal([Body] GoalViewModel goalViewModel);
    
    [Post("/goal/today")]
    public Task<GoalViewModel> SaveTodayGoal([Body] GoalViewModel goalViewModel);
}