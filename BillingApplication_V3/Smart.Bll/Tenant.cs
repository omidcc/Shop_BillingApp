using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Tenant : Smart.Bll.Base.TenantBase
	{
		private static Smart.Dal.TenantDal Dal = new Smart.Dal.TenantDal();
		public Tenant() : base()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
	    public int GetMaxTenantId()
	    {
	        return dal.GetMaxTenantId();
	    }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public int GetNextTenantId(int tenantId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", tenantId);

            string id = dal.GetNextTenantId(lstItems);
            
            return (id == string.Empty)?0: int.Parse(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public int GetPreviousTenantId(int tenantId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", tenantId);

            string id = dal.GetPreviousTenantId(lstItems);

            return (id == string.Empty) ? 0 : int.Parse(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllTenantWithDetail(int tenantId, int shopId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@ShopId", shopId);
            lstItems.Add("@Id", tenantId);

            return dal.GetAllTenantWithDetail(lstItems);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_MarketId"></param>
        /// <returns></returns>
        public DataTable GetTenantByMarketId(Int64 _MarketId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@MarketId", _MarketId);

            return dal.GetTenantByMarketId(lstItems);
            //List<Tenant> TenantList = new List<Tenant>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    TenantList.Add(GetObject(dr));
            //}
            //return TenantList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_MarketId"></param>
        /// <returns></returns>
        public DataTable GetTenantWithDue(Int64 _MarketId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@MarketId", _MarketId);

            return dal.GetTenantWithDue(lstItems);
        }


        public DataTable GetAllTenant()
        {

            return dal.GetAllTenant(new Hashtable());
            //List<Tenant> TenantList = new List<Tenant>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    TenantList.Add(GetObject(dr));
            //}
            //return TenantList;
        }

        public List<Tenant> SearchTenantByName(string _tenantName)
        {
            DataTable dt = dal.SearchTenantByName(_tenantName);
            return (from DataRow dr in dt.Rows select GetObject(dr)).ToList();
        }        
	}
}
