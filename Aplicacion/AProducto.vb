Public Class AProducto
    Private Shared _instance As AProducto
    Private Shared ReadOnly _lock As New Object()
    Public Shared Function Instance() As AProducto
        If _instance Is Nothing Then
            SyncLock _lock
                If _instance Is Nothing Then
                    _instance = New AProducto()
                End If
            End SyncLock
        End If
        Return _instance
    End Function

End Class
