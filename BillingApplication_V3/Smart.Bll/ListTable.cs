using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class ListTable : Smart.Bll.Base.ListTableBase
	{
		private static Smart.Dal.ListTableDal Dal = new Smart.Dal.ListTableDal();
		public ListTable() : base()
		{
		}
	}
}
