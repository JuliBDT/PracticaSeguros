Imports Dominio
Imports Oracle.ManagedDataAccess.Client

Public Class PolizaRepository

    Dim _conexion As Conexion

    Public Sub New()
        _conexion = Conexion.getInstance()
    End Sub

    Public Function GetPolizas() As List(Of Poliza)

        Dim list As New List(Of Poliza)

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT RAMO, PRODUCTO, POLIZA, CLIENTE_TITULAR, NULLDATE,FECHA_EFECTO,FECHA_VIGENTE,DOMICILIO ,SUMA_ASEGURADA,WAYPAY FROM POLIZA"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim entity As New Poliza(
                        reader.GetInt32(reader.GetOrdinal("RAMO")),
                        reader.GetInt32(reader.GetOrdinal("PRODUCTO")),
                        reader.GetInt32(reader.GetOrdinal("POLIZA")),
                        reader.GetString(reader.GetOrdinal("CLIENTE_TITULAR")),
                        reader.GetDateTime(reader.GetOrdinal("NULLDATE")),
                        reader.GetDateTime(reader.GetOrdinal("FECHA_EFECTO")),
                        reader.GetDateTime(reader.GetOrdinal("FECHA_VIGENTE")),
                        reader.GetString(reader.GetOrdinal("DOMICILIO")),
                        reader.GetInt32(reader.GetOrdinal("SUMA_ASEGURADA")),
                        reader.GetInt32(reader.GetOrdinal("WAYPAY"))
)
                    list.Add(entity)
                End While
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener datos", ex)
        Finally
            _conexion.CloseConnection()
        End Try

        GetPolizas = list

    End Function

End Class
