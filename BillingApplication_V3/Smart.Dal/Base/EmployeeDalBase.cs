using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class EmployeeDalBase : SqlServerConnection
	{
		public DataTable GetAllEmployee()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Employee", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllEmployeeByEmployeeID(Hashtable lstData)
		{
			string whereCondition = " where Employee.EmployeeID = @EmployeeID ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Employee", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertEmployee(Hashtable lstData)
		{
			string sqlQuery ="Insert into Employee (EmployeeID, EmployeeName, Department, Designation, Address, ContactNo, NationalIDNo) values(@EmployeeID, @EmployeeName, @Department, @Designation, @Address, @ContactNo, @NationalIDNo);";
			try
			{
				int success = ExecuteNonQuery(sqlQuery, lstData);
				return success;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
			}
		}

		public int UpdateEmployee(Hashtable lstData)
		{
			string sqlQuery = "Update Employee set EmployeeName = @EmployeeName, Department = @Department, Designation = @Designation, Address = @Address, ContactNo = @ContactNo, NationalIDNo = @NationalIDNo where Employee.EmployeeID = @EmployeeID;";
			try
			{
				int success = ExecuteNonQuery(sqlQuery, lstData);
				return success;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
			}
		}

		public int DeleteEmployeeByEmployeeID(Hashtable lstData)
		{
			string sqlQuery = "delete from  Employee where EmployeeID = @EmployeeID;";
			try
			{
				int success = ExecuteNonQuery(sqlQuery, lstData);
				return success;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
			}
		}
	}
}
