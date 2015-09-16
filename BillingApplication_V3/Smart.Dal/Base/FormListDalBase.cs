using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class FormListDalBase : SqlServerConnection
	{
		public DataTable GetAllFormList()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("FormList", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllFormListBySlno(Hashtable lstData)
		{
			string whereCondition = " where FormList.Slno = @Slno ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("FormList", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertFormList(Hashtable lstData)
		{
			string sqlQuery ="Insert into FormList (Slno, FormName) values(@Slno, @FormName);";
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

		public int UpdateFormList(Hashtable lstData)
		{
			string sqlQuery = "Update FormList set FormName = @FormName where FormList.Slno = @Slno;";
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

		public int DeleteFormListBySlno(Hashtable lstData)
		{
			string sqlQuery = "delete from  FormList where Slno = @Slno;";
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
