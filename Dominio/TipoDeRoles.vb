Public Class TipoDeRoles
    Private _Rol As Integer
    Private _FechaDeComputo As Date
    Private _Descripcion As String
    Private _Estado As Integer
    Private _CodigoDeUsuario As Integer

    Public Sub New(rol As Integer, fechaDeComputo As Date, descripcion As String, estado As Integer, codigoDeUsuario As Integer)
        _Rol = rol
        _FechaDeComputo = fechaDeComputo
        _Descripcion = descripcion
        _Estado = estado
        _CodigoDeUsuario = codigoDeUsuario
    End Sub

    Public Property Rol As Integer
        Get
            Return _Rol
        End Get
        Set(value As Integer)
            _Rol = value
        End Set
    End Property

    Public Property FechaDeComputo As Date
        Get
            Return _FechaDeComputo
        End Get
        Set(value As Date)
            _FechaDeComputo = value
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

    Public Property CodigoDeUsuario As Integer
        Get
            Return _CodigoDeUsuario
        End Get
        Set(value As Integer)
            _CodigoDeUsuario = value
        End Set
    End Property
End Class
