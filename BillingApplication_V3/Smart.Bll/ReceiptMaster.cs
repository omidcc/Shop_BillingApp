using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class ReceiptMaster : Smart.Bll.Base.ReceiptMasterBase
	{
		private static Smart.Dal.ReceiptMasterDal Dal = new Smart.Dal.ReceiptMasterDal();
		public ReceiptMaster() : base()
		{
		}
	}
}
