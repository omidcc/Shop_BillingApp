using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class ReceiptDetailBase
	{
		protected static Smart.Dal.ReceiptDetailDal dal = new Smart.Dal.ReceiptDetailDal();

		public System.Int64 Id		{ get ; set; }

		public System.Int64 ReceiptMasterId		{ get ; set; }

		public System.Int64 BillMasterId		{ get ; set; }

		public System.Int64 BillDetailId		{ get ; set; }

		public System.Decimal BillAmount		{ get ; set; }

		public System.Decimal PaymentAmount		{ get ; set; }

		public System.Decimal Due		{ get ; set; }


		public  Int32 InsertReceiptDetail()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ReceiptMasterId", ReceiptMasterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillMasterId", BillMasterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillDetailId", BillDetailId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillAmount", BillAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PaymentAmount", PaymentAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Due", Due.ToString(CultureInfo.InvariantCulture));

			return dal.InsertReceiptDetail(lstItems);
		}

		public  Int32 UpdateReceiptDetail()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ReceiptMasterId", ReceiptMasterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillMasterId", BillMasterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillDetailId", BillDetailId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@BillAmount", BillAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PaymentAmount", PaymentAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Due", Due.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateReceiptDetail(lstItems);
		}

		public  Int32 DeleteReceiptDetailById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteReceiptDetailById(lstItems);
		}

		public List<ReceiptDetail> GetAllReceiptDetail()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllReceiptDetail(lstItems);
			List<ReceiptDetail> ReceiptDetailList = new List<ReceiptDetail>();
			foreach (DataRow dr in dt.Rows)
			{
				ReceiptDetailList.Add(GetObject(dr));
			}
			return ReceiptDetailList;
		}

		public ReceiptDetail  GetReceiptDetailById(Int64 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetReceiptDetailById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  ReceiptDetail GetObject(DataRow dr)
		{

			ReceiptDetail objReceiptDetail = new ReceiptDetail();
			objReceiptDetail.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int64)dr["Id"];
			objReceiptDetail.ReceiptMasterId = (dr["ReceiptMasterId"] == DBNull.Value) ? 0 : (Int64)dr["ReceiptMasterId"];
			objReceiptDetail.BillMasterId = (dr["BillMasterId"] == DBNull.Value) ? 0 : (Int64)dr["BillMasterId"];
			objReceiptDetail.BillDetailId = (dr["BillDetailId"] == DBNull.Value) ? 0 : (Int64)dr["BillDetailId"];
			objReceiptDetail.BillAmount = (dr["BillAmount"] == DBNull.Value) ? 0 : (Decimal)dr["BillAmount"];
			objReceiptDetail.PaymentAmount = (dr["PaymentAmount"] == DBNull.Value) ? 0 : (Decimal)dr["PaymentAmount"];
			objReceiptDetail.Due = (dr["Due"] == DBNull.Value) ? 0 : (Decimal)dr["Due"];

			return objReceiptDetail;
		}
	}
}
