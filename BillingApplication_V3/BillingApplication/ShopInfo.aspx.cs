using System;
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
    public partial class ShopInfo : System.Web.UI.Page
    {
        private static bool isNewEntry;
        private static int userId;

        private void Clear()
        {
            lblId.Text = "";
            txtShopNo.Text = "";
            txtArea.Text = "";
            txtMonthlyRent.Text = "";
            txtServiceCharge.Text = "";
            txtMiscBill.Text = "";
            txtAdvance.Text = "";
            ddlShopType.SelectedIndex = 0;
            ddlMarket.SelectedIndex = 0;
            txtDescription.Text = "";
        }

        private void LoadShopCategory()
        {
            List<ShopCategory> shopCategories = new ShopCategory().GetAllShopCategory();
            shopCategories.Insert(0,new ShopCategory());

            ddlShopType.DataTextField = "Category";
            ddlShopType.DataValueField = "Id";

            ddlShopType.DataSource = shopCategories;
            ddlShopType.DataBind();

            ddlShopType.SelectedIndex = 0;
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
                    this.LoadShopCategory();
                    this.LoadMarketDropDown();

                    if (Request.QueryString["id"] != null)
                    {
                        int id = int.Parse(Request.QueryString["id"].ToString());

                        if (id > 0)
                        {
                            Shop shop = new Shop().GetShopById(id);
                            
                            lblId.Text = shop.Id.ToString();
                            txtShopNo.Text = shop.ShopNo;
                            txtServiceCharge.Text = shop.ServiceCharge.ToString();
                            txtMonthlyRent.Text = shop.MonthlyRent.ToString();
                            txtDescription.Text = shop.Description;
                            txtArea.Text = Math.Round(shop.SpaceInSqFt,0).ToString();
                            txtAdvance.Text = shop.AdvanceAmount.ToString();
                            ddlShopType.SelectedValue = shop.CategoryId.ToString();
                            ddlMarket.SelectedValue = shop.MarketId.ToString();
                            txtMiscBill.Text = shop.MiscBill.ToString();

                            isNewEntry = false;
                            btnNext.Visible = true;
                            btnPrev.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Alert.Show(ex.Message);
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (lblId.Text == string.Empty) return;
            int shoptId = int.Parse(lblId.Text);
            int id = new Shop().GetPreviousShopId(shoptId);
            Response.Redirect("ShopInfo.aspx?id=" + id.ToString(), true);

            //if (id > 0) ShowTenantDetails(id);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (lblId.Text == string.Empty) return;
            int shoptId = int.Parse(lblId.Text);
            int id = new Shop().GetNextShopId(shoptId);
            Response.Redirect("ShopInfo.aspx?id=" + id.ToString(), true);
            //if (id > 0) ShowTenantDetails(id);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            this.Clear();
            isNewEntry = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlMarket.SelectedIndex == -1)
                {
                    Alert.Show("দয়া করে মার্কেট নির্ধারণ করুন।");
                    ddlMarket.Focus();
                    return;
                }
                if (txtShopNo.Text==string.Empty)
                {
                    Alert.Show("দয়া করে দোকান/কক্ষ নং প্রদান করুন।");
                    txtShopNo.Focus();
                    return;
                }

                //convert unicode to decimal
                string strMonthlyRent = Encode.HtmlEncode(txtMonthlyRent.Text);
                decimal decMonthlyRent = 0;
                try
                {
                    decMonthlyRent = decimal.Parse(strMonthlyRent);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে সার্ভিস চার্জ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtMonthlyRent.Focus();
                    return;
                }

                string strServcieCharge = Encode.HtmlEncode(txtServiceCharge.Text);
                decimal decServiceCharge = 0;
                try
                {
                    decServiceCharge = decimal.Parse(strServcieCharge);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে সার্ভিস চার্জ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtServiceCharge.Focus();
                    return;
                }

                string strMiscBill = Encode.HtmlEncode(txtMiscBill.Text);
                decimal decMiscBill  = 0;
                try
                {
                    decMiscBill = decimal.Parse(strMiscBill);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে বিবিধ বিল ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtMiscBill.Focus();
                    return;
                }

                string strAdvance = Encode.HtmlEncode(txtAdvance.Text);
                decimal decAdvance = 0;
                try
                {
                    decAdvance = decimal.Parse(strAdvance);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে সার্ভিস চার্জ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtAdvance.Focus();
                    return;
                }

                string strSqFeet= Encode.HtmlEncode(txtArea.Text);
                decimal decSqFeet = 0;
                try
                {
                    decSqFeet = decimal.Parse(strSqFeet);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে জায়গার পরিমাপ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtArea.Focus();
                    return;
                }

                Shop obj=new Shop();

                obj.MarketId = int.Parse(ddlMarket.SelectedValue);
                obj.ShopNo = txtShopNo.Text;
                obj.SpaceInSqFt = decSqFeet;
                obj.MonthlyRent = decMonthlyRent;
                obj.ServiceCharge = decServiceCharge;
                obj.MiscBill = decMiscBill;
                obj.AdvanceAmount = decAdvance;
                obj.ShopType = ddlShopType.SelectedItem.Text;
                obj.CategoryId = int.Parse(ddlShopType.SelectedValue);
                obj.Description = txtDescription.Text;
                
                
                if (!isNewEntry)
                    obj.Id = int.Parse(lblId.Text);
                    
                    
                int count = obj.CheckShopNoExistance(isNewEntry);
                if (count > 0)
                {
                    Alert.Show("This shop no is already exist. Please enter a unique shop no.");
                    txtShopNo.Focus();
                    return;
                }

                int success = 0;

                if (isNewEntry) 
                    success = obj.InsertShop();
                else
                    success = obj.UpdateShop();


                if (success == 1)
                {
                    Alert.Show("তথ্য সংরক্ষণ হয়েছে।");

                    if (isNewEntry)
                    {
                        lblId.Text = obj.GetLastShopId().ToString();
                        isNewEntry = false;
                    }
                }
            }
            catch (Exception ex)
            {
               Alert.Show(ex.Message);
            }
        }

        protected void ddlShopType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShopType.SelectedIndex > 0)
            {
                int categoryId = int.Parse(ddlShopType.SelectedValue);

                ShopCategory shopCategory = new ShopCategory().GetShopCategoryById(categoryId);
                if (shopCategory.Id != 0)
                    txtServiceCharge.Text = shopCategory.ServiceCharge.ToString();
                else
                    txtServiceCharge.Text = "";
            }
        }

        
    }
}