using CharityWork.Core.Models;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Infra.Services
{
    public class WalletService: IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public Task<IEnumerable<Wallet>> GetAllWallet() { return _walletRepository.GetAllWallet(); }
        public void CreateWallet(Wallet wallet) { _walletRepository.CreateWallet(wallet); }
        public void DeleteWallet(int id) { _walletRepository.DeleteWallet(id); }
        public Wallet GetWalletById(int id) { return _walletRepository.GetWalletById(id); }
        public void UpdateWallet(Wallet wallet) { _walletRepository.UpdateWallet(wallet); }



    }
}
