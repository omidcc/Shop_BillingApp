using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class CommissionSetup : Smart.Bll.Base.CommissionSetupBase
	{
		private static Smart.Dal.CommissionSetupDal Dal = new Smart.Dal.CommissionSetupDal();
		public CommissionSetup() : base()
		{
		}
	}
}
