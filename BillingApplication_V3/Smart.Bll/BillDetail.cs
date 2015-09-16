using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class BillDetail : Smart.Bll.Base.BillDetailBase
	{
		private static Smart.Dal.BillDetailDal Dal = new Smart.Dal.BillDetailDal();
		public BillDetail() : base()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_masterId"></param>
        /// <returns></returns>
        public int GetBillDetailIdByMasterId(Int64 _masterId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@BillMasterId", _masterId);

            string masterId = dal.GetBillDetailIdByMasterId(lstItems);
            return (masterId == string.Empty) ? 0 : int.Parse(masterId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tenantId"></param>
        /// <param name="_shopId"></param>
        /// <returns></returns>
        public decimal CheckBillExistenceByTenant(Int64 _tenantId, int _shopId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@TenantId", _tenantId);
            lstItems.Add("@ShopId", _shopId);

            try
            {

                return dal.CheckBillExistenceByTenant(lstItems);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_tenantId"></param>
        /// <param name="_shopId"></param>
        /// <returns></returns>
        public decimal GetLastDueTenantAndShopWise(Int64 _tenantId, int _shopId)
        {
            Hashtable lstItems=new Hashtable();
            lstItems.Add("@TenantId",_tenantId);
            lstItems.Add("@ShopId", _shopId);
 
            try
            {
                string val = dal.GetLastDueTenantAndShopWise(lstItems);
                
                return (val == string.Empty)?0:decimal.Parse(val);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_BillMasterId"></param>
        /// <returns></returns>
        public int UpdatePaymentWithLateFeeByMasterId(Int64 _BillMasterId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@BillMasterId", _BillMasterId);

            try
            {
                return dal.UpdatePaymentWithLateFeeByMasterId(lstItems);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_BillMasterId"></param>
        /// <returns></returns>
        public int UpdatePaymentWithoutLateFeeByMasterId(Int64 _BillMasterId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@BillMasterId", _BillMasterId);

            try
            {
                return dal.UpdatePaymentWithoutLateFeeByMasterId(lstItems);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
