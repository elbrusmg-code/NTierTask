using EcommerceBusinesLogicLayer.Dtos;
using EcommerceDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceBusinesLogicLayer.Services.Contracts
{
    public interface ICategoryServices
    {
       List<CategoryDto> GetCategories();
        CategoryDto GetCategoryById(int id);
        void AddCategory(CreateCategoryDto creatCategory);
        void UpdateCategory(int id,UpdateCategoryDto uptadeCategory);
        void DeleteCategory(int id);
        
    }
}
