Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class New_Secretary
    Private da As New MySqlDataAdapter
    Private dsaddress As New DataSet

    Private email_checker As Boolean = True
    Private errormsg As String = ""
    Private loaded As Boolean = False
    Private secretary_info_arr(10) As String
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.Dispose()
    End Sub
#Region "on_enter"
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

    Private Sub txt_uname_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_uname.Enter
        With txt_uname
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_pword_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pword.Enter
        With txt_pword
            .Clear()
            .ForeColor = Color.Black
            .UseSystemPasswordChar = True
        End With
    End Sub

    Private Sub txt_confirmpword_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_confirmpword.Enter
        With txt_confirmpword
            .Clear()
            .ForeColor = Color.Black
            .UseSystemPasswordChar = True
        End With
    End Sub

    Private Sub txt_uname_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_uname.Leave
        If txt_uname.Text = "" Then
            With txt_uname
                .Text = "User Name"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_pword_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pword.Leave
        If txt_pword.Text = "" Then
            With txt_pword
                .Text = "Password"
                .ForeColor = Color.Gray
                .UseSystemPasswordChar = False
            End With
        End If
    End Sub

    Private Sub txt_confirmpword_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_confirmpword.Leave
        If txt_confirmpword.Text = "" Then
            With txt_confirmpword
                .Text = "Confirm Password"
                .ForeColor = Color.Gray
                .UseSystemPasswordChar = False
            End With
        End If
    End Sub
