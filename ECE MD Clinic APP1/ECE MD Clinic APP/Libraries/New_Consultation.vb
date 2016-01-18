Public Class New_Consultation
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
                Param_Value = {2, 1, "", UserId}
                cmb_doctors.Enabled = False
            End If
            With cmb_doctors
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Patient", Param_Name, Param_Value)
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
#End Region
#Region "Variables"
    Public what_to_do As Integer
    Public consult_id As Integer
    Public patient_id As Integer
    Public doctor_id As Integer
    Public consult_date As Date
    Public comment As String
#End Region
    Private Sub New_Consultation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayPatient()
        DisplayDoctors()
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
                Dim Param_Name As String() = {"@action_type", "@sub_action", "@doctor_id", "@patient_id", "@clinic_id"}
                Dim Param_Value As String() = {2, 1, cmb_doctors.SelectedValue, cmb_patients.SelectedValue, My.Settings.ClinicID}
                Dim MyAdapter_Doctor_Patient As New Custom_Adapters
                Dim MyAdapter_Patient_Consultation As New Custom_Adapters
                If MyAdapter_Doctor_Patient.CUSTOM_TRANSACT_WITH_RETURN("SP_DoctorPatient", Param_Name, Param_Value) = 0 Then
                    Param_Name = {"@action_type", "@sub_action", "@doctor_id", "@patient_id", "@clinic_id", "@username", "@password"}
                    Param_Value = {2, 1, cmb_doctors.SelectedValue, cmb_patients.SelectedValue, My.Settings.ClinicID,
                                        randomuname("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"),
                                        randomuname("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz")}

                    MyAdapter_Doctor_Patient.CUSTOM_TRANSACT("SP_DoctorPatient", Param_Name, Param_Value)
                End If
                Param_Name = {"@action_type", "@doctor_id", "@patient_id", "@clinic_id", "@consult_date", "@consult_time", "@is_done", "@comment_doctor"}
                Param_Value = {0, cmb_doctors.SelectedValue,
                                  cmb_patients.SelectedValue,
                                  My.Settings.ClinicID,
                                  Convert.ToDateTime(dtp_date.Value.ToString).ToString("yyyy-MM-dd hh:mm:ss"),
                                  dtp_date.Value.ToLongTimeString, 0, txt_notes.Text}

                If MyAdapter_Patient_Consultation.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value) Then
                    MsgBox("Appointment Saved", , "APPOINTMENT NOTIFICATION")
                    Consultation.DisplayAppointmentsAll()
                    today.DisplayAppointmentToday()
                    incoming.DisplayAppointmentIncoming()
                Else
                    MsgBox("Failed")
                End If

            Else
                Dim MyAdapter_Patient_Consultation As New Custom_Adapters
                Dim Param_Name As String() = {"@action_type", "@sub_action", "@doctor_id", "@patient_id",
                                              "@consult_date", "@consult_time", "@comment_doctor", "@id"}
                Dim Param_Value As String() = {1, 2, cmb_doctors.SelectedValue, cmb_patients.SelectedValue,
                                               Convert.ToDateTime(dtp_date.Value.ToString).ToString("yyyy-MM-dd hh:mm:ss"),
                                               dtp_date.Value.ToLongTimeString,
                                               consult_id}
                If MyAdapter_Patient_Consultation.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value) Then
                    MsgBox("Appointment Saved", , "APPOINTMENT NOTIFICATION")
                    Consultation.DisplayAppointmentsAll()
                    today.DisplayAppointmentToday()
                    incoming.DisplayAppointmentIncoming()
                Else
                    MsgBox("Failed")
                End If

            End If
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