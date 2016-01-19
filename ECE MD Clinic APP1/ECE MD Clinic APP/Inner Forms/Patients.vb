Public Class Patients
#Region "Methods"
    Public Sub DisplayPatients()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@search"}
            Dim Param_Value As String() = {2, 1, GetSearchString()}
            Dim MyAdapter As New Custom_Adapters
            dtgv_patients.DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Patient", Param_Name, Param_Value)
            dtgv_patients.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Function GetSearchString()
        If txt_search.Text = Search_Hint_Patient Or txt_search.Text.Length = 0 Then
            Return ""
        End If
        Return txt_search.Text
    End Function
#End Region
#Region "variables"
    Private ButtonColumn As Integer = 5
#End Region
    Private Sub Patients_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_patients.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_patients.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_patients.RowTemplate.Height = Default_Row_Height
        txt_search.Text = Search_Hint_Patient
        DisplayPatients()
    End Sub
    
    Private Sub btn_add_patient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_patient.Click
        New_Patient.ShowDialog()
    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        If txt_search.Text = Search_Hint_Patient Then
            txt_search.Text = ""
            txt_search.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = Search_Hint_Patient
            txt_search.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub dtgv_patients_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_patients.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = ButtonColumn And myRow <> -1 Then
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
            If myCol = ButtonColumn And myRow <> -1 Then
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
        If Not txt_search.Text = SEARCH_HINT_PATIENT Then
            DisplayPatients()
        End If

    End Sub

    Private Sub dtgv_patients_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_patients.CellClick
        Try
            Dim myRow As Integer = dtgv_patients.CurrentRow.Index
            Dim myCol As Integer = dtgv_patients.CurrentCell.ColumnIndex
            If myCol = ButtonColumn And myRow <> -1 Then
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