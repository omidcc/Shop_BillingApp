using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.Bll;

namespace BillingApplication
{
    public partial class DueInstallmentSetup : System.Web.UI.Page
    {
        private static bool isNewEntry;
        private static int userId;
        private static Hashtable _MonthList;

        private void Clear()
        {
            lblId.Text = "";
            txtShopNo.Text = "";
            txtMonthlyRent.Text = "";
            txtServiceCharge.Text = "";
            txtMiscBill.Text = "";
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

        private void LoadMarketDropDown()
        {
            List<Market> objMarketList = new Market().GetAllMarket();
            objMarketList.Insert(0,new Market());

            ddlMarket.DataTextField = "MarketName";
            ddlMarket.DataValueField = "Id";

            ddlMarket.DataSource = objMarketList;
            ddlMarket.DataBind();

            ddlMarket.SelectedIndex = 0;
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
                    isNewEntry = true;

                    this.Clear();
                    this.LoadMonthDropDown();
                    this.LoadMarketDropDown();

                    if (Request.QueryString["tid"] != null)
                    {
                        int tenantid = int.Parse(Request.QueryString["tid"].ToString());

                        if (tenantid > 0)
                        {
                            Tenant tenant= new Tenant().GetTenantById(tenantid);

                            lblTenantId.Text = tenant.Id.ToString();
                            txtTenantName.Text = tenant.TenantName;
                            txtTotalDue.Text = tenant.OutstandingAmount.ToString();

                            DataTable dtShop = new ShopeMapping().GetShopeMappingByTenantId(tenantid);
                            if (dtShop.Rows.Count > 0)
                            {
                                ddlMarket.SelectedValue = dtShop.Rows[0]["MarketId"].ToString();
                                lblShopId.Text = dtShop.Rows[0]["ShopeId"].ToString();
                                txtShopNo.Text = new Shop().GetShopById(int.Parse(lblShopId.Text)).ShopNo;
                                txtServiceCharge.Text = dtShop.Rows[0]["ServiceCharge"].ToString();
                                txtMonthlyRent.Text = dtShop.Rows[0]["MonthlyRent"].ToString();
                                txtMiscBill.Text = dtShop.Rows[0]["MiscBill"].ToString();
                                
                                isNewEntry = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("DueList.aspx", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTenantId.Text.Length==0)
                {
                    Alert.Show("দয়া করে এই প্রক্রিয়াটি পুনরায় করুন।");
                    return;
                }
                if (txtInstallmentNo.Text==string.Empty)
                {
                    Alert.Show("দয়া করে কিস্তির সংখ্যা প্রদান করুন।");
                    txtInstallmentNo.Focus();
                    return;
                }

                //convert unicode to decimal
                string strInstallmentNo = Encode.HtmlEncode(txtInstallmentNo.Text);
                int decInstallmentNo = 0;
                try
                {
                    decInstallmentNo = int.Parse(strInstallmentNo);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে কিস্তির সংখ্যা ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtInstallmentNo.Focus();
                    return;
                }
                string strPrevDie = Encode.HtmlEncode(txtTotalDue.Text);
                decimal decPrevDue = 0;
                try
                {
                    decPrevDue = decimal.Parse(strPrevDie);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে সার্ভিস চার্জ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtServiceCharge.Focus();
                    return;
                }
                string strAmount = Encode.HtmlEncode(txtInstallmentAmount.Text);
                decimal decAmount= 0;
                try
                {
                    decAmount = decimal.Parse(strAmount);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে সার্ভিস চার্জ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtServiceCharge.Focus();
                    return;
                }
               
                DueInstallment obj = new DueInstallment();

                obj.TenantId = int.Parse(lblTenantId.Text);
                obj.ShopId = int.Parse(lblShopId.Text);
                obj.DueDate = System.DateTime.Today;
                obj.PreviousDue = decPrevDue;
                obj.NoOfInstallment = decInstallmentNo;
                obj.InstallmentAmount = decAmount;

                string startMonth = ddlMonth.SelectedValue;
                obj.StartMonth = int.Parse(startMonth.Substring(5));
                obj.StartYear = int.Parse(startMonth.Substring(0,4));
                obj.PaidAmount = 0;
                obj.UserId = userId;
                
                if (!isNewEntry)
                    obj.Id = int.Parse(lblId.Text);
                    
                int success = 0;

                if (isNewEntry) 
                    success = obj.InsertDueInstallment();
                else
                    success = obj.UpdateDueInstallment();


                if (success == 1)
                {
                    Alert.Show("তথ্য সংরক্ষণ হয়েছে।");

                    string marketId = ddlMarket.SelectedValue;
                    Response.Redirect("DueList.aspx?mid=" + marketId, false);
                }
            }
            catch (Exception ex)
            {
               Alert.Show(ex.Message);
            }
        }

       
        protected void txtInstallmentNo_TextChanged(object sender, EventArgs e)
        {
            if (txtInstallmentNo.Text.Length > 0)
            {
                string strInstallmentNo = Encode.HtmlEncode(txtInstallmentNo.Text);
                int decInstallmentNo = 0;
                try
                {
                    decInstallmentNo = int.Parse(strInstallmentNo);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে কিস্তির সংখ্যা ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtInstallmentNo.Focus();
                    return;
                }

                txtInstallmentAmount.Text = (double.Parse(txtTotalDue.Text) / decInstallmentNo).ToString();
            }
        }

        
    }
}