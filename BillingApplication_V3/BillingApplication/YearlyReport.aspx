<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="YearlyReport.aspx.cs" Inherits="BillingApplication.YearlyReport" %>
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
                    <h1>ভাড়াটিয়ার বাৎসরিক হিসাব বিবরণী</h1></td>
                
                <td>
                    &nbsp;</td>
                
            </tr>
           
            <tr>
                <td class="tdCaption" colspan="4">
                    <table width="100%"><tr>
                <td class="style1">
                    বছর</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:DropDownList ID="ddlYear" Font-Names="SutonnyMJ" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlYear_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
                        <tr>
                <td class="tdCaption">
                                            মার্কেট</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtMarket"
            runat="server" Width="303px" Font-Names="SutonnyMJ" Enabled="False"></asp:TextBox>
                </td>
            </tr>
                        <tr>
                <td class="tdCaption">
                    ভাড়াটিয়ার নাম</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtName"
            runat="server" Width="303px" Font-Names="SutonnyMJ" Enabled="False"></asp:TextBox>
                    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    পিতার নাম</td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtFatherName"
            runat="server" Width="303px" Font-Names="SutonnyMJ" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdCaption">
                    ঠিকানা </td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtAddress"
            runat="server" Width="303px" Font-Names="SutonnyMJ" Enabled="False"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="tdCaption">
                    যোগাযোগের তথ্য </td>
                <td class="style3">
                    :</td>
                <td class="tdControl">
                    <asp:TextBox ID="txtContactNo"
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
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="tdControl">
                    &nbsp;</td>
            </tr>
             <tr>
                <td class="tdCaption">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="tdControl">
                    <asp:Button ID="btnPrintAll" runat="server" style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="প্রিন্ট করুন" Width="263px"  CssClass="button" OnClick="btnPrintAll_Click" />
                </td>
            </tr></table>
                    </td>
            </tr>
          
            <tr>
                <td class="style4" colspan="5">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AllowSorting="True" 
                        AutoGenerateColumns="False" CellSpacing="0" GridLines="None" 
                        >
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="monthName" 
                                    FilterControlAltText="Filter column5 column" HeaderText="মাসের নাম" 
                                    UniqueName="column5">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BillNo" 
                                    FilterControlAltText="Filter column5 column" HeaderText="বিল নং" 
                                    UniqueName="column5">
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="মাসিক ভাড়া" UniqueName="colDesc" DataField="MonthlyRent">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="সার্ভিস চার্জ" UniqueName="colDesc" DataField="ServiceCharge">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn HeaderText="বিবিধ বিল" UniqueName="column" 
                                    DataField="MiscBills" FilterControlAltText="Filter column column">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PreviousDue" 
                                    FilterControlAltText="Filter column6 column" HeaderText="পূর্ববর্তী বকেয়া" 
                                    UniqueName="column6">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="LateFee" 
                                    FilterControlAltText="Filter column7 column" HeaderText="বিলম্ব মাশুল" 
                                    UniqueName="column7">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="TotalAmountAfterLateFee" 
                                    FilterControlAltText="Filter column8 column" HeaderText="সর্বমোট" 
                                    UniqueName="column8">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Payment" 
                                    FilterControlAltText="Filter column9 column" HeaderText="পেমেন্ট" 
                                    UniqueName="column9">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Due" 
                                    FilterControlAltText="Filter column10 column" HeaderText="বকেয়া" 
                                    UniqueName="column10">
                                    <ItemStyle HorizontalAlign="Right" />
                                </telerik:GridBoundColumn>
                                
                            </Columns>
                        </MasterTableView>
                        <HeaderStyle Font-Bold="True" Font-Size="10pt" />
                    </telerik:RadGrid>
                </td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
        </table>
       
    </div>
</asp:Content>


