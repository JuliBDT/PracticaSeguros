Imports Dominio

Public Class BaseDeDatos
    Private _ListaDeRamos As List(Of Ramo)
    Private _ListaDePolizas As List(Of Poliza)
    Private _ListaDeRoles As List(Of Rol)
    Private _HistorialDePolizas As List(Of Poliza)
    Private _ListaDeProductos As List(Of Producto)

    Public Sub New()
        _ListaDeRamos = Me.GenerarListaDeRamos()
        _ListaDeRoles = Me.GenerarlistaDeRoles()
        _HistorialDePolizas = New List(Of Poliza)
        _ListaDeProductos = Me.GenerarListaDeProductos()
        _ListaDePolizas = Me.GenerarListaDePolizas()
    End Sub


    Private Function GenerarListaDePolizas() As List(Of Poliza)
        Throw New NotImplementedException()
    End Function

    Private Function GenerarListaDeProductos() As List(Of Producto)
        Throw New NotImplementedException()
    End Function

    Private Function GenerarListaDeRoles() As List(Of Rol)
        Throw New NotImplementedException()
    End Function

    Private Function GenerarListaDeRamos() As List(Of Ramo)
        Throw New NotImplementedException()
    End Function
End Class
