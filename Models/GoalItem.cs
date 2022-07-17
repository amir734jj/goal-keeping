using Models.Interfaces;

namespace Models;

public class GoalItem : IEntity
{
    public int Id { get; set; }
    
    public string Text { get; set; }
    
    public Goal GoalRef { get; set; }
    public int GoalRefId { get; set; }
}