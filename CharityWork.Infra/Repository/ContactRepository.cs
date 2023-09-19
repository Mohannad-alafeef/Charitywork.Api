using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CharityWork.Core.Common;
using System.Data.Common;

namespace CharityWork.Infra.Repository {
	public class ContactRepository : IContactRepository {
		private readonly IDbContext _dbContext;
		private DbConnection _connection;

		public ContactRepository(IDbContext dbContext) {
			_dbContext = dbContext;
			_connection = _dbContext.Connection;
		}

		public async void ChangeStatus(Contact contact) {
			var parm = new DynamicParameters();
			parm.Add("id", contact.ContactId,DbType.Int64,ParameterDirection.Input);
			parm.Add("Status", contact.ContactStatus,DbType.Int64,ParameterDirection.Input);
			await _connection.ExecuteAsync("Contact_package.change_status", parm,commandType: CommandType.StoredProcedure);
		}

		public async void CreateContact(Contact contact) {
			var parm = new DynamicParameters();
			parm.Add("name", contact.SenderName, DbType.String, ParameterDirection.Input);
			parm.Add("email", contact.SenderEmail, DbType.String, ParameterDirection.Input);
			parm.Add("subject", contact.ContactSubject, DbType.String, ParameterDirection.Input);
			parm.Add("content", contact.ContactContent, DbType.String, ParameterDirection.Input);
			parm.Add("Status", Const.Unread, DbType.Int64, ParameterDirection.Input);
			await _connection.ExecuteAsync("Contact_package.create_contact", parm, commandType: CommandType.StoredProcedure);
		}

		public async void  DeleteContact(int id) {
			var parm = new DynamicParameters();
			parm.Add("id", id, DbType.Int64, ParameterDirection.Input);
			
			await _connection.ExecuteAsync("Contact_package.delete_Contact", parm, commandType: CommandType.StoredProcedure);
		}

		public async Task<IEnumerable<Contact>> GetAll() {
			return await _connection.QueryAsync<Contact>("Contact_package.get_all_contact", commandType: CommandType.StoredProcedure);
		}
	}
}
