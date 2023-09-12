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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CharityWork.Infra.Repository
{
    public class PaymentRepository: IPaymentRepository
    {

        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public PaymentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }
        public void createPayment(Payment payment)
        {
            var parm = new DynamicParameters();
            parm.Add("paymentType", payment.PaymentType, DbType.Int64, ParameterDirection.Input);
            parm.Add("paymentDate", payment.PaymentDate, DbType.Date, ParameterDirection.Input);
            parm.Add("paymentAmount", payment.Amount, DbType.Int64, ParameterDirection.Input);
            parm.Add("userId", payment.UserId, DbType.Int64, ParameterDirection.Input);
            parm.Add("charityId", payment.CharityId, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("payment_package.create_payment", parm, commandType: CommandType.StoredProcedure);
        }
    

        public Payment getPaymentById(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("id", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QueryFirstOrDefault<Payment>("payment_package.get_by_id", parm, commandType: CommandType.StoredProcedure);
        }
        public Task<IEnumerable<Payment>> getPaymentByType(int type)
        {
            var parm = new DynamicParameters();
            parm.Add("paymentType", type, DbType.Int64, ParameterDirection.Input);
            return _connection.QueryAsync<Payment>("payment_package.get_by_type", parm, commandType: CommandType.StoredProcedure);
        }
        public List<PaymentOfPeriod> getPaymentByPeriod(DatesType dateSearch)
        {
            var parm = new DynamicParameters();
            parm.Add("fromDate", dateSearch.fromDate, DbType.Date, ParameterDirection.Input);
            parm.Add("toDate", dateSearch.toDate, DbType.Date, ParameterDirection.Input);
            parm.Add("paymentType", dateSearch.type, DbType.Int64, ParameterDirection.Input);

            var p = _connection.Query<PaymentOfPeriod>("payment_package.get_by_period", parm, commandType: CommandType.StoredProcedure);
            return p.ToList();
        }


        public Task<IEnumerable<Payment>> getPaymentByCharity(int id)
        {

            var parm = new DynamicParameters();
            parm.Add("charityId", id, DbType.Int64, ParameterDirection.Input);

            return _connection.QueryAsync<Payment>("payment_package.get_by_charity", parm, commandType: CommandType.StoredProcedure);
        }
    }
}
