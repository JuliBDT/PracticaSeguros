Imports System
Imports Aplicacion
Imports Dominio
Imports Infraestructura

Public Class Endosos
    Inherits System.Web.UI.Page
    Dim acontrolador As Controlador = Controlador.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarRamos()

            CargamosTiposDeRol()

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
            If ddlPolizas.Items.Count > 0 Then
                ddlPolizas.Items(0).Attributes.Add("disabled", "true")

            End If
            If ddlClienteTitular.Items.Count > 0 Then
                ddlClienteTitular.Items(0).Attributes.Add("disabled", "true")
            End If
            If ddlWayPay.Items.Count > 0 Then
                ddlWayPay.Items(0).Attributes.Add("disabled", "true")
            End If
            If ddlRol.Items.Count > 0 Then
                ddlRol.Items(0).Attributes.Add("disabled", "true")
            End If
            If ddlClienteRol.Items.Count > 0 Then
                ddlClienteRol.Items(0).Attributes.Add("disabled", "true")
            End If
        End If
    End Sub

    Private Sub CargarRamos()
        ddlRamos.DataSource = acontrolador.ObtenerRamos
        ddlRamos.DataTextField = "Descripcion"
        ddlRamos.DataValueField = "Ramo"
        ddlRamos.DataBind()
        ddlRamos.Items.Insert(0, New ListItem("--Seleccione un Ramo--", "0"))
        ddlRamos.Items(0).Attributes.Add("disabled", "true")
        ddlRamos.SelectedIndex = 0

        CargarClientes()
        CargarWayPay()
    End Sub

    Private Sub CargarClientes()
        ddlClienteTitular.DataSource = acontrolador.ObtenerClientes()
        ddlClienteTitular.DataTextField = "Cliente"
        ddlClienteTitular.DataValueField = "Nombre"
        ddlClienteTitular.DataBind()

        ddlClienteTitular.Items.Insert(0, New ListItem("--Seleccione un Cliente--", "0"))
        ddlClienteTitular.Items(0).Attributes.Add("disabled", "true")
        'ddlClienteTitular.SelectedIndex = 0


    End Sub

    ' Evento que se dispara cuando se selecciona un ramo
    Protected Sub ddlRamo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlRamos.SelectedIndexChanged
        If ddlRamos.SelectedIndex > 0 Then
            Dim idRamo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)

            ' Cargar las pólizas correspondientes al ramo seleccionado
            Dim listaPolizas = acontrolador.ObtenerListaPolizasPorRamo(idRamo)
            ddlPolizas.DataSource = listaPolizas
            ddlPolizas.DataValueField = "Poliza"
            ddlPolizas.DataBind()

            If Not listaPolizas.Any() Then
                ddlPolizas.Items.Insert(0, New ListItem("No existen polizas para este ramo"))
            End If ' Insertar la opción "Nueva Póliza"
            ddlPolizas.Items.Insert(0, New ListItem("Selecciona una poliza"))

            Dim listaProductos = acontrolador.ObtenerProductosPorRamo(idRamo)
            ddlProductos.DataSource = listaProductos
            ddlProductos.DataTextField = "Descripcion"
            ddlProductos.DataValueField = "Producto"
            ddlProductos.DataBind()
            ddlProductos.Items.Insert(0, New ListItem("--Seleccione un Producto--", "0"))
            ddlProductos.Items(0).Attributes.Add("disabled", "true")
            ddlProductos.SelectedIndex = 0
        Else
            ddlPolizas.Items.Clear()
            ddlPolizas.Items.Insert(0, New ListItem("--Seleccione una Póliza--", "0"))
        End If
    End Sub

    Private Sub CargarWayPay()
        ddlWayPay.DataSource = acontrolador.ObtenerListaWayPay()
        ddlWayPay.DataTextField = "Descripcion"
        ddlWayPay.DataValueField = "WayPay"
        ddlWayPay.DataBind()
        ddlWayPay.Items.Insert(0, New ListItem("--Seleccione una Forma de Pago--", "0"))
        ddlWayPay.Items(0).Attributes.Add("disabled", "true")
        'ddlWayPay.SelectedIndex = 0
    End Sub

    Private Sub CargamosTiposDeRol()
        ddlRol.DataSource = acontrolador.ObtenerListaRolesOracle()
        ddlRol.DataTextField = "Descripcion"
        ddlRol.DataValueField = "Rol"
        ddlRol.DataBind()

        ddlRol.Items.Insert(0, New ListItem("--Seleccione un Rol--", "0"))
        ddlRol.Items(0).Attributes.Add("disabled", "true")
        ddlRol.Items(1).Attributes.Add("disabled", "True")
        ddlRol.SelectedIndex = 0

        CargarClientesRol()
    End Sub

    Private Sub CargarClientesRol()
        ddlClienteRol.DataSource = acontrolador.ObtenerClientes()
        ddlClienteRol.DataTextField = "Cliente"
        ddlClienteRol.DataValueField = "Nombre"
        ddlClienteRol.DataBind()

        ddlClienteRol.Items.Insert(0, New ListItem("--Seleccione un Cliente--", "0"))
        ddlClienteRol.Items(0).Attributes.Add("disabled", "true")
        ddlClienteRol.SelectedIndex = 0
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ramoId As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim productoId As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim wayPay As Integer = Convert.ToInt32(ddlWayPay.SelectedValue)
        Dim fechaEfecto As Date = Convert.ToDateTime(txtFechaEfecto.Text)
        Dim fechaVigencia As Date = Convert.ToDateTime(txtFechaVigencia.Text)
        Dim polizaId As Integer = Convert.ToInt32(ddlPolizas.SelectedValue)
        Dim cliente As String = ddlClienteTitular.SelectedValue
        Dim fechaDefault As Date = Nothing


        If chkHabilitarRol.Checked AndAlso
           ddlRol.SelectedValue = Nothing AndAlso
           ddlClienteRol.SelectedValue = Nothing AndAlso
           txtFechaEfectoRol.Text = Nothing Then
            Dim idRol As Integer = Convert.ToInt32(ddlRol.SelectedValue)
            Dim clienteRol As String = Convert.ToString(ddlClienteRol.SelectedValue)
            Dim fechaEfectoRol As Date = Convert.ToDateTime(txtFechaEfectoRol.Text)

            acontrolador.CrearRol(ramoId, productoId, polizaId, idRol, clienteRol, fechaEfectoRol)
        End If

        acontrolador.EndosarPoliza(ramoId, productoId, polizaId, cliente, fechaEfecto, fechaVigencia,
                                   txtDomicilio.Text, txtSumaAsegurada.Text, wayPay)
        '  acontrolador.EndosarRol(ramoId, productoId, polizaId, 1, cliente, Now)
        LimpiarFormulario()
    End Sub

    Protected Sub btnBaja_Click()
        Dim ramoId As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim productoId As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim polizaId As Integer = Convert.ToInt32(ddlPolizas.SelectedValue)
        acontrolador.BajarPoliza(ramoId, productoId, polizaId)
        acontrolador.darBajaRolesDePoliza(ramoId, productoId, polizaId)

        LimpiarFormulario()
    End Sub

    Protected Sub ddlPoliza_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlPolizas.SelectedIndexChanged
        If ddlPolizas.SelectedIndex > 0 Then
            Dim polizaId As Integer = Convert.ToInt32(ddlPolizas.SelectedValue)
            Dim productoId As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
            Dim ramoId As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
            Dim poliza As Poliza = acontrolador.BuscarPoliza(ramoId, productoId, polizaId)

            If poliza IsNot Nothing Then

                ' For Each item As ListItem In ddlClienteTitular.Items
                'If item.Text = poliza.ClienteTitular Then
                'ddlClienteTitular.DataTextField = item.Value
                'Exit For
                'End If
                'Next

                ddlClienteTitular.SelectedValue = poliza.ClienteTitular
                txtFechaEfecto.Text = poliza.FechaDeEfecto.ToString("yyyy-MM-dd")
                txtFechaVigencia.Text = poliza.FechaDeVigencia.ToString("yyyy-MM-dd")
                txtDomicilio.Text = poliza.Domicilio
                txtSumaAsegurada.Text = poliza.SumaAsegurada.ToString()
                ddlWayPay.SelectedValue = poliza.Waypay
            End If
        End If
    End Sub

    Protected Sub ddlFechaEfectoRol_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ddlClienteRol.SelectedIndex > 0 AndAlso ddlRol.SelectedIndex > 0 Then
            txtFechaEfectoRol.Text = Now
        End If
    End Sub

    Private Sub LimpiarFormulario()
        ddlRamos.SelectedIndex = 0
        ddlProductos.SelectedIndex = 0
        ddlPolizas.SelectedIndex = 0
        ddlWayPay.SelectedIndex = 0
        ddlClienteTitular.SelectedIndex = 0
        txtFechaEfecto.Text = String.Empty
        txtFechaVigencia.Text = String.Empty
        txtDomicilio.Text = String.Empty
        txtSumaAsegurada.Text = String.Empty
        chkHabilitarRol.Checked = False

    End Sub
End Class

