Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.SqlServer

Public Class CategoryOperation
    Implements ICategoryOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter
    Dim connString As String = File.ReadAllText("./connectionString.txt")
    Public Function AddCategory(cate As Category) As Integer Implements ICategoryOperation.AddRole
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_addCategory", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@name", cate.Name)
            cmd.Parameters.AddWithValue("@loc", cate.ImgLoc)
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

    Public Function GetAllCategory() As List(Of Category) Implements ICategoryOperation.GetAllRole
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim categories As New List(Of Category)
        Try
            cmd = New SqlCommand("sp_getAllCategory", con)
            cmd.CommandType = CommandType.StoredProcedure
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim cate As Category
            If result.Tables.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                For Each rows In result.Tables(0).Rows
                    cate = New Category
                    cate.Id = rows(0)
                    cate.Name = rows(1)
                    cate.ImgLoc = rows(2)
                    categories.Add(cate)
                Next
                Return categories
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("Already Exist")
        End Try
    End Function

    Public Function GetCategoryById(id As Integer) As Category Implements ICategoryOperation.GetcategoryById
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("sp_getCategoryById", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim cate As New Category
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No Such Record found")
            Else
                Debug.WriteLine(result.Tables(0).Rows(0)(0))
                Dim rows = result.Tables(0).Rows(0)
                cate.Id = rows(0)
                cate.Name = rows(1)
                cate.ImgLoc = rows(2)
                Return cate
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("No Such record Found")
        End Try
    End Function

    Public Function DeleteCategoryById(id As Integer) As Integer Implements ICategoryOperation.DeleteCategoryById
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_deleteCategory", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("No Such Record Founds")
            Else
                Return result
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("Cannot delete or No such record")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

    Public Function UpdateCategory(cate As Category) As Integer Implements ICategoryOperation.UpdateCategory
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_updateCategory", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", cate.Id)
            cmd.Parameters.AddWithValue("@name", cate.Name)
            cmd.Parameters.AddWithValue("@loc", cate.ImgLoc)

            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("Something went Wrong")
            Else
                Return result
                Exit Function
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("Something Went Wrong")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

End Class
