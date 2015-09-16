using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class TreatmentPaymentDalBase : SqlServerConnection
	{
		public DataTable GetAllTreatmentPayment()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("TreatmentPayment", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllTreatmentPaymentById(Hashtable lstData)
		{
			string whereCondition = " where TreatmentPayment.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("TreatmentPayment", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertTreatmentPayment(Hashtable lstData)
		{
			string sqlQuery ="Insert into TreatmentPayment (PaymentCode, PayDate, TreatmentId, TotalAmount, Discount, Payable, PaidAmount, DueAmount, ThisAmount, CurrentBalance) values(@PaymentCode, @PayDate, @TreatmentId, @TotalAmount, @Discount, @Payable, @PaidAmount, @DueAmount, @ThisAmount, @CurrentBalance);";
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

		public int UpdateTreatmentPayment(Hashtable lstData)
		{
			string sqlQuery = "Update TreatmentPayment set PayDate = @PayDate, TreatmentId = @TreatmentId, TotalAmount = @TotalAmount, Discount = @Discount, Payable = @Payable, PaidAmount = @PaidAmount, DueAmount = @DueAmount, ThisAmount = @ThisAmount, CurrentBalance = @CurrentBalance where TreatmentPayment.PaymentCode = @PaymentCode;";
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

		public int DeleteTreatmentPaymentById(Hashtable lstData)
		{
			string sqlQuery = "delete from  TreatmentPayment where Id = @Id;";
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
