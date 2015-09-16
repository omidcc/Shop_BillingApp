using System;
using System.Text;
using System.Data;
using System.Collections;
using Smart.Bll.Base;

namespace Smart.Bll
{
	public class AppModule :  Smart.Bll.Base.AppModuleBase
	{
		private static  Smart.Dal.AppModuleDal Dal = new Smart.Dal.AppModuleDal();
		public AppModule() : base()
		{
		}
	}
}
