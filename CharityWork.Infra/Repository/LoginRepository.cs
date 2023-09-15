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
	public class LoginRepository : ILoginRepository {
		private readonly IDbContext _dbContext;
		private DbConnection _connection;

		public LoginRepository(IDbContext dbContext) {
			_dbContext = dbContext;
			_connection = dbContext.Connection;
		}

		public Task<IEnumerable<UserLogin>> AllLogin() {

			return _connection.QueryAsync<UserLogin>("user_login_package.get_all_user_login", commandType:CommandType.StoredProcedure);
		}

		public async Task<UserAccount> Auth(UserLogin userLogin) {
			var parm = new DynamicParameters();
			parm.Add("userName", userLogin.UserName, DbType.String, ParameterDirection.Input);
			parm.Add("pass", userLogin.Password, DbType.String, ParameterDirection.Input);
			var result = await _connection.QueryAsync<UserAccount,UserLogin, UserAccount>("user_login_package.auth",
				(account, login) => {
					account.Login = login;
					return account;
				},
				parm,
				splitOn: "loginId",
				commandType: CommandType.StoredProcedure);

			return result.SingleOrDefault();

		}

		public void CreateLogin(UserLogin login) {
			var parm = new DynamicParameters();
			parm.Add("name",login.UserName, DbType.String, ParameterDirection.Input);
			parm.Add("pass", login.Password, DbType.String, ParameterDirection.Input);
			parm.Add("emailAddress", login.Email, DbType.String, ParameterDirection.Input);
			parm.Add("roleId", login.RoleId, DbType.Int64, ParameterDirection.Input);
			_connection.ExecuteAsync("user_login_package.create_user_login", parm,commandType: CommandType.StoredProcedure);
		}

		public void DeleteLogin(int id) {
			var parm = new DynamicParameters();
			parm.Add("id", id, DbType.Int64, ParameterDirection.Input);
			_connection.ExecuteAsync("user_login_package.delete_user_login", parm, commandType: CommandType.StoredProcedure);

		}

		public Task<UserLogin> GetLogin(int id) {
			var parm = new DynamicParameters();
			parm.Add("id", id, DbType.Int64, ParameterDirection.Input);
			return _connection.QuerySingleOrDefaultAsync<UserLogin>("user_login_package.get_by_id",parm, commandType: CommandType.StoredProcedure);
		}

		public void UpdateLogin(UserLogin login) {
			var parm = new DynamicParameters();
			parm.Add("id", login.LoginId, DbType.Int64, ParameterDirection.Input);
			parm.Add("name", login.UserName, DbType.String, ParameterDirection.Input);
			parm.Add("pass", login.Password, DbType.String, ParameterDirection.Input);
			parm.Add("emailAddress", login.Email, DbType.String, ParameterDirection.Input);
			
			_connection.ExecuteAsync("user_login_package.update_user_login", parm, commandType: CommandType.StoredProcedure);
		}
	}
}
