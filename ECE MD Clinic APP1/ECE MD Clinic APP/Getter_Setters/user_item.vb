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