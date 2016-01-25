Imports System.Data
Imports System.Data.SqlClient
Public Class add_prescription
#Region "Methods"
    Public Sub LoadMedicines()
        Try
            dtgv_meds.Rows.Clear()
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@search"}
            Dim Param_Value As String() = {3, 1, GetSearchString()}
            Dim MyAdapter As New Custom_Adapters
            DT = MyAdapter.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
            For i As Integer = 0 To DT.Rows.Count - 1
                dtgv_meds.Rows.Add(DT.Rows(i).Item(0), DT.Rows(i).Item(1).ToString, " Add ")
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetSearchString()
        If txt_search.Text = Search_Hint_Medicine Or txt_search.Text.Length = 0 Then
            Return ""
        End If
        Return txt_search.Text
    End Function
#End Region
#Region "Variables"
    Private DT As New DataTable
    Private da As New SqlDataAdapter
    Private cmd As New SqlCommand
#End Region
    Private Sub add_prescription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_meds.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        txt_search.Text = Search_Hint_Medicine
        LoadMedicines()

    End Sub


    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not txt_search.Text = Search_Hint_Medicine Then
            LoadMedicines()
            If txt_search.Text.Length > 3 Then
                btn_add_med.Visible = True
            Else
                btn_add_med.Visible = False
            End If
        End If

    End Sub

    Private Sub btn_add_med_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_med.Click
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@med_name"}
            Dim Param_Value As String() = {3, 2, txt_search.Text}
            Dim MyAdapter As New Custom_Adapters
            If MyAdapter.CUSTOM_TRANSACT("SP_Miscellaneous", Param_Name, Param_Value) Then
                MsgBox("Saved")
                LoadMedicines()
            Else
                MsgBox("Saving Failed")
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        If txt_search.Text = Search_Hint_Medicine Then
            txt_search.Text = ""
        End If
    End Sub


    Private Sub dtgv_meds_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_meds.CellContentClick
        Try
            If e.ColumnIndex = 2 Then
                Dim checker As Boolean = True
                For i As Integer = 0 To new_consult.dtgv_treatments.Rows.Count - 1
                    If new_consult.dtgv_treatments.Rows(i).Cells(0).Value = dtgv_meds.CurrentRow.Cells(0).Value Then
                        checker = False
                        Exit For
                    End If
                Next
                If checker Then
                    new_consult.add_med(dtgv_meds.CurrentRow.Cells(1).Value.ToString, dtgv_meds.CurrentRow.Cells(0).Value)
                    Me.dtgv_meds.Rows.RemoveAt(e.RowIndex)
                Else
                    MsgBox(dtgv_meds.CurrentRow.Cells(1).Value.ToString + " has already been added!")
                End If
            End If
        Catch ex As Exception
            MsgBox("Adding Medicines Failed.")
        End Try
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = Search_Hint_Medicine
        End If

    End Sub
End Class