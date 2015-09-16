using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class TreatmentInvoiceDetailDalBase : SqlServerConnection
	{
		public DataTable GetAllTreatmentInvoiceDetail()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("TreatmentInvoiceDetail", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllTreatmentInvoiceDetailById(Hashtable lstData)
		{
			string whereCondition = " where TreatmentInvoiceDetail.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("TreatmentInvoiceDetail", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertTreatmentInvoiceDetail(Hashtable lstData)
		{
			string sqlQuery ="Insert into TreatmentInvoiceDetail (MasterId, TreatmentId, TotalAmount, Payment, DueAmount) values(@MasterId, @TreatmentId, @TotalAmount, @Payment, @DueAmount);";
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

		public int UpdateTreatmentInvoiceDetail(Hashtable lstData)
		{
			string sqlQuery = "Update TreatmentInvoiceDetail set TreatmentId = @TreatmentId, TotalAmount = @TotalAmount, Payment = @Payment, DueAmount = @DueAmount where TreatmentInvoiceDetail.MasterId = @MasterId;";
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

		public int DeleteTreatmentInvoiceDetailById(Hashtable lstData)
		{
			string sqlQuery = "delete from  TreatmentInvoiceDetail where Id = @Id;";
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
