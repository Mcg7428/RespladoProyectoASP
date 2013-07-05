
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Conectado") = "Yes" Then ''comprobar si esta conectado
            Response.Redirect("DefaultMaster.aspx") ''pagina de inicio
        End If
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Dim obj As New ConeccionChepe ''Crea coneccion
        Dim texto As String = "SELECT * FROM Usuario WHERE USUARIO = '" & nombre.Text & "' and CLAVE = '" & contrasna.Text & "'" ''Consulta
        obj.conectar() ''Se conecta
        obj.Obtener(texto) ''Realiza la coneccion
        If obj.Arreglo.HasRows = True Then ''hay algun usuario con lass carrecticas
            obj.Arreglo.Read() ''busca la datos

            ''Anade informacion a la ssecion
            Session("Usuario") = obj.Arreglo("NOMBRE") ''Nombre de usuario
            Session("Cargo") = obj.Arreglo("CARGO") ''Los cargo o permiso
            Session("Departamento") = obj.Arreglo("DEPARTAMENTO") ''Departamento que trabaja
            Session("Conectado") = "Yes" ''opcion que esta conectado

            obj.desconectar() ''Se cierra a coneccion''

            Response.Redirect("~/DefaultMaster.aspx") ''enviar a pagina pirncipal
        Else
            MError.Text = "Error Intente de nuevo" ''envia el error
        End If
    End Sub
End Class
