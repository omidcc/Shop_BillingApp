using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class DueInstallment : Smart.Bll.Base.DueInstallmentBase
	{
		private static Smart.Dal.DueInstallmentDal Dal = new Smart.Dal.DueInstallmentDal();
		public DueInstallment() : base()
		{
		}


	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="_TenantId"></param>
	    /// <returns></returns>
	    public DueInstallment GetDueInstallmentByTenant(Int64 _TenantId)
	    {
	        Hashtable lstItems = new Hashtable();
	        lstItems.Add("@TenantId", _TenantId);

	        DataTable dt = dal.GetDueInstallmentByTenant(lstItems);
	        if (dt.Rows.Count > 0)
	        {
	            DataRow dr = dt.Rows[0];
	            return GetObject(dr);
	        }
            else 
                return new DueInstallment();
	    }
	}
}
