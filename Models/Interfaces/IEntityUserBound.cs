namespace Models.Interfaces;

public interface IEntityUserBound : IEntity
{
    public User UserRef { get; set; }
    
    public int UserRefId { get; set; }
}