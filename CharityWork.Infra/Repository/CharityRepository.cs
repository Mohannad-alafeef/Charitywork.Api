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
        public async Task<IEnumerable<Charity>> allstatusCharity()
        {
            // return _connection.QueryAsync<Charity>("Charity_Package.GetAllStatusCharitys", commandType: CommandType.StoredProcedure);
            var result = await _connection.QueryAsync<Charity, Category,UserAccount, Charity>("Charity_Package.GetAllStatusCharitys",
                (charity, cat,user) => {
                    charity.Category=cat;
                    charity.User = user;
                    return charity;
                },
                splitOn: "CategoryId,userId",
                commandType: CommandType.StoredProcedure);
           
            return result;
        }
        public async Task<int> createCharity(Charity charity)
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
            parm.Add("ch_Is_Accepted", Const.NeedReview, DbType.Int64, ParameterDirection.Input);
            parm.Add("donationGoal", charity.DonationGoal, DbType.Int64, ParameterDirection.Input);
            parm.Add("charityId", 0, DbType.Int32, ParameterDirection.Output);

            await _connection.ExecuteAsync("Charity_Package.CreateCharity", parm, commandType: CommandType.StoredProcedure);
            return parm.Get<int>("charityId");
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
        public async Task<IEnumerable<Charity>> allCharity()
        {
            var result = await _connection.QueryAsync<Charity,Payment,Charity>("Charity_Package.GetAllCharitys",
                (charity, payment) => {
                    charity.Payments.Add(payment);
                    return charity;
                },
                splitOn:"paymentId",
                commandType: CommandType.StoredProcedure);
            result = result.GroupBy(x => x.CharityId).Select(g => {
                var gp = g.First();
                gp.Payments = g.Select(p => p.Payments.Single()).ToList();
                return gp;
            });

            return result;

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
