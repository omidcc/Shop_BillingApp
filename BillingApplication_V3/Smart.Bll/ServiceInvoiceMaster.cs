using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class ServiceInvoiceMaster : Smart.Bll.Base.ServiceInvoiceMasterBase
	{
		private static Smart.Dal.ServiceInvoiceMasterDal Dal = new Smart.Dal.ServiceInvoiceMasterDal();
		public ServiceInvoiceMaster() : base()
		{
		}
	}
}
