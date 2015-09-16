using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Appointment : Smart.Bll.Base.AppointmentBase
	{
		private static Smart.Dal.AppointmentDal Dal = new Smart.Dal.AppointmentDal();
		public Appointment() : base()
		{
		}
	}
}
