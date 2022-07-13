using EfCoreRepository.Interfaces;
using Logic.Interfaces;
using Models;

namespace Logic;

public class GoalLogic : IGoalLogic
{
    private readonly IBasicCrud<Goal> _repository;

    public GoalLogic(IEfRepository repository)
    {
        _repository = repository.For<Goal>();
    }
    
    public async Task<Goal> Save(Goal goal)
    {
        var insertedGaol = await _repository.Save(goal);

        return insertedGaol;
    }
    
    public async Task<Goal> Update(int id, Goal goal)
    {
        var updatedGoal = await _repository.Update(id, goal);

        return updatedGoal;
    }

    public async Task<Goal> Delete(int id)
    {
        var goal = await _repository.Get(id);

        await _repository.Delete(id);

        return goal;
    }
    
    public async Task<Goal> Renew(int id)
    {
        var goal = await _repository.Get(id);
        
        // Renew the goal
        goal.RenewedDate = DateTimeOffset.Now;

        await _repository.Update(id, goal);

        return goal;
    }

    public async Task<IEnumerable<Goal>> GetAll()
    {
        var goals = (await _repository.GetAll()).ToList();
        
        return goals;
    }
}