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
            CargarWayPay()
        End If
    End Sub

    Private Sub CargarRamos()
        ddlRamos.DataSource = acontrolador.ObtenerRamos
        ddlRamos.DataTextField = "Descripcion"
        ddlRamos.DataValueField = "Ramo"
        ddlRamos.DataBind()
        ddlRamos.Items.Insert(0, New ListItem("--Seleccione un Ramo--", "0"))
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
        Else
            ddlPolizas.Items.Clear()
            ddlPolizas.Items.Insert(0, New ListItem("Nueva Póliza", "NuevaPoliza"))
            ddlPolizas.Items.Insert(1, New ListItem("--Seleccione una Póliza--", "0"))
        End If
    End Sub

    Private Sub CargarWayPay()
        ddlWayPay.DataSource = acontrolador.ObtenerListaWayPay()
        ddlWayPay.DataTextField = "Descripcion"
        ddlWayPay.DataValueField = "WayPay"
        ddlWayPay.DataBind()
        ddlWayPay.Items.Insert(0, New ListItem("--Seleccione una Forma de Pago--", "0"))
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim ramoId As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim productoId As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim wayPay As Integer = Convert.ToInt32(ddlWayPay.SelectedValue)
        Dim fechaEfecto As Date = Convert.ToDateTime(txtFechaEfecto.Text)
        Dim fechaVigencia As Date = Convert.ToDateTime(txtFechaVigencia.Text)
        Dim polizaId As Integer = Convert.ToInt32(ddlPolizas.SelectedValue)

        acontrolador.EndosarPoliza(ramoId, productoId, polizaId, txtClienteTitular.Text, fechaEfecto, fechaVigencia,
                                   txtDomicilio.Text, txtSumaAsegurada.Text, wayPay)

        ' Validar si el usuario seleccionó "Nueva Póliza"
        'If idPoliza = "NuevaPoliza" Then
        ' Lógica para manejar la creación de una nueva póliza
        ' Aquí puedes redirigir a otro formulario o mostrar un pop-up para ingresar los detalles de la nueva póliza.
        ' Ejemplo:
        ' Response.Redirect("CrearNuevaPoliza.aspx")

        ' Guardar la póliza existente
        'If idRamo > 0 AndAlso idPoliza > 0 AndAlso idProducto > 0 AndAlso idWayPay > 0 Then
        'aPoliza.CrearPoliza(idRamo, idProducto, idPoliza, txtClienteTitular.Text, Nothing, fechaEfecto,
        'fechaVigencia, txtDomicilio.Text, txtSumaAsegurada.Text, idWayPay)
        'Else
        ' Mostrar un mensaje de error si faltan datos
        'End If
    End Sub
End Class

