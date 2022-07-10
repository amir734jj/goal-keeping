using Models.Interfaces;

namespace Models;

public class Goal : IEntity
{
    public int Id { get; set; }
    
    public DateTimeOffset AddedDate { get; set; }
    
    public DateTimeOffset RenewedDate { get; set; }
    
    public List<GoalItem> GoalItems { get; set; }
    
    public User UserRef { get; set; }
}