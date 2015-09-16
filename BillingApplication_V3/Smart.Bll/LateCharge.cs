using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class LateCharge : Smart.Bll.Base.LateChargeBase
	{
		private static Smart.Dal.LateChargeDal Dal = new Smart.Dal.LateChargeDal();
		public LateCharge() : base()
		{
		}
	}
}
