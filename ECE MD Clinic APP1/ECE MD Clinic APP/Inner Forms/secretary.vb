Public Class secretary
#Region "Methods"
    Public Sub DisplaySecretaries()
        Try
             Dim Param_Name As String() = {"@action_type", "@sub_action", "@search"}
            Dim Param_Value As String() = {2, 1, GetSearchString()}
            Dim MyAdapter As New Custom_Adapters
            With (dtgv_secretaries)
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Secretary", Param_Name, Param_Value)
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(5).Visible = False
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Function GetSearchString()
        If txt_search.Text = Search_Hint_Secretary Or txt_search.Text.Length = 0 Then
            Return ""
        End If
        Return txt_search.Text
    End Function
#End Region
#Region "Variables"
    Private ButtonColumn As Integer = 5
#End Region
    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = Search_Hint_Secretary
        End If
    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        If txt_search.Text = Search_Hint_Secretary Then
            txt_search.Text = ""
        End If
    End Sub

    Private Sub secretary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_secretaries.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_secretaries.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_secretaries.RowTemplate.Height = Default_Row_Height
        txt_search.Text = Search_Hint_Secretary
    End Sub
    

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not txt_search.Text = "Search Secretary Here" Then
            DisplaySecretaries()
        End If
    End Sub

    Private Sub dtgv_patients_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_secretaries.CellMouseEnter
        Try
            Dim myRow As Integer = e.RowIndex
            Dim myCol As Integer = e.ColumnIndex
            If myCol = ButtonColumn And myRow <> -1 Then
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
            If myCol = ButtonColumn And myRow <> -1 Then
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
            If myCol = ButtonColumn And myRow <> -1 Then
                View_Secretary.secretary_id = dtgv_secretaries.CurrentRow.Cells(0).Value
                If dtgv_secretaries.CurrentRow.Cells(6).Value.ToString = "Active" Then
                    View_Secretary.isactive = 1
                Else
                    View_Secretary.isactive = 0
                End If
                View_Secretary.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_new_secretary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new_secretary.Click
        New_Secretary.ShowDialog()
    End Sub
End Class