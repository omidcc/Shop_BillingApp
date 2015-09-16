using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class DoctorDalBase : SqlServerConnection
	{
		public DataTable GetAllDoctor()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Doctor", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllDoctorById(Hashtable lstData)
		{
			string whereCondition = " where Doctor.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Doctor", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertDoctor(Hashtable lstData)
		{
			string sqlQuery ="Insert into Doctor (DoctorsCode, DoctorName, Address, ContactNo, Email, JoinDate, TotalEarning, CurrentDue, LastJobId, IsActive) values(@DoctorsCode, @DoctorName, @Address, @ContactNo, @Email, @JoinDate, @TotalEarning, @CurrentDue, @LastJobId, @IsActive);";
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

		public int UpdateDoctor(Hashtable lstData)
		{
			string sqlQuery = "Update Doctor set DoctorName = @DoctorName, Address = @Address, ContactNo = @ContactNo, Email = @Email, JoinDate = @JoinDate, TotalEarning = @TotalEarning, CurrentDue = @CurrentDue, LastJobId = @LastJobId, IsActive = @IsActive where Doctor.DoctorsCode = @DoctorsCode;";
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

		public int DeleteDoctorById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Doctor where Id = @Id;";
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
