namespace WebServer.Controllers
{
    public partial class CategoriesController
    {
        public class CategoryCreateModel
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }
    }
}

