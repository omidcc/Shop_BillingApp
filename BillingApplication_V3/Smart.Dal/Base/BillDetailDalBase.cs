using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class BillDetailDalBase : SqlServerConnection
	{
		public DataTable GetAllBillDetail(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("BillDetail", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetBillDetailById(Hashtable lstData)
		{
			string whereCondition = " where BillDetail.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("BillDetail", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertBillDetail(Hashtable lstData)
		{
			string sqlQuery ="Insert into BillDetail (BillMasterId, MarketId, ShopId, MonthlyRent, ServiceCharge, MiscBills, PreviousDue, LateFee, Payment, IsClosed, ClosedBy) values(@BillMasterId, @MarketId, @ShopId, @MonthlyRent, @ServiceCharge, @MiscBills, @PreviousDue, @LateFee, @Payment, @IsClosed, @ClosedBy);";
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

		public int UpdateBillDetail(Hashtable lstData)
		{
			string sqlQuery = "Update BillDetail set BillMasterId = @BillMasterId, MarketId = @MarketId, ShopId = @ShopId, MonthlyRent = @MonthlyRent, ServiceCharge = @ServiceCharge, MiscBills = @MiscBills,  PreviousDue = @PreviousDue,LateFee = @LateFee, Payment = @Payment, IsClosed = @IsClosed, ClosedBy = @ClosedBy where BillDetail.Id = @Id;";
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

		public int DeleteBillDetailById(Hashtable lstData)
		{
			string sqlQuery = "delete from  BillDetail where Id = @Id;";
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
