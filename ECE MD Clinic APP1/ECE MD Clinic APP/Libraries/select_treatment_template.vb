Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class select_treatment_template
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private Sub select_treatment_template_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ds.Tables.Add("templates")
        ds.Tables.Add("items")
        ds.Tables.Add("routes")
        ds.Tables.Add("frequency")
        getfrequency_route()
        display_templates("")
    End Sub
    Private Sub display_templates(ByRef search As String)
        ds.Tables("templates").Clear()
        da = New MySqlDataAdapter("Select id,name from prescription_template where name like '%" + search + "%'", conn)
        da.Fill(ds, "templates")
        With lst_templates
            .DataSource = ds.Tables("templates")
            .DisplayMember = "name"
            .ValueMember = "id"
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub select_treatment_template_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
    Private Sub getfrequency_route()
        Try
            da = New MySqlDataAdapter("SELECT `id`, `name` FROM `prescription_frequency`", conn)
            da.Fill(ds, "frequency")
            da = New MySqlDataAdapter("SELECT `id`, `name` FROM `presciption_routes`", conn)
            da.Fill(ds, "routes")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lst_templates_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lst_templates.SelectedValueChanged
        Try
            Dim dstreatment As New DataSet
            dtgv_treatments.Rows.Clear()
            da = New MySqlDataAdapter("SELECT pi.`template_id`,pi.`medicine_id`, m.`med_name`,pi.no_generics,pi.quantity, `route`, `frequency`, `refills` FROM medicines m inner join prescription_template_items pi on m.id=pi.medicine_id where template_id=" + lst_templates.SelectedValue.ToString, conn)
            da.Fill(dstreatment, "treatments")
            If dstreatment.Tables("treatments").Rows.Count > 0 Then
                For i As Integer = 0 To dstreatment.Tables("treatments").Rows.Count - 1
                    dtgv_treatments.Rows.Add(dstreatment.Tables("treatments").Rows(i).Item(1).ToString, dstreatment.Tables("treatments").Rows(i).Item(2).ToString, dstreatment.Tables("treatments").Rows(i).Item(3).ToString, dstreatment.Tables("treatments").Rows(i).Item(4).ToString, "", "", dstreatment.Tables("treatments").Rows(i).Item(7).ToString, "")
                    Dim lastrow As Integer = dtgv_treatments.Rows.Count - 1
                    Dim cellfrequency As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(5)
                    cellfrequency.DataSource = ds.Tables("frequency")
                    cellfrequency.DisplayMember = "name"
                    cellfrequency.Value = dstreatment.Tables("treatments").Rows(i).Item(6).ToString
                    'cellfrequency.ValueMember = "id"
                    Dim cellroutes As DataGridViewComboBoxCell = dtgv_treatments.Rows(lastrow).Cells(4)
                    cellroutes.DataSource = ds.Tables("routes")
                    cellroutes.DisplayMember = "name"
                    cellroutes.Value = dstreatment.Tables("treatments").Rows(i).Item(5).ToString
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
                    cellfrequency.DataSource = ds.Tables("frequency")
                    cellfrequency.DisplayMember = "name"
                    cellfrequency.Value = dtgv_treatments.Rows(i).Cells(5).Value.ToString
                    'cellfrequency.ValueMember = "id"
                    Dim cellroutes As DataGridViewComboBoxCell = new_consult.dtgv_treatments.Rows(lastrow).Cells(4)
                    cellroutes.DataSource = ds.Tables("routes")
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
        If txt_search.Text = "Search here" Then
            txt_search.Text = ""
        End If
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = "Search here"
        End If
    End Sub
End Class