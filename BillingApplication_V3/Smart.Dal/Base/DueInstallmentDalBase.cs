using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class DueInstallmentDalBase : SqlServerConnection
	{
		public DataTable GetAllDueInstallment(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("DueInstallment", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetDueInstallmentById(Hashtable lstData)
		{
			string whereCondition = " where DueInstallment.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("DueInstallment", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertDueInstallment(Hashtable lstData)
		{
			string sqlQuery ="Insert into DueInstallment (TenantId, ShopId, DueDate, PreviousDue, NoOfInstallment, InstallmentAmount, PaidAmount, StartMonth, StartYear, UserId) values(@TenantId, @ShopId, @DueDate, @PreviousDue, @NoOfInstallment, @InstallmentAmount, @PaidAmount, @StartMonth, @StartYear, @UserId);";
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

		public int UpdateDueInstallment(Hashtable lstData)
		{
			string sqlQuery = "Update DueInstallment set TenantId = @TenantId, ShopId = @ShopId, DueDate = @DueDate, PreviousDue = @PreviousDue, NoOfInstallment = @NoOfInstallment, InstallmentAmount = @InstallmentAmount, PaidAmount = @PaidAmount, StartMonth = @StartMonth, StartYear = @StartYear, UserId = @UserId where DueInstallment.Id = @Id;";
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

		public int DeleteDueInstallmentById(Hashtable lstData)
		{
			string sqlQuery = "delete from  DueInstallment where Id = @Id;";
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
