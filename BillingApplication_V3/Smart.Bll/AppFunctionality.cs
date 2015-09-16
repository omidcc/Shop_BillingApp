using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class AppFunctionality :  Smart.Bll.Base.AppFunctionalityBase
	{
		private static  Smart.Dal.AppFunctionalityDal Dal = new Smart.Dal.AppFunctionalityDal();
		public AppFunctionality() : base()
		{
		}
        public int GetAppFunctionalityId(string _Functionality)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Functionality", _Functionality);

            return dal.GetAppFunctionalityId(lstItems);
        }
	}
}
