using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.Bll;
using Telerik.Web.UI;

namespace BillingApplication
{
    public partial class TenantInfo : System.Web.UI.Page
    {
        private  static List<TenantDetails> tenantDetails;
        private static Tenant objTenant;
        private static bool isNewEntry;
        private static bool isNewDetailEntry;

        struct TenantDetails
        {
            public int Id { get; set; }

            public int marketId { get; set; }

            public int shopId { get; set; }
            public string marketName { get; set; }
            public string ShopNo { get; set; }
            public decimal monthlyRent { get; set; }
            public decimal advance { get; set; }
            public decimal serviceCharge { get; set; }
            public DateTime? contractDate { get; set; }
            public int contractValidYear { get; set; }
            public decimal previousDue { get; set; }
            public decimal miscBill { get; set; }

        }

     

        private void LoadGridView()
        {
            if (tenantDetails.Count == 0)
                tenantDetails.Add(new TenantDetails());

            radGrid1.DataSource = tenantDetails;
            radGrid1.DataBind();
        }

        private void LoadMarketDropDown()
        {
            List<Market> objMarketList = new List<Market>();
            Market objMarket = new Market();
            objMarketList = objMarket.GetAllMarket();
            objMarketList.Insert(0, objMarket);

            ddlMarket.DataTextField = "MarketName";
            ddlMarket.DataValueField = "Id";

            ddlMarket.DataSource = objMarketList;
            ddlMarket.DataBind();

            ddlMarket.SelectedIndex = 0;
        }

        private void LoadUnallocatedShopDropDown(int marketId)
        {
            if (marketId == 0) return;

            List<Shop> objShopList = new List<Shop>();
            Shop objShop = new Shop();
            objShopList = objShop.GetAllUnallocatedShopByMarketId(marketId);

            objShopList.Insert(0, objShop);

            ddlShop.DataTextField = "ShopNo";
            ddlShop.DataValueField = "Id";

            ddlShop.DataSource = objShopList;
            ddlShop.DataBind();

            ddlShop.SelectedIndex = -1;
        }

        private void LoadShopDropDown(int marketId)
        {
            if (marketId == 0) return;

            List<Shop> objShopList = new List<Shop>();
            Shop objShop = new Shop();
            objShopList = objShop.GetAllShopByMarketId(marketId);

            objShopList.Insert(0, objShop);

            ddlShop.DataTextField = "ShopNo";
            ddlShop.DataValueField = "Id";

            ddlShop.DataSource = objShopList;
            ddlShop.DataBind();

            ddlShop.SelectedIndex = -1;
        }

        private void ClearDetailSection()
        {
            ddlMarket.SelectedIndex = 0;
            ddlShop.SelectedIndex = 0;
            txtMonthlyRent.Text = "";
            txtServiceCharge.Text = "";
            txtAdvance.Text = "";
            dtpContractDate.SelectedDate = DateTime.Today;
            txtContractYear.Text = "";
            txtPrevDue.Text = "";

            ddlMarket.Focus();
        }

        private void ClearMasterSection()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtFatherName.Text = "";

            dtpContractDate.SelectedDate = DateTime.Today;

