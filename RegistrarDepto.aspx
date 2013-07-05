<%@ Page Title="" Language="VB" MasterPageFile="~/Inmuebles.master" AutoEventWireup="false" CodeFile="RegistrarDepto.aspx.vb" Inherits="RegistrarDepto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder14" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td colspan="3" style="height: 23px">
            Registro Departamento</td>
    </tr>
    <tr>
        <td style="width: 148px">
            ID_Departamento</td>
        <td style="width: 180px">
            <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="176px"></asp:TextBox>
        </td>
        <td>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="TextBox1" ErrorMessage="Formato No Valido" 
                ValidationExpression="[A-Z]{2}[0-9]{1,3}"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 148px">
            Nombre Departamento</td>
        <td style="width: 180px">
            <asp:TextBox ID="TextBox2" runat="server" Height="19px" Width="176px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 148px; height: 92px;">
            Edificio de Ubicacion</td>
        <td style="width: 180px; height: 92px;">
            <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="177px" 
                DataSourceID="SqlDataSource1" DataTextField="ID_EDIFICIO" 
                DataValueField="ID_EDIFICIO">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT [ID_EDIFICIO] FROM [Edificio]"></asp:SqlDataSource>
        </td>
        <td style="height: 92px">
            </td>
    </tr>
    <tr>
        <td style="width: 148px">
            &nbsp;</td>
        <td style="width: 180px">
            <asp:Button ID="Button1" runat="server" Text="Registrar" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

