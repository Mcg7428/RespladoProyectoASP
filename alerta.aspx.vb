
Partial Class alerta
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim correo As New System.Net.Mail.MailMessage
        correo.From = New System.Net.Mail.MailAddress(txtDe.Text)
        correo.To.Add(txtPara.Text)
        correo.Subject = txtAsunto.Text
        correo.Body = txtTexto.Text
        correo.IsBodyHtml = False
        correo.Priority = System.Net.Mail.MailPriority.Normal

        Dim smtp As New System.Net.Mail.SmtpClient
        smtp.Host = "servidor de correo"

        smtp.Credentials = New System.Net.NetworkCredential("usuario", "password")

    End Sub
End Class
