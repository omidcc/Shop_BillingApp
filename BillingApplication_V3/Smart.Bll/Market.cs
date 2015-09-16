using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Market : Smart.Bll.Base.MarketBase
	{
		private static Smart.Dal.MarketDal Dal = new Smart.Dal.MarketDal();
		public Market() : base()
		{
		}
	}
}
