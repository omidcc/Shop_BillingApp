using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class UserGroup : Smart.Bll.Base.UserGroupBase
	{
		private static Smart.Dal.UserGroupDal Dal = new Smart.Dal.UserGroupDal();
		public UserGroup() : base()
		{
		}
	}
}
