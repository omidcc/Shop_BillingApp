<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="GenerateBill.aspx.cs" Inherits="BillingApplication.GenerateBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style2
        {
            text-align: left;
        }
        .tdControl {
            width: 60px;
        }
       
    </style>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.Core.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQuery.js">
            </asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" 
                Name="Telerik.Web.UI.Common.jQueryInclude.js">
            </asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>

    <div class="mainWrapper">
        <table class="mainTable">
            <tr>
                <td class="style5" colspan="3" style="background-color:  #666699">
                    <h1>মাসিক বিল জেনারেট</h1></td>
            </tr>
            <tr>
                <td class="tdCaption">
                    আজকের তারিখ</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtDate"  runat="server">০১/০১/২০১৪</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    মাসের নাম</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:DropDownList ID="ddlMonth" Font-Names="SutonnyMJ" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    মার্কেট</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:DropDownList ID="ddlMarket" runat="server" Font-Names="SutonnyMJ"  AutoPostBack="True"
                        onselectedindexchanged="ddlMarket_SelectedIndexChanged">
                        <asp:ListItem Value="1">হাজীগঞ্জ টাওয়ার</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    বিল প্রদানের শেষ তারিখ</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <telerik:RadDatePicker ID="dtpLastDate" Font-Names="SutonnyMJ" runat="server" Culture="en-US">
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:CheckBox ID="chkPrevDue" runat="server" Font-Names="SutonnyMJ" 
                        Text="পূর্ববর্তী বকেয়া সহ হিসাব করুন" Checked="True" />
                        <asp:CheckBox ID="chkUpdateExisting" runat="server" Font-Names="SutonnyMJ" 
                        Text="বিদ্যমান বিলগুলো প্রতিস্থাপন করুন" Checked="True" />
                </td>
            </tr>
            <tr Visible="False">
                <td style="vertical-align: top;">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    
                    &nbsp;</td>
            </tr>
            <tr id = "tdShopListCaption" runat="server" Visible="False">
                <td style="vertical-align: top;">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td style="text-align: left; padding-left: 12px; font-weight: 700; font-size: large">
                    
                    দোকানের তালিকা</td>
            </tr>
            <tr id = "tdShopList" runat="server" Visible="False">
                <td style="vertical-align: top;">
                    <asp:Button ID="btnSelectAll" runat="server" Height="63px" 
                        style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="সব দোকান নির্বাচন করুন" Width="233px"  
                        Enabled="True" onclick="btnSelectAll_Click" />
                    <asp:Button ID="btnUnSelectall" runat="server" Height="63px" 
                        style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="সব দোকান অনির্বাচন করুন" Width="233px"                         
                        Enabled="True" onclick="btnUnSelectall_Click" />
                    
                    </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    
                    <asp:CheckBoxList ID="cbListShops" runat="server" DataTextField="ShopInfo" 
                        DataValueField="Id" Font-Names="SutonnyMJ" Visible="True" CellPadding="2" 
                        CellSpacing="2" CssClass="checkListBox">
                    </asp:CheckBoxList>
                    
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    </td>
                <td class="style3">
                    </td>
                <td class="style3" style="text-align: left">
                    <asp:Button ID="btnGenerate" runat="server" Height="63px" 
                        style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="মাসের বিল তৈরি করুন" Width="233px" onclick="btnGenerate_Click" Enabled="False" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2" colspan="3">
                    <asp:Literal ID="ltrStatus" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>


