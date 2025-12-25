using EcommerceDataAccessLayer.DataContext;
using EcommerceDataAccessLayer.Models;

namespace EcommerceDataAccessLayer.Repositories.Contract
{
    public class CategoryRepository : ICategoryRepository
    {
        private static readonly EcommerceDataBase _database = new EcommerceDataBase();

        public void Add(Category entity)
        {
            EcommerceDataBase.Categories.Add(entity);
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if (category is not null)
            {
                EcommerceDataBase.Categories.Remove(category);
                return ;
            }
            throw new Exception("Category Not Found");
        }

        public List<Category> GetAll()
        {
           return EcommerceDataBase.Categories;
        }

        public Category? GetById(int id)
        {
            var category =  EcommerceDataBase.Categories.SingleOrDefault(c => c.Id == id);
            return category;
            
           
        }

        public void Update(int id, Category entity)
        {
            var existingCategory = GetById(id);
            if (existingCategory is not null)
            {
                existingCategory.Name = entity.Name;
                existingCategory.Products = entity.Products;
                
               
            }
            throw new Exception("Product Not Found");
        }
    }
}
