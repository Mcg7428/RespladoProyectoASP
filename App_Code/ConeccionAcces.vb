Imports System.Data.OleDb
Imports Microsoft.VisualBasic

Public Class ConeccionAcces

    Public cnn As New OleDbConnection
    Public reg As OleDbDataReader

    Public Sub ini()
        cnn.ConnectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Jose Carlos\Documents\GitHub\RespladoProyectoASP\Respaldos\BaseImport.accdb")
        Try
            cnn.Open()
        Catch ex As Exception
            MsgBox("Error de conexión de acces")
        End Try
    End Sub

    Public Sub fin()
        cnn.Close()
    End Sub

    Public Sub envia(ByVal texto As String)
        Dim con As New OleDbCommand(texto, cnn)
        con.ExecuteNonQuery()
    End Sub



    Public Function recibe(ByVal texto As String) As OleDbDataReader
        Dim con As New OleDbCommand(texto, cnn)
        con.ExecuteNonQuery()
        reg = con.ExecuteReader
        Return reg
    End Function

End Class
