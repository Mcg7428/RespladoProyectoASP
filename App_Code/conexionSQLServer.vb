Imports Microsoft.VisualBasic
Imports System.Data
Imports System

Public Class conexionSQLServer
    ''creamos el objeto de conexion
    Public conexion As SqlClient.SqlConnection
    ''metodo para conectanos a la base de datos
    Public Sub conectar()
        conexion = New SqlClient.SqlConnection() ''inicializamos el objeto conexion
        ''ahora pasamos la cadena de conexion al objeto conexion con nuestros datos
        conexion.ConnectionString = "Server=ATHENA64; database=BD_MantenimientoASP; trusted_connection=yes" '' cambiar el servidor para comite a   Server=ATHENA64
        conexion.Open() ''con la funcion open abrimos la conexion
    End Sub

    'Data Source=ATHENA64;Initial Catalog=BD_GUIA_4;Integrated Security=True

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
End Class

