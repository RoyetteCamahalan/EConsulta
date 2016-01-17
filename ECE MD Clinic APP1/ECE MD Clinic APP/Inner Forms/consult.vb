Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class consult
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private Sub consult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_consult.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_consult.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_consult.RowTemplate.Height = 35
        display_records("")
    End Sub
    Public Sub display_records(ByRef search As String)
        Try
            ds.Clear()
            Dim strquery As String
            If UserType = 0 Then 'secretary
                strquery = "SELECT pr.id,p.id as 'Patient_Id',concat(p.fname,' ',p.mname,' ',p.lname) as 'Patient Name',d.id AS 'Doctor_Id',concat(d.fname,' ',d.mname,' ',d.lname) as 'Doctor Name',pr.created_at as 'Date','View More' as Action,pr.updated_at,pr.complaints,pr.findings from doctors d INNER JOIN patient_records pr on pr.doctor_id=d.id INNER JOIN patients p on p.id=pr.patient_id INNER JOIN secretary_access sc on sc.doctor_id=d.id where sc.secretary_id=" + UserId.ToString + search + " ORDER BY pr.created_at desc"
            Else 'doctor
                strquery = "SELECT pr.id,p.id as 'Patient_Id',concat(p.fname,' ',p.mname,' ',p.lname) as 'Patient Name',d.id AS 'Doctor_Id',concat(d.fname,' ',d.mname,' ',d.lname) as 'Doctor Name',pr.created_at as 'Date','View More' as Action,pr.updated_at,pr.complaints,pr.findings from doctors d INNER JOIN patient_records pr on pr.doctor_id=d.id INNER JOIN patients p on p.id=pr.patient_id where d.id=" + UserId.ToString + search + " ORDER BY pr.created_at desc"
            End If
            da = New MySqlDataAdapter(strquery, conn)
            da.Fill(ds, "consult")
            With dtgv_consult
                .DataSource = ds.Tables("consult")
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(3).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        txt_search.Clear()
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = "Search Anything here"
        End If
    End Sub

    Private Sub btn_new_consult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_consult.Click

        new_consult.what_to_do = 0
        new_consult.title_text = "New Consultation"
        new_consult.ShowDialog()
    End Sub
    Private Sub dtgv_consult_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_consult.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = 6 And myRow <> -1 Then
                dtgv_consult.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Underline)
                dtgv_consult.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_consult.Cursor = Cursors.Hand
                dtgv_consult.Rows(myRow).DefaultCellStyle.BackColor = Color.LightBlue
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtgv_consult_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_consult.CellMouseLeave
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = 6 And myRow <> -1 Then
                dtgv_consult.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Modern No. 20", 12, FontStyle.Regular)
                dtgv_consult.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_consult.Cursor = Cursors.Arrow
                dtgv_consult.Rows(myRow).DefaultCellStyle.BackColor = Color.White
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtgv_consult_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgv_consult.MouseMove
        Try
            Dim hit As DataGridView.HitTestInfo = dtgv_consult.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                Dim myRow As Integer = hit.RowIndex
                Dim myCol As Integer = hit.ColumnIndex
                If myCol <> 6 And myRow <> -1 And Not dtgv_consult.Rows(myRow).Cells(7).Value.ToString = "" Then
                    Dim tempdate As Date = dtgv_consult.Rows(myRow).Cells(7).Value
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
                    dtgv_consult.Rows(myRow).Cells(myCol).ToolTipText = msg
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgv_consult_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_consult.CellClick
        Try
            Dim myRow As Integer = dtgv_consult.CurrentRow.Index
            Dim myCol As Integer = dtgv_consult.CurrentCell.ColumnIndex
            If myCol = 6 And myRow <> -1 Then
                new_consult.what_to_do = 1
                new_consult.title_text = "View Consultation"
                new_consult.doctor_id = Me.dtgv_consult.CurrentRow.Cells(3).Value
                new_consult.patient_id = Me.dtgv_consult.CurrentRow.Cells(1).Value
                new_consult.complaints = Me.dtgv_consult.CurrentRow.Cells(8).Value.ToString
                new_consult.findings = Me.dtgv_consult.CurrentRow.Cells(9).Value.ToString
                new_consult.dateandtime = Me.dtgv_consult.CurrentRow.Cells(5).Value.ToString
                new_consult.last_update = Me.dtgv_consult.CurrentRow.Cells(7).Value.ToString
                new_consult.consult_id = Me.dtgv_consult.CurrentRow.Cells(0).Value.ToString
                new_consult.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not (txt_search.Text = "Search Anything here") Then
            display_records(" and (p.lname like '%" + txt_search.Text + "%' or p.fname like '%" + txt_search.Text + "%' or p.mname like '%" + txt_search.Text + "%')")
        End If
    End Sub
End Class