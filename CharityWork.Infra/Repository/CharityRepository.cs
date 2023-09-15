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
    public class CharityRepository: ICharityRepository
    {
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public CharityRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }

        public void createCharity(Charity charity)
        {
            var parm = new DynamicParameters();
            parm.Add("ch_Longitude", charity.Longitude, DbType.String, ParameterDirection.Input);
            parm.Add("ch_latitude", charity.Latitude, DbType.String, ParameterDirection.Input);
            parm.Add("ch_mission", charity.Mission, DbType.String, ParameterDirection.Input);
            parm.Add("ch_Create_Date", charity.CreateDate, DbType.Date, ParameterDirection.Input);
            parm.Add("ch_Image_Path", charity.ImagePath, DbType.String, ParameterDirection.Input);
            parm.Add("ch_User_Id", charity.UserId, DbType.Int64, ParameterDirection.Input);
            parm.Add("ch_Category_Id", charity.CategoryId, DbType.Int64, ParameterDirection.Input);
            parm.Add("name", charity.CharityName, DbType.String, ParameterDirection.Input);
            parm.Add("ch_Is_Accepted", charity.IsAccepted, DbType.Int64, ParameterDirection.Input);
            parm.Add("donationGoal", charity.DonationGoal, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("Charity_Package.CreateCharity", parm, commandType: CommandType.StoredProcedure);
        }
        public void updateCharity(Charity charity)
        {
            var parm = new DynamicParameters();
            parm.Add("Id ", charity.CharityId, DbType.Int64, ParameterDirection.Input);
            parm.Add("name", charity.CharityName, DbType.String, ParameterDirection.Input);
            parm.Add("ch_latitude", charity.Latitude, DbType.String, ParameterDirection.Input);

            parm.Add("ch_Longitude", charity.Longitude, DbType.String, ParameterDirection.Input);
            parm.Add("ch_mission", charity.Mission, DbType.String, ParameterDirection.Input);
            parm.Add("ch_Create_Date", charity.CreateDate, DbType.Date, ParameterDirection.Input);
            parm.Add("ch_Image_Path", charity.ImagePath, DbType.String, ParameterDirection.Input);
            parm.Add("ch_User_Id", charity.UserId, DbType.Int64, ParameterDirection.Input);
            parm.Add("ch_Category_Id", charity.CategoryId, DbType.Int64, ParameterDirection.Input);
            parm.Add("ch_Is_Accepted", charity.IsAccepted, DbType.Int64, ParameterDirection.Input);
            parm.Add("donationGoal", charity.DonationGoal, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("Charity_Package.UpateCharity", parm, commandType: CommandType.StoredProcedure);
        }
        public void deleteCharity(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Charity_Package.DeleteCharity", parm, commandType: CommandType.StoredProcedure);

        }
        public Task<IEnumerable<Charity>> allCharity()
        {
            return _connection.QueryAsync<Charity>("Charity_Package.GetAllCharitys", commandType: CommandType.StoredProcedure);

        }
        public Charity getCharity(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QuerySingleOrDefault<Charity>("Charity_Package.GetcharityById", parm, commandType: CommandType.StoredProcedure);

        }
        public Task<IEnumerable<Charity>> SearchByName(string name)
        {
            var parm = new DynamicParameters();
            parm.Add("name", name, DbType.String, ParameterDirection.Input);
            return _connection.QueryAsync<Charity>("Charity_Package.SearchByName", parm, commandType: CommandType.StoredProcedure);

        }
        public Task<IEnumerable<Charity>> SearchByDate(DateSearch dateSearch)
        {
            var parm = new DynamicParameters();
            parm.Add("firstDate", dateSearch.date1, DbType.Date, ParameterDirection.Input);
            parm.Add("secondDate", dateSearch.date2, DbType.Date, ParameterDirection.Input);

            return _connection.QueryAsync<Charity>("Charity_Package.SearchByDates", parm, commandType: CommandType.StoredProcedure);

        }
    }
}
