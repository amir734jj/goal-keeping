using Models;
using Models.ViewModels.Api;

namespace Logic.Interfaces;

public interface IGoalLogic : IBasicLogic<Goal>
{
    Task<Goal> Renew(int id);

    Task<GoalViewModel?> GetTodayGaol(User user);

    Task<GoalViewModel?> SaveTodayGaol(User user, GoalViewModel goalViewModel);

    Task<GoalViewModel?> UpdateTodayGaol(User user, GoalViewModel goalViewModel);
}