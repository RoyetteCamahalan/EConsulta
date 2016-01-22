Public Class Form_Main
#Region "Variables"
    Private Selected_Menu_Index As Integer = 0
    Private Previous_Selected_Menu_Index As Integer = 0
    Private Menu_Default_Color As Color = Color.Silver
    Private Menu_Default_Color_Header As Color = Color.DimGray
    Private Menu_Selected_Color_Header As Color = Color.Gray
    Private Menu_Selected_Color_Text As Color = Color.White
    Private Container_Used As Integer = 1
    Private Transition_Control As Integer = 0
    Private Default_Height As Integer = 52
    Private Default_Width As Integer = 1150

    Private ReadyToClose As Boolean = True
#End Region
#Region "Methods"
    Private Sub ReturnToStatePreviousSelected()
        Select Case Previous_Selected_Menu_Index
            Case 0
                Menu_Consultations.ForeColor = Menu_Default_Color
                consultation_header.BackColor = Menu_Default_Color_Header
            Case 1
                Menu_Appoinments.ForeColor = Menu_Default_Color
                Appointments_Header.BackColor = Menu_Default_Color_Header
            Case 2
                Menu_Patients.ForeColor = Menu_Default_Color
                patients_header.BackColor = Menu_Default_Color_Header
            Case 3
                Menu_Secretaries.ForeColor = Menu_Default_Color
                secretaries_header.BackColor = Menu_Default_Color_Header
            Case 4
                Menu_Doctors.ForeColor = Menu_Default_Color
                doctors_header.BackColor = Menu_Default_Color_Header
        End Select
    End Sub
