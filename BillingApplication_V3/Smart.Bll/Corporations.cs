using System;
using System.Collections.Generic;
using System.Text;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class Corporations : Smart.Bll.Base.CorporationsBase
	{
		private static Smart.Dal.CorporationsDal Dal = new Smart.Dal.CorporationsDal();
		public Corporations() : base()
		{
		}
	}
}
