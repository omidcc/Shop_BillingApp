using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class MarketBase
	{
		protected static Smart.Dal.MarketDal dal = new Smart.Dal.MarketDal();

		public System.Int32 Id		{ get ; set; }

		public System.String MarketName		{ get ; set; }

		public System.String Description		{ get ; set; }

		public System.String EstablishDate		{ get ; set; }

		public System.String InCharge		{ get ; set; }


		public  Int32 InsertMarket()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MarketName", MarketName);
			lstItems.Add("@Description", Description);
			lstItems.Add("@EstablishDate", EstablishDate);
			lstItems.Add("@InCharge", InCharge);

			return dal.InsertMarket(lstItems);
		}

		public  Int32 UpdateMarket()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@MarketName", MarketName);
			lstItems.Add("@Description", Description);
			lstItems.Add("@EstablishDate", EstablishDate);
			lstItems.Add("@InCharge", InCharge);

			return dal.UpdateMarket(lstItems);
		}

		public  Int32 DeleteMarketById(Int32 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteMarketById(lstItems);
		}

		public List<Market> GetAllMarket()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllMarket(lstItems);
			List<Market> MarketList = new List<Market>();
			foreach (DataRow dr in dt.Rows)
			{
				MarketList.Add(GetObject(dr));
			}
			return MarketList;
		}

		public Market  GetMarketById(Int32 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetMarketById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  Market GetObject(DataRow dr)
		{

			Market objMarket = new Market();
			objMarket.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int32)dr["Id"];
			objMarket.MarketName = (dr["MarketName"] == DBNull.Value) ? "" : (String)dr["MarketName"];
			objMarket.Description = (dr["Description"] == DBNull.Value) ? "" : (String)dr["Description"];
			objMarket.EstablishDate = (dr["EstablishDate"] == DBNull.Value) ? "" : (String)dr["EstablishDate"];
			objMarket.InCharge = (dr["InCharge"] == DBNull.Value) ? "" : (String)dr["InCharge"];

			return objMarket;
		}
	}
}
