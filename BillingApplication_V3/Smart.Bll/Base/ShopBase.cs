using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class ShopBase
	{
		protected static Smart.Dal.ShopDal dal = new Smart.Dal.ShopDal();

		public System.Int32 Id		{ get ; set; }

		public System.Int32 MarketId		{ get ; set; }

		public System.String ShopNo		{ get ; set; }

		public System.Int32 CategoryId		{ get ; set; }

		public System.String ShopType		{ get ; set; }

		public System.Decimal SpaceInSqFt		{ get ; set; }

		public System.Decimal MonthlyRent		{ get ; set; }

		public System.Decimal AdvanceAmount		{ get ; set; }

		public System.Decimal ServiceCharge		{ get ; set; }

		public System.String Description		{ get ; set; }

	    public System.Decimal MiscBill { get; set; }


	    public  Int32 InsertShop()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MarketId", MarketId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ShopNo", ShopNo);
			lstItems.Add("@CategoryId", CategoryId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ShopType", ShopType);
			lstItems.Add("@SpaceInSqFt", SpaceInSqFt.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MonthlyRent", MonthlyRent.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@AdvanceAmount", AdvanceAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ServiceCharge", ServiceCharge.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Description", Description);
            lstItems.Add("@MiscBill", MiscBill.ToString(CultureInfo.InvariantCulture));


			return dal.InsertShop(lstItems);
		}

		public  Int32 UpdateShop()
		{
			Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@MarketId", MarketId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ShopNo", ShopNo);
			lstItems.Add("@CategoryId", CategoryId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ShopType", ShopType);
			lstItems.Add("@SpaceInSqFt", SpaceInSqFt.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MonthlyRent", MonthlyRent.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@AdvanceAmount", AdvanceAmount.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ServiceCharge", ServiceCharge.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Description", Description);
            lstItems.Add("@MiscBill", MiscBill.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateShop(lstItems);
		}

		public  Int32 DeleteShopById(Int32 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteShopById(lstItems);
		}

		public List<Shop> GetAllShop()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllShop(lstItems);
			List<Shop> ShopList = new List<Shop>();
			foreach (DataRow dr in dt.Rows)
			{
				ShopList.Add(GetObject(dr));
			}
			return ShopList;
		}

		public Shop  GetShopById(Int32 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetShopById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Shop GetObject(DataRow dr)
		{

			Shop objShop = new Shop();
			objShop.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int32)dr["Id"];
			objShop.MarketId = (dr["MarketId"] == DBNull.Value) ? 0 : (Int32)dr["MarketId"];
			objShop.ShopNo = (dr["ShopNo"] == DBNull.Value) ? "" : (String)dr["ShopNo"];
			objShop.CategoryId = (dr["CategoryId"] == DBNull.Value) ? 0 : (Int32)dr["CategoryId"];
			objShop.ShopType = (dr["ShopType"] == DBNull.Value) ? "" : (String)dr["ShopType"];
			objShop.SpaceInSqFt = (dr["SpaceInSqFt"] == DBNull.Value) ? 0 : (Decimal)dr["SpaceInSqFt"];
			objShop.MonthlyRent = (dr["MonthlyRent"] == DBNull.Value) ? 0 : (Decimal)dr["MonthlyRent"];
			objShop.AdvanceAmount = (dr["AdvanceAmount"] == DBNull.Value) ? 0 : (Decimal)dr["AdvanceAmount"];
			objShop.ServiceCharge = (dr["ServiceCharge"] == DBNull.Value) ? 0 : (Decimal)dr["ServiceCharge"];
			objShop.Description = (dr["Description"] == DBNull.Value) ? "" : (String)dr["Description"];
            objShop.MiscBill = (dr["MiscBill"] == DBNull.Value) ? 0 : (Decimal)dr["MiscBill"];

			return objShop;
		}
	}
}