#End Region

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click

    End Sub

    Private Sub btn_finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
        If btn_save.ForeColor = Color.Gray Then
            MsgBox(errormsg)
        Else
            collect_data()
            Try
                Dim cmd As New MySqlCommand
                Dim insert_str As String = "Insert into secretaries " +
                                            "( `fname`, `mname`, `lname`, `username`, `password`, `address_house_no`, `address_street`, `barangay_id`, `cell_no`, `tel_no`, `email`, `created_at`) values" +
                                            " (@fname,@mname,@lname,@uname,@pword,@houseno,@street,@barangay,@mobile,@tel,@email,CURRENT_TIMESTAMP)"

                cmd = New MySqlCommand(insert_str, conn)
                cmd.Parameters.AddWithValue("fname", secretary_info_arr(0))
                cmd.Parameters.AddWithValue("mname", secretary_info_arr(1))
                cmd.Parameters.AddWithValue("lname", secretary_info_arr(2))
                cmd.Parameters.AddWithValue("uname", secretary_info_arr(3))
                cmd.Parameters.AddWithValue("pword", secretary_info_arr(4))
                cmd.Parameters.AddWithValue("houseno", secretary_info_arr(5))
                cmd.Parameters.AddWithValue("street", secretary_info_arr(6))
                cmd.Parameters.AddWithValue("barangay", secretary_info_arr(7))
                'cmd.Parameters.AddWithValue("photo", filename)
                cmd.Parameters.AddWithValue("mobile", secretary_info_arr(8))
                cmd.Parameters.AddWithValue("tel", secretary_info_arr(9))
                cmd.Parameters.AddWithValue("email", secretary_info_arr(10))
                cmd.ExecuteNonQuery()
                Dim da As New MySqlDataAdapter
                da = New MySqlDataAdapter("select max(id) from secretaries ", conn)
                Dim ds As New DataSet
                da.Fill(ds)
                Dim id As Integer = ds.Tables(0).Rows(0).Item(0)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim cid As Integer = My.Settings.ClinicID
                    cmd = New MySqlCommand("INSERT INTO `clinic_secretary`(`clinic_id`, `secretary_id`) VALUES (" + cid.ToString + "," + id.ToString + ")", conn)
                    cmd.ExecuteNonQuery()
                    secretary.display_secretaries("")
                    'INSERT INTO `clinic_secretary`(`clinic_id`, `secretary_id`, `is_active`) VALUES ([value-1],[value-2],[value-3])
                    MsgBox("New Secretary has been saved!")
                End If
                If chk_isactive.Checked = True Then
                    cmd = New MySqlCommand("INSERT INTO `secretary_access`(`clinic_id`, `doctor_id`, `secretary_id`) VALUES (@clinic_id,@doctor_id,@sec_id)", conn)
                    cmd.Parameters.AddWithValue("sec_id", id.ToString)
                    cmd.Parameters.AddWithValue("doctor_id", UserId.ToString)
                    cmd.Parameters.AddWithValue("clinic_id", My.Settings.ClinicID.ToString)
                    cmd.ExecuteNonQuery()
                End If
                secretary.display_secretaries("")
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub
    Private Sub collect_data()

        secretary_info_arr(0) = txt_fname.Text
        If txt_mname.Text = "Middle Name" Then
            secretary_info_arr(1) = ""
        Else
            secretary_info_arr(1) = txt_mname.Text
        End If
        secretary_info_arr(2) = txt_lname.Text
        secretary_info_arr(3) = txt_uname.Text
        secretary_info_arr(4) = txt_pword.Text

        If txt_houseno.Text = "House No." Then
            secretary_info_arr(5) = ""
        Else
            secretary_info_arr(5) = txt_houseno.Text
        End If
        If txt_street.Text = "Street" Then
            secretary_info_arr(6) = ""
        Else
            secretary_info_arr(6) = txt_street.Text
        End If
        secretary_info_arr(7) = cmb_barangay.SelectedValue.ToString

        If txt_mobileno.Text = "Mobile No." Then
            secretary_info_arr(8) = ""
        Else
            secretary_info_arr(8) = txt_mobileno.Text
        End If
        If txt_telno.Text = "Telephone No." Then
            secretary_info_arr(9) = ""
        Else
            secretary_info_arr(9) = txt_telno.Text
        End If
        If txt_email.Text = "E-mail Address" Then
            secretary_info_arr(10) = ""
        Else
            secretary_info_arr(10) = txt_email.Text
        End If
    End Sub
    Private Sub validation()
        If loaded Then
            errormsg = ""
            Dim ctr As Integer = 0
            If txt_fname.Text = "First Name" Then
                errormsg = "Please Fill First Name"
                ctr = 1
            End If
            If txt_lname.Text = "Last Name" Then
                If ctr = 1 Then
                    errormsg = errormsg + " , Last Name"
                Else
                    errormsg = "Please Fill Last Name"
                End If
                ctr = 1
            End If


            If cmb_barangay.SelectedIndex < 0 Then
                If ctr = 1 Then
                    errormsg = errormsg + " and Address Fields"
                Else
                    errormsg = "Please Fill Address Fields"
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
                btn_save.ForeColor = Color.Gray
            Else
                If txt_uname.Text = "User Name" Or txt_pword.Text = "Password" Then
                    errormsg = "User Name and Password must be filled"
                    btn_save.ForeColor = Color.Gray
                Else
                    If txt_uname.Text.Length < 4 Or txt_pword.Text.Length < 4 Then
                        errormsg = "User Name and Password must be 4 to 15 Characters"


                    Else
                        If txt_confirmpword.Text = "Confirmed Password" Then
                            errormsg = "Please Confirm Password "
                            btn_save.ForeColor = Color.Gray
                        Else
                            If txt_confirmpword.Text = txt_pword.Text Then
                                btn_save.ForeColor = Color.Black
                            Else
                                errormsg = "Password Does not Match"
                                btn_save.ForeColor = Color.Gray
                            End If
                        End If

                    End If
                End If

            End If
        End If

    End Sub
#Region "For Validation"
    Private Sub txt_fname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_fname.TextChanged
        validation()
    End Sub

    Private Sub txt_pword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pword.TextChanged
        validation()
    End Sub

    Private Sub txt_uname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_uname.TextChanged
        validation()
    End Sub

    Private Sub txt_email_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_email.TextChanged
        validation()
    End Sub

    Private Sub txt_telno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_telno.TextChanged
        validation()
    End Sub

    Private Sub txt_mobileno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mobileno.TextChanged
        validation()
    End Sub

    Private Sub txt_zip_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        validation()
    End Sub
    Private Sub txt_lname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_lname.TextChanged
        validation()
    End Sub

    Private Sub txt_mname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_mname.TextChanged
        validation()
    End Sub

    Private Sub txt_confirmpword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_confirmpword.TextChanged
        validation()
    End Sub

    Private Sub New_Secretary_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        loaded = True
    End Sub
#End Region

    Private Sub New_Secretary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dsaddress.Tables.Add("regions")
        dsaddress.Tables.Add("provinces")
        dsaddress.Tables.Add("municipalities")
        dsaddress.Tables.Add("barangays")
        display_regions()
    End Sub
    Private Sub display_regions()
        Try            dsaddress.Clear()
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