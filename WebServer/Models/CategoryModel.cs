namespace WebServer.Controllers
{
    public partial class CategoriesController
    {
        public class CategoryModel
        {
            public string? Url { get; set; }
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
        }
    }
}

