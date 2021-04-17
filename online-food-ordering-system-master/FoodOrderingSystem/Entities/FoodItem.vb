Public Class FoodItem

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _categoryId As Integer
    Public Property CategoryId() As Integer
        Get
            Return _categoryId
        End Get
        Set(ByVal value As Integer)
            _categoryId = value
        End Set
    End Property
    Private _imgLoc As String
    Public Property ImgLoc() As String
        Get
            Return _imgLoc
        End Get
        Set(ByVal value As String)
            _imgLoc = value
        End Set
    End Property

    Private _createdBy As Integer
    Public Property CreatedBy() As Integer
        Get
            Return _createdBy
        End Get
        Set(ByVal value As Integer)
            _createdBy = value
        End Set
    End Property

    Private _createdAt As String
    Public Property CreatedAt() As Date
        Get
            Return _createdAt
        End Get
        Set(ByVal value As Date)
            _createdAt = value
        End Set
    End Property
End Class
