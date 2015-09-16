using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class AccountBalance : Smart.Bll.Base.AccountBalanceBase
	{
		private static Smart.Dal.AccountBalanceDal Dal = new Smart.Dal.AccountBalanceDal();
		public AccountBalance() : base()
		{
		}

	    public AccountBalance GetAccountBalanceByTenantAndType(Int64 _tenantId, Int64 _voucherTypeId, string _refType)
	    {
	        Hashtable lstItems = new Hashtable();
	        lstItems.Add("@TenantId", _tenantId);
	        lstItems.Add("@VoucherTypeId", _voucherTypeId);
	        lstItems.Add("@ReferenceType", _refType);

	        DataTable dt = dal.GetAccountBalanceByTenantAndType(lstItems);
	        if (dt.Rows.Count > 0)
	        {
	            DataRow row = dt.Rows[0];
	            return GetObject(row);
	        }
	        else
	        {
	             return new AccountBalance();
	        }
	    }
	}
}
