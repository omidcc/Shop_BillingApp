using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class MarketDalBase : SqlServerConnection
	{
		public DataTable GetAllMarket(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Market", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetMarketById(Hashtable lstData)
		{
			string whereCondition = " where Market.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Market", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertMarket(Hashtable lstData)
		{
			string sqlQuery ="Insert into Market (MarketName, Description, EstablishDate, InCharge) values(@MarketName, @Description, @EstablishDate, @InCharge);";
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

		public int UpdateMarket(Hashtable lstData)
		{
			string sqlQuery = "Update Market set MarketName = @MarketName, Description = @Description, EstablishDate = @EstablishDate, InCharge = @InCharge where Market.Id = @Id;";
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

		public int DeleteMarketById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Market where Id = @Id;";
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
