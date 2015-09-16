<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="ShopList.aspx.cs" Inherits="BillingApplication.ShopList" %>
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
                    <h1>দোকানের তালিকা</h1></td>
                
            </tr>
            <tr>
                <td class="tdCaption">
                    মার্কেট</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:DropDownList ID="ddlMarket" Font-Names="SutonnyMJ" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlMarket_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
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
                                <telerik:GridBoundColumn HeaderText="দোকান/কক্ষ নং" UniqueName="colCategory" DataField="ShopNo">
                                    <ItemStyle HorizontalAlign="Left" Font-Names="SutonnyMJ" Font-Size="11pt" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn 
                                    HeaderText="Id" UniqueName="colCategoryId" DataField="CategoryId" Display="False">
                                    <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="দোকানের ধরন" UniqueName="colServiceCharge" DataField="ShopType">
                                    <ItemStyle HorizontalAlign="Left" Font-Names="SutonnyMJ" Font-Size="11pt" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="জায়গার পরিমাণ" UniqueName="colDesc" DataField="SpaceInSqFt">
                                    <ItemStyle HorizontalAlign="Right" Font-Names="SutonnyMJ" Font-Size="11pt" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="মাসিক ভাড়া" UniqueName="colDesc" DataField="MonthlyRent">
                                    <ItemStyle HorizontalAlign="Right" Font-Names="SutonnyMJ" Font-Size="11pt" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="অগ্রিম" UniqueName="colDesc" DataField="AdvanceAmount">
                                    <ItemStyle HorizontalAlign="Right" Font-Names="SutonnyMJ" Font-Size="11pt" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="সার্ভিস চার্জ" UniqueName="colDesc" DataField="ServiceCharge">
                                    <ItemStyle HorizontalAlign="Right" Font-Names="SutonnyMJ" Font-Size="11pt" />
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


