using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class BillDetailDal : Smart.Dal.Base.BillDetailDalBase
	{
		public BillDetailDal() : base()
		{
		}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public string GetBillDetailIdByMasterId(Hashtable lstData)
        {
            string whereCondition = " where BillDetail.BillMasterId = @BillMasterId";
            try
            {
                return ExecuteScaler("BillDetail", "Id", whereCondition, lstData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstItems"></param>
        /// <returns></returns>
        public string GetLastDueTenantAndShopWise(Hashtable lstItems)
        {
            string whereCondition = " where ShopId=@ShopId and BillMasterId = (select max(Id) from BillMaster where TenantId=@TenantId)";
            try
            {
                return ExecuteScaler("BillDetail", "Due", whereCondition, lstItems);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstItems"></param>
        /// <returns></returns>
        public int CheckBillExistenceByTenant(Hashtable lstItems)
        {
            string whereCondition = " where ShopId=@ShopId and BillMasterId = (select max(Id) from BillMaster where TenantId=@TenantId)";
            try
            {
                return CheckExistence("BillDetail", "id", whereCondition, lstItems);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstItems"></param>
        /// <returns></returns>
        public int UpdatePaymentWithLateFeeByMasterId(Hashtable lstItems)
        {
            string queryString = "Update BillDetail Set Payment = TotalAmountAfterLateFee  where BillMasterId=@BillMasterId";
            try
            {
                return ExecuteNonQuery(queryString, lstItems);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstItems"></param>
        /// <returns></returns>
        public int UpdatePaymentWithoutLateFeeByMasterId(Hashtable lstItems)
        {
            string queryString = "Update BillDetail Set Payment = TotalAmount  where BillMasterId=@BillMasterId";
            try
            {
                return ExecuteNonQuery(queryString, lstItems);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
