Imports System.Net
Imports Dominio

Public Class BaseDeDatos
    Private _ListaDeRamos As List(Of Ramo)
    Private _ListaDePolizas As List(Of Poliza)
    Private _ListaDeRoles As List(Of Rol)
    Private _HistorialDePolizas As List(Of Poliza)
    Private _ListaDeProductos As List(Of Producto)

    Public Sub New()
        _ListaDeRamos = Me.GenerarListaDeRamos()
        _ListaDeRoles = Me.GenerarListaDeRoles()
        _HistorialDePolizas = New List(Of Poliza)
        _ListaDeProductos = Me.GenerarListaDeProductos()
        _ListaDePolizas = Me.GenerarListaDePolizas()
    End Sub


    Private Function GenerarListaDePolizas() As List(Of Poliza)
        Throw New NotImplementedException()
    End Function

    Private Function GenerarListaDeProductos() As List(Of Producto)
        Throw New NotImplementedException()
    End Function

    Private Function GenerarListaDeRoles() As List(Of Rol)
        Throw New NotImplementedException()
    End Function

    Private Function GenerarListaDeRamos() As List(Of Ramo)
        Throw New NotImplementedException()
    End Function

    Public Function BuscarPoliza(poliza As Integer, ramo As Integer, producto As Integer) As Poliza
        Return _ListaDePolizas.FirstOrDefault(Function(p) p.Poliza = poliza AndAlso p.Producto = producto AndAlso p.Ramo = ramo)
    End Function

    Public Function PolizaPorRamo(ramo As Integer) As List(Of Producto)
        Return _ListaDeProductos.Where(Function(p) p.Ramos = ramo).ToList()
    End Function


    Public Sub EndosarPoliza(nProducto As Integer, nPoliza As Integer, nRamo As Integer, cliente As String,
                             fechaVigencia As Date, domicilio As String,
                             fechaEfecto As Date, sumaAsegurada As Integer, waypay As Integer)
        Dim polizaExistente As Poliza = BuscarPoliza(nPoliza, nRamo, nProducto)
        If polizaExistente IsNot Nothing Then
            polizaExistente.Nulldate = Now
            Me._HistorialDePolizas.Add(polizaExistente)
            Me._ListaDePolizas.Remove(polizaExistente)
            Dim nuevaPoliza As Poliza = New Poliza(nRamo, nProducto, nPoliza, cliente, Nothing, fechaEfecto, fechaVigencia, domicilio, sumaAsegurada, waypay)
            Me._ListaDePolizas.Add(nuevaPoliza)
        End If
    End Sub

    Public Sub AgregarPoliza(nProducto As Integer, nPoliza As Integer, nRamo As Integer, cliente As String,
                             fechaVigencia As Date, domicilio As String,
                             fechaEfecto As Date, sumaAsegurada As Integer, waypay As Integer)
        Me._ListaDePolizas.Add(New Poliza(nRamo, nProducto, nPoliza, cliente, Nothing, fechaEfecto, fechaVigencia, domicilio, sumaAsegurada, waypay))
    End Sub

    Public Function GetHistoriaPoliza() As List(Of Poliza)
        Return Me._HistorialDePolizas
    End Function

    Public Function GetHistoriaPoliza(ramo As Integer, poliza As Integer) As List(Of Poliza)
        Return _HistorialDePolizas.Where(Function(p) p.Poliza = poliza AndAlso p.Ramo = ramo)
    End Function

    Public Function GetTitular(ramo As Integer, producto As String, poliza As Integer) As String
        Dim pBuscada As Poliza = _ListaDePolizas.FirstOrDefault(Function(p) p.Ramo = ramo AndAlso p.Producto = producto AndAlso p.Poliza = poliza)
        Return pBuscada.ClienteTitular
    End Function


End Class
