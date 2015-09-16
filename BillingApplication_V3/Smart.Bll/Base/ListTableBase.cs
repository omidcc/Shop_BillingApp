using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Collections;
using Smart.Dal;

namespace Smart.Bll.Base
{
	public class ListTableBase
	{
		protected static Smart.Dal.ListTableDal dal = new Smart.Dal.ListTableDal();

		public System.Int64 Slno		{ get ; set; }

		public System.String ListName		{ get ; set; }

		public System.Int32 ListItemId		{ get ; set; }

		public System.String ListItemValue		{ get ; set; }

		public System.String ListDescription		{ get ; set; }

		public System.Boolean ShowDesc		{ get ; set; }


		public  Int32 InsertListTable()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ListName", ListName);
			lstItems.Add("@ListItemId", ListItemId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ListItemValue", ListItemValue);
			lstItems.Add("@ListDescription", ListDescription);
			lstItems.Add("@ShowDesc", ShowDesc);

			return dal.InsertListTable(lstItems);
		}

		public  Int32 UpdateListTable()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ListName", ListName);
			lstItems.Add("@ListItemId", ListItemId.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@ListItemValue", ListItemValue);
			lstItems.Add("@ListDescription", ListDescription);
			lstItems.Add("@ShowDesc", ShowDesc);

			return dal.UpdateListTable(lstItems);
		}

		public  Int32 DeleteListTableBySlno(Int64 Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			return dal.DeleteListTableBySlno(lstItems);
		}

		public  DataTable GetAllListTable()
		{
			return dal.GetAllListTable();
		}

		public List<ListTable> ListTableSelectAll()
		{
			DataTable dt = new DataTable();
			List<ListTable> ListTableList = new List<ListTable>();
			foreach (DataRow dr in dt.Rows)
			{
				ListTableList.Add(GetObject(dr));
			}
			return ListTableList;
		}

		public  DataTable GetAllListTableBySlno(Int64 Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			return dal.GetAllListTableBySlno(lstItems);
		}

		public ListTable  GetListTableBySlno(Int64 Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			DataTable dt = dal.GetAllListTableBySlno(lstItems);
			ListTable objListTable = new ListTable();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static ListTable GetObject(DataRow dr)
		{

			ListTable objListTable = new ListTable
			{
				 Slno = (Int64)dr["Slno"],
				 ListName = (String)dr["ListName"],
				 ListItemId = (Int32)dr["ListItemId"],
				 ListItemValue = (String)dr["ListItemValue"],
				 ListDescription = (String)dr["ListDescription"],
				 ShowDesc = (Boolean)dr["ShowDesc"],
			};

			return objListTable;
		}
	}
}
