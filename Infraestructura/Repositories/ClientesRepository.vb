﻿Imports Dominio
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

    Public Function AddCliente(documento As String, nombre As String, nacimiento As Date, estadoCivil As Integer) As Boolean

        Dim result As Boolean = False

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.StoredProcedure
            command.CommandText = "clientes_insert"  ' Nombre del procedimiento almacenado

            ' Agregar los parámetros que requiere el procedimiento almacenado
            command.Parameters.Add(New OracleParameter("c_cliente", documento))
            command.Parameters.Add(New OracleParameter("c_nom_completo", nombre))
            command.Parameters.Add(New OracleParameter("c_fecha_nacimiento", nacimiento))
            command.Parameters.Add(New OracleParameter("c_nulldate", DBNull.Value))
            command.Parameters.Add(New OracleParameter("c_estado_civil", estadoCivil))

            result = command.ExecuteNonQuery() > 0

        Catch ex As Exception
            Throw New Exception("Error al insertar datos en CLIENTES", ex)
        Finally
            _conexion.CloseConnection()
        End Try

        Return result

    End Function

End Class