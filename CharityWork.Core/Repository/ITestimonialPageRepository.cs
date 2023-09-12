using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface ITestimonialPageRepository
    {
        void createTestimonialPage(TestimonialPage testimonialPage);
        TestimonialPage getTestimonialpage(int id);
        void updateTestimonialPage(TestimonialPage testimonialPage);
        void deleteTestimonialPage(int id);

    }
}
