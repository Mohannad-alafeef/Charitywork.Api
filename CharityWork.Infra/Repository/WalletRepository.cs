using CharityWork.Core.Common;
using CharityWork.Core.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharityWork.Core.Repository;

namespace CharityWork.Infra.Repository
{
    public class WalletRepository :IWalletRepository
    {
        
        private readonly IDbContext _dbContext;
        private DbConnection _connection;

        public WalletRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _connection = dbContext.Connection;
        }

        public Task<IEnumerable<Wallet>> GetAllWallet()
        {

            return _connection.QueryAsync<Wallet>("Wallet_Package.GetAllWallet", commandType: CommandType.StoredProcedure);
        }

        public void CreateWallet(Wallet wallet)
        {
            var parm = new DynamicParameters();
           
            parm.Add("p_Balance", wallet.Balance, DbType.Int64, ParameterDirection.Input); 
            parm.Add("p_IBAN", wallet.Iban, DbType.String, ParameterDirection.Input);
            parm.Add("p_User_Id", wallet.UserId, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("Wallet_Package.CREATEWallet", parm, commandType: CommandType.StoredProcedure);
        }

        public void DeleteWallet(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Wallet_ID", id, DbType.Int64, ParameterDirection.Input);
            _connection.ExecuteAsync("Wallet_Package.DeleteWallet", parm, commandType: CommandType.StoredProcedure);

        }

        public Wallet GetWalletById(int id)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Wallet_ID", id, DbType.Int64, ParameterDirection.Input);
            return _connection.QueryFirstOrDefault<Wallet>("Wallet_Package.GetWalletBYID", parm, commandType: CommandType.StoredProcedure);
        }

        public void UpdateWallet(Wallet wallet)
        {
            var parm = new DynamicParameters();
            parm.Add("p_Wallet_ID", wallet.WalletId, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_Balance", wallet.Balance, DbType.Int64, ParameterDirection.Input);
            parm.Add("p_IBAN", wallet.Iban, DbType.String, ParameterDirection.Input);
            parm.Add("p_User_Id", wallet.UserId, DbType.Int64, ParameterDirection.Input);

            _connection.ExecuteAsync("Wallet_Package.UPDATEWallet", parm, commandType: CommandType.StoredProcedure);
        }


    }
}
