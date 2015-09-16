using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.Bll;
using System.Collections;
using Telerik.Web.UI;

namespace BillingApplication
{
    public partial class GenerateBill : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        private static Hashtable _MonthList;
        
        /// <summary>
        /// 
        /// </summary>
        private static List<Shop> shopList;

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
            if (!IsValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=default.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);
            }


            try
            {
                if (!IsPostBack)
                {
                    txtDate.Text = DateTime.Today.ToString("MMM dd, yyyy");
                    dtpLastDate.SelectedDate = DateTime.Parse(DateTime.Today.Year + "/" + DateTime.Today.Month + "/15");
                    if (DateTime.Parse(txtDate.Text) > dtpLastDate.SelectedDate)
                    {
                        DateTime date = DateTime.Today.AddMonths(1);
                        dtpLastDate.SelectedDate = date;
                    }
                        
                    this.LoadMarketDropDown();

                    this.GetMonthList();
                    this.LoadMonthDropDown();
                }
            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message);
            }
        }


        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            StringBuilder strSuccess=new StringBuilder();
            StringBuilder strFailure = new StringBuilder();

            strSuccess.Append("<strong>Success</strong><br>");
            strFailure.Append("<strong>Failure</strong><br>");

            try
            {
                if (ddlMarket.SelectedIndex <= 0)
                {
                    Alert.Show("Please select a market first.");
                    ddlMarket.Focus();
                    return;
                }

                int marketId = int.Parse(ddlMarket.SelectedValue);
                List<Shop> shopList = new Shop().GetAllShopByMarketId(marketId);
                BillMaster billMaster = new BillMaster();
                BillDetail billDetail = new BillDetail();


                foreach (ListItem li in cbListShops.Items)
                {
                    if (!li.Selected) continue;

                    int shopId = int.Parse(li.Value);

                    Shop shop = shopList.Find(x => x.Id == shopId);
                    try
                    {
                        #region process bill master data

                        string monthYearText = ddlMonth.SelectedItem.Text;
                        string monthYearVal = ddlMonth.SelectedValue;

                        ShopeMapping shopeMapping = new ShopeMapping().GetAllShopeMappingByShopId(shop.Id);

                        billMaster.BilGeneratelDate = DateTime.Parse(txtDate.Text);
                        billMaster.BillMonth = monthYearText.Substring(5);
                        billMaster.BillYear = int.Parse(monthYearText.Substring(0, 4));
                        billMaster.TenantId = shopeMapping.TenantId;

                        billMaster.BillNo = billMaster.BillYear + "-" + monthYearVal.Substring(5) + "-" +
                                            shop.Id + "-" + shopeMapping.TenantId;



                        billMaster.GenerateBy = 1;
                        billMaster.ApprovedBy = 0;
                        billMaster.TotalAmount = 0;
                        billMaster.TotalPayment = 0;
                        billMaster.LastPaymentDate = (DateTime) dtpLastDate.SelectedDate;

                        string MonthVal = ddlMonth.SelectedValue.Substring(5);
                        billMaster.BillMonthId = int.Parse(MonthVal);
                        int success = 0;

                        int billId = billMaster.CheckExistanceByBillNo(billMaster.BillNo);
                        if (billId > 0)
                        {
                            if (!chkUpdateExisting.Checked)
                            {
                                strFailure.Append("Bill already generated for the shop: " + shop.ShopNo + "<br>");
                                continue;
                            }

                            billMaster.Id = billId;
                            success = billMaster.UpdateBillMaster();
                        }
                        else
                        {      
                            success = billMaster.InsertBillMaster();
                            billMaster.Id = new BillMaster().GetLastId();
                        }

                    #endregion

                        #region process bill detail data

                        if (success > 0)
                        {
                            billDetail = new BillDetail();
                            billDetail.BillMasterId = billMaster.Id;
                            billDetail.MarketId = int.Parse(ddlMarket.SelectedValue);
                            billDetail.ShopId = shop.Id;
                            billDetail.MonthlyRent = shopeMapping.MonthlyRent;
                            billDetail.ServiceCharge = shopeMapping.ServiceCharge;
                            billDetail.MiscBills = shopeMapping.MiscBill;

                            if (chkPrevDue.Checked)
                            {
                                DueInstallment installment = new DueInstallment().GetDueInstallmentByTenant(billMaster.TenantId);
                                if (installment.Id != 0)
                                {
                                    billDetail.PreviousDue = installment.InstallmentAmount;
                                    if (installment.DueAmount < installment.InstallmentAmount)
                                        billDetail.PreviousDue = installment.DueAmount;
                                }
                                else
                                {
                                    if (billDetail.CheckBillExistenceByTenant(billMaster.TenantId, shop.Id) > 0)
                                        billDetail.PreviousDue = billDetail.GetLastDueTenantAndShopWise(billMaster.TenantId, shop.Id);
                                    else
                                        billDetail.PreviousDue = new ShopeMapping().GetAllShopeMappingByShopId(shop.Id).PreviousDue;
                                }
                                
                            }
                            else
                                billDetail.PreviousDue = 0;

                            billDetail.LateFee = Math.Round((shopeMapping.MonthlyRent*5)/100,0);
                            billDetail.Payment = 0;
                            billDetail.IsClosed = false;
                            billDetail.ClosedBy = 0;

                            if (billId > 0)
                            {
                                int billDetailId = billDetail.GetBillDetailIdByMasterId(billId);
                                if (billDetailId > 0)
                                {
                                    billDetail.Id = billDetailId;
                                    success = billDetail.UpdateBillDetail();
                                }
                                else
                                    success = billDetail.InsertBillDetail();
                            }
                            else
                                success = billDetail.InsertBillDetail();

                            //update total amount in master table
                            if (success > 0)
                            {
                                decimal totalAmount = (billDetail.MonthlyRent + billDetail.ServiceCharge +
                                                       billDetail.MiscBills +
                                                       billDetail.PreviousDue);

                                billMaster.UpdateTotalAmount(billMaster.Id, totalAmount);

                                strSuccess.Append("Bill generated for Shop: " + shop.ShopNo + "<br>");
                            }
                        }

                        #endregion

                    }

                    catch (Exception ex)
                    {
                        strFailure.Append("Bill generate failed for Shop " + shop.ShopNo + ". Error: " + ex.Message +
                                          "<br>");
                        continue;
                    }
                }

                strFailure.Append("<br><br>");

                ltrStatus.Text = strFailure.ToString() + strSuccess.ToString();
            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message);
            }
        }

        protected void ddlMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMarket.SelectedIndex <= 0)
            {
                Alert.Show("Please select a market first.");
                ddlMarket.Focus();
                return;
            }

            int marketId = int.Parse(ddlMarket.SelectedValue);
            shopList = new Shop().GetAllShopByMarketId(marketId);

            if (shopList.Count > 0)
            {
                cbListShops.DataTextField = "ShopInfo";
                cbListShops.DataValueField = "Id";
                cbListShops.DataSource = shopList;
                cbListShops.DataBind();


                tdShopList.Visible = true;
                tdShopListCaption.Visible = true;
                btnGenerate.Enabled = true;
            }
            else
            {
                tdShopList.Visible = false;
                tdShopListCaption.Visible = false;
                btnGenerate.Enabled = false;
            }

        }

        protected void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in cbListShops.Items)
            {
                li.Selected = true;
            }  
        }

        protected void btnUnSelectall_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in cbListShops.Items)
            {
                li.Selected = false;
            }
        }
    }
}