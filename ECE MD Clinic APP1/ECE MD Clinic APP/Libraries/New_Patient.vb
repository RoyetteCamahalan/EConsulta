Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Text.StringBuilder
Imports System.IO

Public Class New_Patient
    Private dsaddress As New DataSet
    Private close_tag As Boolean = False
    Private da As New MySqlDataAdapter
    Private cmd As New MySqlCommand
    Private confirmed_pword As Boolean = False
    Private patient_info_arr(27) As String
    Private filename As String = ""
    Private path As String = ""
    Private email_checker As Boolean = True
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
        dsaddress.Tables.Add("regions")
        dsaddress.Tables.Add("provinces")
        dsaddress.Tables.Add("municipalities")
        dsaddress.Tables.Add("barangays")
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
            Dim insert_str As String = "Insert into patients " +
                                        "(fname, mname, lname, occupation, doctor_referred_by, birthdate, sex, civil_status, height, weight, address_house_no, address_street, barangay_id,created_at,photo, `email_address`, `mobile_no`, `tel_no`) values" +
                                        " (@fname,@mname,@lname,@occupation,@doctor_reffered_by,@bdate,@sex,@status,@height,@weight,@houseno,@street,@barangay,CURRENT_TIMESTAMP,@photo,@email,@mobile,@tel)"

            cmd = New MySqlCommand(insert_str, conn)
            cmd.Parameters.AddWithValue("fname", patient_info_arr(0))
            cmd.Parameters.AddWithValue("mname", patient_info_arr(1))
            cmd.Parameters.AddWithValue("lname", patient_info_arr(2))
            cmd.Parameters.AddWithValue("occupation", patient_info_arr(5))
            cmd.Parameters.AddWithValue("doctor_reffered_by", patient_info_arr(6))
            cmd.Parameters.AddWithValue("bdate", patient_info_arr(7))
            cmd.Parameters.AddWithValue("sex", patient_info_arr(8))
            cmd.Parameters.AddWithValue("status", patient_info_arr(9))
            cmd.Parameters.AddWithValue("height", patient_info_arr(10))
            cmd.Parameters.AddWithValue("weight", patient_info_arr(11))
            cmd.Parameters.AddWithValue("houseno", patient_info_arr(12))
            cmd.Parameters.AddWithValue("street", patient_info_arr(13))
            cmd.Parameters.AddWithValue("barangay", patient_info_arr(14))
            cmd.Parameters.AddWithValue("photo", filename)

            cmd.Parameters.AddWithValue("email", patient_info_arr(15))
            cmd.Parameters.AddWithValue("mobile", patient_info_arr(16))
            cmd.Parameters.AddWithValue("tel", patient_info_arr(17))

            cmd.ExecuteNonQuery()
            Patients.display_patients("")
            New_Consultation.display_patient()
            new_consult.display_patient()
            close_tag = True
            MsgBox("New Patient Succesfully Added")
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
    Private Sub display_regions()
        Try
            dsaddress.Clear()
            da = New MySqlDataAdapter("select id,name from regions", conn)
            da.Fill(dsaddress, "regions")
            With cmb_region
                .DataSource = dsaddress.Tables("regions")
                .DisplayMember = "name"
                .ValueMember = "id"
                .SelectedIndex = -1

            End With
        Catch ex As Exception

        End Try
        cmb_region.Text = "Select Region"
    End Sub

    Private Sub cmb_region_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_region.SelectedValueChanged
        Try
            dsaddress.Tables("provinces").Clear()
            da = New MySqlDataAdapter("select id,name from provinces where region_id=" + cmb_region.SelectedValue.ToString, conn)
            da.Fill(dsaddress, "provinces")
            With cmb_province
                .DataSource = dsaddress.Tables("provinces")
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
            dsaddress.Tables("municipalities").Clear()
            da = New MySqlDataAdapter("select id,name from municipalities where province_id=" + cmb_province.SelectedValue.ToString, conn)
            da.Fill(dsaddress, "municipalities")
            With cmb_municipality
                .DataSource = dsaddress.Tables("municipalities")
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
            dsaddress.Tables("barangays").Clear()
            da = New MySqlDataAdapter("select id,name from barangays where municipality_id=" + cmb_municipality.SelectedValue.ToString, conn)
            da.Fill(dsaddress, "barangays")
            With cmb_barangay
                .DataSource = dsaddress.Tables("barangays")
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