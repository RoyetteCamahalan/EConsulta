Imports System.Data
Imports System.Data.SqlClient
Public Class select_treatment_template
    Private da As New SqlDataAdapter
#Region "Methods"
    Private Sub DisplayTemplates()
        Dim Param_Name As String() = {"@action_type", "@sub_action", "@search"}
        Dim Param_Value As String() = {2, 2, GetSearchString()}
        Dim MyAdapter As New Custom_Adapters
        With lst_templates
            .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
            .DisplayMember = "name"
            .ValueMember = "id"
            .SelectedIndex = -1
        End With
    End Sub
    Private Function GetSearchString()
        If txt_search.Text = Search_Hint Or txt_search.Text.Length = 0 Then
            Return ""
        End If
        Return txt_search.Text
    End Function
#End Region
#Region "Variables"
    Private DT_Routes As New DataTable
    Private DT_Frequency As New DataTable
    Private DT_Templates As New DataTable
#End Region
    Private Sub select_treatment_template_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getfrequency_route()
        txt_search.Text = Search_Hint
        DisplayTemplates()
    End Sub
    

    Private Sub select_treatment_template_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub getfrequency_route()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action"}
            Dim Param_Value As String() = {2, 4}
            Dim MyAdapter_Frequency As New Custom_Adapters
            Dim MyAdapter_Routes As New Custom_Adapters
            DT_Frequency = MyAdapter_Frequency.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
            Param_Value = {2, 5}
            DT_Routes = MyAdapter_Routes.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lst_templates_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_templates.SelectedValueChanged
        Try
            Dim DT As New DataTable
            dtgv_treatments.Rows.Clear()
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@template_id"}
            Dim Param_Value As String() = {2, 3, lst_templates.SelectedValue}
            Dim MyAdapter As New Custom_Adapters
            DT = MyAdapter.CUSTOM_RETRIEVE("SP_Miscellaneous", Param_Name, Param_Value)
            If DT.Rows.Count > 0 Then
                For i As Integer = 0 To DT.Rows.Count - 1
                    dtgv_treatments.Rows.Add(DT.Rows(i).Item(1).ToString, DT.Rows(i).Item(2).ToString,
                                             DT.Rows(i).Item(3).ToString, DT.Rows(i).Item(4).ToString,
                                             "", "",DT.Rows(i).Item(7).ToString, "")
                    Dim lastrow As Integer = dtgv_treatments.Rows.Count - 1
                    Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(5)
                    cellfrequency.DataSource = DT_Frequency
                    cellfrequency.DisplayMember = "name"
                    cellfrequency.Value = DT.Rows(i).Item(6).ToString
                    'cellfrequency.ValueMember = "id"
                    Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(4)
                    cellroutes.DataSource = DT_Routes
                    cellroutes.DisplayMember = "name"
                    cellroutes.Value = DT.Rows(i).Item(5).ToString
                    'cellroutes.ValueMember = "id"
                    Dim cellduration As DataGridViewTextBoxCell = dtgv_treatments.Rows(lastrow).Cells(7)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        Try
            For i As Integer = 0 To dtgv_treatments.Rows.Count - 1
                Dim checker = False
                For j As Integer = 0 To new_consult.dtgv_treatments.Rows.Count - 1
                    If dtgv_treatments.Rows(i).Cells(0).Value = new_consult.dtgv_treatments.Rows(j).Cells(0).Value Then
                        checker = True
                        Exit For
                    End If
                Next
                If Not checker Then
                    new_consult.dtgv_treatments.Rows.Add(dtgv_treatments.Rows(i).Cells(0).Value.ToString, dtgv_treatments.Rows(i).Cells(1).Value.ToString, dtgv_treatments.Rows(i).Cells(2).Value.ToString, dtgv_treatments.Rows(i).Cells(3).Value.ToString, "", "", dtgv_treatments.Rows(i).Cells(6).Value.ToString, "", "Remove")
                    Dim lastrow As Integer = new_consult.dtgv_treatments.Rows.Count - 1
                    Dim cellfrequency As DataGridViewComboBoxCell = new_consult.dtgv_treatments.Rows(lastrow).Cells(5)
                    cellfrequency.DataSource = DT_Frequency
                    cellfrequency.DisplayMember = "name"
                    cellfrequency.Value = dtgv_treatments.Rows(i).Cells(5).Value.ToString
                    'cellfrequency.ValueMember = "id"
                    Dim cellroutes As DataGridViewComboBoxCell = new_consult.dtgv_treatments.Rows(lastrow).Cells(4)
                    cellroutes.DataSource = DT_Routes
                    cellroutes.DisplayMember = "name"
                    cellroutes.Value = dtgv_treatments.Rows(i).Cells(4).Value.ToString
                    'cellroutes.ValueMember = "id"
                    Dim cellduration As DataGridViewTextBoxCell = new_consult.dtgv_treatments.Rows(lastrow).Cells(7)
                End If

            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged

    End Sub

    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        If txt_search.Text = Search_Hint Then
            txt_search.Text = ""
        End If
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = Search_Hint
        End If
    End Sub
End Class