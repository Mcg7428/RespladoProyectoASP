
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub BUsuario_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BUsuario.Click
        Response.Redirect("~/DefaultUsuarios.aspx")
    End Sub

    Protected Sub BUsuario0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BMantenimiento.Click
        Response.Redirect("~/DefaultMantenimiento.aspx")
    End Sub

    Protected Sub BEdificio_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BEdificio.Click
        Response.Redirect("~/DefaultInmuebles.aspx")
    End Sub

    Protected Sub BEquipos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BEquipos.Click
        Response.Redirect("~/DefaultEquipos.aspx")
    End Sub

    Protected Sub BAdmin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BAdmin.Click
        Response.Redirect("~/DefaultReportes_BackUp.aspx")
    End Sub

    Protected Sub BRegistarMantenimiento_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BRegistarMantenimiento.Click
        Response.Redirect("~/DefaultRegManteAsigna.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BSalir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BSalir.Click
        Session("Conectado") = "No" ''opcion que esta conectado
        Response.Redirect("~/Default.aspx") ''enviar a pagina pirncipal
    End Sub
End Class

