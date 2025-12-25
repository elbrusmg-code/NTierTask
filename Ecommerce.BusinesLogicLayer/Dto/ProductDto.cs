using Ecommerce.EcommerceDataAccessLayer.Models;

namespace Ecommerce.BusinesLogicLayer.Dto;

public class ProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? CategoryName { get; set; }
}

public class CreateProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public Cate
}

