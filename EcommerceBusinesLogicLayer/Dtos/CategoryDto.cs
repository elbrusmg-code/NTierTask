using EcommerceDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBusinesLogicLayer.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Product> products { get; set; }

    }
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class UpdateCategoryDto
    {
        public string? Name { get; set; }
    }
}
