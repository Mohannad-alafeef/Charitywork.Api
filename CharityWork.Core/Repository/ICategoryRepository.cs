using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategory();
        public void CreateCategory(Category category);
        public void DeleteCategory(int id);
        public Category GetCategoryId(int id);
       void UpdateCategory(Category category);
        Task<List<Category>> GetCategoryCharity();
    }
}
