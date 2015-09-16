using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Smart.Dal.Base
{
	public class CorporationsDalBase : SqlServerConnection
	{
		public DataTable GetAllCorporations()
		{
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Corporations", "*", "", null);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable GetAllCorporationsById(Hashtable lstData)
		{
			string whereCondition = " where Corporations.Id = @Id ";
			DataTable dt = new DataTable();
			try
			{
				dt = GetDataTable("Corporations", "*", whereCondition, lstData);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int InsertCorporations(Hashtable lstData)
		{
			string sqlQuery ="Insert into Corporations (CorpCode, CorpName, Address, ContactNo, ContactPerson, Designation, CPContactNo, Email, DiscountPcnt, PaymentMethodId, IsActive) values(@CorpCode, @CorpName, @Address, @ContactNo, @ContactPerson, @Designation, @CPContactNo, @Email, @DiscountPcnt, @PaymentMethodId, @IsActive);";
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

		public int UpdateCorporations(Hashtable lstData)
		{
			string sqlQuery = "Update Corporations set CorpName = @CorpName, Address = @Address, ContactNo = @ContactNo, ContactPerson = @ContactPerson, Designation = @Designation, CPContactNo = @CPContactNo, Email = @Email, DiscountPcnt = @DiscountPcnt, PaymentMethodId = @PaymentMethodId, IsActive = @IsActive where Corporations.CorpCode = @CorpCode;";
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

		public int DeleteCorporationsById(Hashtable lstData)
		{
			string sqlQuery = "delete from  Corporations where Id = @Id;";
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
