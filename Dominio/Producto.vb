Public Class Producto
    Private _Ramos As Integer
    Private _Producto As Integer
    Private _FechaComputo As Date
    Private _Descripcion As String
    Private _EstadoRegistro As Integer
    Private _CodUsuario As Integer
#Region "Properties"
    Public Property Ramos As Integer
        Get
            Return _Ramos
        End Get
        Set(value As Integer)
            _Ramos = value
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

    Public Property EstadoRegistro As Integer
        Get
            Return _EstadoRegistro
        End Get
        Set(value As Integer)
            _EstadoRegistro = value
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
#End Region

End Class
