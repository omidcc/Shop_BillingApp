using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class AppFunctionalityDal :  Smart.Dal.Base.AppFunctionalityDalBase
	{
		public AppFunctionalityDal() : base()
		{
		}
        public int GetAppFunctionalityId(Hashtable lstData)
        {
            string whereCondition = " where AppFunctionality.Functionality = @Functionality";
            DataTable dt = new DataTable();
            try
            {
                string FunctionId = ExecuteScaler("AppFunctionality", "Id", whereCondition, lstData);
                if (FunctionId == "")
                {
                    return 0;
                }
                else
                    return int.Parse(FunctionId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
	}
}
