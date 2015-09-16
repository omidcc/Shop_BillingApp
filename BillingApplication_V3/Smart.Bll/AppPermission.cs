using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Smart.Bll.Base;

namespace Smart.Bll
{
    public class AppPermission :  Smart.Bll.Base.AppPermissionBase
    {
        private static  Smart.Dal.AppPermissionDal Dal = new Smart.Dal.AppPermissionDal();

        public string FunctionalityName { get; set; }
        public string ModuleName { get; set; }
        public string Url { get; set; }
        public int ParentId { get; set; }
        public string FunctionalityNameArabic{get;set;}

        public AppPermission()
            : base()
        {
        }

        public List<AppPermission> GetViewAllAppPermission(int CompanyId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@CompanyId", CompanyId);
            DataTable dt = dal.GetViewAllAppPermission(lstItems);
            List<AppPermission> AppPermissionList = new List<AppPermission>();
            foreach (DataRow dr in dt.Rows)
            {
                AppPermission appPermission = GetObject(dr);

                appPermission.FunctionalityName = (dr["Functionality"] == DBNull.Value) ? "" : (String)dr["Functionality"];
                
                AppPermissionList.Add(appPermission);
            }
            return AppPermissionList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_companyId"></param>
        /// <param name="_userId"></param>
        /// <returns></returns>
        public List<AppPermission> GelAppFunctionalityForMenu(int _companyId, int _userId)
        {
            List<AppPermission> AppPermissionList = new List<AppPermission>();

            Hashtable lstItems = new Hashtable();
            lstItems.Add("@CompanyId", _companyId);
            lstItems.Add("@UserId", _userId);

            DataTable dt = dal.GelAppFunctionalityForMenu(lstItems);

            if (dt.Rows.Count == 0)
            {
                int roleId = new UserRoleMapping().GetRoleIdForUser(_userId, _companyId);
                if (roleId > 0)
                {
                    lstItems = new Hashtable();
                    lstItems.Add("@CompanyId", _companyId);
                    lstItems.Add("@RoleId", roleId);

                    dt = dal.GelAppFunctionalityForMenuByRoleId(lstItems);
                }
            }
            
            foreach (DataRow dr in dt.Rows)
            {
                AppPermission appPermission = GetObject(dr);

                appPermission.FunctionalityName = (dr["Functionality"] == DBNull.Value) ? "" : (String)dr["Functionality"];
                appPermission.FunctionalityNameArabic = (dr["FunctionalityArabic"] == DBNull.Value) ? "" : (String)dr["FunctionalityArabic"];
                appPermission.ModuleName = (dr["Module"] == DBNull.Value) ? "" : (String)dr["Module"];
                appPermission.Url = (dr["Url"] == DBNull.Value) ? "" : (String)dr["Url"];
                appPermission.ParentId = (dr["ParentId"] == DBNull.Value) ? 0 : (int)dr["ParentId"];

                AppPermissionList.Add(appPermission);
            }
            return AppPermissionList;
        }

        public AppPermission GetAppPermissionId(int _FunctionalityId, int _UserId, int _RoleId, int _CompanyId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@FunctionalityId", _FunctionalityId);
            lstItems.Add("@UserId", _UserId);
            lstItems.Add("@RoleId", _RoleId);
            lstItems.Add("@CompanyId", _CompanyId);

            DataTable dt = dal.GetAppPermissionId(lstItems);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return GetObject(dr);
            }
            else
                return new AppPermission();
        }
    }
}
