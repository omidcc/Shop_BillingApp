using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Employee : Smart.Bll.Base.EmployeeBase
	{
		private static Smart.Dal.EmployeeDal Dal = new Smart.Dal.EmployeeDal();
		public Employee() : base()
		{
		}
	}
}
