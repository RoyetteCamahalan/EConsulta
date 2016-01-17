Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class incoming
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private cmd As New MySqlCommand
    Dim w As Integer = 221
    Dim h As Integer = 99
    Private Sub incoming_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_incoming.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_incoming.DefaultCellStyle.SelectionForeColor = Color.Black
        Me.Size = New System.Drawing.Size(w, h)
        Timer1.Start()
        display_incoming("")
        dtgv_incoming.RowTemplate.Height = 35
    End Sub
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

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = "Search Patient here"
        End If
    End Sub
    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not (txt_search.Text = "Search Patient here") Then
            display_incoming("and (p.lname like '%" + txt_search.Text + "%' or p.fname like '%" + txt_search.Text + "%' or p.mname like '%" + txt_search.Text + "%')")
        End If
    End Sub
    Public Sub display_incoming(ByRef search As String)
        Dim str As String
        If UserType = 0 Then 'secretary
            str = "select pc.id,p.id as patient_id,concat(p.fname,' ',p.mname,' ',p.lname)as 'Patient Name',CONCAT(pc.date,' ',pc.time) as Date," +
                                        " d.id,concat(d.fname,' ',d.mname,' ',d.lname) as Doctor,'' dummy,pc.created_at as 'Encoded Date'," +
                                        " case WHEN pc.isdone=0 THEN 'Pending'when pc.isdone=1 then 'Done'end as 'Status','Options ...' as Actions,pc.updated_at from doctors d" +
                                        " INNER JOIN patient_consultations pc on pc.doctor_id=d.id" +
                                        " INNER JOIN patients p on p.id=pc.patient_id  inner join secretary_access sc on sc.doctor_id=d.id where sc.secretary_id=" + UserId.ToString + " and pc.isdone=0 " + search + " order by pc.date"
        Else 'doctor
            str = "select pc.id,p.id as patient_id,concat(p.fname,' ',p.mname,' ',p.lname)as 'Patient Name',CONCAT(pc.date,' ',pc.time) as Date," +
                                        " d.id,concat(d.fname,' ',d.mname,' ',d.lname) as Doctor,'' dummy,pc.created_at as 'Encoded Date'," +
                                        " case WHEN pc.isdone=0 THEN 'Pending'when pc.isdone=1 then 'Done'end as 'Status','Options ...' as Actions,pc.updated_at from doctors d" +
                                        " INNER JOIN patient_consultations pc on pc.doctor_id=d.id" +
                                        " INNER JOIN patients p on p.id=pc.patient_id where d.id=" + UserId.ToString + " and pc.isdone=0 " + search + " order by pc.date"

        End If

        Try
            ds.Clear()
            da = New MySqlDataAdapter(str, conn)
            da.Fill(ds)
            With dtgv_incoming
                .DataSource = ds.Tables(0)
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(4).Visible = False
                .Columns(6).Visible = False
                .Columns(10).Visible = False
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtgv_allappointment_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_incoming.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If (myCol = 9 Or myCol = 2) And myRow <> -1 Then
                dtgv_incoming.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Underline)
                dtgv_incoming.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_incoming.Cursor = Cursors.Hand
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtgv_allappointment_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_incoming.CellMouseLeave
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If (myCol = 9 Or myCol = 2) And myRow <> -1 Then
                dtgv_incoming.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Modern No. 20", 12, FontStyle.Regular)
                dtgv_incoming.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_incoming.Cursor = Cursors.Arrow
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtgv_allappointment_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgv_incoming.MouseMove
        Try
            Dim hit As DataGridView.HitTestInfo = dtgv_incoming.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                Dim myRow As Integer = hit.RowIndex
                Dim myCol As Integer = hit.ColumnIndex
                If (myCol <> 9 Or myCol <> 2) And myRow <> -1 And Not dtgv_incoming.Rows(myRow).Cells(10).Value.ToString = "" Then
                    Dim tempdate As Date = dtgv_incoming.Rows(myRow).Cells(10).Value
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
                    dtgv_incoming.Rows(myRow).Cells(myCol).ToolTipText = msg
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgv_allappointment_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_incoming.CellClick
        Try
            Dim myRow As Integer = dtgv_incoming.CurrentRow.Index
            Dim myCol As Integer = dtgv_incoming.CurrentCell.ColumnIndex
            If myCol = 9 And myRow <> -1 Then
                context_options.Show(Control.MousePosition)
            ElseIf myCol = 2 And myRow <> -1 Then
                Dim viewpatient As New View_patient
                viewpatient.patient_id = dtgv_incoming.CurrentRow.Cells(1).Value
                viewpatient.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        New_Consultation.patient_id = dtgv_incoming.CurrentRow.Cells(1).Value
        New_Consultation.doctor_id = dtgv_incoming.CurrentRow.Cells(4).Value
        New_Consultation.consult_date = Convert.ToDateTime(dtgv_incoming.CurrentRow.Cells(3).Value.ToString).ToString("yyyy-MM-dd hh:mm:ss")
        New_Consultation.comment = dtgv_incoming.CurrentRow.Cells(6).Value
        New_Consultation.consult_id = dtgv_incoming.CurrentRow.Cells(0).Value
        New_Consultation.what_to_do = 1
        New_Consultation.ShowDialog()
    End Sub

    Private Sub postpone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles postpone.Click
        Dim res As MsgBoxResult = MsgBox("Are you sure you want to POSTPONE this schedule?", MsgBoxStyle.YesNo, "Postpone Schedule")
        If res = MsgBoxResult.Yes Then
            Try
                cmd = New MySqlCommand("update patient_consultations SET isdone=2,updated_at=CURRENT_TIMESTAMP where id=" + Me.dtgv_incoming.CurrentRow.Cells(0).Value.ToString, conn)
                cmd.ExecuteNonQuery()
                Consultation.display_all("")
                Me.display_incoming("")
                today.display_today("")

            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub Consult_now_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Consult_now.Click
        new_consult.what_to_do = 2
        new_consult.appointment_id = dtgv_incoming.CurrentRow.Cells(0).Value

        new_consult.cmb_patients.SelectedValue = dtgv_incoming.CurrentRow.Cells(1).Value
        new_consult.cmb_doctors.SelectedValue = dtgv_incoming.CurrentRow.Cells(4).Value
        new_consult.cmb_doctors.Enabled = False
        new_consult.cmb_patients.Enabled = False
        new_consult.Show()
    End Sub

 
End Class