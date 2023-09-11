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
    public class AboutPageRepository:IAboutPageRepository
    {
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public AboutPageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }
        public void createAboutPage(AboutUsPage aboutUsPage)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Title", aboutUsPage.Title, DbType.String, ParameterDirection.Input);
            parm.Add("p_Image_Path", aboutUsPage.ImagePath, DbType.String, ParameterDirection.Input);
            parm.Add("p_Text", aboutUsPage.Text, DbType.String, ParameterDirection.Input);
            parm.Add("p_Home_Id", aboutUsPage.HomeId, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("About_Us_Page_Package.CREATEAboutPAGE", parm, commandType: CommandType.StoredProcedure);

        }
        public AboutUsPage getAbout(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_About_Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QueryFirstOrDefault<AboutUsPage>("About_Us_Page_Package.GetAboutPAGEBYID", parm, commandType: CommandType.StoredProcedure);

        }
        public void updateAboutPage(AboutUsPage aboutUsPage)
        {
            var parm = new DynamicParameters();
            parm.Add("p_About_Id", aboutUsPage.AboutId, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_Title", aboutUsPage.Title, DbType.String, ParameterDirection.Input);
            parm.Add("p_Image_Path", aboutUsPage.ImagePath, DbType.String, ParameterDirection.Input);
            parm.Add("p_Text", aboutUsPage.Text, DbType.String, ParameterDirection.Input);
            parm.Add("p_Home_Id", aboutUsPage.HomeId, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("About_Us_Page_Package.UPDATEAboutPAGE", parm, commandType: CommandType.StoredProcedure);

        }
        public void deleteAboutPage(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_About_Id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("About_Us_Page_Package.DeleteAboutPAGE", parm, commandType: CommandType.StoredProcedure);

        }
    }
}
