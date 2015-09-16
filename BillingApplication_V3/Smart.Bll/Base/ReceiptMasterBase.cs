using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class ReceiptMasterBase
	{
		protected static Smart.Dal.ReceiptMasterDal dal = new Smart.Dal.ReceiptMasterDal();

		public System.Int64 Id		{ get ; set; }

		public System.Int64 ReceiptNo		{ get ; set; }

		public System.DateTime ReceiptDate		{ get ; set; }

		public System.Int32 ReceivedBy		{ get ; set; }

		public System.Decimal TotalAmount		{ get ; set; }


		public  Int32 InsertReceiptMaster()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ReceiptNo", ReceiptNo.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ReceiptDate", ReceiptDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ReceivedBy", ReceivedBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));

			return dal.InsertReceiptMaster(lstItems);
		}

		public  Int32 UpdateReceiptMaster()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ReceiptNo", ReceiptNo.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ReceiptDate", ReceiptDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ReceivedBy", ReceivedBy.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateReceiptMaster(lstItems);
		}

		public  Int32 DeleteReceiptMasterById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteReceiptMasterById(lstItems);
		}

		public List<ReceiptMaster> GetAllReceiptMaster()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllReceiptMaster(lstItems);
			List<ReceiptMaster> ReceiptMasterList = new List<ReceiptMaster>();
			foreach (DataRow dr in dt.Rows)
			{
				ReceiptMasterList.Add(GetObject(dr));
			}
			return ReceiptMasterList;
		}

		public ReceiptMaster  GetReceiptMasterById(Int64 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetReceiptMasterById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  ReceiptMaster GetObject(DataRow dr)
		{

			ReceiptMaster objReceiptMaster = new ReceiptMaster();
			objReceiptMaster.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int64)dr["Id"];
			objReceiptMaster.ReceiptNo = (dr["ReceiptNo"] == DBNull.Value) ? 0 : (Int64)dr["ReceiptNo"];
			objReceiptMaster.ReceiptDate = (dr["ReceiptDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["ReceiptDate"];
			objReceiptMaster.ReceivedBy = (dr["ReceivedBy"] == DBNull.Value) ? 0 : (Int32)dr["ReceivedBy"];
			objReceiptMaster.TotalAmount = (dr["TotalAmount"] == DBNull.Value) ? 0 : (Decimal)dr["TotalAmount"];

			return objReceiptMaster;
		}
	}
}
