using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Security.AccessControl;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingApplication.Reports.Dataset;
using Smart.Bll;
using Telerik.Web.UI;

namespace BillingApplication
{
    public partial class YearlyReport : System.Web.UI.Page
    {
        private static int userId;
        private static Hashtable _MonthList;
        private static Tenant tenantDetails;
        private static DataTable dtTenant;
        private static DataTable dtyearlyReport;

        /// <summary>
        /// load month and year dropdown
        /// </summary>
        private void LoadYearDropDown()
        {
            int start = DateTime.Today.Year;
            int end = start + 10;
            start = start - 10;
            
            string selectedVal = string.Empty;

            for (int year = start; year <= end; year++)
            {
                if (year == DateTime.Today.Year)
                    selectedVal = year.ToString();

                ddlYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
            }

            ddlYear.SelectedValue = selectedVal;
        }


        /// <summary>
        /// 
        /// </summary>
        private void LoadGrid(int tenantId)
        {
            try
            {
                
                if (ddlYear.SelectedIndex == -1) return;

                int year = int.Parse(ddlYear.Text);

                dtyearlyReport = new BillMaster().GetYearlyReport(year, tenantId);

                if (dtyearlyReport.Rows.Count == 0)
                {
                    DataRow row = dtyearlyReport.NewRow();

                    dtyearlyReport.Rows.Add(row);
                }

                RadGrid1.DataSource = dtyearlyReport;
                RadGrid1.DataBind();
            }
            catch (Exception ex)
            {
                Alert.Show("Error in method 'LoadLeaveDetailsGrid'. Error: " + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shopId"></param>
        private void ShowTenantDetails(int id, int shopId)
        {
            dtTenant = new Tenant().GetAllTenantWithDetail(id,shopId);

            lblId.Text = dtTenant.Rows[0]["Id"].ToString();
            txtName.Text = dtTenant.Rows[0]["TenantName"].ToString();
            txtAddress.Text = dtTenant.Rows[0]["Address"].ToString();
            txtContactNo.Text = dtTenant.Rows[0]["ContactNo"].ToString();
            txtFatherName.Text = dtTenant.Rows[0]["FathersNames"].ToString();
            txtMarket.Text = dtTenant.Rows[0]["MarketName"].ToString();
            txtShopNo.Text = dtTenant.Rows[0]["ShopNo"].ToString();
            
            this.LoadGrid(id);
        }

        /// <summary>
        /// 
        /// </summary>
        private static Users _user;

        /// <summary>
        /// 
        /// </summary>
        private static UserRole _role;

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
            try
            {
                if (!IsValidSession())
                {
                    string str = Request.QueryString.ToString();
                    if (str == string.Empty)
                        Response.Redirect("LogIn.aspx?refPage=default.aspx");
                    else
                        Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);
                }


                if (!IsPostBack)
                {
                    userId = 1;
                    this.LoadYearDropDown();
                    
                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        int shopId = int.Parse(Request.QueryString["shopid"].ToString());

                        if (id > 0)
                        {
                            ShowTenantDetails(id, shopId);       
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlYear.SelectedIndex > 0)
            {
                this.LoadGrid(int.Parse(lblId.Text));
            }
        }

        protected void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                

                DataSet ds = new DataSet();
                DataColumn colYear=new DataColumn("Year");
                colYear.DefaultValue = ddlYear.Text;
                dtTenant.Columns.Add(colYear);
                ds.Tables.Add(dtTenant);

                ds.Tables.Add(dtyearlyReport);

                Session["ReportDataset"] = ds;
                Session["year"] = ddlYear.Text;
                string myScript = "window.open('CrystalReportViewer.aspx?report=rptYearlyReport.rpt');";
                //string myScript = "window.open('ReportView.aspx?report=Report1.rdlc');";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "OpenPopup", myScript, true);
    
            }
            catch (Exception ex)
            {
                Alert.Show("Error during leave grid event. Error: " + ex.Message);
            }
        }

       
    }
}