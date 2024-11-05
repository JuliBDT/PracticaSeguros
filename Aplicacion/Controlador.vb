Imports Dominio
Imports Infraestructura

Public Class Controlador
    Private RoleMasterRepo As New RoleMasterRepository
    Private ClientesRepo As New ClientesRepository
    Private RolesRepo As New RolesRepository
    Private PolizasRepo As New PolizaRepository
    Private RamoMasterRepo As New BranchMasterRepository
    Private HistorialRepo As New HistorialPolizasRepository
    Private PolizaRepo As New PolizaRepository
    Private ProductoRepo As New ProductMasterRepository
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

    Public Function ListarClientes() As List(Of Cliente)
        Return ClientesRepo.GetClientes()
    End Function
    Public Function ObtenerRamos() As List(Of Ramo)
        Return RamoMasterRepo.GetBranchMaster() ' Esta función se implementa en la capa de Infraestructura
    End Function

    Public Function ObtenerProductosPorRamo(ramoId As Integer) As List(Of Producto)
        Dim lista = ProductoRepo.GetProductMaster()
        Return lista.Where(Function(p) p.Ramos = ramoId).ToList()
    End Function

    Public Sub CrearPoliza(ramoId As Integer, productoId As Integer, polizaId As Integer, cliente As String, nulldate As Date,
                           fechaEfecto As Date, fechaVigencia As Date, domicilio As String, sumaAsegurada As Integer, waypay As Integer)

        PolizasRepo.InsertarPoliza(ramoId, productoId, polizaId, cliente, nulldate, fechaEfecto, fechaVigencia, domicilio, sumaAsegurada, waypay)
    End Sub

    Public Function ObtenerPolizas() As List(Of Poliza)
        Return _db.ObtenerPolizas()
    End Function

    Public Function PolizasPorCliente(cliente As String) As List(Of Poliza)
        Return PolizaRepo.ObtenerPolizasPorCliente(cliente)
    End Function

    Public Function RolesActivos() As List(Of Rol)
        Return RolesRepo.GetRoleList()
    End Function

    Public Function ObtenerListaRolesOracle() As List(Of TipoDeRoles)
        Return RoleMasterRepo.GetRoleMasterList()
    End Function


    Public Function ObtenerListaWayPay() As List(Of WayPay)
        Return _db.ObtenerListaWayPay
    End Function


    Public Function ObtenerListaPolizasPorRamo(ramoId As Integer) As List(Of Poliza)
        Return PolizaRepo.ObtenerPolizasPorRamo(ramoId)
    End Function


    Public Function PolizaPorRamoYProducto(ramo As Integer, producto As Integer) As List(Of Poliza)
        Return _db.PolizaPorRamoYProducto(ramo, producto)
    End Function

    Public Function BuscarPoliza(ramo As Integer, producto As Integer, poliza As Integer) As Poliza
        Return PolizaRepo.ObtenerPolizaPorLlaves(ramo, producto, poliza)
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

    Public Function PolizasActivas() As List(Of Poliza)
        Return PolizaRepo.GetPolizas()
    End Function

    Public Sub EndosarPoliza(ramoId As Integer, productoId As Integer, polizaId As Integer, cliente As String, fechaEfecto As Date,
                             fechaVigencia As Date, domicilio As String, sumaAsegurada As Integer, waypay As Integer)
        PolizaRepo.EndosarPoliza(ramoId, productoId, polizaId, cliente, fechaEfecto, fechaVigencia, domicilio, sumaAsegurada, waypay)

    End Sub

    Public Sub BajarPoliza(ramoId As Integer, productoId As Integer, polizaId As Integer)
        _db.BajarPoliza(ramoId, productoId, polizaId)
    End Sub

    Public Sub darBajaRolesDePoliza(ramoId As Integer, productoId As Integer, polizaId As Integer)
        _db.darBajaRolesDePoliza(ramoId, productoId, polizaId)
    End Sub

    Public Sub CrearRol(idRamo As Integer, idProducto As Integer, idPoliza As Integer, idRol As Integer, cliente As String, fechaEfecto As Date)
        RolesRepo.AddRol(idRamo, idProducto, idPoliza, idRol, cliente, fechaEfecto)
    End Sub

    Public Function ObtenerClientes() As List(Of Cliente)
        Return _db.ObtenerClientes()
    End Function

    Public Function ObtenerRolesDePoliza(ramoId As Integer, productoId As Integer, polizaId As Integer) As List(Of Rol)
        Return RolesRepo.ObtenerRolesPorPoliza(ramoId, productoId, polizaId)
    End Function

    Public Sub EndosarRol(ramoId As Integer, productoId As Integer, polizaId As Integer, tipoDeRol As Integer, cliente As String, fechaEfecto As Date)
        _db.EndosarRol(ramoId, productoId, polizaId, tipoDeRol, cliente, fechaEfecto)
    End Sub

    Public Function ObtenerEstadoCivil() As List(Of EstadoCivil)
        Return _db.ListaEstadoCivil()
    End Function

    Public Function AddCliente(documento As String, nombre As String, nacimiento As Date, estadoCivil As Integer)
        Return ClientesRepo.AddCliente(documento, nombre, nacimiento, estadoCivil)
    End Function

    Public Function getHistorialPolizas() As List(Of Poliza)
        Return HistorialRepo.GetHistorialPolizas()
    End Function
End Class
