using DataLayer.Model;

namespace DataLayer
{
    public interface IDataService
    {
        IList<Category> GetCategories();
        Category? GetCategory(int id);
        //IList<Product> GetProducts();
        //Product? GetProduct(int id);
        Category CreateCategory(string name, string description);
        //bool UpdateCategory(Category category);
        bool UpdateCategory(int id, string name, string description);
        bool DeleteCategory(int id);
    }
}