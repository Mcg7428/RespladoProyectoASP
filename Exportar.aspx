<%@ Page Title="" Language="VB" MasterPageFile="~/Reportes_BackUp.master" AutoEventWireup="false" CodeFile="Exportar.aspx.vb" Inherits="Exportar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td class="style1" style="width: 144px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" style="width: 144px">
            Archivo a exportar</td>
        <td>
            <asp:FileUpload ID="Suvir" runat="server" Width="266px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" style="width: 144px">
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" style="margin-left: 0px" 
                Text="Exportar" Width="260px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

