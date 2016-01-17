Imports System.Net
Imports System.Text
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Public Class mysqbridge_upload
    Public Shared Function POST_DATA(ByRef url As String, ByRef postData As String) As String
        Dim responseFromServer As String = ""
        Try
            Dim request As WebRequest = WebRequest.Create(url)
            ' Set the Method property of the request to POST.
            request.Method = "POST"
            ' Create POST data and convert it to a byte array.
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            ' Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded"
            ' Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length
            ' Get the request stream.
            Dim dataStream As Stream = request.GetRequestStream()
            ' Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length)
            ' Close the Stream object.
            dataStream.Close()
            ' Get the response.
            Dim response As WebResponse = request.GetResponse()
            ' Display the status.
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            ' Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(dataStream)
            ' Read the content.
            responseFromServer = reader.ReadToEnd()
            ' Display the content.
            ' Clean up the streams.
            reader.Close()
            dataStream.Close()
            response.Close()
        Catch ex As Exception

        End Try
        Return responseFromServer
    End Function

    Public Shared Sub UPLOAD_PATIENT()
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand
        Try

            da = New MySqlDataAdapter("SELECT `id`, `fname`, `mname`, `lname`, `mobile_no`, `tel_no`,`occupation`,`birthdate`, `sex`, `civil_status`, `height`, `weight`, `address_house_no`, `address_street`, `barangay_id`, `server_id` FROM `patients` WHERE server_id=6 or updated_at>'" + My.Settings.Last_Update + "'", conn)
            da.Fill(ds, "patients")
            If ds.Tables("patients").Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables("patients").Rows.Count - 1
                    With ds.Tables("patients").Rows(i)
                        Dim poststring As String = ""

                        poststring = String.Format("fname={0}&mname={1}&lname={2}&mobile_no={3}&tel_no={4}&occupation={5}& birthdate={6}& sex={7} &civil_status={8}& height={9} &weight={10}& optional_address={11}& address_street={12}& brgy_id={13}&action_type={14}&clinic_id={15}&server_id={16}",
                                                   .Item(1).ToString, .Item(2).ToString, .Item(3).ToString, .Item(4).ToString, .Item(5).ToString, .Item(6).ToString, Convert.ToDateTime(.Item(7)).ToString("yyyy-MM-dd"),
                                                   .Item(8).ToString, .Item(9).ToString, .Item(10).ToString, .Item(11).ToString, .Item(12).ToString, .Item(13).ToString, .Item(14).ToString, "2", My.Settings.ClinicID.ToString, .Item(15).ToString)
                        'MsgBox(poststring)
                        Dim response As String = POST_DATA("http://localhost/E-Clinic/upload.php", poststring)
                        'main_menu.TextBox1.Text = response
                        If .Item(15) = 0 Then 'insert
                            Try
                                If IsNumeric(response) Then
                                    cmd = New MySqlCommand("UPDATE `patients` SET `server_id`=" + response + " where id=" + .Item(0).ToString, conn)
                                    cmd.ExecuteNonQuery()
                                Else

                                End If
                            Catch ex As Exception

                            End Try
                        End If
                    End With
                Next

            End If
        Catch ex As Exception

        End Try



        Try

            da = New MySqlDataAdapter("SELECT dp.`id`, dp.`clinic_id`, dp.`doctor_id`, p.`server_id`, dp.`username`, dp.`password`, dp.`created_at`, dp.`updated_at`, dp.`server_id` FROM `doctor_patient` dp INNER JOIN patients p on p.id=dp.patient_id WHERE dp.server_id=0 OR dp.updated_at>'" + My.Settings.Last_Update + "'", conn)
            da.Fill(ds, "credentials")
            If ds.Tables("credentials").Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables("credentials").Rows.Count - 1
                    With ds.Tables("credentials").Rows(i)
                        Dim poststring As String = ""
                        poststring = String.Format("clinic_id_source={0}&doctor_id={1}&patient_id={2}&username={3}&password={4}&action_type={5}&clinic_id={6}&server_id={7}",
                                                       .Item(1).ToString, .Item(2).ToString, .Item(3).ToString, .Item(4).ToString, .Item(5).ToString, "3", My.Settings.ClinicID.ToString, .Item(8).ToString)
                        'MsgBox(poststring)
                        Dim response As String = POST_DATA("http://localhost/E-Clinic/upload.php", poststring)
                        If .Item(8) = 0 Then 'insert
                            Try
                                If IsNumeric(response) Then

                                    cmd = New MySqlCommand("UPDATE `doctor_patient` SET `server_id`=" + response + " where id=" + .Item(0).ToString, conn)
                                    cmd.ExecuteNonQuery()
                                Else

                                End If
                            Catch ex As Exception

                            End Try
                        End If

                    End With
                Next

            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Sub UPLOAD_APPOINTMENTS()
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        Try
            da = New MySqlDataAdapter("SELECT `server_id`,`time`, `comment_doctor`,`is_approved` FROM `consultations_request` WHERE updated_at>'" + My.Settings.Last_Update + "'", conn)
            da.Fill(ds, "appointments")
            If ds.Tables("appointments").Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables("appointments").Rows.Count - 1
                    With ds.Tables("appointments").Rows(i)
                        Dim poststring As String = ""
                        poststring = String.Format("id={0}&time={1}&is_approved={2}&comment_doctor={3}&action_type={4}&clinic_id={5}", .Item(0).ToString, Convert.ToDateTime("11/9/2015 " + .Item(1).ToString).ToShortTimeString, .Item(3).ToString, .Item(2).ToString, "4", My.Settings.ClinicID.ToString)
                        'MsgBox(poststring)
                        Dim response As String = POST_DATA("http://localhost/E-Clinic/upload.php", poststring)
                        MsgBox(response)
                    End With
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function UPLOAD_MEDICALREQUEST(ByRef patient_id As Integer, ByRef doctor_id As Integer, ByRef clinic_id As Integer) As Integer
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand
        Try
            Dim poststring As String = ""
            Dim uname As String = randomuname("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890")
            Dim pword As String = randomuname("ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz")
            poststring = String.Format("id={0}&action_type={1}&clinic_id={2}&clinic_id_source={3}&doctor_id={4}&username={5}&password={6}", patient_id.ToString, "6", My.Settings.ClinicID.ToString, clinic_id.ToString,
                                       doctor_id.ToString, uname, pword)
            'MsgBox(poststring)
            Dim response As String = POST_DATA("http://localhost/E-Clinic/upload.php", poststring)

            Dim userobject As rootID = JsonConvert.DeserializeObject(Of rootID)(response)

            Try
                    Dim clinic_patient_id As Integer = userobject.ids.Item(0).user_id
                    cmd = New MySqlCommand("INSERT INTO `doctor_patient`(`clinic_id`, `doctor_id`, `patient_id`, `app_user_id`, `username`, `password`, `created_at`,`server_id`) VALUES " +
                                           "(" + clinic_id.ToString + "," + doctor_id.ToString + "," + clinic_patient_id.ToString + "," + patient_id.ToString + ",'" + uname + "','" + pword + "',CURRENT_TIMESTAMP," + userobject.ids.Item(0).server_id.ToString + " )", conn)
                    cmd.ExecuteNonQuery()
                    Return clinic_patient_id
            Catch ex As Exception

            End Try

        Catch ex As Exception

        End Try
        Return 0
    End Function

    Public Shared Sub UPLOAD_PATIENT_RECORDS()
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand
        Try

            da = New MySqlDataAdapter("SELECT pr.`id`,p.server_id, pr.`doctor_id`, pr.`complaints`, pr.`findings`, pr.`note`, pr.`created_at`,pr.server_id FROM `patient_records` pr INNER JOIN patients p on p.id=pr.patient_id where pr.server_id=0 or pr.updated_at>'" + My.Settings.Last_Update + "'", conn)
            da.Fill(ds, "records")
            If ds.Tables("records").Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables("records").Rows.Count - 1
                    With ds.Tables("records").Rows(i)
                        Dim patient_record_id As Integer = 0
                        Dim poststring As String = ""
                        'insert
                        poststring = String.Format("patient_id={0}&doctor_id={1}&complaints={2}&findings={3}&datetime={4}&note={5}&action_type={6}&clinic_id={7}&server_id={8}",
                                                   .Item(1).ToString, .Item(2).ToString, .Item(3).ToString, .Item(4).ToString, .Item(6).ToString, .Item(5).ToString, "7", My.Settings.ClinicID.ToString, .Item(7).ToString)
                        MsgBox(poststring)

                        Dim response As String = POST_DATA("http://localhost/E-Clinic/upload.php", poststring)
                        main_menu.TextBox1.Text = response
                        If .Item(7) = 0 Then

                            Try
                                If IsNumeric(response) Then
                                    cmd = New MySqlCommand("UPDATE `patient_records` SET `server_id`=" + response + " where id=" + .Item(0).ToString, conn)
                                    cmd.ExecuteNonQuery()
                                    patient_record_id = Convert.ToInt32(response)
                                Else

                                End If
                            Catch ex As Exception

                            End Try
                        Else 'update
                            patient_record_id = .Item(7)
                        End If
                        da = New MySqlDataAdapter("SELECT m.`server_id`, p.`no_generics`, p.`quantity`, p.`route`, p.`frequency`, p.`refills`, p.`duration`, p.`duration_type` FROM `prescription_items` p INNER JOIN medicines m on m.id=p.medicine_id WHERE p.patient_record_id=" + .Item(0).ToString, conn)
                        da.Fill(ds, "treatments")
                        Dim strquery As String = "INSERT INTO `clinic_treatments`(`patient_record_id`, `medicine_id`, `no_generics`, `quantity`, `route`, `frequency`, `refills`, `duration`, `duration_type`, `created_at`) VALUES "
                        If ds.Tables("treatments").Rows.Count > 0 Then
                            For j As Integer = 0 To ds.Tables("treatments").Rows.Count - 1
                                With ds.Tables("treatments").Rows(j)
                                    If j > 0 Then
                                        strquery = strquery + ", (" + patient_record_id.ToString + "," + .Item(0).ToString + "," + .Item(1).ToString + "," + .Item(2).ToString + ",'" + .Item(3).ToString + "','" + .Item(4).ToString + "'," + .Item(5).ToString + "," + .Item(6).ToString + "," + .Item(7).ToString + ",CURRENT_TIMESTAMP)"
                                    Else
                                        strquery = strquery + " (" + patient_record_id.ToString + "," + .Item(0).ToString + "," + .Item(1).ToString + "," + .Item(2).ToString + ",'" + .Item(3).ToString + "','" + .Item(4).ToString + "'," + .Item(5).ToString + "," + .Item(6).ToString + "," + .Item(7).ToString + ",CURRENT_TIMESTAMP)"
                                    End If
                                End With

                            Next
                            poststring = String.Format("prescription_query={0}&action_type={1}&clinic_id={2}&server_id={3}",
                                                   strquery, "9", My.Settings.ClinicID.ToString, patient_record_id.ToString)
                            Dim response2 As String = POST_DATA("http://localhost/E-Clinic/upload.php", poststring)
                            MsgBox("reponse")
                        End If
                        main_menu.TextBox1.Text = poststring

                    End With
                Next


            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub UPLOAD_MEDICINES()
        Dim da As New MySqlDataAdapter
        Dim ds As New DataSet
        Dim cmd As New MySqlCommand
        Try

            da = New MySqlDataAdapter("SELECT `id`, `med_name`, `server_id` FROM `medicines` WHERE server_id=0 OR updated_at>'" + My.Settings.Last_Update + "'", conn)
            da.Fill(ds, "patients")
            If ds.Tables("patients").Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables("patients").Rows.Count - 1
                    With ds.Tables("patients").Rows(i)
                        Dim poststring As String = ""
