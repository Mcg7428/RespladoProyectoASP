﻿Imports System.Data.SqlClient
Imports System.Data

Partial Class RegistrarEdificio
    Inherits System.Web.UI.Page
    Dim cnn As New conexionSQLServer

    Private Property comandoSqlE As SqlCommand


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        cnn.conectar()
        If cnn.consulta("INSERT INTO Edificio  VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')") Then
            MsgBox("Registro almacenado")
            TextBox1.Text = Nothing
            TextBox2.Text = Nothing
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing

            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If
    End Sub

End Class
