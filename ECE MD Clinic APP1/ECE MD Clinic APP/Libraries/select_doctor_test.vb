Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class select_doctor_test
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Public testresult As test_result
    Private Sub select_doctor_test_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_ok.ForeColor = Color.Gray
        display_doctors()
    End Sub
    Private Sub display_doctors()
        Try
            Dim strquery As String
            If UserType = 0 Then
                strquery = "select d.id,concat(d.`fname`,' ',d.`mname`,' ',d.`lname`)as doctors_name from doctors d INNER JOIN secretary_access sc on sc.doctor_id=d.id WHERE sc.secretary_id=" + UserId.ToString
                cmb_doctors.Enabled = True
            Else
                strquery = "select id,concat(`fname`,' ',`mname`,' ',`lname`)as doctors_name from doctors where id=" + UserId.ToString
                cmb_doctors.Enabled = False
            End If
            da = New MySqlDataAdapter(strquery, conn)
            da.Fill(ds, "doctors")

            With cmb_doctors
                .DataSource = ds.Tables("doctors")
                .ValueMember = "id"
                .DisplayMember = "doctors_name"
                .SelectedIndex = -1
            End With
            If UserType = 1 Then
                cmb_doctors.SelectedValue = UserId
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmb_doctors_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_doctors.SelectedValueChanged
        If cmb_doctors.SelectedIndex >= 0 Then
            btn_ok.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        If btn_ok.ForeColor = Color.Gray Then
            MsgBox("Please select doctor")
        Else
            testresult.addfromsecretary(cmb_doctors.SelectedValue)
            Me.Dispose()
        End If
    End Sub
End Class