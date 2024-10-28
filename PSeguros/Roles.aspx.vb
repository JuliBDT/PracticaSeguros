Imports Aplicacion
Imports Dominio

Public Class Roles
    Inherits System.Web.UI.Page
    Dim Controlador As Controlador = Controlador.Instance

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarRamos()
            CargamosTiposDeRol()
        End If
    End Sub

    Private Sub CargamosTiposDeRol()
        ddlRol.DataSource = Controlador.ObtenerListaRoles()
        ddlRol.DataTextField = "Descripcion"
        ddlRol.DataValueField = "Rol"
        ddlRol.DataBind()
        ddlRol.Items.Insert(0, New ListItem("--Seleccione un Rol--", "0"))
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

    Protected Sub ddlProductos_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlProductos.SelectedIndexChanged
        If ddlProductos.SelectedIndex > 0 And ddlRamos.SelectedIndex > 0 Then
            Dim idRamo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
            Dim idProducto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)

            ' Obtener las pólizas disponibles para el ramo y producto seleccionados
            ddlPoliza.DataSource = Controlador.PolizaPorRamoYProducto(idRamo, idProducto)
            ddlPoliza.DataValueField = "Poliza"
            ddlPoliza.DataBind()
            ddlPoliza.Items.Insert(0, New ListItem("--Seleccione una Póliza--", "0"))
        Else
            ' Limpia el DropDownList de pólizas si no se ha seleccionado correctamente
            ddlPoliza.Items.Clear()
            ddlPoliza.Items.Insert(0, New ListItem("--Seleccione una Póliza--", "0"))
        End If
    End Sub


    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim idRamo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim idProducto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim idPoliza As Integer = Convert.ToInt32(ddlPoliza.SelectedValue)
        Dim idRol As Integer = Convert.ToInt32(ddlRol.SelectedValue)
        Dim fechaEfecto As DateTime = Convert.ToDateTime(txtFechaEfecto.Text)

        Controlador.CrearRol(idRamo, idProducto, idPoliza, idRol, txtClienteTitular.Text, fechaEfecto)

        ' Limpiar el formulario
        LimpiarFormulario()
    End Sub

    Private Sub LimpiarFormulario()
        ddlRamos.SelectedIndex = 0
        ddlProductos.SelectedIndex = 0
        txtClienteTitular.Text = String.Empty
        txtFechaEfecto.Text = String.Empty
    End Sub
End Class