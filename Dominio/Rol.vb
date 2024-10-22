Public Class Rol
    Private _Ramo As Integer
    Private _Producto As Integer
    Private _Rol As Integer
    Private _Cliente As String
    Private _FecaDeEfecto As Date
    Private _Nulldate As Date

    Public Sub New(ramo As Integer, producto As Integer, rol As Integer, cliente As String, fecaDeEfecto As Date, nulldate As Date)
        _Ramo = ramo
        _Producto = producto
        _Rol = rol
        _Cliente = cliente
        _FecaDeEfecto = fecaDeEfecto
        _Nulldate = nulldate
    End Sub



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

    Public Property Cliente As String
        Get
            Return _Cliente
        End Get
        Set(value As String)
            _Cliente = value
        End Set
    End Property
#End Region

End Class
