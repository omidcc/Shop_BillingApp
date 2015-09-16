using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class PatientBase
	{
		protected static Smart.Dal.PatientDal dal = new Smart.Dal.PatientDal();

		public System.Int64 Id		{ get ; set; }

		public System.String PatientCode		{ get ; set; }

		public System.String PatientName		{ get ; set; }

		public System.String DateOfBirth		{ get ; set; }

		public System.String ParentsName		{ get ; set; }

		public System.String Address		{ get ; set; }

		public System.String PhoneRes		{ get ; set; }

		public System.String PhoneOff		{ get ; set; }

		public System.String Mobile		{ get ; set; }

		public System.String Email		{ get ; set; }

		public System.Int64 CorpId		{ get ; set; }

		public System.Int64 LastJobId		{ get ; set; }

		public System.Decimal OutstandingAmount		{ get ; set; }

		public System.Boolean IsVIP		{ get ; set; }

		public System.DateTime NextApointment		{ get ; set; }

		public System.String AnestheticAllergy		{ get ; set; }

		public System.String PenicillinAllergy		{ get ; set; }

		public System.String OtherAllergy		{ get ; set; }

		public System.String BloodPressure		{ get ; set; }

		public System.String HeartProblems		{ get ; set; }

		public System.String BleedingProblems		{ get ; set; }

		public System.String Diabetic		{ get ; set; }

		public System.String Remarks		{ get ; set; }


		public  Int32 InsertPatient()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@PatientCode", PatientCode);
			lstItems.Add("@PatientName", PatientName);
			lstItems.Add("@DateOfBirth", DateOfBirth);
			lstItems.Add("@ParentsName", ParentsName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@PhoneRes", PhoneRes);
			lstItems.Add("@PhoneOff", PhoneOff);
			lstItems.Add("@Mobile", Mobile);
			lstItems.Add("@Email", Email);
			lstItems.Add("@CorpId", CorpId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LastJobId", LastJobId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@OutstandingAmount", OutstandingAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsVIP", IsVIP);
			lstItems.Add("@NextApointment", NextApointment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@AnestheticAllergy", AnestheticAllergy);
			lstItems.Add("@PenicillinAllergy", PenicillinAllergy);
			lstItems.Add("@OtherAllergy", OtherAllergy);
			lstItems.Add("@BloodPressure", BloodPressure);
			lstItems.Add("@HeartProblems", HeartProblems);
			lstItems.Add("@BleedingProblems", BleedingProblems);
			lstItems.Add("@Diabetic", Diabetic);
			lstItems.Add("@Remarks", Remarks);

			return dal.InsertPatient(lstItems);
		}

		public  Int32 UpdatePatient()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@PatientCode", PatientCode);
			lstItems.Add("@PatientName", PatientName);
			lstItems.Add("@DateOfBirth", DateOfBirth);
			lstItems.Add("@ParentsName", ParentsName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@PhoneRes", PhoneRes);
			lstItems.Add("@PhoneOff", PhoneOff);
			lstItems.Add("@Mobile", Mobile);
			lstItems.Add("@Email", Email);
			lstItems.Add("@CorpId", CorpId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LastJobId", LastJobId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@OutstandingAmount", OutstandingAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsVIP", IsVIP);
			lstItems.Add("@NextApointment", NextApointment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@AnestheticAllergy", AnestheticAllergy);
			lstItems.Add("@PenicillinAllergy", PenicillinAllergy);
			lstItems.Add("@OtherAllergy", OtherAllergy);
			lstItems.Add("@BloodPressure", BloodPressure);
			lstItems.Add("@HeartProblems", HeartProblems);
			lstItems.Add("@BleedingProblems", BleedingProblems);
			lstItems.Add("@Diabetic", Diabetic);
			lstItems.Add("@Remarks", Remarks);

			return dal.UpdatePatient(lstItems);
		}

		public  Int32 DeletePatientById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeletePatientById(lstItems);
		}

		public  DataTable GetAllPatient()
		{
			return dal.GetAllPatient();
		}

		public List<Patient> PatientSelectAll()
		{
			DataTable dt = new DataTable();
			List<Patient> PatientList = new List<Patient>();
			foreach (DataRow dr in dt.Rows)
			{
				PatientList.Add(GetObject(dr));
			}
			return PatientList;
		}

		public  DataTable GetAllPatientById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllPatientById(lstItems);
		}

		public Patient  GetPatientById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllPatientById(lstItems);
			Patient objPatient = new Patient();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static Patient GetObject(DataRow dr)
		{

			Patient objPatient = new Patient
			{
				 Id = (Int64)dr["Id"],
				 PatientCode = (String)dr["PatientCode"],
				 PatientName = (String)dr["PatientName"],
				 DateOfBirth = (String)dr["DateOfBirth"],
				 ParentsName = (String)dr["ParentsName"],
				 Address = (String)dr["Address"],
				 PhoneRes = (String)dr["PhoneRes"],
				 PhoneOff = (String)dr["PhoneOff"],
				 Mobile = (String)dr["Mobile"],
				 Email = (String)dr["Email"],
				 CorpId = (Int64)dr["CorpId"],
				 LastJobId = (Int64)dr["LastJobId"],
				 OutstandingAmount = (Decimal)dr["OutstandingAmount"],
				 IsVIP = (Boolean)dr["IsVIP"],
				 NextApointment = (DateTime)dr["NextApointment"],
				 AnestheticAllergy = (String)dr["AnestheticAllergy"],
				 PenicillinAllergy = (String)dr["PenicillinAllergy"],
				 OtherAllergy = (String)dr["OtherAllergy"],
				 BloodPressure = (String)dr["BloodPressure"],
				 HeartProblems = (String)dr["HeartProblems"],
				 BleedingProblems = (String)dr["BleedingProblems"],
				 Diabetic = (String)dr["Diabetic"],
				 Remarks = (String)dr["Remarks"],
			};

			return objPatient;
		}
	}
}
