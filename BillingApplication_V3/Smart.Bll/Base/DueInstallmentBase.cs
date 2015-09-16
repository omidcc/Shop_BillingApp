using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class DueInstallmentBase
	{
		protected static Smart.Dal.DueInstallmentDal dal = new Smart.Dal.DueInstallmentDal();

		public System.Int64 Id		{ get ; set; }

		public System.Int64 TenantId		{ get ; set; }

		public System.Int64 ShopId		{ get ; set; }

		public System.DateTime DueDate		{ get ; set; }

		public System.Decimal PreviousDue		{ get ; set; }

		public System.Int32 NoOfInstallment		{ get ; set; }

		public System.Decimal InstallmentAmount		{ get ; set; }

		public System.Decimal PaidAmount		{ get ; set; }

		public System.Decimal DueAmount		{ get ; set; }

		public System.Int32 StartMonth		{ get ; set; }

		public System.Int32 StartYear		{ get ; set; }

		public System.Int32 UserId		{ get ; set; }


		public  Int32 InsertDueInstallment()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@TenantId", TenantId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ShopId", ShopId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@DueDate", DueDate);
			lstItems.Add("@PreviousDue", PreviousDue.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@NoOfInstallment", NoOfInstallment.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@InstallmentAmount", InstallmentAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PaidAmount", PaidAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@StartMonth", StartMonth.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@StartYear", StartYear.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UserId", UserId.ToString(CultureInfo.InvariantCulture));

			return dal.InsertDueInstallment(lstItems);
		}

		public  Int32 UpdateDueInstallment()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@TenantId", TenantId.ToString());
			lstItems.Add("@ShopId", ShopId.ToString());
			lstItems.Add("@DueDate", DueDate);
			lstItems.Add("@PreviousDue", PreviousDue.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@NoOfInstallment", NoOfInstallment.ToString());
			lstItems.Add("@InstallmentAmount", InstallmentAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PaidAmount", PaidAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@StartMonth", StartMonth.ToString());
			lstItems.Add("@StartYear", StartYear.ToString());
			lstItems.Add("@UserId", UserId.ToString());

			return dal.UpdateDueInstallment(lstItems);
		}

		public  Int32 DeleteDueInstallmentById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteDueInstallmentById(lstItems);
		}

		public List<DueInstallment> GetAllDueInstallment()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllDueInstallment(lstItems);
			List<DueInstallment> DueInstallmentList = new List<DueInstallment>();
			foreach (DataRow dr in dt.Rows)
			{
				DueInstallmentList.Add(GetObject(dr));
			}
			return DueInstallmentList;
		}

		public DueInstallment  GetDueInstallmentById(Int64 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetDueInstallmentById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  DueInstallment GetObject(DataRow dr)
		{

			DueInstallment objDueInstallment = new DueInstallment();
			objDueInstallment.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int64)dr["Id"];
			objDueInstallment.TenantId = (dr["TenantId"] == DBNull.Value) ? 0 : (Int64)dr["TenantId"];
			objDueInstallment.ShopId = (dr["ShopId"] == DBNull.Value) ? 0 : (Int64)dr["ShopId"];
			objDueInstallment.DueDate = (dr["DueDate"] == DBNull.Value) ? System.DateTime.Today : (DateTime)dr["DueDate"];
			objDueInstallment.PreviousDue = (dr["PreviousDue"] == DBNull.Value) ? 0 : (Decimal)dr["PreviousDue"];
			objDueInstallment.NoOfInstallment = (dr["NoOfInstallment"] == DBNull.Value) ? 0 : (Int32)dr["NoOfInstallment"];
			objDueInstallment.InstallmentAmount = (dr["InstallmentAmount"] == DBNull.Value) ? 0 : (Decimal)dr["InstallmentAmount"];
			objDueInstallment.PaidAmount = (dr["PaidAmount"] == DBNull.Value) ? 0 : (Decimal)dr["PaidAmount"];
			objDueInstallment.DueAmount = (dr["DueAmount"] == DBNull.Value) ? 0 : (Decimal)dr["DueAmount"];
			objDueInstallment.StartMonth = (dr["StartMonth"] == DBNull.Value) ? 0 : (Int32)dr["StartMonth"];
			objDueInstallment.StartYear = (dr["StartYear"] == DBNull.Value) ? 0 : (Int32)dr["StartYear"];
			objDueInstallment.UserId = (dr["UserId"] == DBNull.Value) ? 0 : (Int32)dr["UserId"];

			return objDueInstallment;
		}
	}
}
