using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class CompanyDalBase : SqlServerConnection
	{
		public DataTable GetAllCompany()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Company", "*", "");
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetCompanyById(Hashtable lstData)
		{
			string whereCondition = " where Company.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Company", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertCompany(Hashtable lstData)
		{
			string sqlQuery ="Insert into Company (Id, CompanyName, Header1, Address) values(@Id, @CompanyName, @Header1, @Address);";
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

		public int UpdateCompany(Hashtable lstData)
		{
			string sqlQuery = "Update Company set CompanyName = @CompanyName, Header1 = @Header1, Address = @Address where Company.Id = @Id;";
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

		public int DeleteCompanyById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Company where Id = @Id;";
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