#End Region

    Private Sub Form_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.transition Then
            chk_transition.Checked = True
        End If
        DisplayNotificationCount()
        Patient_Record.MdiParent = Me
        Patient_Record.Parent = Panel_Container1
        Patient_Record.Show()
        Patient_Record.BringToFront()
        If UserType = 0 Then
            doctors_header.Visible = False
            secretaries_header.Visible = False
        End If
    End Sub
    Private Sub consultation_header_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Consultations.MouseEnter, consultation_header.MouseEnter
        Menu_Consultations.ForeColor = Color.White
    End Sub

    Private Sub Appointments_Header_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Appoinments.MouseEnter, Appointments_Header.MouseEnter
        Menu_Appoinments.ForeColor = Color.White
    End Sub

    Private Sub patients_header_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles patients_header.MouseEnter, Menu_Patients.MouseEnter
        Menu_Patients.ForeColor = Color.White
    End Sub

    Private Sub Menu_Secretaries_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles secretaries_header.MouseEnter, Menu_Secretaries.MouseEnter
        Menu_Secretaries.ForeColor = Color.White
    End Sub

    Private Sub doctors_header_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Doctors.MouseEnter, doctors_header.MouseEnter
        Menu_Doctors.ForeColor = Color.White
    End Sub

    Private Sub Menu_Consultations_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles secretaries_header.MouseLeave, patients_header.MouseLeave, Menu_Secretaries.MouseLeave, Menu_Patients.MouseLeave, Menu_Doctors.MouseLeave, Menu_Consultations.MouseLeave, Menu_Appoinments.MouseLeave, doctors_header.MouseLeave, consultation_header.MouseLeave, Appointments_Header.MouseLeave
        Select Case Selected_Menu_Index
            Case 0
                Menu_Appoinments.ForeColor = Menu_Default_Color
                Menu_Patients.ForeColor = Menu_Default_Color
                Menu_Secretaries.ForeColor = Menu_Default_Color
                Menu_Doctors.ForeColor = Menu_Default_Color
            Case 1
                Menu_Consultations.ForeColor = Menu_Default_Color
                Menu_Patients.ForeColor = Menu_Default_Color
                Menu_Secretaries.ForeColor = Menu_Default_Color
                Menu_Doctors.ForeColor = Menu_Default_Color
            Case 2
                Menu_Consultations.ForeColor = Menu_Default_Color
                Menu_Appoinments.ForeColor = Menu_Default_Color
                Menu_Secretaries.ForeColor = Menu_Default_Color
                Menu_Doctors.ForeColor = Menu_Default_Color
            Case 3
                Menu_Consultations.ForeColor = Menu_Default_Color
                Menu_Appoinments.ForeColor = Menu_Default_Color
                Menu_Patients.ForeColor = Menu_Default_Color
                Menu_Doctors.ForeColor = Menu_Default_Color
            Case 4
                Menu_Consultations.ForeColor = Menu_Default_Color
                Menu_Appoinments.ForeColor = Menu_Default_Color
                Menu_Patients.ForeColor = Menu_Default_Color
                Menu_Secretaries.ForeColor = Menu_Default_Color
        End Select
    End Sub

    Private Sub consultation_header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Consultations.Click, consultation_header.Click
        If Not Selected_Menu_Index = 0 Then
            Previous_Selected_Menu_Index = Selected_Menu_Index
            Selected_Menu_Index = 0
            ReturnToStatePreviousSelected()
            Menu_Consultations.ForeColor = Menu_Selected_Color_Text
            consultation_header.BackColor = Menu_Selected_Color_Header
            Patient_Record.MdiParent = Me
            If My.Settings.transition Then
                If Container_Used = 1 Then
                    Patient_Record.Parent = Panel_Container2
                    Container_Used = 2
                    Panel_Container2.Location = New Point(Default_Width, Default_Height)
                    Timer_Transition1.Start()
                Else
                    Patient_Record.Parent = Panel_Container1
                    Container_Used = 1
                    Panel_Container1.Location = New Point(Default_Width, Default_Height)
                    Timer_Transition2.Start()
                End If
            Else
                If Container_Used = 1 Then
                    Patient_Record.Parent = Panel_Container2
                    Container_Used = 2
                    Panel_Container2.Location = New Point(0, Default_Height)
                    Panel_Container2.BringToFront()
                Else
                    Patient_Record.Parent = Panel_Container1
                    Container_Used = 1
                    Panel_Container1.Location = New Point(0, Default_Height)
                    Panel_Container1.BringToFront()
                End If
            End If

            Patient_Record.Show()
            Patient_Record.BringToFront()
        End If
    End Sub

    Private Sub Appointments_Header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Appoinments.Click, Appointments_Header.Click
        If Not Selected_Menu_Index = 1 Then
            Previous_Selected_Menu_Index = Selected_Menu_Index
            Selected_Menu_Index = 1
            ReturnToStatePreviousSelected()
            Menu_Appoinments.ForeColor = Menu_Selected_Color_Text
            Appointments_Header.BackColor = Menu_Selected_Color_Header

            Appointments.MdiParent = Me
            If My.Settings.transition Then
                If Container_Used = 1 Then
                    Appointments.Parent = Panel_Container2
                    Container_Used = 2
                    Panel_Container2.Location = New Point(Default_Width, Default_Height)
                    Timer_Transition1.Start()
                Else
                    Appointments.Parent = Panel_Container1
                    Container_Used = 1
                    Panel_Container1.Location = New Point(Default_Width, Default_Height)
                    Timer_Transition2.Start()
                End If
            Else
                If Container_Used = 1 Then
                    Appointments.Parent = Panel_Container2
                    Container_Used = 2
                    Panel_Container2.Location = New Point(0, Default_Height)
                    Panel_Container2.BringToFront()
                Else
                    Appointments.Parent = Panel_Container1
                    Container_Used = 1
                    Panel_Container1.Location = New Point(0, Default_Height)
                    Panel_Container1.BringToFront()
                End If

            End If

            Appointments.Show()
            Appointments.BringToFront()
        End If
    End Sub

    Private Sub patients_header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles patients_header.Click, Menu_Patients.Click
        If Not Selected_Menu_Index = 2 Then
            Previous_Selected_Menu_Index = Selected_Menu_Index
            Selected_Menu_Index = 2
            ReturnToStatePreviousSelected()
            Menu_Patients.ForeColor = Menu_Selected_Color_Text
            patients_header.BackColor = Menu_Selected_Color_Header
            Patients.MdiParent = Me
            If My.Settings.transition Then
                If Container_Used = 1 Then
                    Patients.Parent = Panel_Container2
                    Container_Used = 2
                    Panel_Container2.Location = New Point(Default_Width, Default_Height)
                    Timer_Transition1.Start()
                Else
                    Patients.Parent = Panel_Container1
                    Container_Used = 1
                    Panel_Container1.Location = New Point(Default_Width, Default_Height)
                    Timer_Transition2.Start()
                End If
            Else
                If Container_Used = 1 Then
                    Patients.Parent = Panel_Container2
                    Container_Used = 2
                    Panel_Container2.Location = New Point(0, Default_Height)
                    Panel_Container2.BringToFront()
                Else
                    Patients.Parent = Panel_Container1
                    Container_Used = 1
                    Panel_Container1.Location = New Point(0, Default_Height)
                    Panel_Container1.BringToFront()
                End If

            End If

            Patients.Show()
            Patients.BringToFront()
        End If
    End Sub

    Private Sub secretaries_header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles secretaries_header.Click, Menu_Secretaries.Click
        If Not Selected_Menu_Index = 3 Then
            Previous_Selected_Menu_Index = Selected_Menu_Index
            Selected_Menu_Index = 3
            ReturnToStatePreviousSelected()
            Menu_Secretaries.ForeColor = Menu_Selected_Color_Text
            secretaries_header.BackColor = Menu_Selected_Color_Header
            secretary.MdiParent = Me
            If My.Settings.transition Then
                If Container_Used = 1 Then
                    secretary.Parent = Panel_Container2
                    Container_Used = 2
                    Panel_Container2.Location = New Point(Default_Width, Default_Height)
                    Timer_Transition1.Start()
                Else
                    secretary.Parent = Panel_Container1
                    Container_Used = 1
                    Panel_Container1.Location = New Point(Default_Width, Default_Height)
                    Timer_Transition2.Start()
                End If
            Else
                If Container_Used = 1 Then
                    secretary.Parent = Panel_Container2
                    Container_Used = 2
                    Panel_Container2.Location = New Point(0, Default_Height)
                    Panel_Container2.BringToFront()
                Else
                    secretary.Parent = Panel_Container1
                    Container_Used = 1
                    Panel_Container1.Location = New Point(0, Default_Height)
                    Panel_Container1.BringToFront()
                End If

            End If

            secretary.Show()
            secretary.BringToFront()
        End If
    End Sub

    Private Sub doctors_header_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Menu_Doctors.Click, doctors_header.Click
        If Not Selected_Menu_Index = 4 Then
            Previous_Selected_Menu_Index = Selected_Menu_Index
            Selected_Menu_Index = 4
            ReturnToStatePreviousSelected()
            Menu_Doctors.ForeColor = Menu_Selected_Color_Text
            doctors_header.BackColor = Menu_Selected_Color_Header
        End If
    End Sub

    Private Sub Form_Main_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        If ReadyToClose Then
            frm_login.Dispose()
        End If
    End Sub


    Private Sub Timer_Transition1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Transition1.Tick
        If Panel_Container2.Location.X > 0 Then
            Panel_Container1.Location = New Point(Transition_Control, Default_Height)
            Panel_Container2.Location = New Point(Default_Width + Transition_Control, Default_Height)
            Transition_Control = Transition_Control - 50
        Else
            Timer_Transition1.Stop()
            Transition_Control = 0
        End If
    End Sub

    Private Sub Timer_Transition2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Transition2.Tick
        If Panel_Container1.Location.X > 0 Then
            Panel_Container2.Location = New Point(Transition_Control, Default_Height)
            Panel_Container1.Location = New Point(Default_Width + Transition_Control, Default_Height)
            Transition_Control = Transition_Control - 50
        Else
            Timer_Transition2.Stop()
            Transition_Control = 0
        End If
    End Sub

    Private Sub chk_transition_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_transition.CheckedChanged
        If chk_transition.Checked = True Then
            My.Settings.transition = True
        Else
            My.Settings.transition = False
        End If
        My.Settings.Save()
    End Sub

    Private Sub ts_sign_out_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_sign_out.Click
        ReadyToClose = False
        frm_login.Show()
        Me.Dispose()
    End Sub

    Private Sub Panel2_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.MouseEnter, lbl_notification_counter.MouseEnter, Notification_counter_container.MouseEnter
        lbl_notif_context.Visible = True
    End Sub
    Private Sub Panel2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.MouseLeave, lbl_notification_counter.MouseLeave, Notification_counter_container.MouseLeave
        lbl_notif_context.Visible = False
    End Sub
    Private Sub Panel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click, lbl_notification_counter.Click, Notification_counter_container.Click
        Notification.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Helper_Download.get_appointments()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Helper_Upload.UPLOAD_PATIENT()
        Call Helper_Upload.UPLOAD_APPOINTMENTS()
    End Sub
End Class