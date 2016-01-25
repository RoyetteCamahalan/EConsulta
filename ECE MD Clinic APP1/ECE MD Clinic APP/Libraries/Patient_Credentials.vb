Public Class Patient_Credentials
    Public Patient_ID As Integer
#Region "Methods"
    Private Sub DisplayCredentials()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@patient_id"}
            Dim Param_Value As String() = {2, 5, Patient_ID}
            Dim DT As New DataTable
            Dim MyAdapter As New Custom_Adapters
            DT = MyAdapter.CUSTOM_RETRIEVE("SP_DoctorPatient", Param_Name, Param_Value)
            If DT.Rows.Count > 0 Then
                txt_uname.Text = DT.Rows(0).Item(0).ToString
                txt_pword.Text = DT.Rows(0).Item(1).ToString
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Private Sub btn_generate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_generate.Click
        txt_uname.Text = randomuname("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
        txt_pword.Text = randomuname("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz")
        ts_save.Visible = True
    End Sub

    Private Sub ts_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_save.Click
        Dim Param_Name As String() = {"@action_type", "@patient_id", "@clinic_id", "@doctor_id", "@username", "@password"}
        Dim Param_Value As String() = {1, Patient_ID, My.Settings.ClinicID, UserId, txt_uname.Text, txt_pword.Text}
        Dim MyAdapter As New Custom_Adapters
        If MyAdapter.CUSTOM_TRANSACT("SP_DoctorPatient", Param_Name, Param_Value) Then
            MsgBox("Saved")
            ts_save.Visible = False
        Else
            MsgBox("Saving Failed")
        End If
    End Sub

    Private Sub ts_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ts_close.Click
        Me.Dispose()
    End Sub

    Private Sub Patient_Credentials_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayCredentials()
    End Sub
End Class