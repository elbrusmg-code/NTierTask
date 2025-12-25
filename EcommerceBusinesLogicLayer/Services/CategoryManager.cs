using EcommerceBusinesLogicLayer.Dtos;
using EcommerceBusinesLogicLayer.Services.Contracts;
using EcommerceDataAccessLayer.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceDataAccessLayer.Models;

namespace EcommerceBusinesLogicLayer.Services
{
    public class CategoryManager : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void AddCategory(CreateCategoryDto createCategory)
        {
            _categoryRepository.Add(new Category
            {
                Id = createCategory.Id,
                Name = createCategory.Name
            });
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<CategoryDto> GetCategories()
        {
            var category = _categoryRepository.GetAll();
            return category .Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name

            }).ToList();
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            if( category is null)
            {
                return null;
            }
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

       

     public void UpdateCategory(int id, UpdateCategoryDto category)
        {
            var updatedCategory = new Category
            {
                Id = id,
                Name = category.Name
            };
            _categoryRepository.Update(id, updatedCategory);
        }

       
    }
}
