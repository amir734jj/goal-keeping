using Models;

namespace Logic.Interfaces;

public interface IGoalLogic : IBasicLogicUserBound<Goal>
{
    Task<IEnumerable<Goal>> GetAll(User user, DateTimeOffset addedDate);
}