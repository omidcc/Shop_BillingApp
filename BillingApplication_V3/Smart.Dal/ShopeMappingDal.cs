using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class ShopeMappingDal : Smart.Dal.Base.ShopeMappingDalBase
	{
		public ShopeMappingDal() : base()
		{
		}

        public DataTable GetAllShopMappingByShopId(Hashtable lstData)
        {
            string whereCondition = " where ShopeMapping.ShopId = @Id ";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("ShopeMapping", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAllShopeMappingByTenantId(Hashtable lstData)
        {
            string whereCondition = " where TenantId = @TenantId;";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewShopMapping", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAllShopeMappingByShopId(Hashtable lstData)
        {
            string whereCondition = " where ShopeId = @ShopId;";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewShopMapping", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetId(Hashtable lstData)
        {
            int Id = 0;
            string whereCondition = " where ShopeMapping.ShopeId = @ShopeId and ShopeMapping.TenantId = @TenantId";
            try
            {
                var strVal = ExecuteScaler("ShopeMapping", "Id", whereCondition, lstData);
                if (!string.IsNullOrEmpty(strVal))
                {
                    Id = int.Parse(strVal);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Id;
        }
	}
}
