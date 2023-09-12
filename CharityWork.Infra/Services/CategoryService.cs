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

        private readonly ICategoryRepository Category_Package;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            Category_Package = categoryRepository;
        }
        public Task<IEnumerable<Category>> GetAllCategory() {return Category_Package.GetAllCategory(); }
        public void CreateCategory(Category category) { Category_Package.CreateCategory(category); }
        public void DeleteCategory(int id) { Category_Package.DeleteCategory(id); }
        public Category GetCategoryId(int id) { return Category_Package.GetCategoryId(id); }
        public void UpdateCategory(Category category) { Category_Package.UpdateCategory(category); }
        public  Task<List<Category>> GetCategoryCharity() { return Category_Package.GetCategoryCharity(); }

    }

}
