using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWork.Core.Encoder {
	public class CodePagesEncodingProvider : EncodingProvider {
		public override Encoding? GetEncoding(int codepage) {
			return Encoding.GetEncoding(1252);
		}

		public override Encoding? GetEncoding(string name) {
			return Encoding.GetEncoding(1252);
		}
	}
}
