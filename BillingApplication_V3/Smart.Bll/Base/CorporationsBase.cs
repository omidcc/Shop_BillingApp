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
	public class CorporationsBase
	{
		protected static Smart.Dal.CorporationsDal dal = new Smart.Dal.CorporationsDal();

		public System.Int64 Id		{ get ; set; }

		public System.String CorpCode		{ get ; set; }

		public System.String CorpName		{ get ; set; }

		public System.String Address		{ get ; set; }

		public System.String ContactNo		{ get ; set; }

		public System.String ContactPerson		{ get ; set; }

		public System.String Designation		{ get ; set; }

		public System.String CPContactNo		{ get ; set; }

		public System.String Email		{ get ; set; }

		public System.Decimal DiscountPcnt		{ get ; set; }

		public System.Int64 PaymentMethodId		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }


		public  Int32 InsertCorporations()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CorpCode", CorpCode);
			lstItems.Add("@CorpName", CorpName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@ContactNo", ContactNo);
			lstItems.Add("@ContactPerson", ContactPerson);
			lstItems.Add("@Designation", Designation);
			lstItems.Add("@CPContactNo", CPContactNo);
			lstItems.Add("@Email", Email);
			lstItems.Add("@DiscountPcnt", DiscountPcnt.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PaymentMethodId", PaymentMethodId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);

			return dal.InsertCorporations(lstItems);
		}

		public  Int32 UpdateCorporations()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@CorpCode", CorpCode);
			lstItems.Add("@CorpName", CorpName);
			lstItems.Add("@Address", Address);
			lstItems.Add("@ContactNo", ContactNo);
			lstItems.Add("@ContactPerson", ContactPerson);
			lstItems.Add("@Designation", Designation);
			lstItems.Add("@CPContactNo", CPContactNo);
			lstItems.Add("@Email", Email);
			lstItems.Add("@DiscountPcnt", DiscountPcnt.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PaymentMethodId", PaymentMethodId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);

			return dal.UpdateCorporations(lstItems);
		}

		public  Int32 DeleteCorporationsById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteCorporationsById(lstItems);
		}

		public  DataTable GetAllCorporations()
		{
			return dal.GetAllCorporations();
		}

		public List<Corporations> CorporationsSelectAll()
		{
			DataTable dt = new DataTable();
			List<Corporations> CorporationsList = new List<Corporations>();
			foreach (DataRow dr in dt.Rows)
			{
				CorporationsList.Add(GetObject(dr));
			}
			return CorporationsList;
		}

		public  DataTable GetAllCorporationsById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllCorporationsById(lstItems);
		}

		public Corporations  GetCorporationsById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllCorporationsById(lstItems);
			Corporations objCorporations = new Corporations();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static Corporations GetObject(DataRow dr)
		{

			Corporations objCorporations = new Corporations
			{
				 Id = (Int64)dr["Id"],
				 CorpCode = (String)dr["CorpCode"],
				 CorpName = (String)dr["CorpName"],
				 Address = (String)dr["Address"],
				 ContactNo = (String)dr["ContactNo"],
				 ContactPerson = (String)dr["ContactPerson"],
				 Designation = (String)dr["Designation"],
				 CPContactNo = (String)dr["CPContactNo"],
				 Email = (String)dr["Email"],
				 DiscountPcnt = (Decimal)dr["DiscountPcnt"],
				 PaymentMethodId = (Int64)dr["PaymentMethodId"],
				 IsActive = (Boolean)dr["IsActive"],
			};

			return objCorporations;
		}
	}
}
