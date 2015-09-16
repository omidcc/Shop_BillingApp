using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ChairListDalBase : SqlServerConnection
	{
		public DataTable GetAllChairList()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ChairList", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllChairListById(Hashtable lstData)
		{
			string whereCondition = " where ChairList.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ChairList", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertChairList(Hashtable lstData)
		{
			string sqlQuery ="Insert into ChairList (ChairCode, IsReserved) values(@ChairCode, @IsReserved);";
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

		public int UpdateChairList(Hashtable lstData)
		{
			string sqlQuery = "Update ChairList set IsReserved = @IsReserved where ChairList.ChairCode = @ChairCode;";
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

		public int DeleteChairListById(Hashtable lstData)
		{
			string sqlQuery = "delete from  ChairList where Id = @Id;";
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
