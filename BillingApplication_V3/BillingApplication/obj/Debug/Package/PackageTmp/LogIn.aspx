<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="BillingApplication.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.Core.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQuery.js"></asp:ScriptReference>
            <asp:ScriptReference Assembly="Telerik.Web.UI" Name="Telerik.Web.UI.Common.jQueryInclude.js"></asp:ScriptReference>
        </Scripts>
    </telerik:RadScriptManager>
    <div class="mainWrapper" style="text-align: center;">


        <div class="loginHeader">
            <br>
            
            <p class="headerFont">

                <asp:Literal ID="Literal1" runat="server" Text="User Login" />
            </p>
        </div>

        <div class="loginUser">
            <div>
                <p class="userFont">
                    <asp:Literal ID="ltrlUser" runat="server" Text="User Name" />
                    :
                    <br />
                    <telerik:RadTextBox ID="txtUserName" runat="server" Height="30px" Width="250px" CssClass="textbox" Font-Size="15px">
                    </telerik:RadTextBox>
                </p>
            </div>
            <div>
                <p class="userFont">
                    <asp:Literal ID="ltrlPassword" runat="server" Text="Password" />
                    :
                    <br />
                    <telerik:RadTextBox ID="txtPassword" runat="server" TextMode="Password" Height="30px" Width="250px" CssClass="textbox"  Font-Size="15px"></telerik:RadTextBox>
                </p>
            </div>

            <br />
            <br />
            <div>
                
                            <telerik:RadButton ID="btnLogIn" runat="server" CssClass="loginbutton" text-align="center"  Text="Login" Height="40px" Width="250px" Font-Weight="600" Font-Size="18px" ForeColor="#0f82c2" OnClick="btnLogIn_Click"></telerik:RadButton>

            </div>
            <br />
        </div>




    </div>
</asp:Content>
