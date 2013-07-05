Imports System.Data.SqlClient
Imports System.Data

Partial Class EliminarActualizar
    Inherits System.Web.UI.Page
    Public cn As SqlClient.SqlConnection
    Dim cnn As New conexionSQLServer

    Private Property comandoSqlE As SqlCommand

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ''Conexion a base de datos para extraccion de informacion
        cn = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
        ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
        cn.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
        cn.Open() ''con ela funcion open abrimos la conexion

        Dim consulta As String = "select * from Usuario where ID_USUARIO = '" + DropDownList1.Text + "'" ''consulta a la base de datos
        comandoSqlE = New SqlClient.SqlCommand(consulta, cn) '' creando objeto consulta a la base de datos con objeto conexio

        Dim da As SqlDataAdapter = New SqlDataAdapter(comandoSqlE) 'CREANDO ADAPTER 
        Dim ds As DataSet   'CREANDO DATA SETE 
        ds = New DataSet          ' INICIALIZANDO OBJETO
        ds.Tables.Add("Usuario")    'DEFINIENDO TABLAS EL DATASET
        da.Fill(ds.Tables("Usuario"))  'LLENANDO DATOS DE TABLA

        Dim oTabla As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
        oTabla = ds.Tables("Usuario")  'LLENADO DE LA TABLA

        Dim FilaMpio As DataRow
        For Each FilaMpio In oTabla.Rows
            TextBox1.Text = FilaMpio.Item("NOMBRE")
            TextBox2.Text = FilaMpio.Item("CARGO")
            TextBox3.Text = FilaMpio.Item("DEPARTAMENTO")
            TextBox4.Text = FilaMpio.Item("USUARIO")
            TextBox5.Text = FilaMpio.Item("CLAVE")
            TextBox6.Text = FilaMpio.Item("CLAVE")
            TextBox7.Text = FilaMpio.Item("PREGUNTA_SECRETA")
            TextBox8.Text = FilaMpio.Item("RESPUESTA_SECRETA")
            TextBox9.Text = FilaMpio.Item("EMAIL")
        Next

        cn.Close()


    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ''nos conectamos a la base de datos
        cnn.conectar()


        ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"
        If cnn.consulta(" update Usuario set ID_USUARIO='" & DropDownList1.Text & "', NOMBRE='" & TextBox1.Text & "',CARGO='" & DropDownList1.Text & "',DEPARTAMENTO = '" & DropDownList2.Text & "',USUARIO='" & TextBox4.Text & "', CLAVE='" & TextBox5.Text & "',PREGUNTA_SECRETA='" & TextBox7.Text & "',RESPUESTA_SECRETA='" & TextBox8.Text & "',EMAIL='" & TextBox9.Text & "' where ID_USUARIO='" & DropDownList1.Text & "' ID_USUARIO='" & DropDownList1.Text & "'") Then

            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing
            TextBox5.Text = Nothing
            TextBox6.Text = Nothing
            TextBox7.Text = Nothing
            TextBox8.Text = Nothing
            TextBox9.Text = Nothing

            MsgBox("Registro Actualizado")
            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If


    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click

        ''nos conectamos a la base de datos
        cnn.conectar()


        ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"
        If cnn.consulta(" delete from Usuario where ID_USUARIO='" & DropDownList1.Text & "'") Then
            '''''''' trabajando

            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing
            TextBox5.Text = Nothing
            TextBox6.Text = Nothing
            TextBox7.Text = Nothing
            TextBox8.Text = Nothing
            TextBox9.Text = Nothing

            MsgBox("Registro eliminado")
            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo eliminar el registro")
        End If






    End Sub
End Class
