Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class secretary
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = "Search Secretary Here"
        End If
    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        txt_search.Clear()
    End Sub

    Private Sub secretary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_secretaries.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_secretaries.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_secretaries.RowTemplate.Height = 35
        display_secretaries("")
    End Sub
    Public Sub display_secretaries(ByVal SEARCH As String)
        Try
            ds.Clear()
            da = New MySqlDataAdapter("SELECT id,fname as 'First Name', mname as 'Middle Name', lname as 'Last Name',created_at as 'Registration Date', updated_at,File_Access as 'File Access','More Details....' as" +
                                        " Action FROM (SELECT s.id,s.fname, s.mname, s.lname , s.created_at, s.updated_at, 'Allowed' AS 'File_Access' FROM `secretaries` s inner JOIN secretary_access sa on" +
                                        " s.id=sa.secretary_id WHERE sa.doctor_id=" + UserId.ToString + " UNION ALL SELECT s.id,s.fname, s.mname, s.lname, s.created_at, s.updated_at, 'Not Allowed' AS 'File_Access' FROM `secretaries` s inner" +
                                        " JOIN clinic_secretary cs on s.id=cs.secretary_id WHERE NOT EXISTS(SELECT secretary_id FROM secretary_access WHERE doctor_id=" + UserId.ToString + " and s.id=secretary_id)) as x " + SEARCH, conn)
            da.Fill(ds)
            With (dtgv_secretaries)
                .DataSource = ds.Tables(0)
                .Columns(5).Visible = False
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not txt_search.Text = "Search Secretary Here" Then
            display_secretaries(" where lname like '%" + txt_search.Text + "%' or fname like '%" + txt_search.Text + "%' or mname like '%" + txt_search.Text + "%'")
        End If
    End Sub

    Private Sub dtgv_patients_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_secretaries.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = 7 And myRow <> -1 Then
                dtgv_secretaries.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Underline)
                dtgv_secretaries.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_secretaries.Cursor = Cursors.Hand
                dtgv_secretaries.Rows(myRow).DefaultCellStyle.BackColor = Color.LightBlue
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgv_secretaries_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_secretaries.CellMouseLeave
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = 7 And myRow <> -1 Then
                dtgv_secretaries.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Regular)
                dtgv_secretaries.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_secretaries.Rows(myRow).DefaultCellStyle.BackColor = Color.White
                dtgv_secretaries.Cursor = Cursors.Arrow
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtgv_secretaries_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_secretaries.CellClick
        Try
            Dim myRow As Integer = dtgv_secretaries.CurrentRow.Index
            Dim myCol As Integer = dtgv_secretaries.CurrentCell.ColumnIndex
            If myCol = 7 And myRow <> -1 Then
                View_Secretary.secretary_id = dtgv_secretaries.CurrentRow.Cells(0).Value
                If dtgv_secretaries.CurrentRow.Cells(6).Value.ToString = "Allowed" Then
                    View_Secretary.isactive = 1
                Else
                    View_Secretary.isactive = 0
                End If
                View_Secretary.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        New_Secretary.ShowDialog()
    End Sub
End Class