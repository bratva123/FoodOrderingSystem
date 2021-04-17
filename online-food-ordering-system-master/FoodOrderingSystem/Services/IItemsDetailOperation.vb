Public Interface IItemsDetailOperation
    Function AddItemsDetail(itemd As ItemsDetail) As Integer
    Function UpdateItemsDetail(itemd As ItemsDetail) As Integer
    Function GetItemsDetailById(id As Integer) As ItemsDetail


End Interface
