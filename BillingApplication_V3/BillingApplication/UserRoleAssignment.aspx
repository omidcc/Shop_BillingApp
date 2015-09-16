<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="UserRoleAssignment.aspx.cs" Inherits="BillingApplication.UserRoleAssignment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            font-size: small;
            text-align: left;
            padding-right: 10px;
            padding-top: 3px;
            min-width: 80px;
            height: 22px;
        }
        .auto-style2 {
            height: 22px;
        }
        .auto-style3 {
            text-align: left;
            height: 22px;
        }
        .auto-style4 {
            color: red;
            text-align: left;
            height: 22px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    </telerik:RadAjaxManager>

    <div class="mainWrapper">
        <table style="width: 100%;" class="tableFix">
            <tr>
                <td colspan="9">
                    <h1 style="text-align: center" class="HeaderFont">
                        <asp:Literal ID="LitHeader" runat="server" Text="Usre Role Assignment"></asp:Literal>
                    </h1>
                </td>

            </tr>
            
            <tr>
                <td class="caption">
                    <asp:Literal ID="LitType" runat="server" Text="Type"></asp:Literal>
                </td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">

                    <telerik:RadDropDownList ID="rdeopType" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="rdeopType_SelectedIndexChanged" Skin="Default" 
                        ValidationGroup="type">
                        <Items>
                            <telerik:DropDownListItem runat="server" Text="---Select One---" />
                            <telerik:DropDownListItem runat="server" Text="Role" Value="Role" />
                            <telerik:DropDownListItem runat="server" Text="Users" Value="Users" />
                        </Items>
                    </telerik:RadDropDownList>

                </td>
                <td class="auto-style4">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="rdeopType" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style2"></td>
                <td class="caption">
                    <asp:Literal ID="LitRoleUserList" runat="server" Text="Users"></asp:Literal>
                </td>
                <td class="auto-style2">:</td>
                <td class="auto-style3">
                    <telerik:RadDropDownList ID="rdropList" runat="server" ValidationGroup="list" 
                        AutoPostBack="True" Skin="Default" 
                        OnSelectedIndexChanged="rdropList_SelectedIndexChanged"></telerik:RadDropDownList>
                </td>
                <td class="auto-style4">*<asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="rdropList" runat="server" ErrorMessage="RequiredFieldValidator" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="caption"></td>
                <td></td>
                <td></td>
                <td class="validation"></td>
                <td>&nbsp;</td>
                <td class="caption"></td>
                <td></td>
                <td></td>
                <td class="validation">&nbsp;</td>
            </tr>

            <tr>
                <td class="caption"></td>
                <td></td>
                <td></td>
                <td class="validation"></td>
                <td>&nbsp;</td>
                <td class="caption" style="text-align: right"></td>
                <td></td>
                <td style="text-align: left"></td>
                <td class="validation"></td>
            </tr>

            <tr>
                <td colspan="4" style="text-align: right">
                    <asp:HiddenField ID="HFDayNo" runat="server" />
                </td>

                <td>&nbsp;</td>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: right">&nbsp;</td>

                <td>&nbsp;</td>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="9" style="text-align: left">
                    <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                    </telerik:RadAjaxManager>
                    <telerik:RadScriptManager ID="RadScriptManager2" runat="server">
                        <Scripts>
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
                        </Scripts>
                    </telerik:RadScriptManager>

                    <telerik:RadGrid ID="RadGridAppFunction" runat="server" AllowFilteringByColumn="True" CssClass="gridCulture" AllowSorting="True" AutoGenerateColumns="False" CellSpacing="0" GridLines="None" ShowGroupPanel="False" Skin="Metro" Width="90%">
                        <ClientSettings AllowDragToGroup="True">
                            <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                        </ClientSettings>

                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <Columns>
                                <telerik:GridBoundColumn DataField="PermitionId" FilterControlAltText="Filter column column" HeaderText="Permission Id" UniqueName="colPerId" Display="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Id" FilterControlAltText="Filter column column" HeaderText="Id" UniqueName="colId" Display="False">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Functionality" HeaderText="Functionality Name" ColumnEditorID="GridTextBoxEditor" >
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn DataField="IsInsert" HeaderText="Save" ColumnEditorID="GridTextBoxEditor">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsInsert" runat="server" Checked='<%#Eval("IsInsert") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="IsUpdate" HeaderText="Update" ColumnEditorID="GridTextBoxEditor">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsUpdate" runat="server" Checked='<%#Eval("IsUpdate") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="IsDelete" HeaderText="Delete" ColumnEditorID="GridTextBoxEditor">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsDelete" runat="server" Checked='<%#Eval("IsDelete") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="IsView" HeaderText="View" ColumnEditorID="GridTextBoxEditor">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsView" runat="server" Checked='<%#Eval("IsView") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn DataField="IsApprove" HeaderText="Approve" ColumnEditorID="GridTextBoxEditor">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsApprove" runat="server" Checked='<%#Eval("IsApprove") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>

                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>

                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>

                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                            </EditFormSettings>

                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>

                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

                        <FilterMenu EnableImageSprites="False"></FilterMenu>
                    </telerik:RadGrid>

                </td>

            </tr>
            <tr>
                <td colspan="4" style="text-align: right">
                    <%-- <telerik:RadButton ID="rbtnClear" runat="server" Height="25px" Text="Clear" Width="90px">
                    </telerik:RadButton>--%>
                    <telerik:RadButton ID="rbtnSave" runat="server" Text="Save" OnClick="btnSave_Click" Skin="Metro" Height="35px" Width="145px"></telerik:RadButton>
                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                    <telerik:RadButton ID="rbtnClear" runat="server" Text="Clear" Height="35px" Skin="Metro" Width="135px"></telerik:RadButton>
                    <%--  <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />--%>
                </td>

                <td>&nbsp;</td>
                <td colspan="4">
                    <%--<asp:Button ID="btnClear" runat="server" Text="Clear" />--%>
                </td>
            </tr>
        </table>

    </div>


</asp:Content>
