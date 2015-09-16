using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class UserRole : Smart.Bll.Base.UserRoleBase
	{
		private static Smart.Dal.UserRoleDal Dal = new Smart.Dal.UserRoleDal();
		public UserRole() : base()
		{
		}

        public int CheckRoleExistance(int _Id, string _Role, bool isNewEntry)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Role", _Role);

            if (!isNewEntry) lstItems.Add("@Id", _Id);

            return dal.CheckRoleExistance(lstItems, isNewEntry);
        }
	}
}
