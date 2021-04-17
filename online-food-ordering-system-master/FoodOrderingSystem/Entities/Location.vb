Public Class Location

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _add As String
    Public Property Address() As String
        Get
            Return _add
        End Get
        Set(ByVal value As String)
            _add = value
        End Set
    End Property

    Private _landmark As String
    Public Property Landmark() As String
        Get
            Return _landmark
        End Get
        Set(ByVal value As String)
            _landmark = value
        End Set
    End Property

    Private _pincode As Integer
    Public Property Pincode() As Integer
        Get
            Return _pincode
        End Get
        Set(ByVal value As Integer)
            _pincode = value
        End Set
    End Property

    Private _userid As Integer
    Public Property UserId() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property

End Class
