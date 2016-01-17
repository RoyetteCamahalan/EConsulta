Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class mysqlbridge


    Public Shared Sub get_appointments()
        Try
            main_menu.TextBox1.Text = "http://localhost/E-Clinic/sample.php?" + "last_update=" + My.Settings.Last_Update_Web.ToString + "&&clinic_id=" + My.Settings.ClinicID.ToString
            Dim request As HttpWebRequest = WebRequest.Create("http://localhost/E-Clinic/sample.php?" + "last_update=" + My.Settings.Last_Update_Web.ToString + "&&clinic_id=" + My.Settings.ClinicID.ToString)
            request.Method = WebRequestMethods.Http.Get
            request.ContentType = "application/json"
            Dim response1 As HttpWebResponse = request.GetResponse

            Dim receivestream As StreamReader = New StreamReader(response1.GetResponseStream)
            Dim strjson As String = ""

            strjson = receivestream.ReadToEnd

            Dim Testobject As RootObject = JsonConvert.DeserializeObject(Of RootObject)(strjson)
            For i As Integer = 0 To Testobject.appointments.Count - 1
                Dim m_id As Integer = Testobject.appointments.Item(i).id
                Dim m_patient_id As Integer = Testobject.appointments.Item(i).patient_id
                Dim m_clinic_patient_id As Integer = Testobject.appointments.Item(i).clinic_patient_id
                Dim m_doctor_id As Integer = Testobject.appointments.Item(i).doctor_id
                Dim m_clinic_id As Integer = Testobject.appointments.Item(i).clinic_id
                Dim m_date As String = Testobject.appointments.Item(i).appointment_date.ToString
                Dim m_time As String = Testobject.appointments.Item(i).time.ToString
                Dim m_is_approved As Integer = Testobject.appointments.Item(i).is_approved
                Dim m_is_approved_patient As Integer = Testobject.appointments.Item(i).is_approved_patient
                Dim m_created_at As String = Testobject.appointments.Item(i).created_at.ToString
                Dim m_updated_at As String = Testobject.appointments.Item(i).updated_at.ToString
                Dim ds As New DataSet
                Dim da As New MySqlDataAdapter
                da = New MySqlDataAdapter("SELECT id FROM consultations_request WHERE server_id=" + m_id.ToString, conn)
                da.Fill(ds, "appointments")
                If ds.Tables("appointments").Rows.Count > 0 Then 'update
                    Dim cmd As New MySqlCommand
                    Dim insert_sql As String = String.Format("UPDATE `consultations_request` SET `doctor_id`={0}, `date`='{1}', `time`='{2}', `comment_doctor`=@notes,`comment_patient`=@notes1,  `is_approved`={3},is_approved_patient=" + m_is_approved_patient.ToString + " WHERE `server_id`={4} ",
                                                                     m_doctor_id.ToString, m_date, m_time, m_is_approved.ToString, m_id.ToString)

                    cmd = New MySqlCommand(insert_sql, conn)
                    cmd.Parameters.AddWithValue("notes", Testobject.appointments.Item(i).comment_doctor)
                    cmd.Parameters.AddWithValue("notes1", Testobject.appointments.Item(i).comment_patient)
                    cmd.ExecuteNonQuery()
                    If m_is_approved = 1 And m_is_approved_patient = 1 Then
                        da = New MySqlDataAdapter("select p.id from doctor_patient dp INNER JOIN patients p on p.server_id=dp.patient_id where dp.app_user_id=" + m_id.ToString, conn)
                        da.Fill(ds, "checker")
                        If ds.Tables("checker").Rows.Count > 0 Then
                            insert_sql = String.Format("INSERT INTO `patient_consultations`(`clinic_id`, `patient_id`, `doctor_id`, `date`, `time`, `request_id`) VALUES ({0},{1},{2},'{3}','{4}',{5})",
                                                                                                 My.Settings.ClinicID.ToString, ds.Tables("checker").Rows(0).Item(0).ToString, m_doctor_id.ToString, m_date, m_time, m_id.ToString)
                            cmd = New MySqlCommand(insert_sql, conn)
                            cmd.ExecuteNonQuery()
                        End If

                    End If
                Else 'insert
                    If m_clinic_patient_id = 0 Then
                        Dim new_patient_id As Integer = get_new_patient_info(m_patient_id, m_doctor_id, m_clinic_id)
                        m_patient_id = new_patient_id
                    Else
                        m_patient_id = m_clinic_patient_id
                    End If
                    Dim cmd As New MySqlCommand
                    Dim from_patient As Integer = 1
                    If Not m_is_approved = 0 Then
                        from_patient = 1
                    End If
                    Dim insert_sql As String = String.Format("INSERT INTO `consultations_request`(`clinic_id`,`patient_id`, `doctor_id`, `date`, `time`,comment_doctor, `comment_patient`,`created_at`, `updated_at`,  `is_approved`, `server_id`,is_approved_patient) " +
                                                                                "VALUES (" + My.Settings.ClinicID.ToString + ",{0},{1},'{2}','{3}',@notes_doctor,@notes,'{4}','{5}',{6},{7},{8})",
                                                                     m_patient_id.ToString, m_doctor_id.ToString, m_date, m_time, m_created_at, m_updated_at, m_is_approved.ToString, m_id.ToString, m_is_approved_patient.ToString)

                    cmd = New MySqlCommand(insert_sql, conn)
                    cmd.Parameters.AddWithValue("notes", Testobject.appointments.Item(i).comment_patient)
                    cmd.Parameters.AddWithValue("notes_doctor", Testobject.appointments.Item(i).comment_doctor)
                    cmd.ExecuteNonQuery()
                End If
                MsgBox(Testobject.appointments.Item(i).id.ToString)
            Next
            main_menu.Counter_Notification()
            For i As Integer = 0 To Testobject.last_update.Count - 1
                My.Settings.Last_Update_Web = Testobject.last_update.Item(0).new_last_update.ToString
                My.Settings.Save()
            Next
        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function get_new_patient_info(ByRef patient_id As Integer, ByRef doctor_id As Integer, ByRef clinic_id As Integer) As Integer
        Try
            Dim cmd As New MySqlCommand
            Dim da As New MySqlDataAdapter
            Dim ds As New DataSet
            Dim request As HttpWebRequest = WebRequest.Create("http://localhost/E-Clinic/get_new_patient_info.php?patient_id=" + patient_id.ToString)
            request.Method = WebRequestMethods.Http.Get
            request.ContentType = "application/json"
            Dim response1 As HttpWebResponse = request.GetResponse

            Dim receivestream As StreamReader = New StreamReader(response1.GetResponseStream)
            Dim strjson As String = ""

            strjson = receivestream.ReadToEnd
            da = New MySqlDataAdapter("select p.id from doctor_patient mrq INNER JOIN patients p on p.server_id=mrq.patient_id where mrq.patient_id=" + patient_id.ToString, conn)
            da.Fill(ds, "checker")
            If ds.Tables("checker").Rows.Count = 0 Then
                Dim new_clinic_patient_id As Integer = mysqbridge_upload.UPLOAD_MEDICALREQUEST(patient_id, doctor_id, clinic_id)
                Dim userobject As userRoot = JsonConvert.DeserializeObject(Of userRoot)(strjson)

                For i As Integer = 0 To userobject.user_info.Count - 1

                    Dim insert_str As String = "Insert into patients " +
                                            "(fname, mname, lname, occupation, birthdate, sex, civil_status, height, weight, address_house_no, address_street, barangay_id,created_at, `email_address`, `mobile_no`, `tel_no`,is_from_app,server_id) values" +
                                            " (@fname,@mname,@lname,@occupation,@bdate,@sex,@status,@height,@weight,@houseno,@street,@barangay,CURRENT_TIMESTAMP,@email,@mobile,@tel,1," + new_clinic_patient_id.ToString + ")"

                    cmd = New MySqlCommand(insert_str, conn)
                    cmd.Parameters.AddWithValue("fname", userobject.user_info.Item(i).fname)
                    cmd.Parameters.AddWithValue("mname", userobject.user_info.Item(i).mname)
                    cmd.Parameters.AddWithValue("lname", userobject.user_info.Item(i).lname)
                    cmd.Parameters.AddWithValue("occupation", userobject.user_info.Item(i).occupation)
                    cmd.Parameters.AddWithValue("bdate", userobject.user_info.Item(i).birthdate)
                    cmd.Parameters.AddWithValue("sex", userobject.user_info.Item(i).sex)
                    cmd.Parameters.AddWithValue("status", userobject.user_info.Item(i).civil_status)
                    cmd.Parameters.AddWithValue("height", userobject.user_info.Item(i).height)
                    cmd.Parameters.AddWithValue("weight", userobject.user_info.Item(i).weight)
                    cmd.Parameters.AddWithValue("houseno", userobject.user_info.Item(i).optional_address)
                    cmd.Parameters.AddWithValue("street", userobject.user_info.Item(i).address_street)
                    cmd.Parameters.AddWithValue("barangay", userobject.user_info.Item(i).address_barangay_id)

                    cmd.Parameters.AddWithValue("email", userobject.user_info.Item(i).email_address)
                    cmd.Parameters.AddWithValue("mobile", userobject.user_info.Item(i).mobile_no)
                    cmd.Parameters.AddWithValue("tel", userobject.user_info.Item(i).tel_no)

                    cmd.ExecuteNonQuery()
                    da = New MySqlDataAdapter("select max(id) from patients", conn)
                    da.Fill(ds, "id")
                    Return ds.Tables("id").Rows(0).Item(0)
                Next
            Else
                Return ds.Tables("checker").Rows(0).Item(0)
            End If



        Catch ex As Exception

        End Try
        Return 0
    End Function
