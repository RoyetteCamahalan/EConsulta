Imports System.Data
Imports System.Data.SqlClient
Public Class new_consult
    Private rowindex As Integer
    Public appointment_id As Integer
    Private errormsg As String
    Public consult_id As Integer
    Public what_to_do As Integer
    Public doctor_id, patient_id As Integer
    Public complaints, findings, dateandtime, last_update As String
    Private from_update As Integer = 0
    Private from_update_ctr As Integer = 0
    Public title_text As String
    Public str_medicine_id As String = ""
#Region "Methods"
    Public Sub DisplayPatient()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action"}
            Dim Param_Value As String() = {2, 2}
            Dim MyAdapter As New Custom_Adapters
            With cmb_patients
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Patient", Param_Name, Param_Value)
                .ValueMember = "id"
                .DisplayMember = "Name"
                .SelectedIndex = -1
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DisplayDoctors()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@secretary_id", "@id"}
            Dim Param_Value As String()
            Dim MyAdapter As New Custom_Adapters
            If UserType = 0 Then
                Param_Value = {2, 1, UserId, ""}
                cmb_doctors.Enabled = True
            Else
                Param_Value = {2, 2, "", UserId}
                cmb_doctors.Enabled = False
            End If
            With cmb_doctors
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Doctors", Param_Name, Param_Value)
                .ValueMember = "id"
                .DisplayMember = "doctors_name"
                .SelectedIndex = -1
            End With
            If UserType = 1 Then
                cmb_doctors.SelectedValue = UserId
            End If
            'strquery = "SELECT `id`, `department_name`, `description` FROM `department`"
            'da = New SqlDataAdapter(strquery, conn)
            'da.Fill(ds, "departments")
            'With cmb_department
            '    .DataSource = ds.Tables("departments")
            '    .ValueMember = "id"
            '    .DisplayMember = "department_name"
            '    .SelectedIndex = -1
            'End With
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Variables"
    Private DT_Routes As New DataTable
    Private DT_Frequency As New DataTable
