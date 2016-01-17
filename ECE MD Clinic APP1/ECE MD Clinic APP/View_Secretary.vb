Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class View_Secretary
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private dsaddress As New DataSet
    Public secretary_id, isactive As Integer
    Private fname, mname, lname, mobileno, telno, email, houseno, street, uname, pword As String
    Private barangay, municipality, province, region_id As Integer
    Private email_checker As Boolean = True
    Private errormsg As String = ""
    Private Sub View_Secretary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            dsaddress.Tables.Add("regions")
            dsaddress.Tables.Add("provinces")
            dsaddress.Tables.Add("municipalities")
            dsaddress.Tables.Add("barangays")
            display_regions()
            ds.Clear()
            da = New MySqlDataAdapter("SELECT s.`fname`, s.`mname`, s.`lname`, s.`username`, s.`password`, s.`address_house_no`, s.`address_street`, b.`id`, m.`id`, " +
                                      "p.`id`, r.`id`, s.`cell_no`, s.`tel_no`, s.`email`, s.`photo`, s.`created_at`, s.`updated_at`, s.`deleted_at` FROM `secretaries`s " +
                                      "inner join clinic_secretary cs on cs.secretary_id=s.id INNER join barangays b on b.id=s.barangay_id INNER JOIN municipalities m ON" +
                                      " m.id=b.municipality_id INNER JOIN provinces p on p.id=m.province_id INNER JOIN regions r ON r.id=p.region_id WHERE s.id=" + secretary_id.ToString, conn)
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                fname = ds.Tables(0).Rows(0).Item(0).ToString
                mname = ds.Tables(0).Rows(0).Item(1).ToString
                lname = ds.Tables(0).Rows(0).Item(2).ToString
                uname = ds.Tables(0).Rows(0).Item(3).ToString
                pword = ds.Tables(0).Rows(0).Item(4).ToString
                houseno = ds.Tables(0).Rows(0).Item(5).ToString
                street = ds.Tables(0).Rows(0).Item(6).ToString
                barangay = ds.Tables(0).Rows(0).Item(7)
                municipality = ds.Tables(0).Rows(0).Item(8)
                province = ds.Tables(0).Rows(0).Item(9)
                region_id = ds.Tables(0).Rows(0).Item(10)
                mobileno = ds.Tables(0).Rows(0).Item(11).ToString
                telno = ds.Tables(0).Rows(0).Item(12).ToString
                email = ds.Tables(0).Rows(0).Item(13).ToString
                fill_fields()
                If isactive = 1 Then
                    chk_isactive.Checked = True
                Else
                    chk_isactive.Checked = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btn_gedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        enable_fields()
    End Sub
    Private Sub fill_fields()
        txt_uname.Text = uname
        txt_pword.Text = pword
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



        If isactive = 1 Then
            chk_isactive.Checked = True
        Else
            chk_isactive.Checked = False
        End If
    End Sub
    Private Sub enable_fields()
        txt_fname.ReadOnly = False
        txt_mname.ReadOnly = False
        txt_lname.ReadOnly = False
        'birthdate_picker.Enabled = True
        'GroupBox1.Enabled = True
        'cmv_status.Enabled = True
        ts_save .Visible = True
        ts_cancel.Visible = True
        ts_edit.Visible = False
        ts_close.Visible = False
        txt_houseno.ReadOnly = False
        txt_street.ReadOnly = False
        cmb_barangay.Enabled = True
        cmb_municipality.Enabled = True
        cmb_province.Enabled = True
        cmb_region.Enabled = True
        txt_mobileno.ReadOnly = False
        txt_telno.ReadOnly = False
        txt_email.ReadOnly = False
        txt_uname.ReadOnly = False
        txt_pword.ReadOnly = False
        chk_isactive.Enabled = True
    End Sub
    Private Sub disable_fields()
        txt_fname.ReadOnly = True
        txt_mname.ReadOnly = True
        txt_lname.ReadOnly = True
        ts_save.Visible = False
        ts_cancel.Visible = False
        ts_edit.Visible = True
        ts_close.Visible = True
        txt_houseno.ReadOnly = True
        txt_street.ReadOnly = True
        cmb_barangay.Enabled = False
        cmb_municipality.Enabled = False
        cmb_province.Enabled = False
        cmb_region.Enabled = False
        txt_mobileno.ReadOnly = True
        txt_telno.ReadOnly = True
        txt_email.ReadOnly = True
        txt_uname.ReadOnly = True
        txt_pword.ReadOnly = True
        chk_isactive.Enabled = False
    End Sub

    Private Sub View_Secretary_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub btn_gcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        disable_fields()
        fill_fields()
    End Sub
    Private Sub validation()
        errormsg = ""
        Dim ctr As Integer = 0
        If txt_fname.Text = "" Then
            errormsg = "First Name"
            ctr = 1
        End If
        If txt_lname.Text = "" Then
            If ctr = 1 Then
                errormsg = errormsg + " , Last Name"
            Else
                errormsg = "Last Name"
            End If
            ctr = 1
        End If


        If cmb_barangay.SelectedIndex < 0 Then
            If ctr = 1 Then
                errormsg = errormsg + " and Please Fill Either of the Address Field"
            Else
                errormsg = "Please Fill Either of the Address Field"
            End If
            ctr = 1
        Else
            If Not email_checker Then
                ctr = 1
                If errormsg = "" Then
                    errormsg = "Invalid E-mail Address"
                Else
                    errormsg = errormsg + " and E-mail Address is invalid"
                End If
            End If
        End If
        If ctr = 1 Then
            ts_save.ForeColor = Color.Gray
        Else
            If txt_uname.Text = "" Or txt_pword.Text = "" Then
                MsgBox("User Name and Password must not empty")
                ts_save.ForeColor = Color.Gray
            Else
                ts_save.ForeColor = Color.Black
            End If

        End If
    End Sub
    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged
        Try
            If Not txt_email.Text = "" Then
                Dim m As New System.Net.Mail.MailAddress(txt_email.Text)
                lbl_invalid_email.Visible = False
            End If
            email_checker = True
            validation()

        Catch ex As Exception
            lbl_invalid_email.Visible = True
            email_checker = False
            validation()
        End Try
    End Sub

    Private Sub txt_fname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.TextChanged
        validation()
    End Sub

    Private Sub txt_mobileno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mobileno.TextChanged
        validation()
    End Sub

    Private Sub txt_pword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pword.TextChanged
        validation()
    End Sub

    Private Sub txt_uname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_uname.TextChanged
        validation()
    End Sub

    Private Sub txt_province_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validation()
    End Sub

    Private Sub txt_city_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validation()
    End Sub

    Private Sub txt_barangay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validation()
    End Sub

    Private Sub txt_street_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_street.TextChanged
        validation()
    End Sub

    Private Sub txt_houseno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_houseno.TextChanged
        validation()
    End Sub

    Private Sub txt_lname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.TextChanged
        validation()
    End Sub

    Private Sub txt_mname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mname.TextChanged
        validation()
    End Sub

    Private Sub txt_telno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telno.TextChanged
        validation()
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        If ts_save.ForeColor = Color.Black Then
            Verification.action_verified = 2
            Verification.ShowDialog()
        Else
            If Not errormsg = "" Then
                MsgBox("Please Complete the following: " + errormsg, MsgBoxStyle.OkOnly, "Clinic App")
            End If
        End If
    End Sub
    Public Sub update_secretary_profile()
        Try
            Dim cmd As New MySqlCommand
            cmd = New MySqlCommand("UPDATE `secretaries` SET `username`=@uname,`password`=@pword," +
                                   "`lname`=@lname,`mname`=@mname,`fname`=@fname," +
                                   "`address_house_no`=@houseno,`address_street`=@street,`barangay_id`=@brgy," +
                                   "`cell_no`=@celno,`tel_no`=@telno," +
                                   "`email`=@email,`updated_at`=CURRENT_TIMESTAMP where id=@id", conn)
            cmd.Parameters.AddWithValue("uname", txt_uname.Text)
            cmd.Parameters.AddWithValue("pword", txt_pword.Text)
            cmd.Parameters.AddWithValue("fname", txt_fname.Text)
            cmd.Parameters.AddWithValue("mname", txt_mname.Text)
            cmd.Parameters.AddWithValue("lname", txt_lname.Text)
            cmd.Parameters.AddWithValue("houseno", txt_houseno.Text)
            cmd.Parameters.AddWithValue("street", txt_street.Text)
            cmd.Parameters.AddWithValue("brgy", cmb_barangay.SelectedValue.ToString)
            cmd.Parameters.AddWithValue("celno", txt_mobileno.Text)
            cmd.Parameters.AddWithValue("telno", txt_telno.Text)
            cmd.Parameters.AddWithValue("email", txt_email.Text)
            cmd.Parameters.AddWithValue("id", secretary_id.ToString)
            cmd.ExecuteNonQuery()


            If chk_isactive.Checked = True And isactive = 0 Then
                cmd = New MySqlCommand("INSERT INTO `secretary_access`(`clinic_id`, `doctor_id`, `secretary_id`) VALUES (@clinic_id,@doctor_id,@sec_id)", conn)
                cmd.Parameters.AddWithValue("sec_id", secretary_id.ToString)
                cmd.Parameters.AddWithValue("doctor_id", UserId.ToString)
                cmd.Parameters.AddWithValue("clinic_id", My.Settings.ClinicID.ToString)
                cmd.ExecuteNonQuery()
            ElseIf chk_isactive.Checked = False And isactive = 1 Then
                    cmd = New MySqlCommand("DELETE FROM `secretary_access` WHERE clinic_id=@clinic_id AND doctor_id=@doctor_id AND secretary_id=@sec_id", conn)
                    cmd.Parameters.AddWithValue("sec_id", secretary_id.ToString)
                    cmd.Parameters.AddWithValue("doctor_id", UserId.ToString)
                    cmd.Parameters.AddWithValue("clinic_id", My.Settings.ClinicID.ToString)
                    cmd.ExecuteNonQuery()
            End If

            MsgBox("New Update Saved", MsgBoxStyle.OkOnly, "Clinic App")
            disable_fields()
            fname = txt_fname.Text
            lname = txt_lname.Text()
            mname = txt_mname.Text
            mobileno = txt_mobileno.Text
            telno = txt_telno.Text
            txt_email.Text = email
            houseno = txt_houseno.Text
            street = txt_street.Text
            barangay = cmb_barangay.SelectedValue
            municipality = cmb_municipality.SelectedValue
            province = cmb_province.SelectedValue
            region_id = cmb_region.SelectedValue
            uname = txt_uname.Text
            pword = txt_pword.Text
            If (secretary.txt_search.Text = "Search Secretary Here") Then
                secretary.display_secretaries("")
            Else
                secretary.display_secretaries(secretary.txt_search.Text)
            End If

            If chk_isactive.Checked = True Then
                isactive = 1
            Else
                isactive = 0
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ts_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_close.Click
        Me.Dispose()
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
        validation()
    End Sub
End Class