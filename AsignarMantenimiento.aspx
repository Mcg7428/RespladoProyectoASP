<%@ Page Title="" Language="VB" MasterPageFile="~/RegistroAsignacionMante.master" AutoEventWireup="false" CodeFile="AsignarMantenimiento.aspx.vb" Inherits="AsignarMantenimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder15" Runat="Server">
    <table style="width:546px;">
    <tr>
        <td style="width: 164px">
            &nbsp;</td>
        <td colspan="2">
            Asignar Mantenimiento</td>
        <td style="width: 65px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 164px">
            Mantenimiento Asignado</td>
        <td colspan="2">
            <asp:DropDownList ID="DropDownList1AM" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="ID_MANTENIMIENTO" 
                DataValueField="ID_MANTENIMIENTO">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT [ID_MANTENIMIENTO] FROM [Mantenimiento]">
            </asp:SqlDataSource>
        </td>
        <td style="width: 65px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 164px">
            Id Creador Mantenimiento</td>
        <td colspan="2">
            <asp:DropDownList ID="DropDownList2" runat="server" Height="17px" Width="69px" 
                DataSourceID="SqlDataSource2" DataTextField="ID_USUARIO" 
                DataValueField="ID_USUARIO">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT [ID_USUARIO] FROM [Usuario]"></asp:SqlDataSource>
        </td>
        <td style="width: 65px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 164px" rowspan="3">
            Sala / Laboratorio/ Equipo&nbsp;
        </td>
        <td style="width: 82px" class="style2" rowspan="3">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem>Sala</asp:ListItem>
                <asp:ListItem>Laboratorio</asp:ListItem>
                <asp:ListItem>Equipo</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td style="width: 69px" class="style1">
            <asp:DropDownList ID="DropDownList3" runat="server" 
                DataSourceID="SqlDataSource3" DataTextField="ID_SALA" DataValueField="ID_SALA">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT * FROM [Sala]"></asp:SqlDataSource>
        </td>
        <td rowspan="3" style="width: 65px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="RadioButtonList1" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td style="width: 69px" class="style1">
            <asp:DropDownList ID="DropDownList4" runat="server" 
                DataSourceID="SqlDataSource4" DataTextField="ID_LAB" DataValueField="ID_LAB">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT [ID_LAB] FROM [Laboratorio]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="width: 69px" class="style1">
            <asp:DropDownList ID="DropDownList5" runat="server" 
                DataSourceID="SqlDataSource5" DataTextField="ID_EQUIPO" 
                DataValueField="ID_EQUIPO">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT [ID_EQUIPO] FROM [Equipos]"></asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td style="width: 164px">
            &nbsp;</td>
        <td colspan="2">
            Fecha de Inicio</td>
        <td style="width: 65px">
            Fecha Finalizacion</td>
    </tr>
    <tr>
        <td style="width: 164px">
            &nbsp;</td>
        <td colspan="2">
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                BorderColor="#3366CC" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="#003399" Height="200px" Width="220px" CellPadding="1" 
                DayNameFormat="Shortest">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#009999" ForeColor="#CCFF99" Font-Bold="True" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                    Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <WeekendDayStyle BackColor="#CCCCFF" />
            </asp:Calendar>
        </td>
        <td style="width: 65px">
            <asp:Calendar ID="Calendar2" runat="server" BackColor="#FFFFCC" 
                BorderColor="#FFCC66" BorderWidth="1px" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="#663399" Height="200px" Width="220px" DayNameFormat="Shortest" 
                ShowGridLines="True">
                <DayHeaderStyle Font-Bold="True" BackColor="#FFCC66" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" 
                    Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
        </td>
    </tr>
    <tr>
        <td style="width: 164px">
            &nbsp;</td>
        <td colspan="2">
            &nbsp;</td>
        <td style="width: 65px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 164px; height: 25px;">
            ID de Autorizado por</td>
        <td style="height: 25px;" colspan="2">
            <asp:DropDownList ID="DropDownList6" runat="server" 
                DataSourceID="SqlDataSource2" DataTextField="ID_USUARIO" 
                DataValueField="ID_USUARIO">
            </asp:DropDownList>
        </td>
        <td style="width: 65px; height: 25px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 164px">
            Personal Asignado</td>
        <td colspan="2">
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="TextBox1" ErrorMessage="Rquerido"></asp:RequiredFieldValidator>
        </td>
        <td style="width: 65px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 164px">
            Observaciones</td>
        <td colspan="2">
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        <td style="width: 65px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 164px">
            &nbsp;</td>
        <td colspan="2">
            <asp:Button ID="Button1" runat="server" Text="Asignar Mantenimiento" />
        </td>
        <td style="width: 65px">
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

