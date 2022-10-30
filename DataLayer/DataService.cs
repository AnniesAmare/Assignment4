using DataLayer.DataTransferModel;
using Microsoft.EntityFrameworkCore;
using DataLayer.Model;
using AutoMapper;

namespace DataLayer
{
    public partial class DataService : IDataService
    {

        //CATEGORIES
        //Get all categories
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

        //Get category by id
        public Category? GetCategory(int Id)
        {
            using var db = new NorthwindContext();
            var category = db.Categories.Find(Id);
            if (category != null) return category;
            return null;
        }

        //Create a category and return the new category
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

        //Deletes a category and returns true on success, false on failure.
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

        //Updates a category and returns true on success, false on failure
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
        //Get a single product by id
        public ProductElement? GetProduct(int id)
        {
            ProductElement result = null;
            using var db = new NorthwindContext();
            foreach (var product in db
                        .Products
                        .Include(x => x.Category)
                        .Where(x => x.Id == id))
            {
                result = ObjectMapper.Mapper.Map<ProductElement>(product);
            }
            return result;
        }

        //get a list of products by category id
        public IList<ProductByCategoryListElement>? GetProductByCategory(int inputCategoryId)
        {
            using var db = new NorthwindContext();
            var result = new List<ProductByCategoryListElement>();

            foreach (var product in db
                         .Products
                         .Include(x => x.Category)
                         .Where(x => x.CategoryId == inputCategoryId))
            {
                var newProduct = ObjectMapper.Mapper.Map<ProductByCategoryListElement>(product);
                result.Add(newProduct);
            }
            return result;
        }

        //get a list of products that contains a substring
        public IList<ProductByNameListElement>? GetProductByName(string searchString)
        {
            using var db = new NorthwindContext();
            var result = new List<ProductByNameListElement>();

            foreach (var product in db
                         .Products
                         .Include(x => x.Category)
                         .Where(x => x.Name.Contains(searchString)))
            {
                var newProduct = ObjectMapper.Mapper.Map<ProductByNameListElement>(product);
                result.Add(newProduct);
            }
            return result;
        }

        //ORDERS
        //get the complete order by id
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

        //list all orders
        public IList<OrderListElement> GetOrders()
        {
            using var db = new NorthwindContext();
            var result = new List<OrderListElement>();
            foreach (var order in db.Orders)
            {
                var newOrder = ObjectMapper.Mapper.Map<OrderListElement>(order);
                result.Add(newOrder);
            }
            return result;
        }


        //get order by shipName name
        public IList<OrderListElement> GetOrderByShipping(string shipName)
        {
            using var db = new NorthwindContext();
            var result = new List<OrderListElement>();
            foreach (var order in db.Orders
                         .Where(x => x.ShipName.Contains(shipName)))
            {
                var newOrder = ObjectMapper.Mapper.Map<OrderListElement>(order);
                result.Add(newOrder);
            }
            return result;
        }
        

        //ORDERDETAILS
        public IList<OrderDetailsByIdListElement>? GetOrderDetailsByOrderId(int id)
        {
            using var db = new NorthwindContext();
            var result = new List<OrderDetailsByIdListElement>();

            foreach (var orderDetails in db
                         .OrderDetails
                         .Include(x => x.Product)
                         .Where(x => x.OrderId == id))
            {
                var newOrderDetails = ObjectMapper.Mapper.Map<OrderDetailsByIdListElement>(orderDetails);
                result.Add(newOrderDetails);
            }
            return result;
        }

        public IList<OrderDetailsByProductIdListElement>? GetOrderDetailsByProductId(int id)
        {
            using var db = new NorthwindContext();
            var result = new List<OrderDetailsByProductIdListElement>();

            foreach (var orderDetails in db
                         .OrderDetails
                         .Include(x => x.Product)
                         .Include(x => x.Order)
                         .Where(x => x.ProductId == id)
                         .OrderBy(x => x.UnitPrice))
            {
                var newOrderDetails = ObjectMapper.Mapper.Map<OrderDetailsByProductIdListElement>(orderDetails);
                result.Add(newOrderDetails);
            }
            return result;
        }



    }

}
