using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {

        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet]
        [Route("GetAllWallet")]
        public Task<IEnumerable<Wallet>> GetAllWallet()
        {
            return _walletService.GetAllWallet();
        }
        [HttpPost]
        [Route("CreateWallet")]
        public void CreateWallet(Wallet wallet)
        {
            _walletService.CreateWallet(wallet);
        }

        [HttpDelete]
        [Route("DeleteWallet/{id}")]
        public void DeleteWallet(int id)
        {
            _walletService.DeleteWallet(id);
        }

        [HttpGet]
        [Route("GetWalletById/{id}")]
        public Wallet GetWalletById(int id)
        {
            return _walletService.GetWalletById(id);
        }

        [HttpPost]
        [Route("UpdateWallet")]
        public void UpdateWallet(Wallet wallet)
        {
            _walletService.UpdateWallet(wallet);
        }

    }
}
