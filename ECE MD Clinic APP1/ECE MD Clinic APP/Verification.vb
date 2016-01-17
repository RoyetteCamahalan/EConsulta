Public Class Verification
    Public action_verified As Integer
    Public overwrite As Integer = 0
    Private Sub Verification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If overwrite = 0 Then
            UsernameTextBox.ReadOnly = True
            UsernameTextBox.Text = UserName
        Else
            UsernameTextBox.ReadOnly = False
        End If
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If PasswordTextBox.Text.ToLower = PassWord.ToLower Then
            Select Case action_verified
                Case 1
                    user_profile.save_userprofilecontact()
                Case 2
                    View_Secretary.update_secretary_profile()
                Case 3
                    user_profile.save_userprofilebasic()
                Case 4
                    user_profile.save_userprofileaccount()
            End Select
            Label1.Hide()
            Me.Dispose()
        Else
            Label1.Text = "Password Does Not Match"
            Label1.Visible = True
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Dispose()
    End Sub

End Class