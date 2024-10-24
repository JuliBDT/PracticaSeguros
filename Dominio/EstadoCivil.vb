Public Class EstadoCivil
    Private _ID As Integer
    Private _Descripcion As String

    Public Sub New(id As Integer, descripcion As String)
        Me._ID = id
        Me._Descripcion = descripcion
    End Sub

    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property ID As Integer
        Get
            Return _ID
        End Get
        Set(value As Integer)
            _ID = value
        End Set
    End Property
End Class
