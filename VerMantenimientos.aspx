<%@ Page Title="" Language="VB" MasterPageFile="~/MPMantenimiento.master" AutoEventWireup="false" CodeFile="VerMantenimientos.aspx.vb" Inherits="VerMantenimientos" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" 
    ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" 
    ToolPanelWidth="200px" Width="1104px" />
<CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    <Report FileName="Mantenimientos.rpt">
    </Report>
</CR:CrystalReportSource>
</asp:Content>

