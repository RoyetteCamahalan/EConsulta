Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class main_menu
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private today_tag As Boolean = False
    Private incoming_tag As Boolean = False
    Private consultation_tag As Boolean = True
    Private contact_tag As Boolean = False
    Private account_tag As Boolean = False
    Private personal_tag As Boolean = True
    Public readytoclose As Boolean = True
    Private interval As Integer
    Private is_done As Integer = 0

    Private Sub main_menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If UserType = 0 Then
            Me.TabControl1.TabPages.Remove(TabPage6)
            Me.TabControl1.TabPages.Remove(TabPage5)
        ElseIf UserType = 1 Then
            Me.TabControl1.TabPages.Remove(TabPage6)
        End If
        'TimerSync.Start()
        reload_cached()
        Try
            'ds.Clear()
            'da = New MySqlDataAdapter("SELECT id,fname as 'First Name', mname as 'Middle Name', lname as 'Last Name',sex as 'Sex','More Details....' as Action  FROM patients" + SEARCH, conn)
            'da.Fill(ds)
            'TextBox1.AutoCompleteCustomSource = ds.Tables(1)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        consult.MdiParent = Me
        consult.Parent = Me.TabPage3
        consult.Show()
        Counter_Notification()

    End Sub
    
    Private Sub reload_cached()
        Try
            If Directory.Exists("C:\ECE MD Clinic APP\TEST_RESULTS_CACHED") Then
                My.Computer.FileSystem.DeleteDirectory("C:\ECE MD Clinic APP\TEST_RESULTS_CACHED", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
            Directory.CreateDirectory("C:\ECE MD Clinic APP\TEST_RESULTS_CACHED")
        Catch ex As Exception

        End Try

    End Sub
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Select Case TabControl1.SelectedIndex
            Case 0
                consult.MdiParent = Me
                consult.Parent = Me.TabPage3
                consult.Show()
                
            Case 1
                Consultation.MdiParent = Me
                Consultation.Parent = Me.consultation_panel
                today.MdiParent = Me
                today.Parent = Me.consultation_panel
                incoming.MdiParent = Me
                incoming.Parent = Me.consultation_panel
                If consultation_tag Then
                    Consultation.Show()
                ElseIf today_tag Then
                    today.Show()
                ElseIf incoming_tag Then
                    incoming.Show()
                End If
            Case 2

                Patients.MdiParent = Me
                Patients.Parent = Me.TabPage2
                Patients.Show()
            Case 3
                If UserType = 1 Then
                    secretary.MdiParent = Me
                    secretary.Parent = Me.TabPage5
                    secretary.Show()
                End If

            Case 4
                secretary.MdiParent = Me
                secretary.Parent = Me.TabPage5
                secretary.Show()
        End Select
    End Sub
#Region "Nav-bar-like-Consultaion"
    Private Sub lbl_consultation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_consultation.Click

        lbl_consultation.ForeColor = Color.Blue
        lbl_incoming.ForeColor = Color.CornflowerBlue
        lbl_today.ForeColor = Color.CornflowerBlue
        today_tag = False
        consultation_tag = True
        incoming_tag = False

        consultation_bar.FillColor = Color.Cyan
        today_bar.FillColor = Color.LightGray
        incoming_bar.FillColor = Color.LightGray

        today.Hide()
        incoming.Hide()
        Consultation.Show()
        Consultation.Timer1.Start()
    End Sub

    Private Sub lbl_today_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_today.Click
        lbl_consultation.ForeColor = Color.CornflowerBlue
        lbl_incoming.ForeColor = Color.CornflowerBlue
        lbl_today.ForeColor = Color.Blue
        today_tag = True
        consultation_tag = False
        incoming_tag = False

        today_bar.FillColor = Color.Cyan
        consultation_bar.FillColor = Color.LightGray
        incoming_bar.FillColor = Color.LightGray

        Consultation.Hide()
        incoming.Hide()
        today.Show()
        today.Timer1.Start()
    End Sub

    Private Sub lbl_incoming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_incoming.Click

        lbl_consultation.ForeColor = Color.CornflowerBlue
        lbl_incoming.ForeColor = Color.Blue
        lbl_today.ForeColor = Color.CornflowerBlue
        today_tag = False
        consultation_tag = False
        incoming_tag = True

        incoming_bar.FillColor = Color.Cyan
        consultation_bar.FillColor = Color.LightGray
        today_bar.FillColor = Color.LightGray

        Consultation.Hide()
        today.Hide()
        incoming.Show()
        incoming.Timer1.Start()
    End Sub

    Private Sub lbl_today_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_today.MouseEnter
        lbl_today.ForeColor = Color.Blue
    End Sub

    Private Sub lbl_today_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_today.MouseLeave
        If Not today_tag Then
            lbl_today.ForeColor = Color.CornflowerBlue
        End If

    End Sub

    Private Sub lbl_incoming_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_incoming.MouseEnter
        lbl_incoming.ForeColor = Color.Blue
    End Sub

    Private Sub lbl_incoming_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_incoming.MouseLeave
        If incoming_tag = False Then
            lbl_incoming.ForeColor = Color.CornflowerBlue
        End If

    End Sub

    Private Sub lbl_consultation_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_consultation.MouseEnter
        lbl_consultation.ForeColor = Color.Blue
    End Sub

    Private Sub lbl_consultation_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_consultation.MouseLeave
        If Not consultation_tag Then
            lbl_consultation.ForeColor = Color.CornflowerBlue
        End If
    End Sub
#End Region
#Region "COnsultation events"
    Private Sub btn_new_appointment(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_appoinment.Click
        New_Consultation.what_to_do = 0
        New_Consultation.ShowDialog()
    End Sub
#End Region

    Private Sub main_menu_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frm_login.Close()
    End Sub


    Private Sub TimerSync_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSync.Tick
        interval = interval + 1
        If interval = 300 Then
            SyncToWeb()
            interval = 0
        End If
    End Sub


    Private Sub main_menu_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    TabControl1.SelectedIndex = 0
                Case Keys.F2
                    TabControl1.SelectedIndex = 1
                Case Keys.F3
                    TabControl1.SelectedIndex = 2
                Case Keys.F4
                    TabControl1.SelectedIndex = 3
                Case Keys.F5
                    TabControl1.SelectedIndex = 4

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_upload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SyncToWeb()
    End Sub

    Private Sub toolstrip_log_out_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolstrip_log_out.Click
        readytoclose = False
        UserId = 0
        UserType = 0
        UserName = ""
        PassWord = ""
        frm_login.PasswordTextBox.Text = ""
        frm_login.UsernameTextBox.Text = ""
        frm_login.Show()
        Me.Dispose()
    End Sub

    Private Sub toolstrip_myprofile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolstrip_myprofile.Click
        user_profile.Show()
    End Sub

    Private Sub toolstrip_notifs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolstrip_notifs.Click
        Notification.ShowDialog()
        Counter_Notification()
    End Sub

    Private Sub notification_label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles notification_label.Click
        Notification.ShowDialog()
        notification_label.Text = ""
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox1.Visible = True
        Label1.Visible = True
        Dim t As New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf newThread2))
        t.Start()

        timer_isdone.Start()
    End Sub

    Public Sub Counter_Notification()
        Dim ds1 As New DataSet
        Try
            Dim strquery As String = ""
            If UserType = 0 Then 'secretary
                strquery = "SELECT pc.id FROM secretary_access sa INNER JOIN `consultations_request` pc on pc.doctor_id=sa.doctor_id WHERE pc.is_approved=0 and sa.secretary_id=" + UserId.ToString
            Else 'doctor
                strquery = "SELECT id from consultations_request where is_approved=0 and doctor_id=" + UserId.ToString
            End If
            da = New MySqlDataAdapter(strquery, conn)
            da.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Me.notification_label.Text = ds1.Tables(0).Rows.Count.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PictureBox1.Visible = True
        Label1.Visible = True
        Dim t As New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf newThread))
        t.Start()

        timer_isdone.Start()
    End Sub


    Private Sub newThread2()
        Call mysqlbridge.get_appointments()
        is_done = 1
        Threading.Thread.CurrentThread.Abort()
    End Sub
    Private Sub newThread()
        'Call mysqbridge_upload.UPLOAD_PATIENT()
        Call mysqbridge_upload.UPLOAD_APPOINTMENTS()
        'Call mysqbridge_upload.UPLOAD_PATIENT_RECORDS()
        'Call mysqbridge_upload.UPLOAD_MEDICINES()
        is_done = 1
        Threading.Thread.CurrentThread.Abort()
    End Sub
    
    Private Sub timer_isdone_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_isdone.Tick
        If is_done = 1 Then
            PictureBox1.Visible = False
            Label1.Visible = False
            My.Settings.Last_Update = Now.ToString
            is_done = 0
            My.Settings.Save()
            timer_isdone.Stop()
        End If
    End Sub
End Class
