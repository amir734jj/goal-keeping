using Models;

namespace Logic.Interfaces;

public interface IGoalLogic
{
    Task<List<Goal>> GetAll();

    Task<Goal> Save(Goal goal);

    Task<Goal> Update(int id, Goal goal);

    Task<Goal> Delete(int id);

    Task<Goal> Renew(int id);
}