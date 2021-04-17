Public Class ItemsDetail

    Private _id As Integer
    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _ordid As Integer
    Public Property OrderId() As Integer
        Get
            Return _ordid
        End Get
        Set(ByVal value As Integer)
            _ordid = value
        End Set
    End Property

    Private _itemid As Integer
    Public Property ItemId() As Integer
        Get
            Return _itemid
        End Get
        Set(ByVal value As Integer)
            _itemid = value
        End Set
    End Property


    Private _qty As Integer
    Public Property Qty() As Integer
        Get
            Return _qty
        End Get
        Set(ByVal value As Integer)
            _qty = value
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

End Class
