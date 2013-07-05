Imports System.Data.SqlClient
Imports System.Data
Partial Class CrearMantenimiento
    Inherits System.Web.UI.Page
    Dim cnn As New conexionSQLServer

    Public cn As SqlClient.SqlConnection
    Private Property comandoSqlE As SqlCommand

    Private Property comandoSqlE1 As SqlCommand '' cadena extra para 

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        cnn.conectar()
        If cnn.consulta("insert into Mantenimiento values ('" & TextBox1.Text & "','" & TextBox2.Text & "','0')") Then
            MsgBox("Registro almacenado")
           

            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If
        TextBox1.Enabled = False
        TextBox2.Enabled = False

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim conTareas As Integer

        If (ListBox1.SelectedIndex > -1) Then
            Dim tarea As String = ListBox1.SelectedItem.Text
            'codigo para obtener id de trabajo
            ''Conexion a base de datos para extraccion de informacion
            cn = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
            ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
            cn.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
            cn.Open() ''con ela funcion open abrimos la conexion
            Dim consulta As String = "select * from Tarea_Individual where NOMBRE_TAREA_IDN = '" & tarea & "'" ''consulta a la base de datos
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
            For Each FilaMpio In oTabla.Rows
                idt = FilaMpio.Item("ID_TAREA_IND")
            Next
            cn.Close()

            Dim idtbuscar As String = Convert.ToString(idt)
            ''subtareas ligadas
            Dim idtarea As String = TextBox1.Text + idtbuscar
            '' creando tarea asociada 
            MsgBox(idtarea)
            cnn.conectar()
            If cnn.consulta("insert into Tarea values ('" & idtarea & "','" & TextBox1.Text & "','" & tarea & "','0')") Then
                'MsgBox("Registro almacenado")
                ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
            Else
                MsgBox("No se pudo almacenar el registro")
            End If


            ''''

            cn.Open() ''con ela funcion open abrimos la conexion
            Dim consulta1 As String = "select * from SubTarea_Individual where ID_TAREA_STIND = '" & idtbuscar & "'" ''consulta a la base de datos
            comandoSqlE1 = New SqlClient.SqlCommand(consulta1, cn) '' creando objeto consulta a la base de datos con objeto conexio
            Dim da1 As SqlDataAdapter = New SqlDataAdapter(comandoSqlE1) 'CREANDO ADAPTER 
            Dim ds1 As DataSet   'CREANDO DATA SETE 
            ds1 = New DataSet          ' INICIALIZANDO OBJETO
            ds1.Tables.Add("SubTarea_Individual")    'DEFINIENDO TABLAS EL DATASET
            da1.Fill(ds1.Tables("SubTarea_Individual"))  'LLENANDO DATOS DE TABLA
            Dim oTabla1 As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
            oTabla1 = ds1.Tables("SubTarea_Individual")  'LLENADO DE LA TABLA
            Dim FilaMpio1 As DataRow
            Dim idst As String = ""
            Dim desc As String = ""
            Dim contador As Integer = 0
            For Each FilaMpio1 In oTabla1.Rows
                '' crear subtareas ligadas
                idst = FilaMpio1.Item("ID_SUBTAREA_IND")
                desc = FilaMpio1.Item("DESCRIPCION")

                cnn.conectar()
                If cnn.consulta("insert into SubTarea values ('" & idtarea + idst & "','" & idtarea & "','" & desc & "')") Then
                    contador = contador + 1
                    'MsgBox("Registro almacenado")
                    ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
                Else
                    MsgBox("No se pudo almacenar el registro")
                End If
            Next

            cnn.conectar()
            If cnn.consulta(" update Tarea set NUM_SUBTAR=" & Val(contador) & " where ID_TAREA='" & idtarea & "'") Then

                ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
            Else
                MsgBox("No se pudo almacenar el registro")
            End If
            cn.Close()


            conTareas = conTareas + 1
            cnn.conectar()
            If cnn.consulta(" update Mantenimiento set NUM_TAREAS=" & Val(conTareas) & " where ID_MANTENIMIENTO='" & TextBox1.Text & "'") Then

                ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
            Else
                MsgBox("No se pudo almacenar el registro")
            End If


            Dim itemadd As String = ListBox1.SelectedItem.Text
            ListBox2.Items.Add(itemadd)
            ListBox1.Items.Remove(itemadd)
        Else
            MsgBox("selecciones tarea")
        End If








    End Sub
End Class
