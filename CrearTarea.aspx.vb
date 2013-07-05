Imports System.Data
Imports System.Data.SqlClient

Partial Class CrearTarea
    Inherits System.Web.UI.Page
    Dim cnn As New conexionSQLServer
    Public cn As SqlClient.SqlConnection
    Private Property comandoSqlE As SqlCommand




    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        cnn.conectar()

        Dim contador As Integer = 0
        ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"

        If cnn.consulta("INSERT INTO Tarea_Individual values('" & TextBox2.Text & "','" & Val(contador) & "')") Then
            MsgBox("Registro almacenado")


            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If


        Button1.Enabled = True
        Button2.Enabled = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'OBTENIENDO DATOS DE SUBTAREAS A AGREAGAR A TAREA


        'codigo para obtener id de trabajo
        ''Conexion a base de datos para extraccion de informacion
        cn = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
        ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
        cn.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
        cn.Open() ''con ela funcion open abrimos la conexion

        Dim consulta As String = "SELECT * from Tarea_Individual where ID_TAREA_IND =(select MAX(ID_TAREA_IND) id FROM Tarea_Individual)" ''consulta a la base de datos
        comandoSqlE = New SqlClient.SqlCommand(consulta, cn) '' creando objeto consulta a la base de datos con objeto conexio

        Dim da As SqlDataAdapter = New SqlDataAdapter(comandoSqlE) 'CREANDO ADAPTER 
        Dim ds As DataSet   'CREANDO DATA SETE 
        ds = New DataSet          ' INICIALIZANDO OBJETO
        ds.Tables.Add("Tarea_Individual")    'DEFINIENDO TABLAS EL DATASET
        da.Fill(ds.Tables("Tarea_Individual"))  'LLENANDO DATOS DE TABLA

        Dim oTabla As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
        oTabla = ds.Tables("Tarea_Individual")  'LLENADO DE LA TABLA
        Dim idt As Integer
        Dim FilaMpio As DataRow
        Dim numsubtar As Integer
        For Each FilaMpio In oTabla.Rows
            idt = FilaMpio.Item("ID_TAREA_IND")
            numsubtar = FilaMpio("NUM_SUBT_IND")

        Next

        cn.Close()

        'fin codigo codigo busqueda de codigo








        'OBTENIENDO DATOS DE LA TAREA QUE SE MODFICA

        If (ListBox1.SelectedIndex > -1) Then
            Dim subtar As String = ListBox1.SelectedItem.Text
            ListBox2.Items.Add(ListBox1.SelectedItem.Text)

            cn.Open() ''con ela funcion open abrimos la conexion


            Dim consulta1 As String = "select *from SubTarea_Independiente where DESCRIPCION = '" & subtar & "'" ''consulta a la base de datos

            comandoSqlE = New SqlClient.SqlCommand(consulta1, cn) '' creando objeto consulta a la base de datos con objeto conexio


            Dim da1 As SqlDataAdapter = New SqlDataAdapter(comandoSqlE) 'CREANDO ADAPTER 
            Dim ds1 As DataSet   'CREANDO DATA SETE 
            ds1 = New DataSet          ' INICIALIZANDO OBJETO
            ds1.Tables.Add("SubTarea_Independiente")    'DEFINIENDO TABLAS EL DATASET
            da1.Fill(ds1.Tables("SubTarea_Independiente"))  'LLENANDO DATOS DE TABLA

            Dim oTabla1 As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
            oTabla1 = ds1.Tables("SubTarea_Independiente")  'LLENADO DE LA TABLA
            Dim idst As Integer
            Dim subtar1 As String
            Dim FilaMpio1 As DataRow

            For Each FilaMpio1 In oTabla1.Rows
                idst = FilaMpio1.Item("ID_SubTarea_Independ")
                subtar1 = FilaMpio1.Item("DESCRIPCION")
            Next



            'AGREGANDO TAREAS INDIVIDUALES 
            cn.Close()


            Dim id_insertar As String = idt.ToString + idst.ToString

            cnn.conectar()
            ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"

            If cnn.consulta("insert into SubTarea_Individual values('" & id_insertar & "','" & Val(idt) & "','" & subtar & "')") Then


                'en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
            Else
                MsgBox("No se pudo almacenar el registro")
            End If


            cnn.conectar()
            'ACTUALIZACION DE TAREAS ASIGNADAS
            ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"

            numsubtar = numsubtar + 1

            If cnn.consulta("update Tarea_Individual set NUM_SUBT_IND ='" & Val(numsubtar) & " 'where ID_TAREA_IND='" & Val(idt) & "'") Then

                ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
            Else
                MsgBox("No se pudo almacenar el registro****")
            End If
            'mover al final
            ListBox1.Items.Remove(ListBox1.SelectedItem.Text)
            'mover al final
        Else
            MsgBox("selecciones subtarea")
        End If
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Response.Redirect("~/CrearTarea.aspx")

    End Sub
End Class
