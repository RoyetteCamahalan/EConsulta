
Public Class New_Patient
#Region "Methods"
    Private Sub display_regions()
        Try
            DT_Region.Clear()
            DT_Province.Clear()
            DT_Municipality.Clear()
            DT_Barangay.Clear()
            Dim Param_Name As String() = {"@action_type"}
            Dim Param_Value As String() = {0}
            Dim MyAdapter As New Custom_Adapters
            With cmb_region
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_ADDRESS", Param_Name, Param_Value)
                .DisplayMember = "name"
                .ValueMember = "id"
                .SelectedIndex = -1
            End With
        Catch ex As Exception

        End Try
        cmb_region.Text = "Select Region"
    End Sub
#End Region
#Region "Variables"
    Private close_tag As Boolean = False
    Private confirmed_pword As Boolean = False
    Private patient_info_arr(27) As String
    Private filename As String = ""
    Private path As String = ""
    Private email_checker As Boolean = True

    Private DT_Region As New DataTable
    Private DT_Province As New DataTable
    Private DT_Municipality As New DataTable
    Private DT_Barangay As New DataTable
#End Region
    Private Sub btn_next_geninfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next_geninfo.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Dispose()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub New_Patient_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If close_tag = False Then
            Dim res As MsgBoxResult
            res = MsgBox("Are you sure you want to close this without saving", MsgBoxStyle.YesNo, "Warning!")
            If res = MsgBoxResult.Yes Then
                Me.Dispose()
            Else
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
#Region "Text Box hint effect on general info"
    Private Sub txt_fname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.Enter
        With txt_fname
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_mname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mname.Enter
        With txt_mname
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_lname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.Enter
        With txt_lname
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_occupation_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_occupation.Enter
        With txt_occupation
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_height_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_height.Enter
        With txt_height
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_weight_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_weight.Enter
        With txt_weight
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_fname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.Leave
        If txt_fname.Text = "" Then
            With txt_fname
                .Text = "First Name"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub
    Private Sub txt_mname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mname.Leave
        If txt_mname.Text = "" Then
            With txt_mname
                .Text = "Middle Name"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_lname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.Leave
        If txt_lname.Text = "" Then
            With txt_lname
                .Text = "Last Name"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub
    Private Sub txt_occupation_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_occupation.Leave
        If txt_occupation.Text = "" Then
            With txt_occupation
                .Text = "Occupation"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_height_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_height.Leave
        If txt_height.Text = "" Then
            With txt_height
                .Text = "Height"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_weight_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_weight.Leave
        If txt_weight.Text = "" Then
            With txt_weight
                .Text = "Weight"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub
#End Region
#Region "Text Box hint effect on contact info"
    Private Sub txt_houseno_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_houseno.Enter
        With txt_houseno
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_street_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_street.Enter
        With txt_street
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_mobileno_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mobileno.Enter
        With txt_mobileno
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_telno_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telno.Enter
        With txt_telno
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_email_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.Enter
        If txt_email.Text = "E-mail Address" Then
            With txt_email
                .Clear()
                .ForeColor = Color.Black
            End With
        End If
    End Sub
    Private Sub txt_houseno_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_houseno.Leave
        If txt_houseno.Text = "" Then
            With txt_houseno
                .Text = "House No."
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_street_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_street.Leave
        If txt_street.Text = "" Then
            With txt_street
                .Text = "Street"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub


    Private Sub txt_mobileno_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mobileno.Leave
        If txt_mobileno.Text = "" Then
            With txt_mobileno
                .Text = "Mobile No."
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_telno_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telno.Leave
        If txt_telno.Text = "" Then
            With txt_telno
                .Text = "Telephone No."
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_email_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.Leave
        If txt_email.Text = "" Then
            With txt_email
                .Text = "E-mail Address"
                .ForeColor = Color.Gray
            End With
            lbl_invalid_email.Visible = False
        Else
            Try
                Dim m As New System.Net.Mail.MailAddress(txt_email.Text)
                lbl_invalid_email.Visible = False
            Catch ex As Exception
                lbl_invalid_email.Visible = True
                txt_email.Focus()
            End Try

        End If

    End Sub
    
    
