using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class CommissionSetupDalBase : SqlServerConnection
	{
		public DataTable GetAllCommissionSetup()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("CommissionSetup", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllCommissionSetupById(Hashtable lstData)
		{
			string whereCondition = " where CommissionSetup.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("CommissionSetup", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertCommissionSetup(Hashtable lstData)
		{
			string sqlQuery ="Insert into CommissionSetup (ServicdeId, DoctorsId, CommissionType, CommissionPcnt, CommissionAmount, ActivateDate) values(@ServicdeId, @DoctorsId, @CommissionType, @CommissionPcnt, @CommissionAmount, @ActivateDate);";
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

		public int UpdateCommissionSetup(Hashtable lstData)
		{
			string sqlQuery = "Update CommissionSetup set DoctorsId = @DoctorsId, CommissionType = @CommissionType, CommissionPcnt = @CommissionPcnt, CommissionAmount = @CommissionAmount, ActivateDate = @ActivateDate where CommissionSetup.ServicdeId = @ServicdeId;";
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

		public int DeleteCommissionSetupById(Hashtable lstData)
		{
			string sqlQuery = "delete from  CommissionSetup where Id = @Id;";
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
