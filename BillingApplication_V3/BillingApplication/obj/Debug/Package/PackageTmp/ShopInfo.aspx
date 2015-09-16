<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="ShopInfo.aspx.cs" Inherits="BillingApplication.ShopInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
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
            <tr class="trHeader">
                <td colspan="3" >
                    <h1>দোকানের তথ্য</h1></td>
            </tr>
            <tr>
                <td class="tdCaption" style="width: 35%">
                    মার্কেট</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:DropDownList ID="ddlMarket"  runat="server" Font-Names="SutonnyMJ">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    দোকান/কক্ষ নং</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtShopNo"
            runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                   দোকানের ধরন</td>
                <td class="style3">
                   :</td>
                <td class="tdControl">
                    <asp:DropDownList runat="server" ID="ddlShopType" AutoPostBack="True" 
                        onselectedindexchanged="ddlShopType_SelectedIndexChanged" Font-Names="SutonnyMJ">
                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    জায়গার পরিমাণ</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtArea"
            runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    মাসিক ভাড়া</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtMonthlyRent"
            runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    অগ্রিম</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtAdvance"
            runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    সার্ভিস চার্জ</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtServiceCharge"
            runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    বিবিধ বিল</td>
                <td >
                    :</td>
                <td class="tdControl">
                    <asp:TextBox runat="server" ID="txtMiscBill" 
                        Font-Names="SutonnyMJ" Culture="en-US" 
                        LabelWidth="64px" Width="303px" ></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td class="tdCaption">
                    দোকানের বিস্তারিত</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtDescription"
            runat="server" Width="303px" Height="47px" TextMode="MultiLine" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Button ID="btnPrev" runat="server"  
                        Text="&lt;&lt;" onclick="btnPrev_Click" CssClass="button" Visible="False" />
                    <asp:Button ID="btnNext" runat="server"  
                        Text="&gt;&gt;" onclick="btnNext_Click" CssClass="button" Visible="False"  />
                </td>
                <td class="style3">
                    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:Button ID="btnSave" runat="server" CssClass="button"  
                        Text="তথ্য সংরক্ষণ করুন" Font-Names="SutonnyMJ" onclick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" CssClass="button"  
                        Text="তথ্য খালি করুন" Font-Names="SutonnyMJ" Width="233px" onclick="btnClear_Click" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>


