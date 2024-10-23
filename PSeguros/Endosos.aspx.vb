Imports System
Imports Dominio
Imports Infraestructura

Public Class Endosos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarRamos()
        End If
    End Sub

    Private Sub CargarRamos()
        ' Cargar los ramos desde la base de datos
        ddlRamos.DataSource = BaseDeDatos.Instance.ObtenerRamos()
        ddlRamos.DataTextField = "ramo" ' Cambia esto según tu propiedad
        ddlRamos.DataValueField = "Id" ' Cambia esto según tu propiedad
        ddlRamos.DataBind()
    End Sub
    Protected Sub ddlRamo_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Cargar productos según el ramo seleccionado
        Dim ramo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        ddlProductos.DataSource = BaseDeDatos.Instance.ProductoPorRamo(ramo)
        ddlProductos.DataTextField = "Nombre" ' Cambia esto según tu propiedad
        ddlProductos.DataValueField = "Id" ' Cambia esto según tu propiedad
        ddlProductos.DataBind()
    End Sub

    Protected Sub ddlProducto_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Cargar pólizas según el producto seleccionado
        Dim producto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim ramo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        ddlPolizas.DataSource = BaseDeDatos.Instance.PolizaPorRamo(ramo).Where(Function(p) p.Producto = producto).ToList()
        ddlPolizas.DataTextField = "Poliza" ' Cambia esto según tu propiedad
        ddlPolizas.DataValueField = "Poliza" ' Cambia esto según tu propiedad
        ddlPolizas.DataBind()
    End Sub

    Protected Sub ddlPoliza_SelectedIndexChanged(sender As Object, e As EventArgs)
        ' Cargar datos de la póliza seleccionada
        Dim poliza As Integer = Convert.ToInt32(ddlPolizas.SelectedValue)
        Dim ramo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim producto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim polizaEncontrada As Poliza = BaseDeDatos.Instance.BuscarPoliza(poliza, ramo, producto)

        If polizaEncontrada IsNot Nothing Then
            txtClienteTitular.Text = polizaEncontrada.ClienteTitular
            txtFechaEfecto.Text = polizaEncontrada.FechaDeEfecto.ToString
            txtFechaVigencia.Text = polizaEncontrada.FechaDeVigencia.ToString
            txtDomicilio.Text = polizaEncontrada.Domicilio
            txtSumaAsegurada.Text = polizaEncontrada.SumaAsegurada.ToString()
            txtWayPay.Text = polizaEncontrada.Waypay.ToString()
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        ' Guardar los cambios de la póliza
        Dim ramo As Integer = Convert.ToInt32(ddlRamos.SelectedValue)
        Dim producto As Integer = Convert.ToInt32(ddlProductos.SelectedValue)
        Dim poliza As Integer = Convert.ToInt32(ddlPolizas.SelectedValue)

        ' Aquí podrías agregar la lógica para modificar la póliza
        BaseDeDatos.Instance.EndosarPoliza(producto, poliza, ramo, txtClienteTitular.Text,
                                            DateTime.Parse(txtFechaVigencia.Text),
                                            txtDomicilio.Text,
                                            DateTime.Parse(txtFechaEfecto.Text),
                                            Convert.ToInt32(txtSumaAsegurada.Text),
                                            Convert.ToInt32(txtWayPay.Text))
    End Sub
End Class
