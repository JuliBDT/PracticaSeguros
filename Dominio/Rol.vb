Public Class Rol
    Private _Ramo As Integer
    Private _Producto As Integer
    Private _Rol As Integer
    Private _FecaDeEfecto As Date
    Private _Nulldate As Date

#Region "Propertys"
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

    Public Property Rol As Integer
        Get
            Return _Rol
        End Get
        Set(value As Integer)
            _Rol = value
        End Set
    End Property

    Public Property FecaDeEfecto As Date
        Get
            Return _FecaDeEfecto
        End Get
        Set(value As Date)
            _FecaDeEfecto = value
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
#End Region

End Class
