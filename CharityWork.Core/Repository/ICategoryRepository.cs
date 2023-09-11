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
        Task<IEnumerable<Testimonial>> GetAllCategory();
        public void CreateCategory(Testimonial Testimonial);
        public void DeleteCategory(int id);
        public Testimonial GetCategoryId(int id);
       void UpdateCategory(Testimonial Testimonial);
        Task<List<Testimonial>> GetCategoryCharity();
    }
}
