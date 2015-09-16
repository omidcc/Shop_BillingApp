using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ShopCategoryDalBase : SqlServerConnection
	{
		public DataTable GetAllShopCategory(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ShopCategory", "*", " Where ShopCategory.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetShopCategoryById(Hashtable lstData)
		{
			string whereCondition = " where ShopCategory.Id = @Id And ShopCategory.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ShopCategory", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertShopCategory(Hashtable lstData)
		{
            string sqlQuery = "Insert into ShopCategory (Category, ServiceCharge, Description, IsActive, LastModified, ModifiedBy, MiscBill) values(@Category, @ServiceCharge, @Description, @IsActive, @LastModified, @ModifiedBy, @MiscBill);";
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

		public int UpdateShopCategory(Hashtable lstData)
		{
            string sqlQuery = "Update ShopCategory set Category = @Category, ServiceCharge = @ServiceCharge, Description = @Description, IsActive = @IsActive, LastModified = @LastModified, ModifiedBy = @ModifiedBy, MiscBill = @MiscBill where ShopCategory.Id = @Id;";
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

		public int DeleteShopCategoryById(Hashtable lstData)
		{
			string sqlQuery = "delete from  ShopCategory where Id = @Id;";
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
