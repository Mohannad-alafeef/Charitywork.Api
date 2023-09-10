using CharityWork.Core.Common;
using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CharityWork.Infra.Repository {
	public class AccountRepository : IAccountRepository {
		private readonly IDbContext _dbContext;
		private DbConnection _connection;

		public AccountRepository(IDbContext dbContext) {
			_dbContext = dbContext;
			_connection = _dbContext.Connection;
		}

		public async void CreateAccount(UserAccount userAccount) {
			var parm = new DynamicParameters();
			parm.Add("firstName", userAccount.FirstName, DbType.String, ParameterDirection.Input);
			parm.Add("lastName", userAccount.LastName, DbType.String, ParameterDirection.Input);
			parm.Add("dob", userAccount.DateOfBirth, DbType.Date, ParameterDirection.Input);
			parm.Add("userAge", userAccount.Age, DbType.Decimal, ParameterDirection.Input);
			parm.Add("phoneNum", userAccount.Phone, DbType.String, ParameterDirection.Input);
			parm.Add("emailAddress", userAccount.Email, DbType.String, ParameterDirection.Input);
			parm.Add("userAddress", userAccount.Address, DbType.String, ParameterDirection.Input);
			parm.Add("userGender", userAccount.Gender, DbType.String, ParameterDirection.Input);
			parm.Add("loginDate", userAccount.LoginDate, DbType.Date, ParameterDirection.Input);
			parm.Add("imagePath", userAccount.ImagePath, DbType.String, ParameterDirection.Input);
			parm.Add("loginId", userAccount.LoginId, DbType.Int64, ParameterDirection.Input);
			await _connection.ExecuteAsync("user_account_package.create_user_account", parm,commandType:CommandType.StoredProcedure);
		}

		public async void DeleteAccount(int id) {
			var parm = new DynamicParameters();
			parm.Add("id", id,DbType.Int64,ParameterDirection.Input);
			await _connection.ExecuteAsync("user_account_package.delete_user_account",parm,commandType:CommandType.StoredProcedure);

		}

		public async Task<IEnumerable<UserAccount>> GetAll() {
			return await _connection.QueryAsync<UserAccount>("user_account_package.get_all_user_account", commandType: CommandType.StoredProcedure);
		}

		public async Task<UserAccount> GetById(int id) {
			var parm = new DynamicParameters();
			parm.Add("id", id, DbType.Int64, ParameterDirection.Input);
			return await _connection.QuerySingleAsync<UserAccount>("user_account_package.get_by_id", parm, commandType: CommandType.StoredProcedure);
		}

		public async void UpdateAccount(UserAccount userAccount) {
			var parm = new DynamicParameters();
			parm.Add("id", userAccount.UserId, DbType.Int64, ParameterDirection.Input);
			parm.Add("firstName", userAccount.FirstName, DbType.String, ParameterDirection.Input);
			parm.Add("lastName", userAccount.LastName, DbType.String, ParameterDirection.Input);
			parm.Add("dob", userAccount.DateOfBirth, DbType.Date, ParameterDirection.Input);
			parm.Add("userAge", userAccount.Age, DbType.Decimal, ParameterDirection.Input);
			parm.Add("phoneNum", userAccount.Phone, DbType.String, ParameterDirection.Input);
			parm.Add("emailAddress", userAccount.Email, DbType.String, ParameterDirection.Input);
			parm.Add("userAddress", userAccount.Address, DbType.String, ParameterDirection.Input);
			parm.Add("userGender", userAccount.Gender, DbType.String, ParameterDirection.Input);
			parm.Add("loginDate", userAccount.LoginDate, DbType.Date, ParameterDirection.Input);
			parm.Add("imagePath", userAccount.ImagePath, DbType.String, ParameterDirection.Input);
			
			await _connection.ExecuteAsync("user_account_package.update_user_account", parm, commandType: CommandType.StoredProcedure);
		}
	}
}
