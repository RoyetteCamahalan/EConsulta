Public Class Notification
    Dim txbtnControl As New TextAndButtonControl
    Dim btnaccept As New userbtnAccept
#Region "Methods"
    Private Sub GetNotifs()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@search", "@secretary_id", "@doctor_id"}
            Dim Param_Value As String()
            Dim MyAdapter As New Custom_Adapters
            Dim DT As New DataTable
            If UserType = 0 Then 'secretary
                Param_Value = {2, 5, "", UserId, ""}
            Else 'doctor
                Param_Value = {2, 6, "", "", UserId}
            End If
            DT = MyAdapter.CUSTOM_RETRIEVE("SP_Consultation", Param_Name, Param_Value)
            For i As Integer = 0 To DT.Rows.Count - 1
                Dim server_id As Integer = DT.Rows(i).Item(0)
                Dim clinic_name As String = DT.Rows(i).Item(1).ToString
                Dim doctor_name As String = DT.Rows(i).Item(2).ToString
                Dim patient_name As String = DT.Rows(i).Item(3).ToString
                Dim sched_date As String = Convert.ToDateTime(DT.Rows(i).Item(4)).ToShortDateString
                Dim sched_time As String = DT.Rows(i).Item(5).ToString
                Dim sched As String = ""
                If Not sched_time = "" Then
                    sched = Convert.ToDateTime(sched_date + " " + sched_time).ToShortTimeString
                End If

                Dim comment_doctor As String = DT.Rows(i).Item(6).ToString
                Dim comment_patient As String = DT.Rows(i).Item(7).ToString
                Dim is_approved_patient As Integer = DT.Rows(i).Item(8)
                Dim patient_acceptance As String = ""
                If is_approved_patient = 0 Then
                    patient_acceptance = " Pending "
                ElseIf is_approved_patient = 1 Then
                    patient_acceptance = " Accepted "
                ElseIf is_approved_patient = 2 Then
                    patient_acceptance = " Cancelled "
                End If
                Dim is_approved As Integer = DT.Rows(i).Item(9)
                dtgcv_notifs.Rows.Add(server_id, clinic_name, doctor_name, patient_name, sched_date, sched, comment_doctor, comment_patient, patient_acceptance, "")
                If is_approved = 0 Then
                    no_response_col(i)
                Else
                    response_col(i, is_approved)
                End If
                If is_approved_patient = 0 Then
                    dtgcv_notifs.Rows(i).Cells(8).Style.ForeColor = Color.Red
                ElseIf is_approved_patient = 1 Then
                    dtgcv_notifs.Rows(i).Cells(8).Style.ForeColor = Color.Green
                ElseIf is_approved_patient = 2 Then
                    patient_acceptance = " Cancelled "
                End If

            Next

        Catch ex As Exception

        End Try
    End Sub
#End Region
    Private Sub Notification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtgcv_notifs.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        btnaccept.Visible = False

        txbtnControl.Visible = False
        GetNotifs()
    End Sub
    Private Sub no_response_col(ByVal row_index As Integer)
        Dim rect As Rectangle = Me.dtgcv_notifs.GetCellDisplayRectangle(9, row_index, True)
        Dim txttxbtnControl2 As New TextAndButtonControl
        dtgcv_notifs.Controls.Add(txttxbtnControl2)
        txttxbtnControl2.Name = "usercontrol" + row_index.ToString
        txttxbtnControl2.btn_accept.Tag = row_index.ToString
        txttxbtnControl2.btn_decline.Tag = row_index.ToString
        txttxbtnControl2.Location = rect.Location
        txttxbtnControl2.Size = rect.Size
        txttxbtnControl2.renderControl()
        txttxbtnControl2.Visible = True
    End Sub
    Private Sub response_col(ByVal row_index As Integer, ByRef is_approved As Integer)
        Dim rect As Rectangle = Me.dtgcv_notifs.GetCellDisplayRectangle(9, row_index, True)
        Dim txttxbtnControl2 As New userbtnAccept
        txttxbtnControl2.Name = "usercontrol" + row_index.ToString
        dtgcv_notifs.Controls.Add(txttxbtnControl2)
        txttxbtnControl2.Location = rect.Location
        txttxbtnControl2.Size = rect.Size
        If is_approved = 1 Then
            txttxbtnControl2.Button1.Text = "Accepted"
            txttxbtnControl2.Button1.BackColor = Color.LimeGreen
        Else
            txttxbtnControl2.Button1.Text = "Declined"
            txttxbtnControl2.Button1.BackColor = Color.Red
        End If
        txttxbtnControl2.Button1.Tag = row_index.ToString
        txttxbtnControl2.renderControl()
        txttxbtnControl2.Visible = True
    End Sub
    
    Public Sub accept(ByRef rowindex As Integer, ByRef t As Date, ByRef comment As String)
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@comment_doctor", "@is_approved_doctor", "@consult_time", "@server_id"}
            Dim Param_Value As String() = {1, 4, comment, 1, t.TimeOfDay.ToString, dtgcv_notifs.Rows(rowindex).Cells(0).Value}
            Dim MyAdapter As New Custom_Adapters
            If MyAdapter.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value) Then
                MsgBox("Saved")
                dtgcv_notifs.Controls.RemoveByKey("usercontrol" + rowindex.ToString)
                dtgcv_notifs.Rows(rowindex).Cells(5).Value = t.ToShortTimeString
                response_col(rowindex, 1)
                Dim notif_count As Integer = Convert.ToInt32(main_menu.notification_label.Text) - 1
                If Not notif_count = 0 Then
                    main_menu.notification_label.Text = notif_count.ToString
                Else
                    main_menu.notification_label.Text = ""
                End If
                DisplayNotificationCount()
            Else
                MsgBox("Failed")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub decline(ByRef rowindex As Integer, ByRef comment As String)
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@comment_doctor", "@is_approved_doctor", "@server_id"}
            Dim Param_Value As String() = {1, 4, comment, 2, dtgcv_notifs.Rows(rowindex).Cells(0).Value}
            Dim MyAdapter As New Custom_Adapters
            If MyAdapter.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value) Then
                MsgBox("Saved")
                dtgcv_notifs.Controls.RemoveByKey("usercontrol" + rowindex.ToString)
                response_col(rowindex, 2)
                Dim notif_count As Integer = Convert.ToInt32(main_menu.notification_label.Text) - 1
                If Not notif_count = 0 Then
                    main_menu.notification_label.Text = notif_count.ToString
                Else
                    main_menu.notification_label.Text = ""
                End If
                DisplayNotificationCount()
            Else
                MsgBox("Failed")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Notification_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class
