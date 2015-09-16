using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class ShopCategory : Smart.Bll.Base.ShopCategoryBase
	{
		private static Smart.Dal.ShopCategoryDal Dal = new Smart.Dal.ShopCategoryDal();
		public ShopCategory() : base()
		{
		}
	}
}
