using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ListTableDalBase : SqlServerConnection
	{
		public DataTable GetAllListTable()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ListTable", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllListTableBySlno(Hashtable lstData)
		{
			string whereCondition = " where ListTable.Slno = @Slno ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ListTable", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertListTable(Hashtable lstData)
		{
			string sqlQuery ="Insert into ListTable (ListName, ListItemId, ListItemValue, ListDescription, ShowDesc) values(@ListName, @ListItemId, @ListItemValue, @ListDescription, @ShowDesc);";
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

		public int UpdateListTable(Hashtable lstData)
		{
			string sqlQuery = "Update ListTable set ListItemId = @ListItemId, ListItemValue = @ListItemValue, ListDescription = @ListDescription, ShowDesc = @ShowDesc where ListTable.ListName = @ListName;";
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

		public int DeleteListTableBySlno(Hashtable lstData)
		{
			string sqlQuery = "delete from  ListTable where Slno = @Slno;";
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
