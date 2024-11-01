Imports Aplicacion

Public Class AgregarCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarEstadoCivil()
        End If
    End Sub
    Private Sub CargarEstadoCivil()
        ddlEstadoCivil.DataSource = Controlador.Instance.ObtenerEstadoCivil()
        ddlEstadoCivil.DataTextField = "Descripcion"
        ddlEstadoCivil.DataValueField = "ID"
        ddlEstadoCivil.DataBind()
        ddlEstadoCivil.Items.Insert(0, New ListItem("--Seleccione una opción--", "0"))
        ddlEstadoCivil.Items(0).Attributes.Add("disabled", "true")
        ddlEstadoCivil.SelectedIndex = 0
    End Sub
    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim documento As String = Convert.ToString(txtDocumento.Text)
        Dim nombre As String = Convert.ToString(txtNombre.Text)
        Dim fechaNacimiento As Date = Convert.ToDateTime(txtFechaNacimiento.Text)
        Dim estadoCivil As Integer = Convert.ToInt32(ddlEstadoCivil.SelectedValue)
        Controlador.Instance.AddCliente(documento, nombre, fechaNacimiento, estadoCivil - 1)
        ' Limpiar el formulario
        LimpiarFormulario()
    End Sub
    Private Sub LimpiarFormulario()
        ddlEstadoCivil.SelectedIndex = 0
        txtDocumento.Text = String.Empty
        txtNombre.Text = String.Empty
        txtFechaNacimiento.Text = String.Empty
    End Sub

End Class