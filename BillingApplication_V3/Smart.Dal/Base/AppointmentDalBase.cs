using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class AppointmentDalBase : SqlServerConnection
	{
		public DataTable GetAllAppointment()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Appointment", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllAppointmentById(Hashtable lstData)
		{
			string whereCondition = " where Appointment.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Appointment", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertAppointment(Hashtable lstData)
		{
			string sqlQuery ="Insert into Appointment (AppointmentCode, AppointmentDate, PatientId, DoctorId, ToothNo, TreatmentRecord, TimeFrom, TimeTo, DurationInMinute, Cost, Advance, Amount, ChairId) values(@AppointmentCode, @AppointmentDate, @PatientId, @DoctorId, @ToothNo, @TreatmentRecord, @TimeFrom, @TimeTo, @DurationInMinute, @Cost, @Advance, @Amount, @ChairId);";
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

		public int UpdateAppointment(Hashtable lstData)
		{
			string sqlQuery = "Update Appointment set AppointmentDate = @AppointmentDate, PatientId = @PatientId, DoctorId = @DoctorId, ToothNo = @ToothNo, TreatmentRecord = @TreatmentRecord, TimeFrom = @TimeFrom, TimeTo = @TimeTo, DurationInMinute = @DurationInMinute, Cost = @Cost, Advance = @Advance, Amount = @Amount, ChairId = @ChairId where Appointment.AppointmentCode = @AppointmentCode;";
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

		public int DeleteAppointmentById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Appointment where Id = @Id;";
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
