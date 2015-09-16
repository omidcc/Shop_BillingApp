using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Shop : Smart.Bll.Base.ShopBase
	{
	    public int TenantId { get; set; }
        public string TenantName { get; set; }
        public string ShopInfo { get; set; }

	    private static Smart.Dal.ShopDal Dal = new Smart.Dal.ShopDal();
		public Shop() : base()
		{
		}


	    public int GetLastShopId()
	    {
	        return dal.GetLastShopId();
	    }

	    public List<Shop> GetAllUnallocatedShop()
	    {
            DataTable dt = dal.GetAllUnAllocatedShop();
            List<Shop> ShopList = new List<Shop>();
            foreach (DataRow dr in dt.Rows)
            {
                ShopList.Add(GetObject(dr));
            }
            return ShopList;

	    }

        public List<Shop> GetAllUnallocatedShopByMarketId(int marketId)
        {
            Hashtable listItem=new Hashtable();
            listItem.Add("@marketId", marketId);
            DataTable dt = dal.GetAllUnAllocatedShopByMarketId(listItem);
            List<Shop> ShopList = new List<Shop>();
            foreach (DataRow dr in dt.Rows)
            {
                ShopList.Add(GetObject(dr));
            }
            return ShopList;

        }

	    public int CheckShopNoExistance(bool isNewEntry)
	    {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@MarketId", MarketId);
            lstItems.Add("@ShopNo", ShopNo);
            if(!isNewEntry)
                lstItems.Add("@ID", Id);

	        return dal.CheckShopNoExistance(lstItems, isNewEntry);
	    }


        public List<Shop> GetAllShopByMarketIdWithoutTenant(int marketId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@MarketId", marketId);

            DataTable dt = dal.GetAllShopByMarketIdWithoutTenant(lstItems);
            List<Shop> ShopList = new List<Shop>();
            foreach (DataRow dr in dt.Rows)
            {
                Shop shop = GetObject(dr);
                //shop.TenantId = int.Parse(dr["TenantId"].ToString());
                //shop.TenantName = dr["TenantName"].ToString();
                //shop.ShopInfo = dr["ShopInfo"].ToString();

                ShopList.Add(shop);
            }
            return ShopList;
        }

        public List<Shop> GetAllShopByMarketId(int marketId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@MarketId", marketId);

            DataTable dt = dal.GetAllShopByMarketId(lstItems);
            List<Shop> ShopList = new List<Shop>();
            foreach (DataRow dr in dt.Rows)
            {
                Shop shop = GetObject(dr);
                shop.TenantId = int.Parse(dr["TenantId"].ToString());
                shop.TenantName = dr["TenantName"].ToString();
                shop.ShopInfo = dr["ShopInfo"].ToString();

                ShopList.Add(shop);
            }
            return ShopList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public int GetPreviousShopId(int tenantId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", tenantId);

            string id = dal.GetPreviousShopId(lstItems);

            return (id == string.Empty) ? 0 : int.Parse(id);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public int GetNextShopId(int tenantId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", tenantId);

            string id = dal.GetNextShopId(lstItems);

            return (id == string.Empty) ? 0 : int.Parse(id);
        }
	}
}
