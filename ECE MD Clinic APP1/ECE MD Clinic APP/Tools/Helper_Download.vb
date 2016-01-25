Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Public Class Helper_Download


    Public Shared Sub get_appointments()
        Try
            Form_Main.TextBox1.Text = DownLoad_URL + "action_type=0&&last_update=" + My.Settings.Last_Update_Web.ToString + "&&clinic_id=" + My.Settings.ClinicID.ToString
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
                    Dim userobject As GS_Patient = JsonConvert.DeserializeObject(Of GS_Patient)(strjson)
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

