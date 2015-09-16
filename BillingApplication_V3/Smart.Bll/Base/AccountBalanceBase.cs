using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class AccountBalanceBase
	{
		protected static Smart.Dal.AccountBalanceDal dal = new Smart.Dal.AccountBalanceDal();

		public System.Decimal Id		{ get ; set; }

		public System.DateTime TransDate		{ get ; set; }

		public System.Int64 TenantId		{ get ; set; }

		public System.Int64 VoucherTypeId		{ get ; set; }

		public System.String VoucherNo		{ get ; set; }

		public System.Int32 AgainstVoucherTypeId		{ get ; set; }

		public System.Int64 AgainstVoucherNo		{ get ; set; }

		public System.String ReferenceType		{ get ; set; }

		public System.Decimal OpeningBalance		{ get ; set; }

		public System.Decimal Debit		{ get ; set; }

		public System.Decimal Credit		{ get ; set; }

		public System.Decimal ClosingBalance		{ get ; set; }

		public System.DateTime LastModified		{ get ; set; }

		public System.Int32 ModifiedBy		{ get ; set; }


		public  Int32 InsertAccountBalance()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@TransDate", TransDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TenantId", TenantId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@VoucherTypeId", VoucherTypeId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@VoucherNo", VoucherNo);
			lstItems.Add("@AgainstVoucherTypeId", AgainstVoucherTypeId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@AgainstVoucherNo", AgainstVoucherNo.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ReferenceType", ReferenceType);
			lstItems.Add("@OpeningBalance", OpeningBalance.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Debit", Debit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Credit", Credit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ClosingBalance", ClosingBalance.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LastModified", LastModified.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ModifiedBy", ModifiedBy.ToString(CultureInfo.InvariantCulture));

			return dal.InsertAccountBalance(lstItems);
		}

		public  Int32 UpdateAccountBalance()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id.ToString());
			lstItems.Add("@TransDate", TransDate.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@TenantId", TenantId.ToString());
			lstItems.Add("@VoucherTypeId", VoucherTypeId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@VoucherNo", VoucherNo);
			lstItems.Add("@AgainstVoucherTypeId", AgainstVoucherTypeId.ToString());
			lstItems.Add("@AgainstVoucherNo", AgainstVoucherNo.ToString());
			lstItems.Add("@ReferenceType", ReferenceType);
			lstItems.Add("@OpeningBalance", OpeningBalance.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Debit", Debit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Credit", Credit.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ClosingBalance", ClosingBalance.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@LastModified", LastModified.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ModifiedBy", ModifiedBy.ToString());

			return dal.UpdateAccountBalance(lstItems);
		}

		public  Int32 DeleteAccountBalanceById(Decimal Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteAccountBalanceById(lstItems);
		}

		public List<AccountBalance> GetAllAccountBalance()
		{
			Hashtable lstItems = new Hashtable();
			DataTable dt = dal.GetAllAccountBalance(lstItems);
			List<AccountBalance> AccountBalanceList = new List<AccountBalance>();
			foreach (DataRow dr in dt.Rows)
			{
				AccountBalanceList.Add(GetObject(dr));
			}
			return AccountBalanceList;
		}

		public AccountBalance  GetAccountBalanceById(Decimal _Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", _Id);

			DataTable dt = dal.GetAccountBalanceById(lstItems);
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		protected  AccountBalance GetObject(DataRow dr)
		{

			AccountBalance objAccountBalance = new AccountBalance();
			objAccountBalance.Id = (dr["Id"] == DBNull.Value) ? 0 : (Decimal)dr["Id"];
			objAccountBalance.TransDate = (dr["TransDate"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["TransDate"];
			objAccountBalance.TenantId = (dr["TenantId"] == DBNull.Value) ? 0 : (Int64)dr["TenantId"];
			objAccountBalance.VoucherTypeId = (dr["VoucherTypeId"] == DBNull.Value) ? 0 : Int64.Parse(dr["VoucherTypeId"].ToString());
			objAccountBalance.VoucherNo = (dr["VoucherNo"] == DBNull.Value) ? "" : (String)dr["VoucherNo"];
			objAccountBalance.AgainstVoucherTypeId = (dr["AgainstVoucherTypeId"] == DBNull.Value) ? 0 : (Int32)dr["AgainstVoucherTypeId"];
			objAccountBalance.AgainstVoucherNo = (dr["AgainstVoucherNo"] == DBNull.Value) ? 0 : (Int64)dr["AgainstVoucherNo"];
			objAccountBalance.ReferenceType = (dr["ReferenceType"] == DBNull.Value) ? "" : (String)dr["ReferenceType"];
			objAccountBalance.OpeningBalance = (dr["OpeningBalance"] == DBNull.Value) ? 0 : (Decimal)dr["OpeningBalance"];
			objAccountBalance.Debit = (dr["Debit"] == DBNull.Value) ? 0 : (Decimal)dr["Debit"];
			objAccountBalance.Credit = (dr["Credit"] == DBNull.Value) ? 0 : (Decimal)dr["Credit"];
			objAccountBalance.ClosingBalance = (dr["ClosingBalance"] == DBNull.Value) ? 0 : (Decimal)dr["ClosingBalance"];
			objAccountBalance.LastModified = (dr["LastModified"] == DBNull.Value) ? DateTime.MinValue : (DateTime)dr["LastModified"];
			objAccountBalance.ModifiedBy = (dr["ModifiedBy"] == DBNull.Value) ? 0 : (Int32)dr["ModifiedBy"];

			return objAccountBalance;
		}
	}
}
