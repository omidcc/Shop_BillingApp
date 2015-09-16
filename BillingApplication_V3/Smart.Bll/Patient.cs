using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Patient : Smart.Bll.Base.PatientBase
	{
		private static Smart.Dal.PatientDal Dal = new Smart.Dal.PatientDal();
		public Patient() : base()
		{
		}
	}
}
