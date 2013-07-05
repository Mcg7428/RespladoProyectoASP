
Partial Class Exportar
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ConsultaInser As String
        Dim Consulta As String
        Dim TargetPath As String = "C:\Users\Jose Carlos\Documents\GitHub\RespladoProyectoASP\Respaldos\BaseImport.accdb"
        Suvir.PostedFile.SaveAs(TargetPath)
        Dim obj2 As New ConeccionChepe

        Dim obj1 As New ConeccionAcces
        obj1.ini()
        obj2.conectar()
        ' ConsultaInser = "delete from SubTarea_Independiente"
        'obj1.envia(ConsultaInser)
        'ConsultaInser = "delete from SubTarea_Individual"
        'obj1.envia(ConsultaInser)
        'ConsultaInser = "delete from Tarea_Individual"
        'obj1.envia(ConsultaInser)
        'ConsultaInser = "delete from SubTarea"
        'obj1.envia(ConsultaInser)
        'ConsultaInser = "delete from Tarea"
        'obj1.envia(ConsultaInser)
        'ConsultaInser = "delete from Mantenimiento"
        'obj1.envia(ConsultaInser)



        'ConsultaInser = "DBCC CHECKIDENT (Tarea_Individual, RESEED,0)"
        'obj1.envia(ConsultaInser)


        '' importando a Mantenimiento

        Consulta = "SELECT * FROM´Mantenimiento"
        obj1.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO MANTENIMIENTO values ('" & obj2.reg("ID_MANTENIMIENTO") & "','" & obj2.reg("NOMBRE") & "','" & obj2.reg("NUM_TAREAS") & "')"
            obj1.envia(ConsultaInser)
        End While

        '' importando a Tarea

        Consulta = "SELECT * FROM Tarea"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO TAREA values ('" & obj2.reg("ID_TAREA") & "','" & obj2.reg("ID_MANTE_T") & "','" & obj2.reg("NOMBRE_TAREA") & "','" & obj2.reg("NUM_SUBTAR") & "')"
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

        Consulta = "SELECT * FROM SubTarea_Individual"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO SUBTAREAINDIVIDUAL values ('" & obj2.reg("ID_SUBTAREA_IND") & "','" & obj2.reg("ID_TAREA_STIND") & "','" & obj2.reg("DESCRIPCION") & "')"
            obj1.envia(ConsultaInser)
        End While

        '' importando a Tarea_Independiente

        Consulta = "SELECT * FROM SubTarea_Independiente"
        obj2.recibe(Consulta)
        While obj2.reg.Read
            ConsultaInser = "INSERT INTO SUBTAREAINDEPENDITE values ('" & obj2.reg("DESCRIPCION") & "','" & obj2.reg("DESCRIPCION") & ")"
            obj1.envia(ConsultaInser)
        End While



        obj2.desconectar()
        obj1.fin()

        download()

    End Sub

    Private Sub download()
        'Fuerzo el Dialogo de Download
        Dim sPathFile As String
        'Guardo el path del archivo
        sPathFile = "C:\Users\Jose Carlos\Documents\GitHub\RespladoProyectoASP\Respaldos\BaseImport.accdb"
        'Armo la cabecera del diálogo para exportar el XML
        Response.AddHeader("content-disposition", "attachment; filename=" & sPathFile)
        Response.ContentType = "Application/x-msXML"
        'Leo el archivo con un StreamReader
        Dim reader As New IO.StreamReader(sPathFile)
        'Le asigno al lector Binario, el Stream base del archivo
        Dim stream As New IO.BinaryReader(reader.BaseStream)
        'Escribo en el diálogo de exportación, el archivo completo
        Response.BinaryWrite(stream.ReadBytes(stream.BaseStream.Length))
        'Cierro el Stream
        reader.Close()
        stream.Close()
    End Sub
End Class
