Imports Aplicacion
Imports Dominio

Public Class PolizasCliente
    Inherits System.Web.UI.Page
    Dim aControlador As Controlador = Controlador.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim clienteId As String = Request.QueryString("clienteId")
            If Not String.IsNullOrEmpty(clienteId) Then
                ' Obtener pólizas activas del cliente
                Dim polizas As List(Of Poliza) = aControlador.PolizasPorCliente(clienteId)

                If polizas IsNot Nothing AndAlso polizas.Count > 0 Then
                    gvPolizas.DataSource = polizas
                    gvPolizas.DataBind()
                Else
                    ' Mensaje para indicar que no hay pólizas activas
                    gvPolizas.EmptyDataText = "No hay pólizas activas para este cliente."
                    gvPolizas.DataBind()
                End If
            End If
        End If
    End Sub
End Class
