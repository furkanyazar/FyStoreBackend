using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class Entity : IEntity
{
    public int Id { get; set; }
    public DateTime DateOfCreate { get; set; }
    public DateTime DateOfLastUpdate { get; set; }
}