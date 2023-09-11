using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using CharityWork.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services
{
    public class CategoryService:ICategoryService
    {

        private readonly ICategoryRepository _testimonialRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _testimonialRepository = categoryRepository;
        }
        public Task<IEnumerable<Testimonial>> GetAllCategory() {return _testimonialRepository.GetAllCategory(); }
        public void CreateCategory(Testimonial Testimonial) { _testimonialRepository.CreateCategory(Testimonial); }
        public void DeleteCategory(int id) { _testimonialRepository.DeleteCategory(id); }
        public Testimonial GetCategoryId(int id) { return _testimonialRepository.GetCategoryId(id); }
        public void UpdateCategory(Testimonial Testimonial) { _testimonialRepository.UpdateCategory(Testimonial); }
        public  Task<List<Testimonial>> GetCategoryCharity() { return _testimonialRepository.GetCategoryCharity(); }

    }

}
