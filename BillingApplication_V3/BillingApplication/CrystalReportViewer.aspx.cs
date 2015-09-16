using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using Microsoft.Reporting.WebForms;
using Smart.Bll;

namespace BillingApplication
{
    public partial class CrystalReportViewer : System.Web.UI.Page
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
                        case "rptYearlyReport.rpt":
                            string year = DateTime.Today.Year.ToString();
                            if (Session["year"] != null)
                                year = Session["year"].ToString();

                            this.ShowYearlyReport(year);
                            break;
                        case "crptBillCopy.rpt":
                            this.ShowReportAll();
                            break;
                        case "crptBillCopyWithoutCaption.rpt":
                            this.ShowReportAll();
                            break;
                        case "summaryReport.rpt":
                            this.ShowSummaryReport();
                            break;
                    }

                }
                else
                {
                    try
                    {
                        rptViewer.ReportSource = (ReportDocument)Session["ReportDocument"];
                        rptViewer.RefreshReport();
                        rptViewer.DataBind();
                    }
                    catch (Exception ex)
                    {

                        // throw;
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
            //DataTable dtCompnay = _ds.Tables[1];

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath(@"Reports\Report\\" + _reportName));
            crystalReport.Database.Tables["BillMaster"].SetDataSource(_ds.Tables[0]);
            crystalReport.Database.Tables["Company"].SetDataSource(_ds.Tables[1]);

            crystalReport.SetDataSource(_ds);
            rptViewer.ReportSource = crystalReport;
            rptViewer.RefreshReport();

            //String reportPath = Server.MapPath();
            //rptViewer.LocalReport.ReportPath = reportPath + _reportName;

            //rptViewer.LocalReport.DataSources.Clear();
            //rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsBillData", _ds.Tables[0]));
            //rptViewer.LocalReport.DataSources.Add(new ReportDataSource("dsCompany", dtCompnay));
            ////rptViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _ds.Tables[0]));

            //rptViewer.LocalReport.Refresh();
        }


        /// <summary>
        /// 
        /// </summary>
        private void ShowYearlyReport(string year)
        {
            //DataTable dtCompnay = _ds.Tables[1];

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath(@"Reports\Report\\" + _reportName));
            crystalReport.Database.Tables["dtMaster"].SetDataSource(_ds.Tables[0]);
            crystalReport.Database.Tables["dtDetail"].SetDataSource(_ds.Tables[1]);


            crystalReport.SetDataSource(_ds);
            rptViewer.ReportSource = crystalReport;
            
            rptViewer.RefreshReport();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowReportAll()
        {
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath(@"Reports\Report\\" + _reportName));
            Session["ReportDocument"] = crystalReport;

            crystalReport.Database.Tables["BillMaster"].SetDataSource(_ds.Tables[0]);
            crystalReport.Database.Tables["Company"].SetDataSource(_ds.Tables[1]);

            //crystalReport.SetDataSource(_ds);
            rptViewer.PrintMode = PrintMode.Pdf;
            //rptViewer.
            crystalReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
            rptViewer.ReportSource = (ReportDocument)Session["ReportDocument"];
            rptViewer.RefreshReport();
            rptViewer.DataBind();

            // Stop buffering the response
            Response.Buffer = false;
            // Clear the response content and headers
            Response.ClearContent();
            Response.ClearHeaders();

            ExportFormatType format = ExportFormatType.PortableDocFormat;
            string ext = ".pdf";
            string reportName = "myreport";

            try
            {
                crystalReport.ExportToHttpResponse(format, Response, false, "");
            }
            catch (System.Threading.ThreadAbortException)
            {
                //ThreadException can happen for internale Response implementation
            }
            catch (Exception ex)
            {
                //other exeptions will be managed   
                throw;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        private void ShowSummaryReport()
        {
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath(@"Reports\Report\\" + _reportName));
            Session["ReportDocument"] = crystalReport;

            crystalReport.Database.Tables["BillMaster"].SetDataSource(_ds.Tables[0]);
            crystalReport.Database.Tables["Company"].SetDataSource(_ds.Tables[1]);

            //crystalReport.SetDataSource(_ds);
            rptViewer.ReportSource = (ReportDocument)Session["ReportDocument"];
            rptViewer.RefreshReport();
            rptViewer.DataBind();
        }
    }
}