using CharityWork.Core.Common;
using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
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
    public class ContactPageRepository: IContactPageRepository
    {
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public ContactPageRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }

        public void createContactPage(ContactUsPage contactUsPage)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Title", contactUsPage.Title, DbType.String, ParameterDirection.Input);
            parm.Add("p_Email_Address", contactUsPage.EmailAddress, DbType.String, ParameterDirection.Input);
            parm.Add("p_Phone", contactUsPage.Phone, DbType.String, ParameterDirection.Input);
            parm.Add("p_Address", contactUsPage.Address, DbType.String, ParameterDirection.Input);
            parm.Add("p_Open_Hours", contactUsPage.OpenHours, DbType.String, ParameterDirection.Input);
            parm.Add("p_Home_Id", contactUsPage.HomeId, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Contact_Us_Page_Package.CREATEContactPAGE", parm, commandType: CommandType.StoredProcedure);
        }

        public ContactUsPage getContact(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Contact_Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QuerySingleOrDefault<ContactUsPage>("Contact_Us_Page_Package.GetContactPAGEBYID", parm, commandType: CommandType.StoredProcedure);

        }
        public void updateContactPage(ContactUsPage contactUsPage)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Contact_Id", contactUsPage.ContactId, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_Title", contactUsPage.Title, DbType.String, ParameterDirection.Input);
            parm.Add("p_Email_Address", contactUsPage.EmailAddress, DbType.String, ParameterDirection.Input);
            parm.Add("p_Phone", contactUsPage.Phone, DbType.String, ParameterDirection.Input);
            parm.Add("p_Address", contactUsPage.Address, DbType.String, ParameterDirection.Input);
            parm.Add("p_Open_Hours", contactUsPage.OpenHours, DbType.String, ParameterDirection.Input);
            parm.Add("p_Home_Id", contactUsPage.HomeId, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Contact_Us_Page_Package.UPDATEContactPAGE", parm, commandType: CommandType.StoredProcedure);
        }
      public  void deleteContactPage(int id)
      {
            var parm = new DynamicParameters();
            parm.Add("p_Contact_Id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Contact_Us_Page_Package.DeleteContactPAGE", parm, commandType: CommandType.StoredProcedure);
      }


    }
}
