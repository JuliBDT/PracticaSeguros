Imports Aplicacion
Imports Dominio

Public Class RolesDePoliza
    Inherits System.Web.UI.Page
    Dim acontrolador As Controlador = Controlador.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim ramoId As Integer
            Dim productoId As Integer
            Dim polizaId As Integer
            If Integer.TryParse(Request.QueryString("polizaId"), polizaId) AndAlso
               Integer.TryParse(Request.QueryString("ramo"), ramoId) AndAlso
               Integer.TryParse(Request.QueryString("producto"), productoId) Then
                Dim roles As List(Of Rol) = acontrolador.ObtenerRolesDePoliza(ramoId, productoId, polizaId)
                If roles IsNot Nothing AndAlso roles.Count > 0 Then
                    gvRoles.DataSource = roles
                    gvRoles.DataBind()
                Else
                    Console.WriteLine("No se encontraron roles para la póliza.")
                End If
            End If
        End If
    End Sub
End Class