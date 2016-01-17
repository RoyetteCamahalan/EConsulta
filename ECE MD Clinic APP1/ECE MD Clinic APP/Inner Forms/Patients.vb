Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Patients
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private dt As New DataTable
    Private Sub Patients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_patients.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_patients.DefaultCellStyle.SelectionForeColor = Color.Black
        display_patients("")
        dtgv_patients.RowTemplate.Height = 35
    End Sub
    Public Sub display_patients(ByVal SEARCH As String)
        Try
            ds.Clear()
            da = New MySqlDataAdapter("SELECT id,fname as 'First Name', mname as 'Middle Name', lname as 'Last Name',sex as 'Sex','More Details....' as Action  FROM patients" + SEARCH, conn)
            da.Fill(ds)
            With (dtgv_patients)
                .DataSource = ds.Tables(0)
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        New_Patient.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim p_history As New View_patient
        p_history.Show()
    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        With txt_search
            .Clear()
            .ForeColor = Color.Black
        End With
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            With txt_search
                .Text = "Search Patient here"
                .ForeColor = Color.Gray
            End With
        End If
    End Sub

    Private Sub dtgv_patients_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_patients.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = 5 And myRow <> -1 Then
                dtgv_patients.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Underline)
                dtgv_patients.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_patients.Cursor = Cursors.Hand
                dtgv_patients.Rows(myRow).DefaultCellStyle.BackColor = Color.LightBlue
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtgv_patients_CellMouseLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_patients.CellMouseLeave
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = 5 And myRow <> -1 Then
                dtgv_patients.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Hoefler Text Black", 8.25, FontStyle.Regular)
                dtgv_patients.Rows(myRow).Cells(myCol).Style.Font = f
                dtgv_patients.Rows(myRow).DefaultCellStyle.BackColor = Color.White
                dtgv_patients.Cursor = Cursors.Arrow
                'MsgBox("underline")
            End If
        Catch ex As Exception

        End Try

    End Sub


    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not txt_search.Text = "Search Patient here" Then
            display_patients(" where lname like '%" + txt_search.Text + "%' or fname like '%" + txt_search.Text + "%' or mname like '%" + txt_search.Text + "%'")
        End If

    End Sub

    Private Sub dtgv_patients_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_patients.CellClick
        Try
            Dim myRow As Integer = dtgv_patients.CurrentRow.Index
            Dim myCol As Integer = dtgv_patients.CurrentCell.ColumnIndex
            If myCol = 5 And myRow <> -1 Then
                Dim viewpatient As New View_patient
                viewpatient.patient_id = dtgv_patients.CurrentRow.Cells(0).Value
                viewpatient.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dtgv_patients_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtgv_patients.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                Dim viewpatient As New View_patient
                viewpatient.patient_id = dtgv_patients.CurrentRow.Cells(0).Value
                viewpatient.Show()
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class