Imports System.Data.SqlClient
Imports System.Data


Partial Class EliminarActualizaEquipo
    Inherits System.Web.UI.Page
    Dim cnn As New conexionSQLServer
    Public cn As SqlClient.SqlConnection
    Private Property comandoSqlE As SqlCommand



    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        ''Conexion a base de datos para extraccion de informacion
        cn = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
        ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
        cn.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
        cn.Open() ''con ela funcion open abrimos la conexion

        Dim id As String = DropDownList1.SelectedItem.Text

        Dim consulta As String = "select * from Equipos where  ID_EQUIPO= '" & id & "'" ''consulta a la base de datos
        comandoSqlE = New SqlClient.SqlCommand(consulta, cn) '' creando objeto consulta a la base de datos con objeto conexio

        Dim da As SqlDataAdapter = New SqlDataAdapter(comandoSqlE) 'CREANDO ADAPTER 
        Dim ds As DataSet   'CREANDO DATA SETE 
        ds = New DataSet          ' INICIALIZANDO OBJETO
        ds.Tables.Add("Equipos")    'DEFINIENDO TABLAS EL DATASET
        da.Fill(ds.Tables("Equipos"))  'LLENANDO DATOS DE TABLA

        Dim oTabla As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
        oTabla = ds.Tables("Equipos")  'LLENADO DE LA TABLA

        Dim FilaMpio As DataRow

        For Each FilaMpio In oTabla.Rows
            TextBox1.Text = FilaMpio.Item("NOMBRE_EQUIPO")
            TextBox3.Text = FilaMpio.Item("FABRICANTE")
            Label1.Text = FilaMpio.Item("ESTADO")
            TextBox2.Text = FilaMpio.Item("ESPECIFIC_TECNI")
            TextBox4.Text = FilaMpio.Item("OBSERVACIONES")
        Next

        cn.Close()


        Button2.Enabled = True
        Button3.Enabled = True

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        cnn.conectar()


        ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"
        If cnn.consulta("update Equipos set ID_EQUIPO='" & DropDownList1.SelectedItem.Text & "', NOMBRE_EQUIPO = '" & TextBox1.Text & "', FABRICANTE= '" & TextBox3.Text & "', ESTADO = '" & DropDownList2.SelectedItem.Text & "', ESPECIFIC_TECNI='" & TextBox2.Text & "', OBSERVACIONES='" & TextBox4.Text & "'where ID_EQUIPO='" & DropDownList1.SelectedItem.Text & "'") Then

            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing
            Button2.Enabled = False
            Button3.Enabled = False
            Label1.Text = Nothing
            MsgBox("Registro Actualizado")
            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        cnn.conectar()


        ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"
        If cnn.consulta("delete from Equipos where ID_EQUIPO='" & DropDownList1.SelectedItem.Text & "'") Then
            Dim datoeli As String = DropDownList1.SelectedItem.Text
            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing
            Button2.Enabled = False
            Button3.Enabled = False
            Label1.Text = Nothing
            DropDownList1.Items.Remove(datoeli)
            MsgBox("Registro Eliminado")
            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo eliminar el registro")
        End If



    End Sub
End Class
