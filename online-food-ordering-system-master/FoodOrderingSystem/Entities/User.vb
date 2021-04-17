Public Class User

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _firstname As String
    Public Property FirstName() As String
        Get
            Return _firstname
        End Get
        Set(ByVal value As String)
            _firstname = value
        End Set
    End Property

    Private _lastname As String
    Public Property LastName() As String
        Get
            Return _lastname
        End Get
        Set(ByVal value As String)
            _lastname = value
        End Set
    End Property

    Private _phone As Integer
    Public Property Phone() As Integer
        Get
            Return _phone
        End Get
        Set(ByVal value As Integer)
            _phone = value
        End Set
    End Property

    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _roleid As Integer
    Public Property RoleId() As Integer
        Get
            Return _roleid
        End Get
        Set(ByVal value As Integer)
            _roleid = value
        End Set
    End Property

    Private _pass As String
    Public Property Password() As String
        Get
            Return _pass
        End Get
        Set(ByVal value As String)
            _pass = value
        End Set
    End Property

    Private _reg As DateTime
    Public Property RegAt() As DateTime
        Get
            Return _reg
        End Get
        Set(ByVal value As DateTime)
            _reg = value
        End Set
    End Property

    Private _locid As Integer
    Public Property LocId() As Integer
        Get
            Return _locid
        End Get
        Set(ByVal value As Integer)
            _locid = value
        End Set
    End Property

End Class
