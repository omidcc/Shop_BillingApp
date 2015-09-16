using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class ApplicationSetup :  Smart.Bll.Base.ApplicationSetupBase
	{
		private static  Smart.Dal.ApplicationSetupDal Dal = new Smart.Dal.ApplicationSetupDal();
		public ApplicationSetup() : base()
		{
		}
	}
}
