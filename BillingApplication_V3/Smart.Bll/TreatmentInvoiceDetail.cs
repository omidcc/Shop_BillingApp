using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class TreatmentInvoiceDetail : Smart.Bll.Base.TreatmentInvoiceDetailBase
	{
		private static Smart.Dal.TreatmentInvoiceDetailDal Dal = new Smart.Dal.TreatmentInvoiceDetailDal();
		public TreatmentInvoiceDetail() : base()
		{
		}
	}
}
