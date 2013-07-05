Imports System.Data.SqlClient
Imports System.Data

Partial Class RegistrarEquipo
    Inherits System.Web.UI.Page

    Dim cnn As New conexionSQLServer
    Public cn As SqlClient.SqlConnection
    Private Property comandoSqlE As SqlCommand


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim idbusqueda As String = ""

        

        If (RadioButtonList1.SelectedItem.Value = "Sala") Then
            idbusqueda = DropDownList1.SelectedItem.Text

        ElseIf (RadioButtonList1.SelectedItem.Value = "Laboratorio") Then
            idbusqueda = DropDownList2.SelectedItem.Text

        Else
            MsgBox("Seleccione Sala o laboratorio")
        End If


        Dim tipo As String = DropDownList5.SelectedItem.Text
        Dim tipoinsert As String = ""

        Select Case tipo
            Case "Impresora"
                tipoinsert = "I"
                ' The following is the only Case clause that evaluates to True.
            Case "Laptop"
                tipoinsert = "L"
            Case "Escritorio"
                tipoinsert = "E"
            Case "Perifericos"
                tipoinsert = "P"
        End Select


        Dim buscar As String
        buscar = idbusqueda + tipoinsert





        '' codigo para corelativo de usuario 





        'codigo para obtener id de trabajo
        ''Conexion a base de datos para extraccion de informacion
        cn = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
        ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
        cn.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
        cn.Open() ''con ela funcion open abrimos la conexion

        Dim consulta As String = "select * from Equipos where coeq = (select max(coeq) from dbo.Equipos where ID_EQUIPO like '%" & buscar & "%')" ''consulta a la base de datos
        comandoSqlE = New SqlClient.SqlCommand(consulta, cn) '' creando objeto consulta a la base de datos con objeto conexio

        Dim da As SqlDataAdapter = New SqlDataAdapter(comandoSqlE) 'CREANDO ADAPTER 
        Dim ds As DataSet   'CREANDO DATA SETE 
        ds = New DataSet          ' INICIALIZANDO OBJETO
        ds.Tables.Add("Equipos")    'DEFINIENDO TABLAS EL DATASET
        da.Fill(ds.Tables("Equipos"))  'LLENANDO DATOS DE TABLA

        Dim oTabla As DataTable        ''=OBJETO TABLA PARA GUARDAR DATOS 
        oTabla = ds.Tables("Equipos")  'LLENADO DE LA TABLA
        Dim numemp As Integer
        Dim FilaMpio As DataRow

        For Each FilaMpio In oTabla.Rows
            numemp = FilaMpio.Item("coeq")
        Next

        cn.Close()

        '''' codigo para correlativo 


        '' generar auto incremento de identificador
        Dim corr As Integer
        corr = numemp + 1

        Dim corins As String = ""

        If corr <= 9 Then
            corins = "00" + Convert.ToString(corr)
        ElseIf (corr >= 10 And corr <= 99) Then
            corins = "0" + Convert.ToString(corr)
        ElseIf corr >= 100 Then
            corins = Convert.ToString(corr)
        End If
        '' condigo de insercion 

        





        '' codigo de insercion 

        cnn.conectar()


        ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"

        If cnn.consulta("insert into  Equipos values('" & buscar + corins & "','" & TextBox5.Text & "','" & idbusqueda & "','" & TextBox7.Text & "','" & Val(corr) & "','" & DropDownList1.SelectedItem.Text & "','" & DropDownList3.SelectedItem.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "')") Then
            TextBox3.Text = Nothing
            TextBox5.Text = Nothing
            TextBox6.Text = Nothing
            TextBox7.Text = Nothing

            For Each li As ListItem In RadioButtonList1.Items
                li.Selected = False
            Next

            MsgBox("Registro almacenado")

            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If

        '' condigo de insercion 

    End Sub
End Class
