using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class PatientDalBase : SqlServerConnection
	{
		public DataTable GetAllPatient()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Patient", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllPatientById(Hashtable lstData)
		{
			string whereCondition = " where Patient.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Patient", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertPatient(Hashtable lstData)
		{
			string sqlQuery ="Insert into Patient (PatientCode, PatientName, DateOfBirth, ParentsName, Address, PhoneRes, PhoneOff, Mobile, Email, CorpId, LastJobId, OutstandingAmount, IsVIP, NextApointment, AnestheticAllergy, PenicillinAllergy, OtherAllergy, BloodPressure, HeartProblems, BleedingProblems, Diabetic, Remarks) values(@PatientCode, @PatientName, @DateOfBirth, @ParentsName, @Address, @PhoneRes, @PhoneOff, @Mobile, @Email, @CorpId, @LastJobId, @OutstandingAmount, @IsVIP, @NextApointment, @AnestheticAllergy, @PenicillinAllergy, @OtherAllergy, @BloodPressure, @HeartProblems, @BleedingProblems, @Diabetic, @Remarks);";
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

		public int UpdatePatient(Hashtable lstData)
		{
			string sqlQuery = "Update Patient set PatientName = @PatientName, DateOfBirth = @DateOfBirth, ParentsName = @ParentsName, Address = @Address, PhoneRes = @PhoneRes, PhoneOff = @PhoneOff, Mobile = @Mobile, Email = @Email, CorpId = @CorpId, LastJobId = @LastJobId, OutstandingAmount = @OutstandingAmount, IsVIP = @IsVIP, NextApointment = @NextApointment, AnestheticAllergy = @AnestheticAllergy, PenicillinAllergy = @PenicillinAllergy, OtherAllergy = @OtherAllergy, BloodPressure = @BloodPressure, HeartProblems = @HeartProblems, BleedingProblems = @BleedingProblems, Diabetic = @Diabetic, Remarks = @Remarks where Patient.PatientCode = @PatientCode;";
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

		public int DeletePatientById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Patient where Id = @Id;";
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
