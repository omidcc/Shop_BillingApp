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
	public class UserBase
	{
		protected static Smart.Dal.UserDal dal = new Smart.Dal.UserDal();

		public System.Int32 UserID		{ get ; set; }

		public System.String UserName		{ get ; set; }

		public System.String Password		{ get ; set; }

		public System.Int32 GroupCode		{ get ; set; }

		public System.Boolean IsActive		{ get ; set; }


		public  Int32 InsertUser()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@UserID", UserID.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UserName", UserName);
			lstItems.Add("@Password", Password);
			lstItems.Add("@GroupCode", GroupCode.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);

			return dal.InsertUser(lstItems);
		}

		public  Int32 UpdateUser()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@UserID", UserID.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UserName", UserName);
			lstItems.Add("@Password", Password);
			lstItems.Add("@GroupCode", GroupCode.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@IsActive", IsActive);

			return dal.UpdateUser(lstItems);
		}

		public  Int32 DeleteUserByUserID(Int32 UserID)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@UserID", UserID);

			return dal.DeleteUserByUserID(lstItems);
		}

		public  DataTable GetAllUser()
		{
			return dal.GetAllUser();
		}

		public List<User> UserSelectAll()
		{
			DataTable dt = new DataTable();
			List<User> UserList = new List<User>();
			foreach (DataRow dr in dt.Rows)
			{
				UserList.Add(GetObject(dr));
			}
			return UserList;
		}

		public  DataTable GetAllUserByUserID(Int32 UserID)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@UserID", UserID);

			return dal.GetAllUserByUserID(lstItems);
		}

		public User  GetUserByUserID(Int32 UserID)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@UserID", UserID);

			DataTable dt = dal.GetAllUserByUserID(lstItems);
			User objUser = new User();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static User GetObject(DataRow dr)
		{

			User objUser = new User
			{
				 UserID = (Int32)dr["UserID"],
				 UserName = (String)dr["UserName"],
				 Password = (String)dr["Password"],
				 GroupCode = (Int32)dr["GroupCode"],
				 IsActive = (Boolean)dr["IsActive"],
			};

			return objUser;
		}
	}
}
