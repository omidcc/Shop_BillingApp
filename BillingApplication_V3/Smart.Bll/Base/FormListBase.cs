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
	public class FormListBase
	{
		protected static Smart.Dal.FormListDal dal = new Smart.Dal.FormListDal();

		public System.Decimal Slno		{ get ; set; }

		public System.String FormName		{ get ; set; }


		public  Int32 InsertFormList()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@FormName", FormName);

			return dal.InsertFormList(lstItems);
		}

		public  Int32 UpdateFormList()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@FormName", FormName);

			return dal.UpdateFormList(lstItems);
		}

		public  Int32 DeleteFormListBySlno(Decimal Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			return dal.DeleteFormListBySlno(lstItems);
		}

		public  DataTable GetAllFormList()
		{
			return dal.GetAllFormList();
		}

		public List<FormList> FormListSelectAll()
		{
			DataTable dt = new DataTable();
			List<FormList> FormListList = new List<FormList>();
			foreach (DataRow dr in dt.Rows)
			{
				FormListList.Add(GetObject(dr));
			}
			return FormListList;
		}

		public  DataTable GetAllFormListBySlno(Decimal Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			return dal.GetAllFormListBySlno(lstItems);
		}

		public FormList  GetFormListBySlno(Decimal Slno)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Slno", Slno);

			DataTable dt = dal.GetAllFormListBySlno(lstItems);
			FormList objFormList = new FormList();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static FormList GetObject(DataRow dr)
		{

			FormList objFormList = new FormList
			{
				 Slno = (Decimal)dr["Slno"],
				 FormName = (String)dr["FormName"],
			};

			return objFormList;
		}
	}
}
