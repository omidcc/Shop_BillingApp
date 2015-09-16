using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class UsersDal : Smart.Dal.Base.UsersDalBase
	{
		public UsersDal() : base()
		{
		}



        public int CheckUserNameExistance(Hashtable lstData, bool isNewEntry)
        {

            string whereCondition = string.Empty;

            if (isNewEntry)
                whereCondition = " where Users.UserName = @UserName";
            else
                whereCondition = "where Users.UserName = @UserName And Users.Id <> @Id";

            int count = 0;
            try
            {
                count = CheckExistence("Users", "Id", whereCondition, lstData);
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public int GetLastId(int companyId)
        {

            string whereCondition = " Where CompanyId = '" + companyId + "'";

            try
            {
                return GetMaximumID("Users", "Id",0, whereCondition);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable GetUserByUserName(Hashtable lstData)
        {

            string whereCondition = " where Users.UserName = @UserName and isActive = 1";

            try
            {
                return GetDataTable("Users", "*", whereCondition, lstData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable GetAllUsersList(Hashtable lstData)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = GetDataTable("Users", "*", " Where Users.IsActive = 1;", lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int DeleteUsersById(Hashtable lstData)
        {
           
            try
            {
                int success = ExecuteStoreProcedure("DeleteUser", lstData);
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
	}
}
