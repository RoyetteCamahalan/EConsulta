
Public Class TextAndButtonControl

    Public Sub renderControl()

        btn_accept.Location = New Point(0, 0)
        btn_accept.Width = Me.Width / 2
        btn_accept.Height = Me.Height

        btn_decline.Location = New Point(Me.Width / 2, 0)
        btn_decline.Width = Me.Width / 2
        btn_decline.Height = Me.Height
    End Sub

    Private Sub btn_accept_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_accept.Click
        Try
            select_time.rowindex = Convert.ToInt32(btn_accept.Tag)
            select_time.action_type = 1
            select_time.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_decline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_decline.Click
        Try
            select_time.rowindex = Convert.ToInt32(btn_decline.Tag)
            select_time.action_type = 2
            select_time.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class
