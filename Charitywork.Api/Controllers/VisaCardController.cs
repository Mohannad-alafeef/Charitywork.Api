using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisaCardController : ControllerBase
    {
        private readonly IVisaCardService _visaCardService;

        public VisaCardController(IVisaCardService visaCardService)
        {

            _visaCardService = visaCardService;
        }

        [HttpPost]
        public void createVisaCard(VisaCard visaCard)
        {
            _visaCardService.createVisaCard(visaCard);
        }
        [HttpPost("update")]
        public void updateVisaCard(VisaCard visaCard)
        {
            _visaCardService.updateVisaCard(visaCard);
        }
        [HttpDelete("{id}")]
        public void deleteVisaCard(int id)
        {
            _visaCardService.deleteVisaCard(id);
        }
        [HttpGet("GetAll")]
        public Task<IEnumerable<VisaCard>> allVisaCard()
        {
            return _visaCardService.allVisaCard();
        }
        [HttpGet("GetById/{id}")]
        public VisaCard getVisaCard(int id)
        {
            return _visaCardService.getVisaCard(id);
        }
    }
}
