using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Models {
	public enum Const {
		Admin=1,
		User=2,
		donation = 10,
		Payment = 11,
		Accepted = 20,
		NeedPayment = 21,
		Rejected = 22,
		NeedReview = 23,
		Unread = 30,
		Readed = 31,
		Replied = 32
	}
}
