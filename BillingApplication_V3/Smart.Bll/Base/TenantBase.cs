using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class TenantBase
	{
		protected static Smart.Dal.TenantDal dal = new Smart.Dal.TenantDal();

		public System.Int64 Id		{ get ; set; }

		public System.String TenantName		{ get ; set; }

		public System.String FathersNames		{ get ; set; }

		public System.String Address		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.Decimal OutstandingAmount		{ get ; set; }

		public System.Int32 NoOfShops		{ get ; set; }

		public System.String ContactNo		{ get ; set; }


		public  Int32 InsertTenant()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TenantName", TenantName);
			lstItems.Add("@FathersNames", FathersNames);
			lstItems.Add("@Address", Address);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@OutstandingAmount", OutstandingAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@NoOfShops", NoOfShops.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ContactNo", ContactNo);

			return dal.InsertTenant(lstItems);
		}

		public  Int32 UpdateTenant()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@TenantName", TenantName);
			lstItems.Add("@FathersNames", FathersNames);
			lstItems.Add("@Address", Address);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@OutstandingAmount", OutstandingAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@NoOfShops", NoOfShops.ToString());
			lstItems.Add("@ContactNo", ContactNo);

			return dal.UpdateTenant(lstItems);
		}

		public  Int32 DeleteTenantById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteTenantById(lstItems);
		}

		public List<Tenant> GetAllTenant()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllTenant(lstItems);
			List<Tenant> TenantList = new List<Tenant>();
			foreach (DataRow dr in dt.Rows)
			{
				TenantList.Add(GetObject(dr));
			}
			return TenantList;
		}

		public Tenant  GetTenantById(Int64 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetTenantById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Tenant GetObject(DataRow dr)
		{

			Tenant objTenant = new Tenant();
			objTenant.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int64)dr["Id"];
			objTenant.TenantName = (dr["TenantName"] == DBNull.Value) ? "" : (String)dr["TenantName"];
			objTenant.FathersNames = (dr["FathersNames"] == DBNull.Value) ? "" : (String)dr["FathersNames"];
			objTenant.Address = (dr["Address"] == DBNull.Value) ? "" : (String)dr["Address"];
			objTenant.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objTenant.OutstandingAmount = (dr["OutstandingAmount"] == DBNull.Value) ? 0 : (Decimal)dr["OutstandingAmount"];
			objTenant.NoOfShops = (dr["NoOfShops"] == DBNull.Value) ? 0 : (Int32)dr["NoOfShops"];
			objTenant.ContactNo = (dr["ContactNo"] == DBNull.Value) ? "" : (String)dr["ContactNo"];

			return objTenant;
		}
	}
}
