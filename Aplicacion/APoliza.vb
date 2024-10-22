Imports Dominio
Imports Infraestructura

Public Class APoliza
    Inherits System.Web.UI.Page

    Private _db As BaseDeDatos

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        _db = New BaseDeDatos()

        If Not IsPostBack Then
            CargarRamos()
        End If
    End Sub

    ' Cargar Ramos en el DropDownList
    Private Sub CargarRamos()
        ddlRamo.DataSource = _db.ObtenerRamos()
        ddlRamo.DataTextField = "Nombre"  ' Propiedad para mostrar
        ddlRamo.DataValueField = "Id"  ' Propiedad con el valor del Ramo
        ddlRamo.DataBind()
        ddlRamo.Items.Insert(0, New ListItem("-- Seleccione un Ramo --", "0"))
    End Sub

    ' Cargar Productos cuando se selecciona un Ramo
    Protected Sub ddlRamo_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim ramoId As Integer = Convert.ToInt32(ddlRamo.SelectedValue)
        ddlProducto.DataSource = _db.ObtenerProductosPorRamo(ramoId)
        ddlProducto.DataTextField = "Nombre"
        ddlProducto.DataValueField = "Id"
        ddlProducto.DataBind()
        ddlProducto.Items.Insert(0, New ListItem("-- Seleccione un Producto --", "0"))

        ddlPoliza.Items.Clear()
    End Sub

    ' Cargar Pólizas cuando se selecciona un Producto
    Protected Sub ddlProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim productoId As Integer = Convert.ToInt32(ddlProducto.SelectedValue)
        ddlPoliza.DataSource = _db.ObtenerPolizasPorProducto(productoId)
        ddlPoliza.DataTextField = "Nombre"
        ddlPoliza.DataValueField = "Id"
        ddlPoliza.DataBind()
        ddlPoliza.Items.Insert(0, New ListItem("-- Seleccione una Póliza --", "0"))
    End Sub
End Class

End Class
