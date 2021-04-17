Public Interface IRoleOperation
    Function AddRole(role As Role) As Integer
    Function DeleteRole(id As Integer) As Integer
    Function GetAllRole() As List(Of Role)
    Function GetRoleById(id As Integer) As Role
    Function UpdateRole(role As Role) As Integer
End Interface
