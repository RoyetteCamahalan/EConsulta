Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Consultation
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private cmd As New MySqlCommand
    Dim w As Integer = 221
    Dim h As Integer = 99
    Private lastitem As Integer = 0
    Private firstitem As Integer = 0
    Dim limit As Integer = 10
    Private Sub Consultation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_allappointment.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_allappointment.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_allappointment.RowTemplate.Height = 35
        dtgv_allappointment.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.Size = New System.Drawing.Size(w, h)
        Timer1.Start()
        display_all("")
        
    End Sub
#Region "entrance and exit"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '1121, 519
        '273, 231
        w = w + 90
        h = h + 42
        If w <= 1121 Then
            Me.Size = New System.Drawing.Size(w, h)
        Else
            Timer1.Stop()
            w = 221
            h = 99
        End If
    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        txt_search.Clear()
    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not (txt_search.Text = "Search Patient here") Then
            display_all(" AND (p.lname like '%" + txt_search.Text + "%' or p.fname like '%" + txt_search.Text + "%' or p.mname like '%" + txt_search.Text + "%')")
        End If
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = "Search Patient here"
        End If
    End Sub
#End Region
    Public Sub display_all(ByRef search As String)
        Dim str As String
        If UserType = 0 Then 'secretary
            str = "select pc.id,p.id as patient_id,concat(p.fname,' ',p.mname,' ',p.lname)as 'Patient Name',CONCAT(pc.date,' ',pc.time) as Date," +
                                        " d.id,concat(d.fname,' ',d.mname,' ',d.lname) as Doctor,'' dummy,pc.created_at as 'Encoded Date'," +
                                        " case WHEN pc.isdone=0 THEN 'Pending' when pc.isdone=1 then 'Done'  when pc.isdone=2 then 'Postponed'end as 'Status', case WHEN pc.isdone=1 THEN 'View Details' else 'Options...' end as Actions,pc.updated_at,pc.patient_record_id   from doctors d" +
                                        " INNER JOIN patient_consultations pc on pc.doctor_id=d.id" +
                                        " INNER JOIN patients p on p.id=pc.patient_id inner join secretary_access sc on sc.doctor_id=d.id where sc.secretary_id=" + UserId.ToString + search + " order by pc.date"
        Else 'doctor
            str = "select pc.id,p.id as patient_id,concat(p.fname,' ',p.mname,' ',p.lname)as 'Patient Name',CONCAT(pc.date,' ',pc.time) as Date," +
                                            " d.id,concat(d.fname,' ',d.mname,' ',d.lname) as Doctor,'' dummy,pc.created_at as 'Encoded Date'," +
                                            " case WHEN pc.isdone=0 THEN 'Pending' when pc.isdone=1 then 'Done'  when pc.isdone=2 then 'Postponed'end as 'Status', case WHEN pc.isdone=1 THEN 'View Details' else 'Options...' end as Actions,pc.updated_at,pc.patient_record_id   from doctors d" +
                                            " INNER JOIN patient_consultations pc on pc.doctor_id=d.id" +
                                            " INNER JOIN patients p on p.id=pc.patient_id where d.id=" + UserId.ToString + search + " order by pc.date"

        End If

        Try
            lastitem = -1
            firstitem = 0
            ds.Clear()
            da = New MySqlDataAdapter(str, conn)
            da.Fill(ds)
            dtgv_allappointment.Rows.Clear()
            Dim dslength As Integer = ds.Tables(0).Rows.Count
            With ds.Tables(0)
                If dslength > 0 Then
                    For i = 0 To limit

                        If lastitem = dslength - 1 Then
                            btn_next.Visible = False
                            Exit For
                        Else
                            firstitem = 0

                            dtgv_allappointment.Rows.Add(.Rows(i).Item(0),
                                                                            .Rows(i).Item(1),
                                                                           .Rows(i).Item(2).ToString,
                                                                           .Rows(i).Item(3),
                                                                           .Rows(i).Item(4),
                                                                           .Rows(i).Item(5).ToString,
                                                                           .Rows(i).Item(6).ToString,
                                                                           .Rows(i).Item(7).ToString,
                                                                           .Rows(i).Item(8).ToString,
                                                                           .Rows(i).Item(9).ToString,
                                                                           .Rows(i).Item(10).ToString,
                                                                           .Rows(i).Item(11)
                                                   )
                            Dim lastindex As Integer = dtgv_allappointment.Rows.Count - 1
                            Select Case .Rows(i).Item(8).ToString
                                Case "Done"
                                    dtgv_allappointment.Rows(lastindex).DefaultCellStyle.BackColor = Color.LightGreen
                            End Select
                            btn_next.Visible = True
                            btn_back.Visible = False
                        End If

                        lastitem = i
                    Next
                End If

            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub dtgv_allappointment_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_allappointment.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If (myCol = 9 Or myCol = 2) And myRow <> -1 Then
                dtgv_allappointment.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Underline)
                dtgv_allappointment.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_allappointment.Cursor = Cursors.Hand
                dtgv_allappointment.Rows(myRow).DefaultCellStyle.BackColor = Color.LightBlue
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtgv_allappointment_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_allappointment.CellMouseLeave
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If (myCol = 9 Or myCol = 2) And myRow <> -1 Then
                dtgv_allappointment.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Modern No. 20", 12, FontStyle.Regular)
                dtgv_allappointment.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_allappointment.Cursor = Cursors.Arrow
                dtgv_allappointment.Rows(myRow).DefaultCellStyle.BackColor = Color.White
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtgv_allappointment_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgv_allappointment.MouseMove
        Try
            Dim hit As DataGridView.HitTestInfo = dtgv_allappointment.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                Dim myRow As Integer = hit.RowIndex
                Dim myCol As Integer = hit.ColumnIndex
                If (myCol <> 9 Or myCol <> 2) And myRow <> -1 And Not dtgv_allappointment.Rows(myRow).Cells(10).Value.ToString = "" Then
                    Dim tempdate As Date = dtgv_allappointment.Rows(myRow).Cells(10).Value
                    Dim msg As String = ""
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
                    dtgv_allappointment.Rows(myRow).Cells(myCol).ToolTipText = msg
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgv_allappointment_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_allappointment.CellClick
        Try
            Dim myRow As Integer = dtgv_allappointment.CurrentRow.Index
            Dim myCol As Integer = dtgv_allappointment.CurrentCell.ColumnIndex
            If myCol = 9 And myRow <> -1 Then
                If dtgv_allappointment.Rows(myRow).Cells(8).Value.ToString = "Done" Then
                    Try
                        Dim dsdetails As New DataSet
                        da = New MySqlDataAdapter("SELECT pr.`id`, pr.`patient_id`, pr.`doctor_id`, pr.`complaints`, pr.`findings`, pr.`created_at`, pr.`updated_at` FROM `patient_records` pr INNER JOIN patient_consultations pc on pc.patient_record_id=pr.id WHERE pc.id=" + dtgv_allappointment.CurrentRow.Cells(0).Value.ToString, conn)
                        da.Fill(dsdetails)
                        If dsdetails.Tables(0).Rows.Count > 0 Then
                            new_consult.what_to_do = 1
                            new_consult.title_text = "View Consultation"
                            new_consult.appointment_id = dsdetails.Tables(0).Rows(0).Item(0)
                            new_consult.doctor_id = dsdetails.Tables(0).Rows(0).Item(2).ToString
                            new_consult.patient_id = dsdetails.Tables(0).Rows(0).Item(1).ToString
                            new_consult.complaints = dsdetails.Tables(0).Rows(0).Item(3).ToString
                            new_consult.findings = dsdetails.Tables(0).Rows(0).Item(4).ToString
                            new_consult.dateandtime = dsdetails.Tables(0).Rows(0).Item(5).ToString
                            new_consult.last_update = dsdetails.Tables(0).Rows(0).Item(6).ToString
                            new_consult.consult_id = dtgv_allappointment.CurrentRow.Cells(11).Value
                            new_consult.ShowDialog()
                        End If
                    Catch ex As Exception

                    End Try
                Else
                    If dtgv_allappointment.Rows(myRow).Cells(8).Value.ToString = "Pending" Then
                        context_options.Items(0).Visible = False
                        context_options.Items(1).Visible = True
                        context_options.Items(2).Visible = True
                        context_options.Items(3).Visible = True
                        context_options.Items(4).Visible = False
                        context_options.Items(5).Visible = False
                    Else
                        context_options.Items(0).Visible = False
                        context_options.Items(1).Visible = False
                        context_options.Items(2).Visible = True
                        context_options.Items(3).Visible = False
                        context_options.Items(4).Visible = True
                        context_options.Items(5).Visible = False
                    End If
                    context_options.Show(Control.MousePosition)
                End If
            ElseIf myCol = 2 And myRow <> -1 Then
                Dim viewpatient As New View_patient
                viewpatient.patient_id = dtgv_allappointment.CurrentRow.Cells(1).Value
                viewpatient.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Consult_now_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Consult_now.Click
        Dim consult_now As New new_consult
        consult_now.what_to_do = 2
        consult_now.appointment_id = dtgv_allappointment.CurrentRow.Cells(0).Value
        consult_now.Show()
        consult_now.cmb_patients.SelectedValue = dtgv_allappointment.CurrentRow.Cells(1).Value
        consult_now.cmb_doctors.SelectedValue = dtgv_allappointment.CurrentRow.Cells(4).Value
        consult_now.cmb_doctors.Enabled = False
        consult_now.cmb_patients.Enabled = False
    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        New_Consultation.patient_id = dtgv_allappointment.CurrentRow.Cells(1).Value
        New_Consultation.doctor_id = dtgv_allappointment.CurrentRow.Cells(4).Value
        New_Consultation.consult_date = dtgv_allappointment.CurrentRow.Cells(3).Value
        New_Consultation.comment = dtgv_allappointment.CurrentRow.Cells(6).Value
        New_Consultation.consult_id = dtgv_allappointment.CurrentRow.Cells(0).Value
        New_Consultation.what_to_do = 1
        New_Consultation.ShowDialog()
    End Sub

    Private Sub cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancel.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to POSTPONE this schedule?", MsgBoxStyle.YesNo, "Postpone Schedule")
        If res = MsgBoxResult.Yes Then
            Try
                cmd = New MySqlCommand("update patient_consultations SET isdone=2,updated_at=CURRENT_TIMESTAMP where id=" + Me.dtgv_allappointment.CurrentRow.Cells(0).Value.ToString, conn)
                cmd.ExecuteNonQuery()
                dtgv_allappointment.CurrentRow.Cells(8).Value = "Postponed"
                dtgv_allappointment.CurrentRow.Cells(10).Value = Now().ToString
                today.display_today("")
                incoming.display_incoming("")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub unpostpone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles unpostpone.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to UNPOSTPONE this schedule?", MsgBoxStyle.YesNo, "Unpostpone Schedule")
        If res = MsgBoxResult.Yes Then
            Try
                cmd = New MySqlCommand("update patient_consultations SET isdone=0,updated_at=CURRENT_TIMESTAMP where id=" + Me.dtgv_allappointment.CurrentRow.Cells(0).Value.ToString, conn)
                cmd.ExecuteNonQuery()
                dtgv_allappointment.CurrentRow.Cells(8).Value = "Pending"
                dtgv_allappointment.CurrentRow.Cells(10).Value = Now().ToString
                today.display_today("")
                incoming.display_incoming("")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next.Click
        Try


            Dim dslength As Integer = ds.Tables(0).Rows.Count
            If lastitem < dslength Then
                dtgv_allappointment.Rows.Clear()
            End If
            Dim firstit As Integer = 0
            With ds.Tables(0)
                For i = lastitem + 1 To limit + lastitem + 1
                    lastitem = i
                    If lastitem = dslength Then
                        btn_next.Visible = False

                        Exit For
                    Else
                        If firstit = 0 Then
                            firstitem = i
                            firstit = 1
                        End If
                        dtgv_allappointment.Rows.Add(.Rows(i).Item(0),
                                                                        .Rows(i).Item(1),
                                                                       .Rows(i).Item(2).ToString,
                                                                       .Rows(i).Item(3),
                                                                       .Rows(i).Item(4),
                                                                       .Rows(i).Item(5).ToString,
                                                                       .Rows(i).Item(6).ToString,
                                                                       .Rows(i).Item(7).ToString,
                                                                       .Rows(i).Item(8).ToString,
                                                                       .Rows(i).Item(9).ToString,
                                                                       .Rows(i).Item(10).ToString,
                                                                       .Rows(i).Item(11)
                                               )
                        Dim lastindex As Integer = dtgv_allappointment.Rows.Count - 1
                        Select Case .Rows(i).Item(8).ToString
                            Case "Done"
                                dtgv_allappointment.Rows(lastindex).DefaultCellStyle.BackColor = Color.LightGreen
                        End Select
                        btn_next.Visible = True
                    End If


                Next
                btn_back.Visible = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.Click
        Try


            Dim dslength As Integer = ds.Tables(0).Rows.Count
            If firstitem > 0 Then
                dtgv_allappointment.Rows.Clear()
            End If
            Dim firstit As Integer = 0
            With ds.Tables(0)
                For i = firstitem - limit - 1 To firstitem - 1
                    lastitem = i

                    If firstit = 0 Then
                        firstitem = i
                        firstit = 1
                    End If
                    If firstitem <= 0 Then
                        btn_back.Visible = False
                    Else
                        btn_back.Visible = True
                    End If
                    dtgv_allappointment.Rows.Add(.Rows(i).Item(0),
                                                                    .Rows(i).Item(1),
                                                                   .Rows(i).Item(2).ToString,
                                                                   .Rows(i).Item(3),
                                                                   .Rows(i).Item(4),
                                                                   .Rows(i).Item(5).ToString,
                                                                   .Rows(i).Item(6).ToString,
                                                                   .Rows(i).Item(7).ToString,
                                                                   .Rows(i).Item(8).ToString,
                                                                   .Rows(i).Item(9).ToString,
                                                                   .Rows(i).Item(10).ToString,
                                                                   .Rows(i).Item(11)
                                           )
                    Dim lastindex As Integer = dtgv_allappointment.Rows.Count - 1
                    Select Case .Rows(i).Item(8).ToString
                        Case "Done"
                            dtgv_allappointment.Rows(lastindex).DefaultCellStyle.BackColor = Color.LightGreen
                    End Select

                Next
                btn_next.Visible = True
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class