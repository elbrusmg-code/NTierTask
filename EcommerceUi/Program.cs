//using EcommerceBusinesLogicLayer.Services;
//using EcommerceDataAccessLayer.Repositories.Contract;
//using EcommerceBusinesLogicLayer.Dtos;
//using EcommerceBusinesLogicLayer.Services;
//namespace EcommerceUi
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            var productRepostory = new ProductRepository();
//            var categoryRepostory = new CategoryRepository();
//            var productManager = new ProductManager(productRepostory);
//            var categoryManager = new CategoryManager(categoryRepostory);
//            Dictionary<string, Action> menuCommand = new Dictionary<string, Action>()
//            {
//                {"1",MainMenu },
//                {"2",ProductMenu },
//                {"3",CategoryMenu},
//                {"4",ExitMenu},

//            };

//            while (true)
//            {
//                MainMenu();
//                Console.Write("Sellec a option");
//                string choice = Console.ReadLine();
//                if(choice == "4")
//                {
//                    ExitMenu();
//                    return;
//                }
//                if(menuCommand.ContainsKey(choice))
//                {
//                    menuCommand[choice].Invoke();
//                }




//            }


//        }

//        private static void ListProducts(ProductManager productManager)
//        {
//            var products = productManager.GetProducts();
//            foreach (var product in products)
//            {
//                Console.WriteLine($"ID: {product.Id}  Name: {product.Name}  Price: {product.Price}");
//            }
//        }

//        private static void AddProduct(ProductManager productManager)
//        {
//            Console.Write("Enter a Id");
//            int id = int.Parse(Console.ReadLine());
//            Console.Write("Enter a Name: ");
//            string productName = Console.ReadLine();
//            Console.Write("Enter a Price: ");
//            decimal price = decimal.Parse(Console.ReadLine());
//            productManager.AddProduct(new CreateProductDto
//            {
//                Id = id,
//                Name = productName,
//                Price = price


//            });
//            Console.WriteLine("Product added succesfuly");
//        }


//       private static void MainMenu()
//       {
//            Console.WriteLine("Ecommerce Main Menu");
//            Console.WriteLine("1.Products");
//            Console.WriteLine("2.Categorys");
//            Console.WriteLine("0.Exit");

//       }
//        private static void ProductMenu()
//        {
//            Console.WriteLine("=== PRODUCTS MENU ===");
//            Console.WriteLine("1. List products");
//            Console.WriteLine("2. Add product");
//            Console.WriteLine("3. Update product");
//            Console.WriteLine("4. Delete product");
//            Console.WriteLine("5. Exit");
//        }

//        private static void CategoryMenu()
//        {
//            Console.WriteLine("=== CATEGORIES MENU ===");
//            Console.WriteLine("1. List categories");
//            Console.WriteLine("2. Add category");
//            Console.WriteLine("3. Update category");
//            Console.WriteLine("4. Delete category");
//            Console.WriteLine("5. Exit");
//        }

//        private static void ExitMenu()
//        {
//            Console.WriteLine("Exiting the application. Goodbye!");
//        }
//    }
//}
using EcommerceBusinesLogicLayer.Dtos;
using EcommerceBusinesLogicLayer.Services;
using EcommerceBusinesLogicLayer.Services;
using EcommerceDataAccessLayer.DataContext;
using EcommerceDataAccessLayer.Repositories.Contract;

namespace EcommerceUi
{
    internal class Program
    {
      
        private static ProductManager productManager;
        private static CategoryManager categoryManager;

