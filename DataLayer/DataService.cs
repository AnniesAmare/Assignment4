using Microsoft.EntityFrameworkCore;
using DataLayer.Model;

namespace DataLayer
{
    public partial class DataService : IDataService
    {
        //CATEGORIES
        public IList<Category> GetCategories()
        {
            using var db = new NorthwindContext();
            var result = new List<Category>();

            foreach (var category in db
                         .Categories)

            {
                var newCategory = category;
                result.Add(newCategory);
            }
            return result;
        }

        public Category? GetCategory(int Id)
        {
            using var db = new NorthwindContext();
            var category = db.Categories.Find(Id);
            if (category != null) return category;
            return null;
        }

        public Category CreateCategory(string name, string description)
        {
            using var db = new NorthwindContext();
            var newId = db.Categories.Max(category => category.Id) + 1;
            var newCategory = new Category
            {
                Id = newId,
                Name = name,
                Description = description
            };
            db.Categories.Add(newCategory);
            db.SaveChanges();
            return newCategory;
        }

        public bool DeleteCategory(int Id)
        {
            using var db = new NorthwindContext();
            var category = db.Categories.Find(Id);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCategory(int Id, string updatedName, string updatedDescription)
        {
            using var db = new NorthwindContext();
            var category = db.Categories.Find(Id);
            if (category != null)
            {
                category.Name = updatedName;
                category.Description = updatedDescription;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //PRODUCTS
        public Product? GetProduct(int Id)
        {
            Product result = null;
            using var db = new NorthwindContext();
            foreach (var product in db
                        .Products
                        .Include(x => x.Category)
                        .Where(x => x.Id == Id))
            {
                result = product;
            }
            return result;
        }

        public IList<ProductByCategoryListElement>? GetProductByCategory(int inputCategoryId)
        {
            using var db = new NorthwindContext();
            var result = new List<ProductByCategoryListElement>();

            foreach (var product in db
                         .Products
                         .Include(x => x.Category)
                         .Where(x => x.CategoryId == inputCategoryId))
            {
                var newProduct = new ProductByCategoryListElement
                {
                    Name = product.Name,
                    CategoryName = product.Category.Name
                };
                result.Add(newProduct);
            }
            return result;
        }

        public IList<ProductByNameListElement>? GetProductByName(string searchString)
        {
            using var db = new NorthwindContext();
            var result = new List<ProductByNameListElement>();

            foreach (var product in db
                         .Products
                         .Include(x => x.Category)
                         .Where(x => x.Name.Contains(searchString)))
            {
                var newProduct = new ProductByNameListElement
                {
                    ProductName = product.Name,
                    CategoryName = product.Category.Name
                };
                result.Add(newProduct);
            }
            return result;
        }

        //ORDERS
        public IList<Order> GetOrders()
        {
            using var db = new NorthwindContext();
            return db.Orders.ToList();
        }

        public Order? GetOrder(int Id)
        {
            Order result = null;
            using var db = new NorthwindContext();

            foreach (var order in db
                         .Orders
                         .Include(x => x.OrderDetails)
                         .ThenInclude(x => x.Product)
                         .ThenInclude(x => x.Category)
                         .Where(x => x.Id == Id))
            {
                result = order;
            }
            return result;
        }

        //ORDERDETAILS
        public IList<OrderDetails>? GetOrderDetailsByOrderId(int Id)
        {
            using var db = new NorthwindContext();
            var result = new List<OrderDetails>();

            foreach (var orderDetails in db
                         .OrderDetails
                         .Include(x => x.Product)
                         .Where(x => x.OrderId == Id))
            {
                result.Add(orderDetails);
            }
            return result;
        }

        public IList<OrderDetails>? GetOrderDetailsByProductId(int Id)
        {
            using var db = new NorthwindContext();
            var result = new List<OrderDetails>();

            foreach (var orderDetails in db
                         .OrderDetails
                         .Include(x => x.Product)
                         .Include(x => x.Order)
                         .Where(x => x.ProductId == Id)
                         .OrderBy(x => x.UnitPrice))
            {
                result.Add(orderDetails);
            }
            return result;
        }



    }

}
