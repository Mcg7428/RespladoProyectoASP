<%@ Page Title="" Language="VB" MasterPageFile="~/Reportes_BackUp.master" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td>
            Archivo a importar</td>
        <td>
            <asp:FileUpload ID="Suvir" runat="server" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            Utilice el formato deerminado</td>
        <td>
            <asp:Button ID="importa" runat="server" Text="Importa" Width="216px" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

