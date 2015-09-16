using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ReceiptDetailDalBase : SqlServerConnection
	{
		public DataTable GetAllReceiptDetail(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ReceiptDetail", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetReceiptDetailById(Hashtable lstData)
		{
			string whereCondition = " where ReceiptDetail.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ReceiptDetail", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertReceiptDetail(Hashtable lstData)
		{
			string sqlQuery ="Insert into ReceiptDetail (Id, ReceiptMasterId, BillMasterId, BillDetailId, BillAmount, PaymentAmount, Due) values(@Id, @ReceiptMasterId, @BillMasterId, @BillDetailId, @BillAmount, @PaymentAmount, @Due);";
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

		public int UpdateReceiptDetail(Hashtable lstData)
		{
			string sqlQuery = "Update ReceiptDetail set ReceiptMasterId = @ReceiptMasterId, BillMasterId = @BillMasterId, BillDetailId = @BillDetailId, BillAmount = @BillAmount, PaymentAmount = @PaymentAmount, Due = @Due where ReceiptDetail.Id = @Id;";
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

		public int DeleteReceiptDetailById(Hashtable lstData)
		{
			string sqlQuery = "delete from  ReceiptDetail where Id = @Id;";
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
