Public Class Order
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _userId As Integer
    Public Property UserId() As Integer
        Get
            Return _userId
        End Get
        Set(ByVal value As Integer)
            _userId = value
        End Set
    End Property

    Private _totalPrice As Integer
    Public Property TotalPrice() As Integer
        Get
            Return _totalPrice
        End Get
        Set(ByVal value As Integer)
            _totalPrice = value
        End Set
    End Property

    Private _itemsDetailId As Integer
    Public Property ItemsDetailId() As Integer
        Get
            Return _itemsDetailId
        End Get
        Set(ByVal value As Integer)
            _itemsDetailId = value
        End Set
    End Property

    Private _orderDate As Date
    Public Property OrderDate() As Date
        Get
            Return _orderDate
        End Get
        Set(ByVal value As Date)
            _orderDate = value
        End Set
    End Property

    Private _paymentId As Integer
    Public Property PaymentId() As Integer
        Get
            Return _paymentId
        End Get
        Set(ByVal value As Integer)
            _paymentId = value
        End Set
    End Property
End Class
