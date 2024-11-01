Public Class Documento
    Private _Doctype As Integer
    Private _Documento As String
    Private _Cliente As String
    Private _cuilCuitDni As Integer
    Private _FechaExpiracion As Date

    Public Sub New(doctype As Integer, documento As String, cliente As String, cuit As Integer, fechaExpiracion As Date)
        _Doctype = doctype
        _Documento = documento
        _Cliente = cliente
        _cuilCuitDni = cuit
        _FechaExpiracion = fechaExpiracion
    End Sub

    Public Property Doctype As Integer
        Get
            Return _Doctype
        End Get
        Set(value As Integer)
            _Doctype = value
        End Set
    End Property

    Public Property Documento As String
        Get
            Return _Documento
        End Get
        Set(value As String)
            _Documento = value
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

    Public Property FehcaExpiracion As Date
        Get
            Return _FechaExpiracion
        End Get
        Set(value As Date)
            _FechaExpiracion = value
        End Set
    End Property
End Class
