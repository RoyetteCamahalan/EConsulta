Public Class home_page
    Private contact_tag As Boolean = False
    Private account_tag As Boolean = False
    Private personal_tag As Boolean = True

    Private Sub lbl_personal_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_personal.MouseEnter
        lbl_personal.ForeColor = Color.Blue
    End Sub

    Private Sub lbl_personal_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_personal.MouseLeave

        If Not personal_tag Then
            lbl_personal.ForeColor = Color.CornflowerBlue
        End If
    End Sub

    Private Sub lbl_contact_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_contact.MouseEnter
        lbl_contact.ForeColor = Color.Blue
    End Sub

    Private Sub lbl_contact_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_contact.MouseLeave

        If Not contact_tag Then
            lbl_contact.ForeColor = Color.CornflowerBlue
        End If
    End Sub
    Private Sub lbl_personal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_personal.Click
        
        personal_tag = True
        account_tag = False
        contact_tag = False
        lbl_contact.ForeColor = Color.CornflowerBlue
        lbl_personal.ForeColor = Color.Blue
        personal_bar.FillColor = Color.Cyan
        contact_bar.FillColor = Color.LightGray
    End Sub

    Private Sub lbl_contact_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_contact.Click
        personal_tag = False
        account_tag = False
        contact_tag = True
        lbl_contact.ForeColor = Color.Blue
        lbl_personal.ForeColor = Color.CornflowerBlue
        personal_bar.FillColor = Color.LightGray
        contact_bar.FillColor = Color.Cyan
    End Sub

    Private Sub lbl_account_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        personal_tag = False
        account_tag = True
        contact_tag = False
        lbl_contact.ForeColor = Color.CornflowerBlue
        lbl_personal.ForeColor = Color.CornflowerBlue
        personal_bar.FillColor = Color.LightGray
        contact_bar.FillColor = Color.LightGray
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        NotifyIcon1.ShowBalloonTip(10000, "Birthdays", "Vincent's Birthday is today!", ToolTipIcon.Info)
    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick

    End Sub

    Private Sub home_page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_logout.Click
        main_menu.readytoclose = False
        UserName = ""
        PassWord = ""
        UserId = 0
        UserType = 0
        frm_login.Show()
        main_menu.Close()
    End Sub
End Class