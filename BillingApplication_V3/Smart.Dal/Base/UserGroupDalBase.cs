using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class UserGroupDalBase : SqlServerConnection
	{
		public DataTable GetAllUserGroup()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("UserGroup", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllUserGroupByGroupCode(Hashtable lstData)
		{
			string whereCondition = " where UserGroup.GroupCode = @GroupCode ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("UserGroup", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertUserGroup(Hashtable lstData)
		{
			string sqlQuery ="Insert into UserGroup (GroupCode, GroupName) values(@GroupCode, @GroupName);";
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

		public int UpdateUserGroup(Hashtable lstData)
		{
			string sqlQuery = "Update UserGroup set GroupName = @GroupName where UserGroup.GroupCode = @GroupCode;";
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

		public int DeleteUserGroupByGroupCode(Hashtable lstData)
		{
			string sqlQuery = "delete from  UserGroup where GroupCode = @GroupCode;";
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
