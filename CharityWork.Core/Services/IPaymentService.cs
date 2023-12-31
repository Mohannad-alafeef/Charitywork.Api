﻿using CharityWork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Services
{
    public interface IPaymentService
    {
        void createPayment(Payment payment);

        Payment getPaymentById(int id);
        Task<IEnumerable<Payment>> getPaymentByType(int type);
        List<PaymentOfPeriod> getPaymentByPeriod(DatesType dateSearch);
        Task<IEnumerable<Payment>> getPaymentByCharity(int id);
		Task<IEnumerable<Payment>> GetAll();
	}
}
