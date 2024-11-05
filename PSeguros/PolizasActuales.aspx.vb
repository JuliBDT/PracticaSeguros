Imports Aplicacion
Imports Dominio

Public Class PolizasActuales
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim polizas As List(Of Poliza) = Controlador.Instance.PolizasActivas
            gvPolizas.DataSource = polizas
            gvPolizas.DataBind()
        End If
    End Sub

    Protected Sub gvPolizas_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "VerRoles" Then
            Dim listaRamo = Controlador.Instance.ObtenerRamos
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = gvPolizas.Rows(index)
            Dim ramoId As Integer = Convert.ToInt32(listaRamo.FirstOrDefault(Function(r) r.Descripcion = row.Cells(0).Text).Ramo)
            Dim listaProducto = Controlador.Instance.ObtenerProductosPorRamo(ramoId)
            Dim productoId As Integer = Convert.ToInt32(listaProducto.FirstOrDefault(Function(p) p.Descripcion = row.Cells(1).Text).Producto)
            Dim polizaId As String = row.Cells(2).Text
            Response.Redirect($"RolesDePoliza.aspx?ramo={ramoId}&producto={productoId}&polizaId={polizaId}")

        End If
    End Sub

End Class