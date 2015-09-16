using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class ApplicationSetupBase
	{
		protected static Smart.Dal.ApplicationSetupDal dal = new Smart.Dal.ApplicationSetupDal();

		public System.Int32 Id		{ get ; set; }

		public System.Boolean IsMultilanguage		{ get ; set; }

		public System.Boolean UseSingleSerailForEmplyoeeCode		{ get ; set; }


		public  Int32 InsertApplicationSetup()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@IsMultilanguage", IsMultilanguage);
			lstItems.Add("@UseSingleSerailForEmplyoeeCode", UseSingleSerailForEmplyoeeCode);

			return dal.InsertApplicationSetup(lstItems);
		}

		public  Int32 UpdateApplicationSetup()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@IsMultilanguage", IsMultilanguage);
			lstItems.Add("@UseSingleSerailForEmplyoeeCode", UseSingleSerailForEmplyoeeCode);

			return dal.UpdateApplicationSetup(lstItems);
		}

		public  Int32 DeleteApplicationSetupById(Int32 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteApplicationSetupById(lstItems);
		}

		public List<ApplicationSetup> GetAllApplicationSetup()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllApplicationSetup(lstItems);
			List<ApplicationSetup> ApplicationSetupList = new List<ApplicationSetup>();
			foreach (DataRow dr in dt.Rows)
			{
				ApplicationSetupList.Add(GetObject(dr));
			}
			return ApplicationSetupList;
		}

		public ApplicationSetup  GetApplicationSetupById(Int32 _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetApplicationSetupById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  ApplicationSetup GetObject(DataRow dr)
		{

			ApplicationSetup objApplicationSetup = new ApplicationSetup();
			objApplicationSetup.Id = (dr["Id"] == DBNull.Value) ? 0 : (Int32)dr["Id"];
			objApplicationSetup.IsMultilanguage = (dr["IsMultilanguage"] == DBNull.Value) ? false : (Boolean)dr["IsMultilanguage"];
			objApplicationSetup.UseSingleSerailForEmplyoeeCode = (dr["UseSingleSerailForEmplyoeeCode"] == DBNull.Value) ? false : (Boolean)dr["UseSingleSerailForEmplyoeeCode"];

			return objApplicationSetup;
		}
	}
}
