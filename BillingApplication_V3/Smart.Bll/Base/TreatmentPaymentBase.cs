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
	public class TreatmentPaymentBase
	{
		protected static Smart.Dal.TreatmentPaymentDal dal = new Smart.Dal.TreatmentPaymentDal();

		public System.Int64 Id		{ get ; set; }

		public System.String PaymentCode		{ get ; set; }

		public System.DateTime PayDate		{ get ; set; }

		public System.Int64 TreatmentId		{ get ; set; }

		public System.Decimal TotalAmount		{ get ; set; }

		public System.Decimal Discount		{ get ; set; }

		public System.Decimal Payable		{ get ; set; }

		public System.Decimal PaidAmount		{ get ; set; }

		public System.Decimal DueAmount		{ get ; set; }

		public System.Decimal ThisAmount		{ get ; set; }

		public System.Decimal CurrentBalance		{ get ; set; }


		public  Int32 InsertTreatmentPayment()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@PaymentCode", PaymentCode);
			lstItems.Add("@PayDate", PayDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TreatmentId", TreatmentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Discount", Discount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Payable", Payable.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PaidAmount", PaidAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DueAmount", DueAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ThisAmount", ThisAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CurrentBalance", CurrentBalance.ToString(CultureInfo.InvariantCulture));

			return dal.InsertTreatmentPayment(lstItems);
		}

		public  Int32 UpdateTreatmentPayment()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@PaymentCode", PaymentCode);
			lstItems.Add("@PayDate", PayDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TreatmentId", TreatmentId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalAmount", TotalAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Discount", Discount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Payable", Payable.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PaidAmount", PaidAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DueAmount", DueAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ThisAmount", ThisAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CurrentBalance", CurrentBalance.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateTreatmentPayment(lstItems);
		}

		public  Int32 DeleteTreatmentPaymentById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteTreatmentPaymentById(lstItems);
		}

		public  DataTable GetAllTreatmentPayment()
		{
			return dal.GetAllTreatmentPayment();
		}

		public List<TreatmentPayment> TreatmentPaymentSelectAll()
		{
			DataTable dt = new DataTable();
			List<TreatmentPayment> TreatmentPaymentList = new List<TreatmentPayment>();
			foreach (DataRow dr in dt.Rows)
			{
				TreatmentPaymentList.Add(GetObject(dr));
			}
			return TreatmentPaymentList;
		}

		public  DataTable GetAllTreatmentPaymentById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllTreatmentPaymentById(lstItems);
		}

		public TreatmentPayment  GetTreatmentPaymentById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllTreatmentPaymentById(lstItems);
			TreatmentPayment objTreatmentPayment = new TreatmentPayment();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static TreatmentPayment GetObject(DataRow dr)
		{

			TreatmentPayment objTreatmentPayment = new TreatmentPayment
			{
				 Id = (Int64)dr["Id"],
				 PaymentCode = (String)dr["PaymentCode"],
				 PayDate = (DateTime)dr["PayDate"],
				 TreatmentId = (Int64)dr["TreatmentId"],
				 TotalAmount = (Decimal)dr["TotalAmount"],
				 Discount = (Decimal)dr["Discount"],
				 Payable = (Decimal)dr["Payable"],
				 PaidAmount = (Decimal)dr["PaidAmount"],
				 DueAmount = (Decimal)dr["DueAmount"],
				 ThisAmount = (Decimal)dr["ThisAmount"],
				 CurrentBalance = (Decimal)dr["CurrentBalance"],
			};

			return objTreatmentPayment;
		}
	}
}
