using CharityWork.Core.Models;
using CharityWork.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CharityWork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpPost]
        public void createPayment(Payment payment)
        {
            _paymentService.createPayment(payment);
        }
        [HttpGet("getById/{id}")]
        public Payment getPaymentById(int id)
        {
            return _paymentService.getPaymentById(id);
        }
        [HttpGet("getByType/{type}")]
        public Task<IEnumerable<Payment>> getPaymentByType(int type)
        {
            return _paymentService.getPaymentByType(type);
        }
        [HttpPost("getByDates")]
        public Task<IEnumerable<PaymentOfPeriod>> getPaymentByPeriod(DatesType dateSearch)
        {
            return _paymentService.getPaymentByPeriod(dateSearch);
        }
        [HttpGet("getByCharity/{id}")]
        public Task<IEnumerable<Payment>> getPaymentByCharity(int id)
        {
            return _paymentService.getPaymentByCharity(id);
        }
    }
}
