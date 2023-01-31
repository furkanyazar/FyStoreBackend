namespace Core.Entities.Abstract;

public class Entity : IEntity
{
    public int Id { get; set; }
    public DateTime? DateOfCreate { get; set; }
    public DateTime? DateOfLastUpdate { get; set; }
}