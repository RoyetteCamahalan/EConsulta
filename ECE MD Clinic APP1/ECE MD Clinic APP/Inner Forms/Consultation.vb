Public Class Consultation
#Region "Methods"
    Public Sub DisplayAppointmentsAll()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@search", "@secretary_id", "@doctor_id"}
            Dim Param_Value As String()
            Dim MyAdapter As New Custom_Adapters
            If UserType = 0 Then 'secretary
                Param_Value = {2, 1, GetSearchString(), UserId, 0}
            Else
                Param_Value = {2, 2, GetSearchString(), 0, UserId}
            End If
            With dtgv_allappointment
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Consultation", Param_Name, Param_Value)
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(4).Visible = False
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Function GetSearchString()
        If txt_search.Text = Search_Hint_Patient Or txt_search.Text.Length = 0 Then
            Return ""
        End If
        Return txt_search.Text
    End Function
#End Region
#Region "Variables"
    Dim w As Integer = 221
    Dim h As Integer = 99
    Private ButtonColumn As Integer = 8
#End Region
    Private Sub Consultation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_allappointment.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_allappointment.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_allappointment.RowTemplate.Height = Default_Row_Height
        dtgv_allappointment.Columns(ButtonColumn).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.Size = New System.Drawing.Size(w, h)
        Timer1.Start()
        txt_search.Text = Search_Hint_Patient

    End Sub
#Region "entrance and exit"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '1121, 519
        '273, 231
        w = w + 90
        h = h + 42
        If w <= 1121 Then
            Me.Size = New System.Drawing.Size(w, h)
        Else
            Timer1.Stop()
            w = 221
            h = 99
        End If
    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        txt_search.Clear()
    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not (txt_search.Text = Search_Hint_Patient) Then
            DisplayAppointmentsAll()
        End If
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = Search_Hint_Patient
        End If
    End Sub
