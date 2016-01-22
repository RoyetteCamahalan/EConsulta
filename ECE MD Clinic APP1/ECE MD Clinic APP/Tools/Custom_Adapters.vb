Imports System.Data
Imports System.Data.SqlClient
Public Class Custom_Adapters
    Public sqlCommand As New SqlCommand
    Private dt As New DataTable
    Private sqladapter As New SqlDataAdapter
    Public Function CUSTOM_RETRIEVE(ByRef SP_Name As String, ByRef Param_Name As String(), ByRef Param_Value As String()) As DataTable
        Try
            dt.Clear()
            sqlCommand = New SqlCommand
            sqlCommand.Connection = conn
            sqlCommand.CommandText = SP_Name
            sqlCommand.CommandType = CommandType.StoredProcedure

            For i As Integer = 0 To Param_Name.Length - 1
                sqlCommand.Parameters.AddWithValue(Param_Name(i), Param_Value(i))
            Next

            sqladapter = New SqlDataAdapter(sqlCommand)
            sqladapter.Fill(dt)
        Catch ex As Exception

        End Try
        Return dt
    End Function
    Public Function CUSTOM_TRANSACT(ByRef SP_Name As String, ByRef Param_Name As String(), ByRef Param_Value As String()) As Boolean
        Try
            sqlCommand = New SqlCommand
            sqlCommand.Connection = conn
            sqlCommand.CommandText = SP_Name
            sqlCommand.CommandType = CommandType.StoredProcedure

            For i As Integer = 0 To Param_Name.Length - 1
                sqlCommand.Parameters.AddWithValue(Param_Name(i), Param_Value(i))
            Next
            Return sqlCommand.ExecuteNonQuery > 0
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function CUSTOM_TRANSACT_WITH_RETURN(ByRef SP_Name As String, ByRef Param_Name As String(), ByRef Param_Value As String()) As Integer
        Try
            sqlCommand = New SqlCommand
            sqlCommand.Connection = conn
            sqlCommand.CommandText = SP_Name
            sqlCommand.CommandType = CommandType.StoredProcedure

            For i As Integer = 0 To Param_Name.Length - 1
                sqlCommand.Parameters.AddWithValue(Param_Name(i), Param_Value(i))
            Next
            sqlCommand.Parameters.Add("@last_insert_id", SqlDbType.Int).Direction = ParameterDirection.Output
            sqlCommand.ExecuteNonQuery()
            Return sqlCommand.Parameters("@last_insert_id").Value
        Catch ex As Exception
            Return 0
        End Try
    End Function
End Class
