Imports System.Data.SqlClient

Public Class UserOperation

    Implements IUserOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter

    Dim connString As String = "Data source=DEL1-LHP-N70246;initial catalog=FoodOrderDb;integrated security=true;"

    Public Function AddUser(user As User) As Integer Implements IUserOperation.AddUser
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Add_user", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@fname", user.FirstName)
            cmd.Parameters.AddWithValue("@lname", user.LastName)
            cmd.Parameters.AddWithValue("@phone", user.Phone)
            cmd.Parameters.AddWithValue("@email", user.Email)
            cmd.Parameters.AddWithValue("@role_id", user.RoleId)
            cmd.Parameters.AddWithValue("@pass", user.Password)
            cmd.Parameters.AddWithValue("@reg_id", user.RegAt)
            cmd.Parameters.AddWithValue("@loc_id", user.LocId)

            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("Some thing Went Wrong")
            Else
                Return result
                Exit Function
            End If
        Catch ex As FoodOrderException
            Throw ex
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function


    Public Function UpdateUser(user As User) As Integer Implements IUserOperation.UpdateUser
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Update_user", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", user.Id)
            cmd.Parameters.AddWithValue("@fname", user.FirstName)
            cmd.Parameters.AddWithValue("@lname", user.LastName)
            cmd.Parameters.AddWithValue("@phone", user.Phone)
            cmd.Parameters.AddWithValue("@email", user.Email)
            cmd.Parameters.AddWithValue("@role_id", user.RoleId)
            cmd.Parameters.AddWithValue("@pass", user.Password)
            cmd.Parameters.AddWithValue("@reg_id", user.RegAt)
            cmd.Parameters.AddWithValue("@loc_id", user.LocId)

            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("Something went Wrong")
            Else
                Return result
                Exit Function
            End If
        Catch ex As FoodOrderException
            Throw ex
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

    Public Function GetUserById(id As Integer) As User Implements IUserOperation.GetUserById
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("Get_user_ByID", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim user As New User
            user.Id = result.Tables(0).Rows(0)(0)
            user.FirstName = result.Tables(0).Rows(0)(1)
            user.LastName = result.Tables(0).Rows(0)(2)
            user.Phone = result.Tables(0).Rows(0)(3)
            user.Email = result.Tables(0).Rows(0)(4)
            user.RoleId = result.Tables(0).Rows(0)(5)
            user.Password = result.Tables(0).Rows(0)(6)
            user.RegAt = result.Tables(0).Rows(0)(7)
            user.LocId = result.Tables(0).Rows(0)(8)
            If user Is Nothing Then
                Throw New FoodOrderException("No Such Record found")
            Else
                Return user
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

    Public Function GetUserByRoleId(roleid As Integer) As User Implements IUserOperation.GetUserByRoleId
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("Get_user_ByRole", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@role_id", roleid)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim user As New User
            user.Id = result.Tables(0).Rows(0)(0)
            user.FirstName = result.Tables(0).Rows(0)(1)
            user.LastName = result.Tables(0).Rows(0)(2)
            user.Phone = result.Tables(0).Rows(0)(3)
            user.Email = result.Tables(0).Rows(0)(4)
            user.RoleId = result.Tables(0).Rows(0)(5)
            user.Password = result.Tables(0).Rows(0)(6)
            user.RegAt = result.Tables(0).Rows(0)(7)
            user.LocId = result.Tables(0).Rows(0)(8)
            If user Is Nothing Then
                Throw New FoodOrderException("No Such Record found")
            Else
                Return user
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function


End Class
