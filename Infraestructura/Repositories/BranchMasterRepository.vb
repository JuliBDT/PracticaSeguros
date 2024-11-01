Imports Dominio
Imports Oracle.ManagedDataAccess.Client

Public Class BranchMasterRepository

    Dim _conexion As Conexion

    Public Sub New()
        _conexion = Conexion.getInstance()
    End Sub

    Public Function GetBranchMaster() As List(Of Ramo)

        Dim list As New List(Of Ramo)

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT RAMO, FECHACOMPUTO, DESCRIPCION, ESTADOREGISTRO, CODUSUARIO FROM BRANCHMASTER"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim entity As New Ramo(
                        reader.GetInt32(reader.GetOrdinal("RAMO")),
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

        GetBranchMaster = list

    End Function

End Class
