<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="DueInstallmentSetup.aspx.cs" Inherits="BillingApplication.DueInstallmentSetup" %>
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
                    <h1>বকেয়া প্রদানের হিসাব</h1></td>
            </tr>
            <tr>
                <td class="tdCaption">
                    মার্কেট</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:DropDownList ID="ddlMarket" runat="server"  Font-Names="SutonnyMJ" AutoPostBack="True" Enabled="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    ভাড়াটিয়ার নাম</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtTenantName"
            runat="server" Width="303px" Font-Names="SutonnyMJ" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    দোকান/কক্ষ নং</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtShopNo"
            runat="server" Width="303px" Font-Names="SutonnyMJ" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    মাসিক ভাড়া</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtMonthlyRent"
            runat="server" Width="303px" Font-Names="SutonnyMJ" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    সার্ভিস চার্জ</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtServiceCharge"
            runat="server" Width="303px" Font-Names="SutonnyMJ" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    বিবিধ বিল</td>
                <td >
                    :</td>
                <td class="tdControl">
                    <telerik:RadTextBox runat="server" ID="txtMiscBill" 
                        Font-Names="SutonnyMJ" Culture="en-US" 
                        DbValueFactor="1" LabelWidth="64px" Width="303px" BorderStyle="Solid" 
                        BorderWidth="1px" Enabled="False"></telerik:RadTextBox>
                </td>
                
            </tr>
            <tr>
                <td class="tdCaption">
                    মোট বকেয়া</td>
                <td >
                    :</td>
                <td class="tdControl">
                    <telerik:RadTextBox runat="server" ID="txtTotalDue" 
                        Font-Names="SutonnyMJ" Culture="en-US" 
                        DbValueFactor="1" LabelWidth="64px" Width="303px" BorderStyle="Solid" 
                        BorderWidth="1px" Enabled="True"></telerik:RadTextBox>
                </td>
                
            </tr>
           <tr>
                <td class="tdCaption">
                    কিস্তির সংখ্যা</td>
                <td >
                    :</td>
                <td class="tdControl">
                    <telerik:RadTextBox runat="server" ID="txtInstallmentNo" 
                        Font-Names="SutonnyMJ" Culture="en-US" 
                        DbValueFactor="1" LabelWidth="64px" Width="303px" BorderStyle="Solid" 
                        BorderWidth="1px" ontextchanged="txtInstallmentNo_TextChanged" AutoPostBack="True"
                        Resize="None"></telerik:RadTextBox>
                </td>
                
            </tr>
            <tr>
                <td class="tdCaption">
                    কিস্তির পরিমাণ</td>
                <td >
                    :</td>
                <td class="tdControl">
                    <telerik:RadTextBox runat="server" ID="txtInstallmentAmount" 
                        Font-Names="SutonnyMJ" Culture="en-US" 
                        DbValueFactor="1" LabelWidth="64px" Width="303px" BorderStyle="Solid" 
                        BorderWidth="1px"></telerik:RadTextBox>
                </td>
                
            </tr>
            <tr>
                <td class="tdCaption">
                    কিস্তি শুরুর মাস</td>
                <td class="style3">
                    :</td>
                <td class="tdControl" style="width: 26%">
                    <asp:DropDownList ID="ddlMonth" runat="server">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblTenantId" runat="server" Visible="False"></asp:Label>
                    <asp:Label ID="lblShopId" runat="server" Visible="False"></asp:Label>

                </td>
                <td style="text-align: left">
                    <asp:Button ID="btnSave" runat="server" Height="53px" 
                        style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="তথ্য সংরক্ষণ করুন" Font-Names="SutonnyMJ" Width="233px" onclick="btnSave_Click" CssClass="button" />
                    <asp:Button ID="btnClear" runat="server" Height="53px" 
                        style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="বকেয়া তালিকা" Font-Names="SutonnyMJ" Width="233px" onclick="btnClear_Click" CssClass="button" />
                </td>
            </tr>
        </table>
        <br />
        <br />
    </div>
</asp:Content>


