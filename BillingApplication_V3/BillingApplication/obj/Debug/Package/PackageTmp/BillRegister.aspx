﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="BillRegister.aspx.cs" Inherits="BillingApplication.BillRegister" %>
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
                    <h1>বিল রেজিস্ট্রার</h1></td>
                
               
                
            </tr>
            <tr>
                <td colspan="4">
                    <table>
                        <tr>
                            <td>
                                
                                <asp:RadioButton ID="rbAll" runat="server" Text="সব তালিকা প্রদর্শন" 
                                    Checked="True" oncheckedchanged="rbAll_CheckedChanged" 
                                    GroupName="ReportType" AutoPostBack="True" />
                                
                            </td>
                            <td>
                                <asp:RadioButton ID="rbPaid" runat="server" Text="আদায় তালিকা প্রদর্শন" 
                                    oncheckedchanged="rbPaid_CheckedChanged" GroupName="ReportType" AutoPostBack="True"/>
                            </td>
                            <td>
                                <asp:RadioButton ID="rbDue" runat="server" Text="বাকি তালিকা প্রদর্শন" 
                                    oncheckedchanged="rbDue_CheckedChanged" GroupName="ReportType" AutoPostBack="True"/>
                            </td>

                        </tr>
                    </table>
                </td>
            </tr>
           <tr>
                <td class="tdCaption" style="width: 80px">
                    মাসের নাম</td>
                <td class="style3">
                    :</td>
                <td class="tdControl" style="width: 26%">
                    <asp:DropDownList ID="ddlMonth" runat="server" Font-Names="SutonnyMJ" AutoPostBack="True" 
                        onselectedindexchanged="ddlMonth_SelectedIndexChanged" >
                    </asp:DropDownList>
                </td>
                <td class="tdControl" rowspan="2">
                    <table>
                        <tr>
                            <td><asp:Button ID="btnPrintAll" runat="server" Height="53px" 
                        style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="সব একসাথে প্রিন্ট করুন" Width="263px"  CssClass="button" OnClick="btnPrintAll_Click" /></td>
                            <td><asp:Button ID="btnPrintSummary" runat="server" Height="53px" 
                        style="font-weight: 700; font-size: large; color: #000066; background-color: #666699;" 
                        Text="সংক্ষিপ্ত রিপোর্ট" Width="263px"  CssClass="button" OnClick="btnPrintSummary_Click" /></td>
                            
                        </tr>

                    </table>
                    
                </td>
            </tr>
            <tr>
                <td class="tdCaption" style="width: 111px">
                    মার্কেট</td>
                <td class="style3">
                    :</td>
                <td class="tdControl" style="width: 26%">
                    <asp:DropDownList ID="ddlMarket" runat="server" Font-Names="SutonnyMJ" AutoPostBack="True" 
                        onselectedindexchanged="ddlMarket_SelectedIndexChanged" 
>
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
                                <telerik:GridBoundColumn 
                                    HeaderText="মার্কেট" UniqueName="column1" DataField="marketName" 
                                    FilterControlAltText="Filter column1 column">
                                    <ItemStyle HorizontalAlign="Left" Font-Names="SutonnyMJ" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="দোকান/কক্ষ নং" UniqueName="colCategory" DataField="ShopNo">
                                    <ItemStyle Font-Names="SutonnyMJ" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ভাড়াটিয়ার নাম" UniqueName="column2" 
                                    DataField="TenantName" FilterControlAltText="Filter column2 column">
                                    <ItemStyle Font-Names="SutonnyMJ" HorizontalAlign="Left" Font-Size="Medium" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="বিলের মাস" UniqueName="column4" 
                                    DataField="BillMonthYear" FilterControlAltText="Filter column4 column">
                                    <ItemStyle Font-Names="SutonnyMJ" HorizontalAlign="Left" />
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
                                <telerik:GridButtonColumn  
                                    UniqueName="colButton" CommandName="btnPrint" Text="প্রিন্ট করুন">
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


