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
	public class DoctorBase
	{
		protected static Smart.Dal.DoctorDal dal = new Smart.Dal.DoctorDal();

		public System.Int64 Id		{ get ; set; }

		public System.String DoctorsCode		{ get ; set; }

		public System.String DoctorName		{ get ; set; }

		public System.String Address		{ get ; set; }

		public System.String ContactNo		{ get ; set; }

		public System.String Email		{ get ; set; }

		public System.String JoinDate		{ get ; set; }

		public System.Decimal TotalEarning		{ get ; set; }

		public System.Decimal CurrentDue		{ get ; set; }

		public System.String LastJobId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }


		public  Int32 InsertDoctor()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DoctorsCode", DoctorsCode);
			lstItems.Add("@DoctorName", DoctorName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@ContactNo", ContactNo);
			lstItems.Add("@Email", Email);
			lstItems.Add("@JoinDate", JoinDate);
			lstItems.Add("@TotalEarning", TotalEarning.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CurrentDue", CurrentDue.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LastJobId", LastJobId);
			lstItems.Add("@IsActive", IsActive);

			return dal.InsertDoctor(lstItems);
		}

		public  Int32 UpdateDoctor()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@DoctorsCode", DoctorsCode);
			lstItems.Add("@DoctorName", DoctorName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@ContactNo", ContactNo);
			lstItems.Add("@Email", Email);
			lstItems.Add("@JoinDate", JoinDate);
			lstItems.Add("@TotalEarning", TotalEarning.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CurrentDue", CurrentDue.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LastJobId", LastJobId);
			lstItems.Add("@IsActive", IsActive);

			return dal.UpdateDoctor(lstItems);
		}

		public  Int32 DeleteDoctorById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteDoctorById(lstItems);
		}

		public  DataTable GetAllDoctor()
		{
			return dal.GetAllDoctor();
		}

		public List<Doctor> DoctorSelectAll()
		{
			DataTable dt = new DataTable();
			List<Doctor> DoctorList = new List<Doctor>();
			foreach (DataRow dr in dt.Rows)
			{
				DoctorList.Add(GetObject(dr));
			}
			return DoctorList;
		}

		public  DataTable GetAllDoctorById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllDoctorById(lstItems);
		}

		public Doctor  GetDoctorById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllDoctorById(lstItems);
			Doctor objDoctor = new Doctor();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static Doctor GetObject(DataRow dr)
		{

			Doctor objDoctor = new Doctor
			{
				 Id = (Int64)dr["Id"],
				 DoctorsCode = (String)dr["DoctorsCode"],
				 DoctorName = (String)dr["DoctorName"],
				 Address = (String)dr["Address"],
				 ContactNo = (String)dr["ContactNo"],
				 Email = (String)dr["Email"],
				 JoinDate = (String)dr["JoinDate"],
				 TotalEarning = (Decimal)dr["TotalEarning"],
				 CurrentDue = (Decimal)dr["CurrentDue"],
				 LastJobId = (String)dr["LastJobId"],
				 IsActive = (Boolean)dr["IsActive"],
			};

			return objDoctor;
		}
	}
}
