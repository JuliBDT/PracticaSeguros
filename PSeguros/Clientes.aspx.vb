Imports Aplicacion
Imports Dominio
Imports Infraestructura

Public Class Clientes
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clientes As List(Of Cliente) = Controlador.Instance.ListarClientes()
        If clientes IsNot Nothing AndAlso clientes.Count > 0 Then
            gvClientes.DataSource = clientes
            gvClientes.DataBind()
        Else
            Console.WriteLine("No se encontraron pólizas.")
        End If
    End Sub

End Class