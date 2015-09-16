using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.Bll;
using Telerik.Web.UI;

namespace BillingApplication
{
    public partial class ShopCategoryEntry : System.Web.UI.Page
    {
        private static int userId;
        private static bool isNewEntry;

        private void clear()
        {
            lblId.Text = "";
            txtCategory.Text = "";
            txtDescription.Text = "";
            txtServiceCharge.Text = "";
            txtMiscBill.Text = "";
            isNewEntry = true;

        }

        private void LoadGrid()
        {
            try
            {
                List<ShopCategory> shopCategories = new ShopCategory().GetAllShopCategory();

                RadGrid1.DataSource = shopCategories;
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
                userId = 1;
                
                this.clear();
                this.LoadGrid();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (txtCategory.Text==string.Empty)
                {
                    lblMessage.Text = "দয়া করে দোকানের বিভাগ প্রদান করুন।";
                    lblMessage.ForeColor = Color.Red;
                    txtCategory.Focus();
                    return;
                }
                if (txtServiceCharge.Text == string.Empty)
                {
                    lblMessage.Text = "দয়া করে দোকানের সার্ভিস চার্জ করুন।";
                    lblMessage.ForeColor = Color.Red;
                    txtServiceCharge.Focus();
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
                    lblMessage.Text = "দয়া করে সার্ভিস চার্জ ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।";
                    lblMessage.ForeColor = Color.Red;
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
                    lblMessage.Text = "দয়া করে বিবিধ বিল ফিল্ডে শুধুমাত্র নাম্বার প্রবেশ করুন।";
                    lblMessage.ForeColor = Color.Red;
                    txtMiscBill.Focus();
                    return;
                }


                ShopCategory obj = new ShopCategory();

                obj.Category = txtCategory.Text;
                obj.ServiceCharge = decServiceCharge;
                obj.MiscBill = decMiscBill;
                obj.Description= txtDescription.Text;
                obj.IsActive = true;
                obj.LastModified = DateTime.Now;
                obj.ModifiedBy = userId;


                int success = 0;
                
                if(isNewEntry)
                    success = obj.InsertShopCategory();
                else
                {
                    obj.Id = int.Parse(lblId.Text);
                    success = obj.UpdateShopCategory();
                }

                if (success == 1)
                {
                    Alert.Show("তথ্য সংরক্ষণ হয়েছে।");

                    this.clear();
                    this.LoadGrid();
                    txtCategory.Focus();
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
                if (e.CommandName == "btnSelect")
                {
                    GridDataItem item = (GridDataItem) e.Item;
                    lblId.Text  = item["colId"].Text;
                    txtCategory.Text  = item["colCategory"].Text;
                    txtServiceCharge.Text = item["colServiceCharge"].Text;
                    txtMiscBill.Text = item["colMiscBill"].Text;
                    txtDescription.Text = (item["colDesc"].Text == "&nbsp;") ? "" : item["colDesc"].Text;

                    isNewEntry = false;
                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error during leave grid event. Error: " + ex.Message);
            }
        }
    }
}