#End Region

    Private Sub validate_gen_info()
        If txt_fname.Text = "First Name" Or txt_fname.Text = "" Or txt_lname.Text = "Last Name" Or txt_lname.Text = "" Or rdbtn_female.Checked = False And rbtn_male.Checked = False Or birthdate_picker.Value.Date = Date.Now().Date Then
            btn_next_geninfo.Enabled = False
        Else
            btn_next_geninfo.Enabled = True
        End If
    End Sub
    Private Sub validate_contact_info()
        If cmb_barangay.SelectedIndex < 0 Then
            btn_next_contact_info.Enabled = False
        Else
            If email_checker Then
                btn_next_contact_info.Enabled = True
            Else
                btn_next_contact_info.Enabled = False
            End If
        End If
    End Sub
    Private Sub txt_fname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.TextChanged
        If Not (txt_fname.Text = "First Name" Or txt_fname.Text = "") Then
            validate_gen_info()
        Else
            btn_next_geninfo.Enabled = False
        End If
    End Sub

    Private Sub txt_lname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.TextChanged
        If Not (txt_lname.Text = "Last Name" Or txt_lname.Text = "") Then
            validate_gen_info()
        Else
            btn_next_geninfo.Enabled = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtn_male.CheckedChanged
        validate_gen_info()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbtn_female.CheckedChanged
        validate_gen_info()
    End Sub

    Private Sub New_Patient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        display_regions()
        birthdate_picker.MaxDate = Date.Now()
        imagedialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        birthdate_picker.CustomFormat = "yyyy'-'MM'-'dd'"
    End Sub
    Private Sub birthdate_picker_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles birthdate_picker.ValueChanged
        validate_gen_info()
    End Sub

    Private Sub txt_phase_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validate_contact_info()
    End Sub

    Private Sub txt_lotno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validate_contact_info()
    End Sub

    Private Sub txt_building_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validate_contact_info()
    End Sub

    Private Sub txt_roomno_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validate_contact_info()
    End Sub

    Private Sub txt_blockno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validate_contact_info()
    End Sub
    Private Sub txt_houseno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_houseno.TextChanged
        validate_contact_info()
    End Sub

    Private Sub txt_street_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_street.TextChanged
        validate_contact_info()
    End Sub

    Private Sub txt_barangay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validate_contact_info()
    End Sub

    Private Sub txt_city_municipality_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validate_contact_info()
    End Sub

    Private Sub txt_province_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validate_contact_info()
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If btn_next_geninfo.Enabled = False Then
            e.Cancel = True
        ElseIf btn_next_contact_info.Enabled = False And e.TabPageIndex = 2 Then
            e.Cancel = True
        End If
    End Sub
    Private Sub btn_finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next_contact_info.Click
        Try
            collect_data()
            If Not filename = "" Then
                My.Computer.FileSystem.CopyFile(path, "C:\ECE MD Clinic APP\PROFILE_PICTURES\Patients\" + filename)
            End If
            Dim MyAdapter As New Custom_Adapters
            Dim Param_Name As String() = {"@action_type",
                                          "@fname", "@mname", "@lname",
                                          "@email", "@mobile", "@tel",
                                           "@occupation",
                                          "@reffered_by", "@reffered_to",
                                          "@birthdate", "@sex", "@civil_status",
                                          "@height", "@weight",
                                          "@houseno", "@street", "@barangay_id", "@server_id"}
            Dim Param_Value As String() = {0,
                                           patient_info_arr(0), patient_info_arr(1), patient_info_arr(2),
                                           patient_info_arr(15), patient_info_arr(16), patient_info_arr(17),
                                            patient_info_arr(5),
                                           patient_info_arr(6), "",
                                           patient_info_arr(7), patient_info_arr(8), patient_info_arr(9),
                                           patient_info_arr(10), patient_info_arr(11),
                                           patient_info_arr(12), patient_info_arr(13), patient_info_arr(14), 0}
            If MyAdapter.CUSTOM_TRANSACT("SP_Patient", Param_Name, Param_Value) Then
                Patients.DisplayPatients()
                New_Consultation.DisplayPatient()
                new_consult.DisplayPatient()
                close_tag = True
                MsgBox("New Patient Succesfully Added")
            Else
                MsgBox("Saving Failed")
            End If
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub collect_data()
        patient_info_arr(0) = txt_fname.Text
        If txt_mname.Text = "Middle Name" Then
            patient_info_arr(1) = ""
        Else
            patient_info_arr(1) = txt_mname.Text
        End If
        patient_info_arr(2) = txt_lname.Text
        If txt_occupation.Text = "Occupation" Then
            patient_info_arr(5) = ""
        Else
            patient_info_arr(5) = txt_occupation.Text
        End If
        patient_info_arr(6) = txt_reffered_by.Text
        patient_info_arr(7) = birthdate_picker.Text
        If rdbtn_female.Checked = True Then
            patient_info_arr(8) = "Female"
        ElseIf rbtn_male.Checked = True Then
            patient_info_arr(8) = "Male"
        End If
        If cmv_status.SelectedIndex = -1 Then
            patient_info_arr(9) = ""
        Else
            patient_info_arr(9) = cmv_status.SelectedItem.ToString
        End If
        If txt_height.Text = "Height" Then
            patient_info_arr(10) = ""
        Else
            patient_info_arr(10) = txt_height.Text
        End If
        If txt_weight.Text = "Weight" Then
            patient_info_arr(11) = ""
        Else
            patient_info_arr(11) = txt_weight.Text
        End If
        If txt_houseno.Text = "House No." Then
            patient_info_arr(12) = ""
        Else
            patient_info_arr(12) = txt_houseno.Text
        End If
        If txt_street.Text = "Street" Then
            patient_info_arr(13) = ""
        Else
            patient_info_arr(13) = txt_street.Text
        End If
        patient_info_arr(14) = cmb_barangay.SelectedValue.ToString
        If txt_email.Text = "E-mail Address" Then
            patient_info_arr(15) = ""
        Else
            patient_info_arr(15) = txt_email.Text
        End If
        If txt_mobileno.Text = "Mobile No." Then
            patient_info_arr(16) = ""
        Else
            patient_info_arr(16) = txt_mobileno.Text
        End If
        If txt_telno.Text = "Telephone No." Then
            patient_info_arr(17) = ""
        Else
            patient_info_arr(17) = txt_telno.Text
        End If
        
    End Sub

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
        Try
            If imagedialog.ShowDialog = DialogResult.OK Then
                Dim filename_without As String = System.IO.Path.GetFileNameWithoutExtension(imagedialog.FileName)
                Dim extention As String = System.IO.Path.GetExtension(imagedialog.FileName)
                path = imagedialog.FileName
                filename = randomstring(filename_without) + extention
                profile_pic.Image = Image.FromFile(path)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function randomstring(ByRef s As String) As String
        Dim r As New Random
        Dim sb As New System.Text.StringBuilder
        Dim cnt As Integer = r.Next(15, 33)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

    Private Sub btn_remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_remove.Click
        profile_pic.Image = Image.FromFile("C:\ECE MD Clinic APP\PROFILE_PICTURES\default_profile.png")
        filename = ""
    End Sub

    Private Sub txt_roomno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txt_lotno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txt_blockno_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txt_phase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged
        Try
            If Not (txt_email.Text = "" Or txt_email.Text = "E-mail Address") Then
                Dim m As New System.Net.Mail.MailAddress(txt_email.Text)
                lbl_invalid_email.Visible = False
            End If
            email_checker = True
            validate_contact_info()

        Catch ex As Exception
            email_checker = False
            validate_contact_info()
        End Try
    End Sub
    

    Private Sub cmb_region_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_region.SelectedValueChanged
        Try
            DT_Province.Clear()
            Dim Param_Name As String() = {"@action_type", "@region_id"}
            Dim Param_Value As String() = {1, cmb_region.SelectedValue}
            Dim MyAdapter As New Custom_Adapters
            With cmb_province
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_ADDRESS", Param_Name, Param_Value)
                .DisplayMember = "name"
                .ValueMember = "id"
                .SelectedIndex = -1

            End With
        Catch ex As Exception

        End Try
        cmb_province.Text = "Select Province"
    End Sub

    Private Sub cmb_province_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_province.SelectedValueChanged
        Try
            DT_Municipality.Clear()
            Dim Param_Name As String() = {"@action_type", "@province_id"}
            Dim Param_Value As String() = {2, cmb_province.SelectedValue}
            Dim MyAdapter As New Custom_Adapters
            With cmb_municipality
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_ADDRESS", Param_Name, Param_Value)
                .DisplayMember = "name"
                .ValueMember = "id"
                .SelectedIndex = -1

            End With
        Catch ex As Exception

        End Try
        cmb_municipality.Text = "Select Municipality"
    End Sub

    Private Sub cmb_municipality_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_municipality.SelectedValueChanged
        Try
            DT_Barangay.Clear 
            Dim Param_Name As String() = {"@action_type", "@municipal_id"}
            Dim Param_Value As String() = {3, cmb_municipality.SelectedValue}
            Dim MyAdapter As New Custom_Adapters
            With cmb_barangay
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_ADDRESS", Param_Name, Param_Value)
                .DisplayMember = "name"
                .ValueMember = "id"
                .SelectedIndex = -1

            End With
        Catch ex As Exception

        End Try
        cmb_barangay.Text = "Select Barangay"
    End Sub

    Private Sub cmb_barangay_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_barangay.SelectedValueChanged
        validate_contact_info()
    End Sub
End Class