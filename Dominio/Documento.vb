Public Class Documento
    Private _doctype As Integer
    Private _documento As String
    Private _cliente As String
    Private _fehcaExpiracion As Date


    Public Property Doctype As Integer
        Get
            Return _doctype
        End Get
        Set(value As Integer)
            _doctype = value
        End Set
    End Property

    Public Property Documento As String
        Get
            Return _documento
        End Get
        Set(value As String)
            _documento = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property

    Public Property FehcaExpiracion As Date
        Get
            Return _fehcaExpiracion
        End Get
        Set(value As Date)
            _fehcaExpiracion = value
        End Set
    End Property
End Class
