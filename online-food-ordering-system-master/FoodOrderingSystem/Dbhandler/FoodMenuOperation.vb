Imports System.Data.SqlClient

Public Class FoodMenuOperation
    Implements IFoodMenuOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter

    Dim connString As String = "Data source=DEL1-LHP-N67743;initial catalog=FoodOrderDb;integrated security=true;"

    Public Function AddFoodMenu(fm As FoodMenu) As Integer Implements IFoodMenuOperation.AddFoodMenu
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Add_food_menu", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@item_id", fm.ItemId)
            cmd.Parameters.AddWithValue("@price", fm.Price)
            cmd.Parameters.AddWithValue("@qty", fm.Quantity)
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

    Public Function UpdateFoodMenu(fm As FoodMenu) As Integer Implements IFoodMenuOperation.UpdateFoodMenu
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Update_food_menu", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", fm.Id)
            cmd.Parameters.AddWithValue("@item_id", fm.ItemId)
            cmd.Parameters.AddWithValue("@price", fm.Price)
            cmd.Parameters.AddWithValue("@qty", fm.Quantity)
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

    Public Function DeleteFoodMenuById(id As Integer) As Integer Implements IFoodMenuOperation.DeleteFoodMenuById
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Delete_food_menu", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            result = cmd.ExecuteNonQuery()
            If result = 0 Then
                Throw New FoodOrderException("No Such Record Founds")
            Else
                Return result
            End If
        Catch ex As FoodOrderException
            Throw ex
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Function

    Public Function GetByCategoryId(categoryId As Integer) As List(Of FoodMenu) Implements IFoodMenuOperation.GetByCategoryId
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim menus As New List(Of FoodMenu)
        Try
            cmd = New SqlCommand("Get_food_menu_by_Category", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@category_id", categoryId)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim menu As FoodMenu
            For Each rows In result.Tables(0).Rows
                menu = New FoodMenu
                menu.Id = rows(0)
                menu.ItemId = rows(1)
                menu.Price = rows(2)
                menu.Quantity = rows(3)
                menus.Add(menu)
            Next
            If menus.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return menus
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

    Public Function GetByItemName(name As String) As List(Of FoodMenu) Implements IFoodMenuOperation.GetByItemName
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim menus As New List(Of FoodMenu)
        Try
            cmd = New SqlCommand("Get_food_menu_by_Item_name", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@item_name", name)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim menu As FoodMenu
            For Each rows In result.Tables(0).Rows
                menu = New FoodMenu
                menu.Id = rows(0)
                menu.ItemId = rows(1)
                menu.Price = rows(2)
                menu.Quantity = rows(3)
                menus.Add(menu)
            Next
            If menus.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return menus
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

    Public Function GetByItemId(itemId As Integer) As FoodMenu Implements IFoodMenuOperation.GetByItemId
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim menus As New List(Of FoodMenu)
        Try
            cmd = New SqlCommand("Get_food_menu_by_Item_id", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@item_id", itemId)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim menu As FoodMenu
            For Each rows In result.Tables(0).Rows
                menu = New FoodMenu
                menu.Id = rows(0)
                menu.ItemId = rows(1)
                menu.Price = rows(2)
                menu.Quantity = rows(3)
                menus.Add(menu)
            Next
            If menus.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return menus(0)
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function


End Class
