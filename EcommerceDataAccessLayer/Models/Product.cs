

namespace EcommerceDataAccessLayer.Models;

public class Product: Entity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }

}
