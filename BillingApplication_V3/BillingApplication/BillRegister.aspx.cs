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
    public partial class BillRegister : System.Web.UI.Page
    {
        private static int userId;
        private static Hashtable _MonthList;
       
        /// <summary>
        /// 
        /// </summary>
        private void LoadGrid()
        {
            try
            {
                //if (ddlMarket.SelectedIndex <= 0) return;

                DataTable dt = GetBillData();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.NewRow();

                    dt.Rows.Add(row);
                }

                RadGrid1.DataSource = dt;
                RadGrid1.DataBind();
            }
            catch (Exception ex)
            {
                Alert.Show("Error in method 'LoadLeaveDetailsGrid'. Error: " + ex.Message);
            }
        }

        private DataTable GetBillData()
        {
            if (ddlMonth.SelectedIndex == -1) return new DataTable();

            int marketId = 0;

            if (ddlMarket.SelectedIndex > 0) marketId = int.Parse(ddlMarket.SelectedValue);

            string month = ddlMonth.SelectedItem.Text.Substring(5);
            int year = int.Parse(ddlMonth.SelectedItem.Text.Substring(0, 4));

            DataTable dt;
            if(rbDue.Checked)
                dt = new BillMaster().GetBillMasterDetailForGridWithCondition(year, month, marketId, " And Due > 0");
            else if(rbPaid.Checked)
                dt = new BillMaster().GetBillMasterDetailForGridWithCondition(year, month, marketId, " And Due = 0");
            else
                dt = new BillMaster().GetBillMasterDetailForGrid(year, month, marketId);

            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadMarketDropDown()
        {
            List<Market> objMarketList = new Market().GetAllMarket();
            objMarketList.Insert(0, new Market());

            ddlMarket.DataTextField = "MarketName";
            ddlMarket.DataValueField = "Id";

            ddlMarket.DataSource = objMarketList;
            ddlMarket.DataBind();

            ddlMarket.SelectedIndex = 0;
        }


        /// <summary>
        /// load month and year dropdown
        /// </summary>
        private void LoadMonthDropDown()
        {
            this.GetMonthList();
            DateTime start = DateTime.Parse(DateTime.Today.Year + "/" + DateTime.Today.Month + "/1");
            start = start.AddMonths(-10);
            DateTime end = DateTime.Today.AddMonths(10);

            int monthDiff = (end.Year * end.Month) - (start.Year * start.Month);
            string selectedVal = string.Empty;

            for (DateTime startDate = start; startDate <= end; startDate.AddMonths(1))
            {
                int monthInt = startDate.Month;

                string str = startDate.Year.ToString() + " " + _MonthList[monthInt].ToString();

                string strVal = startDate.Year.ToString() + " " + monthInt.ToString();

                if (startDate.Year == DateTime.Today.Year && startDate.Month == DateTime.Today.Month)
                    selectedVal = strVal;
                ddlMonth.Items.Add(new ListItem(str, strVal));

                startDate = startDate.AddMonths(1);
            }

            ddlMonth.SelectedValue = selectedVal;
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetMonthList()
        {
            _MonthList = new Hashtable();
            _MonthList.Add(1, "Rvbyqvix");
            _MonthList.Add(2, "‡deªzzzqvix");
            _MonthList.Add(3, "gvP©");
            _MonthList.Add(4, "GwcÖj");
            _MonthList.Add(5, "‡g");
            _MonthList.Add(6, "Ryb");
            _MonthList.Add(7, "RyjvB");
            _MonthList.Add(8, "AvM÷");
            _MonthList.Add(9, "‡m‡Þ¤^i");
            _MonthList.Add(10, "A‡±vei");
            _MonthList.Add(11, "b‡f¤^i");
            _MonthList.Add(12, "wW‡m¤^i");
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

                    this.LoadMarketDropDown();
                    this.LoadMonthDropDown();
                    this.LoadGrid();
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

     
        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                
                if (e.CommandName == "btnPrint")
                {
                    GridDataItem item = (GridDataItem) e.Item;
                    int id = int.Parse(item["colId"].Text);

                    if (id != 0)
                    {
                        DataSet ds = new DataSet();

                        DataTable dtBillDetail = new BillMaster().GetBillMasterDetailForSingleReport(id);
                        ds.Tables.Add(dtBillDetail);

                        DataTable dtCompany = new Company().GetCompanyDatatableById(1);
                        ds.Tables.Add(dtCompany);

                        Session["ReportDataset"] = ds;

                        //string myScript = "window.open('reportview.aspx?report=rptBillCopy.rdlc');";
                        string myScript = "window.open('CrystalReportViewer.aspx?report=crptBillCopyWithoutCaption.rpt');";

                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "OpenPopup", myScript, true);
                    }

                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error during leave grid event. Error: " + ex.Message);
            }
        }

        protected void ddlMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMarket.SelectedIndex > 0)
            {
                this.LoadGrid();
            }
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMonth.SelectedIndex > 0)
            {
                this.LoadGrid();
            }
        }

        protected void btnPrintSummary_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBillDetail = GetBillData();
                //if (ddlMarket.SelectedIndex <=0)
                //    dtBillDetail = new BillMaster().GetBillMasterDetailForReport();
                //else
                //{ 
                //    int marketId = int.Parse(ddlMarket.SelectedValue); 
                //    dtBillDetail = new BillMaster().GetBillMasterDetailForReport(marketId); 
                //}

                DataSet ds = new DataSet();
                ds.Tables.Add(dtBillDetail);

                DataTable dtCompany = new Company().GetCompanyDatatableById(1);
                ds.Tables.Add(dtCompany);

                Session["ReportDataset"] = ds;

                string myScript = "window.open('CrystalReportViewer.aspx?report=summaryReport.rpt');";
                //string myScript = "window.open('ReportView.aspx?report=Report1.rdlc');";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "OpenPopup", myScript, true);

            }
            catch (Exception ex)
            {
                Alert.Show("Error during leave grid event. Error: " + ex.Message);
            }
        }

        protected void btnPrintAll_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtBillDetail =  GetBillData();
                //if (ddlMarket.SelectedIndex <= 0)
                //    dtBillDetail = new BillMaster().GetBillMasterDetailForReport();
                //else
                //{
                //    int marketId = int.Parse(ddlMarket.SelectedValue);
                //    dtBillDetail = new BillMaster().GetBillMasterDetailForReport(marketId);
                //}

                DataSet ds = new DataSet();

                ds.Tables.Add(dtBillDetail);

                DataTable dtCompany = new Company().GetCompanyDatatableById(1);
                ds.Tables.Add(dtCompany);

                Session["ReportDataset"] = ds;

                string myScript = "window.open('CrystalReportViewer.aspx?report=crptBillCopyWithoutCaption.rpt');";
                //string myScript = "window.open('ReportView.aspx?report=Report1.rdlc');";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "OpenPopup", myScript, true);
    
            }
            catch (Exception ex)
            {
                Alert.Show("Error during leave grid event. Error: " + ex.Message);
            }
        }

        protected void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        protected void rbPaid_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        protected void rbDue_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

       
    }
}