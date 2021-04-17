Imports System.Data.SqlClient

Public Class OrderOperation
    Implements IOrderOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter

    Dim connString As String = "Data source=DEL1-LHP-N67743;initial catalog=FoodOrderDb;integrated security=true;"

    Public Function CreateOrder(ord As Order) As Integer Implements IOrderOperation.CreateOrder
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Add_Order", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@userId", ord.UserId)
            cmd.Parameters.AddWithValue("@total_price", ord.TotalPrice)
            cmd.Parameters.AddWithValue("@items_detail_id", ord.ItemsDetailId)
            cmd.Parameters.AddWithValue("@order_date", ord.OrderDate)
            cmd.Parameters.AddWithValue("@payment_id", ord.PaymentId)
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

    Public Function UpdateOrder(ord As Order) As Integer Implements IOrderOperation.UpdateOrder
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Update_Order", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", ord.ID)
            cmd.Parameters.AddWithValue("@userId", ord.UserId)
            cmd.Parameters.AddWithValue("@total_price", ord.TotalPrice)
            cmd.Parameters.AddWithValue("@items_detail_id", ord.ItemsDetailId)
            cmd.Parameters.AddWithValue("@order_date", ord.OrderDate)
            cmd.Parameters.AddWithValue("@payment_id", ord.PaymentId)
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

    Public Function GetOrderById(id As Integer) As Order Implements IOrderOperation.GetOrderById
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("Get_food_menu_by_Item_id", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim ord As New Order
            ord.ID = result.Tables(0).Rows(0)(0)
            ord.UserId = result.Tables(0).Rows(0)(1)
            ord.TotalPrice = result.Tables(0).Rows(0)(2)
            ord.ItemsDetailId = result.Tables(0).Rows(0)(3)
            ord.OrderDate = result.Tables(0).Rows(0)(4)
            ord.PaymentId = result.Tables(0).Rows(0)(5)
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return ord
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

    Public Function GetByUserId(userId As Integer) As List(Of Order) Implements IOrderOperation.GetByUserId
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim orders As New List(Of Order)
        Try
            cmd = New SqlCommand("Get_Order_By_User_Id", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@user_id", userId)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim ord As Order
            For Each rows In result.Tables(0).Rows
                ord = New Order
                ord.ID = rows(0)
                ord.UserId = rows(1)
                ord.TotalPrice = rows(2)
                ord.ItemsDetailId = rows(3)
                ord.OrderDate = rows(4)
                ord.PaymentId = rows(5)
                orders.Add(ord)
            Next
            If orders.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return orders
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

    Public Function GetByPaymentId(userId As Integer) As Order Implements IOrderOperation.GetByPaymentId
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim orders As New List(Of Order)
        Try
            cmd = New SqlCommand("Get_Order_By_Payment_ID", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@user_id", userId)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim ord As New Order
            ord.ID = result.Tables(0).Rows(0)(0)
            ord.UserId = result.Tables(0).Rows(0)(1)
            ord.TotalPrice = result.Tables(0).Rows(0)(2)
            ord.ItemsDetailId = result.Tables(0).Rows(0)(3)
            ord.OrderDate = result.Tables(0).Rows(0)(4)
            ord.PaymentId = result.Tables(0).Rows(0)(5)
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return ord
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function
    Public Function GetByDate(orderDate As Date) As List(Of Order) Implements IOrderOperation.GetByDate
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim orders As New List(Of Order)
        Try
            cmd = New SqlCommand("Get_Order_By_Date", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@date", orderDate)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim ord As Order
            For Each rows In result.Tables(0).Rows
                ord = New Order
                ord.ID = rows(0)
                ord.UserId = rows(1)
                ord.TotalPrice = rows(2)
                ord.ItemsDetailId = rows(3)
                ord.OrderDate = rows(4)
                ord.PaymentId = rows(5)
                orders.Add(ord)
            Next
            If orders.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return orders
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

    Public Function GetByUserIdAndDate(userId As Integer, orderDate As Date) As List(Of Order) Implements IOrderOperation.GetByUserIdAndDate
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim orders As New List(Of Order)
        Try
            cmd = New SqlCommand("Get_Order_By_User_Id_Date", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@user_id", userId)
            cmd.Parameters.AddWithValue("@date", orderDate)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim ord As Order
            For Each rows In result.Tables(0).Rows
                ord = New Order
                ord.ID = rows(0)
                ord.UserId = rows(1)
                ord.TotalPrice = rows(2)
                ord.ItemsDetailId = rows(3)
                ord.OrderDate = rows(4)
                ord.PaymentId = rows(5)
                orders.Add(ord)
            Next
            If orders.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return orders
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

End Class
