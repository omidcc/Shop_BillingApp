<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="UserRoleInfo.aspx.cs" Inherits="hrms.UserRoleInfo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            width: 159px;
        }

        .auto-style3 {
            color: red;
            text-align: left;
            width: 654px;
        }

        .auto-style6 {
            font-size: small;
            text-align: left;
            padding-right: 10px;
            padding-top: 3px;
            min-width: 80px;
            width: 107px;
        }

        .auto-style8 {
            font-size: small;
            text-align: left;
            padding-right: 10px;
            padding-top: 3px;
            min-width: 80px;
            width: 2px;
        }
        .auto-style9 {
            width: 2px;
        }
        .auto-style192 {
            font-weight: 700;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="mainWrapper">
        <table style="width: 100%;" class="tableFix">
            <tr>
                <td colspan="4">
                    <h1 style="text-align: center" class="HeaderFont">
                        <asp:Literal ID="LitHeader" runat="server" Text="User Roles"></asp:Literal>
                    </h1>
                </td>

            </tr>
          
            <tr>
                <td class="caption">
                    <asp:Literal ID="LitRole" runat="server" Text="Role"></asp:Literal>
                </td>
                <td class="auto-style9">:</td>
                <td class="auto-style1">

                    <telerik:RadTextBox ID="txtRole" runat="server" Skin="Default">
                    </telerik:RadTextBox>

                </td>
                <td class="auto-style3">*<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="save" ControlToValidate="txtRole" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                </td>


            </tr>
            <tr>
                <td class="caption">
                    <asp:Literal ID="LitDescription" runat="server" Text="Description"></asp:Literal>
                </td>
                <td class="auto-style9">:</td>
                <td class="auto-style1">
                    <telerik:RadTextBox ID="txtDescription" runat="server" Skin="Default">
                    </telerik:RadTextBox>
                </td>
                <td class="auto-style3"></td>
            </tr>

            <tr>
                <td class="auto-style6" style="text-align: right">&nbsp;</td>
                <td class="auto-style8" style="text-align: left">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>

            </tr>

            <tr>
                <td class="auto-style6" style="text-align: right">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Height="35px" Skin="Default" Width="135px"></telerik:RadButton>
                    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
                    <%----%>
                </td>
                <td class="auto-style8" style="text-align: left">
                    <%--<asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />--%>
                    
                </td>
                <td>

                    <telerik:RadButton ID="rbtnClear" runat="server" Text="Clear" OnClick="btnClear_Click" Skin="Default" Height="35px" Width="135px"></telerik:RadButton>
                </td>
                <td></td>

            </tr>

            <tr>
                <td colspan="4" style="text-align: left">
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
                    </telerik:RadAjaxManager>
                    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
                        <Scripts>
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
                            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
                        </Scripts>
                    </telerik:RadScriptManager>


                    <telerik:RadGrid ID="dgvUserRole" runat="server" AutoGenerateColumns="False" 
                        CssClass="gridCulture" CellSpacing="0" GridLines="None" AllowPaging="True" 
                        OnPageIndexChanged="dgvUserRole_PageIndexChanged" 
                        OnPageSizeChanged="dgvUserRole_PageSizeChanged" Width="98%" 
                        OnItemCommand="dgvUserRole_ItemCommand">
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
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Role" FilterControlAltText="Filter column column" HeaderText="Role" UniqueName="colRole">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Description" FilterControlAltText="Filter column column" HeaderText="Description" UniqueName="colDesc" Display="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="CompanyId" FilterControlAltText="Filter column column" HeaderText="Company Id" UniqueName="colComId" Display="false">
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
