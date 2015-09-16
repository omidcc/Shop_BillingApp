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
	public class AppointmentBase
	{
		protected static Smart.Dal.AppointmentDal dal = new Smart.Dal.AppointmentDal();

		public System.Int64 Id		{ get ; set; }

		public System.String AppointmentCode		{ get ; set; }

		public System.String AppointmentDate		{ get ; set; }

		public System.Int64 PatientId		{ get ; set; }

		public System.Int64 DoctorId		{ get ; set; }

		public System.String ToothNo		{ get ; set; }

		public System.String TreatmentRecord		{ get ; set; }

		public System.String TimeFrom		{ get ; set; }

		public System.String TimeTo		{ get ; set; }

		public System.Int32 DurationInMinute		{ get ; set; }

		public System.Decimal Cost		{ get ; set; }

		public System.Decimal Advance		{ get ; set; }

		public System.Decimal Amount		{ get ; set; }

		public System.Int64 ChairId		{ get ; set; }


		public  Int32 InsertAppointment()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@AppointmentCode", AppointmentCode);
			lstItems.Add("@AppointmentDate", AppointmentDate);
			lstItems.Add("@PatientId", PatientId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DoctorId", DoctorId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ToothNo", ToothNo);
			lstItems.Add("@TreatmentRecord", TreatmentRecord);
			lstItems.Add("@TimeFrom", TimeFrom);
			lstItems.Add("@TimeTo", TimeTo);
			lstItems.Add("@DurationInMinute", DurationInMinute.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Cost", Cost.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Advance", Advance.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Amount", Amount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ChairId", ChairId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertAppointment(lstItems);
		}

		public  Int32 UpdateAppointment()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@AppointmentCode", AppointmentCode);
			lstItems.Add("@AppointmentDate", AppointmentDate);
			lstItems.Add("@PatientId", PatientId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DoctorId", DoctorId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ToothNo", ToothNo);
			lstItems.Add("@TreatmentRecord", TreatmentRecord);
			lstItems.Add("@TimeFrom", TimeFrom);
			lstItems.Add("@TimeTo", TimeTo);
			lstItems.Add("@DurationInMinute", DurationInMinute.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Cost", Cost.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Advance", Advance.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Amount", Amount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ChairId", ChairId.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateAppointment(lstItems);
		}

		public  Int32 DeleteAppointmentById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteAppointmentById(lstItems);
		}

		public  DataTable GetAllAppointment()
		{
			return dal.GetAllAppointment();
		}

		public List<Appointment> AppointmentSelectAll()
		{
			DataTable dt = new DataTable();
			List<Appointment> AppointmentList = new List<Appointment>();
			foreach (DataRow dr in dt.Rows)
			{
				AppointmentList.Add(GetObject(dr));
			}
			return AppointmentList;
		}

		public  DataTable GetAllAppointmentById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllAppointmentById(lstItems);
		}

		public Appointment  GetAppointmentById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllAppointmentById(lstItems);
			Appointment objAppointment = new Appointment();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static Appointment GetObject(DataRow dr)
		{

			Appointment objAppointment = new Appointment
			{
				 Id = (Int64)dr["Id"],
				 AppointmentCode = (String)dr["AppointmentCode"],
				 AppointmentDate = (String)dr["AppointmentDate"],
				 PatientId = (Int64)dr["PatientId"],
				 DoctorId = (Int64)dr["DoctorId"],
				 ToothNo = (String)dr["ToothNo"],
				 TreatmentRecord = (String)dr["TreatmentRecord"],
				 TimeFrom = (String)dr["TimeFrom"],
				 TimeTo = (String)dr["TimeTo"],
				 DurationInMinute = (Int32)dr["DurationInMinute"],
				 Cost = (Decimal)dr["Cost"],
				 Advance = (Decimal)dr["Advance"],
				 Amount = (Decimal)dr["Amount"],
				 ChairId = (Int64)dr["ChairId"],
			};

			return objAppointment;
		}
	}
}
