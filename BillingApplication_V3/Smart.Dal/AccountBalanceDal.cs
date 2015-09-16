using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class AccountBalanceDal : Smart.Dal.Base.AccountBalanceDalBase
	{
		public AccountBalanceDal() : base()
		{
		}

        public DataTable GetAccountBalanceByTenantAndType(Hashtable lstData)
        {
            string whereCondition = " where AccountBalance.TenantId = @TenantId and VoucherTypeId = @VoucherTypeId And ReferenceType = @ReferenceType";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("AccountBalance", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
