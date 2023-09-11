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

        [HttpGet]
        [Route("GetAllCategory")]
        public Task<IEnumerable<Testimonial>> GetAllCategory()
        {
            return _categoryService.GetAllCategory();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public void CreateCategory(Testimonial Testimonial)
        {
            _categoryService.CreateCategory(Testimonial);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
        }

        [HttpGet]
        [Route("GetCategoryId/{id}")]
        public Testimonial GetCategoryId(int id)
        {
            return _categoryService.GetCategoryId(id);
        }

        [HttpPost]
        [Route("UpdateCategory")]
        public void UpdateCategory(Testimonial Testimonial)
        {
            _categoryService.UpdateCategory(Testimonial);
        }

        //Something wrong here
        [HttpGet]
        [Route("GetCategoryCharity")]

        public Task<List<Testimonial>> GetCategoryCharity()
        {
            return _categoryService.GetCategoryCharity() ;
        }

        [HttpPost]
        [Route("UploadImage")]
        public Testimonial UploadIMage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("Images", fileName);



            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Testimonial item = new Testimonial();
            item.ImagePath = fileName;
            return item;
        }
    }
}
