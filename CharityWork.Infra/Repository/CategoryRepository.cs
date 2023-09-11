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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }

        public Task<IEnumerable<Testimonial>> GetAllCategory()
        {

            return _connection.QueryAsync<Testimonial>("testimonial_package.GetAllCategory", commandType: CommandType.StoredProcedure);
        }

        public void CreateCategory(Testimonial Testimonial)
        {
            var parm = new DynamicParameters();
            parm.Add("catName", Testimonial.CategoryName, DbType.String, ParameterDirection.Input);
            parm.Add("image", Testimonial.ImagePath, DbType.String, ParameterDirection.Input);
            
            _connection.ExecuteAsync("testimonial_package.CreateCategory", parm, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("testimonial_package.DeleteCategory", parm, commandType: CommandType.StoredProcedure);

        }

        public Testimonial GetCategoryId(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QueryFirstOrDefault<Testimonial>("testimonial_package.GetCategoryId", parm, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCategory(Testimonial Testimonial)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", Testimonial.CategoryId, DbType.Int64, ParameterDirection.Input);
            parm.Add("catName", Testimonial.CategoryName, DbType.String, ParameterDirection.Input);
            parm.Add("image", Testimonial.ImagePath, DbType.String, ParameterDirection.Input);

            _connection.ExecuteAsync("testimonial_package.UpdateCategory", parm, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Testimonial>> GetCategoryCharity()
        {
            var result1 = await _dbContext.Connection.QueryAsync<Testimonial, Charity,
            Testimonial>("Charity_Package.GetAllCharitys",
            (Testimonial, charity) =>
            {
                Testimonial.Charities.Add(charity);
                return Testimonial;
            }, splitOn: "CategoryId", param: null, commandType: CommandType.StoredProcedure);
            var result2 = result1.GroupBy(p =>
            p.CategoryId).Select(g =>
            {
                var groupedPost = g.First();
                groupedPost.Charities = g.Select(p =>
                p.Charities.Single()).ToList();
                return groupedPost;
            });
            //return results.ToList();
           return result2.ToList();
        }


    }
}
