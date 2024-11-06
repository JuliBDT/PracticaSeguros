Imports Aplicacion
Imports Dominio

Public Class NewPoliza
    Inherits System.Web.UI.Page
    Dim Controlador As Controlador = Controlador.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarRamos()
            'CargarWayPay()
            'CargarClientes()
        Else
            If ddlRamos.Items.Count > 0 Then
                ddlRamos.Items(0).Attributes.Add("disabled", "true")
                'ddlClienteTitular.SelectedIndex = 0
                'ddlWayPay.SelectedIndex = 0
            End If
            If ddlProductos.Items.Count > 0 Then
                ddlProductos.Items(0).Attributes.Add("disabled", "true")
                'ddlClienteTitular.SelectedIndex = 0

                'ddlWayPay.SelectedIndex = 0
            End If
            If ddlClienteTitular.Items.Count > 0 Then
                ddlClienteTitular.Items(0).Attributes.Add("disabled", "true")
            End If
            If ddlWayPay.Items.Count > 0 Then
                ddlWayPay.Items(0).Attributes.Add("disabled", "true")
            End If
        End If
    End Sub

    ' Método para cargar clientes en el dropdownlist de cliente titular
    Private Sub CargarClientes()
        ddlClienteTitular.DataSource = Controlador.ListarClientes()
        ddlClienteTitular.DataTextField = "Nombre"
        ddlClienteTitular.DataValueField = "Cliente"
        ddlClienteTitular.DataBind()

        ddlClienteTitular.Items.Insert(0, New ListItem("--Seleccione un Cliente--", "0"))
        ddlClienteTitular.Items(0).Attributes.Add("disabled", "true")
        ddlClienteTitular.SelectedIndex = 0
    End Sub

    Private Sub CargarRamos()
        ddlRamos.DataSource = Controlador.ObtenerRamos()
        ddlRamos.DataTextField = "Descripcion"
        ddlRamos.DataValueField = "Ramo"
        ddlRamos.DataBind()

        ddlRamos.Items.Insert(0, New ListItem("--Seleccione un Ramo--", "0"))
        ddlRamos.Items(0).Attributes.Add("disabled", "true")
        ddlRamos.SelectedIndex = 0
    End Sub

    ' Evento que se dispara cuando se selecciona un ramo
    Protected Sub ddlRamo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlRamos.SelectedIndexChanged
        If ddlRamos.SelectedIndex > 0 Then
            Dim idRamo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)

            Dim listaProductos = Controlador.ObtenerProductosPorRamo(idRamo)
            ddlProductos.DataSource = listaProductos
            ddlProductos.DataTextField = "Descripcion"
            ddlProductos.DataValueField = "Producto"
            ddlProductos.DataBind()

            ddlProductos.Items.Insert(0, New ListItem("--Seleccione un Producto--", "0"))
            ddlProductos.Items(0).Attributes.Add("disabled", "true")
            ddlProductos.SelectedIndex = 0

            CargarClientes()
            CargarWayPay()
        End If
    End Sub

    Private Sub CargarWayPay()
        ddlWayPay.DataSource = Controlador.ObtenerListaWayPay()
        ddlWayPay.DataTextField = "Descripcion"
        ddlWayPay.DataValueField = "WayPay"
        ddlWayPay.DataBind()

        ddlWayPay.Items.Insert(0, New ListItem("--Seleccione una Forma de Pago--", "0"))
        ddlWayPay.Items(0).Attributes.Add("disabled", "true")
        ddlWayPay.SelectedIndex = 0
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim idRamo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim idProducto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim idWayPay As Integer = Convert.ToInt32(ddlWayPay.SelectedValue)

        Dim fechaEfecto As DateTime
        If String.IsNullOrEmpty(txtFechaEfecto.Text) Then
            fechaEfecto = Now
        Else
            fechaEfecto = Convert.ToDateTime(txtFechaEfecto.Text)
        End If

        Dim fechaVigencia As DateTime
        If String.IsNullOrEmpty(txtFechaVigencia.Text) Then
            fechaVigencia = Now
        Else
            fechaVigencia = Convert.ToDateTime(txtFechaVigencia.Text)
        End If

        Dim cliente As String = ddlClienteTitular.SelectedValue


        Dim idPoliza As Integer = (Controlador.ObtenerUltimoidPoliza(idRamo, idProducto) + 1)
        Dim idRolClienteTitular As Integer = 1

        Controlador.CrearPoliza(idRamo, idProducto, idPoliza, cliente, fechaEfecto,
                                fechaVigencia, txtDomicilio.Text, txtSumaAsegurada.Text, idWayPay)

        Controlador.CrearRol(idRamo, idProducto, idPoliza, idRolClienteTitular, cliente, fechaEfecto)
        LimpiarFormulario()
    End Sub

    Private Sub LimpiarFormulario()
        ddlRamos.SelectedIndex = 0
        ddlProductos.SelectedIndex = 0
        ddlWayPay.SelectedIndex = 0
        ddlClienteTitular.SelectedIndex = 0
        txtFechaEfecto.Text = String.Empty
        txtFechaVigencia.Text = String.Empty
        txtDomicilio.Text = String.Empty
        txtSumaAsegurada.Text = String.Empty
    End Sub
End Class