#End Region
    

    Private Sub dtgv_allappointment_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_allappointment.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If (myCol = ButtonColumn Or myCol = 2) And myRow <> -1 Then
                dtgv_allappointment.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Underline)
                dtgv_allappointment.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_allappointment.Cursor = Cursors.Hand
                dtgv_allappointment.Rows(myRow).DefaultCellStyle.BackColor = Color.LightBlue
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtgv_allappointment_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_allappointment.CellMouseLeave
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If (myCol = ButtonColumn Or myCol = 2) And myRow <> -1 Then
                dtgv_allappointment.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Modern No. 20", 12, FontStyle.Regular)
                dtgv_allappointment.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_allappointment.Cursor = Cursors.Arrow
                dtgv_allappointment.Rows(myRow).DefaultCellStyle.BackColor = Color.White
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtgv_allappointment_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgv_allappointment.MouseMove
        Try
            Dim hit As DataGridView.HitTestInfo = dtgv_allappointment.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                Dim myRow As Integer = hit.RowIndex
                Dim myCol As Integer = hit.ColumnIndex
                If (myCol <> ButtonColumn Or myCol <> 2) And myRow <> -1 And Not dtgv_allappointment.Rows(myRow).Cells(10).Value.ToString = "" Then
                    Dim tempdate As Date = dtgv_allappointment.Rows(myRow).Cells(10).Value
                    Dim msg As String = ""
                    Dim duration As TimeSpan = Now() - tempdate
                    Dim days As Integer = DateDiff(DateInterval.Day, tempdate.Date, Now.Date())
                    If tempdate.Date = Now.Date() Then
                        If duration.Hours > 0 Then
                            If duration.Hours = 1 Then
                                msg = "Updated " + duration.Hours.ToString + " hr ago"
                            Else
                                msg = "Updated " + duration.Hours.ToString + " hrs ago"
                            End If
                        Else
                            msg = "Updated " + duration.Minutes.ToString + " mins ago"
                        End If
                    ElseIf tempdate.Date < Now.Date() Then
                        If days = 1 Then
                            msg = "Updated Yesterday, " + tempdate.ToString("t")
                        Else
                            msg = "Updated " + days.ToString + " days ago"
                        End If

                    End If
                    dtgv_allappointment.Rows(myRow).Cells(myCol).ToolTipText = msg
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgv_allappointment_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_allappointment.CellClick
        Try
            Dim myRow As Integer = dtgv_allappointment.CurrentRow.Index
            Dim myCol As Integer = dtgv_allappointment.CurrentCell.ColumnIndex
            If myCol = ButtonColumn And myRow <> -1 Then
                If dtgv_allappointment.Rows(myRow).Cells(8).Value.ToString = "Done" Then
                    Try
                        Dim DT As New DataTable
                        Dim Param_Name As String() = {"@action_type", "@sub_action"}
                        Dim Param_Value As String() = {2, 4}
                        Dim MyAdapter As New Custom_Adapters
                        DT = MyAdapter.CUSTOM_RETRIEVE("SP_PatientRecord", Param_Name, Param_Value)
                        If DT.Rows.Count > 0 Then
                            new_consult.what_to_do = 1
                            new_consult.title_text = "View Consultation"
                            new_consult.appointment_id = DT.Rows(0).Item(0)
                            new_consult.doctor_id = DT.Rows(0).Item(2).ToString
                            new_consult.patient_id = DT.Rows(0).Item(1).ToString
                            new_consult.complaints = DT.Rows(0).Item(3).ToString
                            new_consult.findings = DT.Rows(0).Item(4).ToString
                            new_consult.dateandtime = DT.Rows(0).Item(5).ToString
                            new_consult.last_update = DT.Rows(0).Item(6).ToString
                            new_consult.consult_id = dtgv_allappointment.CurrentRow.Cells(10).Value
                            new_consult.ShowDialog()
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    If dtgv_allappointment.Rows(myRow).Cells(8).Value.ToString = "Pending" Then
                        context_options.Items(0).Visible = False
                        context_options.Items(1).Visible = True
                        context_options.Items(2).Visible = True
                        context_options.Items(3).Visible = True
                        context_options.Items(4).Visible = False
                        context_options.Items(5).Visible = False
                    Else
                        context_options.Items(0).Visible = False
                        context_options.Items(1).Visible = False
                        context_options.Items(2).Visible = True
                        context_options.Items(3).Visible = False
                        context_options.Items(4).Visible = True
                        context_options.Items(5).Visible = False
                    End If
                    context_options.Show(Control.MousePosition)
                End If
            ElseIf myCol = 2 And myRow <> -1 Then
                Dim viewpatient As New View_patient
                viewpatient.patient_id = dtgv_allappointment.CurrentRow.Cells(1).Value
                viewpatient.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Consult_now_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Consult_now.Click
        Dim consult_now As New new_consult
        consult_now.what_to_do = 2
        consult_now.appointment_id = dtgv_allappointment.CurrentRow.Cells(0).Value
        consult_now.Show()
        consult_now.cmb_patients.SelectedValue = dtgv_allappointment.CurrentRow.Cells(1).Value
        consult_now.cmb_doctors.SelectedValue = dtgv_allappointment.CurrentRow.Cells(4).Value
        consult_now.cmb_doctors.Enabled = False
        consult_now.cmb_patients.Enabled = False
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        New_Consultation.patient_id = dtgv_allappointment.CurrentRow.Cells(1).Value
        New_Consultation.doctor_id = dtgv_allappointment.CurrentRow.Cells(4).Value
        New_Consultation.consult_date = dtgv_allappointment.CurrentRow.Cells(3).Value
        New_Consultation.comment = dtgv_allappointment.CurrentRow.Cells(6).Value
        New_Consultation.consult_id = dtgv_allappointment.CurrentRow.Cells(0).Value
        New_Consultation.what_to_do = 1
        New_Consultation.ShowDialog()
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to POSTPONE this schedule?", MsgBoxStyle.YesNo, "Postpone Schedule")
        If res = MsgBoxResult.Yes Then
            Try
                Dim Param_Name As String() = {"@action_type", "@sub_action", "@is_done"}
                Dim Param_Value As String() = {1, 1, 2}
                Dim MyAdapter As New Custom_Adapters
                If MyAdapter.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value) Then
                    dtgv_allappointment.CurrentRow.Cells(8).Value = "Postponed"
                    dtgv_allappointment.CurrentRow.Cells(10).Value = Now().ToString
                    today.DisplayAppointmentToday()
                    incoming.DisplayAppointmentIncoming()
                Else
                    MsgBox("Failed")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub unpostpone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unpostpone.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to UNPOSTPONE this schedule?", MsgBoxStyle.YesNo, "Unpostpone Schedule")
        If res = MsgBoxResult.Yes Then
            Try
                Dim Param_Name As String() = {"@action_type", "@sub_action", "@is_done"}
                Dim Param_Value As String() = {1, 1, 0}
                Dim MyAdapter As New Custom_Adapters
                If MyAdapter.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value) Then
                    dtgv_allappointment.CurrentRow.Cells(8).Value = "Pending"
                    dtgv_allappointment.CurrentRow.Cells(10).Value = Now().ToString
                    today.DisplayAppointmentToday()
                    incoming.DisplayAppointmentIncoming()
                Else
                    MsgBox("Failed")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class