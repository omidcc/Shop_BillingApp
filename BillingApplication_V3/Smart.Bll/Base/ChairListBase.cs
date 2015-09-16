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
	public class ChairListBase
	{
		protected static Smart.Dal.ChairListDal dal = new Smart.Dal.ChairListDal();

		public System.Int64 Id		{ get ; set; }

		public System.String ChairCode		{ get ; set; }

		public System.Int64 IsReserved		{ get ; set; }


		public  Int32 InsertChairList()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ChairCode", ChairCode);
			lstItems.Add("@IsReserved", IsReserved.ToString(CultureInfo.InvariantCulture));

			return dal.InsertChairList(lstItems);
		}

		public  Int32 UpdateChairList()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ChairCode", ChairCode);
			lstItems.Add("@IsReserved", IsReserved.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateChairList(lstItems);
		}

		public  Int32 DeleteChairListById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteChairListById(lstItems);
		}

		public  DataTable GetAllChairList()
		{
			return dal.GetAllChairList();
		}

		public List<ChairList> ChairListSelectAll()
		{
			DataTable dt = new DataTable();
			List<ChairList> ChairListList = new List<ChairList>();
			foreach (DataRow dr in dt.Rows)
			{
				ChairListList.Add(GetObject(dr));
			}
			return ChairListList;
		}

		public  DataTable GetAllChairListById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllChairListById(lstItems);
		}

		public ChairList  GetChairListById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllChairListById(lstItems);
			ChairList objChairList = new ChairList();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static ChairList GetObject(DataRow dr)
		{

			ChairList objChairList = new ChairList
			{
				 Id = (Int64)dr["Id"],
				 ChairCode = (String)dr["ChairCode"],
				 IsReserved = (Int64)dr["IsReserved"],
			};

			return objChairList;
		}
	}
}
