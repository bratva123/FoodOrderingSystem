Imports System.Data.SqlClient
Imports System.IO

Public Class FoodItemOperation
    Implements IFoodItemOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter

    Dim connString As String = File.ReadAllText("./connectionString.txt")
    Public Function AddFoodItem(fi As FoodItem) As Integer Implements IFoodItemOperation.AddFoodItem
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_addFoodItem", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@name", fi.Name)
            cmd.Parameters.AddWithValue("@catId", fi.CategoryId)
            cmd.Parameters.AddWithValue("@loc", fi.ImgLoc)
            cmd.Parameters.AddWithValue("@by", fi.CreatedBy)
            cmd.Parameters.AddWithValue("@at", fi.CreatedAt)
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

    Public Function GetAllFoodItem() As List(Of FoodItem) Implements IFoodItemOperation.GetAllFoodItem
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim items As New List(Of FoodItem)
        Try
            cmd = New SqlCommand("sp_getAllFoodItem", con)
            cmd.CommandType = CommandType.StoredProcedure
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim item As FoodItem
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                For Each rows In result.Tables(0).Rows
                    item = New FoodItem
                    item.Id = rows(0)
                    item.Name = rows(1)
                    item.CategoryId = rows(2)
                    item.ImgLoc = rows(3)
                    item.CreatedBy = rows(4)
                    item.CreatedAt = rows(5)
                    items.Add(item)
                Next
                Return items
            End If


        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("No Records Found")
        End Try
    End Function

    Public Function GetItemById(id As Integer) As FoodItem Implements IFoodItemOperation.GetItemById
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("sp_getFoodItemById", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim item As New FoodItem
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No Such Record found")
            Else
                item.Id = result.Tables(0).Rows(0)(0)
                item.Name = result.Tables(0).Rows(0)(1)
                item.CategoryId = result.Tables(0).Rows(0)(2)
                item.ImgLoc = result.Tables(0).Rows(0)(3)
                item.CreatedBy = result.Tables(0).Rows(0)(4)
                item.CreatedAt = result.Tables(0).Rows(0)(5)
                Return item
            End If


        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("No Such Records Exist")
        End Try
    End Function

    Public Function DeleteFoodItemById(id As Integer) As Integer Implements IFoodItemOperation.DeleteFoodItemById
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_deleteFoodItem", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("No Such Record Founds")
            Else
                Return result
            End If
        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("Already Exist .. Or No Such Record Found")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

    Public Function UpdateFoodItems(fi As FoodItem) As Integer Implements IFoodItemOperation.UpdateFoodItems
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("sp_updateFoodItem", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", fi.Id)
            cmd.Parameters.AddWithValue("@name", fi.Name)
            cmd.Parameters.AddWithValue("@catId", fi.CategoryId)
            cmd.Parameters.AddWithValue("@loc", fi.ImgLoc)
            cmd.Parameters.AddWithValue("@by", fi.CreatedBy)
            cmd.Parameters.AddWithValue("@at", fi.CreatedAt)
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
    Public Function GetItemsByName(ch As String) As List(Of FoodItem) Implements IFoodItemOperation.GetItemsByName
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim items As New List(Of FoodItem)
        Try
            cmd = New SqlCommand("sp_getFoodItemByName", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ch", ch)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim item As FoodItem
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                For Each rows In result.Tables(0).Rows
                    item = New FoodItem
                    item.Id = rows(0)
                    item.Name = rows(1)
                    item.CategoryId = rows(2)
                    item.ImgLoc = rows(3)
                    item.CreatedBy = rows(4)
                    item.CreatedAt = rows(5)
                    items.Add(item)
                Next
                Return items
            End If


        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("No Records Found")
        End Try
    End Function

    Public Function GetByNameAndCategoryId(ch As String, catId As Integer) As List(Of FoodItem) Implements IFoodItemOperation.GetByNameAndCategoryId
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim items As New List(Of FoodItem)
        Try
            cmd = New SqlCommand("sp_getFoodItemByNameAndCatId", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@ch", ch)
            cmd.Parameters.AddWithValue("@catId", catId)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim item As FoodItem
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                For Each rows In result.Tables(0).Rows
                    item = New FoodItem
                    item.Id = rows(0)
                    item.Name = rows(1)
                    item.CategoryId = rows(2)
                    item.ImgLoc = rows(3)
                    item.CreatedBy = rows(4)
                    item.CreatedAt = rows(5)
                    items.Add(item)
                Next
                Return items
            End If

        Catch ex As Exception When TypeOf ex Is FoodOrderException OrElse TypeOf ex Is SqlException
            Throw New FoodOrderException("No Records Found")
        End Try

    End Function
End Class
