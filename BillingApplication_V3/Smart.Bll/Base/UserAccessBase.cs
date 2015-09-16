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
	public class UserAccessBase
	{
		protected static Smart.Dal.UserAccessDal dal = new Smart.Dal.UserAccessDal();

		public System.Decimal Slno		{ get ; set; }

		public System.Decimal UserID		{ get ; set; }

		public System.Decimal GroupCode		{ get ; set; }

		public System.Decimal FormID		{ get ; set; }

		public System.Boolean canOpen		{ get ; set; }

		public System.Boolean canSave		{ get ; set; }

		public System.Boolean canUpdate		{ get ; set; }

		public System.Boolean canDelete		{ get ; set; }

		public System.Boolean canPrint		{ get ; set; }


		public  Int32 InsertUserAccess()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UserID", UserID.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@GroupCode", GroupCode.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@FormID", FormID.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@canOpen", canOpen);
			lstItems.Add("@canSave", canSave);
			lstItems.Add("@canUpdate", canUpdate);
			lstItems.Add("@canDelete", canDelete);
			lstItems.Add("@canPrint", canPrint);

			return dal.InsertUserAccess(lstItems);
		}

		public  Int32 UpdateUserAccess()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@UserID", UserID.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@GroupCode", GroupCode.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@FormID", FormID.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@canOpen", canOpen);
			lstItems.Add("@canSave", canSave);
			lstItems.Add("@canUpdate", canUpdate);
			lstItems.Add("@canDelete", canDelete);
			lstItems.Add("@canPrint", canPrint);

			return dal.UpdateUserAccess(lstItems);
		}

		public  Int32 DeleteUserAccessBySlno(Decimal Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			return dal.DeleteUserAccessBySlno(lstItems);
		}

		public  DataTable GetAllUserAccess()
		{
			return dal.GetAllUserAccess();
		}

		public List<UserAccess> UserAccessSelectAll()
		{
			DataTable dt = new DataTable();
			List<UserAccess> UserAccessList = new List<UserAccess>();
			foreach (DataRow dr in dt.Rows)
			{
				UserAccessList.Add(GetObject(dr));
			}
			return UserAccessList;
		}

		public  DataTable GetAllUserAccessBySlno(Decimal Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			return dal.GetAllUserAccessBySlno(lstItems);
		}

		public UserAccess  GetUserAccessBySlno(Decimal Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			DataTable dt = dal.GetAllUserAccessBySlno(lstItems);
			UserAccess objUserAccess = new UserAccess();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static UserAccess GetObject(DataRow dr)
		{

			UserAccess objUserAccess = new UserAccess
			{
				 Slno = (Decimal)dr["Slno"],
				 UserID = (Decimal)dr["UserID"],
				 GroupCode = (Decimal)dr["GroupCode"],
				 FormID = (Decimal)dr["FormID"],
				 canOpen = (Boolean)dr["canOpen"],
				 canSave = (Boolean)dr["canSave"],
				 canUpdate = (Boolean)dr["canUpdate"],
				 canDelete = (Boolean)dr["canDelete"],
				 canPrint = (Boolean)dr["canPrint"],
			};

			return objUserAccess;
		}
	}
}
