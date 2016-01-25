Module Helpers

    Public Sub DisplayNotificationCount()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@search", "@secretary_id", "@doctor_id"}
            Dim Param_Value As String()
            Dim MyAdapter As New Custom_Adapters
            If UserType = 0 Then 'secretary
                Param_Value = {2, 12, "", UserId, ""}
            Else 'doctor
                Param_Value = {2, 13, "", "", UserId}
            End If
            NotificationCount = MyAdapter.CUSTOM_RETRIEVE("SP_Consultation", Param_Name, Param_Value).Rows.Count
            If NotificationCount > 0 Then
                Form_Main.Notification_counter_container.Visible = True
                Form_Main.lbl_notification_counter.Visible = True
                Form_Main.lbl_notif_context.Text = "You have " + NotificationCount.ToString + " notifications request!"
                If NotificationCount > 9 Then
                    Form_Main.lbl_notification_counter.Text = "9+"
                    Form_Main.lbl_notification_counter.Location = New Point(14, 2)
                Else
                    Form_Main.lbl_notification_counter.Text = NotificationCount
                    Form_Main.lbl_notification_counter.Location = New Point(18, 2)
                End If
            Else
                Form_Main.Notification_counter_container.Visible = False
                Form_Main.lbl_notification_counter.Visible = False
                Form_Main.lbl_notif_context.Text = "You have no notification request!"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function Get_Auto_IncrementID(ByRef server_id As Integer, ByRef What_To_Get As String) As Integer
        Dim Param_Name As String() = {"@action_type", "@sub_action", "@server_id"}
        Dim Param_Value As String()
        Dim MyAdapter As New Custom_Adapters
        If What_To_Get = "Patient" Then
            Param_Value = {2, 4, server_id}
            Return MyAdapter.CUSTOM_TRANSACT_WITH_RETURN("SP_Patient", Param_Name, Param_Value)
        End If
        Return 0
    End Function
End Module
