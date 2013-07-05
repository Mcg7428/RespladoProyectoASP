

Partial Class RegistroSala
    Inherits System.Web.UI.Page
    Dim cnn As New conexionSQLServer
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        cnn.conectar()

        If cnn.consulta("INSERT INTO Sala VALUES('" & DropDownList1.SelectedItem.Text + TextBox3.Text & "','" & DropDownList1.SelectedItem.Text & "','" & TextBox4.Text & "')") Then
            MsgBox("Registro almacenado")
            TextBox3.Text = Nothing
            TextBox4.Text = Nothing

            ''en caso de error la funcion consulta devuelve false y lanza mensaje "No se pudo almacenar el registro"
        Else
            MsgBox("No se pudo almacenar el registro")
        End If

    End Sub

End Class
