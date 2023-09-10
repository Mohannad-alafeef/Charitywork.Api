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

        public Task<IEnumerable<Category>> GetAllCategory()
        {

            return _connection.QueryAsync<Category>("Category_Package.GetAllCategory", commandType: CommandType.StoredProcedure);
        }

        public void CreateCategory(Category category)
        {
            var parm = new DynamicParameters();
            parm.Add("catName", category.CategoryName, DbType.String, ParameterDirection.Input);
            parm.Add("image", category.ImagePath, DbType.String, ParameterDirection.Input);
            
            _connection.ExecuteAsync("Category_Package.CreateCategory", parm, commandType: CommandType.StoredProcedure);
        }

        public void DeleteCategory(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Category_Package.DeleteCategory", parm, commandType: CommandType.StoredProcedure);

        }

        public Task<Category> GetCategoryId(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QuerySingleAsync<Category>("Category_Package.GetCategoryId", parm, commandType: CommandType.StoredProcedure);
        }

        public void UpdateCategory(Category category)
        {
            var parm = new DynamicParameters();
            parm.Add("Id", category.CategoryId, DbType.Int64, ParameterDirection.Input);
            parm.Add("catName", category.CategoryName, DbType.String, ParameterDirection.Input);
            parm.Add("image", category.ImagePath, DbType.String, ParameterDirection.Input);

            _connection.ExecuteAsync("Category_Package.UpdateCategory", parm, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Category>> GetCategoryCharity()
        {
            var result1 = await _dbContext.Connection.QueryAsync<Category, Charity,
            Category>("Charity_Package.GetAllCharitys",
            (Category, charity) =>
            {
                Category.Charities.Add(charity);
                return Category;
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
