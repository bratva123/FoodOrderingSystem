Imports System.Data.SqlClient

Public Class LocationOperation

    Implements ILocationOperation

    Dim con As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim ad As SqlDataAdapter

    Dim connString As String = "Data source=DEL1-LHP-N70246;initial catalog=FoodOrderDb;integrated security=true;"

    Public Function AddLocation(loc As Location) As Integer Implements ILocationOperation.AddLocation
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Add_location", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@address", loc.Address)
            cmd.Parameters.AddWithValue("@landmark", loc.Landmark)
            cmd.Parameters.AddWithValue("@pincode", loc.Pincode)
            cmd.Parameters.AddWithValue("@user_id", loc.UserId)

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


    Public Function UpdateLocation(loc As Location) As Integer Implements ILocationOperation.UpdateLocation
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Update_location", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", loc.Id)
            cmd.Parameters.AddWithValue("@address", loc.Address)
            cmd.Parameters.AddWithValue("@landmark", loc.Landmark)
            cmd.Parameters.AddWithValue("@pincode", loc.Pincode)
            cmd.Parameters.AddWithValue("@user_id", loc.UserId)
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


    Public Function DeleteLocationById(id As Integer) As Integer Implements ILocationOperation.DeleteLocationById
        con = New SqlConnection(connString)
        Dim result As Integer
        Try
            con.Open()
            cmd = New SqlCommand("Delete_location_ByID", con)
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



    Public Function GetLocationById(id As Integer) As Location Implements ILocationOperation.GetLocationById
        con = New SqlConnection(connString)
        Dim result As New DataSet
        Try
            cmd = New SqlCommand("Get_location_ByID", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@id", id)
            ad = New SqlDataAdapter(cmd)
            ad.Fill(result)
            Dim loc As New Location
            loc.Id = result.Tables(0).Rows(0)(0)
            loc.Address = result.Tables(0).Rows(0)(1)
            loc.Landmark = result.Tables(0).Rows(0)(2)
            loc.Pincode = result.Tables(0).Rows(0)(3)
            loc.UserId = result.Tables(0).Rows(0)(4)

            If loc Is Nothing Then
                Throw New FoodOrderException("No Such Record found")
            Else
                Return loc
            End If
        Catch ex As FoodOrderException
            Throw ex
        End Try
    End Function

End Class
