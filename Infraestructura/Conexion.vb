Imports Oracle.ManagedDataAccess.Client
Public Class Conexion
    Private _Base As String
    Private _Servidor As String
    Private _Usuario As String
    Private _Clave As String
    Private _Seguridad As Boolean = True



#Region "Propertys"
    Public Property Base As String
        Get
            Return _Base
        End Get
        Set(value As String)
            _Base = value
        End Set
    End Property

    Public Property Servidor As String
        Get
            Return _Servidor
        End Get
        Set(value As String)
            _Servidor = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Clave As String
        Get
            Return _Clave
        End Get
        Set(value As String)
            _Clave = value
        End Set
    End Property

    Public Property Seguridad As Boolean
        Get
            Return _Seguridad
        End Get
        Set(value As Boolean)
            _Seguridad = value
        End Set
    End Property
#End Region

    Dim conectionString As String = "User Id=sys as sysdba;Password=Bdt24++;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=VM-GALICIA)(PORT=1521))(CONNECT_DATA=(SID=PreoyectoSeguros)));"

    Public Sub New()

    End Sub


End Class
