﻿namespace Entities.Dtos.Products;

public class ProductListDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
}