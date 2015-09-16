using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class ShopeMappingBase
	{
		protected static Smart.Dal.ShopeMappingDal dal = new Smart.Dal.ShopeMappingDal();

		public System.Int64 Id		{ get ; set; }

		public System.Int32 MarketId		{ get ; set; }

		public System.Int64 TenantId		{ get ; set; }

		public System.Int64 ShopeId		{ get ; set; }

		public System.Decimal MonthlyRent		{ get ; set; }

		public System.Decimal ServiceCharge		{ get ; set; }

		public System.Decimal Advance		{ get ; set; }

		public System.Decimal PreviousDue		{ get ; set; }

		public System.DateTime ContractDate		{ get ; set; }

		public System.Int32 ContractValidYear		{ get ; set; }

        public System.Decimal MiscBill { get; set; }


		public  Int32 InsertShopeMapping()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MarketId", MarketId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TenantId", TenantId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ShopeId", ShopeId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MonthlyRent", MonthlyRent.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ServiceCharge", ServiceCharge.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Advance", Advance.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PreviousDue", PreviousDue.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ContractDate", ContractDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ContractValidYear", ContractValidYear.ToString(CultureInfo.InvariantCulture));
            lstItems.Add("@MiscBill", MiscBill.ToString(CultureInfo.InvariantCulture));

			return dal.InsertShopeMapping(lstItems);
		}

		public  Int32 UpdateShopeMapping()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@MarketId", MarketId.ToString());
			lstItems.Add("@TenantId", TenantId.ToString());
			lstItems.Add("@ShopeId", ShopeId.ToString());
			lstItems.Add("@MonthlyRent", MonthlyRent.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ServiceCharge", ServiceCharge.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Advance", Advance.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@PreviousDue", PreviousDue.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ContractDate", ContractDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ContractValidYear", ContractValidYear.ToString());
            lstItems.Add("@MiscBill", MiscBill.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateShopeMapping(lstItems);
		}

		public  Int32 DeleteShopeMappingById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteShopeMappingById(lstItems);
		}

		public List<ShopeMapping> GetAllShopeMapping()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllShopeMapping(lstItems);
			List<ShopeMapping> ShopeMappingList = new List<ShopeMapping>();
			foreach (DataRow dr in dt.Rows)
			{
				ShopeMappingList.Add(GetObject(dr));
			}
			return ShopeMappingList;
		}

		public ShopeMapping  GetShopeMappingById(Int64 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetShopeMappingById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  ShopeMapping GetObject(DataRow dr)
		{

			ShopeMapping objShopeMapping = new ShopeMapping();
			objShopeMapping.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int64)dr["Id"];
			objShopeMapping.MarketId = (dr["MarketId"] == DBNull.Value) ? 0 : (Int32)dr["MarketId"];
			objShopeMapping.TenantId = (dr["TenantId"] == DBNull.Value) ? 0 : (Int64)dr["TenantId"];
			objShopeMapping.ShopeId = (dr["ShopeId"] == DBNull.Value) ? 0 : (Int64)dr["ShopeId"];
			objShopeMapping.MonthlyRent = (dr["MonthlyRent"] == DBNull.Value) ? 0 : (Decimal)dr["MonthlyRent"];
			objShopeMapping.ServiceCharge = (dr["ServiceCharge"] == DBNull.Value) ? 0 : (Decimal)dr["ServiceCharge"];
			objShopeMapping.Advance = (dr["Advance"] == DBNull.Value) ? 0 : (Decimal)dr["Advance"];
			objShopeMapping.PreviousDue = (dr["PreviousDue"] == DBNull.Value) ? 0 : (Decimal)dr["PreviousDue"];
			objShopeMapping.ContractDate = (dr["ContractDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["ContractDate"];
			objShopeMapping.ContractValidYear = (dr["ContractValidYear"] == DBNull.Value) ? 0 : (Int32)dr["ContractValidYear"];
            objShopeMapping.MiscBill = (dr["MiscBill"] == DBNull.Value) ? 0 : (Decimal)dr["MiscBill"];
			return objShopeMapping;
		}
	}
}
