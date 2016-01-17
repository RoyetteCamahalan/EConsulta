Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class frm_login
    Private da As New MySqlDataAdapter
    Private cmd As New MySqlCommand
    Private ds As New DataSet
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            ds.Clear()
            cmd = New MySqlCommand("SELECT `id`,`username`, `password`,0 as Usertype FROM `secretaries` where username=@uname union all" +
                            " SELECT `id`, `username`, `password`,1 as Usertype FROM `doctors` where username=@uname", conn)
            cmd.Parameters.AddWithValue("uname", UsernameTextBox.Text)
            da.SelectCommand = cmd
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                UserName = UsernameTextBox.Text
                ds.Clear()
                cmd = New MySqlCommand("SELECT `id`,`username`, `password`,0 as Usertype FROM `secretaries` inner join clinic_secretary on secretary_id=id where password=@pword and username=@uname union all" +
                                        " SELECT `id`, `username`, `password`,1 as Usertype FROM `doctors` where password=@pword and  username=@uname", conn)
                cmd.Parameters.AddWithValue("pword", PasswordTextBox.Text)
                cmd.Parameters.AddWithValue("uname", UsernameTextBox.Text)
                da.SelectCommand = cmd
                da.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    UserType = ds.Tables(0).Rows(0).Item(3)
                    UserId = ds.Tables(0).Rows(0).Item(0)
                    If UserType = 0 Then
                        Dim dschecker As New DataSet
                        da = New MySqlDataAdapter("select * from secretary_access where secretary_id=" + UserId.ToString, conn)
                        da.Fill(dschecker)
                        If dschecker.Tables(0).Rows.Count <= 0 Then
                            MsgBox("Access Denied, No Doctor who allow this account to access files.")
                        Else
                            Label1.Visible = False
                            PassWord = PasswordTextBox.Text
                            main_menu.Show()
                            main_menu.readytoclose = True
                            Me.Hide()
                        End If
                    Else
                        Label1.Visible = False
                        PassWord = PasswordTextBox.Text
                        main_menu.Show()
                        main_menu.readytoclose = True
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
