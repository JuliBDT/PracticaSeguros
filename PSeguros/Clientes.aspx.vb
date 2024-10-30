Imports Aplicacion
Imports Dominio

Public Class Clientes
    Inherits System.Web.UI.Page
    Dim aControlador As Controlador = Controlador.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim clientes As List(Of Cliente) = aControlador.ObtenerClientes()
            gvClientes.DataSource = clientes
            gvClientes.DataBind()
        End If
    End Sub

    Protected Sub gvClientes_RowCommand(sender As Object, e As GridViewCommandEventArgs)
        If e.CommandName = "VerPolizas" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = gvClientes.Rows(index)
            Dim clienteId As String = row.Cells(1).Text
            Response.Redirect($"PolizasCliente.aspx?clienteId={clienteId}")
        End If
    End Sub
End Class
