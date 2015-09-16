using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class User : Smart.Bll.Base.UserBase
	{
		private static Smart.Dal.UserDal Dal = new Smart.Dal.UserDal();
		public User() : base()
		{
		}
	}
}
