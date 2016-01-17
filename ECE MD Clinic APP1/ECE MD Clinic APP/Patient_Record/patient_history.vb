Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class patient_history
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Public patient_id As Integer
    Private Sub patient_history_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_record.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_record.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_record.RowTemplate.Height = 35
        display_patient_record()
    End Sub
    Public Sub display_patient_record()
        Try
            ds.Clear()
            Dim strquery As String
            If UserType = 1 Then 'doctor
                strquery = "SELECT pr.id,p.id as 'Patient_Id',concat(p.fname,' ',p.mname,' ',p.lname) as 'Patient Name',d.id AS 'Doctor_Id',concat(d.fname,' ',d.mname,' ',d.lname) as 'Doctor Name',pr.created_at as 'Date',pr.updated_at,pr.complaints as Complaints,pr.findings as Findings,'View More' as Action from doctors d INNER JOIN patient_records pr on pr.doctor_id=d.id INNER JOIN patients p on p.id=pr.patient_id where p.id=" + patient_id.ToString + " and d.id=" + UserId.ToString + " ORDER BY pr.created_at desc"
            Else 'secretary
                strquery = "SELECT pr.id,p.id as 'Patient_Id',concat(p.fname,' ',p.mname,' ',p.lname) as 'Patient Name',d.id AS 'Doctor_Id',concat(d.fname,' ',d.mname,' ',d.lname) as 'Doctor Name',pr.created_at as 'Date',pr.updated_at,pr.complaints as Complaints,pr.findings as Findings,'View More' as Action from doctors d INNER JOIN patient_records pr on pr.doctor_id=d.id INNER JOIN patients p on p.id=pr.patient_id INNER JOIN secretary_access sc on sc.doctor_id=d.id where p.id=" + patient_id.ToString + " and sc.secretary_id=" + UserId.ToString + " AND sc.doctor_id=d.id ORDER BY pr.created_at desc"
            End If
            da = New MySqlDataAdapter(strquery, conn)
            da.Fill(ds, "consult")
            With dtgv_record
                .DataSource = ds.Tables("consult")
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(3).Visible = False
                .Columns(6).Visible = False 'updated_at
                .Columns(2).Visible = False
                '.Columns(9).Visible = False
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgv_record_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_record.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = 9 And myRow <> -1 Then
                dtgv_record.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Underline)
                dtgv_record.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_record.Cursor = Cursors.Hand
                dtgv_record.Rows(myRow).DefaultCellStyle.BackColor = Color.LightBlue
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtgv_record_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_record.CellMouseLeave
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = 9 And myRow <> -1 Then
                dtgv_record.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Modern No. 20", 12, FontStyle.Regular)
                dtgv_record.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_record.Cursor = Cursors.Arrow
                dtgv_record.Rows(myRow).DefaultCellStyle.BackColor = Color.White
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub dtgv_record_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtgv_record.MouseMove
        Try
            Dim hit As DataGridView.HitTestInfo = dtgv_record.HitTest(e.X, e.Y)
            If hit.Type = DataGridViewHitTestType.Cell Then
                Dim myRow As Integer = hit.RowIndex
                Dim myCol As Integer = hit.ColumnIndex
                If myCol <> 9 And myRow <> -1 And Not dtgv_record.Rows(myRow).Cells(6).Value.ToString = "" Then
                    dtgv_record.Rows(myRow).Cells(myCol).ToolTipText = "Last updated " + dtgv_record.Rows(myRow).Cells(6).Value.ToString
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtgv_consult_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_record.CellClick
        Try
            Dim myRow As Integer = dtgv_record.CurrentRow.Index
            Dim myCol As Integer = dtgv_record.CurrentCell.ColumnIndex
            If myCol = 9 And myRow <> -1 Then
                Dim newconsult As New new_consult
                newconsult.what_to_do = 1
                newconsult.title_text = "View Consultation"
                newconsult.doctor_id = Me.dtgv_record.CurrentRow.Cells(3).Value
                newconsult.patient_id = Me.dtgv_record.CurrentRow.Cells(1).Value
                newconsult.complaints = Me.dtgv_record.CurrentRow.Cells(7).Value.ToString
                newconsult.findings = Me.dtgv_record.CurrentRow.Cells(8).Value.ToString
                newconsult.dateandtime = Me.dtgv_record.CurrentRow.Cells(5).Value.ToString
                newconsult.last_update = Me.dtgv_record.CurrentRow.Cells(6).Value.ToString
                newconsult.consult_id = Me.dtgv_record.CurrentRow.Cells(0).Value.ToString
                newconsult.ShowDialog()
                display_patient_record()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class