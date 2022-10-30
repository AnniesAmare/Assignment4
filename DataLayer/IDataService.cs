using DataLayer.DataTransferModel;
using DataLayer.Model;
using static DataLayer.DataService;

namespace DataLayer
{
    public interface IDataService
    {

        //PRODUCTS
        ProductElement? GetProduct(int id);
        IList<ProductByCategoryListElement>? GetProductByCategory(int inputCategoryId);
        IList<ProductByNameListElement>? GetProductByName(string searchString);

        //CATEGORIES
        IList<Category> GetCategories();
        Category? GetCategory(int id);
        Category CreateCategory(string name, string description);
        bool UpdateCategory(int id, string name, string description);
        bool DeleteCategory(int id);

        //ORDERS
        IList<OrderListElement> GetOrders();
        IList<OrderListElement> GetOrderByShipping(string shipName);
        Order? GetOrder(int id);

        //ORDERDETAILS
        IList<OrderDetailsByIdListElement>? GetOrderDetailsByOrderId(int id);
        IList<OrderDetailsByProductIdListElement>? GetOrderDetailsByProductId(int id);

    }
}