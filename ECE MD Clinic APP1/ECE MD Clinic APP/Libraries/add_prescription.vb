Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class add_prescription
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Private ds_brand As New DataSet
    Private cmd As New MySqlCommand
    Private Sub add_prescription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtgv_meds.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        load_generic("")

    End Sub
    Public Sub load_generic(ByVal search As String)
        Try
            ds.Clear()
            dtgv_meds.Rows.Clear()
            da = New MySqlDataAdapter("SELECT `id`, `med_name` FROM `medicines` where `med_name` like '%" + search + "%' " + new_consult.str_medicine_id, conn)
            da.Fill(ds, "generics")
            For i As Integer = 0 To ds.Tables("generics").Rows.Count - 1
                dtgv_meds.Rows.Add(ds.Tables("generics").Rows(i).Item(0), ds.Tables("generics").Rows(i).Item(1).ToString, " Add ")
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_search_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.TextChanged
        If Not txt_search.Text = "Search Medicine here" Then
            load_generic(txt_search.Text)
            If txt_search.Text.Length > 3 Then
                btn_add_med.Visible = True
            Else
                btn_add_med.Visible = False
            End If
        End If

    End Sub

    Private Sub btn_add_med_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_med.Click
        Try
            cmd = New MySqlCommand("INSERT INTO `medicines`(`med_name`) VALUES (@medname)", conn)
            cmd.Parameters.AddWithValue("medname", txt_search.Text)
            cmd.ExecuteNonQuery()
            load_generic(txt_search.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub


    Private Sub txt_search_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Enter
        If txt_search.Text = "Search Medicine here" Then
            txt_search.Text=""
        End If
    End Sub

    
    Private Sub dtgv_meds_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgv_meds.CellContentClick
        Try
            If e.ColumnIndex = 2 Then
                new_consult.add_med(dtgv_meds.CurrentRow.Cells(1).Value.ToString, dtgv_meds.CurrentRow.Cells(0).Value)
                new_consult.get_med_ids()
                Me.dtgv_meds.Rows.RemoveAt(e.RowIndex)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub txt_search_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_search.Leave
        If txt_search.Text = "" Then
            txt_search.Text = "Search Medicine here"
        End If

    End Sub
End Class