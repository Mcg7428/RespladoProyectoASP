<%@ Page Title="" Language="VB" MasterPageFile="~/MPMantenimiento.master" AutoEventWireup="false" CodeFile="CrearSubTarea.aspx.vb" Inherits="CrearSubTarea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td colspan="3">
            Creacion de Sub Tarea</td>
    </tr>
    <tr>
        <td class="style1" style="width: 110px">
            Descripcion</td>
        <td style="width: 231px">
            <asp:TextBox ID="TextBox4" runat="server" Height="19px" 
                style="margin-left: 0px" TextMode="MultiLine" Width="193px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="TextBox4" ErrorMessage="Descripcion Requerida"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1" style="width: 110px">
            &nbsp;</td>
        <td style="width: 231px">
            <asp:Button ID="Button2" runat="server" Text="Crear" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

