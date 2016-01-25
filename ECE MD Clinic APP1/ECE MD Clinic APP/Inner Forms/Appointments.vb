Public Class Appointments
#Region "Variables"
    Private ButtonColumn As Integer = 8
#End Region

#Region "Methods"
    Public Sub DisplayAppointments()
        Dim Param_Name As String() = {"@action_type", "@sub_action", "@search", "@secretary_id", "@doctor_id", "@is_done"}
        Dim Param_Value As String() = GetFilter()
        Dim MyAdapter As New Custom_Adapters
        With dtgv_Appointments
            .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Consultation", Param_Name, Param_Value)
            .Columns(1).Visible = False
            .Columns(4).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(ButtonColumn).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

    End Sub
    Private Function GetSearchString()
        If txt_search.Text = Search_Hint Or txt_search.Text.Length = 0 Then
            Return ""
        End If
        Return txt_search.Text
    End Function
    Private Function GetFilter() As String()
        Dim Param_Value As String()
        If UserType = 0 Then
            Select Case cmn_filter_by.SelectedIndex
                Case 1
                    Param_Value = {2, 1, GetSearchString(), UserId, "", 0}
                Case 2
                    Param_Value = {2, 9, GetSearchString(), UserId, "", 1}
                Case 3
                    Param_Value = {2, 9, GetSearchString(), UserId, "", 0}
                Case 4
                    Param_Value = {2, 9, GetSearchString(), UserId, "", 2}
                Case Else
                    Param_Value = {2, 7, GetSearchString(), UserId, "", 0}
            End Select
        Else
            Select Case cmn_filter_by.SelectedIndex
                Case 1
                    Param_Value = {2, 2, GetSearchString(), "", UserId, 0}
                Case 2
                    Param_Value = {2, 10, GetSearchString(), "", UserId, 1}
                Case 3
                    Param_Value = {2, 10, GetSearchString(), "", UserId, 0}
                Case 4
                    Param_Value = {2, 10, GetSearchString(), "", UserId, 2}
                Case Else
                    Param_Value = {2, 8, GetSearchString(), "", UserId, 0}
            End Select
        End If

        Return Param_Value
    End Function
#End Region
    Private Sub Appointments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        dtgv_Appointments.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_Appointments.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_Appointments.RowTemplate.Height = Default_Row_Height
        txt_search.Text = Search_Hint
        cmn_filter_by.SelectedIndex = 1
    End Sub

    Private Sub cmn_filter_by_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmn_filter_by.SelectedIndexChanged
        DisplayAppointments()
    End Sub
    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        If txt_search.Text = Search_Hint Then
            txt_search.Text = ""
            txt_search.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = Search_Hint
            txt_search.ForeColor = Color.Gray
        End If
    End Sub
    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not txt_search.Text = Search_Hint Then
            DisplayAppointments()
        End If
    End Sub
    Private Sub dtgv_Appointments_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_Appointments.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = ButtonColumn And myRow <> -1 Then
                dtgv_Appointments.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Microsoft Sans Serif", 9, FontStyle.Underline)
                dtgv_Appointments.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_Appointments.Cursor = Cursors.Hand
                dtgv_Appointments.Rows(myRow).DefaultCellStyle.BackColor = Color.LightBlue
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtgv_Appointments_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_Appointments.CellMouseLeave
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = ButtonColumn And myRow <> -1 Then
                dtgv_Appointments.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Microsoft Sans Serif", 8.5, FontStyle.Regular)
                dtgv_Appointments.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_Appointments.Rows(myRow).DefaultCellStyle.BackColor = Color.White
                dtgv_Appointments.Cursor = Cursors.Arrow
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btn_new_appoinment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_appoinment.Click
        New_Consultation.what_to_do = 0
        New_Consultation.ShowDialog()
    End Sub
    Private Sub dtgv_Appointments_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_Appointments.CellClick
        Try
            Dim myRow As Integer = dtgv_Appointments.CurrentRow.Index
            Dim myCol As Integer = dtgv_Appointments.CurrentCell.ColumnIndex
            If myCol = ButtonColumn And myRow <> -1 Then
                If dtgv_Appointments.Rows(myRow).Cells(7).Value.ToString = "Done" Then
                    Try
                        Dim DT As New DataTable
                        Dim Param_Name As String() = {"@action_type", "@sub_action", "@id"}
                        Dim Param_Value As String() = {2, 4, dtgv_Appointments.CurrentRow.Cells(10).Value}
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
                            new_consult.consult_id = dtgv_Appointments.CurrentRow.Cells(10).Value
                            new_consult.ShowDialog()
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    If dtgv_Appointments.Rows(myRow).Cells(7).Value.ToString = "Pending" Then
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
                viewpatient.patient_id = dtgv_Appointments.CurrentRow.Cells(1).Value
                viewpatient.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Consult_now_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Consult_now.Click
        new_consult.what_to_do = 2
        new_consult.appointment_id = dtgv_Appointments.CurrentRow.Cells(0).Value
        new_consult.Show()
        new_consult.cmb_patients.SelectedValue = dtgv_Appointments.CurrentRow.Cells(1).Value
        new_consult.cmb_doctors.SelectedValue = dtgv_Appointments.CurrentRow.Cells(4).Value
        new_consult.cmb_doctors.Enabled = False
        new_consult.cmb_patients.Enabled = False
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        New_Consultation.patient_id = dtgv_Appointments.CurrentRow.Cells(1).Value
        New_Consultation.doctor_id = dtgv_Appointments.CurrentRow.Cells(4).Value
        New_Consultation.consult_date = dtgv_Appointments.CurrentRow.Cells(3).Value
        New_Consultation.comment = dtgv_Appointments.CurrentRow.Cells(11).Value
        New_Consultation.consult_id = dtgv_Appointments.CurrentRow.Cells(0).Value
        New_Consultation.what_to_do = 1
        New_Consultation.ShowDialog()
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to POSTPONE this schedule?", MsgBoxStyle.YesNo, "Postpone Schedule")
        If res = MsgBoxResult.Yes Then
            Try
                Dim Param_Name As String() = {"@action_type", "@sub_action", "@is_done", "@id"}
                Dim Param_Value As String() = {1, 1, 2, dtgv_Appointments.CurrentRow.Cells(0).Value}
                Dim MyAdapter As New Custom_Adapters
                If MyAdapter.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value) Then
                    dtgv_Appointments.CurrentRow.Cells(7).Value = "Postponed"
                    dtgv_Appointments.CurrentRow.Cells(9).Value = Now().ToString
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
                Dim Param_Name As String() = {"@action_type", "@sub_action", "@is_done", "@id"}
                Dim Param_Value As String() = {1, 1, 0, dtgv_Appointments.CurrentRow.Cells(0).Value}
                Dim MyAdapter As New Custom_Adapters
                If MyAdapter.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value) Then
                    dtgv_Appointments.CurrentRow.Cells(7).Value = "Pending"
                    dtgv_Appointments.CurrentRow.Cells(9).Value = Now().ToString
                Else
                    MsgBox("Failed")
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class