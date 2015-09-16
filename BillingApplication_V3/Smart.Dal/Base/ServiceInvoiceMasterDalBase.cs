using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ServiceInvoiceMasterDalBase : SqlServerConnection
	{
		public DataTable GetAllServiceInvoiceMaster()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ServiceInvoiceMaster", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllServiceInvoiceMasterById(Hashtable lstData)
		{
			string whereCondition = " where ServiceInvoiceMaster.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ServiceInvoiceMaster", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertServiceInvoiceMaster(Hashtable lstData)
		{
			string sqlQuery ="Insert into ServiceInvoiceMaster (InvoiceNo, PatienId, NoOfTreatment, Totalcharges, TotalPayment, DueAmount, InvoiceAmount, InvoiceDate) values(@InvoiceNo, @PatienId, @NoOfTreatment, @Totalcharges, @TotalPayment, @DueAmount, @InvoiceAmount, @InvoiceDate);";
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

		public int UpdateServiceInvoiceMaster(Hashtable lstData)
		{
			string sqlQuery = "Update ServiceInvoiceMaster set PatienId = @PatienId, NoOfTreatment = @NoOfTreatment, Totalcharges = @Totalcharges, TotalPayment = @TotalPayment, DueAmount = @DueAmount, InvoiceAmount = @InvoiceAmount, InvoiceDate = @InvoiceDate where ServiceInvoiceMaster.InvoiceNo = @InvoiceNo;";
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

		public int DeleteServiceInvoiceMasterById(Hashtable lstData)
		{
			string sqlQuery = "delete from  ServiceInvoiceMaster where Id = @Id;";
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
