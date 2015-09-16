using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ShopDalBase : SqlServerConnection
	{
		public DataTable GetAllShop(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Shop", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetShopById(Hashtable lstData)
		{
			string whereCondition = " where Shop.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Shop", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertShop(Hashtable lstData)
		{
            string sqlQuery = "Insert into Shop (MarketId, ShopNo, CategoryId, ShopType, SpaceInSqFt, MonthlyRent, AdvanceAmount, ServiceCharge, Description, MiscBill) values(@MarketId, @ShopNo, @CategoryId, @ShopType, @SpaceInSqFt, @MonthlyRent, @AdvanceAmount, @ServiceCharge, @Description, @MiscBill);";
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

		public int UpdateShop(Hashtable lstData)
		{
            string sqlQuery = "Update Shop set MarketId = @MarketId, ShopNo = @ShopNo, CategoryId = @CategoryId, ShopType = @ShopType, SpaceInSqFt = @SpaceInSqFt, MonthlyRent = @MonthlyRent, AdvanceAmount = @AdvanceAmount, ServiceCharge = @ServiceCharge, Description = @Description, MiscBill = @MiscBill where Shop.Id = @Id;";
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

		public int DeleteShopById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Shop where Id = @Id;";
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
