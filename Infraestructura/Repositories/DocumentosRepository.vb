Imports Dominio
Imports Oracle.ManagedDataAccess.Client

Public Class DocumentosRepository
    Dim _conexion As Conexion

    Public Sub New()
        _conexion = Conexion.getInstance()
    End Sub

    Public Function GetDocumentos() As List(Of Documento)

        Dim list As New List(Of Documento)

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT DOCTYPE, DOCUMENTO, CLIENTE, CUIL_CUIT_DNI,FECHAEXPIRACION FROM DOCUMENTOS"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim entity As New Documento(
                        reader.GetInt32(reader.GetOrdinal("DOCTYPE")),
                        reader.GetString(reader.GetOrdinal("DOCUMENTO")),
                        reader.GetString(reader.GetOrdinal("CLIENTE")),
                        reader.GetInt32(reader.GetOrdinal("CUIL_CUIT_DNI")),
                        reader.GetDateTime(reader.GetOrdinal("FECHAEXPIRACION"))
)
                    list.Add(entity)
                End While
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener datos", ex)
        Finally
            _conexion.CloseConnection()
        End Try

        GetDocumentos = list

    End Function
End Class
