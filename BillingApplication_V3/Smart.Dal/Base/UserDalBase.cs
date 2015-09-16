using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class UserDalBase : SqlServerConnection
	{
		public DataTable GetAllUser()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("User", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllUserByUserID(Hashtable lstData)
		{
			string whereCondition = " where User.UserID = @UserID ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("User", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertUser(Hashtable lstData)
		{
			string sqlQuery ="Insert into User (UserID, UserName, Password, GroupCode, IsActive) values(@UserID, @UserName, @Password, @GroupCode, @IsActive);";
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

		public int UpdateUser(Hashtable lstData)
		{
			string sqlQuery = "Update User set UserName = @UserName, Password = @Password, GroupCode = @GroupCode, IsActive = @IsActive where User.UserID = @UserID;";
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

		public int DeleteUserByUserID(Hashtable lstData)
		{
			string sqlQuery = "delete from  User where UserID = @UserID;";
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
