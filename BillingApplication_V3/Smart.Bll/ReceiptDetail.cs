using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class ReceiptDetail : Smart.Bll.Base.ReceiptDetailBase
	{
		private static Smart.Dal.ReceiptDetailDal Dal = new Smart.Dal.ReceiptDetailDal();
		public ReceiptDetail() : base()
		{
		}
	}
}