End Class
#Region "appointments getter and setter"
Public Class appointment_item
    Public Property id() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Private m_id As Integer

    Public Property patient_id() As Integer
        Get
            Return m_patient_id
        End Get
        Set(ByVal value As Integer)
            m_patient_id = value
        End Set
    End Property
    Private m_patient_id As Integer
    Public Property clinic_patient_id() As Integer
        Get
            Return m_clinic_patient_id
        End Get
        Set(ByVal value As Integer)
            m_clinic_patient_id = value
        End Set
    End Property
    Private m_clinic_patient_id As Integer
    Public Property doctor_id() As Integer
        Get
            Return m_doctor_id
        End Get
        Set(ByVal value As Integer)
            m_doctor_id = value
        End Set
    End Property
    Private m_doctor_id As Integer

    Public Property clinic_id() As Integer
        Get
            Return m_clinic_id
        End Get
        Set(ByVal value As Integer)
            m_clinic_id = value
        End Set
    End Property
    Private m_clinic_id As Integer

    Public Property appointment_date() As String
        Get
            Return m_date
        End Get
        Set(ByVal value As String)
            m_date = value
        End Set
    End Property
    Private m_date As String

    Public Property time() As String
        Get
            Return m_time
        End Get
        Set(ByVal value As String)
            m_time = value
        End Set
    End Property
    Private m_time As String

    Public Property is_approved() As Integer
        Get
            Return m_is_approved
        End Get
        Set(ByVal value As Integer)
            m_is_approved = value
        End Set
    End Property
    Private m_is_approved As Integer

    Public Property is_approved_patient() As Integer
        Get
            Return m_is_approved_patient
        End Get
        Set(ByVal value As Integer)
            m_is_approved_patient = value
        End Set
    End Property
    Private m_is_approved_patient As Integer

    Public Property comment_patient() As String
        Get
            Return m_comment_patient
        End Get
        Set(ByVal value As String)
            m_comment_patient = value
        End Set
    End Property
    Private m_comment_patient As String

    Public Property comment_doctor() As String
        Get
            Return m_comment_doctor
        End Get
        Set(ByVal value As String)
            m_comment_doctor = value
        End Set
    End Property
    Private m_comment_doctor As String

    Public Property created_at() As String
        Get
            Return m_created_at
        End Get
        Set(ByVal value As String)
            m_created_at = value
        End Set
    End Property
    Private m_created_at As String

    Public Property updated_at() As String
        Get
            Return m_updated_at
        End Get
        Set(ByVal value As String)
            m_updated_at = value
        End Set
    End Property
    Private m_updated_at As String
