using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class AppFunctionalityDalBase : SqlServerConnection
	{
		public DataTable GetAllAppFunctionality(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("AppFunctionality", "*", " Where AppFunctionality.IsActive = 1;", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAppFunctionalityById(Hashtable lstData)
		{
			string whereCondition = " where AppFunctionality.Id = @Id And AppFunctionality.IsActive = 1";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("AppFunctionality", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertAppFunctionality(Hashtable lstData)
		{
			string sqlQuery ="Insert into AppFunctionality (Id, CompanyId, Module, Functionality, Url, ParentId, IsCompanySpecific, IsActive, Sequence) values(@Id, @CompanyId, @Module, @Functionality, @Url, @ParentId, @IsCompanySpecific, @IsActive, @Sequence);";
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

		public int UpdateAppFunctionality(Hashtable lstData)
		{
			string sqlQuery = "Update AppFunctionality set CompanyId = @CompanyId, Module = @Module, Functionality = @Functionality, Url = @Url, ParentId = @ParentId, IsCompanySpecific = @IsCompanySpecific, IsActive = @IsActive, Sequence = @Sequence where AppFunctionality.Id = @Id;";
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

		public int DeleteAppFunctionalityById(Hashtable lstData)
		{
			string sqlQuery = "delete from  AppFunctionality where Id = @Id;";
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
