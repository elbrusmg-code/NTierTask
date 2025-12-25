using EcommerceDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDataAccessLayer.DataContext
{
    public class EcommerceDataBase
    {
        public static List<Product> Products { get; set; } = [];
        public static List<Category> Categories { get; set; } = [];

        public EcommerceDataBase()
        {
            var categoryA = new Category { Id=1, Name = "Meyve Terevez" };
            var categoryB = new Category { Id=2, Name = "Et Mehsullari" };
            var categoryC = new Category { Id=3, Name = "Un Memulatlari" };
            Categories.AddRange([categoryA, categoryB, categoryC]);
            var prodA = new Product { Id = 1,Name = "Alma",Price = 1.75m,Category = categoryA};
            var prodB = new Product { Id = 2,Name = "Dana-Eti",Price = 18.75m,Category = categoryB};
            var prodc = new Product { Id = 3, Name = "Paxlava", Price = 5.69m, Category = categoryC };
            var prodD = new Product { Id = 4, Name = "Pomidor", Price = 1.55m, Category = categoryA };
            var prodE = new Product { Id = 5, Name = "Quzu Eti", Price = 21.75m, Category = categoryB };
            var prodF = new Product { Id = 6, Name = "Corek", Price = 1.00m, Category = categoryC };
            Products.AddRange([prodA,prodB,prodc, prodD, prodE, prodF]);





        }
    }
}
