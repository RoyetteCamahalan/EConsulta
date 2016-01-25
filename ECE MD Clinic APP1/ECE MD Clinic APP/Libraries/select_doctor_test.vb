Public Class select_doctor_test
    Public testresult As test_result
    Private Sub select_doctor_test_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btn_ok.ForeColor = Color.Gray
        DisplayDoctors()
    End Sub
    Private Sub DisplayDoctors()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@secretary_id", "@id"}
            Dim Param_Value As String()
            Dim MyAdapter As New Custom_Adapters
            If UserType = 0 Then
                Param_Value = {2, 1, UserId, ""}
                cmb_doctors.Enabled = True
            Else
                Param_Value = {2, 2, "", UserId}
                cmb_doctors.Enabled = False
            End If
            With cmb_doctors
                .DataSource = MyAdapter.CUSTOM_RETRIEVE("SP_Doctors", Param_Name, Param_Value)
                .ValueMember = "id"
                .DisplayMember = "doctors_name"
                .SelectedIndex = -1
            End With
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
            testresult.InsertTestResult(cmb_doctors.SelectedValue)
            Me.Dispose()
        End If
    End Sub
End Class