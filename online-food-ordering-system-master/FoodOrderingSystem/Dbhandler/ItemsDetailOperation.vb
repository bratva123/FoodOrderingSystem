Imports System.Data.SqlClient

Public Class ItemsDetailOperation

    Implements IItemsDetailOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter

    Dim connString As String = "Data source=DEL1-LHP-N70246;initial catalog=FoodOrderDb;integrated security=true;"

    Public Function AddItemsDetail(itemd As ItemsDetail) As Integer Implements IItemsDetailOperation.AddItemsDetail
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Insert_items_detail", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@order_id", itemd.OrderId)
            cmd.Parameters.AddWithValue("@item_id", itemd.ItemId)
            cmd.Parameters.AddWithValue("@qty", itemd.Qty)
            cmd.Parameters.AddWithValue("@price", itemd.Price)

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

    Public Function UpdateItemsDetail(itemd As ItemsDetail) As Integer Implements IItemsDetailOperation.UpdateItemsDetail
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Update_items_detail", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", itemd.Id)
            cmd.Parameters.AddWithValue("@order_id", itemd.OrderId)
            cmd.Parameters.AddWithValue("@item_id", itemd.ItemId)
            cmd.Parameters.AddWithValue("@qty", itemd.Qty)
            cmd.Parameters.AddWithValue("@price", itemd.Price)

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


    Public Function GetItemsDetailById(id As Integer) As ItemsDetail Implements IItemsDetailOperation.GetItemsDetailById

        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("Get_items_detail_ByID", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim itemd As New ItemsDetail
            itemd.Id = result.Tables(0).Rows(0)(0)
            itemd.OrderId = result.Tables(0).Rows(0)(1)
            itemd.ItemId = result.Tables(0).Rows(0)(2)
            itemd.Qty = result.Tables(0).Rows(0)(3)
            itemd.Price = result.Tables(0).Rows(0)(4)

            If itemd Is Nothing Then
                Throw New FoodOrderException("No Such Record found")
            Else
                Return itemd
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

End Class
