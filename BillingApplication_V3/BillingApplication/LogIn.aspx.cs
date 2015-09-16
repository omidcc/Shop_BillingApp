using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;
using Smart.Bll;
using Telerik.Web.UI.Gauge;

namespace BillingApplication
{
    public partial class LogIn : System.Web.UI.Page
    {
        private static string _refPage;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    _refPage = Request.QueryString["action"] != null
                                ? Request.QueryString["action"].ToString()
                                : string.Empty;

                    if (_refPage.ToLower() == "logout")
                    {
                        Session["user"] = null;
                      
                    }
                    else if (Session["user"] != null)
                    {
                        Users user = (Users) Session["user"];
                        if (user.Id != 0)
                            Response.Redirect("Default.aspx");
                    }
                }

                

            }
            catch (Exception ex)
            {
                Alert.Show("Error during page load. Error: "+ex.Message);
            }
        }

        

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {

                Users user = new Users();
                user = user.GetUserByUserName(txtUserName.Text);
                if (user.Id != 0)
                {
                    if(user.UserPass != txtPassword.Text)
                    {
                        Alert.Show("User and password didn't match. Please re-enter the correct password.");
                        txtPassword.Focus();
                        return;
                    }

                    Session["user"] = user;
                    UserRoleMapping userRoles = new UserRoleMapping().GetUserRoleMappingByUserId(user.Id, user.CompanyId);
                    if (userRoles.Id != 0 && user.Id == 1)
                        user.IsSuperUser = true;
                    else
                        user.IsSuperUser = false;

                    if (user.CompanyId == 0 && !user.IsSuperUser)
                    {
                        Alert.Show("Sorry this user is not associated with any company. Contact your system administrator to fix this issue.");
                        return;
                    }



                    Response.Redirect(((_refPage == string.Empty || _refPage.ToLower() == "logout") ? "Default.aspx" : _refPage), false);
                }
                else
                {
                    Alert.Show("The user is not exist in the database. Please check the username.");
                    txtUserName.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error during process user authentication. Error: "+ex.Message);
            }
        }

        


    }
}