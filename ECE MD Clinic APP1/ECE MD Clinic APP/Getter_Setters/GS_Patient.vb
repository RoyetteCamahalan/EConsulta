Public Class GS_Patient
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