Public Interface IPaymentOperation
    Function Add_Payment(pay As Payment) As Integer
    Function GetAll() As List(Of Payment)
    Function GetById(id As Integer) As Payment
End Interface
