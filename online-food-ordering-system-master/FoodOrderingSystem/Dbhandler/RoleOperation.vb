Imports System.Data.SqlClient
Imports System.IO

Public Class RoleOperation
    Implements IRoleOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter

    Dim connString As String = File.ReadAllText("./connectionString.txt")
    Public Function AddRole(role As Role) As Integer Implements IRoleOperation.AddRole
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_addUserRole", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@name", role.Name)
            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("Some thing Went Wrong")
            Else
                Return result
                Exit Function
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("Already Exist ..")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

    Public Function GetAllRole() As List(Of Role) Implements IRoleOperation.GetAllRole
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim roles As New List(Of Role)
        Try
            cmd = New SqlCommand("sp_getAllRole", con)
            cmd.CommandType = CommandType.StoredProcedure
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim role As Role
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                For Each rows In result.Tables(0).Rows
                    role = New Role
                    role.Id = rows(0)
                    role.Name = rows(1)
                    roles.Add(role)
                Next
                Return roles
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("No records found")
        End Try
    End Function

    Public Function GetRoleById(id As Integer) As Role Implements IRoleOperation.GetRoleById
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("sp_getRoleById", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim role As New Role
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No Such Record found")
            Else
                role.Id = result.Tables(0).Rows(0)(0)
                role.Name = result.Tables(0).Rows(0)(1)
                Return role
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("No Such Records found")
        End Try
    End Function

    Public Function DeleteRole(id As Integer) As Integer Implements IRoleOperation.DeleteRole
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_deleteUserRole", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("No Such Record Founds")
            Else
                Return result
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("Cannot Delete or No Such Reccords found")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

    Public Function UpdateRole(role As Role) As Integer Implements IRoleOperation.UpdateRole
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_updateUserRole", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", role.Id)
            cmd.Parameters.AddWithValue("@name", role.Name)

            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("Something went Wrong")
            Else
                Return result
                Exit Function
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("Cannot Update or Something Went wrong")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function
End Class
