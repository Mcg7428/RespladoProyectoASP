<%@ Page Title="" Language="VB" MasterPageFile="~/Reportes_BackUp.master" AutoEventWireup="false" CodeFile="BackUpGeneral.aspx.vb" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder12" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Tarea" Width="160px" />
            <asp:Button ID="Button2" runat="server" Text="Sub Tarea" Width="159px" />
            <asp:Button ID="Button3" runat="server" Text="Mantenimientos" Width="123px" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:GridView ID="DataGridView1" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID_TAREA" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ID_TAREA" HeaderText="ID_TAREA" ReadOnly="True" 
                        SortExpression="ID_TAREA" />
                    <asp:BoundField DataField="ID_MANTE_T" HeaderText="ID_MANTE_T" 
                        SortExpression="ID_MANTE_T" />
                    <asp:BoundField DataField="NOMBRE_TAREA" HeaderText="NOMBRE_TAREA" 
                        SortExpression="NOMBRE_TAREA" />
                    <asp:BoundField DataField="NUM_SUBTAR" HeaderText="NUM_SUBTAR" 
                        SortExpression="NUM_SUBTAR" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT * FROM [Tarea]"></asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:GridView ID="GridViewTarea" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="ID_SUBTAREA" DataSourceID="SqlDataSource2" Visible="False">
                <Columns>
                    <asp:BoundField DataField="ID_SUBTAREA" HeaderText="ID_SUBTAREA" 
                        ReadOnly="True" SortExpression="ID_SUBTAREA" />
                    <asp:BoundField DataField="ID_TAREA_ST" HeaderText="ID_TAREA_ST" 
                        SortExpression="ID_TAREA_ST" />
                    <asp:BoundField DataField="DESCRIPCION" HeaderText="DESCRIPCION" 
                        SortExpression="DESCRIPCION" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT * FROM [SubTarea]"></asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            <asp:GridView ID="GridViewMantenimiento" runat="server" 
                AutoGenerateColumns="False" DataKeyNames="ID_MANTENIMIENTO" 
                DataSourceID="SqlDataSource3" Visible="False">
                <Columns>
                    <asp:BoundField DataField="ID_MANTENIMIENTO" HeaderText="ID_MANTENIMIENTO" 
                        ReadOnly="True" SortExpression="ID_MANTENIMIENTO" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="NOMBRE" 
                        SortExpression="NOMBRE" />
                    <asp:BoundField DataField="NUM_TAREAS" HeaderText="NUM_TAREAS" 
                        SortExpression="NUM_TAREAS" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:BD_MantenimientoASPConnectionString %>" 
                SelectCommand="SELECT * FROM [Mantenimiento]"></asp:SqlDataSource>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

