namespace FormsApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();


        static Repository()
        {
            _categories.Add
                (
                    new Category
                    {
                        CategoryId = 1,
                        Name = "Telefon",
                    }
                );

            _categories.Add
                (
                    new Category
                    {
                        CategoryId = 2,
                        Name = "Bilgisayar",
                    }
                );

            _products.Add
                (
                    new Product
                    {
                        ProductId = 1,
                        Name = "IPhone 14",
                        Price = 40000,
                        IsActive = true,
                        Image ="iphone14.jpg",
                        CategoryId = 1,
                    }

                );
            _products.Add
                (
                    new Product
                    {
                        ProductId = 2,
                        Name = "IPhone 15",
                        Price = 55000,
                        IsActive = true,
                        Image = "iphone15.jpg",
                        CategoryId = 1,
                    }

                );
            _products.Add
                (
                    new Product
                    {
                        ProductId = 3,
                        Name = "IPhone 13",
                        Price = 32000,
                        IsActive = true,
                        Image = "iphone13.jpg",
                        CategoryId = 1,
                    }

                );
            _products.Add
                (
                    new Product
                    {
                        ProductId = 4,
                        Name = "MacBook Pro",
                        Price = 75000,
                        IsActive = true,
                        Image = "macbookprom1.jpg",
                        CategoryId = 2,
                    }

                );
            _products.Add
                (
                    new Product
                    {
                        ProductId = 5,
                        Name = "MacBook Air",
                        Price = 60000,
                        IsActive = true,
                        Image = "macbookair13.jpg",
                        CategoryId = 2,
                    }

                );
        }

        public static List<Product> Products
        {
            get
            {
                return _products;
            }
        }

        public static List<Category> Categories
        {
            get
            {
                return _categories;
            }

        }

        public static void EditProduct( Product updatedProduct)
        {
            var entity= _products.FirstOrDefault(p=>p.ProductId==updatedProduct.ProductId); 
            if (entity != null)
            {
                entity.Name = updatedProduct.Name;
                entity.Price = updatedProduct.Price;
                entity.Image = updatedProduct.Image;
                entity.CategoryId = updatedProduct.CategoryId;
                entity.IsActive = updatedProduct.IsActive;
            }
        }

        public static void CreateProduct(Product entity)
        {
            _products.Add( entity );
        }
    }
}
