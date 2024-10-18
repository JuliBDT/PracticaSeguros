Public Class Cliente
    Private _cliente As String
    Private _nombre As String
    Private _fechaNacimiento As Date
    Private _nulldate As Date
    Private _fechaModificacion As Date
    Private _estadoCivil As Integer

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property FechaNacimiento As Date
        Get
            Return _fechaNacimiento
        End Get
        Set(value As Date)
            _fechaNacimiento = value
        End Set
    End Property

    Public Property Nulldate As Date
        Get
            Return _nulldate
        End Get
        Set(value As Date)
            _nulldate = value
        End Set
    End Property

    Public Property FechaModificacion As Date
        Get
            Return _fechaModificacion
        End Get
        Set(value As Date)
            _fechaModificacion = value
        End Set
    End Property

    Public Property EstadoCivil As Integer
        Get
            Return _estadoCivil
        End Get
        Set(value As Integer)
            _estadoCivil = value
        End Set
    End Property
End Class
