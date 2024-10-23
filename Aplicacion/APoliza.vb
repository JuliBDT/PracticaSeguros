Imports Dominio
Imports Infraestructura

Public Class APoliza
    Private _db As BaseDeDatos = BaseDeDatos.Instance
    Private Shared _instance As APoliza
    Private Shared ReadOnly _lock As New Object()
    Public Shared Function Instance() As APoliza
        If _instance Is Nothing Then
            SyncLock _lock
                If _instance Is Nothing Then
                    _instance = New APoliza()
                End If
            End SyncLock
        End If
        Return _instance
    End Function

    Public Function ObtenerRamos() As List(Of Ramo)
        Return _db.ObtenerRamos() ' Esta función se implementa en la capa de Infraestructura
    End Function

    Public Function ObtenerProductosPorRamo(ramoId As Integer) As List(Of Producto)
        Return _db.ProductoPorRamo(ramoId)
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

    Public Function AgregarRol(rolID As TipoDeRoles, rol As Rol)
        Throw New NotImplementedException()
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
