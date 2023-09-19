using CharityWork.Core.Common;
using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Repository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public TestimonialRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }

        public Task<IEnumerable<Testimonial>> GetAllTestimonial()
        {

            return _connection.QueryAsync<Testimonial,UserAccount,Testimonial>("testimonial_package.get_all_testimonial"
                , (testimonial, account) => {
                    testimonial.User = account;
                    return testimonial;
                },
                splitOn:"userId"
                , commandType: CommandType.StoredProcedure);
        }

        public void CreateTestimonial(Testimonial testimonial)
        {
            var parm = new DynamicParameters();
            parm.Add("testContent", testimonial.Content, DbType.String, ParameterDirection.Input);
            parm.Add("testRate", testimonial.Rate, DbType.Int64, ParameterDirection.Input);
            parm.Add("testDate", testimonial.TestimonialDate, DbType.Date, ParameterDirection.Input);
            parm.Add("isAccepted", Const.NeedReview, DbType.Int64, ParameterDirection.Input);
            parm.Add("userId", testimonial.UserId, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("testimonial_package.create_testimonial", parm, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTestimonial(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("testimonial_package.delete_testimonial", parm, commandType: CommandType.StoredProcedure);

        }

        public Testimonial GetTestimonialById(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QuerySingleOrDefault<Testimonial>("testimonial_package.get_by_id", parm, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", testimonial.TestimonialId, DbType.Int64, ParameterDirection.Input);
            parm.Add("isAccepted", testimonial.IsAccepted, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("testimonial_package.change_status", parm, commandType: CommandType.StoredProcedure);
        }


    }
}
