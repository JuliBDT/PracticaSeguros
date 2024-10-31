Imports Dominio
Imports Oracle.ManagedDataAccess.Client

Public Class ClientesRepository

    Dim _conexion As Conexion

    Public Sub New()
        _conexion = Conexion.getInstance()
    End Sub

    Public Function GetClientes() As List(Of Cliente)

        Dim list As New List(Of Cliente)

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT CLIENTE, NOM_COMPLETO, FECHA_NACIMIENTO, NULLDATE, ESTADO_CIVIL FROM CLIENTES"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim entity As New Cliente(
                        reader.GetInt32(reader.GetOrdinal("CLIENTE")),
                         reader.GetString(reader.GetOrdinal("NOM_COMPLETO")),
                        reader.GetDateTime(reader.GetOrdinal("FECHANACIMIENTO")),
                        reader.GetDateTime(reader.GetOrdinal("NULLDATE")),
                        reader.GetInt32(reader.GetOrdinal("ESTADO_CIVIL"))
)
                    list.Add(entity)
                End While
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener datos", ex)
        Finally
            _conexion.CloseConnection()
        End Try

        GetClientes = list

    End Function

End Class
