<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="ShopCategoryEntry.aspx.cs" Inherits="BillingApplication.ShopCategoryEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>

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
                <td colspan="4">
                    <h1>দোকানের শ্রেণী বিভাগ</h1></td>
                
            </tr>
            <tr>
                <td class="tdCaption">
                    বিভাগ</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <telerik:RadTextBox runat="server" ID="txtCategory" Font-Names="SutonnyMJ" Width="303px"></telerik:RadTextBox>
                     
                </td>
                <td class="tdControl">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCategory" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                     </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    সার্ভিস চার্জ</td>
                <td >
                    :</td>
                <td class="tdControl">
                    <telerik:RadTextBox runat="server" ID="txtServiceCharge" Font-Names="SutonnyMJ" Culture="en-US" 
                        DbValueFactor="1" LabelWidth="64px" Width="303px" BorderStyle="Solid" 
                        BorderWidth="1px"></telerik:RadTextBox>
                </td>
                <td class="tdControl">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtServiceCharge" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator></td>
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
                        BorderWidth="1px"></telerik:RadTextBox>
                </td>
                <td class="tdControl">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="tdCaption">
                    বিস্তারিত</td>
                <td >
                    :</td>
                <td class="tdControl">
                    <telerik:RadTextBox  Font-Names="SutonnyMJ" runat="server" ID="txtDescription"  Width="303px" Height="47px" TextMode="MultiLine"></telerik:RadTextBox>
                </td>
                <td class="tdControl">
                    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td style="text-align: left">
                    <asp:Button ID="btnSave" runat="server" Height="63px" 
                        style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="তথ্য সংরক্ষণ করুন" Width="283px" onclick="btnSave_Click" 
                        CssClass="button" />
                </td>
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
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style4" colspan="4">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" CellSpacing="0" GridLines="None" 
                        onitemcommand="RadGrid1_ItemCommand">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn 
                                    HeaderText="Id" UniqueName="colId" DataField="Id" Display="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="বিভাগ" UniqueName="colCategory" DataField="Category">
                                    <ItemStyle HorizontalAlign="Left" Font-Names="SutonnyMJ" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="সার্ভিস চার্জ" UniqueName="colServiceCharge" DataField="ServiceCharge">
                                    <ItemStyle HorizontalAlign="Right" Font-Names="SutonnyMJ" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="বিবিধ বিল" UniqueName="colMiscBill" DataField="MiscBill">
                                    <ItemStyle HorizontalAlign="Right" Font-Names="SutonnyMJ" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="বিস্তারিত" UniqueName="colDesc" DataField="Description">
                                    <ItemStyle HorizontalAlign="Left" Font-Names="SutonnyMJ" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn  
                                    UniqueName="colButton" CommandName="btnSelect" Text="Select">
                                    <ItemStyle HorizontalAlign="Justify" />
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                        <HeaderStyle Font-Bold="True" Font-Size="10pt" />
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
       
    </div>
</asp:Content>


