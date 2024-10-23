﻿Imports System.Net
Imports Dominio

Public Class BaseDeDatos
    Private _ListaDeRamos As List(Of Ramo)
    Private _ListaDePolizas As List(Of Poliza)
    Private _ListaDeTipoDeRoles As List(Of TipoDeRoles)
    Private _HistorialDePolizas As List(Of Poliza)
    Private _ListaDeProductos As List(Of Producto)
    Private _ListaDeClientes As List(Of Cliente)
    Private _ListaDeWayPays As List(Of WayPay)
    Private _ListaDeRoles As List(Of Rol)

    Public Property ListaDeRoles As List(Of Rol)
        Get
            Return _ListaDeRoles
        End Get
        Set(value As List(Of Rol))
            _ListaDeRoles = value
        End Set
    End Property

    Public Sub New()
        GenerarListaDeRamos()
        GenerarListaDeRoles()
        GenerarListaDeWayPays()
        _HistorialDePolizas = New List(Of Poliza)
        GenerarListaDeProductos()
        _ListaDePolizas = New List(Of Poliza)
        _ListaDeClientes = New List(Of Cliente)
    End Sub

    Private Sub GenerarListaDeWayPays()
        _ListaDeWayPays.Add(New WayPay(1, #2014-04-17#, "Mastercard", 1, 30172))
        _ListaDeWayPays.Add(New WayPay(2, #2017-05-26#, "Visa", 1, 891))
        _ListaDeWayPays.Add(New WayPay(3, #2017-04-20#, "American Express", 1, 34))
        _ListaDeWayPays.Add(New WayPay(4, #2018-05-21#, "Diners", 1, 995))
        _ListaDeWayPays.Add(New WayPay(5, #2020-12-15#, "Naranja", 1, 8999))
        _ListaDeWayPays.Add(New WayPay(6, #2020-12-15#, "Cabal", 1, 1))
        _ListaDeWayPays.Add(New WayPay(7, #2017-05-26#, "Cuenta Corriente", 1, 386))
        _ListaDeWayPays.Add(New WayPay(8, #2017-05-26#, "Cuenta Ahorro", 1, 386))
    End Sub

    Private Sub GenerarListaDeProductos()
        _ListaDeProductos.Add(New Producto(1, 1501, #2017-05-16#, "Incendio", 1, 386))
        _ListaDeProductos.Add(New Producto(2, 2041, #2024-08-28#, "Hogar Clientes BGBA", 1, 459))
        _ListaDeProductos.Add(New Producto(2, 2043, #2017-11-13#, "Hogar Empleados", 1, 386))
        _ListaDeProductos.Add(New Producto(2, 2044, #2019-10-25#, "Hogar Canales Alternativos", 1, 12604))
        _ListaDeProductos.Add(New Producto(2, 2045, #2017-11-13#, "Hogar Clientes T. Regionales", 1, 386))
        _ListaDeProductos.Add(New Producto(2, 2046, #2017-11-13#, "Hogar Mercado Abierto", 1, 386))
        _ListaDeProductos.Add(New Producto(2, 2047, #2018-08-09#, "Hogar PRA", 1, 370))
        _ListaDeProductos.Add(New Producto(2, 2048, #2021-03-29#, "Hogar PRA Traspaso", 1, 370))
        _ListaDeProductos.Add(New Producto(2, 2050, #2024-02-27#, "Hogar Segmentado", 1, 583))
        _ListaDeProductos.Add(New Producto(5, 5000, #2021-08-12#, "Integral de Comercio PRA", 1, 386))
        _ListaDeProductos.Add(New Producto(5, 5010, #2019-11-25#, "Integral PYME", 1, 386))
        _ListaDeProductos.Add(New Producto(5, 5250, #2022-08-17#, "Silo Bolsa", 1, 469))
        _ListaDeProductos.Add(New Producto(7, 3000, #2023-07-20#, "Reembolso de Contracargos", 1, 578))
        _ListaDeProductos.Add(New Producto(7, 3078, #2024-01-24#, "Desempleo Multicanal", 1, 370))
        _ListaDeProductos.Add(New Producto(7, 3085, #2018-07-17#, "Seguro de Bicicleta", 1, 386))
        _ListaDeProductos.Add(New Producto(7, 3087, #2018-03-06#, "Seguro de Bicicleta BGBA Emp.", 1, 386))
        _ListaDeProductos.Add(New Producto(7, 3091, #2022-10-24#, "ATM Plus", 1, 578))
        _ListaDeProductos.Add(New Producto(7, 3092, #2018-09-03#, "Seguro de Compra Protegida", 1, 370))
        _ListaDeProductos.Add(New Producto(7, 3113, #2023-04-12#, "Microemprendedor", 1, 583))
        _ListaDeProductos.Add(New Producto(7, 3500, #2019-09-17#, "Rotura de Pantalla Naranja X", 1, 370))
        _ListaDeProductos.Add(New Producto(7, 3600, #2019-08-12#, "Seguro de Bicicleta", 1, 12604))
        _ListaDeProductos.Add(New Producto(7, 3800, #2020-01-01#, "Protección Integral Galicia", 1, 386))
        _ListaDeProductos.Add(New Producto(7, 3801, #2022-05-10#, "PIG Stock", 1, 578))
        _ListaDeProductos.Add(New Producto(7, 3900, #2022-02-09#, "Robo ATM Tarjeta Naranja Ind.", 1, 386))
        _ListaDeProductos.Add(New Producto(9, 1655, #2017-05-16#, "Robo en Cajero", 1, 386))
        _ListaDeProductos.Add(New Producto(9, 1668, #2018-04-16#, "Robo Celulares", 1, 995))
        _ListaDeProductos.Add(New Producto(9, 1669, #2018-02-21#, "Robo en Vía Pública BGBA", 1, 386))
        _ListaDeProductos.Add(New Producto(9, 1670, #2017-08-24#, "Protección Tecno Portátil", 1, 386))
        _ListaDeProductos.Add(New Producto(9, 1672, #2018-03-05#, "Robo Celulares BGBA Empleados", 1, 386))
        _ListaDeProductos.Add(New Producto(9, 1679, #2018-11-20#, "Tecno Portátil Empleados", 1, 386))
        _ListaDeProductos.Add(New Producto(9, 1680, #2018-11-01#, "Robo en Vía Pública Empleados", 1, 469))
        _ListaDeProductos.Add(New Producto(9, 1684, #2014-01-01#, "Protección Tecno Portátil", 1, 1))
        _ListaDeProductos.Add(New Producto(9, 1686, #2017-09-12#, "Protección Tecno Portátil", 1, 386))
        _ListaDeProductos.Add(New Producto(9, 1694, #2020-07-08#, "Protección Integral Galicia", 1, 469))
        _ListaDeProductos.Add(New Producto(9, 1696, #2020-02-06#, "Robo en Vía Pública", 1, 370))
        _ListaDeProductos.Add(New Producto(9, 1800, #2019-09-17#, "Robo Celulares Naranja X", 1, 370))
        _ListaDeProductos.Add(New Producto(9, 1900, #2023-11-08#, "Celular Robo", 1, 578))
        _ListaDeProductos.Add(New Producto(10, 200, #2007-01-01#, "Saldo Deudor", 1, 1))
        _ListaDeProductos.Add(New Producto(10, 203, #2020-05-27#, "Saldo Deudor BGBA", 1, 386))
        _ListaDeProductos.Add(New Producto(10, 301, #2018-08-27#, "Consumo Garantizado Migracion", 1, 370))
        _ListaDeProductos.Add(New Producto(10, 306, #2020-08-13#, "Producto Vida Colectivo", 1, 370))
        _ListaDeProductos.Add(New Producto(10, 309, #2020-05-15#, "Seguro de Vida Colectivo", 1, 370))
        _ListaDeProductos.Add(New Producto(12, 232, #2020-09-02#, "Accidentes Personales", 1, 370))
        _ListaDeProductos.Add(New Producto(12, 233, #2020-06-22#, "AP Financiero", 1, 469))
        _ListaDeProductos.Add(New Producto(12, 239, #2017-09-22#, "Accidentes Personales", 1, 386))
        _ListaDeProductos.Add(New Producto(12, 240, #2020-01-01#, "AP Modular BGBA Individual", 1, 370))
        _ListaDeProductos.Add(New Producto(12, 245, #2022-12-14#, "AP Capital Uniforme", 1, 370))
    End Sub

    Private Sub GenerarListaDeRoles()
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(1, #2007-01-29#, "Contratante", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(2, #2007-01-29#, "Asegurado", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(3, #2007-01-29#, "Tercero", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(5, #2007-01-29#, "Contacto", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(6, #2007-01-29#, "Contragarante", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(7, #2011-06-19#, "Co-Asegurado", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(16, #2007-01-29#, "Beneficiario", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(25, #2007-01-29#, "Pagador", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(31, #2007-01-29#, "Denunciante", 1, 1))
        _ListaDeTipoDeRoles.Add(New TipoDeRoles(90, #2008-11-07#, "Representante legal", 1, 1))
    End Sub

    Private Sub GenerarListaDeRamos()
        _ListaDeRamos.Add(New Ramo(1, #2014-04-17#, "Incendio", 1, 30172))
        _ListaDeRamos.Add(New Ramo(2, #2017-05-26#, "Combinado Familiar", 1, 891))
        _ListaDeRamos.Add(New Ramo(5, #2017-04-20#, "Integral de Comercio", 1, 34))
        _ListaDeRamos.Add(New Ramo(7, #2018-05-21#, "Riesgos Varios", 1, 995))
        _ListaDeRamos.Add(New Ramo(9, #2020-12-15#, "Robo y Riesgos Similares", 1, 8999))
        _ListaDeRamos.Add(New Ramo(10, #2020-12-15#, "Vida Colectivo", 1, 1))
        _ListaDeRamos.Add(New Ramo(12, #2017-05-26#, "Accidentes Personales", 1, 386))
    End Sub

    Public Function BuscarPoliza(poliza As Integer, ramo As Integer, producto As Integer) As Poliza
        Return _ListaDePolizas.FirstOrDefault(Function(p) p.Poliza = poliza AndAlso p.Producto = producto AndAlso p.Ramo = ramo)
    End Function

    Public Function PolizaPorRamo(ramo As Integer) As List(Of Producto)
        Return _ListaDeProductos.Where(Function(p) p.Ramos = ramo).ToList()
    End Function

    Public Function ObtenerPolizas() As List(Of Poliza)
        Return Me._ListaDePolizas
    End Function

    Public Sub AgregarRol(rol As Rol)
        Me.ListaDeRoles.Add(rol)
    End Sub
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


    Public Function ObtenerRamos() As List(Of Ramo)
        Throw New NotImplementedException()
    End Function
End Class