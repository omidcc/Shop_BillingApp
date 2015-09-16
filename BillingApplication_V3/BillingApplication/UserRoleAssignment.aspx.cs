using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.Bll;
using Smart.Bll.Base;
using System.Data;
using System.IO;
using Telerik.Web.UI;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.Reflection;
namespace BillingApplication
{
    public partial class UserRoleAssignment : System.Web.UI.Page
    {
        private static Users _user;
        private static bool _isNewEntry;
        private static UserRole _role;
        private static ResourceManager rm;
        
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
            int FunctionalId = new AppFunctionality().GetAppFunctionalityId("EmployeeRoleAssignment");
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

        private DataTable GetDatatable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("PermitionId", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("Id", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("Functionality", typeof(System.String)));
            dt.Columns.Add(new DataColumn("IsInsert", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("IsUpdate", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("IsDelete", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("IsView", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("IsApprove", typeof(System.Boolean)));

            return dt;
        }

        private DataTable GetDatatablePermition()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("PermitionId", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("Id", typeof(System.Int32)));
            dt.Columns.Add(new DataColumn("Functionality", typeof(System.String)));
            dt.Columns.Add(new DataColumn("IsInsert", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("IsUpdate", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("IsDelete", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("IsView", typeof(System.Boolean)));
            dt.Columns.Add(new DataColumn("IsApprove", typeof(System.Boolean)));

            return dt;
        }
        private void LoadRoleListCombo()
        {

            List<UserRole> lstUserRole = new UserRole().GetAllUserRole(0);

            lstUserRole.Insert(0, new UserRole());

            rdropList.DataTextField = "Role";
            rdropList.DataValueField = "Id";
            rdropList.DataSource = lstUserRole;
            rdropList.DataBind();

            rdropList.SelectedIndex = 0;
        }
        private void LoadUserListCombo()
        {

            List<Users> lstUser = new Users().GetAllUsers(1);

            lstUser.Insert(0, new Users());
            rdropList.DataTextField = "UserName";
            rdropList.DataValueField = "Id";
            rdropList.DataSource = lstUser;
            rdropList.DataBind();

            rdropList.SelectedIndex = 0;
        }
        private void LoadAppfunctionality()
        {
            List<AppFunctionality> objAppFunctionlity = new AppFunctionality().GetAllAppFunctionality(1);
            DataTable dtFunc = GetDatatable();

            foreach (AppFunctionality func in objAppFunctionlity)
            {
                DataRow row = dtFunc.NewRow();
                row["PermitionId"] = 0;
                row["Id"] = func.Id;
                row["Functionality"] = func.Functionality;
                row["IsInsert"] = false;
                row["IsUpdate"] = false;
                row["IsDelete"] = false;
                row["IsView"] = false;
                row["IsApprove"] = false;

                dtFunc.Rows.Add(row);
            }

            RadGridAppFunction.DataSource = dtFunc;
            RadGridAppFunction.DataBind();

        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str != string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);
                else
                    Response.Redirect("LogIn.aspx?refPage=default.aspx");
            }
            if (!IsValidPageForUser())
            {
                Alert.Show("Sorry, You Don't Have permission to access this page.");
                Response.Redirect("LogIn.aspx?refPage=default.aspx", false);
            }

        }

        protected void rdeopType_SelectedIndexChanged(object sender, Telerik.Web.UI.DropDownListEventArgs e)
        {
            if (rdeopType.SelectedValue == "Users")
            {
                this.LoadUserListCombo();

            }
            else
            {
                this.LoadRoleListCombo();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridDataItem item in RadGridAppFunction.Items)
                {
                    //GridDataItem Item1 = (GridDataItem)item;

                    int PerId = int.Parse(item["colPerId"].Text);
                    int Id = int.Parse(item["colId"].Text);

                    CheckBox isview = (CheckBox)item.FindControl("chkIsView");
                    bool IsViewList = isview.Checked;

                    CheckBox isInsert = (CheckBox)item.FindControl("chkIsInsert");
                    bool IsInsertList = isInsert.Checked;

                    CheckBox isupdate = (CheckBox)item.FindControl("chkIsUpdate");
                    bool IsUpadteList = isupdate.Checked;

                    CheckBox isdelete = (CheckBox)item.FindControl("chkIsDelete");
                    bool IsDeleteList = isdelete.Checked;

                    CheckBox isApprove = (CheckBox)item.FindControl("chkIsApprove");
                    bool IsApproveList = isApprove.Checked;

                    AppPermission objAppPermission = new AppPermission();

                    if (rdeopType.SelectedValue == "Role")
                    {
                        objAppPermission.CompanyId = 1;
                        objAppPermission.RoleId = int.Parse(rdropList.SelectedValue);
                        objAppPermission.UserId = 0;
                        objAppPermission.Id = PerId;
                        objAppPermission.FunctionalityId = Id;
                        objAppPermission.IsView = IsViewList;
                        objAppPermission.IsInsert = IsInsertList;
                        objAppPermission.IsUpdate = IsUpadteList;
                        objAppPermission.IsDelete = IsDeleteList;
                        objAppPermission.IsApprove = IsApproveList;
                        int success = 0;
                        if (_isNewEntry)
                        {
                            success = objAppPermission.InsertAppPermission();
                        }
                        else
                            success = objAppPermission.UpdateAppPermission();

                        if (success == 0)
                        {
                            Alert.Show("AppPermition was not saved successfully. Please retry.");
                        }
                        else
                        {
                            Alert.Show("AppPermition saved successfully. .");
                        }
                    }
                    else
                    {
                        objAppPermission.CompanyId = 1;
                        objAppPermission.UserId = int.Parse(rdropList.SelectedValue);
                        objAppPermission.RoleId = 0;
                        objAppPermission.FunctionalityId = Id;
                        objAppPermission.IsView = IsViewList;
                        objAppPermission.IsInsert = IsInsertList;
                        objAppPermission.IsUpdate = IsUpadteList;
                        objAppPermission.IsDelete = IsDeleteList;
                        objAppPermission.IsApprove = IsApproveList;

                        int success = objAppPermission.InsertAppPermission();
                        if (success == 0)
                        {
                            Alert.Show("AppPermition was not saved successfully. Please retry.");
                        }
                        else
                        {
                            Alert.Show("AppPermition saved successfully. .");
                        }
                    }

                }
            }
            catch (Exception exp)
            {
                Alert.Show("Something is Going Wrong!!!" + exp);
            }

        }

        protected void rdropList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

            if (rdeopType.SelectedValue == "Role")
            {
                List<AppPermission> listR = new AppPermission().GetAllAppPermission(1).Where(ulist => ulist.RoleId == int.Parse(rdropList.SelectedValue)).ToList();
                if (listR.Count == 0)
                {
                    this.LoadAppfunctionality();
                    _isNewEntry = true;
                }
                else
                {
                    List<AppPermission> objApppermision = new AppPermission().GetViewAllAppPermission(1).Where(ulist => ulist.RoleId == int.Parse(rdropList.SelectedValue)).ToList();
                    DataTable dtpermition = GetDatatablePermition();

                    foreach (AppPermission func in objApppermision)
                    {
                        DataRow row = dtpermition.NewRow();
                        row["PermitionId"] = func.Id;
                        row["Id"] = func.FunctionalityId;
                        row["Functionality"] = func.FunctionalityName;
                        row["IsInsert"] = func.IsInsert;
                        row["IsUpdate"] = func.IsUpdate;
                        row["IsDelete"] = func.IsDelete;
                        row["IsView"] = func.IsView;
                        row["IsApprove"] = func.IsApprove;

                        dtpermition.Rows.Add(row);
                    }
                    RadGridAppFunction.DataSource = dtpermition;
                    RadGridAppFunction.DataBind();
                }
            }
            else
            {
                List<AppPermission> listU = new AppPermission().GetViewAllAppPermission(1).Where(ulist => ulist.UserId == int.Parse(rdropList.SelectedValue)).ToList();
                if (listU.Count == 0)
                {
                    this.LoadAppfunctionality();
                    _isNewEntry = true;
                }
                else
                {
                    List<AppPermission> objApppermision = new AppPermission().GetAllAppPermission(1).Where(ulist => ulist.UserId == int.Parse(rdropList.SelectedValue)).ToList();
                    DataTable dtpermition = GetDatatablePermition();

                    foreach (AppPermission func in objApppermision)
                    {
                        DataRow row = dtpermition.NewRow();
                        row["PermitionId"] = func.Id;
                        row["Id"] = func.FunctionalityId;
                        row["Functionality"] = func.FunctionalityName;
                        row["IsInsert"] = func.IsInsert;
                        row["IsUpdate"] = func.IsUpdate;
                        row["IsDelete"] = func.IsDelete;
                        row["IsView"] = func.IsView;
                        row["IsApprove"] = func.IsApprove;

                        dtpermition.Rows.Add(row);
                    }
                    RadGridAppFunction.DataSource = dtpermition;
                    RadGridAppFunction.DataBind();
                }
            }
        }

      
    }
}