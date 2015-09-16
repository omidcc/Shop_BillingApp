using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class UserRoleDal : Smart.Dal.Base.UserRoleDalBase
	{
		public UserRoleDal() : base()
		{
		}

        public int CheckRoleExistance(Hashtable lstData, bool isNewEntry)
        {

            string whereCondition = string.Empty;

            if (isNewEntry)
                whereCondition = " where UserRole.Role = @Role";
            else
                whereCondition = "where UserRole.Role = @Role And UserRole.Id <> @Id";

            int count = 0;
            try
            {
                count = CheckExistence("UserRole", "Id", whereCondition, lstData);
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int DeleteUserRoleById(Hashtable lstData)
        {
            
            try
            {
                int success = ExecuteStoreProcedure("DeleteUserRole", lstData);
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
