using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class EmployeeBase
	{
		protected static Smart.Dal.EmployeeDal dal = new Smart.Dal.EmployeeDal();

		public System.Int64 EmployeeID		{ get ; set; }

		public System.String EmployeeName		{ get ; set; }

		public System.String Department		{ get ; set; }

		public System.String Designation		{ get ; set; }

		public System.String Address		{ get ; set; }

		public System.String ContactNo		{ get ; set; }

		public System.String NationalIDNo		{ get ; set; }


		public  Int32 InsertEmployee()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeID", EmployeeID.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@EmployeeName", EmployeeName);
			lstItems.Add("@Department", Department);
			lstItems.Add("@Designation", Designation);
			lstItems.Add("@Address", Address);
			lstItems.Add("@ContactNo", ContactNo);
			lstItems.Add("@NationalIDNo", NationalIDNo);

			return dal.InsertEmployee(lstItems);
		}

		public  Int32 UpdateEmployee()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeID", EmployeeID.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@EmployeeName", EmployeeName);
			lstItems.Add("@Department", Department);
			lstItems.Add("@Designation", Designation);
			lstItems.Add("@Address", Address);
			lstItems.Add("@ContactNo", ContactNo);
			lstItems.Add("@NationalIDNo", NationalIDNo);

			return dal.UpdateEmployee(lstItems);
		}

		public  Int32 DeleteEmployeeByEmployeeID(Int64 EmployeeID)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeID", EmployeeID);

			return dal.DeleteEmployeeByEmployeeID(lstItems);
		}

		public  DataTable GetAllEmployee()
		{
			return dal.GetAllEmployee();
		}

		public List<Employee> EmployeeSelectAll()
		{
			DataTable dt = new DataTable();
			List<Employee> EmployeeList = new List<Employee>();
			foreach (DataRow dr in dt.Rows)
			{
				EmployeeList.Add(GetObject(dr));
			}
			return EmployeeList;
		}

		public  DataTable GetAllEmployeeByEmployeeID(Int64 EmployeeID)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeID", EmployeeID);

			return dal.GetAllEmployeeByEmployeeID(lstItems);
		}

		public Employee  GetEmployeeByEmployeeID(Int64 EmployeeID)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@EmployeeID", EmployeeID);

			DataTable dt = dal.GetAllEmployeeByEmployeeID(lstItems);
			Employee objEmployee = new Employee();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static Employee GetObject(DataRow dr)
		{

			Employee objEmployee = new Employee
			{
				 EmployeeID = (Int64)dr["EmployeeID"],
				 EmployeeName = (String)dr["EmployeeName"],
				 Department = (String)dr["Department"],
				 Designation = (String)dr["Designation"],
				 Address = (String)dr["Address"],
				 ContactNo = (String)dr["ContactNo"],
				 NationalIDNo = (String)dr["NationalIDNo"],
			};

			return objEmployee;
		}
	}
}
