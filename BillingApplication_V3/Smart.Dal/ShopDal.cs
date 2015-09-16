using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class ShopDal : Smart.Dal.Base.ShopDalBase
	{
		public ShopDal() : base()
		{
		}


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetLastShopId()
        {
            try
            {
                return GetMaximumID("Shop", "Id", 0, "");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetAllUnAllocatedShop()
        {
            string whereCondition = " where Shop.Id not in(select shopId from ShopMapping;)";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("Shop", "*", whereCondition);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAllUnAllocatedShopByMarketId(Hashtable lstItems)
        {
            string whereCondition = " where MarketId = @MarketId and Shop.Id not in(select shopeId from ShopeMapping where MarketId = @MarketId)";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("Shop", "*", whereCondition,lstItems);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CheckShopNoExistance(Hashtable lstItems, bool isNewEntry)
        {
            string whereCondition = string.Empty;
            if(isNewEntry)
                whereCondition = " where Shop.MarketId = @MarketId and Shop.ShopNo = @ShopNo";
            else
                whereCondition = " where Shop.MarketId = @MarketId and Shop.ShopNo = @ShopNo and Shop.ID <> @Id";

            int count = 0;
            try
            {
                count = CheckExistence("Shop", "Id", whereCondition, lstItems);
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAllShopByMarketId(Hashtable lstData)
        {
            string whereCondition = " where MarketId = @MarketId";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewShop", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAllShopByMarketIdWithoutTenant(Hashtable lstData)
        {
            string whereCondition = " where MarketId = @MarketId";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("Shop", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string GetNextShopId(Hashtable lstData)
        {
            string conditionString = " where Id > @Id";
            return ExecuteScaler("Shop", "min(Id)", conditionString, lstData);
        }

        public string GetPreviousShopId(Hashtable lstData)
        {
            string conditionString = " where Id < @Id";

            return ExecuteScaler("Shop", "max(Id)", conditionString, lstData);

        }

	}
}
