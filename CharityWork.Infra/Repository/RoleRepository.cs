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
	public class RoleRepository:IRoleRepository {
		private readonly IDbContext _dbContext;
		private DbConnection _connection;

		public RoleRepository(IDbContext dbContext) {
			_dbContext = dbContext;
			_connection = _dbContext.Connection;
		}

		public async void createRole(Role role) {
			var parm = new DynamicParameters();
			parm.Add("name", role.RoleName, DbType.String, ParameterDirection.Input);
			await _connection.ExecuteAsync("Role_Package.create_role",param: parm,commandType:CommandType.StoredProcedure);

		}
		public async Task<IEnumerable<Role>> getRoles() {

			return await _connection.QueryAsync<Role>("Role_Package.get_all_role", commandType: CommandType.StoredProcedure);
			
		}
		public async Task<Role> getRoleById(int id) {
			var parm = new DynamicParameters();
			parm.Add("id", id, DbType.String, ParameterDirection.Input);
			return await _connection.QuerySingleAsync<Role>("Role_Package.get_by_id", parm, commandType: CommandType.StoredProcedure);
		}
		public async void updateRole(Role role) {
			var parm = new DynamicParameters();
			parm.Add("name", role.RoleName, DbType.String, ParameterDirection.Input);
			parm.Add("id", role.RoleId, DbType.String, ParameterDirection.Input);
			await _connection.ExecuteAsync("Role_Package.update_role", parm, commandType: CommandType.StoredProcedure);
		}
		public async void deleteRole(int id) {
			var parm = new DynamicParameters();
			parm.Add("id", id, DbType.String, ParameterDirection.Input);
			await _connection.ExecuteAsync("Role_Package.delete_role", parm, commandType: CommandType.StoredProcedure);
		}
	}
}
