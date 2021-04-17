Public Interface IFoodMenuOperation
    Function AddFoodMenu(fm As FoodMenu) As Integer
    Function DeleteFoodMenuById(id As Integer) As Integer
    Function GetByCategoryId(categoryId As Integer) As List(Of FoodMenu)
    Function GetByItemId(itemId As Integer) As FoodMenu
    Function GetByItemName(name As String) As List(Of FoodMenu)
    Function UpdateFoodMenu(fm As FoodMenu) As Integer
End Interface
