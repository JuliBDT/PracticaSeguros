Public Class WayPay
    Private _WayPay As Integer
    Private _FechaComputo As Date
    Private _Descripcion As String
    Private _Estado As Integer
    Private _CodUsuario As Integer

    Public Sub New(wayPay As Integer, fechaComputo As Date, descripcion As String, estado As Integer, codUsuario As Integer)
        Me.WayPay = wayPay
        Me.FechaComputo = fechaComputo
        Me.Descripcion = descripcion
        Me.Estado = estado
        Me.CodUsuario = codUsuario
    End Sub

    Public Property WayPay As Integer
        Get
            Return _WayPay
        End Get
        Set(value As Integer)
            _WayPay = value
        End Set
    End Property

    Public Property FechaComputo As Date
        Get
            Return _FechaComputo
        End Get
        Set(value As Date)
            _FechaComputo = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Estado As Integer
        Get
            Return _Estado
        End Get
        Set(value As Integer)
            _Estado = value
        End Set
    End Property

    Public Property CodUsuario As Integer
        Get
            Return _CodUsuario
        End Get
        Set(value As Integer)
            _CodUsuario = value
        End Set
    End Property


End Class
