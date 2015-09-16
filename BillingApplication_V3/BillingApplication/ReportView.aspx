<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportView.aspx.cs" Inherits="BillingApplication.ReportView" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Report Viewer</title>
</head>
<body>
    <div style="Width:auto;"> 
    <form id="form1" runat="server" style="width:12in; height:9in;">
        <asp:scriptmanager ID="scriptmgr" runat="server"></asp:scriptmanager>

        <rsweb:ReportViewer ID="rptViewer" runat="server" ZoomMode="FullPage"
             Height="100%"  SizeToReportContent="true" DocumentMapWidth="100%" Width="100%" ZoomPercent="75" PageCountMode="Actual"></rsweb:ReportViewer>
    
    </form>
</div>
</body>
</html>
