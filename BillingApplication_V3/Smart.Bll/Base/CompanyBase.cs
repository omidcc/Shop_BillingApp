using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class CompanyBase
	{
		protected static Smart.Dal.CompanyDal dal = new Smart.Dal.CompanyDal();

		public System.Int32 Id		{ get ; set; }

		public System.String CompanyName		{ get ; set; }

		public System.String Header1		{ get ; set; }

		public System.String Address		{ get ; set; }


		public  Int32 InsertCompany()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@CompanyName", CompanyName);
			lstItems.Add("@Header1", Header1);
			lstItems.Add("@Address", Address);

			return dal.InsertCompany(lstItems);
		}

		public  Int32 UpdateCompany()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@CompanyName", CompanyName);
			lstItems.Add("@Header1", Header1);
			lstItems.Add("@Address", Address);

			return dal.UpdateCompany(lstItems);
		}

		public  Int32 DeleteCompanyById(Int32 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteCompanyById(lstItems);
		}

		public List<Company> GetAllCompany()
		{
			DataTable dt = dal.GetAllCompany();
			List<Company> CompanyList = new List<Company>();
			foreach (DataRow dr in dt.Rows)
			{
				CompanyList.Add(GetObject(dr));
			}
			return CompanyList;
		}

		public Company GetCompanyById(int _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetCompanyById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Company GetObject(DataRow dr)
		{

			Company objCompany = new Company();
			objCompany.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int32)dr["Id"];
			objCompany.CompanyName = (dr["CompanyName"] == DBNull.Value) ? "" : (String)dr["CompanyName"];
			objCompany.Header1 = (dr["Header1"] == DBNull.Value) ? "" : (String)dr["Header1"];
			objCompany.Address = (dr["Address"] == DBNull.Value) ? "" : (String)dr["Address"];

			return objCompany;
		}
	}
}
