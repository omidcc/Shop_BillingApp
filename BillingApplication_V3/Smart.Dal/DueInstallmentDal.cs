using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class DueInstallmentDal : Smart.Dal.Base.DueInstallmentDalBase
	{
		public DueInstallmentDal() : base()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GetDueInstallmentByTenant(Hashtable lstData)
        {
            string whereCondition = " where DueInstallment.TenantId = @TenantId And DueAmount>0";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("DueInstallment", "Top 1 *", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