8:
                        poststring = String.Format("med_name={0}&server_id={1}&action_type={2}&clinic_id={3}",
                                                   .Item(1).ToString, .Item(2).ToString, "8", My.Settings.ClinicID.ToString)
                        MsgBox(poststring)
                        Dim response As String = POST_DATA("http://localhost/E-Clinic/upload.php", poststring)
                        'main_menu.TextBox1.Text = response
                        If .Item(2) = 0 Then 'insert
                            Try
                                If IsNumeric(response) Then
                                    cmd = New MySqlCommand("UPDATE `medicines` SET `server_id`=" + response + " where id=" + .Item(0).ToString, conn)
                                    cmd.ExecuteNonQuery()
                                Else

                                End If
                            Catch ex As Exception

                            End Try
                        End If
                    End With
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class rootID
    Public Property ids() As List(Of id_items)
        Get
            Return m_ids
        End Get
        Set(ByVal value As List(Of id_items))
            m_ids = value
        End Set
    End Property
    Private m_ids As List(Of id_items)
End Class
Public Class id_items
    Public Property user_id() As Integer
        Get
            Return m_user_id
        End Get
        Set(ByVal value As Integer)
            m_user_id = value
        End Set
    End Property
    Private m_user_id As Integer

    Public Property server_id() As Integer
        Get
            Return m_server_id
        End Get
        Set(ByVal value As Integer)
            m_server_id = value
        End Set
    End Property
    Private m_server_id As Integer
End Class