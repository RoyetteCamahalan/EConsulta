Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class New_Consultation
    Private da As New MySqlDataAdapter
    Private cmd As New MySqlCommand
    Private ds As New DataSet
    Public what_to_do As Integer
    Public consult_id As Integer
    Public patient_id As Integer
    Public doctor_id As Integer
    Public consult_date As Date
    Public comment As String
    Private Sub New_Consultation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display_patient()
        display_doctors()
        If what_to_do = 1 Then
            Try
                Me.Text = "Edit Consultation"
                cmb_patients.SelectedValue = patient_id
                cmb_doctors.SelectedValue = doctor_id
                txt_notes.Text = comment
                dtp_date.Value = consult_date
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Me.Text = "New Consultation Entry"
            dtp_date.MinDate = Date.Now
        End If
    End Sub
    Public Sub display_patient()
        Try
            da = New MySqlDataAdapter("select id,concat(fname,' ',mname,' ',lname) as Name from patients where is_from_app=0", conn)
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
        Catch ex As Exception

        End Try
    End Sub
    Private Sub validate_save()
        If cmb_doctors.SelectedIndex < 0 Or cmb_patients.SelectedIndex < 0 Then
            btn_save.Enabled = False
        Else
            btn_save.Enabled = True
        End If
    End Sub

    Private Sub cmb_patients_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_patients.SelectedValueChanged
        validate_save()
    End Sub

    Private Sub cmb_doctors_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_doctors.SelectedValueChanged
        validate_save()
    End Sub

    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        Try
            If what_to_do = 0 Then
                Dim insert_sql As String
                da = New MySqlDataAdapter("select * from `doctor_patient` where `doctor_id`=" + cmb_doctors.SelectedValue.ToString + " and `patient_id`=" + cmb_patients.SelectedValue.ToString + " and `clinic_id`=" + My.Settings.ClinicID.ToString, conn)
                da.Fill(ds, "checker")
                If ds.Tables("checker").Rows.Count = 0 Then
                    insert_sql = String.Format("INSERT INTO `doctor_patient`(`clinic_id`, `doctor_id`, `patient_id`, `username`, `password`) VALUES ({0},{1},{2},'{3}','{4}')",
                                                                     My.Settings.ClinicID.ToString, cmb_doctors.SelectedValue.ToString, cmb_patients.SelectedValue.ToString, randomuname("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"), randomuname("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz"))

                    cmd = New MySqlCommand(insert_sql, conn)
                    cmd.ExecuteNonQuery()
                End If
                insert_sql = String.Format("INSERT INTO `patient_consultations`(`patient_id`, `doctor_id`, `date`, `time`, `isdone`) VALUES ({0},{1},'{2}','{3}',0)",
                                                                     cmb_patients.SelectedValue.ToString, cmb_doctors.SelectedValue.ToString, Convert.ToDateTime(dtp_date.Value.ToString).ToString("yyyy-MM-dd hh:mm:ss"), dtp_date.Value.ToLongTimeString)

                cmd = New MySqlCommand(insert_sql, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Appointment Saved", , "APPOINTMENT NOTIFICATION")
                Consultation.display_all("")
                today.display_today("")
                incoming.display_incoming("")
            Else
                Dim insert_sql As String = String.Format("Update `patient_consultations` set `patient_id`={0}, `doctor_id`={1}, `date`='{2}', `time`='{4}',updated_at=CURRENT_TIMESTAMP where id={3}",
                                                                     cmb_patients.SelectedValue.ToString, cmb_doctors.SelectedValue.ToString, Convert.ToDateTime(dtp_date.Value.ToString).ToString("yyyy-MM-dd hh:mm:ss"), consult_id.ToString, dtp_date.Value.ToLongTimeString)
                cmd = New MySqlCommand(insert_sql, conn)
                cmd.ExecuteNonQuery()
                MsgBox("Appointment Saved", , "APPOINTMENT NOTIFICATION")
                Consultation.display_all("")
                today.display_today("")
                incoming.display_incoming("")
            End If
            'MsgBox(dtp_date.Value.Date.ToString("yyyy-MM-dd ") + dtp_date.Value.TimeOfDay.ToString)

            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        New_Patient.ShowDialog()
    End Sub

    Private Sub New_Consultation_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
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
End Class