using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class ServiceDalBase : SqlServerConnection
	{
		public DataTable GetAllService()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Service", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllServiceById(Hashtable lstData)
		{
			string whereCondition = " where Service.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Service", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertService(Hashtable lstData)
		{
			string sqlQuery ="Insert into Service (ServiceCode, ServiceName, Price, Cost, MinAdvance) values(@ServiceCode, @ServiceName, @Price, @Cost, @MinAdvance);";
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

		public int UpdateService(Hashtable lstData)
		{
			string sqlQuery = "Update Service set ServiceName = @ServiceName, Price = @Price, Cost = @Cost, MinAdvance = @MinAdvance where Service.ServiceCode = @ServiceCode;";
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

		public int DeleteServiceById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Service where Id = @Id;";
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
