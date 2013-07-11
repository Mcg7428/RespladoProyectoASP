Imports Excel = Microsoft.Office.Interop.Excel

Partial Class Default2
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles importa.Click
        Dim ConsultaInser As String
        Dim Consulta As String
        Dim TargetPath As String = "C:\Users\Jose Carlos\Documents\GitHub\RespladoProyectoASP\respaldos\BaseImport1.xlsx"
        Suvir.PostedFile.SaveAs(TargetPath)
        Dim obj1 As New ConeccionChepe
        obj1.conectar()

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim rCnt As Integer
        Dim cCnt As Integer
        Dim Obj As Object

        xlApp = New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Open("C:\Users\Jose Carlos\Documents\GitHub\RespladoProyectoASP\respaldos\BaseImport1.xlsx")
       
        ''Dim obj2 As New ConeccionAcces
        ''obj2.ini()
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

        xlWorkSheet = xlWorkBook.Worksheets("MANTENIMIENTO")
        range = xlWorkSheet.UsedRange

        For rCnt = 2 To range.Rows.Count
            ConsultaInser = "INSERT INTO Mantenimiento values ('" & range.Cells(rCnt, 1).value & "','" & range.Cells(rCnt, 2).value & "','" & range.Cells(rCnt, 3).value & "')"
            obj1.envia(ConsultaInser)
        Next

        'Consulta = "SELECT * FROM MANTENIMIENTO"
        'obj2.recibe(Consulta)
        'While obj2.reg.Read
        '    ConsultaInser = "INSERT INTO Mantenimiento values ('" & obj2.reg("Campo1") & "','" & obj2.reg("Campo2") & "','" & obj2.reg("Campo3") & "')"
        '    obj1.envia(ConsultaInser)
        'End While

        '' importando a Tarea

        xlWorkSheet = xlWorkBook.Worksheets("TAREA")
        range = xlWorkSheet.UsedRange

        For rCnt = 2 To range.Rows.Count
            ConsultaInser = "INSERT INTO Tarea values ('" & range.Cells(rCnt, 1).value & "','" & range.Cells(rCnt, 2).value & "','" & range.Cells(rCnt, 3).value & "','" & range.Cells(rCnt, 4).value & "')"
            obj1.envia(ConsultaInser)
        Next

        'Consulta = "SELECT * FROM TAREA"
        'obj2.recibe(Consulta)
        'While obj2.reg.Read
        '    ConsultaInser = "INSERT INTO Tarea values ('" & obj2.reg("IDTAREA") & "','" & obj2.reg("id MANTENIMIENT") & "','" & obj2.reg("descripcion") & "','" & obj2.reg("No de subtarea") & "')"
        '    obj1.envia(ConsultaInser)
        'End While

        ' '' importando a SubTarea

        xlWorkSheet = xlWorkBook.Worksheets("SUBTAREA")
        range = xlWorkSheet.UsedRange

        For rCnt = 2 To range.Rows.Count
            ConsultaInser = "INSERT INTO SubTarea values ('" & range.Cells(rCnt, 1).value & "','" & range.Cells(rCnt, 2).value & "','" & range.Cells(rCnt, 3).value & "')"
            obj1.envia(ConsultaInser)
        Next

        'Consulta = "SELECT * FROM SubTarea"
        'obj2.recibe(Consulta)
        'While obj2.reg.Read
        '    ConsultaInser = "INSERT INTO SubTarea values ('" & obj2.reg("ID_SUBTAREA") & "','" & obj2.reg("ID_TAREA_ST") & "','" & obj2.reg("DESCRIPCION") & "')"
        '    obj1.envia(ConsultaInser)
        'End While

        ' '' importando a Tarea_INndividual

        xlWorkSheet = xlWorkBook.Worksheets("TAREA INDIVIDUAL")
        range = xlWorkSheet.UsedRange

        For rCnt = 2 To range.Rows.Count
            ConsultaInser = "INSERT INTO Tarea_Individual values ('" & range.Cells(rCnt, 1).value & "','" & range.Cells(rCnt, 2).value & "','" & range.Cells(rCnt, 3).value & "')"
            obj1.envia(ConsultaInser)
        Next

        'Consulta = "SELECT * FROM TAREAINDIVIDUAL"
        'obj2.recibe(Consulta)
        'While obj2.reg.Read
        '    ConsultaInser = "INSERT INTO Tarea_Individual values ('" & obj2.reg("descripcion") & "','" & obj2.reg("No de subtarea") & "','" & obj2.reg("No tarea") & "')"
        '    obj1.envia(ConsultaInser)
        'End While

        ' '' importando a Tarea_INndividual

        xlWorkSheet = xlWorkBook.Worksheets("SUBTAREA INDIVIDUAL")
        range = xlWorkSheet.UsedRange

        For rCnt = 2 To range.Rows.Count
            ConsultaInser = "INSERT INTO SubTarea_Individual values ('" & range.Cells(rCnt, 1).value & "','" & range.Cells(rCnt, 2).value & "','" & range.Cells(rCnt, 3).value & "')"
            obj1.envia(ConsultaInser)
        Next

        'Consulta = "SELECT * FROM SUBTAREAINDIVIDUAL"
        'obj2.recibe(Consulta)
        'While obj2.reg.Read
        '    ConsultaInser = "INSERT INTO SubTarea_Individual values ('" & obj2.reg("TAREA + SUBTAREA") & "','" & obj2.reg("TAREA") & "','" & obj2.reg("DESCRIPCION") & "')"
        '    obj1.envia(ConsultaInser)
        'End While

        ' '' importando a Tarea_Independiente

        xlWorkSheet = xlWorkBook.Worksheets("SUBTAREA INDEPENDITE")
        range = xlWorkSheet.UsedRange

        For rCnt = 2 To range.Rows.Count
            ConsultaInser = "INSERT INTO SubTarea_Independiente values ('" & range.Cells(rCnt, 1).value & "')"
            obj1.envia(ConsultaInser)
        Next

        'Consulta = "SELECT * FROM SUBTAREAINDEPENDITE"
        'obj2.recibe(Consulta)
        'While obj2.reg.Read
        '    ConsultaInser = "INSERT INTO SubTarea_Independiente values ('" & obj2.reg("descripcion") & "')"
        '    obj1.envia(ConsultaInser)
        'End While




       

       
       

        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

      

        obj1.desconectar()
        '' obj2.fin()

    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class
