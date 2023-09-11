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

        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task<IEnumerable<Category>> GetAllCategory() {return _categoryRepository.GetAllCategory(); }
        public void CreateCategory(Category category) { _categoryRepository.CreateCategory(category); }
        public void DeleteCategory(int id) { _categoryRepository.DeleteCategory(id); }
        public Category GetCategoryId(int id) { return _categoryRepository.GetCategoryId(id); }
        public void UpdateCategory(Category category) { _categoryRepository.UpdateCategory(category); }
        public  Task<List<Category>> GetCategoryCharity() { return _categoryRepository.GetCategoryCharity(); }

    }

}
