using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Users : Smart.Bll.Base.UsersBase
	{
        private static Smart.Dal.UsersDal Dal = new Smart.Dal.UsersDal();

	    public bool IsSuperUser { get; set; }

	    public Users() : base()
		{
		}

        public int CheckUserNameExistance(int _Id, string _UserName, bool isNewEntry)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@UserName", _UserName);

            if (!isNewEntry) lstItems.Add("@Id", _Id);

            return dal.CheckUserNameExistance(lstItems, isNewEntry);
        }

	    public int GetLastId(int companyId)
	    {
	        return dal.GetLastId(companyId);
	    }

	    public Users GetUserByUserName(string _userName)
	    {
            Hashtable lstItems = new Hashtable{{"@UserName", _userName}};
            
	        DataTable dt = dal.GetUserByUserName(lstItems);
	        if (dt.Rows.Count > 0)
	        {
	            DataRow row = dt.Rows[0];

	            return GetObject(row);
	        }
	        else
	        {
	            return new Users();
	        }
	    }
        public List<Users> GetAllUsersList()
        {
            Hashtable lstItems = new Hashtable();
            //lstItems.Add("@CompanyId", CompanyId);
            DataTable dt = dal.GetAllUsersList(lstItems);
            return (from DataRow dr in dt.Rows select GetObject(dr)).ToList();
        }
	}
}
