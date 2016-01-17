Public Class prescription

    Private Sub prescription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            PrintForm1.Print()
        Catch ex As Exception

        End Try
    End Sub
End Class