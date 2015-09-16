using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingApplication;
using Smart.Bll;
using Smart.Bll.Base;
using Telerik.Web.UI;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data;

namespace BillingApplication
{
    public partial class UserInfo : System.Web.UI.Page
    {
        private static bool isNewEntry;
        private static Users _user;
        private static UserRole _role;
        private static bool _IsSuperUser;
       

          private bool IsValidSession()
        {
            if (Session["user"] == null)
            {
                return false;
            }

            _user = (Users)Session["user"];


            if (Session["SuperUser"] != null)
                _IsSuperUser = (bool)Session["SuperUser"];
            else
                _IsSuperUser = false;

            return _user.Id != 0;
        }
        private bool IsValidPageForUser()
        {
            int FunctionalId = new AppFunctionality().GetAppFunctionalityId("UserInfo");
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

        private void loadRoleListBox()
        {
            List<UserRole> roleList = new UserRole().GetAllUserRole(0);

            lbRole.DataSource = roleList;
            lbRole.DataTextField = "Role";
            lbRole.DataValueField = "Id";
            lbRole.DataBind();
        }


        private void LoadUserGrid()
        {
            try
            {
                
                List<Users> userList = new Users().GetAllUsersList();
                if (userList.Count == 0)
                    userList.Add(new Users());

                dgvUser.DataSource = userList;
                dgvUser.DataBind();
                
            }
            catch (Exception ex)
            {
                Alert.Show("Error in method 'LoadLeaveDetailsGrid'. Error: " + ex.Message);
            }


        }

        private void ClearControls()
        {
            lblId.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            isNewEntry = true;

            //_user = new Users();
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

                this.LoadUserGrid();
                this.loadRoleListBox();
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
                if (Regex.IsMatch(txtUserName.Text, @"^[a-zA-Z0-9_]{5,20}$") != true)
                {
                    Alert.Show("User name must be between 5 to 20 Characters Or Lowercase and Uppercase characters Or Alpha-Numeric And No Space And special character allowed");
                    txtUserName.Focus();
                    return;
                }
                int count = _user.CheckUserNameExistance((lblId.Text == string.Empty) ? 0 : int.Parse(lblId.Text), txtUserName.Text, isNewEntry);

                if (count > 0)
                {
                    Alert.Show("User name already exists. ");
                    return;
                }
                
                _user = new Users();
                _user.Id = (lblId.Text == string.Empty) ? 0 : int.Parse(lblId.Text);
                _user.UserName = txtUserName.Text;
                _user.UserPass = txtPassword.Text;
                _user.IsActive = (bool)chkIsActive.Checked;

                int success = 0;
                if (isNewEntry)
                {
                    success = _user.InsertUsers();
                    _user.Id = new Users().GetLastId(_user.CompanyId);
                }
                else
                    success = _user.UpdateUsers();

                if (success == 0)
                {

                    Alert.Show("Create user information was not successfull.");
                    return;
                }
                else
                {
                    //delete all roles from userrole mapping table
                    success = new UserRoleMapping().DeleteUserRoleMappingByUserId(_user.Id);
                    //get roles and update db
                    foreach (RadListBoxItem item in lbRole.CheckedItems)
                    {
                        if (item.Checked)
                        {
                            int roleId = int.Parse(item.Value);
                            UserRoleMapping role = new UserRoleMapping();

                            role.UserId = _user.Id;
                            role.RoleId = roleId;
                            role.CompanyId = _user.CompanyId;

                            role.InsertUserRoleMapping();
                        }
                    }

                    Alert.Show("User information created succssfully.");
                    this.ClearControls();
                    this.LoadUserGrid();
                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error during user information save. Error: " + ex.Message);
            }
        }

        protected void dgvUser_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "btnSelect")
            {
                GridDataItem item = (GridDataItem)e.Item;

                lblId.Text = item["colId"].Text;
                txtUserName.Text = item["colName"].Text.Trim();
                txtPassword.Text = (item["colPass"].Text == "&nbsp;") ? "" : item["colPass"].Text.Trim();

                isNewEntry = false;
            }
            else if (e.CommandName == "btnDelete")
            {
                try
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    lblId.Text = item["colId"].Text;
                    int id = int.Parse(lblId.Text);
                    Users userDelete = new Users();
                    int success = userDelete.DeleteUsersById(id);
                    if (success == 0)
                    {
                        Alert.Show("Something is going Wrong!!!!");
                    }
                    else
                    {
                        Alert.Show("Successfully Deleted!!");
                        this.LoadUserGrid();
                    }
                }
                catch (Exception ex)
                {
                    Alert.Show("Error happen during delete attendance data. Error: " + ex.Message);
                }
            }
        }

        protected void dgvUser_PageIndexChanged(object sender, GridPageChangedEventArgs e)
        {
            this.LoadUserGrid();
        }

        protected void dgvUser_PageSizeChanged(object sender, GridPageSizeChangedEventArgs e)
        {
            this.LoadUserGrid();
        }
        

      

        protected void rdropEmpName_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }

        protected void rdropEmpName_DataBound(object sender, EventArgs e)
        {
            var combo = (RadComboBox)sender;
            combo.Items.Insert(0, new RadComboBoxItem(" ", string.Empty));
        }

    }
}