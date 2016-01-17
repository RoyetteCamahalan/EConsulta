Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class new_consult
    Private da As New MySqlDataAdapter
    Private cmd As New MySqlCommand
    Private ds As New DataSet
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
    Private Sub new_consult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display_patient()
        display_doctors()
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
            Dim dstreatment As New DataSet
            dtgv_treatments.Rows.Clear()
            da = New MySqlDataAdapter("SELECT pi.`patient_record_id`,pi.`medicine_id`, m.`med_name`,pi.no_generics,pi.quantity, `route`, `frequency`, `refills` FROM medicines m inner join prescription_items pi on m.id=pi.medicine_id where patient_record_id=" + consult_id.ToString, conn)
            da.Fill(dstreatment, "treatments")
            If dstreatment.Tables("treatments").Rows.Count > 0 Then
                For i As Integer = 0 To dstreatment.Tables("treatments").Rows.Count - 1
                    dtgv_treatments.Rows.Add(dstreatment.Tables("treatments").Rows(i).Item(1).ToString, dstreatment.Tables("treatments").Rows(i).Item(2).ToString, dstreatment.Tables("treatments").Rows(i).Item(3).ToString, dstreatment.Tables("treatments").Rows(i).Item(4).ToString, "", "", dstreatment.Tables("treatments").Rows(i).Item(7).ToString, "", "Remove")
                    Dim lastrow As Integer = dtgv_treatments.Rows.Count - 1
                    Dim chknogen As DataGridViewCheckBoxCell = dtgv_treatments.Rows(lastrow).Cells(2)
                    chknogen.Value = dstreatment.Tables("treatments").Rows(i).Item(3)
                    Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(5)
                    cellfrequency.DataSource = ds.Tables("frequency")
                    cellfrequency.DisplayMember = "name"
                    cellfrequency.Value = dstreatment.Tables("treatments").Rows(i).Item(6).ToString
                    'cellfrequency.ValueMember = "id"
                    Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(4)
                    cellroutes.DataSource = ds.Tables("routes")
                    cellroutes.DisplayMember = "name"
                    cellroutes.Value = dstreatment.Tables("treatments").Rows(i).Item(5).ToString
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

    Public Sub display_patient()
        Try
            da = New MySqlDataAdapter("select id,concat(fname,' ',mname,' ',lname) as Name from patients", conn)
            da.Fill(ds, "patients")
            With cmb_patients
                .DataSource = ds.Tables("patients")
                .ValueMember = "id"
                .DisplayMember = "Name"
                .SelectedIndex = -1
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub display_doctors()
        Try
            Dim strquery As String
            If UserType = 0 Then
                strquery = "select d.id,concat(d.`fname`,' ',d.`mname`,' ',d.`lname`)as doctors_name from doctors d INNER JOIN secretary_access sc on sc.doctor_id=d.id WHERE sc.secretary_id=" + UserId.ToString
                cmb_doctors.Enabled = True
            Else
                strquery = "select id,concat(`fname`,' ',`mname`,' ',`lname`)as doctors_name from doctors where id=" + UserId.ToString
                cmb_doctors.Enabled = False
            End If
            da = New MySqlDataAdapter(strquery, conn)
            da.Fill(ds, "doctors")

            With cmb_doctors
                .DataSource = ds.Tables("doctors")
                .ValueMember = "id"
                .DisplayMember = "doctors_name"
                .SelectedIndex = -1
            End With
            If UserType = 1 Then
                cmb_doctors.SelectedValue = UserId
            End If
            strquery = "SELECT `id`, `department_name`, `description` FROM `department`"
            da = New MySqlDataAdapter(strquery, conn)
            da.Fill(ds, "departments")
            With cmb_department
                .DataSource = ds.Tables("departments")
                .ValueMember = "id"
                .DisplayMember = "department_name"
                .SelectedIndex = -1
            End With
        Catch ex As Exception

        End Try
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
                Dim treatment_id As Integer
                Try
                    Dim insert_sql As String
                    da = New MySqlDataAdapter("select * from `doctor_patient` where `doctor_id`=" + cmb_doctors.SelectedValue.ToString + " and `patient_id`=" + cmb_patients.SelectedValue.ToString + " and `clinic_id`=" + My.Settings.ClinicID.ToString, conn)
                    da.Fill(ds, "checker")
                    If ds.Tables("checker").Rows.Count = 0 Then
                        insert_sql = String.Format("INSERT INTO `doctor_patient`(`clinic_id`, `doctor_id`, `patient_id`, `username`, `password`) VALUES ({0},{1},{2},'{3}','{4}')",
                                                                         My.Settings.ClinicID.ToString, cmb_doctors.SelectedValue.ToString, cmb_patients.SelectedValue.ToString, randomuname("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"), randomuname("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz"))

                        cmd = New MySqlCommand(insert_sql, conn)
                        cmd.ExecuteNonQuery()
                    End If
                    'insert new patient record
                    cmd = New MySqlCommand("INSERT INTO `patient_records`( `patient_id`, `doctor_id`, `complaints`, `findings`, `created_at`) VALUES (@patientid,@doctorid,@complaints,@findings,CURRENT_TIMESTAMP)", conn)
                    cmd.Parameters.AddWithValue("patientid", cmb_patients.SelectedValue.ToString)
                    cmd.Parameters.AddWithValue("doctorid", cmb_doctors.SelectedValue.ToString)
                    cmd.Parameters.AddWithValue("complaints", txt_complaints.Text)
                    cmd.Parameters.AddWithValue("findings", txt_findings.Text)
                    cmd.ExecuteNonQuery()
                    da = New MySqlDataAdapter("select max(id) from patient_records", conn)
                    da.Fill(ds, "id")
                    treatment_id = ds.Tables("id").Rows(0).Item(0)
                    If dtgv_treatments.Rows.Count > 0 And check_row(0) Then
                        For i As Integer = 0 To dtgv_treatments.RowCount - 1
                            If check_row(i) Then
                                cmd = New MySqlCommand("INSERT INTO `prescription_items`(`patient_record_id`, `medicine_id`, `no_generics`, `quantity`, `route`, `frequency`, `refills`, `duration`, `duration_type`) " +
                                                       "VALUES (@patient_record_id,@medicine_id,@no_generics,@quantity,@route,@frequency,@refills,@duration,@duration_type)", conn)
                                cmd.Parameters.AddWithValue("patient_record_id", treatment_id.ToString)
                                cmd.Parameters.AddWithValue("medicine_id", dtgv_treatments.Rows(i).Cells(0).Value.ToString)
                                cmd.Parameters.AddWithValue("no_generics", dtgv_treatments.Rows(i).Cells(2).Value.ToString)
                                cmd.Parameters.AddWithValue("quantity", dtgv_treatments.Rows(i).Cells(3).Value.ToString)
                                cmd.Parameters.AddWithValue("route", dtgv_treatments.Rows(i).Cells(4).Value.ToString)
                                cmd.Parameters.AddWithValue("frequency", dtgv_treatments.Rows(i).Cells(5).Value.ToString)
                                cmd.Parameters.AddWithValue("refills", dtgv_treatments.Rows(i).Cells(6).Value.ToString)
                                cmd.Parameters.AddWithValue("duration", "2")
                                cmd.Parameters.AddWithValue("duration_type", "1")
                                cmd.ExecuteNonQuery()
                            End If
                        Next
                    End If
                    consult.display_records("")
                    MsgBox("Consultation Saved", , "Consultation NOTIFICATION")
                    'from appointment
                    If what_to_do = 2 Then
                        Dim update_sql As String = "UPDATE `patient_consultations` SET isdone=1,patient_record_id=" + treatment_id.ToString + " where id=" + appointment_id.ToString
                        cmd = New MySqlCommand(update_sql, conn)
                        cmd.ExecuteNonQuery()
                        today.display_today("")
                        incoming.display_incoming("")
                        Consultation.display_all("")
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
                    cmd = New MySqlCommand("UPDATE `patient_records` SET `patient_id`=@patientid,`doctor_id`=@doctorid,`complaints`=@complaints,`findings`=@findings,`updated_at`=CURRENT_TIMESTAMP where id=@id", conn)
                    cmd.Parameters.AddWithValue("patientid", cmb_patients.SelectedValue.ToString)
                    cmd.Parameters.AddWithValue("doctorid", cmb_doctors.SelectedValue.ToString)
                    cmd.Parameters.AddWithValue("complaints", txt_complaints.Text)
                    cmd.Parameters.AddWithValue("findings", txt_findings.Text)
                    cmd.Parameters.AddWithValue("id", consult_id.ToString)
                    cmd.ExecuteNonQuery()
                    If dtgv_treatments.Rows.Count > 0 And check_row(0) Then
                        Dim update_sql2 As String = String.Format("delete from `prescription_items` where patient_record_id=" + consult_id.ToString)
                        cmd = New MySqlCommand(update_sql2, conn)
                        cmd.ExecuteNonQuery()
                        For i As Integer = 0 To dtgv_treatments.RowCount - 1
                            If check_row(i) Then
                                cmd = New MySqlCommand("INSERT INTO `prescription_items`(`patient_record_id`, `medicine_id`, `no_generics`, `quantity`, `route`, `frequency`, `refills`, `duration`, `duration_type`) " +
                                                       "VALUES (@patient_record_id,@medicine_id,@no_generics,@quantity,@route,@frequency,@refills,@duration,@duration_type)", conn)
                                cmd.Parameters.AddWithValue("patient_record_id", consult_id.ToString)
                                cmd.Parameters.AddWithValue("medicine_id", dtgv_treatments.Rows(i).Cells(0).Value.ToString)
                                Dim checknogen As DataGridViewCheckBoxCell = dtgv_treatments.Rows(i).Cells(2)
                                If checknogen.Value = 1 Then
                                    cmd.Parameters.AddWithValue("no_generics", "1")
                                Else
                                    cmd.Parameters.AddWithValue("no_generics", "0")
                                End If

                                cmd.Parameters.AddWithValue("quantity", dtgv_treatments.Rows(i).Cells(3).Value.ToString)
                                Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(i).Cells(5)
                                Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(i).Cells(4)
                                cmd.Parameters.AddWithValue("route", cellroutes.EditedFormattedValue.ToString)
                                cmd.Parameters.AddWithValue("frequency", cellfrequency.EditedFormattedValue.ToString)
                                cmd.Parameters.AddWithValue("refills", dtgv_treatments.Rows(i).Cells(6).Value.ToString)
                                cmd.Parameters.AddWithValue("duration", "2")
                                cmd.Parameters.AddWithValue("duration_type", "1")
                                cmd.ExecuteNonQuery()
                            End If

                        Next
                    End If
                    consult.display_records("")
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
        get_med_ids()
        add_prescription.ShowDialog()
    End Sub

    Private Sub getfrequency_route()
        Try
            da = New MySqlDataAdapter("SELECT `id`, `name` FROM `prescription_frequency`", conn)
            da.Fill(ds, "frequency")
            da = New MySqlDataAdapter("SELECT `id`, `name` FROM `presciption_routes`", conn)
            da.Fill(ds, "routes")
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
        cellfrequency.DataSource = ds.Tables("frequency")
        cellfrequency.DisplayMember = "name"
        'cellfrequency.ValueMember = "id"
        Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(4)
        cellroutes.DataSource = ds.Tables("routes")
        cellroutes.DisplayMember = "name"
        'cellroutes.ValueMember = "id"
        Dim cellduration As DataGridViewTextBoxCell = dtgv_treatments.Rows(lastrow).Cells(7)
    End Sub
    Public Sub get_med_ids()
        Try
            str_medicine_id = ""
            For i As Integer = 0 To dtgv_treatments.Rows.Count - 1
                If i = 0 Then
                    str_medicine_id = " and id not in(" + dtgv_treatments.Rows(i).Cells(0).Value.ToString
                Else
                    str_medicine_id = str_medicine_id + "," + dtgv_treatments.Rows(i).Cells(0).Value.ToString
                End If
            Next
            If dtgv_treatments.Rows.Count > 0 Then
                str_medicine_id = str_medicine_id + ")"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgv_treatments_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_treatments.CellContentClick
        Try
            If e.ColumnIndex = 8 Then
                get_med_ids()
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
                    Dim templateid As Integer
                    Try
                        'insert new patient record
                        cmd = New MySqlCommand("INSERT INTO `prescription_template`(`name`) VALUES(@templatename)", conn)
                        cmd.Parameters.AddWithValue("templatename", templatename)
                        cmd.ExecuteNonQuery()
                        Dim ds As New DataSet
                        da = New MySqlDataAdapter("select max(id) from prescription_template", conn)
                        da.Fill(ds, "id")
                        templateid = ds.Tables("id").Rows(0).Item(0)
                        If dtgv_treatments.Rows.Count > 1 Or check_row(0) Then
                            For i As Integer = 0 To dtgv_treatments.RowCount - 1
                                If check_row(i) Then
                                    cmd = New MySqlCommand("INSERT INTO `prescription_template_items`(`template_id`, `medicine_id`, `no_generics`, `quantity`, `route`, `frequency`, `refills`, `duration`, `duration_type`) " +
                                                           "VALUES (@template_id,@medicine_id,@no_generics,@quantity,@route,@frequency,@refills,@duration,@duration_type)", conn)
                                    cmd.Parameters.AddWithValue("template_id", templateid.ToString)
                                    cmd.Parameters.AddWithValue("medicine_id", dtgv_treatments.Rows(i).Cells(0).Value.ToString)
                                    cmd.Parameters.AddWithValue("no_generics", dtgv_treatments.Rows(i).Cells(2).Value.ToString)
                                    cmd.Parameters.AddWithValue("quantity", dtgv_treatments.Rows(i).Cells(3).Value.ToString)
                                    cmd.Parameters.AddWithValue("route", dtgv_treatments.Rows(i).Cells(4).Value.ToString)
                                    cmd.Parameters.AddWithValue("frequency", dtgv_treatments.Rows(i).Cells(5).Value.ToString)
                                    cmd.Parameters.AddWithValue("refills", dtgv_treatments.Rows(i).Cells(6).Value.ToString)
                                    cmd.Parameters.AddWithValue("duration", "2")
                                    cmd.Parameters.AddWithValue("duration_type", "1")
                                    cmd.ExecuteNonQuery()
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
