Imports System.Data.SqlClient
Imports System.Data

Partial Class AgregarUsuario
    Inherits System.Web.UI.Page
    Dim cnn As New conexionSQLServer
    Public cn As SqlClient.SqlConnection
    Private Property comandoSqlE As SqlCommand

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click


        '' codigo para corelativo de usuario 



        'codigo para obtener id de trabajo
        ''Conexion a base de datos para extraccion de informacion
        cn = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
        ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
        cn.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
        cn.Open() ''con ela funcion open abrimos la conexion

        Dim consulta As String = "SELECT * from Usuario where correlativo = (select MAX(correlativo)  FROM Usuario)" ''consulta a la base de datos
        comandoSqlE = New SqlClient.SqlCommand(consulta, cn) '' creando objeto consulta a la base de datos con objeto conexio

        Dim da As SqlDataAdapter = New SqlDataAdapter(comandoSqlE) 'CREANDO ADAPTER 
        Dim ds As DataSet   'CREANDO DATA SETE 
        ds = New DataSet          ' INICIALIZANDO OBJETO
        ds.Tables.Add("Usuario")    'DEFINIENDO TABLAS EL DATASET
        da.Fill(ds.Tables("Usuario"))  'LLENANDO DATOS DE TABLA

        Dim oTabla As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
        oTabla = ds.Tables("Usuario")  'LLENADO DE LA TABLA
        Dim numemp As Integer
        Dim FilaMpio As DataRow

        For Each FilaMpio In oTabla.Rows
            numemp = FilaMpio.Item("correlativo")
        Next

        cn.Close()

        '''' codigo para correlativo 

        Dim iduser As String



        ''nos conectamos a la base de datos
        cnn.conectar()
        numemp = numemp + 1
        iduser = DropDownList2.Text + numemp.ToString

        ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"
        If cnn.consulta("INSERT INTO Usuario values('" & iduser & "','" & TextBox1.Text & "','" & DropDownList1.Text & "','" & DropDownList2.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & Val(numemp) & "')") Then
            MsgBox("Registro almacenado ID_USUARIO es : " & iduser)
            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing
            TextBox5.Text = Nothing
            TextBox6.Text = Nothing
            TextBox7.Text = Nothing

            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If
    End Sub


End Class
