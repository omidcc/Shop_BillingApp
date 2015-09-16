using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class TreatmentPayment : Smart.Bll.Base.TreatmentPaymentBase
	{
		private static Smart.Dal.TreatmentPaymentDal Dal = new Smart.Dal.TreatmentPaymentDal();
		public TreatmentPayment() : base()
		{
		}
	}
}