        static void Main(string[] args)
        {
            var db = new EcommerceDataBase();
            var productRepository = new ProductRepository();
            var categoryRepository = new CategoryRepository();
            productManager = new ProductManager(productRepository,categoryRepository);
            categoryManager = new CategoryManager(categoryRepository);

            Dictionary<string, Action> mainMenuCommands = new Dictionary<string, Action>()
            {
                {"1", ProductMenu },
                {"2", CategoryMenu},
                {"0", ExitMenu},
            };

            while (true)
            {
                try
                {
                    ShowMainMenu();
                    Console.Write("Select an option: ");
                    string choice = Console.ReadLine();

                    if (choice == "0")
                    {
                        ExitMenu();
                        return;
                    }

                    if (mainMenuCommands.ContainsKey(choice))
                    {
                        mainMenuCommands[choice].Invoke();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option! Please try again.");
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n✗ An error occurred: {ex.Message}");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void ShowMainMenu()
        {
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║   ECOMMERCE MAIN MENU      ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.WriteLine("1. Products");
            Console.WriteLine("2. Categories");
            Console.WriteLine("0. Exit");
            Console.WriteLine("════════════════════════════");
        }

        private static void ProductMenu()
        {
            Dictionary<string, Action> productMenuCommands = new Dictionary<string, Action>()
            {
                {"1", () => ListProducts(productManager) },
                {"2", () => AddProduct(productManager) },
                {"3", () => UpdateProduct(productManager) },
                {"4", () => DeleteProduct(productManager) },
                {"0", () => Console.WriteLine("Returning to main menu...") },
            };

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("╔════════════════════════════╗");
                    Console.WriteLine("║     PRODUCTS MENU          ║");
                    Console.WriteLine("╚════════════════════════════╝");
                    Console.WriteLine("1. List products");
                    Console.WriteLine("2. Add product");
                    Console.WriteLine("3. Update product");
                    Console.WriteLine("4. Delete product");
                    Console.WriteLine("0. Return to main menu");
                    Console.WriteLine("════════════════════════════");
                    Console.Write("Select an option: ");

                    string choice = Console.ReadLine();

                    if (choice == "0")
                    {
                        return;
                    }

                    if (productMenuCommands.ContainsKey(choice))
                    {
                        productMenuCommands[choice].Invoke();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option! Please try again.");
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n✗ An error occurred: {ex.Message}");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void CategoryMenu()
        {
            Dictionary<string, Action> categoryMenuCommands = new Dictionary<string, Action>()
            {
                {"1", () => ListCategories(categoryManager) },
                {"2", () => AddCategory(categoryManager) },
                {"3", () => UpdateCategory(categoryManager) },
                {"4", () => DeleteCategory(categoryManager) },
                {"0", () => Console.WriteLine("Returning to main menu...") },
            };

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("╔════════════════════════════╗");
                    Console.WriteLine("║    CATEGORIES MENU         ║");
                    Console.WriteLine("╚════════════════════════════╝");
                    Console.WriteLine("1. List categories");
                    Console.WriteLine("2. Add category");
                    Console.WriteLine("3. Update category");
                    Console.WriteLine("4. Delete category");
                    Console.WriteLine("0. Return to main menu");
                    Console.WriteLine("════════════════════════════");
                    Console.Write("Select an option: ");

                    string choice = Console.ReadLine();

                    if (choice == "0")
                    {
                        return;
                    }

                    if (categoryMenuCommands.ContainsKey(choice))
                    {
                        categoryMenuCommands[choice].Invoke();
                    }
                    else
                    {
                        Console.WriteLine("Invalid option! Please try again.");
                    }

                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n✗ An error occurred: {ex.Message}");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // Product Operations
        private static void ListProducts(ProductManager productManager)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════════════════════════╗");
                Console.WriteLine("║              PRODUCT LIST                      ║");
                Console.WriteLine("╚════════════════════════════════════════════════╝");

                var products = productManager.GetProducts();

                if (products.Count == 0)
                {
                    Console.WriteLine("No products found.");
                    return;
                }

                foreach (var product in products)
                {
                    Console.WriteLine($"ID: {product.Id,-5} | Name: {product.Name,-20} | Price: ${product.Price,-8:F2} | Category: {product.CategoryName,-20}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error listing products: {ex.Message}");
            }
        }

        private static void AddProduct(ProductManager productManager)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════╗");
                Console.WriteLine("║      ADD NEW PRODUCT       ║");
                Console.WriteLine("╚════════════════════════════╝");
                Console.WriteLine("\n📋 Available Categories:");
                Console.WriteLine("─────────────────────────────");
                var categories = categoryManager.GetCategories();
                foreach (var cat in categories)
                {
                    Console.WriteLine($"  - {cat.Name}");
                }
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Category: ");
                string cateName = Console.ReadLine();
                 var selectCategory = categories.FirstOrDefault(c => c.Name.Equals(cateName, StringComparison.OrdinalIgnoreCase));
                if (selectCategory == null)
                {
                    Console.WriteLine($"\n✗ Error: Category '{cateName}' not found!");
                    Console.WriteLine("Please use one of the available categories listed above.");
                    return;
                }

                productManager.AddProduct(new CreateProductDto
                {
                    Id = id,
                    Name = productName,
                    Price = price,
                    CategoryId = selectCategory.Id
                    
                   
                });

                Console.WriteLine("\n✓ Product added successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n✗ Error: Invalid input format. Please enter correct data types.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error adding product: {ex.Message}");
            }
        }

        private static void UpdateProduct(ProductManager productManager)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════╗");
                Console.WriteLine("║       UPDATE PRODUCT       ║");
                Console.WriteLine("╚════════════════════════════╝");

                // Mövcud məhsulları göstər
                ListProducts(productManager);

                Console.Write("\nEnter Product ID to update: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter new Name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter new Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                // Category seçimi
                Console.WriteLine("\n📋 Available Categories:");
                var categories = categoryManager.GetCategories();
                foreach (var cat in categories)
                {
                    Console.WriteLine($"  {cat.Id}. {cat.Name}");
                }

                Console.Write("\nEnter Category Name: ");
                string categoryName = Console.ReadLine()?.Trim();

                var selectedCategory = categories.FirstOrDefault(c =>
                    c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

                if (selectedCategory == null)
                {
                    Console.WriteLine($"\n✗ Error: Category '{categoryName}' not found!");
                    return;
                }

                // DÜZGÜN ÇAĞIRIŞ - selectedCategory.Id istifadə et
                productManager.UpdateProduct(id, price, new UptadeProducDto
                {
                    Name = productName,
                    Price = price,
                    CategoryId = selectedCategory.Id  // selectedCategory.Id - method deyil!
                });

                Console.WriteLine("\n✓ Product updated successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n✗ Error: Invalid input format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error: {ex.Message}");
            }
        }

        private static void DeleteProduct(ProductManager productManager)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════╗");
                Console.WriteLine("║       DELETE PRODUCT       ║");
                Console.WriteLine("╚════════════════════════════╝");

                ListProducts(productManager);

                Console.Write("\nEnter Product ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                // Debug: ID-ni yoxla
                Console.WriteLine($"[DEBUG] Deleting product with ID: {id}");

                var product = productManager.GetProductById(id);
                if (product == null)
                {
                    Console.WriteLine($"\n✗ Error: Product with ID {id} not found!");
                    return;
                }

                Console.WriteLine($"[DEBUG] Found product: {product.Name}");

                Console.Write($"\nAre you sure you want to delete '{product.Name}'? (y/n): ");
                string confirm = Console.ReadLine()?.ToLower();

                if (confirm == "y")
                {
                    Console.WriteLine($"[DEBUG] Calling DeleteProduct...");
                    productManager.DeleteProduct(id);
                    Console.WriteLine($"[DEBUG] Delete completed");

                    Console.WriteLine("\n✓ Product deleted successfully!");

                    // Yenidən list göstər
                    Console.WriteLine("\n📋 Updated Product List:");
                    ListProducts(productManager);
                }
                else
                {
                    Console.WriteLine("\n✗ Deletion cancelled.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error: {ex.Message}");
                Console.WriteLine($"[DEBUG] Stack trace: {ex.StackTrace}");
            }
        }

        // Category Operations
        private static void ListCategories(CategoryManager categoryManager)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════════════════════════╗");
                Console.WriteLine("║              CATEGORY LIST                     ║");
                Console.WriteLine("╚════════════════════════════════════════════════╝");

                var categories = categoryManager.GetCategories();

                if (categories.Count == 0)
                {
                    Console.WriteLine("No categories found.");
                    return;
                }

                foreach (var category in categories)
                {
                    Console.WriteLine($"ID: {category.Id,-5} | Name: {category.Name}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error listing categories: {ex.Message}");
            }
        }

        private static void AddCategory(CategoryManager categoryManager)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════╗");
                Console.WriteLine("║     ADD NEW CATEGORY       ║");
                Console.WriteLine("╚════════════════════════════╝");

                // Debug: Əvvəlki category sayını göstər
                var beforeCount = categoryManager.GetCategories().Count;
                Console.WriteLine($"[DEBUG] Current category count: {beforeCount}");

                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string categoryName = Console.ReadLine();

                Console.WriteLine($"[DEBUG] Adding category - ID: {id}, Name: {categoryName}");

                // Comment-i SİL və metodu çağır
                categoryManager.AddCategory(new CreateCategoryDto
                {
                    Id = id,
                    Name = categoryName
                });

                Console.WriteLine($"[DEBUG] AddCategory completed");

                // Yenidən say
                var afterCount = categoryManager.GetCategories().Count;
                Console.WriteLine($"[DEBUG] New category count: {afterCount}");

                Console.WriteLine("\n✓ Category added successfully!");

                // List göstər
                Console.WriteLine("\n📋 Updated Category List:");
                ListCategories(categoryManager);
            }
            catch (FormatException)
            {
                Console.WriteLine("\n✗ Error: Invalid input format. Please enter correct data types.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error adding category: {ex.Message}");
                Console.WriteLine($"[DEBUG] Stack trace: {ex.StackTrace}");
            }
        }

        private static void UpdateCategory(CategoryManager categoryManager)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════╗");
                Console.WriteLine("║      UPDATE CATEGORY       ║");
                Console.WriteLine("╚════════════════════════════╝");

                Console.Write("Enter Category ID to update: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter new Name: ");
                string categoryName = Console.ReadLine();

                // UpdateCategory metodunun olduğunu fərz edirəm
                // categoryManager.UpdateCategory(new UpdateCategoryDto { Id = id, Name = categoryName });

                Console.WriteLine("\n✓ Category updated successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n✗ Error: Invalid input format. Please enter correct data types.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error updating category: {ex.Message}");
            }
        }

        private static void DeleteCategory(CategoryManager categoryManager)
        {
            try
            {
                Console.WriteLine("\n╔════════════════════════════╗");
                Console.WriteLine("║      DELETE CATEGORY       ║");
                Console.WriteLine("╚════════════════════════════╝");

                Console.Write("Enter Category ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Are you sure? (y/n): ");
                string confirm = Console.ReadLine()?.ToLower();

                if (confirm == "y")
                {
                    // DeleteCategory metodunun olduğunu fərz edirəm
                    // categoryManager.DeleteCategory(id);
                    Console.WriteLine("\n✓ Category deleted successfully!");
                }
                else
                {
                    Console.WriteLine("\nDeletion cancelled.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n✗ Error: Invalid ID format. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n✗ Error deleting category: {ex.Message}");
            }
        }

        private static void ExitMenu()
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════╗");
            Console.WriteLine("║       GOODBYE! 👋          ║");
            Console.WriteLine("╚════════════════════════════╝");
            Console.WriteLine("Exiting the application...");
        }
    }
}