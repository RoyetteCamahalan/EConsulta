Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Notification
    Private ds As New DataSet
    Private da As New MySqlDataAdapter
    Private cmd As New MySqlCommand
    Dim txbtnControl As New TextAndButtonControl
    Dim btnaccept As New userbtnAccept
    Private Sub Notification_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtgcv_notifs.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        btnaccept.Visible = False

        txbtnControl.Visible = False
        get_notifs()
    End Sub
    Private Sub no_response_col(ByVal row_index As Integer)
        Dim rect As Rectangle = Me.dtgcv_notifs.GetCellDisplayRectangle(9, row_index, True)
        Dim txttxbtnControl2 As TextAndButtonControl = txbtnControl
        dtgcv_notifs.Controls.Add(txttxbtnControl2)
        txttxbtnControl2.Name = "usercontrol" + row_index.ToString
        txttxbtnControl2.btn_accept.Tag = row_index.ToString
        txttxbtnControl2.btn_decline.Tag = row_index.ToString
        txttxbtnControl2.Location = rect.Location
        txttxbtnControl2.Size = rect.Size
        txttxbtnControl2.renderControl()
        txttxbtnControl2.Visible = True
    End Sub
    Private Sub response_col(ByVal row_index As Integer, ByRef is_approved As Integer)
        Dim rect As Rectangle = Me.dtgcv_notifs.GetCellDisplayRectangle(9, row_index, True)
        Dim txttxbtnControl2 As New userbtnAccept
        txttxbtnControl2.Name = "usercontrol" + row_index.ToString
        dtgcv_notifs.Controls.Add(txttxbtnControl2)
        txttxbtnControl2.Location = rect.Location
        txttxbtnControl2.Size = rect.Size
        If is_approved = 1 Then
            txttxbtnControl2.Button1.Text = "Accepted"
            txttxbtnControl2.Button1.BackColor = Color.LimeGreen
        Else
            txttxbtnControl2.Button1.Text = "Declined"
            txttxbtnControl2.Button1.BackColor = Color.Red
        End If
        txttxbtnControl2.Button1.Tag = row_index.ToString
        txttxbtnControl2.renderControl()
        txttxbtnControl2.Visible = True
    End Sub
    Private Sub get_notifs()
        ds.Clear()
        Try
            Dim strquery As String
            If UserType = 0 Then 'secretary
                strquery = "SELECT pc.server_id,c.name,CONCAT(d.lname,' ',d.mname,'',d.fname) as doctor_name,CONCAT(p.lname,' ',p.mname,'',p.fname) as patient_name,pc.date,pc.time,pc.comment_doctor,pc.comment_patient,pc.is_approved_patient,pc.is_approved FROM doctors d INNER JOIN `consultations_request` pc on pc.doctor_id=d.id INNER JOIN patients p on p.server_id=pc.patient_id INNER JOIN clinics c on c.id=pc.clinic_id INNER JOIN secretary_access sa on sa.doctor_id=d.id WHERE sa.secretary_id=" + UserId.ToString
            Else 'doctor
                strquery = "SELECT pc.server_id,c.name,CONCAT(d.lname,' ',d.mname,'',d.fname) as doctor_name,CONCAT(p.lname,' ',p.mname,'',p.fname) as patient_name,pc.date,pc.time,pc.comment_doctor,pc.comment_patient,pc.is_approved_patient,pc.is_approved FROM doctors d INNER JOIN `consultations_request` pc on pc.doctor_id=d.id INNER JOIN patients p on p.server_id=pc.patient_id INNER JOIN clinics c on c.id=pc.clinic_id WHERE d.id=" + UserId.ToString
            End If
            da = New MySqlDataAdapter(strquery, conn)
            da.Fill(ds)
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim server_id As Integer = ds.Tables(0).Rows(i).Item(0)
                Dim clinic_name As String = ds.Tables(0).Rows(i).Item(1).ToString
                Dim doctor_name As String = ds.Tables(0).Rows(i).Item(2).ToString
                Dim patient_name As String = ds.Tables(0).Rows(i).Item(3).ToString
                Dim sched_date As String = Convert.ToDateTime(ds.Tables(0).Rows(i).Item(4)).ToShortDateString
                Dim sched_time As String = ds.Tables(0).Rows(i).Item(5).ToString
                Dim sched As String = ""
                If Not sched_time = "" Then
                    sched = Convert.ToDateTime(sched_date + " " + sched_time).ToShortTimeString
                End If

                Dim comment_doctor As String = ds.Tables(0).Rows(i).Item(6).ToString
                Dim comment_patient As String = ds.Tables(0).Rows(i).Item(7).ToString
                Dim is_approved_patient As Integer = ds.Tables(0).Rows(i).Item(8)
                Dim patient_acceptance As String = ""
                If is_approved_patient = 0 Then
                    patient_acceptance = " Pending "
                ElseIf is_approved_patient = 1 Then
                    patient_acceptance = " Accepted "
                ElseIf is_approved_patient = 2 Then
                    patient_acceptance = " Cancelled "
                End If
                Dim is_approved As Integer = ds.Tables(0).Rows(i).Item(9)
                dtgcv_notifs.Rows.Add(server_id, clinic_name, doctor_name, patient_name, sched_date, sched, comment_doctor, comment_patient, patient_acceptance, "")
                If is_approved = 0 Then
                    no_response_col(i)
                Else
                    response_col(i, is_approved)
                End If

            Next

        Catch ex As Exception

        End Try
    End Sub
    Public Sub accept(ByRef rowindex As Integer, ByRef t As Date, ByRef comment As String)
        Try
            cmd = New MySqlCommand("UPDATE `consultations_request` SET comment_doctor=@comment, `is_approved`=1,time='" + t.TimeOfDay.ToString + "',`updated_at`=CURRENT_TIMESTAMP WHERE server_id=" + dtgcv_notifs.Rows(rowindex).Cells(0).Value.ToString, conn)
            cmd.Parameters.AddWithValue("comment", comment)
            cmd.ExecuteNonQuery()
            dtgcv_notifs.Controls.RemoveByKey("usercontrol" + rowindex.ToString)
            dtgcv_notifs.Rows(rowindex).Cells(5).Value = t.ToShortTimeString
            response_col(rowindex, 1)
            Dim notif_count As Integer = Convert.ToInt32(main_menu.notification_label.Text) - 1
            If Not notif_count = 0 Then
                main_menu.notification_label.Text = notif_count.ToString
            Else
                main_menu.notification_label.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub decline(ByRef rowindex As Integer, ByRef comment As String)
        Try
            cmd = New MySqlCommand("UPDATE `consultations_request` SET comment_doctor=@comment,`is_approved`=2,`updated_at`=CURRENT_TIMESTAMP WHERE server_id=" + dtgcv_notifs.Rows(rowindex).Cells(0).Value.ToString, conn)
            cmd.Parameters.AddWithValue("comment", comment)
            cmd.ExecuteNonQuery()
            dtgcv_notifs.Controls.RemoveByKey("usercontrol" + rowindex.ToString)
            response_col(rowindex, 2)
            Dim notif_count As Integer = Convert.ToInt32(main_menu.notification_label.Text) - 1
            If Not notif_count = 0 Then
                main_menu.notification_label.Text = notif_count.ToString
            Else
                main_menu.notification_label.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Notification_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class
