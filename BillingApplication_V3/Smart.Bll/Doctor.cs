using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Doctor : Smart.Bll.Base.DoctorBase
	{
		private static Smart.Dal.DoctorDal Dal = new Smart.Dal.DoctorDal();
		public Doctor() : base()
		{
		}
	}
}