            ddlMarket.Focus();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void ShowTenantDetails(int id)
        {
            Tenant tenant = new Tenant().GetTenantById(id);

            lblId.Text = tenant.Id.ToString();
            txtName.Text = tenant.TenantName;
            txtAddress.Text = tenant.Address;
            txtContactNo.Text = tenant.ContactNo;
            txtFatherName.Text = tenant.FathersNames;

            tenantDetails = new List<TenantDetails>();

            DataTable dtMapping = new ShopeMapping().GetShopeMappingByTenantId(tenant.Id);
            if (dtMapping.Rows.Count > 0)
            {
                foreach (DataRow row in dtMapping.Rows)
                {
                    TenantDetails _tenantDetails = new TenantDetails();
                    _tenantDetails.Id = int.Parse(row["Id"].ToString());
                    _tenantDetails.marketId = int.Parse(row["marketId"].ToString());
                    _tenantDetails.marketName = row["marketName"].ToString();
                    this.LoadShopDropDown(_tenantDetails.marketId);
                    _tenantDetails.ShopNo = row["shopNo"].ToString();
                    _tenantDetails.advance = (row["Advance"] == DBNull.Value) ? 0 : decimal.Parse(row["Advance"].ToString());
                    _tenantDetails.contractDate = DateTime.Parse(row["contractDate"].ToString());
                    _tenantDetails.contractValidYear = (row["ContractValidYear"] == DBNull.Value) ? 0 : int.Parse(row["ContractValidYear"].ToString());
                    _tenantDetails.monthlyRent = (row["monthlyRent"] == DBNull.Value) ? 0 : decimal.Parse(row["monthlyRent"].ToString());
                    _tenantDetails.previousDue = (row["PreviousDue"] == DBNull.Value) ? 0 : decimal.Parse(row["PreviousDue"].ToString());
                    _tenantDetails.serviceCharge = (row["serviceCharge"] == DBNull.Value) ? 0 : decimal.Parse(row["serviceCharge"].ToString());
                    _tenantDetails.shopId = int.Parse(row["shopeId"].ToString());
                    _tenantDetails.miscBill = (row["miscBill"] == DBNull.Value) ? 0 : decimal.Parse(row["miscBill"].ToString());

                    tenantDetails.Add(_tenantDetails);
                }

                if (tenantDetails.Count == 1)
                {
                    TenantDetails details = tenantDetails[0];
                    ddlMarket.SelectedValue = details.marketId.ToString();
                    this.LoadShopDropDown(int.Parse(ddlMarket.SelectedValue));
                    ddlShop.SelectedValue = details.shopId.ToString();
                    txtMonthlyRent.Text = details.monthlyRent.ToString();
                    txtAdvance.Text = details.advance.ToString();
                    txtServiceCharge.Text = details.serviceCharge.ToString();
                    dtpContractDate.SelectedDate = details.contractDate;
                    txtContractYear.Text = details.contractValidYear.ToString();
                    txtPrevDue.Text = details.previousDue.ToString();
                    txtMiscBill.Text = details.miscBill.ToString(); 

                    isNewDetailEntry = false;
                    btnAddDetail.Visible = false;
                }
                else
                {
                    btnAddDetail.Visible = true;
                }
            }
            else
            {
                tenantDetails.Add(new TenantDetails());
            }

            this.LoadGridView();
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


            if (!IsPostBack)
            {
                tenantDetails = new List<TenantDetails>();
                objTenant = new Tenant();
                dtpContractDate.SelectedDate = DateTime.Today;
                
                this.LoadShopDropDown(0);
                this.LoadMarketDropDown();
                this.LoadGridView();
                isNewDetailEntry = true;
                isNewEntry = true;

                btnNext.Visible = false;
                btnPrev.Visible = false;

                if (Request.QueryString["id"] != null)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());

                    if (id > 0)
                    {
                        ShowTenantDetails(id);

                        isNewDetailEntry = false;
                        isNewEntry = false;

                        btnNext.Visible = true;
                        btnPrev.Visible = true;
                    }
                }
            }
        }


        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (lblId.Text == string.Empty) return;
            int tenantId = int.Parse(lblId.Text);
            int id = new Tenant().GetPreviousTenantId(tenantId);
            Response.Redirect("TenantInfo.aspx?id=" + id.ToString(), true);

            //if (id > 0) ShowTenantDetails(id);
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (lblId.Text == string.Empty) return;
            int tenantId = int.Parse(lblId.Text);
            int id = new Tenant().GetNextTenantId(tenantId);
            Response.Redirect("TenantInfo.aspx?id=" + id.ToString(), true);
            //if (id > 0) ShowTenantDetails(id);
        }

        protected void btnAddDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlMarket.SelectedIndex <= 0)
                {
                    return;
                }
                if (ddlShop.SelectedIndex <= 0)
                {
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

                string strMiscBill= Encode.HtmlEncode(txtMiscBill.Text);
                decimal decMiscBill = 0;
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
                    Alert.Show("দয়া করে অগ্রিম ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtAdvance.Focus();
                    return;
                }
                string strPrevDue = Encode.HtmlEncode(txtPrevDue.Text);
                decimal decPrevDue = 0;
                try
                {
                    decPrevDue = decimal.Parse(strPrevDue);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে পূর্ববর্তী বকেয়া ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtPrevDue.Focus();
                    return;
                }
                string strYear= Encode.HtmlEncode(txtContractYear.Text);
                int decYear= 0;
                try
                {
                    decYear = int.Parse(strYear);
                }
                catch (Exception ex)
                {
                    Alert.Show("দয়া করে চুক্তির মেয়াদ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                    txtContractYear.Focus();
                    return;
                }


                TenantDetails obj =tenantDetails.Find(x =>x.marketId == int.Parse(ddlMarket.SelectedValue) &&
                            x.shopId == int.Parse(ddlShop.SelectedValue));
                if(obj.marketId==0)
                    obj=new TenantDetails();
                else
                    tenantDetails.Remove(obj);

                obj.marketId = int.Parse(ddlMarket.SelectedValue);
                obj.shopId = int.Parse(ddlShop.SelectedValue);
                obj.marketName = ddlMarket.Text;
                obj.ShopNo = ddlShop.SelectedText;
                obj.contractValidYear = decYear;
                obj.previousDue = decPrevDue;
                obj.monthlyRent = decMonthlyRent;
                obj.serviceCharge = decServiceCharge;
                obj.advance = decAdvance;
                obj.miscBill = decMiscBill;
                obj.contractDate = dtpContractDate.SelectedDate ?? DateTime.Today;
                if(tenantDetails.Count==0 || tenantDetails[0].shopId==0)
                    tenantDetails=new List<TenantDetails>();
                
                tenantDetails.Add(obj);

                LoadGridView();

                ClearDetailSection();
                isNewDetailEntry = true;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                lblMessage.ForeColor = Color.Red;
            }
        }

        protected void RadListView2_ItemDataBound(object sender, Telerik.Web.UI.RadListViewItemEventArgs e)
        {
            //if (e.Item is RadListViewItem)
            //{
            //    RadListViewDataItem item = e.Item as RadListViewDataItem;
            //    object dataItem = ((System.Data.DataRowView)(((RadListViewDataItem)e.Item).DataItem)).Row.ItemArray[2].ToString();
            //    string raetest = Convert.ToString(dataItem);
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == string.Empty)
                {
                    lblMessage.Text = "Please enter the tenant name.";
                    txtName.Focus();
                    return;
                }
                //if (txtFatherName.Text == string.Empty)
                //{
                //    lblMessage.Text = "Please enter the tenant name.";
                //    txtFatherName.Focus();
                //    return;
                //}

                Tenant obj = new Tenant();
               
                obj.TenantName = txtName.Text;
                obj.FathersNames = txtFatherName.Text;
                obj.Address = txtAddress.Text;
                obj.ContactNo = txtContactNo.Text;
                obj.IsActive = true;
                obj.OutstandingAmount = 0;
                obj.NoOfShops = tenantDetails.Count;

                int success = 0;

                if (isNewEntry)
                {
                    obj.Id = new Tenant().GetMaxTenantId();
                    obj.Id = obj.Id + 1; 
                    success = obj.InsertTenant();
                }
                else
                {
                    obj.Id = int.Parse(lblId.Text);
                    success = obj.UpdateTenant();
                }

                if (success == 1)
                {

                    if (tenantDetails.Count == 1)
                    {
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
                        decimal decMiscBill = 0;
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
                            Alert.Show("দয়া করে অগ্রিম ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                            txtAdvance.Focus();
                            return;
                        }
                        string strPrevDue = Encode.HtmlEncode(txtPrevDue.Text);
                        decimal decPrevDue = 0;
                        try
                        {
                            decPrevDue = decimal.Parse(strPrevDue);
                        }
                        catch (Exception ex)
                        {
                            Alert.Show("দয়া করে পূর্ববর্তী বকেয়া ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                            txtPrevDue.Focus();
                            return;
                        }
                        string strYear = Encode.HtmlEncode(txtContractYear.Text);
                        int decYear = 0;
                        try
                        {
                            decYear = int.Parse(strYear);
                        }
                        catch (Exception ex)
                        {
                            Alert.Show("দয়া করে চুক্তির মেয়াদ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।");
                            txtContractYear.Focus();
                            return;
                        }

                        TenantDetails objDetails = tenantDetails.Find(x => x.marketId == int.Parse(ddlMarket.SelectedValue) &&
                           x.shopId == int.Parse(ddlShop.SelectedValue));
                        if (objDetails.marketId == 0)
                            objDetails = new TenantDetails();
                        else
                            tenantDetails.Remove(objDetails);
                       

                        objDetails.marketId = int.Parse(ddlMarket.SelectedValue);
                        objDetails.shopId = int.Parse(ddlShop.SelectedValue);
                        objDetails.marketName = ddlMarket.Text;
                        objDetails.ShopNo = ddlShop.SelectedText;
                        objDetails.contractValidYear = decYear;
                        objDetails.previousDue = decPrevDue;
                        objDetails.monthlyRent = decMonthlyRent;
                        objDetails.serviceCharge = decServiceCharge;
                        objDetails.advance = decAdvance;
                        objDetails.miscBill = decMiscBill;
                        objDetails.contractDate = dtpContractDate.SelectedDate ?? DateTime.Today;
                        if (tenantDetails.Count == 0 || tenantDetails[0].shopId == 0)
                            tenantDetails = new List<TenantDetails>();

                        tenantDetails.Add(objDetails);

                    }
                    //obj = obj.GetTenantById(obj.Id);

                    foreach (TenantDetails tenantDetail in tenantDetails)
                    {
                        ShopeMapping objMapping=new ShopeMapping();
                        objMapping.TenantId = obj.Id;
                        objMapping.MarketId = tenantDetail.marketId;
                        objMapping.ShopeId = tenantDetail.shopId;
                        objMapping.MonthlyRent = tenantDetail.monthlyRent;
                        objMapping.ServiceCharge = tenantDetail.serviceCharge;
                        objMapping.Advance = tenantDetail.advance;
                        objMapping.MiscBill = tenantDetail.miscBill;
                        objMapping.ContractDate = (DateTime) tenantDetail.contractDate;
                        objMapping.ContractValidYear = tenantDetail.contractValidYear;
                        objMapping.PreviousDue = tenantDetail.previousDue;

                        objMapping.Id = new ShopeMapping().GetId(objMapping.TenantId, objMapping.ShopeId);

                        if (objMapping.Id == 0)
                            success = objMapping.InsertShopeMapping();
                        else
                            success = objMapping.UpdateShopeMapping();
                        

                        if (success == 0)
                        {
                            lblMessage.Text ="The tenant information saved successfully, but failed to save shop mapping.";
                            lblMessage.ForeColor = Color.Red;
                            return;
                        }
                       
                    }

                    Alert.Show("Data saved successfully.");

                    lblId.Text = obj.Id.ToString();

                    isNewEntry = false;

                    
                }
            }
            catch (Exception ex)
            {
                
                Alert.Show(ex.Message);
            }
        }

        protected void ddlMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMarket.SelectedIndex > 0)
            {
                int marketId = int.Parse(ddlMarket.SelectedValue);

                this.LoadUnallocatedShopDropDown(marketId);
            }
        }

        protected void ddlShop_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            if (ddlShop.SelectedIndex > 0)
            {
                int shopId = int.Parse(ddlShop.SelectedValue);

                Shop shop = new Shop().GetShopById(shopId);

                txtMonthlyRent.Text = shop.MonthlyRent.ToString();
                txtServiceCharge.Text = shop.ServiceCharge.ToString();
                txtAdvance.Text = shop.AdvanceAmount.ToString();


            }
        }


        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnSelect")
                {
                    GridDataItem item = (GridDataItem)e.Item;
                    
                    
                    
                    ddlMarket.SelectedValue = item["colMarketId"].Text;
                    this.LoadShopDropDown(int.Parse(ddlMarket.SelectedValue));
                    ddlShop.SelectedValue = item["colShopId"].Text;
                    txtMonthlyRent.Text = (item["colRent"] == null || item["colRent"].Text == "&nbsp;") ? "0" : item["colRent"].Text;
                    txtAdvance.Text = (item["colAdvance"] == null || item["colAdvance"].Text == "&nbsp;") ? "0" : item["colAdvance"].Text;
                    txtServiceCharge.Text = (item["colRent"] == null || item["colRent"].Text == "&nbsp;") ? "0" : item["colServiceCharge"].Text;
                    dtpContractDate.SelectedDate = (item["colContractDate"] == null || item["colContractDate"].Text == "&nbsp;") ? DateTime.Now : DateTime.Parse(item["colContractDate"].Text);
                    txtContractYear.Text = (item["colValidYear"] == null || item["colValidYear"].Text == "&nbsp;") ? "0" : item["colValidYear"].Text;
                    txtPrevDue.Text = (item["colPrevDue"] == null || item["colPrevDue"].Text == "&nbsp;") ? "0" : item["colPrevDue"].Text;

                    isNewDetailEntry = false;
                }
                else if (e.CommandName == "btnLastBill")
                {

                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error during leave grid event. Error: " + ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearMasterSection();
            ClearDetailSection();

            tenantDetails = new List<TenantDetails>();
            radGrid1.DataSource = tenantDetails;
            radGrid1.DataBind();

            isNewEntry = true;
            isNewDetailEntry = true;
        }

       
    }
}