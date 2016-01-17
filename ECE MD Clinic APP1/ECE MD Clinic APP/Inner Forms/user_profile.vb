Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class user_profile
    Private cmd As New MySqlCommand
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private dsaddress As New DataSet
    Private fname, mname, lname, bdate, sex, civil_status, specialty, sub_specialty, prcno As String
    Private mobileno, telno, email, houseno, street As String
    Private barangay, municipality, province, region_id As Integer
    Private email_checker As Boolean = True
    Private errormsgcon As String = ""
    Private errormsgbasic As String = ""

    Private Sub btn_gcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gcancel.Click
        disableaccount()
        txt_uname.Text = UserName
        txt_pword.Text = PassWord
    End Sub

    Private Sub fillfields()
        txt_fname.Text = fname
        txt_lname.Text = lname
        txt_mname.Text = mname
        txt_mobileno.Text = mobileno
        txt_telno.Text = telno
        txt_email.Text = email
        txt_houseno.Text = houseno
        txt_street.Text = street
        cmb_region.SelectedValue = region_id
        cmb_province.SelectedValue = province
        cmb_municipality.SelectedValue = municipality
        cmb_barangay.SelectedValue = barangay
        txt_uname.Text = UserName
        txt_pword.Text = PassWord
    End Sub
    Public Sub save_userprofilebasic()
        Try
            If Panel1.Visible = True Then
                cmd = New MySqlCommand("UPDATE `doctors` SET `lname`=@lname,`mname`=@mname,`fname`=@fname,`prc_no`=@prc," +
                                       "" +
                                       "`updated_at`=CURRENT_TIMESTAMP where id=@id", conn) '`specialty`=@specialty,`sub_specialty`=@subspecialty,
                cmd.Parameters.AddWithValue("fname", txt_fname.Text)
                cmd.Parameters.AddWithValue("mname", txt_mname.Text)
                cmd.Parameters.AddWithValue("lname", txt_lname.Text)
                cmd.Parameters.AddWithValue("prc", txt_prc.Text)

                'cmd.Parameters.AddWithValue("specialty", txt_specialty.Text)
                'cmd.Parameters.AddWithValue("subspecialty", txt_sub_specialty.Text)
                cmd.Parameters.AddWithValue("id", UserId.ToString)
                cmd.ExecuteNonQuery()
            Else
                cmd = New MySqlCommand("UPDATE `secretaries` SET `lname`=@lname,`mname`=@mname,`fname`=@fname," +
                                       "`updated_at`=CURRENT_TIMESTAMP where id=@id", conn)
                cmd.Parameters.AddWithValue("fname", txt_fname.Text)
                cmd.Parameters.AddWithValue("mname", txt_mname.Text)
                cmd.Parameters.AddWithValue("lname", txt_lname.Text)

                cmd.Parameters.AddWithValue("id", UserId.ToString)
                cmd.ExecuteNonQuery()
            End If
            MsgBox("New Update Saved", MsgBoxStyle.OkOnly, "Clinic App")
            disablebasic()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub save_userprofilecontact()
        Try
            If Panel1.Visible = True Then
                cmd = New MySqlCommand("UPDATE `doctors` SET `address_house_no`=@houseno,`address_street`=@street,`barangay_id`=@brgy," +
                                       "`cell_no`=@celno,`tel_no`=@telno,`email`=@email,`updated_at`=CURRENT_TIMESTAMP where id=@id", conn)
                cmd.Parameters.AddWithValue("houseno", txt_houseno.Text)
                cmd.Parameters.AddWithValue("street", txt_street.Text)
                cmd.Parameters.AddWithValue("brgy", cmb_barangay.SelectedValue.ToString)

                cmd.Parameters.AddWithValue("celno", txt_mobileno.Text)
                cmd.Parameters.AddWithValue("telno", txt_telno.Text)
                cmd.Parameters.AddWithValue("email", txt_email.Text)
                cmd.Parameters.AddWithValue("id", UserId.ToString)
                cmd.ExecuteNonQuery()
            Else
                cmd = New MySqlCommand("UPDATE `secretaries` SET `address_house_no`=@houseno,`address_street`=@street,`barangay_id`=@brgy," +
                                       "`cell_no`=@celno,`tel_no`=@telno," +
                                       "`email`=@email,`updated_at`=CURRENT_TIMESTAMP where id=@id", conn)
                cmd.Parameters.AddWithValue("houseno", txt_houseno.Text)
                cmd.Parameters.AddWithValue("street", txt_street.Text)
                cmd.Parameters.AddWithValue("brgy", cmb_barangay.SelectedValue.ToString)

                cmd.Parameters.AddWithValue("celno", txt_mobileno.Text)
                cmd.Parameters.AddWithValue("telno", txt_telno.Text)
                cmd.Parameters.AddWithValue("email", txt_email.Text)
                cmd.Parameters.AddWithValue("id", UserId.ToString)
                cmd.ExecuteNonQuery()
            End If
            MsgBox("New Update Saved", MsgBoxStyle.OkOnly, "Clinic App")
            disablecontact()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub save_userprofileaccount()
        Try
            If Panel1.Visible = True Then
                cmd = New MySqlCommand("UPDATE `doctors` SET `username`=@uname, `password`=@pword," +
                                       "`updated_at`=CURRENT_TIMESTAMP where id=@id", conn)
                cmd.Parameters.AddWithValue("uname", txt_uname.Text)
                cmd.Parameters.AddWithValue("pword", txt_pword.Text)
                cmd.Parameters.AddWithValue("id", UserId.ToString)
                cmd.ExecuteNonQuery()
            Else
                cmd = New MySqlCommand("UPDATE `secretaries` SET `username`=@uname, `password`=@pword," +
                                       "`updated_at`=CURRENT_TIMESTAMP where id=@id", conn)
                cmd.Parameters.AddWithValue("uname", txt_uname.Text)
                cmd.Parameters.AddWithValue("pword", txt_pword.Text)
                cmd.Parameters.AddWithValue("id", UserId.ToString)

                cmd.ExecuteNonQuery()
            End If
            MsgBox("New Update Saved", MsgBoxStyle.OkOnly, "Clinic App")
            disableaccount()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub enable_fieldbasic()
        txt_fname.ReadOnly = False
        txt_mname.ReadOnly = False
        txt_lname.ReadOnly = False
        'birthdate_picker.Enabled = True
        'GroupBox1.Enabled = True
        'cmv_status.Enabled = True
        btnbsave.Visible = True
        btnbcancel.Visible = True
        btnbedit.Visible = False
        txt_specialty.ReadOnly = False
        txt_sub_specialty.ReadOnly = False
        txt_prc.ReadOnly = False
    End Sub
    Private Sub enable_fieldcontact()
        btnconsave.Visible = True
        btnconcancel.Visible = True
        btnconedit.Visible = False
        txt_houseno.ReadOnly = False
        cmb_region.Enabled = True
        cmb_province.Enabled = True
        cmb_municipality.Enabled = True
        cmb_barangay.Enabled = True
        txt_mobileno.ReadOnly = False
        txt_telno.ReadOnly = False
        txt_email.ReadOnly = False
    End Sub
    Private Sub disableaccount()
        btn_save.Visible = False
        btn_gcancel.Visible = False
        btn_gedit.Visible = True
        txt_pword.ReadOnly = True
        txt_uname.ReadOnly = True
    End Sub
    Private Sub disablebasic()
        txt_fname.ReadOnly = True
        txt_mname.ReadOnly = True
        txt_lname.ReadOnly = True
        btnbsave.Visible = False
        btnbcancel.Visible = False
        btnbedit.Visible = True
        txt_specialty.ReadOnly = True
        txt_sub_specialty.ReadOnly = True
        txt_prc.ReadOnly = True
    End Sub
    Private Sub disablecontact()
        btnconsave.Visible = False
        btnconcancel.Visible = False
        btnconedit.Visible = True
        txt_houseno.ReadOnly = True
        txt_street.ReadOnly = True
        cmb_barangay.Enabled = False
        cmb_municipality.Enabled = False
        cmb_province.Enabled = False
        cmb_region.Enabled = False
        txt_mobileno.ReadOnly = True
        txt_telno.ReadOnly = True
        txt_email.ReadOnly = True

    End Sub
    Private Sub enableaccount()
        btn_save.Visible = True
        btn_gcancel.Visible = True
        btn_gedit.Visible = False
        txt_pword.ReadOnly = False
        txt_uname.ReadOnly = False
    End Sub

    Private Sub txt_telno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telno.TextChanged
        validationcontact()
    End Sub

    Private Sub txt_mobileno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mobileno.TextChanged
        validationcontact()
    End Sub

    Private Sub txt_zip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validationcontact()
    End Sub

    Private Sub txt_fname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.TextChanged
        validationbasic()
    End Sub

    Private Sub txt_city_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validationcontact()
    End Sub

    Private Sub txt_barangay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validationcontact()
    End Sub

    Private Sub txt_street_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_street.TextChanged
        validationcontact()
    End Sub

    Private Sub txt_houseno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_houseno.TextChanged
        validationcontact()
    End Sub

    Private Sub txt_pword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pword.TextChanged
        validationaccount()
    End Sub

    Private Sub txt_uname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_uname.TextChanged
        validationaccount()
    End Sub

    Private Sub txt_lname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.TextChanged
        validationbasic()
    End Sub

    Private Sub txt_mname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mname.TextChanged
        validationbasic()
    End Sub

    Private Sub txt_province_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validationcontact()
    End Sub
    Private Sub validationbasic()
        errormsgbasic = ""
        Dim ctr As Integer = 0
        If txt_fname.Text = "" Then
            errormsgbasic = "First Name"
            ctr = 1
        End If
        If txt_lname.Text = "" Then
            If ctr = 1 Then
                errormsgbasic = errormsgbasic + " , Last Name"
            Else
                errormsgbasic = "Last Name"
            End If
            ctr = 1
        End If
        If ctr = 1 Then
            btnbsave.ForeColor = Color.Gray
        Else
            btnbsave.ForeColor = Color.Black
        End If
    End Sub
    Private Sub validationcontact()
        errormsgcon = ""
        Dim ctr As Integer = 0
        If cmb_barangay.SelectedIndex < 0 Then
            errormsgcon = "Please Fill Address Fields"
            ctr = 1
        Else
            If Not email_checker Then
                ctr = 1
                If errormsgcon = "" Then
                    errormsgcon = "Invalid E-mail Address"
                Else
                    errormsgcon = errormsgcon + " and E-mail Address is invalid"
                End If
            End If
        End If
        If ctr = 1 Then
            btnconsave.ForeColor = Color.Gray
        Else
            btnconsave.ForeColor = Color.Black
        End If
    End Sub
    Private Sub validationaccount()
        If txt_uname.Text = "" Or txt_pword.Text = "" Then
            btn_save.ForeColor = Color.Gray
        Else
            btn_save.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged
        Try
            If Not txt_email.Text = "" Then
                Dim m As New System.Net.Mail.MailAddress(txt_email.Text)
                lbl_invalid_email.Visible = False
            End If
            email_checker = True
            validationcontact()

        Catch ex As Exception
            lbl_invalid_email.Visible = True
            email_checker = False
            validationcontact()
        End Try
    End Sub

    Private Sub btnbedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbedit.Click
        enable_fieldbasic()
    End Sub

    Private Sub btnconedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconedit.Click
        enable_fieldcontact()
    End Sub
    Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If btn_save.ForeColor = Color.Black Then
            Verification.action_verified = 4
            Verification.ShowDialog()
        Else
            If Not errormsgcon = "" Then
                MsgBox("Please Complete the following: " + errormsgcon, MsgBoxStyle.OkOnly, "Clinic App")
            End If
        End If
    End Sub
    Private Sub btnbsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbsave.Click
        If btnbsave.ForeColor = Color.Black Then
            Verification.action_verified = 3
            Verification.ShowDialog()
        Else
            If Not errormsgbasic = "" Then
                MsgBox("Please Complete the following: " + errormsgbasic, MsgBoxStyle.OkOnly, "Clinic App")
            End If
        End If
    End Sub

    Private Sub btnconsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconsave.Click
        If btnconsave.ForeColor = Color.Black Then
            Verification.action_verified = 1
            Verification.ShowDialog()
        Else
            If Not errormsgcon = "" Then
                MsgBox("Please Complete the following: " + errormsgcon, MsgBoxStyle.OkOnly, "Clinic App")
            End If
        End If
    End Sub

    Private Sub btnbcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbcancel.Click
        disablebasic()
        txt_fname.Text = fname
        txt_lname.Text = lname
        txt_mname.Text = mname
        'birthdate_picker.Value = bdate
        'If civil_status = "Single" Then
        '    cmv_status.SelectedIndex = 0
        'ElseIf civil_status = "Married" Then
        '    cmv_status.SelectedIndex = 1
        'ElseIf civil_status = "Widow" Then
        '    cmv_status.SelectedIndex = 2
        'End If
        'If sex = "Female" Then
        '    rdbtn_female.Checked = True
        'ElseIf sex = "Male" Then
        '    rdbtn_male.Checked = True
        'End If
        txt_specialty.Text = specialty
        txt_sub_specialty.Text = sub_specialty
        txt_prc.Text = prcno
    End Sub

    Private Sub btnconcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconcancel.Click
        disablecontact()
        txt_mobileno.Text = mobileno
        txt_telno.Text = telno
        txt_email.Text = email
        txt_houseno.Text = houseno
        txt_street.Text = street
        cmb_region.SelectedValue = region_id
        cmb_province.SelectedValue = province
        cmb_municipality.SelectedValue = municipality
        cmb_barangay.SelectedValue = barangay
    End Sub

    Private Sub btn_gedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_gedit.Click
        enableaccount()
    End Sub

    Private Sub user_profile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dsaddress.Tables.Add("regions")
            dsaddress.Tables.Add("provinces")
            dsaddress.Tables.Add("municipalities")
            dsaddress.Tables.Add("barangays")
            display_regions()
            ds.Clear()
            If UserType = 0 Then
                da = New MySqlDataAdapter("SELECT s.`id`,s.`fname`, s.`mname`, s.`lname`, s.`address_house_no`, s.`address_street`," +
                                          " b.`id`, m.`id`, p.`id`, r.`id`, s.`cell_no`, s.`tel_no`, s.`email`, s.`photo`, s.`created_at`, " +
                                          "s.`updated_at`,'' as secretary_id,'' as prc_no,'' as specialty,'' as sub_specialty,'' as clinic_sched,'' " +
                                          "as affiliation FROM `secretaries`s inner join clinic_secretary cs on cs.secretary_id=s.id INNER join barangays" +
                                          " b on b.id=s.barangay_id INNER JOIN municipalities m ON m.id=b.municipality_id INNER JOIN provinces p on p.id=m.province_id " +
                                          "INNER JOIN regions r ON r.id=p.region_id WHERE s.id=" + UserId.ToString, conn)
                Panel1.Visible = False
            Else
                da = New MySqlDataAdapter("SELECT d.`id`,d.`fname`, d.`mname`, d.`lname`, d.`address_house_no`, d.`address_street`, b.`id`, m.`id`, p.`id`, r.`id`, d.`cell_no`, d.`tel_no`, d.`email`, d.`photo`, d.`created_at`, d.`updated_at`,'' as secretary_id,'' as prc_no,'' as specialty,'' as sub_specialty,'' as clinic_sched,'' " +
                                          "as affiliation FROM `doctors` d inner join clinic_doctor cs on cs.doctor_id=d.id INNER join barangays b on b.id=d.barangay_id INNER JOIN municipalities m ON m.id=b.municipality_id INNER JOIN provinces p on p.id=m.province_id INNER JOIN regions r ON r.id=p.region_id WHERE d.id=" + UserId.ToString, conn)
                Panel1.Visible = True
            End If
            da.Fill(ds)
            fname = ds.Tables(0).Rows(0).Item(1).ToString
            mname = ds.Tables(0).Rows(0).Item(2).ToString
            lname = ds.Tables(0).Rows(0).Item(3).ToString

            mobileno = ds.Tables(0).Rows(0).Item(10).ToString
            telno = ds.Tables(0).Rows(0).Item(11).ToString
            email = ds.Tables(0).Rows(0).Item(12).ToString
            houseno = ds.Tables(0).Rows(0).Item(4).ToString
            street = ds.Tables(0).Rows(0).Item(5).ToString
            barangay = ds.Tables(0).Rows(0).Item(6)
            municipality = ds.Tables(0).Rows(0).Item(7)
            province = ds.Tables(0).Rows(0).Item(8)
            region_id = ds.Tables(0).Rows(0).Item(9)

            specialty = ds.Tables(0).Rows(0).Item(18).ToString
            sub_specialty = ds.Tables(0).Rows(0).Item(19).ToString
            prcno = ds.Tables(0).Rows(0).Item(17).ToString
            txt_prc.Text = ds.Tables(0).Rows(0).Item(18).ToString
            disablebasic()
            disablecontact()
            disableaccount()
            fillfields()
            Me.Text = fname + " " + mname + " " + lname
        Catch ex As Exception
            MsgBox(ex.ToString)
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
        validationcontact()
    End Sub

End Class