<%@ Page Title="" Language="VB" MasterPageFile="~/Inmuebles.master" AutoEventWireup="false" CodeFile="RegistroLaboratorio.aspx.vb" Inherits="RegistroLaboratorio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder14" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td colspan="3">
            Registro Laboratorio</td>
    </tr>
    <tr>
        <td class="style1" style="width: 100px">
            Identificador de Laboratorio</td>
        <td style="width: 192px">
            <asp:TextBox ID="TextBox3" runat="server" Height="23px" Width="176px"></asp:TextBox>
        </td>
        <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="TextBox3" ErrorMessage="error" 
                ValidationExpression="[LA]{2}[0-9]{1,3}"></asp:RegularExpressionValidator>
        </td>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox3" ErrorMessage="Formato Erroneo" 
                ValidationExpression="[LA]{2}[0-9]{1,3}"></asp:RegularExpressionValidator>
        </td>

    </tr>
    <tr>
        <td class="style1" style="width: 100px">
            Nombre Laboratorio</td>
        <td style="width: 192px">
            <asp:TextBox ID="TextBox4" runat="server" Width="175px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Campo Requerido" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1" style="width: 100px">
                Departamento</td>
        <td style="width: 192px">
            <asp:DropDownList ID="DropDownList1" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="ID_DEPTO" 
                DataValueField="ID_DEPTO">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT [ID_DEPTO] FROM [Departamento]"></asp:SqlDataSource>
        </td>
        <td>
                &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" style="width: 100px">
                &nbsp;</td>
        <td style="width: 192px">
            <asp:Button ID="Button1" runat="server" Text="Registrar" />
        </td>
        <td>
                &nbsp;</td>
    </tr>
</table>
</asp:Content>

