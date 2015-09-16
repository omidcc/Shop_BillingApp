using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class FormList : Smart.Bll.Base.FormListBase
	{
		private static Smart.Dal.FormListDal Dal = new Smart.Dal.FormListDal();
		public FormList() : base()
		{
		}
	}
}
