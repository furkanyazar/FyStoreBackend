using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class OperationClaim : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}