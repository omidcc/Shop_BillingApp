<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="TenantList.aspx.cs" Inherits="BillingApplication.TenantList" %>
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
                    <h1>ভাড়াটিয়ার তালিকা</h1></td>
                
            </tr>
            <tr>
                <td class="tdCaption">
                    মার্কেট</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:DropDownList ID="ddlMarket"  runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlMarket_SelectedIndexChanged" Font-Names="SutonnyMJ">
                    </asp:DropDownList>
                </td>
                <td></td>
            </tr>
          <tr>
                <td class="tdCaption">
                    ভাড়াটিয়ার নাম</td>
                <td class="style3">
                    
                    :</td>
                <td class="tdControl">
                    <telerik:RadTextBox ID="txtNameSearch" runat="server" Font-Names="SutonnyMJ">
                    </telerik:RadTextBox>
                    <asp:HiddenField ID="hfConfirmation" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" 
                        CssClass="button-big" onclick="btnSearch_Click" /></td>
            </tr>
            <tr>
                <td class="style4" colspan="4">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" CellSpacing="0" GridLines="None" 
                        onitemcommand="RadGrid1_ItemCommand" style="margin-bottom: 0px" 
                        onitemdatabound="RadGrid1_ItemDataBound">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="">
                                    <ItemTemplate>
                                      <asp:Label ID="numberLabel" runat="server" Width="30px"  Font-Names="SutonnyMJ" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px" />
                                  </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn 
                                    HeaderText="Id" UniqueName="colId" DataField="Id" Display="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ভাড়াটিয়ার নাম" UniqueName="colName" DataField="TenantName">
                                    <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn HeaderText="পিতার/স্বামীর  নাম" 
                                    UniqueName="colFatherNames" DataField="FathersNames">
                                    <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ঠিকানা" UniqueName="colAddress" DataField="Address">
                                    <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="যোগাযোগের তথ্য" UniqueName="colContactInfo" DataField="ContactNo">
                                    <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="" UniqueName="colShopId" Display="False" 
                                    DataField="ShopeId">
                                    
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="দোকান  নং" UniqueName="colShopNo" 
                                    DataField="ShopNo">
                                    <ItemStyle HorizontalAlign="Center" Font-Names="SutonnyMJ" Font-Size="11pt" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="চুক্তির তারিখ" UniqueName="colOutstanding" 
                                    DataField="ContractDate" DataFormatString="{0:d}" DataType="System.Datetime">
                                    <ItemStyle HorizontalAlign="Right" Font-Names="SutonnyMJ" Font-Size="11pt" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridButtonColumn  
                                    UniqueName="colButton" CommandName="btnSelect" Text="বিস্তারিত">
                                    <ItemStyle HorizontalAlign="Justify" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn  
                                    UniqueName="colButton"
                                    CommandName="btnDelete"
                                    ConfirmText="Are you sure you want to delete this record?"
                                    ConfirmDialogType="RadWindow"
                                    ConfirmTitle="Delete"
                                    Text="তথ্য মুছে ফেলুন">
                                    <ItemStyle HorizontalAlign="Justify" />
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn CommandName="btnYearlyReport" 
                                    FilterControlAltText="Filter column column" Text="বাৎসরিক হিসাব" 
                                    UniqueName="column">
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn DataField="ShopeId" 
                                    FilterControlAltText="Filter colShopId column" HeaderText="shopId" 
                                    UniqueName="colShopId" Visible="False">
                                </telerik:GridBoundColumn>
                                
                            </Columns>
                        </MasterTableView>
                        <HeaderStyle Font-Bold="True" Font-Size="10pt" />
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
       
    </div>
</asp:Content>


