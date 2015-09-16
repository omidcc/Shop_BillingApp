using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class AccountBalanceDalBase : SqlServerConnection
	{
		public DataTable GetAllAccountBalance(Hashtable lstData)
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("AccountBalance", "*", "", lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAccountBalanceById(Hashtable lstData)
		{
			string whereCondition = " where AccountBalance.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("AccountBalance", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertAccountBalance(Hashtable lstData)
		{
			string sqlQuery ="Insert into AccountBalance (TransDate, TenantId, VoucherTypeId, VoucherNo, AgainstVoucherTypeId, AgainstVoucherNo, ReferenceType, OpeningBalance, Debit, Credit, ClosingBalance, LastModified, ModifiedBy) values(@TransDate, @TenantId, @VoucherTypeId, @VoucherNo, @AgainstVoucherTypeId, @AgainstVoucherNo, @ReferenceType, @OpeningBalance, @Debit, @Credit, @ClosingBalance, @LastModified, @ModifiedBy);";
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

		public int UpdateAccountBalance(Hashtable lstData)
		{
			string sqlQuery = "Update AccountBalance set TransDate = @TransDate, TenantId = @TenantId, VoucherTypeId = @VoucherTypeId, VoucherNo = @VoucherNo, AgainstVoucherTypeId = @AgainstVoucherTypeId, AgainstVoucherNo = @AgainstVoucherNo, ReferenceType = @ReferenceType, OpeningBalance = @OpeningBalance, Debit = @Debit, Credit = @Credit, ClosingBalance = @ClosingBalance, LastModified = @LastModified, ModifiedBy = @ModifiedBy where AccountBalance.Id = @Id;";
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

		public int DeleteAccountBalanceById(Hashtable lstData)
		{
			string sqlQuery = "delete from  AccountBalance where Id = @Id;";
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
	}
}
