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
	public class CommissionSetupBase
	{
		protected static Smart.Dal.CommissionSetupDal dal = new Smart.Dal.CommissionSetupDal();

		public System.Int64 Id		{ get ; set; }

		public System.Int64 ServicdeId		{ get ; set; }

		public System.Int64 DoctorsId		{ get ; set; }

		public System.String CommissionType		{ get ; set; }

		public System.Decimal CommissionPcnt		{ get ; set; }

		public System.Decimal CommissionAmount		{ get ; set; }

		public System.String ActivateDate		{ get ; set; }


		public  Int32 InsertCommissionSetup()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ServicdeId", ServicdeId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DoctorsId", DoctorsId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CommissionType", CommissionType);
			lstItems.Add("@CommissionPcnt", CommissionPcnt.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CommissionAmount", CommissionAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ActivateDate", ActivateDate);

			return dal.InsertCommissionSetup(lstItems);
		}

		public  Int32 UpdateCommissionSetup()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ServicdeId", ServicdeId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DoctorsId", DoctorsId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CommissionType", CommissionType);
			lstItems.Add("@CommissionPcnt", CommissionPcnt.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CommissionAmount", CommissionAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ActivateDate", ActivateDate);

			return dal.UpdateCommissionSetup(lstItems);
		}

		public  Int32 DeleteCommissionSetupById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteCommissionSetupById(lstItems);
		}

		public  DataTable GetAllCommissionSetup()
		{
			return dal.GetAllCommissionSetup();
		}

		public List<CommissionSetup> CommissionSetupSelectAll()
		{
			DataTable dt = new DataTable();
			List<CommissionSetup> CommissionSetupList = new List<CommissionSetup>();
			foreach (DataRow dr in dt.Rows)
			{
				CommissionSetupList.Add(GetObject(dr));
			}
			return CommissionSetupList;
		}

		public  DataTable GetAllCommissionSetupById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllCommissionSetupById(lstItems);
		}

		public CommissionSetup  GetCommissionSetupById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllCommissionSetupById(lstItems);
			CommissionSetup objCommissionSetup = new CommissionSetup();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static CommissionSetup GetObject(DataRow dr)
		{

			CommissionSetup objCommissionSetup = new CommissionSetup
			{
				 Id = (Int64)dr["Id"],
				 ServicdeId = (Int64)dr["ServicdeId"],
				 DoctorsId = (Int64)dr["DoctorsId"],
				 CommissionType = (String)dr["CommissionType"],
				 CommissionPcnt = (Decimal)dr["CommissionPcnt"],
				 CommissionAmount = (Decimal)dr["CommissionAmount"],
				 ActivateDate = (String)dr["ActivateDate"],
			};

			return objCommissionSetup;
		}
	}
}
