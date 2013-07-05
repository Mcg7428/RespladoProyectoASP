Imports System.Data.SqlClient
Imports System.Data

Partial Class AsignarMantenimiento

    Inherits System.Web.UI.Page

    Public cn As SqlClient.SqlConnection
    Public cn1 As SqlClient.SqlConnection
    Public cn2 As SqlClient.SqlConnection
    Private Property comandoSqlE As SqlCommand
    Private Property comandoSqlE1 As SqlCommand
    Private Property comandoSqlE2 As SqlCommand
    Private Property comandoSqlE3 As SqlCommand
    Dim cnn As New conexionSQLServer

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        ' validacion de fechas 
        Dim fechaI As Date = Nothing
        Dim fechaF As Date = Nothing
        Dim fechaini As String = Nothing
        Dim fechafinal As String = Nothing

        If (DateDiff(DateInterval.Day, Calendar1.SelectedDate, Calendar2.SelectedDate) >= 0) Then
            fechaI = Calendar1.SelectedDate.Date
            fechaF = Calendar2.SelectedDate.Date
            'codigo para obtener id de trabajo
            ''Conexion a base de datos para extraccion de informacion
            fechaini = fechaI.ToString("yyyy/dd/MM")
            fechafinal = fechaF.ToString("yyyy/dd/MM")
            cn = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
            ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
            cn.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
            cn.Open() ''con ela funcion open abrimos la conexion
            Dim consulta As String = "SELECT * from REGISTRO_MATENIMIENTO where CORRELA = (select MAX(CORRELA)  FROM REGISTRO_MATENIMIENTO)" ''consulta a la base de datos
            comandoSqlE = New SqlClient.SqlCommand(consulta, cn) '' creando objeto consulta a la base de datos con objeto conexio
            Dim da As SqlDataAdapter = New SqlDataAdapter(comandoSqlE) 'CREANDO ADAPTER 
            Dim ds As DataSet   'CREANDO DATA SETE 
            ds = New DataSet          ' INICIALIZANDO OBJETO
            ds.Tables.Add("REGISTRO_MATENIMIENTO")    'DEFINIENDO TABLAS EL DATASET
            da.Fill(ds.Tables("REGISTRO_MATENIMIENTO"))  'LLENANDO DATOS DE TABLA
            Dim oTabla As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
            oTabla = ds.Tables("REGISTRO_MATENIMIENTO")  'LLENADO DE LA TABLA
            Dim numcor As Integer
            Dim FilaMpio As DataRow
            For Each FilaMpio In oTabla.Rows
                numcor = FilaMpio.Item("CORRELA")
            Next
            cn.Close()


            '''' codigo para correlativo 
            '' variables a insertar
            Dim Idmante As String = DropDownList1AM.SelectedItem.Text
            Dim IdUser As String = DropDownList2.SelectedItem.Text
            Dim idbusqueda As String = Nothing ' id de equipo lab o sala a dar mantenimiento


            If (RadioButtonList1.SelectedItem.Value = "Sala") Then
                idbusqueda = DropDownList3.SelectedItem.Text
            ElseIf (RadioButtonList1.SelectedItem.Value = "Laboratorio") Then
                idbusqueda = DropDownList4.SelectedItem.Text
            ElseIf (RadioButtonList1.SelectedItem.Value = "Equipo") Then
                idbusqueda = DropDownList5.SelectedItem.Text
            Else
                MsgBox("Seleccione Sala o laboratorio")
            End If

            Dim estado As String = "Abierto"
            Dim idAutoriaza As String = DropDownList6.SelectedItem.Text
            Dim personal As String = TextBox1.Text
            Dim observaciones As String = TextBox2.Text

            '' numero de tareas 
            cn.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
            cn.Open() ''con ela funcion open abrimos la conexion
            Dim consulta1 As String = "select * from Mantenimiento where ID_MANTENIMIENTO = '" & Idmante & "'" ''consulta a la base de datos
            comandoSqlE1 = New SqlClient.SqlCommand(consulta1, cn) '' creando objeto consulta a la base de datos con objeto conexio
            Dim da1 As SqlDataAdapter = New SqlDataAdapter(comandoSqlE1) 'CREANDO ADAPTER 
            Dim ds1 As DataSet   'CREANDO DATA SETE 
            ds1 = New DataSet          ' INICIALIZANDO OBJETO
            ds1.Tables.Add("Mantenimiento")    'DEFINIENDO TABLAS EL DATASET
            da1.Fill(ds1.Tables("Mantenimiento"))  'LLENANDO DATOS DE TABLA
            Dim oTabla1 As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
            oTabla1 = ds1.Tables("Mantenimiento")  'LLENADO DE LA TABLA
            Dim numtar As Integer
            Dim FilaMpio1 As DataRow
            For Each FilaMpio1 In oTabla1.Rows
                numtar = FilaMpio1.Item("NUM_TAREAS")
            Next
            cn.Close()

            '' numero de tareas 
            ' numatar
            '' insertango registro global
            Dim numid As Integer = numcor + 1

            cnn.conectar()
            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            MsgBox("INSERT INTO REGISTRO_MATENIMIENTO VALUES ('" & Idmante + Convert.ToString(numid) & "','" & Idmante & "','" & IdUser & "','" & idbusqueda & "','" & fechaini & "','" & fechafinal & "','" & estado & "','" & idAutoriaza & "','" & personal & "','" & observaciones & "','" & Convert.ToString(numtar) & "','0','" & Convert.ToString(numid) & "')")
            If cnn.consulta("INSERT INTO REGISTRO_MATENIMIENTO VALUES ('" & Idmante + Convert.ToString(numid) & "','" & Idmante & "','" & IdUser & "','" & idbusqueda & "','" & fechaini & "','" & fechafinal & "','" & estado & "','" & idAutoriaza & "','" & personal & "','" & observaciones & "','" & Convert.ToString(numtar) & "','0','" & Convert.ToString(numid) & "')") Then

                'MsgBox("Registro almacenado")
                'en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
            Else
                '   MsgBox("No se pudo almacenar el registro error qui-------------------")
            End If
            '=======================================
            '++++++++++++++++++++++++++++++++++++++++++++++


            ' insercion bloque avance tareas 
            cn2 = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
            cn2.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
            cn2.Open() ''con ela funcion open abrimos la conexion
            Dim consulta2 As String = "Select * from Tarea where ID_MANTE_T = '" & Idmante & "'" ''consulta a la base de datos
            comandoSqlE2 = New SqlClient.SqlCommand(consulta2, cn2) '' creando objeto consulta a la base de datos con objeto conexio
            Dim da2 As SqlDataAdapter = New SqlDataAdapter(comandoSqlE2) 'CREANDO ADAPTER 
            Dim ds2 As DataSet   'CREANDO DATA SETE 
            ds2 = New DataSet          ' INICIALIZANDO OBJETO
            ds2.Tables.Add("Tarea")    'DEFINIENDO TABLAS EL DATASET
            da2.Fill(ds2.Tables("Tarea"))  'LLENANDO DATOS DE TABLA
            Dim oTabla2 As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
            oTabla2 = ds2.Tables("Tarea")  'LLENADO DE LA TABLA
            Dim numSubtar As Integer
            Dim idtarproc As String
            Dim FilaMpio2 As DataRow
            Dim contatar As Integer = 1

            For Each FilaMpio2 In oTabla2.Rows
                numSubtar = FilaMpio2.Item("NUM_SUBTAR")
                idtarproc = FilaMpio2.Item("ID_TAREA")

                cnn.conectar()
                '=====================================================
                MsgBox("INSERT INTO Reg_Avan_Tarea VALUES ('" & Idmante + Convert.ToString(numid) + Convert.ToString(contatar) & "','" & Idmante + Convert.ToString(numid) & "','" & fechaini & "','" & fechafinal & "','" & Convert.ToString(numSubtar) & "','0','Abierto','" & idtarproc & "')")
                If cnn.consulta("INSERT INTO Reg_Avan_Tarea VALUES ('" & Idmante + Convert.ToString(numid) + Convert.ToString(contatar) & "','" & Idmante + Convert.ToString(numid) & "','" & fechaini & "','" & fechafinal & "','" & Convert.ToString(numSubtar) & "','0','Abierto','" & idtarproc & "')") Then
                    'MsgBox("Registro almacenado")
                    cnn.conexion.Close()
                    ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
                Else
                    MsgBox("No se pudo almacenar el registro")
                End If


                'bloque subtareas
                cn1 = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
                cn1.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
                cn1.Open() ''con ela funcion open abrimos la conexion
                Dim consulta3 As String = "select * from SubTarea where ID_TAREA_ST = '" & idtarproc & "'" ''consulta a la base de datos
                comandoSqlE3 = New SqlClient.SqlCommand(consulta3, cn1) '' creando objeto consulta a la base de datos con objeto conexio

                Dim da3 As SqlDataAdapter = New SqlDataAdapter(comandoSqlE3) 'CREANDO ADAPTER 
                Dim ds3 As DataSet   'CREANDO DATA SETE 
                ds3 = New DataSet          ' INICIALIZANDO OBJETO
                ds3.Tables.Add("SubTarea")    'DEFINIENDO TABLAS EL DATASET
                da3.Fill(ds3.Tables("SubTarea"))  'LLENANDO DATOS DE TABLA
                Dim oTabla3 As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
                oTabla3 = ds3.Tables("SubTarea")  'LLENADO DE LA TABLA
                Dim IdSubtar As String
                Dim FilaMpio3 As DataRow
                Dim contaSubtar As Integer = 1
                For Each FilaMpio3 In oTabla3.Rows
                    IdSubtar = FilaMpio3.Item("ID_SUBTAREA")

                    cnn.conectar()
                    '+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                    MsgBox("INSERT INTO Registro_Avance_Subtarea VALUES('" & Idmante + Convert.ToString(numid) + Convert.ToString(contatar) + Convert.ToString(contaSubtar) & "','" & Idmante + Convert.ToString(numid) + Convert.ToString(contatar) & "','" & fechaini & "','" & fechafinal & "','Abierto','" & IdSubtar & "')")

                    If cnn.consulta("INSERT INTO Registro_Avance_Subtarea VALUES('" & Idmante + Convert.ToString(numid) + Convert.ToString(contatar) + Convert.ToString(contaSubtar) & "','" & Idmante + Convert.ToString(numid) + Convert.ToString(contatar) & "','" & fechaini & "','" & fechafinal & "','Abierto','" & IdSubtar & "')") Then
                        contaSubtar = contaSubtar + 1

                        'MsgBox("Registro almacenado")
                        ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
                    Else
                        MsgBox("No se pudo almacenar el registro")
                    End If

                Next
                cn1.Close()
                contatar = contatar + 1
            Next
            cn2.Close()

            'bloque avance subtareas 

            '' insertando registro gobal


            For Each li As ListItem In RadioButtonList1.Items
                li.Selected = False
            Next

            Calendar1.SelectedDates.Clear()
            Calendar2.SelectedDates.Clear()
            TextBox1.Text = Nothing
            TextBox2.Text = Nothing



            '+++++++++++++++++++++++++++++++++
            '===========================================================




        Else ' else validacon fecha
            Calendar1.SelectedDates.Clear()
            Calendar2.SelectedDates.Clear()
            MsgBox("Selecciones fechas validas")
        End If 'end if validacion de fecha


    End Sub
End Class
