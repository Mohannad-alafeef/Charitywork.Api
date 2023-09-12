using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Repository
{
    public interface IWalletRepository
    {
        public Task<IEnumerable<Wallet>> GetAllWallet();
        public void CreateWallet(Wallet wallet);
        public void DeleteWallet(int id);
        public Wallet GetWalletById(int id);
        public void UpdateWallet(Wallet wallet);
    }
}
