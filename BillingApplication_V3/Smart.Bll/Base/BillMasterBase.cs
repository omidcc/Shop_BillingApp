using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class BillMasterBase
	{
		protected static Smart.Dal.BillMasterDal dal = new Smart.Dal.BillMasterDal();

		public System.Int64 Id		{ get ; set; }

		public System.String BillNo		{ get ; set; }

		public System.Int64 TenantId		{ get ; set; }

		public System.DateTime BilGeneratelDate		{ get ; set; }

		public System.String BillMonth		{ get ; set; }

		public System.Int32 BillYear		{ get ; set; }

		public System.Int32 GenerateBy		{ get ; set; }

		public System.Int32 ApprovedBy		{ get ; set; }

		public System.Decimal TotalAmount		{ get ; set; }

		public System.Decimal TotalPayment		{ get ; set; }

		public System.Decimal Due		{ get ; set; }

		public System.DateTime LastPaymentDate		{ get ; set; }

        public System.Int32 BillMonthId { get; set; }


		public  Int32 InsertBillMaster()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BillNo", BillNo);
			lstItems.Add("@TenantId", TenantId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BilGeneratelDate", BilGeneratelDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillMonth", BillMonth.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillYear", BillYear.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@GenerateBy", GenerateBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ApprovedBy", ApprovedBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalPayment", TotalPayment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Due", Due.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LastPaymentDate", LastPaymentDate.ToString(CultureInfo.InvariantCulture));
            lstItems.Add("@BillMonthId", BillMonthId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertBillMaster(lstItems);
		}

		public  Int32 UpdateBillMaster()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@BillNo", BillNo);
			lstItems.Add("@TenantId", TenantId.ToString());
			lstItems.Add("@BilGeneratelDate", BilGeneratelDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillMonth", BillMonth.ToString());
			lstItems.Add("@BillYear", BillYear.ToString());
			lstItems.Add("@GenerateBy", GenerateBy.ToString());
			lstItems.Add("@ApprovedBy", ApprovedBy.ToString());
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalPayment", TotalPayment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Due", Due.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LastPaymentDate", LastPaymentDate.ToString(CultureInfo.InvariantCulture));
            lstItems.Add("@BillMonthId", BillMonthId.ToString());
            
			return dal.UpdateBillMaster(lstItems);
		}

		public  Int32 DeleteBillMasterById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteBillMasterById(lstItems);
		}

		public List<BillMaster> GetAllBillMaster()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllBillMaster(lstItems);
			List<BillMaster> BillMasterList = new List<BillMaster>();
			foreach (DataRow dr in dt.Rows)
			{
				BillMasterList.Add(GetObject(dr));
			}
			return BillMasterList;
		}

		public BillMaster  GetBillMasterById(Int64 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetBillMasterById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  BillMaster GetObject(DataRow dr)
		{

			BillMaster objBillMaster = new BillMaster();
			objBillMaster.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int64)dr["Id"];
			objBillMaster.BillNo = (dr["BillNo"] == DBNull.Value) ? "" : (String)dr["BillNo"];
			objBillMaster.TenantId = (dr["TenantId"] == DBNull.Value) ? 0 : (Int64)dr["TenantId"];
			objBillMaster.BilGeneratelDate = (dr["BilGeneratelDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["BilGeneratelDate"];
			objBillMaster.BillMonth = (dr["BillMonth"] == DBNull.Value) ? "" : (String)dr["BillMonth"];
			objBillMaster.BillYear = (dr["BillYear"] == DBNull.Value) ? 0 : (Int32)dr["BillYear"];
			objBillMaster.GenerateBy = (dr["GenerateBy"] == DBNull.Value) ? 0 : (Int32)dr["GenerateBy"];
			objBillMaster.ApprovedBy = (dr["ApprovedBy"] == DBNull.Value) ? 0 : (Int32)dr["ApprovedBy"];
			objBillMaster.TotalAmount = (dr["TotalAmount"] == DBNull.Value) ? 0 : (Decimal)dr["TotalAmount"];
			objBillMaster.TotalPayment = (dr["TotalPayment"] == DBNull.Value) ? 0 : (Decimal)dr["TotalPayment"];
			objBillMaster.Due = (dr["Due"] == DBNull.Value) ? 0 : (Decimal)dr["Due"];
			objBillMaster.LastPaymentDate = (dr["LastPaymentDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["LastPaymentDate"];

			return objBillMaster;
		}
	}
}
