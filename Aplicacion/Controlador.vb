Imports Dominio
Imports Infraestructura

Public Class Controlador
    Private _db As BaseDeDatos = BaseDeDatos.Instance
    Private Shared _instance As Controlador
    Private Shared ReadOnly _lock As New Object()
    Public Shared Function Instance() As Controlador
        If _instance Is Nothing Then
            SyncLock _lock
                If _instance Is Nothing Then
                    _instance = New Controlador()
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

    Public Sub CrearPoliza(ramoId As Integer, productoId As Integer, polizaId As Integer, cliente As String, nulldate As Date,
                           fechaEfecto As Date, fechaVigencia As Date, domicilio As String, sumaAsegurada As Integer, waypay As Integer)

        _db.AgregarPoliza(ramoId, productoId, polizaId, cliente, nulldate, fechaEfecto, fechaVigencia, domicilio, sumaAsegurada, waypay)
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

    Public Function ObtenerListaWayPay() As List(Of WayPay)
        Return _db.ObtenerListaWayPay
    End Function

    Public Function ObtenerListaProductos() As List(Of Producto)
        Throw New NotImplementedException()
    End Function

    Public Function ObtenerListaPolizasPorRamo(ramoId As Integer) As List(Of Poliza)
        Return _db.PolizaPorRamo(ramoId)
    End Function

    Public Shared Function ObtenerListaProductosPorRamo(ramoId As Integer) As List(Of Producto)
        Throw New NotImplementedException()
    End Function

    Public Function ObtenerUltimoidPoliza() As Integer
        ' Obtener la lista de pólizas
        Dim listaPolizas = _db.ObtenerPolizas()

        ' Verificar que la lista no esté vacía antes de acceder al último elemento
        If listaPolizas.Count > 0 Then
            ' Devolver el ID de la última póliza (accediendo a Count - 1)
            Return listaPolizas(listaPolizas.Count - 1).Poliza
        Else
            ' Si la lista está vacía, devolver un valor por defecto
            Return 0 ' O algún valor que represente que no hay pólizas
        End If
    End Function

    Public Function PolizasActivas()
        Return _db.PolizasActivas()
    End Function

    Public Sub EndosarPoliza(ramoId As Integer, productoId As Integer, polizaId As Integer, cliente As String, fechaEfecto As Date,
                             fechaVigencia As Date, domicilio As String, sumaAsegurada As Integer, waypay As Integer)
        _db.EndosarPoliza(ramoId, productoId, polizaId, cliente, fechaEfecto, fechaVigencia, domicilio, sumaAsegurada, waypay)

    End Sub

    Public Sub CrearRol(idRamo As Integer, idProducto As Integer, idPoliza As Integer, text As String, fechaEfecto As Date, value As Object)
        Throw New NotImplementedException()
    End Sub
End Class
