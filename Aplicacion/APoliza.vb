Imports Dominio
Imports Infraestructura

Public Class APoliza
    Private _db As BaseDeDatos

    Public Function ObtenerRamos() As List(Of Ramo)
        Return _db.ObtenerRamos() ' Esta función se implementa en la capa de Infraestructura
    End Function

    Public Function ObtenerProductosPorRamo(ramoId As Integer) As List(Of Producto)
        Return _db.PolizaPorRamo(ramoId)
    End Function

    Public Sub CrearPoliza(ramoId As Integer, productoId As Integer, polizaId As Integer, cliente As String,
                           fechaEfecto As Date, fechaVigencia As Date, now As Date, domicilio As String, sumaAsegurada As Integer, waypay As Integer)

        _db.AgregarPoliza(productoId, polizaId, ramoId, cliente, fechaVigencia, domicilio, fechaEfecto, sumaAsegurada, waypay)
    End Sub

    Public Function ObtenerPolizas() As List(Of Poliza)

        Return _db.ObtenerPolizas()
    End Function

    Public Function ObtenerListaRoles() As Object
        Return _db.ObtenerRoles
    End Function

    Public Function AgregarRol(rolID As Integer, descripcion As String, rol Rol)

    End Function

    Public Function ObtenerListaRamos() As Object
        Throw New NotImplementedException()
    End Function

    Public Function ObtenerListaWayPay() As Object
        Throw New NotImplementedException()
    End Function

    Public Function ObtenerListaProductos() As Object
        Throw New NotImplementedException()
    End Function
End Class
