using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class LateChargeDalBase : SqlServerConnection
	{
		public DataTable GetAllLateCharge(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("LateCharge", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetLateChargeById(Hashtable lstData)
		{
			string whereCondition = " where LateCharge.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("LateCharge", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertLateCharge(Hashtable lstData)
		{
			string sqlQuery ="Insert into LateCharge (ShopId, TenantId, Month, Year, AppliedDate, Amount) values(@ShopId, @TenantId, @Month, @Year, @AppliedDate, @Amount);";
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

		public int UpdateLateCharge(Hashtable lstData)
		{
			string sqlQuery = "Update LateCharge set ShopId = @ShopId, TenantId = @TenantId, Month = @Month, Year = @Year, AppliedDate = @AppliedDate, Amount = @Amount where LateCharge.Id = @Id;";
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

		public int DeleteLateChargeById(Hashtable lstData)
		{
			string sqlQuery = "delete from  LateCharge where Id = @Id;";
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
