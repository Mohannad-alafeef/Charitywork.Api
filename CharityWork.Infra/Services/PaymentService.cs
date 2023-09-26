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
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public void createPayment(Payment payment)
        {
            _paymentRepository.createPayment(payment);
        }

        public Payment getPaymentById(int id)
        {
            return _paymentRepository.getPaymentById(id);
        }
        public Task<IEnumerable<Payment>> getPaymentByType(int type)
        {
            return _paymentRepository.getPaymentByType(type);
        }
        public List<PaymentOfPeriod> getPaymentByPeriod(DatesType dateSearch)
        {
            return _paymentRepository.getPaymentByPeriod(dateSearch);
        }
        public Task<IEnumerable<Payment>> getPaymentByCharity(int id)
        {
            return _paymentRepository.getPaymentByCharity(id);
        }

		public Task<IEnumerable<Payment>> GetAll() {
			return _paymentRepository.GetAll();
		}
	}
}
