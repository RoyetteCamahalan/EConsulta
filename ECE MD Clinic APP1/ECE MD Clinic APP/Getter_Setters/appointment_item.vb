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