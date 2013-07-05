
Partial Class alerta
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim correo As New System.Net.Mail.MailMessage
        correo.From = New System.Net.Mail.MailAddress("mcg7428@hotmail.com")
        correo.To.Add("mcg7428@hotmail.com")
        correo.Subject = "prueba"
        correo.Body = "rpueba"
        correo.IsBodyHtml = False
        correo.Priority = System.Net.Mail.MailPriority.Normal

        Dim smtp As New System.Net.Mail.SmtpClient
        smtp.Host = "smtp.live.com"

        smtp.Credentials = New System.Net.NetworkCredential("mcg7428@hotmail.com", "mcglifegg")

        Try
            smtp.Send(correo)
            MsgBox("Mensaje enviado satisfactoriamente")
        Catch ex As Exception
            MsgBox("ERROR: " & ex.Message)
        End Try

    End Sub
End Class
