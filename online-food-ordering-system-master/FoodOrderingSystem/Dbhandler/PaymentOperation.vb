Imports System.Data.SqlClient

Public Class PaymentOperation
    Implements IPaymentOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter

    Dim connString As String = "Data source=DEL1-LHP-N67743;initial catalog=FoodOrderDb;integrated security=true;"

    Public Function Add_Payment(pay As Payment) As Integer Implements IPaymentOperation.Add_Payment
        con = New SqlConnection(connString)
        Dim result As New DataSet

        Try
            con.Open()
            cmd = New SqlCommand("Add_Payment", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@mode", pay.Mode)
            cmd.Parameters.AddWithValue("@status", pay.Status)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)

            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("Some thing Went Wrong")
            Else
                Return result.Tables(0).Rows(0)(0)
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

    Public Function GetAll() As List(Of Payment) Implements IPaymentOperation.GetAll
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Dim paymennts As New List(Of Payment)
        Try
            cmd = New SqlCommand("Get_All_Payment", con)
            cmd.CommandType = CommandType.StoredProcedure
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim item As Payment
            For Each rows In result.Tables(0).Rows
                item = New Payment
                item.Id = rows(0)
                item.Mode = rows(1)
                item.Status = rows(2)
                paymennts.Add(item)
            Next
            If paymennts.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return paymennts
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

    Public Function GetById(id As Integer) As Payment Implements IPaymentOperation.GetById
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("Get_Payment_By_Id", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim payment As New Payment
            payment.Id = result.Tables(0).Rows(0)(0)
            payment.Mode = result.Tables(0).Rows(0)(1)
            payment.Status = result.Tables(0).Rows(0)(2)
            If result.Tables(0).Rows.Count = 0 Then
                Throw New FoodOrderException("No records found")
            Else
                Return payment
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function
End Class
