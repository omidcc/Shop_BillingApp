using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Smart.Bll;


namespace BillingApplication
{
    public partial class ReportView : System.Web.UI.Page
    {
        private string _reportName;
        private DataSet _ds;

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
                    if (Request.QueryString["report"] == null)
                    {
                        Alert.Show("Sorry bad request. Please try again.");
                        return;
                    }

                    _reportName = Request.QueryString["report"].ToString();

                    if (Session["ReportDataset"] == null)
                    {
                        Alert.Show("No dataset were sent from the source page. Please submit the request again.");
                        return;
                    }

                    _ds = (DataSet)Session["ReportDataset"];

                    switch (_reportName)
                    {
                        case "rptBillCopy.rdlc":
                            this.ShowReportAll1();
                            break;
                        case "crptBillCopy.rpt":
                            this.ShowReport();
                            break;
                        case "Report1.rdlc":
                            this.ShowReportAll1();
                            break;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        private void ShowReport()
        {
            DataTable dtCompnay = _ds.Tables[1];

            String reportPath = Server.MapPath(@"Reports\Report\\");
            rptViewer.LocalReport.ReportPath = reportPath + _reportName;

            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsBillData", _ds.Tables[0]));
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsCompany", dtCompnay));
            //rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _ds.Tables[0]));

            rptViewer.LocalReport.Refresh();
        }

        private void ShowReportAll()
        {
            DataTable dtCompnay = _ds.Tables[1];

            String reportPath = Server.MapPath(@"Reports\Report\\");
            rptViewer.LocalReport.ReportPath = reportPath + _reportName;

            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _ds.Tables[0]));
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dtCompnay));
            //rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _ds.Tables[0]));

            rptViewer.LocalReport.Refresh();
        }


        private void ShowReportAll1()
        {
            DataTable dtCompnay = _ds.Tables[1];

            String reportPath = Server.MapPath(@"Reports\Report\\");
            rptViewer.LocalReport.ReportPath = reportPath + _reportName;

            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsBillData", _ds.Tables[0]));
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsCompany", dtCompnay));
            //rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _ds.Tables[0]));

            

            rptViewer.LocalReport.Refresh();
        }
    }
}