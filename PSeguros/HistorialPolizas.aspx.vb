Imports Dominio
Imports Infraestructura

Partial Class HistorialPolizas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPolizas()

        End If
    End Sub

    Private Sub CargarPolizas()
        Dim polizas As List(Of Poliza) = BaseDeDatos.Instance.GetHistoriaPoliza()
        If polizas IsNot Nothing AndAlso polizas.Count > 0 Then
            gvPolizas.DataSource = polizas
            gvPolizas.DataBind()
        Else
            Console.WriteLine("No se encontraron pólizas.")
        End If
    End Sub
End Class
