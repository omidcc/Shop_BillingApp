using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Dal.Base;

namespace Smart.Dal
{
    public class AppPermissionDal :  Smart.Dal.Base.AppPermissionDalBase
    {
        public AppPermissionDal()
            : base()
        {
        }

        public DataTable GetViewAllAppPermission(Hashtable lstData)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewFunctionalit", "*", "", lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GelAppFunctionalityForMenu(Hashtable lstData)
        {
            string whereCondition = " where UserId = @UserId and CompanyId = @CompanyId";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewAppFunctionalityMenu", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GelAppFunctionalityForMenuByRoleId(Hashtable lstData)
        {
            string whereCondition = " where RoleId = @RoleId  AND CompanyId = @CompanyId";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("vewAppFunctionalityMenu", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetAppPermissionId(Hashtable lstData)
        {
            string whereCondition = " where AppPermission.FunctionalityId = @FunctionalityId And (AppPermission.UserId=@UserId Or AppPermission.RoleId=@RoleId) And AppPermission.CompanyId=@CompanyId ";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("AppPermission", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
