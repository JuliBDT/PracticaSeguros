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

    Public Function ObtenerRolesPorPoliza(ramo As Integer, producto As Integer, poliza As Integer) As List(Of Rol)
        Dim roles As New List(Of Rol)

        Try
            ' Abrir la conexión
            _conexion.OpenConnection()

            Using command As OracleCommand = _conexion.Connection.CreateCommand()
                command.CommandText = "ObtenerRolesPorPoliza"
                command.CommandType = CommandType.StoredProcedure

                ' Parámetros de entrada
                command.Parameters.Add("p_ramo", OracleDbType.Int32).Value = ramo
                command.Parameters.Add("p_producto", OracleDbType.Int32).Value = producto
                command.Parameters.Add("p_poliza", OracleDbType.Int32).Value = poliza

                ' Parámetro de salida para el cursor
                Dim refCursorParam As OracleParameter = New OracleParameter("cur_out", OracleDbType.RefCursor)
                refCursorParam.Direction = ParameterDirection.Output
                command.Parameters.Add(refCursorParam)

                ' Ejecutar el comando y leer el cursor
                Using reader As OracleDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Crear una nueva instancia de Rol y agregarla a la lista
                        Dim rol As New Rol(
                        reader.GetInt32(reader.GetOrdinal("RAMO")),
                        reader.GetInt32(reader.GetOrdinal("PRODUCTO")),
                        reader.GetInt32(reader.GetOrdinal("POLIZA")),
                        reader.GetInt32(reader.GetOrdinal("ROL")),
                        reader.GetString(reader.GetOrdinal("CLIENTE")),
                        If(reader.IsDBNull(reader.GetOrdinal("FECHA_EFECTO")), Nothing, reader.GetDateTime(reader.GetOrdinal("FECHA_EFECTO"))),
                        If(reader.IsDBNull(reader.GetOrdinal("NULLDATE")), Nothing, reader.GetDateTime(reader.GetOrdinal("NULLDATE")))
                    )
                        roles.Add(rol)
                    End While
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener roles por póliza", ex)
        Finally
            ' Cerrar la conexión
            _conexion.CloseConnection()
        End Try

        Return roles
    End Function

End Class
