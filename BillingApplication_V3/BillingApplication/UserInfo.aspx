<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="BillingApplication.UserInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .list-panel {
            position: relative;
        }

        .RadListBox {
            margin: 0 auto !important;
            top: 0px;
            left: 0px;
            width: 224px;
        }

        .getCheckedItems {
            left: 300px;
            position: absolute;
            top: 0px;
        }

        .auto-style6 {
            color: red;
            text-align: left;
            width: 40px;
        }

        .auto-style7 {
            width: 4px;
        }

        .auto-style8 {
            font-size: small;
            text-align: left;
            padding-right: 10px;
            padding-top: 3px;
            min-width: 80px;
            width: 91px;
        }

        .auto-style9 {
            font-size: small;
            text-align: left;
            padding-right: 10px;
            padding-top: 3px;
            min-width: 30px;
            width: 91px;
        }

        .auto-style14 {
            width: 91px;
        }

        .auto-style15 {
            text-align: left;
            width: 119px;
        }

        .auto-style16 {
            color: red;
            text-align: left;
            width: 7px;
        }

        .auto-style17 {
            font-size: small;
            text-align: left;
            padding-right: 10px;
            padding-top: 3px;
            min-width: 80px;
            width: 628px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <div class="mainWrapper">
        <table style="width: 100%;" class="tableFix">
            <%-- <tr>
                <td class="caption" style="text-align: right">Company Name
                </td>
                <td>:</td>
                <td style="text-align: left">
                    <telerik:RadComboBox ID="rdropCompany" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdropCompany_SelectedIndexChanged"></telerik:RadComboBox>
                </td>
            </tr>--%>
            <tr>
                <td colspan="9"></td>
            </tr>
        </table>
    </div>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div class="mainWrapper">
        <table style="width: 100%;">
            <tr>
                <td colspan="2">
                    <h1 style="text-align: center" class="HeaderFont">
                        <asp:Literal ID="LitHeader" runat="server" Text="User Information"></asp:Literal>
                    </h1>
                </td>

            </tr>
            <tr>
                <td class="auto-style17">
                    <table style="width: 70%;">

                       
                        <tr>
                            <td class="caption">
                                <asp:Literal ID="LitEmpRef" runat="server" Text="Employee Name"></asp:Literal>
                            </td>
                            <td class="auto-style7">:</td>
                            <td class="auto-style15">

                                <telerik:RadTextBox ID="rtxtEmpName" runat="server" Skin="Default"></telerik:RadTextBox>

                            </td>
                            <td class="auto-style16"></td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                        </tr>
                        <tr>
                            <td class="caption">
                                <asp:Literal ID="LitUserName" runat="server" Text="User Name"></asp:Literal>
                            </td>
                            <td class="auto-style7">:</td>
                            <td class="auto-style15">

                                <telerik:RadTextBox ID="txtUserName" runat="server" ValidationGroup="Save" Skin="Default">
                                </telerik:RadTextBox>

                            </td>
                            <td class="auto-style16">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                        </tr>
                        <tr>
                            <td class="caption">
                                <asp:Literal ID="LitPassword" runat="server" Text="Password"></asp:Literal>
                            </td>
                            <td class="auto-style7">:</td>
                            <td class="auto-style15">

                                <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password" 
                                    ValidationGroup="Save" Skin="Default">
                                </telerik:RadTextBox>

                            </td>
                            <td class="auto-style16">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                        </tr>


                        <tr>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                            <td style="text-align: left" class="caption">

                                <asp:CheckBox ID="chkIsActive" runat="server" Checked="true" Text="IsActive" />

                            </td>
                            <td class="auto-style16">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                        </tr>


                        <tr>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                            <td style="text-align: left" class="auto-style15">&nbsp;</td>
                            <td class="auto-style16">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                        </tr>


                        <tr>
                            <td class="auto-style8" style="text-align: right">
                                <telerik:RadButton ID="rbtnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Save" Skin="Default" Height="35px" Width="145px"></telerik:RadButton>
                            </td>
                            <td class="auto-style7">&nbsp;</td>
                            <td style="text-align: left" class="auto-style15">
                                <telerik:RadButton ID="RadButton1" runat="server" Text="Clear" OnClick="btnClear_Click" Skin="Default" Height="35px" Width="135px"></telerik:RadButton>
                            </td>
                            <td class="auto-style16">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                            <td class="auto-style6">&nbsp;</td>

                        </tr>

                        <tr>
                            <td colspan="4" style="text-align: center" class="controls">
                                <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                                <%--  <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Save" />--%>
                            </td>

                            <td style="text-align: center" class="controls">&nbsp;</td>

                            <td style="text-align: center" class="controls">&nbsp;</td>

                            <td style="text-align: center" class="controls">&nbsp;</td>

                        </tr>
                    </table>
                </td>
                <td>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: left" class="caption">
                                <asp:Literal ID="LitUserRole" runat="server" Text="User Roles"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <telerik:RadAjaxPanel runat="server" ID="RadAjaxPanel1">
                                    <div class="list-panel">
                                        <telerik:RadListBox ID="lbRole" runat="server" CheckBoxes="True" ShowCheckAll="True" 
                                            Height="200px" Skin="Default" Width="200px">
                                            <Items>
                                                <telerik:RadListBoxItem Text="Super"></telerik:RadListBoxItem>

                                            </Items>
                                        </telerik:RadListBox>
                                    </div>
                                </telerik:RadAjaxPanel>

                                <telerik:RadTextBox ID="RadTextBox1" Runat="server">
                                </telerik:RadTextBox>

                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <telerik:RadGrid ID="dgvUser" runat="server" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" CssClass="gridCulture" AllowPaging="True" OnPageIndexChanged="dgvUser_PageIndexChanged" OnPageSizeChanged="dgvUser_PageSizeChanged" Skin="Default" Width="98%" OnItemCommand="dgvUser_ItemCommand">
                        <ClientSettings AllowColumnsReorder="false" AllowDragToGroup="false" ReorderColumnsOnClient="false">
                        </ClientSettings>
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>


                                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter column column" HeaderText="Id" UniqueName="colId" Display="false">
                                    <ColumnValidationSettings>
                                        
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UserName" FilterControlAltText="Filter column column" HeaderText="User Name" UniqueName="colName">
                                    <ColumnValidationSettings>
                                        
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="UserPass" FilterControlAltText="Filter column column" HeaderText="Password" UniqueName="colPass" Display="false">
                                    <ColumnValidationSettings>
                                        
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EmployeeId" FilterControlAltText="Filter column column" HeaderText="Emp ID" UniqueName="colEmpId" Display="false">
                                    <ColumnValidationSettings>
                                        
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="EmpName" FilterControlAltText="Filter column column" HeaderText="Employee Ref" UniqueName="colEmployee">
                                    <ColumnValidationSettings>
                                        
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CompanyId" FilterControlAltText="Filter column column" HeaderText="comp Id" UniqueName="colCompId" Display="false">
                                    <ColumnValidationSettings>
                                        
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CompanyName" FilterControlAltText="Filter column column" HeaderText="Company" UniqueName="colCompany">
                                    <ColumnValidationSettings>
                                        
                                    </ColumnValidationSettings>
                                </telerik:GridBoundColumn>

                                <telerik:GridButtonColumn
                                    CommandName="btnSelect"
                                    HeaderText=""
                                    SortExpression=""
                                    Text="Select"
                                    ButtonType="LinkButton">
                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn
                                    CommandName="btnDelete"
                                    HeaderText=""
                                    SortExpression=""
                                    Text="Delete"
                                    ButtonType="LinkButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" Position="Bottom" Mode="NextPrevAndNumeric"></PagerStyle>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>


    </div>
   
</asp:Content>
