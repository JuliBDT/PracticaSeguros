Imports Aplicacion
Imports Dominio

Public Class Clientes
    Inherits System.Web.UI.Page
    Dim acontrolador As Controlador = Controlador.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clientes As List(Of Rol) = acontrolador.RolesActivos()
        If clientes IsNot Nothing AndAlso clientes.Count > 0 Then
            gvClientes.DataSource = clientes
            gvClientes.DataBind()
        Else
            Console.WriteLine("No se encontraron rol.")
        End If
    End Sub

End Class