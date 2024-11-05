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
            command.CommandText = "SELECT RAMO, PRODUCTO, POLIZA, CLIENTE_TITULAR, NULLDATE,FECHA_EFECTO,FECHA_VIGENCIA,DOMICILIO ,SUMA_ASEGURADA,WAYPAY FROM POLIZA"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim ramo As Integer = reader.GetInt32(reader.GetOrdinal("RAMO"))
                    Dim producto As Integer = reader.GetInt32(reader.GetOrdinal("PRODUCTO"))
                    Dim poliza As Integer = reader.GetInt32(reader.GetOrdinal("POLIZA"))

                    ' Columnas que podrían contener NULL
                    Dim clienteTitular As String = If(reader.IsDBNull(reader.GetOrdinal("CLIENTE_TITULAR")), Nothing, reader.GetString(reader.GetOrdinal("CLIENTE_TITULAR")))
                    Dim nullDate As DateTime? = If(reader.IsDBNull(reader.GetOrdinal("NULLDATE")), Nothing, reader.GetDateTime(reader.GetOrdinal("NULLDATE")))
                    Dim fechaEfecto As DateTime? = If(reader.IsDBNull(reader.GetOrdinal("FECHA_EFECTO")), Nothing, reader.GetDateTime(reader.GetOrdinal("FECHA_EFECTO")))
                    Dim fechaVigencia As DateTime? = If(reader.IsDBNull(reader.GetOrdinal("FECHA_VIGENCIA")), Nothing, reader.GetDateTime(reader.GetOrdinal("FECHA_VIGENCIA")))
                    Dim domicilio As String = If(reader.IsDBNull(reader.GetOrdinal("DOMICILIO")), Nothing, reader.GetString(reader.GetOrdinal("DOMICILIO")))
                    Dim sumaAsegurada As Integer? = If(reader.IsDBNull(reader.GetOrdinal("SUMA_ASEGURADA")), Nothing, reader.GetInt32(reader.GetOrdinal("SUMA_ASEGURADA")))
                    Dim waypay As Integer? = If(reader.IsDBNull(reader.GetOrdinal("WAYPAY")), Nothing, reader.GetInt32(reader.GetOrdinal("WAYPAY")))

                    ' Crear entidad Poliza con valores verificados
                    Dim entity As New Poliza(ramo, producto, poliza, clienteTitular, nullDate, fechaEfecto, fechaVigencia, domicilio, sumaAsegurada, waypay)
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

    Public Sub InsertarPoliza(ramo As Integer, producto As Integer, poliza As Integer, clienteTitular As String, nulldate As Date?, fechaEfecto As Date, fechaVigencia As Date, domicilio As String, sumaAsegurada As Integer, waypay As Integer)
        Try
            ' Abrir la conexión
            _conexion.OpenConnection()

            ' Crear el comando para ejecutar el procedimiento
            Using command As OracleCommand = _conexion.Connection.CreateCommand()
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "POLIZA_INSERT"

                ' Añadir los parámetros
                command.Parameters.Add("p_ramo", OracleDbType.Int32).Value = ramo
                command.Parameters.Add("p_producto", OracleDbType.Int32).Value = producto
                command.Parameters.Add("p_poliza", OracleDbType.Int32).Value = poliza
                command.Parameters.Add("p_cliente_titular", OracleDbType.Varchar2).Value = clienteTitular
                command.Parameters.Add("p_nulldate", OracleDbType.Date).Value = If(nulldate.HasValue, CType(nulldate, DateTime?), DBNull.Value)
                command.Parameters.Add("p_fecha_efecto", OracleDbType.Date).Value = fechaEfecto
                command.Parameters.Add("p_fecha_vigencia", OracleDbType.Date).Value = fechaVigencia
                command.Parameters.Add("p_domicilio", OracleDbType.Varchar2).Value = domicilio
                command.Parameters.Add("p_suma_asegurada", OracleDbType.Int32).Value = sumaAsegurada
                command.Parameters.Add("p_waypay", OracleDbType.Int32).Value = waypay

                ' Ejecutar el comando
                command.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            Throw New Exception("Error al insertar la póliza", ex)
        Finally
            ' Cerrar la conexión
            _conexion.CloseConnection()
        End Try
    End Sub


    Public Function ObtenerPolizasPorCliente(clienteTitular As String) As List(Of Poliza)
        Dim list As New List(Of Poliza)()

        Try
            ' Abrir la conexión
            _conexion.OpenConnection()

            ' Crear el comando para ejecutar el procedimiento
            Using command As OracleCommand = _conexion.Connection.CreateCommand()
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "GET_POLIZAS_BY_CLIENTE"

                ' Añadir el parámetro de entrada
                command.Parameters.Add("p_cliente_titular", OracleDbType.Varchar2).Value = clienteTitular

                ' Crear un parámetro de salida para el cursor
                Dim cursorParam As OracleParameter = command.Parameters.Add("p_cursor", OracleDbType.RefCursor)
                cursorParam.Direction = ParameterDirection.Output

                ' Ejecutar el comando
                command.ExecuteNonQuery()

                ' Obtener el cursor de la salida
                Using cursor As OracleDataReader = command.ExecuteReader()
                    While cursor.Read()
                        Dim entity As New Poliza(
                            cursor.GetInt32(cursor.GetOrdinal("RAMO")),
                            cursor.GetInt32(cursor.GetOrdinal("PRODUCTO")),
                            cursor.GetInt32(cursor.GetOrdinal("POLIZA")),
                            cursor.GetString(cursor.GetOrdinal("CLIENTE_TITULAR")),
                            If(cursor.IsDBNull(cursor.GetOrdinal("NULLDATE")), Nothing, cursor.GetDateTime(cursor.GetOrdinal("NULLDATE"))),
                            cursor.GetDateTime(cursor.GetOrdinal("FECHA_EFECTO")),
                            cursor.GetDateTime(cursor.GetOrdinal("FECHA_VIGENCIA")),
                            cursor.GetString(cursor.GetOrdinal("DOMICILIO")),
                            cursor.GetInt32(cursor.GetOrdinal("SUMA_ASEGURADA")),
                            cursor.GetInt32(cursor.GetOrdinal("WAYPAY"))
                        )
                        list.Add(entity)
                    End While
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener pólizas: " & ex.Message, ex)
        Finally
            ' Cerrar la conexión
            _conexion.CloseConnection()
        End Try

        Return list
    End Function

    Public Function ObtenerPolizasPorRamo(ramo As Integer) As List(Of Poliza)
        Dim polizas As New List(Of Poliza)

        Try
            ' Abre la conexión
            _conexion.OpenConnection()

            ' Configura el comando para el procedimiento almacenado
            Dim command As OracleCommand = _conexion.Connection.CreateCommand()
            command.CommandText = "GET_POLIZAS_BY_RAMO"
            command.CommandType = CommandType.StoredProcedure

            ' Parámetro de entrada
            command.Parameters.Add("p_ramo", OracleDbType.Int32).Value = ramo

            ' Parámetro de salida
            Dim cursorParam As OracleParameter = New OracleParameter("p_resultado", OracleDbType.RefCursor)
            cursorParam.Direction = ParameterDirection.Output
            command.Parameters.Add(cursorParam)

            ' Ejecuta el procedimiento y obtiene el cursor
            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    ' Lee y agrega cada póliza a la lista
                    Dim poliza As New Poliza(
                        reader.GetInt32(reader.GetOrdinal("RAMO")),
                        reader.GetInt32(reader.GetOrdinal("PRODUCTO")),
                        reader.GetInt32(reader.GetOrdinal("POLIZA")),
                        reader.GetString(reader.GetOrdinal("CLIENTE_TITULAR")),
                        If(reader.IsDBNull(reader.GetOrdinal("NULLDATE")), Nothing, reader.GetDateTime(reader.GetOrdinal("NULLDATE"))),
                        If(reader.IsDBNull(reader.GetOrdinal("FECHA_EFECTO")), Nothing, reader.GetDateTime(reader.GetOrdinal("FECHA_EFECTO"))),
                        If(reader.IsDBNull(reader.GetOrdinal("FECHA_VIGENCIA")), Nothing, reader.GetDateTime(reader.GetOrdinal("FECHA_VIGENCIA"))),
                        If(reader.IsDBNull(reader.GetOrdinal("DOMICILIO")), String.Empty, reader.GetString(reader.GetOrdinal("DOMICILIO"))),
                        If(reader.IsDBNull(reader.GetOrdinal("SUMA_ASEGURADA")), 0, reader.GetInt32(reader.GetOrdinal("SUMA_ASEGURADA"))),
                        If(reader.IsDBNull(reader.GetOrdinal("WAYPAY")), 0, reader.GetInt32(reader.GetOrdinal("WAYPAY")))
                    )
                    polizas.Add(poliza)
                End While
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener pólizas por ramo", ex)
        Finally
            ' Cierra la conexión
            _conexion.CloseConnection()
        End Try

        Return polizas
    End Function

    Public Function ObtenerPolizaPorLlaves(ramo As Integer, producto As Integer, poliza As Integer) As Poliza
        Dim polizaBuscada As Poliza = Nothing

        Try
            ' Abre la conexión a la base de datos
            _conexion.OpenConnection()

            ' Crear el comando para ejecutar el SP
            Using command As New OracleCommand("GET_POLIZA_BY_KEYS", _conexion.Connection)
                command.CommandType = CommandType.StoredProcedure

                ' Parámetros de entrada
                command.Parameters.Add("p_ramo", OracleDbType.Int32).Value = ramo
                command.Parameters.Add("p_producto", OracleDbType.Int32).Value = producto
                command.Parameters.Add("p_poliza", OracleDbType.Int32).Value = poliza

                ' Parámetro de salida (cursor)
                command.Parameters.Add("p_resultado", OracleDbType.RefCursor).Direction = ParameterDirection.Output

                ' Ejecutar el comando y leer el resultado
                Using reader As OracleDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Crear el objeto Poliza y llenar sus datos
                        Dim polizaEncontrada As New Poliza(
                        reader.GetInt32(reader.GetOrdinal("RAMO")),
                        reader.GetInt32(reader.GetOrdinal("PRODUCTO")),
                        reader.GetInt32(reader.GetOrdinal("POLIZA")),
                        reader.GetString(reader.GetOrdinal("CLIENTE_TITULAR")),
                        If(reader.IsDBNull(reader.GetOrdinal("NULLDATE")), Nothing, reader.GetDateTime(reader.GetOrdinal("NULLDATE"))),
                        reader.GetDateTime(reader.GetOrdinal("FECHA_EFECTO")),
                        reader.GetDateTime(reader.GetOrdinal("FECHA_VIGENCIA")),
                        reader.GetString(reader.GetOrdinal("DOMICILIO")),
                        reader.GetInt32(reader.GetOrdinal("SUMA_ASEGURADA")),
                        reader.GetInt32(reader.GetOrdinal("WAYPAY"))
                    )
                        polizaBuscada = polizaEncontrada
                    End While
                End Using
            End Using

        Catch ex As Exception
            Throw New Exception("Error al obtener póliza", ex)
        Finally
            ' Cerrar la conexión
            _conexion.CloseConnection()
        End Try

        Return polizaBuscada
    End Function

    Public Sub EndosarPoliza(ramoId As Integer, productoId As Integer, polizaId As Integer, cliente As String,
                          fechaEfecto As Date, fechaVigencia As Date, domicilio As String,
                          sumaAsegurada As Integer, waypay As Integer)
        Try
            _conexion.OpenConnection()

            Using command As OracleCommand = _conexion.Connection.CreateCommand()
                command.CommandType = CommandType.StoredProcedure
                command.CommandText = "ENDOSAR_POLIZA"

                ' Parámetros de entrada para el procedimiento almacenado
                command.Parameters.Add("p_ramo", OracleDbType.Int32).Value = ramoId
                command.Parameters.Add("p_producto", OracleDbType.Int32).Value = productoId
                command.Parameters.Add("p_poliza", OracleDbType.Int32).Value = polizaId
                command.Parameters.Add("p_cliente_titular", OracleDbType.Varchar2).Value = cliente
                command.Parameters.Add("p_fecha_efecto", OracleDbType.Date).Value = fechaEfecto
                command.Parameters.Add("p_fecha_vigencia", OracleDbType.Date).Value = fechaVigencia
                command.Parameters.Add("p_domicilio", OracleDbType.Varchar2).Value = domicilio
                command.Parameters.Add("p_suma_asegurada", OracleDbType.Int32).Value = sumaAsegurada
                command.Parameters.Add("p_waypay", OracleDbType.Int32).Value = waypay

                ' Ejecutar el procedimiento almacenado
                command.ExecuteNonQuery()
            End Using


        Catch ex As Exception
            Throw New Exception("Error al endosar la póliza", ex)
        Finally
            _conexion.CloseConnection()
        End Try
    End Sub



End Class
