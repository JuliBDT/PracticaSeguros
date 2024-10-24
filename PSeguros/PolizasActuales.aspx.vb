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

End Class