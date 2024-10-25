Imports Aplicacion
Imports Dominio

Public Class NewPoliza
    Inherits System.Web.UI.Page
    Dim Controlador As Controlador = Controlador.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarRamos()
            CargarWayPay()
            CargarClientes()
        End If
    End Sub

    ' Método para cargar clientes en el dropdownlist de cliente titular
    Private Sub CargarClientes()
        ddlClienteTitular.DataSource = Controlador.ObtenerClientes()
        ddlClienteTitular.DataTextField = "Cliente"
        ddlClienteTitular.DataValueField = "Nombre"
        ddlClienteTitular.DataBind()
        ddlClienteTitular.Items.Insert(0, New ListItem("--Seleccione un Cliente--", "0"))
    End Sub

    Private Sub CargarRamos()
        ddlRamos.DataSource = Controlador.ObtenerRamos()
        ddlRamos.DataTextField = "Descripcion"
        ddlRamos.DataValueField = "Ramo"
        ddlRamos.DataBind()
        ddlRamos.Items.Insert(0, New ListItem("--Seleccione un Ramo--", "0"))
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

        End If
    End Sub

    Private Sub CargarWayPay()
        ddlWayPay.DataSource = Controlador.ObtenerListaWayPay()
        ddlWayPay.DataTextField = "Descripcion"
        ddlWayPay.DataValueField = "WayPay"
        ddlWayPay.DataBind()
        ddlWayPay.Items.Insert(0, New ListItem("--Seleccione una Forma de Pago--", "0"))
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim idRamo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim idProducto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim idWayPay As Integer = Convert.ToInt32(ddlWayPay.SelectedValue)
        Dim fechaEfecto As DateTime = Convert.ToDateTime(txtFechaEfecto.Text)
        Dim fechaVigencia As DateTime = Convert.ToDateTime(txtFechaVigencia.Text)
        Dim cliente As String = ddlClienteTitular.SelectedValue
        Dim idPoliza As Integer = (Controlador.ObtenerUltimoidPoliza() + 1)
        Dim idRol As Integer = 1

        Controlador.CrearPoliza(idRamo, idProducto, idPoliza, cliente, Nothing, fechaEfecto,
                                fechaVigencia, txtDomicilio.Text, txtSumaAsegurada.Text, idWayPay)

        Controlador.CrearRol(idRamo, idProducto, idPoliza, idRol, cliente, fechaEfecto)
        LimpiarFormulario()
    End Sub

    ' Método para cargar el dropdownlist de roles
    Private Sub CargarRoles(ddl As DropDownList)
        ddl.DataSource = Controlador.ObtenerListaRoles()
        ddl.DataTextField = "Descripcion"
        ddl.DataValueField = "Rol"
        ddl.DataBind()
        ddl.Items.Insert(0, New ListItem("--Seleccione un Rol--", "0"))
    End Sub


    ' Método que se ejecuta al presionar el botón Agregar Rol
    Protected Sub btnAgregarRol_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAgregarRol.Click
        ' Crear una nueva fila con dropdowns dinámicamente
        Dim fila As New TableRow()

        ' Columna para el dropdownlist de clientes
        Dim celdaCliente As New TableCell()
        Dim ddlCliente As New DropDownList()
        ddlCliente.CssClass = "form-control"
        CargarClientes(ddlCliente) ' Asegúrate de cargar correctamente los clientes en este DropDownList
        celdaCliente.Controls.Add(ddlCliente)
        fila.Cells.Add(celdaCliente)

        ' Columna para el dropdownlist de roles
        Dim celdaRol As New TableCell()
        Dim ddlRol As New DropDownList()
        ddlRol.CssClass = "form-control"
        CargarRoles(ddlRol) ' Asegúrate de cargar correctamente los roles en este DropDownList
        celdaRol.Controls.Add(ddlRol)
        fila.Cells.Add(celdaRol)

        ' Columna para el botón de eliminar
        Dim celdaEliminar As New TableCell()
        Dim btnEliminar As New Button()
        btnEliminar.Text = "-"
        btnEliminar.CssClass = "btn btn-danger"
        AddHandler btnEliminar.Click, AddressOf EliminarFila
        celdaEliminar.Controls.Add(btnEliminar)
        fila.Cells.Add(celdaEliminar)

        ' Agregar la fila a la tabla
        tblRolesBody.Rows.Add(fila)

        ' Mostrar la tabla de roles
        pnlRoles.Visible = True
    End Sub

    Private Sub CargarClientes(ddlCliente As DropDownList)
        ddlCliente.DataSource = Controlador.ObtenerClientes()
        ddlCliente.DataTextField = "Nombre"
        ddlCliente.DataValueField = "Cliente"
        ddlCliente.DataBind()
        ddlCliente.Items.Insert(0, New ListItem("--Seleccione un Cliente--", "0"))
    End Sub

    Protected Sub EliminarFila(ByVal sender As Object, ByVal e As EventArgs)
        Dim btnEliminar As Button = CType(sender, Button)
        Dim fila As TableRow = CType(btnEliminar.Parent.Parent, TableRow)
        tblRolesBody.Rows.Remove(fila)

        ' Si no hay más filas, ocultar el panel de roles
        If tblRolesBody.Rows.Count = 0 Then ' Verificar si sólo queda la cabecera
            pnlRoles.Visible = False
        End If
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
