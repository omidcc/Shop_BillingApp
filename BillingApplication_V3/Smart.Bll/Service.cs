using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Service : Smart.Bll.Base.ServiceBase
	{
		private static Smart.Dal.ServiceDal Dal = new Smart.Dal.ServiceDal();
		public Service() : base()
		{
		}
	}
}
