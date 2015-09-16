using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class BillMasterDalBase : SqlServerConnection
	{
		public DataTable GetAllBillMaster(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("BillMaster", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetBillMasterById(Hashtable lstData)
		{
			string whereCondition = " where BillMaster.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("BillMaster", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertBillMaster(Hashtable lstData)
		{
            string sqlQuery = "Insert into BillMaster (BillNo, TenantId, BilGeneratelDate, BillMonth, BillYear, GenerateBy, ApprovedBy, TotalAmount, TotalPayment, LastPaymentDate, BillMonthId) values(@BillNo, @TenantId, @BilGeneratelDate, @BillMonth, @BillYear, @GenerateBy, @ApprovedBy, @TotalAmount, @TotalPayment, @LastPaymentDate, @BillMonthId);";
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

		public int UpdateBillMaster(Hashtable lstData)
		{
			string sqlQuery = "Update BillMaster set BillNo = @BillNo, TenantId = @TenantId, BilGeneratelDate = @BilGeneratelDate, BillMonth = @BillMonth, BillYear = @BillYear, GenerateBy = @GenerateBy, ApprovedBy = @ApprovedBy, TotalAmount = @TotalAmount, TotalPayment = @TotalPayment, LastPaymentDate = @LastPaymentDate where BillMaster.Id = @Id;";
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

		public int DeleteBillMasterById(Hashtable lstData)
		{
			string sqlQuery = "delete from  BillMaster where Id = @Id;";
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
