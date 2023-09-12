using CharityWork.Core.Common;
using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Repository
{
    public class TestimonialPageRepository:ITestimonialPageRepository
    {

        private readonly IDbContext _dbContext;
        private DbConnection _connection;
        public TestimonialPageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }

        public void createTestimonialPage(TestimonialPage testimonialPage)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Title", testimonialPage.Title, DbType.String, ParameterDirection.Input);
            parm.Add("p_Image_Path", testimonialPage.ImagePath, DbType.String, ParameterDirection.Input);
            parm.Add("p_Text", testimonialPage.Text, DbType.String, ParameterDirection.Input);
            parm.Add("p_Home_Id", testimonialPage.HomeId, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Testimonial_Page_Package.CREATETestimonialPAGE", parm, commandType: CommandType.StoredProcedure);
        }
        public TestimonialPage getTestimonialpage(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Testimonial_Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QueryFirstOrDefault<TestimonialPage>("Testimonial_Page_Package.GetTestimonialPAGEBYID", parm, commandType: CommandType.StoredProcedure);
        }
        public void updateTestimonialPage(TestimonialPage testimonialPage)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Testimonial_Id", testimonialPage.HomeId, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_Title", testimonialPage.Title, DbType.String, ParameterDirection.Input);
            parm.Add("p_Image_Path", testimonialPage.ImagePath, DbType.String, ParameterDirection.Input);
            parm.Add("p_Text", testimonialPage.Text, DbType.String, ParameterDirection.Input);
            parm.Add("p_Home_Id", testimonialPage.HomeId, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Testimonial_Page_Package.UPDATETestimonialPAGE", parm, commandType: CommandType.StoredProcedure);

        }
        public void deleteTestimonialPage(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Testimonial_Id", id, DbType.Int64, ParameterDirection.Input);
           _connection.QueryFirstOrDefault<TestimonialPage>("Testimonial_Page_Package.DeleteTestimonialPAGE", parm, commandType: CommandType.StoredProcedure);
        }
    }
}
