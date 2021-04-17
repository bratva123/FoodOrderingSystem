Public Interface IOrderOperation
    Function CreateOrder(ord As Order) As Integer
    Function GetByDate(orderDate As Date) As List(Of Order)
    Function GetByUserId(userId As Integer) As List(Of Order)

    Function GetByPaymentId(paymentId As Integer) As Order
    Function GetByUserIdAndDate(userId As Integer, orderDate As Date) As List(Of Order)
    Function GetOrderById(id As Integer) As Order
    Function UpdateOrder(ord As Order) As Integer
End Interface
