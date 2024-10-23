Imports Dominio
Imports Infraestructura
Imports Microsoft.VisualBasic.Devices

Public Class AEndoso

    Private Shared _instance As AEndoso
    Private Shared ReadOnly _lock As New Object()
    Public Shared Function Instance() As AEndoso
        If _instance Is Nothing Then
            SyncLock _lock
                If _instance Is Nothing Then
                    _instance = New AEndoso()
                End If
            End SyncLock
        End If
        Return _instance
    End Function

    Public Function ObtenerPoliza(ramo As Integer, producto As Integer, poliza As integuer) As Poliza
        Dim bd As BaseDeDatos = BaseDeDatos.Instance
        Return bd.ObtenerPolizas(ramo, producto, poliza)
    End Function
End Class
