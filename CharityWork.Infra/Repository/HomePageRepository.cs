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
    public class HomePageRepository: IHomePageRepository
    {
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public HomePageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }
        public HomePage getHome(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Home_Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QueryFirstOrDefault<HomePage>("Home_Page_Package.GetHOMEPAGEBYID", parm, commandType: CommandType.StoredProcedure);
        }


        public void createHomePage(HomePage homePage)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Title", homePage.Title, DbType.String, ParameterDirection.Input);
            parm.Add("p_Image_Path", homePage.ImagePath, DbType.String, ParameterDirection.Input);
            parm.Add("p_Text", homePage.Text, DbType.String, ParameterDirection.Input);
            _connection.ExecuteAsync("Home_Page_Package.CREATEHOMEPAGE", parm, commandType: CommandType.StoredProcedure);
        }

        public void deleteHomePage(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Home_Id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Home_Page_Package.DeleteHOMEPAGE", parm, commandType: CommandType.StoredProcedure);
        }


        public void updateHomePage(HomePage homePage)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Home_Id", homePage.HomeId, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_Title", homePage.Title, DbType.String, ParameterDirection.Input);
            parm.Add("p_Image_Path", homePage.ImagePath, DbType.String, ParameterDirection.Input);
            parm.Add("p_Text", homePage.Text, DbType.String, ParameterDirection.Input);

            _connection.ExecuteAsync("Home_Page_Package.UPDATEHOMEPAGE", parm, commandType: CommandType.StoredProcedure);
        }
    }
}
