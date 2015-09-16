using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class TenantDal : Smart.Dal.Base.TenantDalBase
	{
		public TenantDal() : base()
		{
		}

        public DataTable GetAllTenantWithDetail(Hashtable lstData)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewTenantDetails", "*", " Where shopeId = @ShopId and Id = @Id ;", lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
	    public int GetMaxTenantId()
	    {
	        return GetMaximumID("Tenant", "Id", 1, "");
	    }

        public string GetNextTenantId(Hashtable lstData)
        {
            string conditionString = " where Id > @Id";
            return ExecuteScaler("Tenant", "min(Id)", conditionString, lstData);
        }

        public string GetPreviousTenantId(Hashtable lstData)
        {
            string conditionString = " where Id < @Id";

            return ExecuteScaler("Tenant", "max(Id)", conditionString, lstData);

        }

        public DataTable GetTenantByMarketId(Hashtable lstData)
        {
            string whereCondition = " where (MarketId = @MarketId and isnull(IsContractClosed,0) = 0)";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewTenantDetails", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GetTenantWithDue(Hashtable lstData)
        {
            string whereCondition = " where (MarketId = @MarketId and OutstandingAmount>0);";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewTenantDetails", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAllTenant(Hashtable lstData)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewTenantDetails", "*", "", lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable SearchTenantByName(string tenantName)
        {
            string whereCondition = " where Tenant.TenantName like N'%" + tenantName + "%'";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("Tenant", "*", whereCondition);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


       
	}
}
