using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.Bll;

namespace WebApp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected static string LoginId;
        private static Users _user;
        private List<AppFunctionality> functionalityList;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsValidSession()
        {
            if (Session["user"] == null)
            {
                return false;
            }

            _user = (Users)Session["user"];


            return _user.Id != 0;
        }
        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsValidSession()) return;

            if (!IsPostBack)
            {
                functionalityList = new AppFunctionality().GetAllAppFunctionality((_user.CompanyId == 0) ? 1 : _user.CompanyId);

                this.GenerateMenu("English");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lang"></param>
        private void GenerateMenu(string lang)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<ul>\n");
            int parentId = 0;
            bool parentUlOpen = false;
            List<AppPermission> permissionList = new AppPermission().GelAppFunctionalityForMenu(_user.CompanyId, _user.Id);
            List<AppModule> moduleList = new AppModule().GetAllAppModule(_user.CompanyId, _user.Id);

            foreach (AppModule module in moduleList)
            {
                List<AppPermission> modulePermission = permissionList.FindAll(x => x.ModuleName == module.Module);

                if (modulePermission.Count == 0) continue;

                if (modulePermission[0].IsView)
                {
                    foreach (AppPermission appPermission in modulePermission)
                    {

                        if (appPermission.Url == "#")
                        {
                            if (parentUlOpen)
                            {
                                str.Append("</ul>\n");
                                str.Append("</li>\n");
                            }

                            if (lang.ToLower() == "ar-sa")
                                str.Append("<li class='has-sub'><a href='#'><span>" + appPermission.FunctionalityNameArabic + "</span></a>\n");
                            else
                                str.Append("<li class='has-sub'><a href='#'><span>" + appPermission.FunctionalityName + "</span></a>\n");
                            str.Append("<ul>\n");

                            parentId = appPermission.FunctionalityId;
                            parentUlOpen = true;
                        }
                        else
                        {

                            if (appPermission.ParentId != parentId)
                            {
                                if (parentUlOpen)
                                {
                                    str.Append("</ul>\n");
                                    str.Append("</li>\n");
                                }

                                if (appPermission.ParentId == 0)
                                    parentUlOpen = false;
                            }


                            if (lang.ToLower() == "ar-sa")
                                str.Append("<li><a target=\"_self\" href=\"" + appPermission.Url + "\">" + appPermission.FunctionalityNameArabic + "</a> </li>\n");
                            else
                                str.Append("<li><a target=\"_self\" href=\"" + appPermission.Url + "\">" + appPermission.FunctionalityName + "</a> </li>\n");


                        }
                    }

                }
            }

            if (parentUlOpen)
            {
                str.Append("</ul>\n");
                str.Append("</li>\n");
            }

            str.Append("</ul>\n");

            Literal ltrl = (Literal)FindControl("ltrlMenu");
            ltrl.Text = str.ToString();
        }

    }
}