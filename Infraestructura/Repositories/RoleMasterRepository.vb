Imports Dominio
Imports Oracle.ManagedDataAccess.Client

Public Class RoleMasterRepository
    Dim _conexion As Conexion

    Public Sub New()
        _conexion = Conexion.getInstance()
    End Sub

    Public Function GetRoleMasterList() As List(Of TipoDeRoles)

        Dim list As New List(Of TipoDeRoles)

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT ROL, FECHACOMPUTO, DESCRIPCION, ESTADOREGISTRO, CODUSUARIO FROM ROLEMASTER"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim entity As New TipoDeRoles(
                        reader.GetInt32(reader.GetOrdinal("ROL")),
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

        GetRoleMasterList = list

    End Function

End Class
