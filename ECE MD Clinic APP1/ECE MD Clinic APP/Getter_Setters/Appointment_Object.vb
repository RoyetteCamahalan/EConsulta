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
