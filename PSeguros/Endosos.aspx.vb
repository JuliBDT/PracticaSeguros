Public Class Endosos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click()
        Dim ramo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim prducot As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim poliza As Integer = Convert.ToInt32(ddlPolizas.SelectedValue)
    End Sub

End Class