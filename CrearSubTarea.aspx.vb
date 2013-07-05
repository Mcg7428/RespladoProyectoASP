
Partial Class CrearSubTarea
    Inherits System.Web.UI.Page
    Dim cnn As New conexionSQLServer


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click

        cnn.conectar()


        ''enviamos la consulta sql a la funcion si es correcta devuelve true y lanza mensaje "Registro almacenado"
        If cnn.consulta("INSERT INTO SubTarea_Independiente values('" & TextBox4.Text & "')") Then
            ' MsgBox("Registro almacenado")

            TextBox4.Text = Nothing

            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If

    End Sub
End Class
