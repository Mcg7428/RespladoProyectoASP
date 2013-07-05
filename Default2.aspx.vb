
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles importa.Click
        Dim ConsultaInser As String
        Dim TargetPath As String = "C:\Users\Jose Carlos\Documents\GitHub\RespladoProyectoASP\Respaldos\BaseImport.accdb"
        Suvir.PostedFile.SaveAs(TargetPath)
        Dim obj1 As New ConeccionChepe
        obj1.conectar()
        Dim obj2 As New ConeccionAcces
        obj2.ini()
        ConsultaInser = "delete from SubTarea_Independiente"
        obj1.envia(ConsultaInser)
        ConsultaInser = "DBCC CHECKIDENT (SubTarea_Independiente, RESEED,0)"
        obj1.envia(ConsultaInser)
        Dim Consulta As String = "SELECT * FROM SUBTAREA_INDEPENDITE"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO SubTarea_Independiente values ('" & obj2.reg("DESCRIPCION") & "')"
            obj1.envia(ConsultaInser)
        End While

        obj1.desconectar()
        obj2.fin()

    End Sub
End Class
