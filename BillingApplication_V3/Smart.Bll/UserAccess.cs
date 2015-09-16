using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class UserAccess : Smart.Bll.Base.UserAccessBase
	{
		private static Smart.Dal.UserAccessDal Dal = new Smart.Dal.UserAccessDal();
		public UserAccess() : base()
		{
		}
	}
}
