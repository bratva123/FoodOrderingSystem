Public Class FoodMenu
    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _itemId As Integer
    Public Property ItemId() As Integer
        Get
            Return _itemId
        End Get
        Set(ByVal value As Integer)
            _itemId = value
        End Set
    End Property

    Private _price As Integer
    Public Property Price() As Integer
        Get
            Return _price
        End Get
        Set(ByVal value As Integer)
            _price = value
        End Set
    End Property

    Private _quantity As Integer
    Public Property Quantity() As Integer
        Get
            Return _quantity
        End Get
        Set(ByVal value As Integer)
            _quantity = value
        End Set
    End Property
End Class
