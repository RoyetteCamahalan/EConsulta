Public Class select_time
    Public rowindex As Integer
    Public action_type As Integer
    Private Sub select_time_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If action_type = 1 Then
            DateTimePicker1.Enabled = False
        Else
            DateTimePicker1.Enabled = True
        End If
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Dim comment As String = ""
        If Not txt_comment.Text = "Write Comment/Message to Patient" Then
            comment = txt_comment.Text
        End If
        If action_type = 1 Then
            Notification.accept(rowindex, DateTimePicker1.Value, comment)
        Else
            Notification.decline(rowindex, comment)
        End If

        Me.Dispose()
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Dispose()
    End Sub

    Private Sub txt_comment_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comment.Enter
        With txt_comment
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_comment_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_comment.Leave
        With txt_comment
            If .Text = "" Then
                .Text = "Write Comment/Message to Patient"
                .ForeColor = Color.Gray
            End If
        End With
    End Sub
End Class