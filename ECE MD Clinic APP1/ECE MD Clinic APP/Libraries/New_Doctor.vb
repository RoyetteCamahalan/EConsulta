Public Class New_Doctor
    'Private filepath As String = ""
    Dim filename As String = ""
    Private Sub New_Doctor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        birthdate_picker.CustomFormat = "hh:mm tt"
        birthdate_picker.Value = Date.Now
        imagedialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
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

    Private Sub txt_prc_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_prc.Enter
        With txt_prc
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
    Private Sub txt_prc_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_prc.Leave
        If txt_prc.Text = "" Then
            With txt_prc
                .Text = "PRC No."
                .ForeColor = Color.Gray
            End With
        End If
    End Sub
    Private Sub txt_specialty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_specialty.Enter
        With txt_specialty
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_subspecialty_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_subspecialty.Enter
        With txt_subspecialty
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_affiliation_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_affiliation.Enter
        With txt_affiliation
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_specialty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_specialty.Leave
        If txt_specialty.Text = "" Then
            With txt_specialty
                .Text = "Specialty"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_subspecialty_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_subspecialty.Leave
        If txt_subspecialty.Text = "" Then
            With txt_subspecialty
                .Text = "Sub-Specialty"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_affiliation_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_affiliation.Leave
        If txt_affiliation.Text = "" Then
            With txt_affiliation
                .Text = "Affiliation"
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

    Private Sub txt_barangay_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_barangay.Enter
        With txt_barangay
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_city_municipality_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_city_municipality.Enter
        With txt_city_municipality
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_province_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_province.Enter
        With txt_province
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_zip_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_zip.Enter
        With txt_zip
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
        With txt_email
            .Clear()
            .ForeColor = Color.Black
        End With
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

    Private Sub txt_barangay_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_barangay.Leave
        If txt_barangay.Text = "" Then
            With txt_barangay
                .Text = "Barangay"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_city_municipality_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_city_municipality.Leave
        If txt_city_municipality.Text = "" Then
            With txt_city_municipality
                .Text = "City/ Municipality"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub txt_province_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_province.Leave
        If txt_province.Text = "" Then
            With txt_province
                .Text = "Province"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub
    Private Sub txt_zip_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_zip.Leave
        If txt_zip.Text = "" Then
            With txt_zip
                .Text = "Zip Code"
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
        End If
    End Sub
#End Region
#Region "Text Box hint effect on account info"
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
    Private Sub validate_gen_info()
        If txt_fname.Text = "First Name" Or txt_fname.Text = "" Or txt_lname.Text = "Last Name" Or txt_lname.Text = "" Or txt_prc.Text = "" Or txt_prc.Text = "PRC No." Or txt_specialty.Text = "" Or txt_specialty.Text = "Specialty" Then
            btn_next_geninfo.Enabled = False
        Else
            btn_next_geninfo.Enabled = True
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
    Private Sub txt_prc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_prc.TextChanged
        If Not (txt_prc.Text = "PCR No." Or txt_prc.Text = "") Then
            validate_gen_info()
        Else
            btn_next_geninfo.Enabled = False
        End If
    End Sub

    Private Sub txt_specialty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_specialty.TextChanged
        If Not (txt_specialty.Text = "Last Name" Or txt_specialty.Text = "") Then
            validate_gen_info()
        Else
            btn_next_geninfo.Enabled = False
        End If
    End Sub

    Private Sub btn_next_geninfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next_geninfo.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If btn_next_geninfo.Enabled = False Then
            e.Cancel = True
        ElseIf btn_next_contact_info.Enabled = False And e.TabPageIndex = 2 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TabControl1.SelectedIndex = 1
    End Sub
    Private Sub validate_contact_info()
        If (txt_houseno.Text = "House No." Or txt_houseno.Text = "") And (txt_street.Text = "Street" Or txt_street.Text = "") And (txt_barangay.Text = "Barangay" Or txt_barangay.Text = "") And (txt_city_municipality.Text = "City/ Municipality" Or txt_city_municipality.Text = "") And (txt_province.Text = "Province" Or txt_province.Text = "") Then
            btn_next_contact_info.Enabled = False
        Else
            btn_next_contact_info.Enabled = True
        End If
    End Sub
    Private Sub validate_account_info()
        If txt_uname.Text = "User Name" Or txt_uname.Text = "" Or txt_pword.Text = "Password" Or txt_pword.Text = "" Or txt_confirmpword.Text = "Confirm Password" Or txt_confirmpword.Text = "" Then
            btn_finish.Enabled = False
        Else
            If Not (txt_pword.Text = txt_confirmpword.Text) Then
                btn_finish.Enabled = False
            Else
                btn_finish.Enabled = True
            End If
        End If
    End Sub

    Private Sub txt_houseno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_houseno.TextChanged
        validate_contact_info()
    End Sub

    Private Sub txt_street_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_street.TextChanged
        validate_contact_info()
    End Sub

    Private Sub txt_barangay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_barangay.TextChanged
        validate_contact_info()
    End Sub

    Private Sub txt_city_municipality_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_city_municipality.TextChanged
        validate_contact_info()
    End Sub

    Private Sub txt_province_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_province.TextChanged
        validate_contact_info()
    End Sub

    Private Sub txt_uname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_uname.TextChanged
        validate_account_info()
    End Sub

    Private Sub txt_pword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_pword.TextChanged
        validate_account_info()
    End Sub

    Private Sub txt_confirmpword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_confirmpword.TextChanged
        validate_account_info()
    End Sub

    Private Sub btn_finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finish.Click
        Try
            'My.Computer.FileSystem.CopyFile(filename, "C:\ECE MD Clinic APP\PROFILE_PICTURES\Doctors\doctor.png")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub collect_data()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If imagedialog.ShowDialog() = DialogResult.OK Then
                filename = imagedialog.FileName
                profile_img.Image = Image.FromFile(filename)
                'filepath = filename.Substring(0, filename.LastIndexOf("\") + 1)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class