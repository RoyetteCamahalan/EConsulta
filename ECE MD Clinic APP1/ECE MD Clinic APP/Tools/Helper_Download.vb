Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class Helper_Download


    Public Shared Sub get_appointments()
        Try
            'Form_Main.TextBox1.Text = DownLoad_URL + "action_type=0&&last_update=" + My.Settings.Last_Update_Web.ToString + "&&clinic_id=" + My.Settings.ClinicID.ToString
            Dim request As HttpWebRequest = WebRequest.Create(DownLoad_URL + "action_type=0&&last_update=" + My.Settings.Last_Update_Web.ToString + "&&clinic_id=" + My.Settings.ClinicID.ToString)
            request.Method = WebRequestMethods.Http.Get
            request.ContentType = "application/json"
            Dim response1 As HttpWebResponse = request.GetResponse

            Dim receivestream As StreamReader = New StreamReader(response1.GetResponseStream)
            Dim strjson As String = ""

            strjson = receivestream.ReadToEnd
            Form_Main.TextBox1.Text = strjson
            Dim AppointmentObject As Appointment_Object = JsonConvert.DeserializeObject(Of Appointment_Object)(strjson)
            For i As Integer = 0 To AppointmentObject.appointments.Count - 1
                Dim m_id As Integer = AppointmentObject.appointments.Item(i).id
                Dim m_patient_id As Integer = AppointmentObject.appointments.Item(i).patient_id
                Dim m_clinic_patient_id As Integer = AppointmentObject.appointments.Item(i).clinic_patient_id
                Dim m_doctor_id As Integer = AppointmentObject.appointments.Item(i).doctor_id
                Dim m_clinic_id As Integer = AppointmentObject.appointments.Item(i).clinic_id
                Dim m_date As String = AppointmentObject.appointments.Item(i).appointment_date.ToString
                Dim m_time As String = AppointmentObject.appointments.Item(i).time.ToString
                Dim m_is_approved_doctor As Integer = AppointmentObject.appointments.Item(i).is_approved_doctor
                Dim m_is_approved_patient As Integer = AppointmentObject.appointments.Item(i).is_approved_patient
                Dim m_comment_doctor As String = AppointmentObject.appointments.Item(i).comment_doctor
                Dim m_comment_patient As String = AppointmentObject.appointments.Item(i).comment_patient
                Dim m_is_done As String = AppointmentObject.appointments.Item(i).is_done
                Dim m_patient_record_id As String = AppointmentObject.appointments.Item(i).patient_record_id
                Dim m_created_at As String = AppointmentObject.appointments.Item(i).created_at.ToString
                Dim Param_Name As String() = {"@action_type", "@sub_action", "@server_id"}
                Dim Param_Value As String() = {2, 11, m_id}
                Dim MyAdapter As New Custom_Adapters
                Dim CheckerID As Integer = MyAdapter.CUSTOM_TRANSACT_WITH_RETURN("SP_Consultation", Param_Name, Param_Value)
                If CheckerID > 0 Then 'update
                    Param_Name = {"@action_type", "@sub_action", "@id", "@patient_id", "@doctor_id",
                                 "@consult_date", "@consult_time", "@comment_doctor", "@comment_patient",
                                  "@is_approved_doctor", "@is_approved_patient", "@patient_record_id", "@is_done",
                                  "@created_at", "@server_id"}
                    Param_Value = {1, 5, CheckerID, Get_Auto_IncrementID(m_clinic_patient_id, "Patient"), m_doctor_id,
                                   m_date, m_time, m_comment_doctor, m_comment_patient,
                                   m_is_approved_doctor, m_is_approved_patient, m_patient_record_id, m_is_done,
                                   m_created_at, m_id}

                    MyAdapter.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value)
                Else 'insert
                    Dim MyAdapter_Patient_Consultation As New Custom_Adapters
                    If m_clinic_patient_id = 0 Then
                        Param_Name = {"@action_type", "@sub_action", "@doctor_id", "@app_user_id", "@clinic_id"}
                        Param_Value = {2, 1, m_doctor_id, m_patient_id, m_clinic_id}
                        Dim MyAdapter_Doctor_Patient As New Custom_Adapters
                        Dim CheckID As Integer = 0
                        CheckID = MyAdapter_Doctor_Patient.CUSTOM_TRANSACT_WITH_RETURN("SP_DoctorPatient", Param_Name, Param_Value)
                        If CheckID = 0 Then
                            Dim new_patient_id As Integer = get_new_patient_info(m_patient_id, m_doctor_id, m_clinic_id)
                            m_patient_id = new_patient_id
                        Else
                            m_patient_id = CheckerID
                        End If


                    Else
                        m_patient_id = Get_Auto_IncrementID(m_clinic_patient_id, "Patient")
                    End If
                    Param_Name = {"@action_type", "@doctor_id", "@patient_id", "@clinic_id",
                                  "@consult_date", "@consult_time",
                                  "@comment_doctor", "@comment_patient",
                                  "@is_approved_doctor", "@is_approved_patient", "@patient_record_id", "@is_done",
                                  "@created_at", "@server_id"}
                    Param_Value = {0, m_doctor_id, m_patient_id, m_clinic_id,
                                      m_date, m_time,
                                      AppointmentObject.appointments.Item(i).comment_doctor,
                                      AppointmentObject.appointments.Item(i).comment_patient,
                                      m_is_approved_doctor, m_is_approved_patient, m_patient_record_id, m_is_done,
                                      m_created_at, m_id}
                    MyAdapter_Patient_Consultation.CUSTOM_TRANSACT("SP_Consultation", Param_Name, Param_Value)
                End If
            Next
            DisplayNotificationCount()
        Catch ex As Exception

        End Try
    End Sub
    Public Shared Function get_new_patient_info(ByRef patient_id As Integer, ByRef doctor_id As Integer, ByRef clinic_id As Integer) As Integer
        Try
            Dim request As HttpWebRequest = WebRequest.Create(DownLoad_URL + "action_type=2&&patient_id=" + patient_id.ToString)
            request.Method = WebRequestMethods.Http.Get
            request.ContentType = "application/json"
            Dim response1 As HttpWebResponse = request.GetResponse

            Dim receivestream As StreamReader = New StreamReader(response1.GetResponseStream)
            Dim strjson As String = ""

            strjson = receivestream.ReadToEnd
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@app_user_id"}
            Dim Param_Value As String() = {2, 2, patient_id}
            Dim MyAdapter As New Custom_Adapters
            Dim DT As New DataTable
            DT = MyAdapter.CUSTOM_RETRIEVE("SP_DoctorPatient", Param_Name, Param_Value)
            If DT.Rows.Count = 0 Then
                'insert patient to online db and getting it's server_id
                Dim Return_Data As String() = Helper_Upload.UPLOAD_MEDICALREQUEST(patient_id, doctor_id, clinic_id)
                If Return_Data.Length > 0 Then
                    Dim new_clinic_patient_server_id As Integer = CType(Return_Data(0), Integer)
                    Dim new_doctor_patient_server_id As Integer = CType(Return_Data(1), Integer)
                    Dim new_uname As String = Return_Data(2)
                    Dim new_pword As String = Return_Data(3)
                    Form_Main.TextBox1.Text = strjson
                    Dim userobject As userRoot = JsonConvert.DeserializeObject(Of userRoot)(strjson)
                    For i As Integer = 0 To userobject.user_info.Count - 1
                        Param_Name = {"@action_type",
                                              "@fname", "@mname", "@lname",
                                              "@email", "@mobile", "@tel",
                                              "@occupation",
                                              "@birthdate", "@sex", "@civil_status",
                                              "@height", "@weight",
                                              "@houseno", "@street", "@barangay_id", "@server_id",
                                              "@created_at", "@is_from_app"}
                        With userobject.user_info.Item(i)
                            Param_Value = {0,
                                            .fname, .mname, .lname,
                                            .email_address, .mobile_no, .tel_no,
                                            .occupation,
                                            .birthdate, .sex, .civil_status,
                                            .height, .weight,
                                           .optional_address, .address_street, .address_barangay_id, new_clinic_patient_server_id,
                                           .created_at, 1}
                        End With
                        Dim Auto_IncrementedID As Integer = MyAdapter.CUSTOM_TRANSACT_WITH_RETURN("SP_Patient", Param_Name, Param_Value)
                        If Auto_IncrementedID > 0 Then

                            Dim MyAdapter_Doctor_Patient As New Custom_Adapters
                            Param_Name = {"@action_type", "@doctor_id", "@patient_id", "@clinic_id", "@app_user_id", "@username", "@password", "@server_id"}
                            Param_Value = {0, doctor_id, Auto_IncrementedID, clinic_id, patient_id, new_uname, new_pword, new_doctor_patient_server_id}
                            MyAdapter_Doctor_Patient.CUSTOM_TRANSACT("SP_DoctorPatient", Param_Name, Param_Value)
                            Return Auto_IncrementedID
                        End If

                    Next
                End If


            Else
                Return DT.Rows(0).Item(0)
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

    Public Property is_approved_doctor() As Integer
        Get
            Return m_is_approved_doctor
        End Get
        Set(ByVal value As Integer)
            m_is_approved_doctor = value
        End Set
    End Property
    Private m_is_approved_doctor As Integer

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

    Public Property patient_record_id() As String
        Get
            Return m_patient_record_id
        End Get
        Set(ByVal value As String)
            m_patient_record_id = value
        End Set
    End Property
    Private m_patient_record_id As String

    Public Property is_done() As Integer
        Get
            Return m_is_done
        End Get
        Set(ByVal value As Integer)
            m_is_done = value
        End Set
    End Property
    Private m_is_done As Integer

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

Public Class Appointment_Object
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
    Public Property created_at() As Date
        Get
            Return m_created_at
        End Get
        Set(ByVal value As Date)
            m_created_at = value
        End Set
    End Property
    Private m_created_at As Date
End Class
#End Region
