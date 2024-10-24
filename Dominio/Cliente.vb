Public Class Cliente
    Private _Cliente As String
    Private _Nombre As String
    Private _FechaNacimiento As Date
    Private _Nulldate As Date
    Private _FechaModificacion As Date
    Private _EstadoCivil As Integer

    Public Sub New(cliente As String, nombre As String, fechaNacimiento As Date, fechaModificacion As Date, estadoCivil As Integer)
        _Cliente = cliente
        _Nombre = nombre
        _FechaNacimiento = fechaNacimiento
        _Nulldate = Nothing
        _FechaModificacion = fechaModificacion
        _EstadoCivil = estadoCivil
    End Sub

    Public Property Cliente As String
        Get
            Return _Cliente
        End Get
        Set(value As String)
            _Cliente = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _FechaNacimiento
        End Get
        Set(value As Date)
            _FechaNacimiento = value
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

    Public Property FechaModificacion As Date
        Get
            Return _FechaModificacion
        End Get
        Set(value As Date)
            _FechaModificacion = value
        End Set
    End Property

    Public Property EstadoCivil As Integer
        Get
            Return _EstadoCivil
        End Get
        Set(value As Integer)
            _EstadoCivil = value
        End Set
    End Property
End Class
