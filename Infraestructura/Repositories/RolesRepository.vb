Imports Dominio
Imports Oracle.ManagedDataAccess.Client

Public Class RolesRepository

    Dim _conexion As Conexion

    Public Sub New()
        _conexion = Conexion.getInstance()
    End Sub

    Public Function GetRoleList() As List(Of Rol)

        Dim list As New List(Of Rol)

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT RAMO, PRODUCTO, POLIZA, ROL, CLIENTE,FECHA_EFECTO,NULLDATE FROM ROLES"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim entity As New Rol(
                        reader.GetInt32(reader.GetOrdinal("RAMO")),
                        reader.GetInt32(reader.GetOrdinal("PRODUCTO")),
                        reader.GetInt32(reader.GetOrdinal("POLIZA")),
                        reader.GetInt32(reader.GetOrdinal("ROL")),
                        reader.GetString(reader.GetOrdinal("CLIENTE")),
                        reader.GetDateTime(reader.GetOrdinal("FECHA_EFECTO")),
                        reader.GetDateTime(reader.GetOrdinal("NULLDATE"))
                        )
                    list.Add(entity)
                End While
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener datos", ex)
        Finally
            _conexion.CloseConnection()
        End Try

        GetRoleList = list

    End Function

    Public Function AddRol(idRamo As Integer, idProducto As Integer, idPoliza As Integer, idRol As Integer, cliente As String, fechaEfecto As Date) As Boolean
        Dim result As Boolean = False
        Try
            _conexion.OpenConnection()
            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "roles_insert"
            command.Parameters.Add(New OracleParameter("p_ramo", idRamo))
            command.Parameters.Add(New OracleParameter("p_producto", idProducto))
            command.Parameters.Add(New OracleParameter("p_poliza", idPoliza))
            command.Parameters.Add(New OracleParameter("p_rol", idRol))
            command.Parameters.Add(New OracleParameter("p_cliente", cliente))
            command.Parameters.Add(New OracleParameter("p_fecha_efecto", fechaEfecto))
            command.Parameters.Add(New OracleParameter("p_nulldate", DBNull.Value))
            result = command.ExecuteNonQuery() > 0
        Catch ex As Exception
            Throw New Exception("Error al insertar datos en CLIENTES", ex)
        Finally
            _conexion.CloseConnection()
        End Try
        Return result
    End Function

End Class