#End Region
    Private Sub new_consult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayPatient()
        DisplayDoctors()
        getfrequency_route()
        btn_saveastemplate.ForeColor = Color.Gray
        TabControl1.TabPages.Remove(ob_gyne)
        TabControl1.TabPages.Remove(pogs)
        TabControl1.TabPages.Remove(ob_pogs_table)
        TabControl1.TabPages.Remove(guardian_info)
        Me.Text = title_text
        If what_to_do = 1 Then
            btn_print_presciption.Visible = True
            ts_edit.Visible = True
            ts_close.Visible = True
            lbl_last_updated.Visible = True
            ts_cancel.Visible = False
            ts_save.Visible = False
            dtp_date.Visible = True
            lbl_date.Visible = True
            load_fields()
            disable_fields()
            load_treatments()
            Dim msg As String = ""
            If last_update = "" Then
                msg = "No Update since encoded :" + dateandtime
            Else
                Dim tempdate As Date = last_update
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
            End If
            lbl_last_updated.Text = msg
            validate_data()
        Else
            btn_new_treatment.Visible = True
            btn_addfromtemplate.Visible = True
            btn_saveastemplate.Visible = True
            dtgv_treatments.Columns(8).Visible = True
        End If
    End Sub
    Private Sub load_fields()
        dtp_date.Value = dateandtime
        cmb_patients.SelectedValue = patient_id
        cmb_doctors.SelectedValue = doctor_id
        txt_complaints.Text = complaints
        txt_findings.Text = findings
    End Sub
    Private Sub disable_fields()
        cmb_doctors.Enabled = False
        cmb_patients.Enabled = False
        txt_complaints.ReadOnly = True
        txt_findings.ReadOnly = True
        dtp_date.Enabled = False
        dtgv_treatments.ReadOnly = True
    End Sub
    Private Sub load_treatments()
        Try
            dtgv_treatments.Rows.Clear()
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@id"}
            Dim Param_Value As String() = {2, 5, consult_id}
            Dim MyAdapter As New Custom_Adapters
            Dim DT As New DataTable
            DT = MyAdapter.CUSTOM_RETRIEVE("SP_PatientRecord", Param_Name, Param_Value)
            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    dtgv_treatments.Rows.Add(DT.Rows(i).Item(1).ToString,
                                             DT.Rows(i).Item(2).ToString,
                                             DT.Rows(i).Item(3).ToString,
                                             DT.Rows(i).Item(4).ToString, "", "",
                                             DT.Rows(i).Item(7).ToString, "", "Remove")
                    Dim lastrow As Integer = dtgv_treatments.Rows.Count - 1
                    Dim chknogen As DataGridViewCheckBoxCell = dtgv_treatments.Rows(lastrow).Cells(2)
                    chknogen.Value = DT.Rows(i).Item(3)
                    Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(5)
                    cellfrequency.DataSource = DT_Frequency
                    cellfrequency.DisplayMember = "name"
                    cellfrequency.Value = DT.Rows(i).Item(6).ToString
                    'cellfrequency.ValueMember = "id"
                    Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(4)
                    cellroutes.DataSource = DT_Routes
                    cellroutes.DisplayMember = "name"
                    cellroutes.Value = DT.Rows(i).Item(5).ToString
                    'cellroutes.ValueMember = "id"
                    Dim cellduration As DataGridViewTextBoxCell = dtgv_treatments.Rows(lastrow).Cells(7)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        If what_to_do = 1 Then
            btn_new_treatment.Visible = False
            btn_addfromtemplate.Visible = False
            btn_saveastemplate.Visible = False
            dtgv_treatments.Columns(8).Visible = False
            btn_print_presciption.Visible = True
            ts_edit.Visible = True
            ts_close.Visible = True
            ts_cancel.Visible = False
            ts_save.Visible = False
            disable_fields()
            load_fields()
            load_treatments()
        Else
            Me.Dispose()
        End If
    End Sub
    Private Sub validate_data()
        Try
            If cmb_doctors.SelectedIndex >= 0 And cmb_patients.SelectedIndex >= 0 And Not (txt_complaints.Text = "" And txt_findings.Text = "") Then
                Dim checker As Boolean = False
                If dtgv_treatments.Rows.Count > 0 Then
                    For i As Integer = 0 To dtgv_treatments.RowCount - 1
                        If Not check_row(i) Then
                            checker = True
                        End If
                    Next
                End If
                If checker Then
                    ts_save.ForeColor = Color.Gray
                    errormsg = "Please Complete Prescription"
                Else
                    ts_save.ForeColor = Color.Black
                End If
            Else
                ts_save.ForeColor = Color.Gray
                errormsg = "Please Complete Details"
            End If
        Catch ex As Exception
            ts_save.ForeColor = Color.Gray
            errormsg = "Please Complete Prescription"
        End Try

    End Sub

    Private Sub cmb_patients_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_patients.SelectedValueChanged
        validate_data()
    End Sub

    Private Sub cmb_doctors_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_doctors.SelectedValueChanged
        validate_data()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_complaints.TextChanged
        validate_data()
    End Sub

    Private Sub txt_findings_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_findings.TextChanged
        validate_data()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If ts_save.ForeColor = Color.Gray Then
            MsgBox(errormsg)
        Else
            If what_to_do = 0 Or what_to_do = 2 Then
                Try
                    Dim Param_Name As String() = {"@action_type", "@sub_action", "@doctor_id", "@patient_id", "@clinic_id"}
                    Dim Param_Value As String() = {2, 1, cmb_doctors.SelectedValue, cmb_patients.SelectedValue, My.Settings.ClinicID}
                    Dim MyAdapter_Doctor_Patient As New Custom_Adapters
                    Dim MyAdapter_Patient_Record As New Custom_Adapters
                    If MyAdapter_Doctor_Patient.CUSTOM_TRANSACT_WITH_RETURN("SP_DoctorPatient", Param_Name, Param_Value) = 0 Then
                        Param_Name = {"@action_type", "@sub_action", "@doctor_id", "@patient_id", "@clinic_id", "@username", "@password"}
                        Param_Value = {2, 1, cmb_doctors.SelectedValue, cmb_patients.SelectedValue, My.Settings.ClinicID,
                                            randomuname("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"),
                                            randomuname("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz")}

                        MyAdapter_Doctor_Patient.CUSTOM_TRANSACT("SP_DoctorPatient", Param_Name, Param_Value)
                    End If
                    'insert new patient record
                    Param_Name = {"@action_type", "@sub_action", "@doctor_id", "@patient_id", "@complaints", "@findings", "@record_date"}
                    Param_Value = {0, 1, cmb_doctors.SelectedValue,
                                      cmb_patients.SelectedValue,
                                      txt_complaints.Text,
                                      txt_findings.Text,
                                      dtp_date.Value.ToLongTimeString}
                    Dim newID As Integer = MyAdapter_Patient_Record.CUSTOM_TRANSACT_WITH_RETURN("SP_PatientRecord", Param_Name, Param_Value)
                    If newID > 0 Then
                        If dtgv_treatments.Rows.Count > 0 And check_row(0) Then
                            Param_Name = {"@action_type", "@sub_action", "@id"}
                            Param_Value = {3, 1, consult_id}
                            MyAdapter_Patient_Record.CUSTOM_TRANSACT("SP_PatientRecord", Param_Name, Param_Value)
                            For i As Integer = 0 To dtgv_treatments.RowCount - 1
                                If check_row(i) Then
                                    Dim checknogen As DataGridViewCheckBoxCell = dtgv_treatments.Rows(i).Cells(2)
                                    Dim CheckNoGen_value As Integer
                                    If checknogen.Value = 1 Then
                                        CheckNoGen_value = 1
                                    Else
                                        CheckNoGen_value = 0
                                    End If
                                    Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(i).Cells(5)
                                    Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(i).Cells(4)
                                    Param_Name = {"@action_type", "@sub_action", "@id", "@medicine_id",
                                                  "@no_generics", "@quantity", "@route", "@frequency",
                                                  "@refills", "@duration", "@duration_type"}
                                    Param_Value = {0, 2, newID, dtgv_treatments.Rows(i).Cells(0).Value,
                                                      CheckNoGen_value, dtgv_treatments.Rows(i).Cells(3).Value.ToString, cellroutes.EditedFormattedValue.ToString, cellfrequency.EditedFormattedValue.ToString,
                                                      dtgv_treatments.Rows(i).Cells(6).Value.ToString, "2", "1"}
                                    MyAdapter_Patient_Record.CUSTOM_TRANSACT("SP_PatientRecord", Param_Name, Param_Value)
                                End If
                            Next
                        End If
                    End If

                    consult.DisplayRecords()
                    MsgBox("Consultation Saved", , "Consultation NOTIFICATION")
                    'from appointment
                    If what_to_do = 2 Then
                        Param_Name = {"@action_type", "@sub_action", "@id", "@is_done", "@patient_record_id"}
                        Param_Value = {1, 2, appointment_id, 1, newID}
                        MyAdapter_Patient_Record.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value)
                        today.DisplayAppointmentToday()
                        incoming.DisplayAppointmentIncoming()
                        Consultation.DisplayAppointmentsAll()
                        btn_new_treatment.Visible = False
                        btn_addfromtemplate.Visible = False
                        btn_saveastemplate.Visible = False
                    End If
                    Me.Dispose()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

            ElseIf what_to_do = 1 Then
                Try
                    Dim Param_Name As String() = {"@action_type", "@sub_action", "@doctor_id",
                                                  "@patient_id", "@complaints", "@findings", "@record_date", "@id"}
                    Dim Param_Value As String() = {1, 1, cmb_doctors.SelectedValue,
                                                   cmb_patients.SelectedValue, Me.txt_complaints.Text,
                                                   Me.txt_findings.Text, dtp_date.Value.ToLongTimeString, consult_id.ToString}
                    Dim MyAdapter_Patient_Record As New Custom_Adapters
                    If MyAdapter_Patient_Record.CUSTOM_TRANSACT("SP_PatientRecord", Param_Name, Param_Value) Then
                        Param_Name = {"@action_type", "@sub_action", "@id"}
                        Param_Value = {3, 1, consult_id}
                        MyAdapter_Patient_Record.CUSTOM_TRANSACT("SP_PatientRecord", Param_Name, Param_Value)
                        If dtgv_treatments.Rows.Count > 0 And check_row(0) Then
                            For i As Integer = 0 To dtgv_treatments.RowCount - 1
                                If check_row(i) Then
                                    Dim checknogen As DataGridViewCheckBoxCell = dtgv_treatments.Rows(i).Cells(2)
                                    Dim CheckNoGen_value As Integer
                                    If checknogen.Value = 1 Then
                                        CheckNoGen_value = 1
                                    Else
                                        CheckNoGen_value = 0
                                    End If
                                    Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(i).Cells(5)
                                    Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(i).Cells(4)
                                    Param_Name = {"@action_type", "@sub_action", "@id", "@medicine_id",
                                                  "@no_generics", "@quantity", "@route", "@frequency",
                                                  "@refills", "@duration", "@duration_type"}
                                    Param_Value = {0, 2, consult_id, dtgv_treatments.Rows(i).Cells(0).Value,
                                                      CheckNoGen_value, dtgv_treatments.Rows(i).Cells(3).Value.ToString, cellroutes.EditedFormattedValue.ToString, cellfrequency.EditedFormattedValue.ToString,
                                                      dtgv_treatments.Rows(i).Cells(6).Value.ToString, "2", "1"}
                                    MyAdapter_Patient_Record.CUSTOM_TRANSACT("SP_PatientRecord", Param_Name, Param_Value)
                                End If

                            Next
                        End If
                    End If

                    consult.DisplayRecords()
                    MsgBox("Update Saved", , "Consultation NOTIFICATION")
                    Me.Text = "View Consultation"
                    ts_edit.Visible = True
                    ts_close.Visible = True
                    ts_cancel.Visible = False
                    ts_save.Visible = False
                    disable_fields()
                    dtgv_treatments.Columns(8).Visible = False
                    timer_last_update.Start()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End If
        End If
    End Sub
    Private Function check_row(ByRef rowid As Integer) As Boolean
        If dtgv_treatments.Rows.Count > 0 Then
            If dtgv_treatments.Rows(rowid).Cells(3).Value.ToString = "0" Or dtgv_treatments.Rows(rowid).Cells(4).Value.ToString = "" Or dtgv_treatments.Rows(rowid).Cells(5).Value.ToString = "" Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub dtgv_treatments_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_treatments.CellEndEdit
        If e.ColumnIndex = 6 Or e.ColumnIndex = 3 Then
            If dtgv_treatments.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" Then
                dtgv_treatments.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "0"
            End If
        End If
        Dim checker As Boolean = False
        If dtgv_treatments.Rows.Count > 0 Then
            For i As Integer = 0 To dtgv_treatments.RowCount - 1
                If Not check_row(i) Then
                    checker = True
                End If
            Next
        End If
        If checker Then
            btn_saveastemplate.ForeColor = Color.Gray
        Else
            btn_saveastemplate.ForeColor = Color.Black
        End If
        validate_data()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        ts_edit.Visible = False
        ts_close.Visible = False
        btn_print_presciption.Visible = False
        dtgv_treatments.Columns(8).Visible = True
        btn_new_treatment.Visible = True
        btn_addfromtemplate.Visible = True
        btn_saveastemplate.Visible = True
        Me.Text = "Edit Consultation"
        ts_cancel.Visible = True
        ts_save.Visible = True
        cmb_doctors.Enabled = True
        cmb_patients.Enabled = True
        txt_complaints.ReadOnly = False
        txt_findings.ReadOnly = False
        dtp_date.Enabled = True
        dtgv_treatments.ReadOnly = False
    End Sub

    Private Sub btn_add_patient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_patient.Click
        New_Patient.ShowDialog()
    End Sub

    Private Sub timer_last_update_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_last_update.Tick
        If from_update_ctr < 60 Then
            from_update_ctr += 1
        Else
            from_update_ctr = 0
            from_update += 1
        End If
        If from_update < 1 Then
            lbl_last_updated.Text = "Updated a few seconds ago"
        Else
            lbl_last_updated.Text = "Updated " + from_update.ToString + " minute(s) ago"
        End If
    End Sub

    Private Sub new_consult_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        timer_last_update.Stop()
    End Sub
    Private Sub btn_new_treatment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_treatment.Click
        add_prescription.ShowDialog()
    End Sub

    Private Sub getfrequency_route()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action"}
            Dim Param_Value As String() = {2, 4}
            Dim MyAdapter_Frequency As New Custom_Adapters
            Dim MyAdapter_Routes As New Custom_Adapters
            DT_Frequency = MyAdapter_Frequency.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
            Param_Value = {2, 5}
            DT_Routes = MyAdapter_Routes.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgv_treatments_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dtgv_treatments.EditingControlShowing
        If dtgv_treatments.CurrentCellAddress.X = 5 Or dtgv_treatments.CurrentCellAddress.X = 4 Then
            Dim cb As ComboBox = e.Control
            If Not cb Is Nothing Then
                cb.DropDownStyle = ComboBoxStyle.DropDown
            End If

        End If
        If dtgv_treatments.CurrentCellAddress.X = 3 Or dtgv_treatments.CurrentCellAddress.X = 6 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TextBox_keyPress
        End If

    End Sub
    Private Sub TextBox_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub
    Public Sub add_med(ByVal medname As String, ByVal med_id As Integer)
        dtgv_treatments.Rows.Add(med_id, medname, False, "1", "", "", "0", "", "Remove")
        Dim lastrow As Integer = dtgv_treatments.Rows.Count - 1
        Dim chknogen As DataGridViewCheckBoxCell = dtgv_treatments.Rows(lastrow).Cells(2)
        chknogen.Value = 0
        Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(5)
        cellfrequency.DataSource = DT_Frequency
        cellfrequency.DisplayMember = "name"
        'cellfrequency.ValueMember = "id"
        Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(4)
        cellroutes.DataSource = DT_Routes
        cellroutes.DisplayMember = "name"
        'cellroutes.ValueMember = "id"
        Dim cellduration As DataGridViewTextBoxCell = dtgv_treatments.Rows(lastrow).Cells(7)
    End Sub

    Private Sub dtgv_treatments_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_treatments.CellContentClick
        Try
            If e.ColumnIndex = 8 Then
                Me.dtgv_treatments.Rows.RemoveAt(e.RowIndex)
            ElseIf e.ColumnIndex = 2 Then
                Dim checknogen As DataGridViewCheckBoxCell = dtgv_treatments.Rows(e.RowIndex).Cells(2)
                If checknogen.Value = checknogen.TrueValue Then
                    checknogen.Value = 0
                Else
                    checknogen.Value = 1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ts_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_close.Click
        Me.Dispose()
    End Sub

    Private Sub btn_saveastemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_saveastemplate.Click
        If dtgv_treatments.Rows.Count > 0 Then
            If btn_saveastemplate.ForeColor = Color.Gray Then
                MsgBox("Please fill all required Fields")
            Else
                Dim templatename As String = InputBox("Please Enter Template Name ", "Save as Template", "")
                If templatename = "" Then
                    MsgBox("Template name needed.")
                Else
                    Try
                        'insert new patient record
                        Dim Param_Name As String() = {"@action_type", "@sub_action", "@templatename"}
                        Dim Param_Value As String() = {2, 1, templatename}
                        Dim MyAdapter As New Custom_Adapters
                        Dim templateid As Integer = 0
                        templateid = MyAdapter.CUSTOM_TRANSACT_WITH_RETURN("SP_Miscellaneous", Param_Name, Param_Value)
                        If dtgv_treatments.Rows.Count > 1 Or check_row(0) Then
                            For i As Integer = 0 To dtgv_treatments.RowCount - 1
                                If check_row(i) Then
                                    Dim checknogen As DataGridViewCheckBoxCell = dtgv_treatments.Rows(i).Cells(2)
                                    Dim CheckNoGen_value As Integer
                                    If checknogen.Value = 1 Then
                                        CheckNoGen_value = 1
                                    Else
                                        CheckNoGen_value = 0
                                    End If
                                    Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(i).Cells(5)
                                    Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(i).Cells(4)
                                    Param_Name = {"@action_type", "@sub_action", "@id", "@medicine_id",
                                                  "@no_generics", "@quantity", "@route", "@frequency",
                                                  "@refills", "@duration", "@duration_type"}
                                    Param_Value = {0, 2, consult_id, dtgv_treatments.Rows(i).Cells(0).Value,
                                                      CheckNoGen_value, dtgv_treatments.Rows(i).Cells(3).Value.ToString, cellroutes.EditedFormattedValue.ToString, cellfrequency.EditedFormattedValue.ToString,
                                                      dtgv_treatments.Rows(i).Cells(6).Value.ToString, "2", "1"}
                                    MyAdapter.CUSTOM_TRANSACT("SP_PatientRecord", Param_Name, Param_Value)
                                End If
                            Next
                        End If

                    Catch ex As Exception
                        MsgBox(ex.ToString)
                    End Try
                End If
            End If

        Else
            MsgBox("No Item to save as template, add item/s and try again. Thank you!")
        End If

    End Sub

    Private Sub btn_addfromtemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addfromtemplate.Click
        select_treatment_template.ShowDialog()
    End Sub

    Private Sub cmb_department_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_department.SelectedValueChanged
        Try
            If cmb_department.SelectedValue = 3 Then
                If Not TabControl1.TabPages.Count = 1 Then
                    For i As Integer = TabControl1.TabPages.Count - 1 To 1 Step -1
                        TabControl1.TabPages.RemoveAt(i)
                    Next
                End If

                TabControl1.TabPages.Add(ob_gyne)
                TabControl1.TabPages.Add(pogs)
                TabControl1.TabPages.Add(ob_pogs_table)
            ElseIf cmb_department.SelectedValue = 6 Then
                If Not TabControl1.TabPages.Count = 1 Then
                    For i As Integer = TabControl1.TabPages.Count - 1 To 1 Step -1
                        TabControl1.TabPages.RemoveAt(i)
                    Next
                End If
                TabControl1.TabPages.Add(guardian_info)
            Else
                If Not TabControl1.TabPages.Count = 1 Then
                    For i As Integer = TabControl1.TabPages.Count - 1 To 1 Step -1
                        TabControl1.TabPages.RemoveAt(i)
                    Next
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Function randomuname(ByRef validchars As String) As String

        Dim sb As New System.Text.StringBuilder
        Dim rand As New Random()
        For i As Integer = 1 To 6
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i

        Return sb.ToString()
    End Function

    Private Sub btn_print_presciption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_print_presciption.Click
        prescription.ShowDialog()
    End Sub
End Class
