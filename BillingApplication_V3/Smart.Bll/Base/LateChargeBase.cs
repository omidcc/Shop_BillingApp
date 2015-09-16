using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class LateChargeBase
	{
		protected static Smart.Dal.LateChargeDal dal = new Smart.Dal.LateChargeDal();

		public System.Int64 Id		{ get ; set; }

		public System.Int64 ShopId		{ get ; set; }

		public System.Int64 TenantId		{ get ; set; }

		public System.Int32 Month		{ get ; set; }

		public System.Int32 Year		{ get ; set; }

		public System.DateTime AppliedDate		{ get ; set; }

		public System.Decimal Amount		{ get ; set; }


		public  Int32 InsertLateCharge()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ShopId", ShopId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TenantId", TenantId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Month", Month.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Year", Year.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@AppliedDate", AppliedDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Amount", Amount.ToString(CultureInfo.InvariantCulture));

			return dal.InsertLateCharge(lstItems);
		}

		public  Int32 UpdateLateCharge()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@ShopId", ShopId.ToString());
			lstItems.Add("@TenantId", TenantId.ToString());
			lstItems.Add("@Month", Month.ToString());
			lstItems.Add("@Year", Year.ToString());
			lstItems.Add("@AppliedDate", AppliedDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Amount", Amount.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateLateCharge(lstItems);
		}

		public  Int32 DeleteLateChargeById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteLateChargeById(lstItems);
		}

		public List<LateCharge> GetAllLateCharge()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllLateCharge(lstItems);
			List<LateCharge> LateChargeList = new List<LateCharge>();
			foreach (DataRow dr in dt.Rows)
			{
				LateChargeList.Add(GetObject(dr));
			}
			return LateChargeList;
		}

		public LateCharge  GetLateChargeById(Int64 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetLateChargeById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  LateCharge GetObject(DataRow dr)
		{

			LateCharge objLateCharge = new LateCharge();
			objLateCharge.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int64)dr["Id"];
			objLateCharge.ShopId = (dr["ShopId"] == DBNull.Value) ? 0 : (Int64)dr["ShopId"];
			objLateCharge.TenantId = (dr["TenantId"] == DBNull.Value) ? 0 : (Int64)dr["TenantId"];
			objLateCharge.Month = (dr["Month"] == DBNull.Value) ? 0 : (Int32)dr["Month"];
			objLateCharge.Year = (dr["Year"] == DBNull.Value) ? 0 : (Int32)dr["Year"];
			objLateCharge.AppliedDate = (dr["AppliedDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["AppliedDate"];
			objLateCharge.Amount = (dr["Amount"] == DBNull.Value) ? 0 : (Decimal)dr["Amount"];

			return objLateCharge;
		}
	}
}
