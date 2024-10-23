Imports Dominio
Imports Infraestructura
Imports Microsoft.VisualBasic.Devices

Public Class AEndoso

    Private _db As BaseDeDatos = BaseDeDatos.Instance
    Private Shared _instance As AEndoso
    Private Shared ReadOnly _lock As New Object()
    Public Shared Function Instance() As AEndoso
        If _instance Is Nothing Then
            SyncLock _lock
                If _instance Is Nothing Then
                    _instance = New AEndoso()
                End If
            End SyncLock
        End If
        Return _instance
    End Function

    Public Function ObtenerPoliza(ramo As Integer, producto As Integer, poliza As Integer) As Poliza
        Dim bd As BaseDeDatos = BaseDeDatos.Instance
        Return bd.ObtenerPolizas(ramo, producto, poliza)
    End Function
    Public Function ObtenerRamos() As List(Of Ramo)
        Return _db.ObtenerRamos  ' Esta función se implementa en la capa de Infraestructura
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

    Public Function ObtenerListaWayPay() As List(Of WayPay)
        Return _db.ObtenerListaWayPay
    End Function

    Public Function ObtenerListaProductos() As List(Of Producto)
        Throw New NotImplementedException()
    End Function

    Public Function ObtenerListaPolizasPorRamo(idRamo As Integer) As List(Of Poliza)
        Return _db.PolizaPorRamo(idRamo)
    End Function

    Public Shared Function ObtenerListaProductosPorRamo(idRamo As Integer) As List(Of Producto)
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

    Public Sub EndosarPoliza(nProducto As Integer, nPoliza As Integer, nRamo As Integer, cliente As String,
                             fechaVigencia As Date, domicilio As String,
                             fechaEfecto As Date, sumaAsegurada As Integer, waypay As Integer)
        _db.EndosarPoliza(nProducto, nPoliza, nRamo, cliente, fechaVigencia, domicilio, fechaEfecto, sumaAsegurada, waypay)
    End Sub
End Class

