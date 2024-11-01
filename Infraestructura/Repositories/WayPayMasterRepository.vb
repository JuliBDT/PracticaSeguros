Imports Dominio
Imports Oracle.ManagedDataAccess.Client

Public Class WayPayMasterRepository

    Dim _conexion As Conexion

    Public Sub New()
        _conexion = Conexion.getInstance()
    End Sub

    Public Function GetWayPayMaster() As List(Of WayPay)

        Dim list As New List(Of WayPay)

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT WAYPAY, FECHACOMPUTO, DESCRIPCION, ESTADPREGISTRO, CODUSUARIO FROM WAYPAYMASTER"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim entity As New WayPay(
                        reader.GetInt32(reader.GetOrdinal("WAYPAY")),
                        reader.GetDateTime(reader.GetOrdinal("FECHACOMPUTO")),
                        reader.GetString(reader.GetOrdinal("DESCRIPCION")),
                        reader.GetInt32(reader.GetOrdinal("ESTADOREGISTRO")),
                        reader.GetInt32(reader.GetOrdinal("CODUSUARIO"))
                        )
                    list.Add(entity)
                End While
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener datos", ex)
        Finally
            _conexion.CloseConnection()
        End Try

        GetWayPayMaster = list

    End Function

End Class
