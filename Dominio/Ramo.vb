Public Class Ramo
    Private _Ramo As Integer
    Private _FechaComputo As Date
    Private _Descripcion As String
    Private _EstadoRegistro As Integer
    Private _CodUsuario As Integer

#Region "Properties"
    Public Property Ramo As Integer
        Get
            Return _Ramo
        End Get
        Set(value As Integer)
            _Ramo = value
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
