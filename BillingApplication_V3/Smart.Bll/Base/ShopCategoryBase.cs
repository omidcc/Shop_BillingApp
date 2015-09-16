using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class ShopCategoryBase
	{
		protected static Smart.Dal.ShopCategoryDal dal = new Smart.Dal.ShopCategoryDal();

		public System.Int32 Id		{ get ; set; }

		public System.String Category		{ get ; set; }

		public System.Decimal ServiceCharge		{ get ; set; }

		public System.String Description		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }

		public System.DateTime LastModified		{ get ; set; }

		public System.Int32 ModifiedBy		{ get ; set; }

        public System.Decimal MiscBill { get; set; }


		public  Int32 InsertShopCategory()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Category", Category);
			lstItems.Add("@ServiceCharge", ServiceCharge.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Description", Description);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@LastModified", LastModified.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ModifiedBy", ModifiedBy.ToString(CultureInfo.InvariantCulture));
            lstItems.Add("@MiscBill", MiscBill.ToString(CultureInfo.InvariantCulture));

			return dal.InsertShopCategory(lstItems);
		}

		public  Int32 UpdateShopCategory()
		{
			Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", Id);
			lstItems.Add("@Category", Category);
			lstItems.Add("@ServiceCharge", ServiceCharge.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Description", Description);
			lstItems.Add("@IsActive", IsActive);
			lstItems.Add("@LastModified", LastModified.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ModifiedBy", ModifiedBy.ToString(CultureInfo.InvariantCulture));
            lstItems.Add("@MiscBill", MiscBill.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateShopCategory(lstItems);
		}

		public  Int32 DeleteShopCategoryById(Int32 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteShopCategoryById(lstItems);
		}

		public List<ShopCategory> GetAllShopCategory()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllShopCategory(lstItems);
			List<ShopCategory> ShopCategoryList = new List<ShopCategory>();
			foreach (DataRow dr in dt.Rows)
			{
				ShopCategoryList.Add(GetObject(dr));
			}
			return ShopCategoryList;
		}

		public ShopCategory  GetShopCategoryById(Int32 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetShopCategoryById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  ShopCategory GetObject(DataRow dr)
		{

			ShopCategory objShopCategory = new ShopCategory();
			objShopCategory.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int32)dr["Id"];
			objShopCategory.Category = (dr["Category"] == DBNull.Value) ? "" : (String)dr["Category"];
			objShopCategory.ServiceCharge = (dr["ServiceCharge"] == DBNull.Value) ? 0 : (Decimal)dr["ServiceCharge"];
			objShopCategory.Description = (dr["Description"] == DBNull.Value) ? "" : (String)dr["Description"];
			objShopCategory.IsActive = (dr["IsActive"] == DBNull.Value) ? false : (Boolean)dr["IsActive"];
			objShopCategory.LastModified = (dr["LastModified"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["LastModified"];
			objShopCategory.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? 0 : (Int32)dr["ModifiedBy"];
            objShopCategory.MiscBill = (dr["MiscBill"] == DBNull.Value) ? 0 : (Decimal)dr["MiscBill"];

			return objShopCategory;
		}
	}
}
