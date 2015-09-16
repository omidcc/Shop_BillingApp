using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ReceiptMasterDalBase : SqlServerConnection
	{
		public DataTable GetAllReceiptMaster(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ReceiptMaster", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetReceiptMasterById(Hashtable lstData)
		{
			string whereCondition = " where ReceiptMaster.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ReceiptMaster", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertReceiptMaster(Hashtable lstData)
		{
			string sqlQuery ="Insert into ReceiptMaster (ReceiptNo, ReceiptDate, ReceivedBy, TotalAmount) values(@ReceiptNo, @ReceiptDate, @ReceivedBy, @TotalAmount);";
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

		public int UpdateReceiptMaster(Hashtable lstData)
		{
			string sqlQuery = "Update ReceiptMaster set ReceiptNo = @ReceiptNo, ReceiptDate = @ReceiptDate, ReceivedBy = @ReceivedBy, TotalAmount = @TotalAmount where ReceiptMaster.Id = @Id;";
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

		public int DeleteReceiptMasterById(Hashtable lstData)
		{
			string sqlQuery = "delete from  ReceiptMaster where Id = @Id;";
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
