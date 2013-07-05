Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ConeccionChepe
    Public conexion As New SqlConnection
    ''Objetos para trabajar con la conecccion
    Public Arreglo As SqlDataReader
    Public lista As New DropDownList
    Public reg As SqlDataReader

    Public Sub conectar() ''Crea la coneccion
        ''conexion = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
        ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
        conexion.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a Server=ATHENA64
        Try
            conexion.Open() ''con la funcion open abrimos la conexion
        Catch ex As Exception
            MsgBox("Error de conexion") ''Manda error por si no abre la base
        End Try

    End Sub

    Public Sub desconectar() ''cierra la base de datos
        conexion.Close()
    End Sub

    Public Sub ConsultaRapida(ByVal StrConsulta As String) ''Ejecuta una consulta
        Dim con As New SqlCommand(StrConsulta, conexion)
        con.ExecuteNonQuery()
    End Sub

    Public Function Obtener(ByVal StrConsulta As String) As SqlDataReader ''debuelve los balore de una consulta
        Dim con As New SqlCommand(StrConsulta, conexion)
        con.ExecuteNonQuery()
        Arreglo = con.ExecuteReader
        Return Arreglo
    End Function

    Public Sub envia(ByVal texto As String) ''realiza una consulta enviando la consulta y conexcion
        Dim con As New SqlCommand(texto, conexion)
        con.ExecuteNonQuery()
    End Sub

    Public Function recibe(ByVal texto As String) As SqlDataReader ''manda la coneccion y la consulta y debuel la cosas
        Dim con As New SqlCommand(texto, conexion)
        con.ExecuteNonQuery()
        reg = con.ExecuteReader
        Return reg
    End Function

    ''funcion para enviar transacciones sql a la base de datos

    Public Function consulta(ByVal cadenaSql As String) As Boolean
        Dim comandoSql As SqlClient.SqlCommand ''declaramos el comando para la consulta
        Dim resultado As Integer ''variable para almacenar el resultado de la transaccion
        Try
            ''inicializamos el comando sql pasando la cadena que recibimos del formulario y la conexion a la base
            comandoSql = New SqlClient.SqlCommand(cadenaSql, conexion)
            resultado = comandoSql.ExecuteNonQuery ''almacenamos el resultado del comando sql

            ''en caso que resultado sea mayor a cero la funcion devolvera true
            If resultado > 0 Then
                Return True
            Else
                Return False ''en caso que resultado sea menor o igual a cero devolvera falso
            End If

            conexion.Close() ''cerramos la conexion
            ''en caso de error lanza mensaje de error y la funcion devolvera falso
        Catch ex As Exception
            MsgBox("Error al conectar con la base de datos")
            Return False
        End Try
    End Function

    Sub ConsultaRapida()
        Throw New NotImplementedException
    End Sub


End Class
