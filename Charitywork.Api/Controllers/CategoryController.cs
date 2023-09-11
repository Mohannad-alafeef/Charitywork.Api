using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        //test
        [HttpGet]
        [Route("GetAllCategory")]
        public Task<IEnumerable<Category>> GetAllCategory()
        {
            return _categoryService.GetAllCategory();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public void CreateCategory(Category category)
        {
            _categoryService.CreateCategory(category);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }

        [HttpGet]
        [Route("GetCategoryId/{id}")]
        public Task<Category> GetCategoryId(int id)
        {
            return _categoryService.GetCategoryId(id);
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public void UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
        }

        //Something wrong here
        [HttpGet]
        [Route("GetCategoryCharity")]

        public Task<List<Category>> GetCategoryCharity()
        {
            return _categoryService.GetCategoryCharity() ;
        }
    }
}
