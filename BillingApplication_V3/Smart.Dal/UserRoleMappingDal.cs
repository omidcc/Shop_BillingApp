using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class UserRoleMappingDal : Smart.Dal.Base.UserRoleMappingDalBase
	{
		public UserRoleMappingDal() : base()
		{
		}

        public int DeleteUserRoleMappingByUserId(Hashtable lstData)
        {
            string sqlQuery = "delete from  UserRoleMapping where UserId = @UserId;";
            try
            {
                int success = ExecuteNonQuery(sqlQuery, lstData);
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
            }
        }

        public DataTable GetUserRoleMappingByUserId(Hashtable lstData)
        {
            string whereCondition = " where UserRoleMapping.UserId = @UserId and CompanyId = @CompanyId";
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("UserRoleMapping", "*", whereCondition, lstData);
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
        public string GetRoleIdForUser(Hashtable lstData)
        {
            string whereCondition = " where UserRoleMapping.UserId = @UserId and CompanyId = @CompanyId";
            DataTable dt = new DataTable();
            try
            {
                return ExecuteScaler("UserRoleMapping", "RoleId", whereCondition, lstData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
