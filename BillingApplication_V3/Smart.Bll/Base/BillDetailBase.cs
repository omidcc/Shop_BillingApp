using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class BillDetailBase
	{
		protected static Smart.Dal.BillDetailDal dal = new Smart.Dal.BillDetailDal();

		public System.Int64 Id		{ get ; set; }

		public System.Int64 BillMasterId		{ get ; set; }

		public System.Int32 MarketId		{ get ; set; }

		public System.Int64 ShopId		{ get ; set; }

		public System.Decimal MonthlyRent		{ get ; set; }

		public System.Decimal ServiceCharge		{ get ; set; }

		public System.Decimal MiscBills		{ get ; set; }

		public System.Decimal ThisMonthTotal		{ get ; set; }

		public System.Decimal PreviousDue		{ get ; set; }

		public System.Decimal TotalAmount		{ get ; set; }

		public System.Decimal LateFee		{ get ; set; }

		public System.Decimal TotalAmountAfterLateFee		{ get ; set; }

		public System.Decimal Payment		{ get ; set; }

		public System.Decimal Due		{ get ; set; }

		public System.Boolean IsClosed		{ get ; set; }

		public System.Int32 ClosedBy		{ get ; set; }


		public  Int32 InsertBillDetail()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@BillMasterId", BillMasterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MarketId", MarketId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ShopId", ShopId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MonthlyRent", MonthlyRent.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ServiceCharge", ServiceCharge.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MiscBills", MiscBills.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ThisMonthTotal", ThisMonthTotal.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PreviousDue", PreviousDue.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LateFee", LateFee.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmountAfterLateFee", TotalAmountAfterLateFee.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Payment", Payment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Due", Due.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsClosed", IsClosed);
			lstItems.Add("@ClosedBy", ClosedBy.ToString(CultureInfo.InvariantCulture));

			return dal.InsertBillDetail(lstItems);
		}

		public  Int32 UpdateBillDetail()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@BillMasterId", BillMasterId.ToString());
			lstItems.Add("@MarketId", MarketId.ToString());
			lstItems.Add("@ShopId", ShopId.ToString());
			lstItems.Add("@MonthlyRent", MonthlyRent.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ServiceCharge", ServiceCharge.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MiscBills", MiscBills.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ThisMonthTotal", ThisMonthTotal.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PreviousDue", PreviousDue.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LateFee", LateFee.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmountAfterLateFee", TotalAmountAfterLateFee.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Payment", Payment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Due", Due.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsClosed", IsClosed);
			lstItems.Add("@ClosedBy", ClosedBy.ToString());

			return dal.UpdateBillDetail(lstItems);
		}

		public  Int32 DeleteBillDetailById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteBillDetailById(lstItems);
		}

		public List<BillDetail> GetAllBillDetail()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllBillDetail(lstItems);
			List<BillDetail> BillDetailList = new List<BillDetail>();
			foreach (DataRow dr in dt.Rows)
			{
				BillDetailList.Add(GetObject(dr));
			}
			return BillDetailList;
		}

		public BillDetail  GetBillDetailById(Int64 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetBillDetailById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  BillDetail GetObject(DataRow dr)
		{

			BillDetail objBillDetail = new BillDetail();
			objBillDetail.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int64)dr["Id"];
			objBillDetail.BillMasterId = (dr["BillMasterId"] == DBNull.Value) ? 0 : (Int64)dr["BillMasterId"];
			objBillDetail.MarketId = (dr["MarketId"] == DBNull.Value) ? 0 : (Int32)dr["MarketId"];
			objBillDetail.ShopId = (dr["ShopId"] == DBNull.Value) ? 0 : (Int64)dr["ShopId"];
			objBillDetail.MonthlyRent = (dr["MonthlyRent"] == DBNull.Value) ? 0 : (Decimal)dr["MonthlyRent"];
			objBillDetail.ServiceCharge = (dr["ServiceCharge"] == DBNull.Value) ? 0 : (Decimal)dr["ServiceCharge"];
			objBillDetail.MiscBills = (dr["MiscBills"] == DBNull.Value) ? 0 : (Decimal)dr["MiscBills"];
			objBillDetail.ThisMonthTotal = (dr["ThisMonthTotal"] == DBNull.Value) ? 0 : (Decimal)dr["ThisMonthTotal"];
			objBillDetail.PreviousDue = (dr["PreviousDue"] == DBNull.Value) ? 0 : (Decimal)dr["PreviousDue"];
			objBillDetail.TotalAmount = (dr["TotalAmount"] == DBNull.Value) ? 0 : (Decimal)dr["TotalAmount"];
			objBillDetail.LateFee = (dr["LateFee"] == DBNull.Value) ? 0 : (Decimal)dr["LateFee"];
			objBillDetail.TotalAmountAfterLateFee = (dr["TotalAmountAfterLateFee"] == DBNull.Value) ? 0 : (Decimal)dr["TotalAmountAfterLateFee"];
			objBillDetail.Payment = (dr["Payment"] == DBNull.Value) ? 0 : (Decimal)dr["Payment"];
			objBillDetail.Due = (dr["Due"] == DBNull.Value) ? 0 : (Decimal)dr["Due"];
			objBillDetail.IsClosed = (dr["IsClosed"] == DBNull.Value) ? false : (Boolean)dr["IsClosed"];
			objBillDetail.ClosedBy = (dr["ClosedBy"] == DBNull.Value) ? 0 : (Int32)dr["ClosedBy"];

			return objBillDetail;
		}
	}
}
