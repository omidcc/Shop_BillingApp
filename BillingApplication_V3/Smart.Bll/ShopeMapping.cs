using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class ShopeMapping : Smart.Bll.Base.ShopeMappingBase
	{
		private static Smart.Dal.ShopeMappingDal Dal = new Smart.Dal.ShopeMappingDal();
		public ShopeMapping() : base()
		{
		}

        public DataTable GetShopeMappingByTenantId(Int64 _tenantId)
        {
            var lstItems = new Hashtable {{"@TenantId", _tenantId}};

            DataTable dt = dal.GetAllShopeMappingByTenantId(lstItems);

            return dt;
        }

        public ShopeMapping GetAllShopeMappingByShopId(Int64 _shopId)
        {
            var lstItems = new Hashtable { { "@ShopId", _shopId } };

            DataTable dt = dal.GetAllShopeMappingByShopId(lstItems);

            if (dt.Rows.Count > 0)
                return GetObject(dt.Rows[0]);
            else
                return new ShopeMapping();
        }

        public int GetId(Int64 _tenantId, Int64 _shopId)
        {
            var lstItems = new Hashtable { { "@TenantId", _tenantId }, { "@shopeId", _shopId } };

            return dal.GetId(lstItems);
        }
	}
}
