using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class UserGroupBase
	{
		protected static Smart.Dal.UserGroupDal dal = new Smart.Dal.UserGroupDal();

		public System.Decimal GroupCode		{ get ; set; }

		public System.String GroupName		{ get ; set; }


		public  Int32 InsertUserGroup()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@GroupCode", GroupCode.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@GroupName", GroupName);

			return dal.InsertUserGroup(lstItems);
		}

		public  Int32 UpdateUserGroup()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@GroupCode", GroupCode.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@GroupName", GroupName);

			return dal.UpdateUserGroup(lstItems);
		}

		public  Int32 DeleteUserGroupByGroupCode(Decimal GroupCode)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@GroupCode", GroupCode);

			return dal.DeleteUserGroupByGroupCode(lstItems);
		}

		public  DataTable GetAllUserGroup()
		{
			return dal.GetAllUserGroup();
		}

		public List<UserGroup> UserGroupSelectAll()
		{
			DataTable dt = new DataTable();
			List<UserGroup> UserGroupList = new List<UserGroup>();
			foreach (DataRow dr in dt.Rows)
			{
				UserGroupList.Add(GetObject(dr));
			}
			return UserGroupList;
		}

		public  DataTable GetAllUserGroupByGroupCode(Decimal GroupCode)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@GroupCode", GroupCode);

			return dal.GetAllUserGroupByGroupCode(lstItems);
		}

		public UserGroup  GetUserGroupByGroupCode(Decimal GroupCode)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@GroupCode", GroupCode);

			DataTable dt = dal.GetAllUserGroupByGroupCode(lstItems);
			UserGroup objUserGroup = new UserGroup();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static UserGroup GetObject(DataRow dr)
		{

			UserGroup objUserGroup = new UserGroup
			{
				 GroupCode = (Decimal)dr["GroupCode"],
				 GroupName = (String)dr["GroupName"],
			};

			return objUserGroup;
		}
	}
}
