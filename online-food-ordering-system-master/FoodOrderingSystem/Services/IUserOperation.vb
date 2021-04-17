Public Interface IUserOperation

    Function AddUser(user As User) As Integer
    Function UpdateUser(user As User) As Integer
    Function GetUserById(id As Integer) As User
    Function GetUserByRoleId(roleid As Integer) As User
End Interface
