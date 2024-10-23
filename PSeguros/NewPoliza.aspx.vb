Imports Aplicacion
Imports Dominio

Public Class NewPoliza
    Inherits System.Web.UI.Page
    Dim aPoliza As APoliza = APoliza.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarRamos()
            CargarWayPay()
            CargarProductos()
        End If
    End Sub

    Private Sub CargarRamos()
        ddlRamos.DataSource = aPoliza.ObtenerListaRamos()
        ddlRamos.DataTextField = "Nombre"
        ddlRamos.DataValueField = "Id"
        ddlRamos.DataBind()
        ddlRamos.Items.Insert(0, New ListItem("--Seleccione un Ramo--", "0"))
    End Sub

    ' Evento que se dispara cuando se selecciona un ramo
    Protected Sub ddlRamo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlRamos.SelectedIndexChanged
        If ddlRamos.SelectedIndex > 0 Then
            Dim idRamo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)

            ' Cargar las pólizas correspondientes al ramo seleccionado
            Dim listaPolizas = aPoliza.ObtenerListaPolizasPorRamo(idRamo)
            ddlPolizas.DataSource = listaPolizas
            ddlPolizas.DataTextField = "Nombre"
            ddlPolizas.DataValueField = "Id"
            ddlPolizas.DataBind()

            ' Insertar la opción "Nueva Póliza"
            ddlPolizas.Items.Insert(0, New ListItem("Nueva Póliza", "NuevaPoliza"))
            ddlPolizas.Items.Insert(1, New ListItem("--Seleccione una Póliza--", "0"))
        Else
            ddlPolizas.Items.Clear()
            ddlPolizas.Items.Insert(0, New ListItem("Nueva Póliza", "NuevaPoliza"))
            ddlPolizas.Items.Insert(1, New ListItem("--Seleccione una Póliza--", "0"))
        End If
    End Sub

    Private Sub CargarProductos()
        ddlProductos.DataSource = aPoliza.ObtenerListaProductos()
        ddlProductos.DataTextField = "Nombre"
        ddlProductos.DataValueField = "Id"
        ddlProductos.DataBind()
        ddlProductos.Items.Insert(0, New ListItem("--Seleccione un Producto--", "0"))
    End Sub

    Private Sub CargarWayPay()
        ddlWayPay.DataSource = aPoliza.ObtenerListaWayPay()
        ddlWayPay.DataTextField = "Nombre"
        ddlWayPay.DataValueField = "Id"
        ddlWayPay.DataBind()
        ddlWayPay.Items.Insert(0, New ListItem("--Seleccione una Forma de Pago--", "0"))
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim idRamo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim idPoliza As Integer = Convert.ToInt32(ddlPolizas.SelectedValue)
        Dim idProducto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim idWayPay As Integer = Convert.ToInt32(ddlWayPay.SelectedValue)
        Dim fechaEfecto As DateTime = Convert.ToDateTime(txtFechaEfecto.Text)
        Dim fechaVigencia As DateTime = Convert.ToDateTime(txtFechaVigencia.Text)

        ' Validar si el usuario seleccionó "Nueva Póliza"
        If idPoliza = "NuevaPoliza" Then
            ' Lógica para manejar la creación de una nueva póliza
            ' Aquí puedes redirigir a otro formulario o mostrar un pop-up para ingresar los detalles de la nueva póliza.
            ' Ejemplo:
            ' Response.Redirect("CrearNuevaPoliza.aspx")
            aPoliza.CrearPoliza(idRamo, idProducto, (aPoliza.ObtenerUltimoidPoliza() + 1), txtClienteTitular.Text, Nothing, fechaEfecto,
                                fechaVigencia, txtDomicilio.Text, txtSumaAsegurada.Text, idWayPay)
        ElseIf idRamo > 0 AndAlso idPoliza > 0 AndAlso idProducto > 0 AndAlso idWayPay > 0 Then
            ' Guardar la póliza existente
            aPoliza.CrearPoliza(idRamo, idProducto, idPoliza, txtClienteTitular.Text, Nothing, fechaEfecto,
                                fechaVigencia, txtDomicilio.Text, txtSumaAsegurada.Text, idWayPay)
        Else
            ' Mostrar un mensaje de error si faltan datos
        End If
    End Sub
End Class
