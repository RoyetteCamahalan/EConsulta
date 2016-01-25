Public Class Patient_Record
#Region "Methods"
    Public Sub DisplayRecords()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@search", "@secretary_id", "@doctor_id"}
            Dim Param_Value As String()
            Dim MyAdapter As New Custom_Adapters
            If UserType = 0 Then 'secretary
                Param_Value = {2, 2, GetSearchString(), UserId, ""}
            Else 'doctor
                Param_Value = {2, 3, GetSearchString(), "", UserId}
            End If
            With dtgv_consult
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_PatientRecord", Param_Name, Param_Value)
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .Columns(3).Visible = False
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .Columns(ButtonColumn).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetSearchString() As String
        If txt_search.Text = Search_Hint Or txt_search.Text.Length = 0 Then
            Return ""
        End If
        Return txt_search.Text
    End Function
#End Region
#Region "Variables"
    Private ButtonColumn As Integer = 8
#End Region
    Private Sub consult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.BackColor = Color.Transparent
        dtgv_consult.DefaultCellStyle.SelectionBackColor = Color.LightBlue
        dtgv_consult.DefaultCellStyle.SelectionForeColor = Color.Black
        dtgv_consult.RowTemplate.Height = Default_Row_Height
        txt_search.Text = Search_Hint
        DisplayRecords()
    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        If txt_search.Text = Search_Hint Then
            txt_search.Text = ""
            txt_search.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = Search_Hint
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
            If myCol = ButtonColumn And myRow <> -1 Then
                dtgv_consult.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Red
                Dim f = New Font("Microsoft Sans Serif", 9, FontStyle.Underline)
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
            If myCol = ButtonColumn And myRow <> -1 Then
                dtgv_consult.Rows(myRow).Cells(myCol).Style.ForeColor = Color.Black
                Dim f = New Font("Microsoft Sans Serif", 8.5, FontStyle.Regular)
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
                If myCol <> ButtonColumn And myRow <> -1 And Not dtgv_consult.Rows(myRow).Cells(7).Value.ToString = "" Then
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
            If myCol = ButtonColumn And myRow <> -1 Then
                new_consult.what_to_do = 1
                new_consult.title_text = "View Consultation"
                new_consult.doctor_id = Me.dtgv_consult.CurrentRow.Cells(3).Value
                new_consult.patient_id = Me.dtgv_consult.CurrentRow.Cells(1).Value
                new_consult.complaints = Me.dtgv_consult.CurrentRow.Cells(6).Value.ToString
                new_consult.findings = Me.dtgv_consult.CurrentRow.Cells(7).Value.ToString
                new_consult.dateandtime = Me.dtgv_consult.CurrentRow.Cells(4).Value.ToString
                new_consult.last_update = Me.dtgv_consult.CurrentRow.Cells(9).Value.ToString
                new_consult.notes = Me.dtgv_consult.CurrentRow.Cells(10).Value.ToString
                new_consult.consult_id = Me.dtgv_consult.CurrentRow.Cells(0).Value.ToString
                new_consult.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not (txt_search.Text = Search_Hint) Then
            DisplayRecords()
        End If
    End Sub

End Class