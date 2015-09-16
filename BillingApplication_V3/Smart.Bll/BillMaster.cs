using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Smart.Bll.Base;
using System.Globalization;

namespace Smart.Bll
{
	public class BillMaster : Smart.Bll.Base.BillMasterBase
	{
		private static Smart.Dal.BillMasterDal Dal = new Smart.Dal.BillMasterDal();
		public BillMaster() : base()
		{
		}

	    public int GetLastId()
	    {
	        return dal.GetLastId();
	    }

	    public decimal GetLastDue()
	    {
	        return dal.GetLastId();
	    }

	    public Int32 UpdateTotalAmount(Int64 masterid, decimal totalAmount)
	    {
	        Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", masterid.ToString());
            lstItems.Add("@TotalAmount", totalAmount.ToString(CultureInfo.InvariantCulture));

	        return dal.UpdateTotalAmount(lstItems);
	    }

        public int CheckExistanceByBillNo(string _billNo)
	    {
            Hashtable lstItem=new Hashtable();
            lstItem.Add("@BillNo", _billNo);

	        string id = dal.GetBillIdByBillNo(lstItem);

            return (id == string.Empty) ? 0 : int.Parse(id);
	    }

	    public DataTable GetBillMasterDetailForGrid(int _billYear, string _billMonth, int _marketId)
	    {
            Hashtable lstItems=new Hashtable();
	        lstItems.Add("@BillYear", _billYear);
	        lstItems.Add("@BillMonth", _billMonth);

	        bool filterMarketWise = false;
	        if (_marketId > 0)
	        {
	            lstItems.Add("@MarketId", _marketId);
	            filterMarketWise = true;
	        }

	        return dal.GetBillMasterDetailForGrid(lstItems, filterMarketWise);
	    }

        public DataTable GetBillMasterDetailForGridWithCondition(int _billYear, string _billMonth, int _marketId, string _condition)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@BillYear", _billYear);
            lstItems.Add("@BillMonth", _billMonth);
            
            bool filterMarketWise = false;
            if (_marketId > 0)
            {
                lstItems.Add("@MarketId", _marketId);
                filterMarketWise = true;
            }

            return dal.GetBillMasterDetailForGridWithCondition(lstItems, filterMarketWise, _condition);
        }
        public DataTable GetBillMasterDetailForSingleReport(int _Id)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", _Id);

            return dal.GetBillMasterDetailForSingleReport(lstItems);
        }

        public DataTable GetBillMasterDetailForReport(int _MarketId)
        {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@MarketId", _MarketId);

            return dal.GetBillMasterDetailForReport(lstItems);
        }

        public DataTable GetBillMasterDetailForReport()
        {

            return dal.GetBillMasterDetailForReport();
        }

        public int UpdatePaymentById(Int64 _masterId, bool applyLateFee)
	    {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@Id", _masterId);
            int success = 0;

            if(applyLateFee)
                success = new BillDetail().UpdatePaymentWithLateFeeByMasterId(_masterId);
            else
                success = new BillDetail().UpdatePaymentWithoutLateFeeByMasterId(_masterId);

            if (success>0)
	            success = dal.UpdatePaymentById(lstItems);

            return success;
	    }

        public DataTable GetYearlyReport(int _BillYear, int _TenantId)
	    {
            Hashtable lstItems = new Hashtable();
            lstItems.Add("@BillYear", _BillYear);
            lstItems.Add("@TenantId", _TenantId);

            return dal.GetYearlyReport(lstItems);
	    }
	}
}
