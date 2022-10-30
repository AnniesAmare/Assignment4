using AutoMapper;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public partial class CategoriesController : ControllerBase
    {
        private IDataService _dataService;
        private readonly LinkGenerator _generator;
        private readonly IMapper _mapper;

        public CategoriesController(IDataService dataService, LinkGenerator generator, IMapper mapper)
        {
            _dataService = dataService;
            _generator = generator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories =
                _dataService.GetCategories().Select(x => CreateCategoryModel(x));
            return Ok(categories);
        }

        [HttpGet("{id}", Name = nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            var model = CreateCategoryModel(category);

            return Ok(model);

        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryCreateModel model)
        {
            var category = _dataService.CreateCategory(model.Name, model.Description);
            return CreatedAtRoute(null, CreateCategoryModel(category));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryUpdateModel model)
        {
            if (id == model.Id) //this prevents the user from making changes to the id
            {
                var updated = _dataService.UpdateCategory(id, model.Name, model.Description);
                if (!updated)
                {
                    return NotFound();
                }
                return Ok();
            }
            return BadRequest(); //returns bad request if input id and model.id isn't the same
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var deleted = _dataService.DeleteCategory(id);

            if (!deleted)
            {
                return NotFound();
            }
            return Ok();
        }

        private CategoryModel CreateCategoryModel(Category category)
        {
            //maps a Category-object to a CategoryModel.
            var model = _mapper.Map<CategoryModel>(category);
            model.Url = _generator.GetUriByName(HttpContext, nameof(GetCategory), new { category.Id });
            return model;
        }
        

    }
}
