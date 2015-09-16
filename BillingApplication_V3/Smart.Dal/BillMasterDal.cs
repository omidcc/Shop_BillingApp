using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Text;
using Smart.Dal.Base;

namespace Smart.Dal
{
	public class BillMasterDal : Smart.Dal.Base.BillMasterDalBase
	{
		public BillMasterDal() : base()
		{

		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetLastId()
        {
            try
            {
                return GetMaximumID("BillMaster", "Id", 0, "");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetLastDue()
        {

            try
            {
                return GetMaximumID("BillMaster", "Id", 0, "");
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
        public int UpdateTotalAmount(Hashtable lstData)
        {
            string sqlQuery = "Update BillMaster set TotalAmount = @TotalAmount where BillMaster.Id = @Id;";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstData"></param>
        /// <returns></returns>
        public DataTable GetBillMasterDetailForGrid(Hashtable lstData, bool FilterMarketWise)
        {
            string whereCondition = " where BillMonth = @BillMonth and BillYear = @BillYear";
            
            if (FilterMarketWise) whereCondition = whereCondition + " and MarketId = @MarketId";
            
            try
            {
                DataTable dt = GetDataTable("vewBillDetails", "*", whereCondition, lstData);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public DataTable GetBillMasterDetailForGridWithCondition(Hashtable lstData, bool FilterMarketWise, string condition)
        {
            string whereCondition = " where BillMonth = @BillMonth and BillYear = @BillYear " + condition;

            if (FilterMarketWise) whereCondition = whereCondition + " and MarketId = @MarketId";

            try
            {
                DataTable dt = GetDataTable("vewBillDetails", "*", whereCondition, lstData);
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
        /// <param name="FilterMarketWise"></param>
        /// <returns></returns>
        public DataTable GetBillMasterDetailForSingleReport(Hashtable lstData)
        {
            string whereCondition = " where ID = @Id";

            try
            {
                DataTable dt = GetDataTable("vewBillDetails", "*", whereCondition, lstData);
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
        public DataTable GetBillMasterDetailForReport(Hashtable lstData)
        {
            string whereCondition = " where MarketId = @MarketId";

            try
            {
                DataTable dt = GetDataTable("vewBillDetails", "*", whereCondition, lstData);
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
        /// <returns></returns>
        public DataTable GetBillMasterDetailForReport()
        {
            try
            {
                DataTable dt = GetDataTable("vewBillDetails", "*", "");
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
        /// <param name="lstItems"></param>
        /// <returns></returns>
        public string GetBillIdByBillNo(Hashtable lstItems)
        {
            string whereCondition = " where BillNo = @BillNo";
            try
            {
                return ExecuteScaler("BillMaster", "Id", whereCondition, lstItems);
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
        //public DataTable GetYearlyReport(Hashtable lstData)
        //{
        //    string whereCondition = " where MarketId = @MarketId and TenantId = @TenantId and BillYear = @BillYear order by BillMonth";

        //    try
        //    {
        //        DataTable dt = GetDataTable("vewBillDetails", "*", whereCondition, lstData);
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}



        public int UpdatePaymentById(Hashtable lstData)
        {
            string queryString = "Update BillMaster set totalPayment = TotalAmount where Id= @Id";

            try
            {
                return ExecuteNonQuery(queryString, lstData);
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
        public DataTable GetYearlyReport(Hashtable lstData)
        {
            string fields = " B.ListValue as monthName, A.ShopNo, A.BillNo, A.MonthlyRent, A.ServiceCharge, A.MiscBills, A.ThisMonthTotal, " +
                            " A.PreviousDue, A.TotalAmount, A.LateFee, A.TotalAmountAfterLateFee, A.Payment, A.Due";

            string table =  "(SELECT ListId, ListValue FROM dbo.ListTable WHERE (ListType = 'MonthBangla' AND IsActive=1)) AS B " +
	                            " LEFT OUTER JOIN (SELECT ShopId, ShopNo, BillNo, MonthlyRent, ServiceCharge, MiscBills, ThisMonthTotal, " +
	                            " PreviousDue, TotalAmount, LateFee, TotalAmountAfterLateFee, Payment, Due, BillMonth, BillMonthId " +
                                " FROM dbo.vewBillDetails WHERE (BillYear = @BillYear) AND (TenantId = @TenantId)) AS A " +
	                            " ON B.ListId = A.BillMonthId";

            try
            {
                return GetDataTable(table, fields, "", lstData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
	    }
        
	}
}
