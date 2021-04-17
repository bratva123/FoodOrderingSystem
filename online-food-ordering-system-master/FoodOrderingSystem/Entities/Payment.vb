Public Class Payment
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _mode As String
    Public Property Mode() As String
        Get
            Return _mode
        End Get
        Set(ByVal value As String)
            _mode = value
        End Set
    End Property

    Private _status As Integer
    Public Property Status() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property
End Class
