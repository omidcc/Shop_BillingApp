<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"
    CodeBehind="TenantInfo.aspx.cs" Inherits="BillingApplication.TenantInfo" %>

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
        .tdControl
        {
            width: 60px;
        }
        .style3
        {
            text-align: center;
        }
        .style4
        {
            color: #FFFFFF;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            InitializeDeleteConfirmation();
        });

        function InitializeDeleteConfirmation() {
            $('#deleteConfirmationDialog').dialog({
                autoOpen: false,
                resizable: false,
                height: 140,
                modal: true,
                buttons: {
                    "Delete": function () {
                        $(this).dialog("close");
                    },
                    Cancel: function () {
                        $(this).dialog("close");
                    }
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />

    <div class="mainWrapper">
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="ListViewPanel1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ListViewPanel1"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ListViewPanel2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="ListViewPanel2"></telerik:AjaxUpdatedControl>
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <table class="mainTable">
            <tr class="trHeader">
                <td class="style3" colspan="3" style="background-color: #666699">
                    <h1>
                        ভাড়াটিয়ার তথ্য</h1>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    ভাড়াটিয়ার নাম
                </td>
                <td class="style3">
                    :
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtName" runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    পিতার/স্বামীর নাম
                </td>
                <td class="style3">
                    :
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtFatherName" runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    ঠিকানা
                </td>
                <td class="style3">
                    :
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtAddress" runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    যোগাযোগের তথ্য
                </td>
                <td class="style3">
                    :
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtContactNo" runat="server" Width="303px" Font-Names="SutonnyMJ"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2" colspan="3">
                    <table class="mainTable" border="1" style="border-color: blue; border-style: solid;
                        border: 1px;">
                        <tr>
                            <td class="style10">
                                <table class="style1">
                                    <tr>
                                        <td class="style2">
                                            মার্কেট
                                        </td>
                                        <td class="style2">
                                            দোকান/কক্ষ নং
                                        </td>
                                        <td class="style2">
                                            মাসিক ভাড়া
                                        </td>
                                        <td class="style2">
                                            সার্ভিস চার্জ
                                        </td>
                                        <td class="style2">
                                            বিবিধ বিল
                                        </td>
                                        <td style="text-align: center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdControl">
                                            <asp:DropDownList ID="ddlMarket" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMarket_SelectedIndexChanged"
                                                Font-Names="SutonnyMJ">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblDetailId" runat="server" Visible="False"></asp:Label>
                                        </td>
                                        <td class="tdControl">
                                            <telerik:RadDropDownList ID="ddlShop" runat="server" Font-Names="SutonnyMJ" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlShop_SelectedIndexChanged">
                                            </telerik:RadDropDownList>
                                        </td>
                                        <td class="tdControl">
                                            <telerik:RadTextBox ID="txtMonthlyRent" runat="server" Font-Names="SutonnyMJ">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td class="tdControl">
                                            <telerik:RadTextBox ID="txtServiceCharge" runat="server" Font-Names="SutonnyMJ">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td class="tdControl">
                                            <telerik:RadTextBox ID="txtMiscBill" runat="server" Font-Names="SutonnyMJ">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="style2">
                                            অগ্রিম
                                        </td>
                                        <td class="style2">
                                            চুক্তির শেষ তারিখ
                                        </td>
                                        <td class="style2">
                                            চুক্তির মেয়াদ
                                        </td>
                                        <td class="style2">
                                            পূর্ববর্তী বকেয়া
                                        </td>
                                        <td class="style2" rowspan="2">
                                            <asp:Button ID="btnAddDetail" runat="server" Text="দোকানের তথ্য সংরক্ষণ করুন" OnClick="btnAddDetail_Click"
                                                CssClass="button" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdControl">
                                            <telerik:RadTextBox ID="txtAdvance" runat="server" Font-Names="SutonnyMJ">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td class="tdControl">
                                            <telerik:RadDatePicker runat="server" ID="dtpContractDate" Width="130px" Font-Names="SutonnyMJ">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td class="tdControl">
                                            <telerik:RadTextBox ID="txtContractYear" runat="server" Font-Names="SutonnyMJ">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td class="tdControl">
                                            <telerik:RadTextBox ID="txtPrevDue" runat="server" Font-Names="SutonnyMJ">
                                            </telerik:RadTextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                   
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                <telerik:RadGrid ID="radGrid1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    CellSpacing="0" GridLines="None" OnItemCommand="RadGrid1_ItemCommand">
                                    <MasterTableView>
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="Id" UniqueName="colId" DataField="Id" Display="true"
                                                Visible="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="marketId" UniqueName="colMarketId" DataField="MarketId"
                                                Display="False">
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="মার্কেট" UniqueName="colMarket" DataField="MarketName">
                                                <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="shopId" UniqueName="colShopId" DataField="ShopId"
                                                Display="False">
                                                <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="দোকান/কক্ষ নং" UniqueName="colShopNo" DataField="ShopNo">
                                                <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="মাসিক ভাড়া" UniqueName="colRent" DataField="MonthlyRent">
                                                <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="অগ্রিম" UniqueName="colAdvance" DataField="AdvanceAmount">
                                                <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="সার্ভিস চার্জ" UniqueName="colServiceCharge"
                                                DataField="ServiceCharge">
                                                <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="চুক্তির তারিখ" UniqueName="colContractDate"
                                                DataField="ContractDate">
                                                <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="চুক্তির মেয়াদ" UniqueName="colValidYear" DataField="ContractValidYear">
                                                <ItemStyle Font-Italic="True" Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn HeaderText="পূর্ববর্তী বকেয়া" UniqueName="colPrevDue" DataField="PreviousDue">
                                                <ItemStyle Font-Names="SutonnyMJ" Font-Size="11pt" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridButtonColumn UniqueName="colButton" CommandName="btnSelect" Text="Select">
                                            </telerik:GridButtonColumn>
                                            <telerik:GridButtonColumn CommandName="btnLastBill" FilterControlAltText="Filter column column"
                                                Text="Show Last Bill" UniqueName="column">
                                            </telerik:GridButtonColumn>
                                        </Columns>
                                    </MasterTableView>
                                    <HeaderStyle Font-Bold="True" Font-Size="10pt" />
                                </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Button ID="btnPrev" runat="server" Text="&lt;&lt;" OnClick="btnPrev_Click" CssClass="button"
                        Visible="False" />
                    <asp:Button ID="btnNext" runat="server" Text="&gt;&gt;" OnClick="btnNext_Click" CssClass="button"
                        Visible="False" />
                </td>
                <td class="style3">
                    <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                </td>
                <td style="text-align: center">
                    <asp:Button ID="btnClear" runat="server" Text="তথ্য খালি করুন" OnClick="btnClear_Click"
                        CssClass="button" />
                    <asp:Button ID="btnSave" runat="server" Text="তথ্য সংরক্ষণ করুন" OnClick="btnSave_Click"
                        CssClass="button" />
                </td>
            </tr>
            <tr>
                <td class="style4">
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td style="text-align: center">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td class="style3">
                    &nbsp;
                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
