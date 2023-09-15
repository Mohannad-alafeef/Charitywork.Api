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
    public class VisaCardRepository: IVisaCardRepository
    {

        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public VisaCardRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }


        public async void createVisaCard(VisaCard visaCard)
        {
            var parm = new DynamicParameters();
            parm.Add("p_balance", visaCard.Balance, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_card_number", visaCard.CardNumber, DbType.String, ParameterDirection.Input);
            parm.Add("p_cvv", visaCard.Cvv, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_exp_date", visaCard.ExpDate, DbType.Date, ParameterDirection.Input);
            parm.Add("p_user_id", visaCard.UserId, DbType.Int64, ParameterDirection.Input);


            await _connection.ExecuteAsync("visa_card_package.create_visa_card", param: parm, commandType: CommandType.StoredProcedure);


        }
        public void updateVisaCard(VisaCard visaCard)
        {
            var parm = new DynamicParameters();
            parm.Add("p_visa_id", visaCard.VisaId, DbType.Int64, ParameterDirection.Input);

            parm.Add("p_balance", visaCard.Balance, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_card_number", visaCard.CardNumber, DbType.String, ParameterDirection.Input);
            parm.Add("p_cvv", visaCard.Cvv, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_exp_date", visaCard.ExpDate, DbType.Date, ParameterDirection.Input);
            parm.Add("p_user_id", visaCard.UserId, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("visa_card_package.update_visa_card", parm, commandType: CommandType.StoredProcedure);


        }
        public void deleteVisaCard(int id)
        {

            var parm = new DynamicParameters();
            parm.Add("p_visa_id", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("visa_card_package.delete_visa_card", parm, commandType: CommandType.StoredProcedure);

        }
        public Task<IEnumerable<VisaCard>> allVisaCard()
        {
            return _connection.QueryAsync<VisaCard>("visa_card_package.GetAllVisa", commandType: CommandType.StoredProcedure);

        }
        public VisaCard getVisaCard(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Visa_Id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QuerySingleOrDefault<VisaCard>("visa_card_package.GetVisaById", parm, commandType: CommandType.StoredProcedure);

        }
    }
}
