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
	public class ServiceInvoiceMasterBase
	{
		protected static Smart.Dal.ServiceInvoiceMasterDal dal = new Smart.Dal.ServiceInvoiceMasterDal();

		public System.Int64 Id		{ get ; set; }

		public System.String InvoiceNo		{ get ; set; }

		public System.Int64 PatienId		{ get ; set; }

		public System.Int32 NoOfTreatment		{ get ; set; }

		public System.Decimal Totalcharges		{ get ; set; }

		public System.Decimal TotalPayment		{ get ; set; }

		public System.Decimal DueAmount		{ get ; set; }

		public System.Decimal InvoiceAmount		{ get ; set; }

		public System.DateTime InvoiceDate		{ get ; set; }


		public  Int32 InsertServiceInvoiceMaster()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@InvoiceNo", InvoiceNo);
			lstItems.Add("@PatienId", PatienId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@NoOfTreatment", NoOfTreatment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Totalcharges", Totalcharges.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalPayment", TotalPayment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DueAmount", DueAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@InvoiceAmount", InvoiceAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@InvoiceDate", InvoiceDate.ToString(CultureInfo.InvariantCulture));

			return dal.InsertServiceInvoiceMaster(lstItems);
		}

		public  Int32 UpdateServiceInvoiceMaster()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@InvoiceNo", InvoiceNo);
			lstItems.Add("@PatienId", PatienId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@NoOfTreatment", NoOfTreatment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Totalcharges", Totalcharges.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TotalPayment", TotalPayment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DueAmount", DueAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@InvoiceAmount", InvoiceAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@InvoiceDate", InvoiceDate.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateServiceInvoiceMaster(lstItems);
		}

		public  Int32 DeleteServiceInvoiceMasterById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteServiceInvoiceMasterById(lstItems);
		}

		public  DataTable GetAllServiceInvoiceMaster()
		{
			return dal.GetAllServiceInvoiceMaster();
		}

		public List<ServiceInvoiceMaster> ServiceInvoiceMasterSelectAll()
		{
			DataTable dt = new DataTable();
			List<ServiceInvoiceMaster> ServiceInvoiceMasterList = new List<ServiceInvoiceMaster>();
			foreach (DataRow dr in dt.Rows)
			{
				ServiceInvoiceMasterList.Add(GetObject(dr));
			}
			return ServiceInvoiceMasterList;
		}

		public  DataTable GetAllServiceInvoiceMasterById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllServiceInvoiceMasterById(lstItems);
		}

		public ServiceInvoiceMaster  GetServiceInvoiceMasterById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllServiceInvoiceMasterById(lstItems);
			ServiceInvoiceMaster objServiceInvoiceMaster = new ServiceInvoiceMaster();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static ServiceInvoiceMaster GetObject(DataRow dr)
		{

			ServiceInvoiceMaster objServiceInvoiceMaster = new ServiceInvoiceMaster
			{
				 Id = (Int64)dr["Id"],
				 InvoiceNo = (String)dr["InvoiceNo"],
				 PatienId = (Int64)dr["PatienId"],
				 NoOfTreatment = (Int32)dr["NoOfTreatment"],
				 Totalcharges = (Decimal)dr["Totalcharges"],
				 TotalPayment = (Decimal)dr["TotalPayment"],
				 DueAmount = (Decimal)dr["DueAmount"],
				 InvoiceAmount = (Decimal)dr["InvoiceAmount"],
				 InvoiceDate = (DateTime)dr["InvoiceDate"],
			};

			return objServiceInvoiceMaster;
		}
	}
}
