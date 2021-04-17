Public Interface ICategoryOperation
    Function AddRole(cate As Category) As Integer
    Function DeleteCategoryById(id As Integer) As Integer
    Function GetAllRole() As List(Of Category)
    Function GetcategoryById(id As Integer) As Category
    Function UpdateCategory(cate As Category) As Integer
End Interface
