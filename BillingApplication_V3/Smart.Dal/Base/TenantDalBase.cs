using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class TenantDalBase : SqlServerConnection
	{
		public DataTable GetAllTenant(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Tenant", "*", " Where Tenant.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetTenantById(Hashtable lstData)
		{
			string whereCondition = " where Tenant.Id = @Id And Tenant.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Tenant", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertTenant(Hashtable lstData)
		{
			string sqlQuery ="Insert into Tenant (Id, TenantName, FathersNames, Address, IsActive, OutstandingAmount, NoOfShops, ContactNo) values(@Id, @TenantName, @FathersNames, @Address, @IsActive, @OutstandingAmount, @NoOfShops, @ContactNo);";
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

		public int UpdateTenant(Hashtable lstData)
		{
			string sqlQuery = "Update Tenant set TenantName = @TenantName, FathersNames = @FathersNames, Address = @Address, IsActive = @IsActive, OutstandingAmount = @OutstandingAmount, NoOfShops = @NoOfShops, ContactNo = @ContactNo where Tenant.Id = @Id;";
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

		public int DeleteTenantById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Tenant where Id = @Id;";
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
