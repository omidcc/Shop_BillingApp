using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class UserAccessDalBase : SqlServerConnection
	{
		public DataTable GetAllUserAccess()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("UserAccess", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllUserAccessBySlno(Hashtable lstData)
		{
			string whereCondition = " where UserAccess.Slno = @Slno ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("UserAccess", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertUserAccess(Hashtable lstData)
		{
			string sqlQuery ="Insert into UserAccess (Slno, UserID, GroupCode, FormID, canOpen, canSave, canUpdate, canDelete, canPrint) values(@Slno, @UserID, @GroupCode, @FormID, @canOpen, @canSave, @canUpdate, @canDelete, @canPrint);";
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

		public int UpdateUserAccess(Hashtable lstData)
		{
			string sqlQuery = "Update UserAccess set UserID = @UserID, GroupCode = @GroupCode, FormID = @FormID, canOpen = @canOpen, canSave = @canSave, canUpdate = @canUpdate, canDelete = @canDelete, canPrint = @canPrint where UserAccess.Slno = @Slno;";
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

		public int DeleteUserAccessBySlno(Hashtable lstData)
		{
			string sqlQuery = "delete from  UserAccess where Slno = @Slno;";
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
