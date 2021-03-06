﻿Imports System.Text.StringBuilder
Imports System.IO
Public Class View_patient
    Private selected_index As Integer = 0
    Public patient_id As Integer = 0
    Private history As New patient_history
    Private testresult As New test_result
    Private testresult_tag As Boolean = False
    Private history_tag As Boolean = True
    Private profilename As String = ""
    Private temppath As String = Path.GetTempPath()
    Private tempprofilepic As String = ""
#Region "Variables"
    Private DT_Region As New DataTable
    Private DT_Province As New DataTable
    Private DT_Municipality As New DataTable
    Private DT_Barangay As New DataTable
    Private DT_PatientInfo As New DataTable
#End Region
    Private Sub Patient_History_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        imagedialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"


        testresult.patient_id = Me.patient_id
        history.patient_id = Me.patient_id
        history.MdiParent = Me
        history.Parent = Me.patient_info_container
        history.Show()
        testresult.Hide()
        display_regions()
        display_patient_info(patient_id)
    End Sub
    Private Sub display_patient_info(ByRef id As Integer)
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@id"}
            Dim Param_Value As String() = {2, 3, patient_id}
            Dim MyAdapter As New Custom_Adapters
            DT_PatientInfo = MyAdapter.CUSTOM_RETRIEVE("SP_Patient", Param_Name, Param_Value)
            'profilepic
            'profilename = "C:\ECE MD Clinic APP\PROFILE_PICTURES\Patients\" + ds.Tables(0).Rows(0).Item(13).ToString
            'If Not (ds.Tables(0).Rows(0).Item(13).ToString = "") And File.Exists(profilename) Then
            '    profile_pic.Image = Image.FromFile(profilename)
            '    tempprofilepic = ds.Tables(0).Rows(0).Item(13).ToString
            '    If Not File.Exists(temppath + tempprofilepic) Then
            '        My.Computer.FileSystem.CopyFile(profilename, temppath + tempprofilepic)
            '    End If

            'Else
            '    profilename = ""
            'End If

            'General Info
            txt_fname.Text = DT_PatientInfo.Rows(0).Item(1).ToString
            txt_mname.Text = DT_PatientInfo.Rows(0).Item(2).ToString
            txt_lname.Text = DT_PatientInfo.Rows(0).Item(3).ToString
            Me.Text = DT_PatientInfo.Rows(0).Item(1).ToString + " " + DT_PatientInfo.Rows(0).Item(2).ToString + " " + DT_PatientInfo.Rows(0).Item(3).ToString + " - Patient Record"
            If DT_PatientInfo.Rows(0).Item(16).ToString = "Male" Then
                rdbtn_male.Checked = True
            ElseIf DT_PatientInfo.Rows(0).Item(16).ToString = "Female" Then
                rdbtn_female.Checked = True
            End If
            If DT_PatientInfo.Rows(0).Item(17).ToString = "Single" Then
                cmv_status.SelectedIndex = 0
            ElseIf DT_PatientInfo.Rows(0).Item(17).ToString = "Married" Then
                cmv_status.SelectedIndex = 1
            ElseIf DT_PatientInfo.Rows(0).Item(17).ToString = "Widow" Then
                cmv_status.SelectedIndex = 2
            End If
            txt_occupation.Text = DT_PatientInfo.Rows(0).Item(18).ToString
            txt_height.Text = DT_PatientInfo.Rows(0).Item(19).ToString
            txt_weight.Text = DT_PatientInfo.Rows(0).Item(20).ToString


            txt_mobileno.Text = DT_PatientInfo.Rows(0).Item(10).ToString
            txt_telno.Text = DT_PatientInfo.Rows(0).Item(11).ToString
            txt_email.Text = DT_PatientInfo.Rows(0).Item(12).ToString

            txt_houseno.Text = DT_PatientInfo.Rows(0).Item(4).ToString
            cmb_region.SelectedValue = DT_PatientInfo.Rows(0).Item(9)
            cmb_province.SelectedValue = DT_PatientInfo.Rows(0).Item(8)
            cmb_municipality.SelectedValue = DT_PatientInfo.Rows(0).Item(7)
            cmb_barangay.SelectedValue = DT_PatientInfo.Rows(0).Item(6)
            birthdate_picker.Value = DT_PatientInfo.Rows(0).Item(21).ToString
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub lbl_history_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_history.MouseEnter
        lbl_history.ForeColor = Color.Blue
    End Sub

    Private Sub lbl_history_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_history.MouseLeave

        If Not testresult_tag Then
            lbl_history.ForeColor = Color.CornflowerBlue
        End If
    End Sub

    Private Sub lbl_test_results_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_test_results.MouseEnter
        lbl_test_results.ForeColor = Color.Blue
    End Sub

    Private Sub lbl_test_results_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_test_results.MouseLeave

        If Not history_tag Then
            lbl_test_results.ForeColor = Color.CornflowerBlue
        End If
    End Sub


    Private Sub lbl_history_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_history.Click
        testresult.Hide()
        history_tag = False
        testresult_tag = True
        lbl_history.ForeColor = Color.Blue
        lbl_test_results.ForeColor = Color.CornflowerBlue
        history_bar.FillColor = Color.Cyan
        results_bar.FillColor = Color.LightGray
    End Sub

    Private Sub lbl_test_results_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_test_results.Click
        testresult.MdiParent = Me
        testresult.Parent = Me.patient_info_container
        testresult.Show()
        history.Hide()
        history_tag = True
        testresult_tag = False
        lbl_history.ForeColor = Color.CornflowerBlue
        lbl_test_results.ForeColor = Color.Blue
        history_bar.FillColor = Color.LightGray
        results_bar.FillColor = Color.Cyan
    End Sub

    Private Sub View_patient_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        history.Close()
        testresult.Close()
    End Sub

    'Private Sub profile_pic_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles profile_pic.MouseEnter
    '    context_replace.Show(profile_pic, 77, 220)
    'End Sub

    Private Sub profile_pic_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles profile_pic.MouseHover
        If Not profilename = "" Then
            changeprofile.Text = "Update Picture"
            RemoveProfilePictureToolStripMenuItem.Visible = True
            context_replace.Show(profile_pic, 10, 73)
        Else
            changeprofile.Text = "Add Picture"
            RemoveProfilePictureToolStripMenuItem.Visible = False
            context_replace.Show(profile_pic, 10, 94)
        End If
    End Sub

    Private Sub changeprofile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles changeprofile.Click
        Try
            'If imagedialog.ShowDialog = DialogResult.OK Then
            '    Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(imagedialog.FileName)
            '    Dim extention As String = System.IO.Path.GetExtension(imagedialog.FileName)
            '    Dim filepath As String = imagedialog.FileName
            '    Dim newfilename As String = randomstring(filename) + extention
            '    While File.Exists("C:\ECE MD Clinic APP\PROFILE_PICTURES\Patients\" + newfilename)
            '        newfilename = randomstring(filename) + extention
            '    End While
            '    If Not profilename = "" Then
            '        profile_pic.Image.Dispose()
            '    End If
            '    profile_pic.Image = Image.FromFile(imagedialog.FileName)
            '    Dim res As MsgBoxResult
            '    res = MsgBox("Are you sure you want to SAVE this Profile Pic", MsgBoxStyle.YesNoCancel, "Warning!")
            '    If res = MsgBoxResult.Yes Then
            '        cmd = New SqlCommand("update patients set photo=@param1 where id=" + patient_id.ToString, conn)
            '        cmd.Parameters.AddWithValue("param1", newfilename)
            '        cmd.ExecuteNonQuery()
            '        My.Computer.FileSystem.CopyFile(filepath, "C:\ECE MD Clinic APP\PROFILE_PICTURES\Patients\" + newfilename)
            '        My.Computer.FileSystem.CopyFile(filepath, temppath + newfilename)
            '        If File.Exists(profilename) And Not profilename = "" Then
            '            My.Computer.FileSystem.DeleteFile(profilename, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            '            My.Computer.FileSystem.DeleteFile(temppath + tempprofilepic, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

            '        End If
            '        profilename = "C:\ECE MD Clinic APP\PROFILE_PICTURES\Patients\" + newfilename
            '        tempprofilepic = newfilename
            '    Else
            '        profile_pic.Image = Image.FromFile(profilename)
            '    End If

            'End If
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

    Private Sub RemoveProfilePictureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveProfilePictureToolStripMenuItem.Click
        'Try
        '    Dim res As MsgBoxResult
        '    res = MsgBox("Are you sure you want to REMOVE this Profile Picture", MsgBoxStyle.YesNo, "Warning!")
        '    If res = MsgBoxResult.Yes Then

        '        profile_pic.Image.Dispose()
        '        profile_pic.Image = Image.FromFile("C:\ECE MD Clinic APP\PROFILE_PICTURES\default_profile.png")
        '        If File.Exists(profilename) Then
        '            My.Computer.FileSystem.DeleteFile(profilename, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        '        End If
        '        profilename = ""
        '        cmd = New SqlCommand("update patients set photo='' where id=" + patient_id.ToString, conn)
        '        cmd.ExecuteNonQuery()
        '    End If
        'Catch ex As Exception
        '    profile_pic.Image = Image.FromFile(profilename)
        'End Try

    End Sub

    Private Sub profile_pic_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles profile_pic.MouseDoubleClick
        'If File.Exists(temppath + tempprofilepic) Then
        '    Process.Start("C:\windows\system32\rundll32.exe", "C:\WINDOWS\System32\shimgvw.dll,ImageView_Fullscreen " & temppath + tempprofilepic)
        'Else
        '    If Not profilename = "" Then
        '        My.Computer.FileSystem.CopyFile(profilename, temppath + tempprofilepic)
        '        Process.Start("C:\windows\system32\rundll32.exe", "C:\WINDOWS\System32\shimgvw.dll,ImageView_Fullscreen " & temppath + tempprofilepic)
        '    End If

        'End If
    End Sub

    Private Sub View_patient_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                Me.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ts_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_edit.Click
        enable_fields()
    End Sub
    Private Sub disable_fields()
        txt_fname.ReadOnly = True
        txt_mname.ReadOnly = True
        txt_lname.ReadOnly = True
        birthdate_picker.Enabled = False
        group_gender.Enabled = False
        txt_occupation.ReadOnly = True
        cmv_status.Enabled = False
        txt_height.ReadOnly = True
        txt_weight.ReadOnly = True
        txt_reffered_by.ReadOnly = True
        txt_houseno.ReadOnly = True
        cmb_barangay.Enabled = False
        cmb_municipality.Enabled = False
        cmb_province.Enabled = False
        cmb_region.Enabled = False
        txt_chief_complaint.ReadOnly = True
        txt_medication.ReadOnly = True
        dtp_enrolled.Enabled = False
        txt_mother.ReadOnly = True
        txt_father.ReadOnly = True
        txt_mobileno.ReadOnly = True
        txt_telno.ReadOnly = True
        txt_email.ReadOnly = True
        ts_save.Visible = False
        ts_edit.Visible = True
        ts_cancel.Visible = False
    End Sub
    Private Sub enable_fields()
        txt_fname.ReadOnly = False
        txt_mname.ReadOnly = False
        txt_lname.ReadOnly = False
        birthdate_picker.Enabled = True
        group_gender.Enabled = True
        txt_occupation.ReadOnly = False
        cmv_status.Enabled = True
        txt_height.ReadOnly = False
        txt_weight.ReadOnly = False
        txt_reffered_by.ReadOnly = False
        txt_houseno.ReadOnly = False
        cmb_barangay.Enabled = True
        cmb_municipality.Enabled = True
        cmb_province.Enabled = True
        cmb_region.Enabled = True
        txt_chief_complaint.ReadOnly = False
        txt_medication.ReadOnly = False
        dtp_enrolled.Enabled = True
        txt_mother.ReadOnly = False
        txt_father.ReadOnly = False
        txt_mobileno.ReadOnly = False
        txt_telno.ReadOnly = False
        txt_email.ReadOnly = False
        ts_save.Visible = True
        ts_edit.Visible = False
        ts_cancel.Visible = True
    End Sub

    Private Sub ts_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_cancel.Click
        disable_fields()
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Try
            Dim MyAdapter As New Custom_Adapters
            Dim Sex As String = ""
            If rdbtn_female.Checked = True Then
                Sex = "Female"
            ElseIf rdbtn_male.Checked = True Then
                Sex = "Male"
            End If
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@id",
                                          "@fname", "@mname", "@lname",
                                          "@occupation", "@birthdate", "@sex",
                                          "@civil_status", "@height", "@weight",
                                          "@email", "@mobile", "@tel",
                                          "@houseno", "@barangay_id"}
            Dim Param_Value As String() = {1, 1, patient_id,
                                           txt_fname.Text, txt_mname.Text, txt_lname.Text,
                                           txt_occupation.Text, birthdate_picker.Value.ToString("yyyy-MM-dd"), Sex,
                                           cmv_status.SelectedText, txt_height.Text, txt_weight.Text,
                                           txt_email.Text, txt_mobileno.Text, txt_telno.Text,
                                           txt_houseno.Text, cmb_barangay.SelectedValue.ToString}

            If MyAdapter.CUSTOM_TRANSACT("SP_Patient", Param_Name, Param_Value) Then
                MsgBox("New Update Saved", MsgBoxStyle.OkOnly, "Clinic App")
            Else
                MsgBox("Saving Failed", MsgBoxStyle.OkOnly, "Clinic App")
            End If

        Catch ex As Exception
        End Try
        disable_fields()
    End Sub
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
            DT_Barangay.Clear()
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

    Private Sub ts_credentials_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_credentials.Click
        If UserType = 0 Then
            MsgBox("Access Denied For Now!")
        Else
            Patient_Credentials.Patient_ID = Me.patient_id
            Patient_Credentials.ShowDialog()
        End If
    End Sub
End Class