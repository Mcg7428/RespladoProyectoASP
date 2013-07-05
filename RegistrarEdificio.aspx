<%@ Page Title="" Language="VB" MasterPageFile="~/Inmuebles.master" AutoEventWireup="false" CodeFile="RegistrarEdificio.aspx.vb" Inherits="RegistrarEdificio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder14" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td style="width: 142px">
                Registrar Edifcio</td>
            <td style="width: 183px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 142px; height: 20px">
                ID_Edificio</td>
            <td style="height: 20px; width: 183px">
                <asp:TextBox ID="TextBox1" runat="server" Width="170px"></asp:TextBox>
            </td>
            <td style="height: 20px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="Fromato Incorrecto" 
                    ValidationExpression="[A-Z]{2}[0-9]{1,3}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Nombre</td>
            <td style="width: 183px">
                <asp:TextBox ID="TextBox2" runat="server" Width="170px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Campo Requerido" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Ubicacion</td>
            <td style="width: 183px">
                <asp:TextBox ID="TextBox3" runat="server" Height="22px" Width="170px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Campo Requerido" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Descripcion</td>
            <td style="width: 183px">
                <asp:TextBox ID="TextBox4" runat="server" Width="170px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Campo Requerido" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                &nbsp;</td>
            <td style="width: 183px">
                <asp:Button ID="Button1" runat="server" Text="Registrar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

