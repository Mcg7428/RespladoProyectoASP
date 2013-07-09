
Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles importa.Click
        Dim ConsultaInser As String
        Dim Consulta As String
        Dim TargetPath As String = "C:\Users\Mcg\Documents\GitHub\RespladoProyectoASP\respaldos\BaseImport.accdb"
        Suvir.PostedFile.SaveAs(TargetPath)
        Dim obj1 As New ConeccionChepe
        obj1.conectar()
        Dim obj2 As New ConeccionAcces
        obj2.ini()
        ConsultaInser = "delete from SubTarea_Independiente"
        obj1.envia(ConsultaInser)
        ConsultaInser = "delete from SubTarea_Individual"
        obj1.envia(ConsultaInser)
        ConsultaInser = "delete from Tarea_Individual"
        obj1.envia(ConsultaInser)
        ConsultaInser = "delete from SubTarea"
        obj1.envia(ConsultaInser)
        ConsultaInser = "delete from Tarea"
        obj1.envia(ConsultaInser)
        ConsultaInser = "delete from Mantenimiento"
        obj1.envia(ConsultaInser)
      
       

        ConsultaInser = "DBCC CHECKIDENT (Tarea_Individual, RESEED,0)"
        obj1.envia(ConsultaInser)


        '' importando a Mantenimiento

        Consulta = "SELECT * FROM MANTENIMIENTO"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO Mantenimiento values ('" & obj2.reg("Campo1") & "','" & obj2.reg("Campo2") & "','" & obj2.reg("Campo3") & "')"
            obj1.envia(ConsultaInser)
        End While

        '' importando a Tarea

        Consulta = "SELECT * FROM TAREA"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO Tarea values ('" & obj2.reg("IDTAREA") & "','" & obj2.reg("id MANTENIMIENT") & "','" & obj2.reg("descripcion") & "','" & obj2.reg("No de subtarea") & "')"
            obj1.envia(ConsultaInser)
        End While

        '' importando a SubTarea

        Consulta = "SELECT * FROM SubTarea"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO SubTarea values ('" & obj2.reg("ID_SUBTAREA") & "','" & obj2.reg("ID_TAREA_ST") & "','" & obj2.reg("DESCRIPCION") & "')"
            obj1.envia(ConsultaInser)
        End While

        '' importando a Tarea_INndividual

        Consulta = "SELECT * FROM TAREAINDIVIDUAL"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO Tarea_Individual values ('" & obj2.reg("descripcion") & "','" & obj2.reg("No de subtarea") & "','" & obj2.reg("No tarea") & "')"
            obj1.envia(ConsultaInser)
        End While

        '' importando a Tarea_INndividual

        Consulta = "SELECT * FROM SUBTAREAINDIVIDUAL"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO SubTarea_Individual values ('" & obj2.reg("TAREA + SUBTAREA") & "','" & obj2.reg("TAREA") & "','" & obj2.reg("DESCRIPCION") & "')"
            obj1.envia(ConsultaInser)
        End While

        '' importando a Tarea_Independiente

        Consulta = "SELECT * FROM SUBTAREAINDEPENDITE"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO SubTarea_Independiente values ('" & obj2.reg("descripcion") & "')"
            obj1.envia(ConsultaInser)
        End While




       

       
       

       

      

        obj1.desconectar()
        obj2.fin()

    End Sub
End Class
