Public Class ARamo
    Private Shared _instance As ARamo
    Private Shared ReadOnly _lock As New Object()
    Public Shared Function Instance() As ARamo
        If _instance Is Nothing Then
            SyncLock _lock
                If _instance Is Nothing Then
                    _instance = New ARamo()
                End If
            End SyncLock
        End If
        Return _instance
    End Function

End Class
