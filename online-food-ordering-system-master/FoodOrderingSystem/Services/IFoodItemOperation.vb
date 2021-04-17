Public Interface IFoodItemOperation
    Function AddFoodItem(fi As FoodItem) As Integer
    Function DeleteFoodItemById(id As Integer) As Integer
    Function GetAllFoodItem() As List(Of FoodItem)
    Function GetByNameAndCategoryId(ch As String, catId As Integer) As List(Of FoodItem)
    Function GetItemById(id As Integer) As FoodItem
    Function GetItemsByName(ch As String) As List(Of FoodItem)
    Function UpdateFoodItems(fi As FoodItem) As Integer
End Interface
