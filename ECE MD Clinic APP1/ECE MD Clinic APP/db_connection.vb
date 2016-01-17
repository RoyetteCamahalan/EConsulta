Imports MySql.Data.MySqlClient
Imports System.Net
Module db_connection
    Public conn As New MySqlConnection
    Private webhost_conn As New MySqlConnection
    Private cmd As New MySqlCommand
    Private da As New MySqlDataAdapter
    Private ds As New DataSet
    Public UserName, PassWord As String
    Public UserId As Integer
    Public UserType As Integer
    Public url_downloaddate As String
    Public Function connect() As Boolean

        Dim dbname As String = "ece_pharmacy_tree"
        Dim dbhost As String = "127.0.0.1"
        Dim user As String = "root"
        Dim pass As String = ""
        'Dim dbname As String = "vbfcbry0_CCCS_Scheduler"
        'Dim dbhost As String = "bsit701.com"
        'Dim user As String = "vbfcbry07"
        'Dim pass As String = "trusted143"
        Try
            conn.ConnectionString = String.Format("Server={0};Port=3306;Database={3};UID={1}; PASSWORD={2};Connect Timeout = 10000000;pooling=true", dbhost, user, pass, dbname)
            conn.Open()
            Return True
        Catch ex As Exception
            MsgBox("Cannot connect to specified server.")
            Return False
        End Try

    End Function
    Public Function connecttoserver() As Boolean
        Dim dbname As String = "ece_pharmacy_tree"
        Dim dbhost As String = "159.203.111.108"
        Dim user As String = "uret"
        Dim pass As String = "01gwapoko01"

        Try
            webhost_conn.ConnectionString = String.Format("Server={0};Port=3306;Database={3};UID={1}; PASSWORD={2};Connect Timeout = 10000000;pooling=true", dbhost, user, pass, dbname)
            webhost_conn.Open()
            Return True
        Catch ex As Exception
            MsgBox("Cannot connect to specified server." + ex.ToString)
            Return False
        End Try

    End Function
    Public Function randomuname(ByRef validchars As String) As String

        Dim sb As New System.Text.StringBuilder
        Dim rand As New Random()
        For i As Integer = 1 To 6
            Dim idx As Integer = rand.Next(0, validchars.Length)
            Dim randomChar As Char = validchars(idx)
            sb.Append(randomChar)
        Next i

        Return sb.ToString()
    End Function

    Public Sub SyncFromWeb()
        webhost_conn.Open()
        Try

        Catch ex As Exception

        End Try
        webhost_conn.Close()
    End Sub
    Public Sub SyncToWeb()

        If connecttoserver() Then
            Try
                ds.Clear()
                'upload_Patients()
                'upload_Doctors()
                upload_Patien_Record()

                
                My.Settings.Last_Update = Date.Now
                MsgBox(My.Settings.Last_Update)
                My.Settings.Save()
            Catch ex As Exception

            End Try
            webhost_conn.Close()
        End If
        


    End Sub
    Public Sub upload_Patients()
        'Patient Upload
        Dim RowCount As Integer
        da = New MySqlDataAdapter("SELECT * from patients where server_id=0 or updated_at >'" + My.Settings.Last_Update + "'", conn)
        da.Fill(ds, "patients")
        RowCount = ds.Tables("patients").Rows.Count
        For i = 0 To RowCount - 1
            If ds.Tables("patients").Rows(i).Item(33) <> 0 Then
                'update here
                Dim update_str As String = String.Format("Update `ece_pharmacy_tree`.`patients` set " +
              "fname='{0}', mname='{1}', lname='{2}', occupation='{3}', birthdate='{4}', sex='{5}', civil_status='{6}', height='{7}', weight='{8}', address_house_no={9}, address_street='{10}'," +
              "address_barangay='{11}', address_city_municipality='{12}', address_province='{13}', address_region='{14}', address_zip='{15}',updated_at=CURRENT_TIMESTAMP, `email_address`='{16}', `mobile_no`='{17}', `tel_no`='{18}',`unit_floor_room_no`={19}, `building`='{20}', `lot_no`={21}, `block_no`={22}, `phase_no`={23},`username`='{24}', `password`='{25}' where id={26}",
                  ds.Tables("patients").Rows(i).Item(1).ToString,
                  ds.Tables("patients").Rows(i).Item(2).ToString,
                  ds.Tables("patients").Rows(i).Item(3).ToString,
                  ds.Tables("patients").Rows(i).Item(10).ToString,
                  ds.Tables("patients").Rows(i).Item(13).ToString,
                  ds.Tables("patients").Rows(i).Item(14).ToString,
                  ds.Tables("patients").Rows(i).Item(15).ToString,
                  ds.Tables("patients").Rows(i).Item(16).ToString,
                  ds.Tables("patients").Rows(i).Item(17).ToString,
                  ds.Tables("patients").Rows(i).Item(23).ToString,
                  ds.Tables("patients").Rows(i).Item(24).ToString,
                  ds.Tables("patients").Rows(i).Item(25).ToString,
                  ds.Tables("patients").Rows(i).Item(26).ToString,
                  ds.Tables("patients").Rows(i).Item(27).ToString,
                  ds.Tables("patients").Rows(i).Item(28).ToString,
                  ds.Tables("patients").Rows(i).Item(29).ToString,
                  ds.Tables("patients").Rows(i).Item(6).ToString,
                  ds.Tables("patients").Rows(i).Item(7).ToString,
                  ds.Tables("patients").Rows(i).Item(8).ToString,
                  ds.Tables("patients").Rows(i).Item(18).ToString,
                  ds.Tables("patients").Rows(i).Item(19).ToString,
                  ds.Tables("patients").Rows(i).Item(20).ToString,
                  ds.Tables("patients").Rows(i).Item(21).ToString,
                  ds.Tables("patients").Rows(i).Item(22).ToString,
                  ds.Tables("patients").Rows(i).Item(4).ToString,
                  ds.Tables("patients").Rows(i).Item(5).ToString,
                  ds.Tables("patients").Rows(i).Item(33).ToString)
                cmd = New MySqlCommand(update_str, webhost_conn)
                cmd.ExecuteNonQuery()

            Else
                'insert here without photo
                Try
                    Dim insert_str As String = String.Format("Insert into `ece_pharmacy_tree`.`patients` " +
                "(fname, mname, lname, occupation, birthdate, sex, civil_status, height, weight, address_house_no, address_street, address_barangay, address_city_municipality, address_province, address_region, address_zip,created_at, `email_address`, `mobile_no`, `tel_no`,`unit_floor_room_no`, `building`, `lot_no`, `block_no`, `phase_no`,`username`, `password`) values" +
                " ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}','{11}','{12}','{13}','{14}','{15}',CURRENT_TIMESTAMP,'{16}','{17}','{18}',{19},'{20}',{21},{22},{23},'{24}','{25}')",
                    ds.Tables("patients").Rows(i).Item(1).ToString,
                    ds.Tables("patients").Rows(i).Item(2).ToString,
                    ds.Tables("patients").Rows(i).Item(3).ToString,
                    ds.Tables("patients").Rows(i).Item(10).ToString,
                    ds.Tables("patients").Rows(i).Item(13).ToString,
                    ds.Tables("patients").Rows(i).Item(14).ToString,
                    ds.Tables("patients").Rows(i).Item(15).ToString,
                    ds.Tables("patients").Rows(i).Item(16).ToString,
                    ds.Tables("patients").Rows(i).Item(17).ToString,
                    ds.Tables("patients").Rows(i).Item(23).ToString,
                    ds.Tables("patients").Rows(i).Item(24).ToString,
                    ds.Tables("patients").Rows(i).Item(25).ToString,
                    ds.Tables("patients").Rows(i).Item(26).ToString,
                    ds.Tables("patients").Rows(i).Item(27).ToString,
                    ds.Tables("patients").Rows(i).Item(28).ToString,
                    ds.Tables("patients").Rows(i).Item(29).ToString,
                    ds.Tables("patients").Rows(i).Item(6).ToString,
                    ds.Tables("patients").Rows(i).Item(7).ToString,
                    ds.Tables("patients").Rows(i).Item(8).ToString,
                    ds.Tables("patients").Rows(i).Item(18).ToString,
                    ds.Tables("patients").Rows(i).Item(19).ToString,
                    ds.Tables("patients").Rows(i).Item(20).ToString,
                    ds.Tables("patients").Rows(i).Item(21).ToString,
                    ds.Tables("patients").Rows(i).Item(22).ToString,
                    ds.Tables("patients").Rows(i).Item(4).ToString,
                    ds.Tables("patients").Rows(i).Item(5).ToString)
                    cmd = New MySqlCommand(insert_str, webhost_conn)
                    cmd.ExecuteNonQuery()

                    da = New MySqlDataAdapter("SELECT MAX(id) from patients", webhost_conn)
                    Dim ds1 As New DataSet
                    da.Fill(ds1)
                    cmd = New MySqlCommand("UPDATE `patients` SET `server_id`=@server_id where id=@id", conn)
                    cmd.Parameters.AddWithValue("server_id", ds1.Tables(0).Rows(0).Item(0))
                    cmd.Parameters.AddWithValue("id", ds.Tables("patients").Rows(i).Item(0).ToString)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try
                
            End If
        Next
    End Sub
    Public Sub upload_Doctors()
        'Doctor Upload
        Dim RowCount As Integer
        da = New MySqlDataAdapter("SELECT `id`, `lname`, `mname`, `fname`, `prc_no`, `sub_specialty_id`, `affiliation`, `email`,server_id FROM `doctors` where server_id=0 or updated_at >'" + My.Settings.Last_Update + "'", conn)
        da.Fill(ds, "doctors")
        RowCount = ds.Tables("doctors").Rows.Count
        For i = 0 To RowCount - 1
            If ds.Tables("doctors").Rows(i).Item(8) <> 0 Then

            Else
                Try
                    Dim insert_str As String = String.Format("INSERT INTO `doctors`(`lname`, `mname`, `fname`, `prc_no`, `sub_specialty_id`, `affiliation`, `email`, `created_at`) values" +
                    " ('{0}','{1}','{2}',{3},5,'{4}','{5}',CURRENT_TIMESTAMP)",
                    ds.Tables("doctors").Rows(i).Item(1).ToString,
                    ds.Tables("doctors").Rows(i).Item(2).ToString,
                    ds.Tables("doctors").Rows(i).Item(3).ToString,
                    ds.Tables("doctors").Rows(i).Item(4).ToString,
                    ds.Tables("doctors").Rows(i).Item(6).ToString,
                    ds.Tables("doctors").Rows(i).Item(7).ToString)
                    cmd = New MySqlCommand(insert_str, webhost_conn)
                    cmd.ExecuteNonQuery()

                    da = New MySqlDataAdapter("SELECT MAX(id) from doctors", webhost_conn)
                    Dim ds1 As New DataSet
                    da.Fill(ds1)
                    cmd = New MySqlCommand("UPDATE `doctors` SET `server_id`=@server_id where id=@id", conn)
                    cmd.Parameters.AddWithValue("server_id", ds1.Tables(0).Rows(0).Item(0))
                    cmd.Parameters.AddWithValue("id", ds.Tables("doctors").Rows(i).Item(0).ToString)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception

                End Try

            End If
        Next

        
    End Sub
    Public Sub upload_Patien_Record()
        'Patient Record Upload
        Try
            Dim RowCount As Integer
            da = New MySqlDataAdapter("SELECT pr.id,p.server_id,d.server_id,pr.complaints,pr.findings,pr.record_date,pr.note,pr.created_at FROM patient_records pr " +
                                        "INNER JOIN patients p on p.id=pr.patient_id " +
                                        "INNER JOIN doctors d on d.id=pr.doctor_id where pr.server_id=0 or pr.updated_at >'" + My.Settings.Last_Update + "'", conn)
            da.Fill(ds, "patient_record")
            RowCount = ds.Tables("patient_record").Rows.Count
            For i = 0 To RowCount - 1
                If ds.Tables("patient_record").Rows(i).Item(10) <> 0 Then
                    'Update Patient Record
                    cmd = New MySqlCommand("UPDATE `patient_records` SET `patient_id`=@patientid,`doctor_id`=@doctorid,`complaints`=@complaints,`findings`=@findings,notes=@notes,`updated_at`=CURRENT_TIMESTAMP where id=@id", webhost_conn)
                    cmd.Parameters.AddWithValue("patientid", ds.Tables("patient_record").Rows(i).Item(1).ToString)
                    cmd.Parameters.AddWithValue("doctorid", ds.Tables("patient_record").Rows(i).Item(2).ToString)
                    cmd.Parameters.AddWithValue("complaints", ds.Tables("patient_record").Rows(i).Item(3).ToString)
                    cmd.Parameters.AddWithValue("findings", ds.Tables("patient_record").Rows(i).Item(4).ToString)
                    cmd.Parameters.AddWithValue("notes", ds.Tables("patient_record").Rows(i).Item(6).ToString)
                    cmd.Parameters.AddWithValue("id", ds.Tables("patient_record").Rows(i).Item(10).ToString)
                    'cmd.ExecuteNonQuery()
                    Dim ds1 As New DataSet
                    da = New MySqlDataAdapter("select * from treatments where patient_record_id=" + ds.Tables("patient_record").Rows(i).Item(0).ToString, conn)
                    da.Fill(ds1, "treatments")
                    If ds1.Tables("treatments").Rows.Count > 0 Then
                        Dim update_sql2 As String = String.Format("delete from `treatments` where patient_record_id=" + ds.Tables("patient_record").Rows(i).Item(0).ToString)
                        cmd = New MySqlCommand(update_sql2, webhost_conn)
                        'cmd.ExecuteNonQuery()
                        'For i As Integer = 0 To ds1.Tables("treatments").Rows.Count - 1
                        '    cmd = New MySqlCommand("INSERT INTO `treatments`(`patient_record_id`, `medicine_name`, `generic_name`, `quantity`, `prescription`, `created_at`) VALUES (@patient_record_id,@medicine_name,@generic_name,@quantity,@presciption,CURRENT_TIMESTAMP)", webhost_conn)
                        '    cmd.Parameters.AddWithValue("patient_record_id", ds.Tables("patient_record").Rows(i).Item(0).ToString)
                        '    cmd.Parameters.AddWithValue("medicine_name", ds1.Tables("patient_record").Rows(i).Item(1).ToString)
                        '    cmd.Parameters.AddWithValue("generic_name", ds1.Tables("patient_record").Rows(i).Item(1).ToString)
                        '    cmd.Parameters.AddWithValue("quantity", ds1.Tables("patient_record").Rows(i).Item(1).ToString)
                        '    cmd.Parameters.AddWithValue("presciption", ds1.Tables("patient_record").Rows(i).Item(1).ToString)
                        '    cmd.ExecuteNonQuery()

                        'Next
                    End If
                Else
                    'Insert Patient Record
                    cmd = New MySqlCommand("INSERT INTO `patient_records`( `patient_id`, `doctor_id`, `complaints`, `findings`,note, `created_at`) VALUES (@patientid,@doctorid,@complaints,@findings,@notes,CURRENT_TIMESTAMP)", webhost_conn)
                    cmd.Parameters.AddWithValue("patientid", ds.Tables("patient_record").Rows(i).Item(1).ToString)
                    cmd.Parameters.AddWithValue("doctorid", ds.Tables("patient_record").Rows(i).Item(2).ToString)
                    cmd.Parameters.AddWithValue("complaints", ds.Tables("patient_record").Rows(i).Item(3).ToString)
                    cmd.Parameters.AddWithValue("findings", ds.Tables("patient_record").Rows(i).Item(4).ToString)
                    cmd.Parameters.AddWithValue("notes", ds.Tables("patient_record").Rows(i).Item(6).ToString)
                    cmd.ExecuteNonQuery()
                    Dim ds1 As New DataSet
                    Dim treatment_id As Integer
                    da = New MySqlDataAdapter("select max(id) from patient_records", webhost_conn)
                    da.Fill(ds1, "id")
                    da = New MySqlDataAdapter("select * from treatments where patient_record_id=" + ds.Tables("patient_record").Rows(i).Item(0).ToString, conn)
                    da.Fill(ds1, "treatments")
                    treatment_id = ds1.Tables("id").Rows(0).Item(0)
                    If ds1.Tables("treatments").Rows.Count > 0 Then
                        For j As Integer = 0 To ds1.Tables("treatments").Rows.Count - 1
                            cmd = New MySqlCommand("INSERT INTO `treatments`(`patient_record_id`, `medicine_name`, `generic_name`, `quantity`, `prescription`, `created_at`) VALUES (@patient_record_id,@medicine_name,@generic_name,@quantity,@presciption,CURRENT_TIMESTAMP)", webhost_conn)
                            cmd.Parameters.AddWithValue("patient_record_id", treatment_id.ToString)
                            cmd.Parameters.AddWithValue("medicine_name", ds1.Tables("treatments").Rows(j).Item(1).ToString)
                            cmd.Parameters.AddWithValue("generic_name", ds1.Tables("treatments").Rows(j).Item(2).ToString)
                            cmd.Parameters.AddWithValue("quantity", ds1.Tables("treatments").Rows(j).Item(3).ToString)
                            cmd.Parameters.AddWithValue("presciption", ds1.Tables("treatments").Rows(j).Item(4).ToString)
                            cmd.ExecuteNonQuery()
                        Next
                    End If
                    cmd = New MySqlCommand("update `patient_records` set `server_id`=@server_id where id=@id", conn)
                    cmd.Parameters.AddWithValue("server_id", treatment_id.ToString)
                    cmd.Parameters.AddWithValue("id", ds.Tables("patient_record").Rows(i).Item(0).ToString)
                    cmd.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception

        End Try
        
    End Sub
End Module
