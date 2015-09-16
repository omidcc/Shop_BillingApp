using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ApplicationSetupDalBase : SqlServerConnection
	{
		public DataTable GetAllApplicationSetup(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ApplicationSetup", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetApplicationSetupById(Hashtable lstData)
		{
			string whereCondition = " where ApplicationSetup.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("ApplicationSetup", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertApplicationSetup(Hashtable lstData)
		{
			string sqlQuery ="Insert into ApplicationSetup (IsMultilanguage, UseSingleSerailForEmplyoeeCode) values(@IsMultilanguage, @UseSingleSerailForEmplyoeeCode);";
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

		public int UpdateApplicationSetup(Hashtable lstData)
		{
			string sqlQuery = "Update ApplicationSetup set IsMultilanguage = @IsMultilanguage, UseSingleSerailForEmplyoeeCode = @UseSingleSerailForEmplyoeeCode where ApplicationSetup.Id = @Id;";
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

		public int DeleteApplicationSetupById(Hashtable lstData)
		{
			string sqlQuery = "delete from  ApplicationSetup where Id = @Id;";
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
