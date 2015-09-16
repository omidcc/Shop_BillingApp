using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ShopeMappingDalBase : SqlServerConnection
	{
		public DataTable GetAllShopeMapping(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ShopeMapping", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetShopeMappingById(Hashtable lstData)
		{
			string whereCondition = " where ShopeMapping.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ShopeMapping", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertShopeMapping(Hashtable lstData)
		{
            string sqlQuery = "Insert into ShopeMapping (MarketId, TenantId, ShopeId, MonthlyRent, ServiceCharge, Advance, PreviousDue, ContractDate, ContractValidYear, MiscBill) values(@MarketId, @TenantId, @ShopeId, @MonthlyRent, @ServiceCharge, @Advance, @PreviousDue, @ContractDate, @ContractValidYear, @MiscBill);";
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

		public int UpdateShopeMapping(Hashtable lstData)
		{
            string sqlQuery = "Update ShopeMapping set MarketId = @MarketId, TenantId = @TenantId, ShopeId = @ShopeId, MonthlyRent = @MonthlyRent, ServiceCharge = @ServiceCharge, Advance = @Advance, PreviousDue = @PreviousDue, ContractDate = @ContractDate, ContractValidYear = @ContractValidYear, MiscBill = @MiscBill where ShopeMapping.Id = @Id;";
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

		public int DeleteShopeMappingById(Hashtable lstData)
		{
			string sqlQuery = "delete from  ShopeMapping where Id = @Id;";
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
