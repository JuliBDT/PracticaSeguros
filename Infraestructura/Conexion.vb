Imports System.Net.Configuration
Imports Oracle.ManagedDataAccess.Client
Public Class Conexion
    Private Shared _instance As Conexion
    Private connectionString As String = "User Id=sys;Password=Bdt24++;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=XEPDB1)));DBA Privilege=SYSDBA;"
    Private _connection As OracleConnection
    Private Sub New()
        _connection = New OracleConnection(connectionString)
    End Sub


    Public Shared Function getInstance()
        If _instance Is Nothing Then
            _instance = New Conexion
        End If
        Return _instance
    End Function

    Public ReadOnly Property Connection As OracleConnection
        Get
            Return _connection
        End Get
    End Property

    Public Sub OpenConnection()
        If _connection.State = ConnectionState.Closed Then
            _connection.Open()
        End If
    End Sub

    Public Sub CloseConnection()
        If _connection.State = ConnectionState.Open Then
            _connection.Close()
        End If
    End Sub

End Class
