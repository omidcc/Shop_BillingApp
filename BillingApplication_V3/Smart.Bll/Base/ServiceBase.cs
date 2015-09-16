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
	public class ServiceBase
	{
		protected static Smart.Dal.ServiceDal dal = new Smart.Dal.ServiceDal();

		public System.Int64 Id		{ get ; set; }

		public System.String ServiceCode		{ get ; set; }

		public System.String ServiceName		{ get ; set; }

		public System.Decimal Price		{ get ; set; }

		public System.Decimal Cost		{ get ; set; }

		public System.Decimal MinAdvance		{ get ; set; }


		public  Int32 InsertService()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ServiceCode", ServiceCode);
			lstItems.Add("@ServiceName", ServiceName);
			lstItems.Add("@Price", Price.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Cost", Cost.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MinAdvance", MinAdvance.ToString(CultureInfo.InvariantCulture));

			return dal.InsertService(lstItems);
		}

		public  Int32 UpdateService()
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@ServiceCode", ServiceCode);
			lstItems.Add("@ServiceName", ServiceName);
			lstItems.Add("@Price", Price.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@Cost", Cost.ToString(CultureInfo.InvariantCulture));
			lstItems.Add("@MinAdvance", MinAdvance.ToString(CultureInfo.InvariantCulture));

			return dal.UpdateService(lstItems);
		}

		public  Int32 DeleteServiceById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.DeleteServiceById(lstItems);
		}

		public  DataTable GetAllService()
		{
			return dal.GetAllService();
		}

		public List<Service> ServiceSelectAll()
		{
			DataTable dt = new DataTable();
			List<Service> ServiceList = new List<Service>();
			foreach (DataRow dr in dt.Rows)
			{
				ServiceList.Add(GetObject(dr));
			}
			return ServiceList;
		}

		public  DataTable GetAllServiceById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			return dal.GetAllServiceById(lstItems);
		}

		public Service  GetServiceById(Int64 Id)
		{
			Hashtable lstItems = new Hashtable();
			lstItems.Add("@Id", Id);

			DataTable dt = dal.GetAllServiceById(lstItems);
			Service objService = new Service();
			DataRow dr = dt.Rows[0];
			return GetObject(dr);
		}

		private static Service GetObject(DataRow dr)
		{

			Service objService = new Service
			{
				 Id = (Int64)dr["Id"],
				 ServiceCode = (String)dr["ServiceCode"],
				 ServiceName = (String)dr["ServiceName"],
				 Price = (Decimal)dr["Price"],
				 Cost = (Decimal)dr["Cost"],
				 MinAdvance = (Decimal)dr["MinAdvance"],
			};

			return objService;
		}
	}
}
