﻿using Core.Entities.Abstract;

namespace Core.Entities.Concrete;

public class OperationClaim : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }

    public OperationClaim()
    {
    }

    public OperationClaim(int id, string name, string value)
    {
        Id = id;
        Name = name;
        Value = value;
    }
}