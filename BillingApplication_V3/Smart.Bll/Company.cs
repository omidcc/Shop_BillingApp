using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Company : Smart.Bll.Base.CompanyBase
	{
		private static Smart.Dal.CompanyDal Dal = new Smart.Dal.CompanyDal();
		public Company() : base()
		{
		}

        public DataTable GetCompanyDatatableById(int _Id)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", _Id);

            return  dal.GetCompanyById(lstItems);
        }
	}
}
