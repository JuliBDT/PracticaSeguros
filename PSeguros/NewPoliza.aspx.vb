﻿Imports Aplicacion
Imports Dominio

Public Class NewPoliza
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ' Cargar las listas desde la capa de Aplicación
            Dim aPoliza As New APoliza()

            ' Lista de WayPay
            ddlWayPay.DataSource = aPoliza.ObtenerListaWayPay()
            ddlWayPay.DataTextField = "Nombre" ' o el campo relevante
            ddlWayPay.DataValueField = "Id"    ' o el campo relevante
            ddlWayPay.DataBind()

            ' Cargar Ramos y Productos de manera similar
            ddlRamos.DataSource = aPoliza.ObtenerListaRamos()
            ddlRamos.DataTextField = "Nombre"
            ddlRamos.DataValueField = "Id"
            ddlRamos.DataBind()

            ddlProductos.DataSource = aPoliza.ObtenerListaProductos()
            ddlProductos.DataTextField = "Nombre"
            ddlProductos.DataValueField = "Id"
            ddlProductos.DataBind()
        End If
    End Sub

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim servicioPoliza As New APoliza()
        servicioPoliza.CrearPoliza(ddlRamos.ID, ddlProductos.ID, ddlPolizas.ID, txtClienteTitular.Text, Nothing, Now,
                                   Now, txtDomicilio.Text, txtSumaAsegurada.Text, ddlWayPay.ID)
    End Sub


End Class