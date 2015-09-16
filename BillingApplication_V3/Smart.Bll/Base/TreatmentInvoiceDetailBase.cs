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
	public class TreatmentInvoiceDetailBase
	{
		protected static Smart.Dal.TreatmentInvoiceDetailDal dal = new Smart.Dal.TreatmentInvoiceDetailDal();

		public System.Int64 Id		{ get ; set; }

		public System.Int64 MasterId		{ get ; set; }

		public System.Int64 TreatmentId		{ get ; set; }

		public System.Decimal TotalAmount		{ get ; set; }

		public System.Decimal Payment		{ get ; set; }

		public System.Decimal DueAmount		{ get ; set; }


		public  Int32 InsertTreatmentInvoiceDetail()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MasterId", MasterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TreatmentId", TreatmentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Payment", Payment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DueAmount", DueAmount.ToString(CultureInfo.InvariantCulture));

			return dal.InsertTreatmentInvoiceDetail(lstItems);
		}

		public  Int32 UpdateTreatmentInvoiceDetail()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MasterId", MasterId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TreatmentId", TreatmentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Payment", Payment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DueAmount", DueAmount.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateTreatmentInvoiceDetail(lstItems);
		}

		public  Int32 DeleteTreatmentInvoiceDetailById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteTreatmentInvoiceDetailById(lstItems);
		}

		public  DataTable GetAllTreatmentInvoiceDetail()
		{
			return dal.GetAllTreatmentInvoiceDetail();
		}

		public List<TreatmentInvoiceDetail> TreatmentInvoiceDetailSelectAll()
		{
			DataTable dt = new DataTable();
			List<TreatmentInvoiceDetail> TreatmentInvoiceDetailList = new List<TreatmentInvoiceDetail>();
			foreach (DataRow dr in dt.Rows)
			{
				TreatmentInvoiceDetailList.Add(GetObject(dr));
			}
			return TreatmentInvoiceDetailList;
		}

		public  DataTable GetAllTreatmentInvoiceDetailById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllTreatmentInvoiceDetailById(lstItems);
		}

		public TreatmentInvoiceDetail  GetTreatmentInvoiceDetailById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllTreatmentInvoiceDetailById(lstItems);
			TreatmentInvoiceDetail objTreatmentInvoiceDetail = new TreatmentInvoiceDetail();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static TreatmentInvoiceDetail GetObject(DataRow dr)
		{

			TreatmentInvoiceDetail objTreatmentInvoiceDetail = new TreatmentInvoiceDetail
			{
				 Id = (Int64)dr["Id"],
				 MasterId = (Int64)dr["MasterId"],
				 TreatmentId = (Int64)dr["TreatmentId"],
				 TotalAmount = (Decimal)dr["TotalAmount"],
				 Payment = (Decimal)dr["Payment"],
				 DueAmount = (Decimal)dr["DueAmount"],
			};

			return objTreatmentInvoiceDetail;
		}
	}
}