End Class

Public Class RootObject
    Public Property appointments() As List(Of appointment_item)
        Get
            Return m_appointments
        End Get
        Set(ByVal value As List(Of appointment_item))
            m_appointments = value
        End Set
    End Property
    Private m_appointments As List(Of appointment_item)

    Public Property last_update() As List(Of lastupdate_item)
        Get
            Return m_last_update
        End Get
        Set(ByVal value As List(Of lastupdate_item))
            m_last_update = value
        End Set
    End Property
    Private m_last_update As List(Of lastupdate_item)
End Class
Public Class lastupdate_item
    Public Property new_last_update() As String
        Get
            Return m_new_last_update
        End Get
        Set(ByVal value As String)
            m_new_last_update = value
        End Set
    End Property
    Private m_new_last_update As String
End Class
#End Region
#Region "new user info getter setter"
Public Class userRoot
    Public Property user_info() As List(Of user_item)
        Get
            Return m_user_info
        End Get
        Set(ByVal value As List(Of user_item))
            m_user_info = value
        End Set
    End Property
    Private m_user_info As List(Of user_item)
End Class
Public Class user_item
    Public Property id() As Integer
        Get
            Return m_id
        End Get
        Set(ByVal value As Integer)
            m_id = value
        End Set
    End Property
    Private m_id As Integer

    Public Property fname() As String
        Get
            Return m_fname
        End Get
        Set(ByVal value As String)
            m_fname = value
        End Set
    End Property
    Private m_fname As String
    Public Property mname() As String
        Get
            Return m_mname
        End Get
        Set(ByVal value As String)
            m_mname = value
        End Set
    End Property
    Private m_mname As String
    Public Property lname() As String
        Get
            Return m_lname
        End Get
        Set(ByVal value As String)
            m_lname = value
        End Set
    End Property
    Private m_lname As String

    Public Property email_address() As String
        Get
            Return m_email_address
        End Get
        Set(ByVal value As String)
            m_email_address = value
        End Set
    End Property
    Private m_email_address As String

    Public Property mobile_no() As String
        Get
            Return m_mobile_no
        End Get
        Set(ByVal value As String)
            m_mobile_no = value
        End Set
    End Property
    Private m_mobile_no As String

    Public Property tel_no() As String
        Get
            Return m_tel_no
        End Get
        Set(ByVal value As String)
            m_tel_no = value
        End Set
    End Property
    Private m_tel_no As String

    Public Property occupation() As String
        Get
            Return m_occupation
        End Get
        Set(ByVal value As String)
            m_occupation = value
        End Set
    End Property
    Private m_occupation As String

    Public Property birthdate() As String
        Get
            Return m_birthdate
        End Get
        Set(ByVal value As String)
            m_birthdate = value
        End Set
    End Property
    Private m_birthdate As String

    Public Property sex() As String
        Get
            Return m_sex
        End Get
        Set(ByVal value As String)
            m_sex = value
        End Set
    End Property
    Private m_sex As String

    Public Property civil_status() As String
        Get
            Return m_civil_status
        End Get
        Set(ByVal value As String)
            m_civil_status = value
        End Set
    End Property
    Private m_civil_status As String

    Public Property height() As String
        Get
            Return m_height
        End Get
        Set(ByVal value As String)
            m_height = value
        End Set
    End Property
    Private m_height As String

    Public Property weight() As String
        Get
            Return m_weight
        End Get
        Set(ByVal value As String)
            m_weight = value
        End Set
    End Property
    Private m_weight As String

    Public Property optional_address() As String
        Get
            Return m_optional_address
        End Get
        Set(ByVal value As String)
            m_optional_address = value
        End Set
    End Property
    Private m_optional_address As String

    Public Property address_street() As String
        Get
            Return m_address_street
        End Get
        Set(ByVal value As String)
            m_address_street = value
        End Set
    End Property
    Private m_address_street As String

    Public Property address_barangay_id() As Integer
        Get
            Return m_address_barangay_id
        End Get
        Set(ByVal value As Integer)
            m_address_barangay_id = value
        End Set
    End Property
    Private m_address_barangay_id As Integer
End Class
#End Region
