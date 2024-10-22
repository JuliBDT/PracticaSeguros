Imports Dominio
Imports Infraestructura

Public Class APoliza
    Private _db As BaseDeDatos

    Public Sub New()
        _db = New BaseDeDatos()
    End Sub

    Public Function ObtenerRamos() As List(Of Ramo)
        Return _db.ObtenerRamos() ' Esta función se implementa en la capa de Infraestructura
    End Function

    Public Function ObtenerProductosPorRamo(ramoId As Integer) As List(Of Producto)
        Return _db.PolizaPorRamo(ramoId)
    End Function

    Public Sub AgregarPoliza(ramoId As Integer, productoId As Integer, polizaId As Integer, cliente As String, fechaEfecto As Date, fechaVigencia As Date, domicilio As String, sumaAsegurada As Integer, waypay As Integer)
        _db.AgregarPoliza(productoId, polizaId, ramoId, cliente, fechaVigencia, domicilio, fechaEfecto, sumaAsegurada, waypay)
    End Sub

End Class
