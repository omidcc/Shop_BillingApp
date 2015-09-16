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
    public partial class ShopList : System.Web.UI.Page
    {
        private static int userId;
       
        private void LoadGrid(int marketId)
        {
            try
            {
                List<Shop> shops = new List<Shop>();

                if(marketId == 0)
                    shops= new Shop().GetAllShop();
                else
                    shops = new Shop().GetAllShopByMarketIdWithoutTenant(marketId);

                RadGrid1.DataSource = shops;
                RadGrid1.DataBind();
            }
            catch (Exception ex)
            {
                Alert.Show("Error in method 'LoadLeaveDetailsGrid'. Error: " + ex.Message);
            }
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
                
                this.LoadMarketDropDown();
                this.LoadGrid(0);
            }
        }

     
        protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnSelect")
                {
                    GridDataItem item = (GridDataItem) e.Item;
                    int id = int.Parse(item["colId"].Text);
                    
                    if (id!=0)
                        Response.Redirect("ShopInfo.aspx?id="+id.ToString());
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
                int marketId = int.Parse(ddlMarket.SelectedValue);

                this.LoadGrid(marketId);
            }
        }
    }
}