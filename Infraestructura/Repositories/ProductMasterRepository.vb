Imports Dominio
Imports Oracle.ManagedDataAccess.Client

Public Class ProductMasterRepository


    Dim _conexion As Conexion

    Public Sub New()
        _conexion = Conexion.getInstance()
    End Sub

    Public Function getProductMaster() As List(Of Producto)

        Dim list As New List(Of Producto)

        Try
            _conexion.OpenConnection()

            Dim command = _conexion.Connection.CreateCommand()
            command.CommandType = CommandType.Text
            command.CommandText = "SELECT RAMO, PRODUCTO, FECHACOMPUTO, DESCRIPCION, ESTADOREGISTRO,CODUSUARIO FROM PRODUCTMASTER"

            Using reader As OracleDataReader = command.ExecuteReader()
                While reader.Read()
                    Dim entity As New Producto(
                        reader.GetInt32(reader.GetOrdinal("RAMO")),
                        reader.GetInt32(reader.GetOrdinal("PRODUCTO")),
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

        getProductMaster = list

    End Function


End Class
