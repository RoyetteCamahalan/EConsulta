Imports System.Data.SqlClient
Imports System.Data

Public Class frm_login
#Region "Methods"
    Private Sub VerifyUser()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@username"}
            Dim Param_Value As String() = {0, 1, UsernameTextBox.Text}
            Dim MyAdapter As New Custom_Adapters
            Dim DT As New DataTable
            DT = MyAdapter.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
            If DT.Rows.Count > 0 Then
                UserName = UsernameTextBox.Text
                Param_Name = {"@action_type", "@sub_action", "@username", "@password"}
                Param_Value = {0, 2, UsernameTextBox.Text, PasswordTextBox.Text}
                DT = MyAdapter.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
                If DT.Rows.Count > 0 Then
                    UserType = DT.Rows(0).Item(3)
                    UserId = DT.Rows(0).Item(0)
                    Dim FullName As String = "'"
                    FullName = DT.Rows(0).Item(4).ToString
                    If UserType = 0 Then
                        Dim dschecker As New DataSet
                        Param_Name = {"@action_type", "@sub_action", "@secretary_id"}
                        Param_Value = {1, 1, UserId}
                        DT = MyAdapter.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
                        If DT.Rows.Count <= 0 Then
                            MsgBox("Access Denied, No Doctor who allow this account to access files.")
                        Else
                            Label1.Visible = False
                            PassWord = PasswordTextBox.Text
                            PasswordTextBox.Text = ""
                            Form_Main.Show()
                            Form_Main.lbl_user_name.Text = FullName
                            Me.Hide()
                        End If
                    Else
                        Label1.Visible = False
                        PassWord = PasswordTextBox.Text
                        PasswordTextBox.Text = ""
                        Form_Main.Show()
                        Form_Main.lbl_user_name.Text = FullName
                        Me.Hide()
                    End If


                Else
                    Label1.Text = "Password Incorrect"
                    Label1.Visible = True
                    PasswordTextBox.Text = ""
                End If
            Else
                Label1.Text = "Username and Password Does not exist"
                Label1.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        VerifyUser()
    End Sub

    Private Sub LoginForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not connect() Then
            Me.Dispose()
        End If
    End Sub

    Private Sub frm_login_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If main_menu.readytoclose = False Then
            e.Cancel = True
            conn.Close()
        End If
    End Sub

    Private Sub UsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UsernameTextBox.TextChanged
        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            OK.Enabled = False
        Else
            OK.Enabled = True
        End If
    End Sub

    Private Sub PasswordTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasswordTextBox.TextChanged
        If UsernameTextBox.Text = "" Or PasswordTextBox.Text = "" Then
            OK.Enabled = False
        Else
            OK.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String = DateTimePicker1.Value.ToShortTimeString
        MsgBox(str)
    End Sub
End Class
