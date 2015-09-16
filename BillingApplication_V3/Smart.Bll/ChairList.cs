using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class ChairList : Smart.Bll.Base.ChairListBase
	{
		private static Smart.Dal.ChairListDal Dal = new Smart.Dal.ChairListDal();
		public ChairList() : base()
		{
		}
	}
}
