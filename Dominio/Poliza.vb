﻿Public Class Poliza
    Private _Ramo As Integer
    Private _Producto As Integer
    Private _Poliza As Integer
    Private _Nulldate As Date
    Private _FechaDeEfecto As Date
    Private _FechaDeVigencia As Date
    Private _Domicilio As String
    Private _SumaAsegurada As Integer
    Private _Waypay As Integer

    Public Property Ramo As Integer
        Get
            Return _Ramo
        End Get
        Set(value As Integer)
            _Ramo = value
        End Set
    End Property

    Public Property Producto As Integer
        Get
            Return _Producto
        End Get
        Set(value As Integer)
            _Producto = value
        End Set
    End Property

    Public Property Poliza As Integer
        Get
            Return _Poliza
        End Get
        Set(value As Integer)
            _Poliza = value
        End Set
    End Property

    Public Property Nulldate As Date
        Get
            Return _Nulldate
        End Get
        Set(value As Date)
            _Nulldate = value
        End Set
    End Property

    Public Property FechaDeEfecto As Date
        Get
            Return _FechaDeEfecto
        End Get
        Set(value As Date)
            _FechaDeEfecto = value
        End Set
    End Property

    Public Property FechaDeVigencia As Date
        Get
            Return _FechaDeVigencia
        End Get
        Set(value As Date)
            _FechaDeVigencia = value
        End Set
    End Property

    Public Property Domicilio As String
        Get
            Return _Domicilio
        End Get
        Set(value As String)
            _Domicilio = value
        End Set
    End Property

    Public Property SumaAsegurada As Integer
        Get
            Return _SumaAsegurada
        End Get
        Set(value As Integer)
            _SumaAsegurada = value
        End Set
    End Property

    Public Property Waypay As Integer
        Get
            Return _Waypay
        End Get
        Set(value As Integer)
            _Waypay = value
        End Set
    End Property
End Class
