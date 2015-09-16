using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingApplication;
using Smart.Bll;
using Telerik.Web.UI;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;

namespace hrms
{
    public partial class UserRoleInfo : System.Web.UI.Page
    {
        private static Users _user;
        private static bool isNewEntry;
        private static UserRole userRole;
        private static UserRole _role;
       
        private bool IsValidSession()
        {
            if (Session["user"] == null)
            {
                return false;
            }

            _user = (Users)Session["user"];

            return _user.Id != 0;

        }
        private bool IsValidPageForUser()
        {
            int FunctionalId = new AppFunctionality().GetAppFunctionalityId("UserRoleInfo");
            int RoleId = new UserRoleMapping().GetUserRoleMappingByUserId(_user.Id, _user.CompanyId).RoleId;
            AppPermission PermissionUser = new AppPermission().GetAppPermissionId(FunctionalId, _user.Id, RoleId, _user.CompanyId);

            if (!PermissionUser.IsView)
            {
                AppPermission Permission = new AppPermission().GetAppPermissionId(FunctionalId, _user.Id, RoleId, _user.CompanyId);
                return !Permission.IsView;
            }
            else
                return true;
        }
        private void LoadUserRoleGrid()
        {
            try
            {
                List<UserRole> roleList = new UserRole().GetAllUserRole(0);
                if (roleList.Count == 0)
                {
                    roleList.Add(new UserRole());
                    dgvUserRole.Visible = false;
                }
                else
                {
                    dgvUserRole.Visible = true;
                    dgvUserRole.DataSource = roleList;
                    dgvUserRole.DataBind();
                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error in method 'LoadLeaveDetailsGrid'. Error: " + ex.Message);
            }


        }

        private void ClearControls()
        {
            lblId.Text = "";
            txtRole.Text = "";
            txtDescription.Text = "";
            isNewEntry = true;

            userRole = new UserRole();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=default.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);

            }
            if (!IsValidPageForUser())
            {
                Alert.Show("Sorry, You Don't Have permission to access this page.");
                Response.Redirect("LogIn.aspx?refPage=default.aspx", false);
            }
            if (!IsPostBack)
            {
                
                ClearControls();
                this.LoadUserRoleGrid();
            }
        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearControls();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int count = userRole.CheckRoleExistance((lblId.Text == string.Empty) ? 0 : int.Parse(lblId.Text), txtRole.Text, isNewEntry);

                if (count > 0)
                {
                    Alert.Show("Company name already exists. ");
                    return;
                }

                userRole = new UserRole();
                userRole.CompanyId = 1;
                userRole.Id = (lblId.Text == string.Empty) ? 0 : int.Parse(lblId.Text);
                userRole.Role = txtRole.Text;
                userRole.Description = txtDescription.Text;

                int succes = 0;
                if (isNewEntry)
                {
                    succes = userRole.InsertUserRole();
                }
                else
                {
                    userRole.CompanyId = 1;
                    succes = userRole.UpdateUserRole();
                }
                if (succes == 0)
                {
                    Alert.Show("Create userRole information was not successfull.");
                    return;
                }
                else
                {
                    Alert.Show("UserRole information created succssfully.");
                    this.ClearControls();
                    this.LoadUserRoleGrid();
                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error during userRole information save. Error: " + ex.Message);
            }
        }


        protected void dgvUserRole_ItemCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "btnSelect")
            {
                GridDataItem item = (GridDataItem)e.Item;

                lblId.Text = item["colId"].Text;
                txtRole.Text = item["colRole"].Text.Trim();
                txtDescription.Text = (item["colDesc"].Text == "&nbsp;") ? "" : item["colDesc"].Text.Trim();
                
                isNewEntry = false;
            }
            else if (e.CommandName == "btnDelete")
            {
                try
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    lblId.Text = item["colId"].Text;
                    int id = int.Parse(lblId.Text);
                    UserRole userRolesDelete = new UserRole();
                    int success = userRolesDelete.DeleteUserRoleById(id);
                    if (success == 0)
                    {
                        Alert.Show("Something is going Wrong!!!!");
                    }
                    else
                    {
                        Alert.Show("Successfully Deleted!!");
                        this.LoadUserRoleGrid();
                    }
                }
                catch (Exception ex)
                {
                    Alert.Show("Error happen during delete attendance data. Error: " + ex.Message);
                }
            }
        }

        protected void dgvUserRole_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.LoadUserRoleGrid();
        }

        protected void dgvUserRole_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.LoadUserRoleGrid();
        }
 
   
    }
}