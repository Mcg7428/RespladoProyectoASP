<%@ Page Title="" Language="VB" MasterPageFile="~/Equipos.master" AutoEventWireup="false" CodeFile="EliminarActualizaEquipo.aspx.vb" Inherits="EliminarActualizaEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder15" Runat="Server">
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style1" style="width: 109px">
                    Modificacion
                </td>
                <td style="width: 181px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 109px">
                    ID Equipo</td>
                <td style="width: 181px">
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        DataSourceID="SqlDataSource1" DataTextField="ID_EQUIPO" 
                        DataValueField="ID_EQUIPO">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                        SelectCommand="SELECT [ID_EQUIPO] FROM [Equipos]"></asp:SqlDataSource>
                    <asp:Button ID="Button1" runat="server" Text="Buscar Equipo" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 109px">
                    Nombre</td>
                <td style="width: 181px">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 109px">
                    Estado</td>
                <td style="width: 181px">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>Bueno</asp:ListItem>
                        <asp:ListItem>Malo</asp:ListItem>
                        <asp:ListItem>Reparacion</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1" style="width: 109px">
                    Especificaciones Tecnicas</td>
                <td style="width: 181px">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 109px">
                    Fabricante</td>
                <td style="width: 181px">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 109px">
                    Observaciones
                </td>
                <td style="width: 181px">
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" style="width: 109px">
                    &nbsp;</td>
                <td style="width: 181px">
                    <asp:Button ID="Button2" runat="server" Enabled="False" Text="Actualizar" />
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Enabled="False" Text="Eliminar" />
                </td>
            </tr>
        </table>
    </p>
</asp:Content>

