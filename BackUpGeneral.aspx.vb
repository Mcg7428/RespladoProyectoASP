Imports System.IO


Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        ExportToExcel("RespaldoTarea.xls", DataGridView1)


    End Sub

    Private Sub ExportToExcel(ByVal nameReport As String, ByVal wControl As GridView)
        Dim responsePage As HttpResponse = Response
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        Dim pageToRender As New Page()
        Dim form As New HtmlForm()
        form.Controls.Add(wControl)
        pageToRender.Controls.Add(form)
        responsePage.Clear()
        responsePage.Buffer = True
        responsePage.ContentType = "application/vnd.ms-excel"
        responsePage.AddHeader("Content-Disposition", "attachment;filename=" & nameReport)
        responsePage.Charset = "UTF-8"
        responsePage.ContentEncoding = Encoding.Default
        pageToRender.RenderControl(htw)
        responsePage.Write(sw.ToString())
        responsePage.End()
    End Sub

    Protected Sub GridViewTarea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridViewTarea.SelectedIndexChanged

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        ExportToExcel("RespaldoSubTarea.xls", GridViewTarea)
    End Sub

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        ExportToExcel("RespaldoMantenimiento.xls", GridViewMantenimiento)
    End Sub
End Class
