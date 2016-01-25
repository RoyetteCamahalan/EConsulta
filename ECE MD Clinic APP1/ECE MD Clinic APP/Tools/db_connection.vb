Imports System.Data
Imports System.Data.SqlClient
Module db_connection
    Public conn As New SqlConnection
    Public UserName, PassWord As String
    Public UserId As Integer
    Public UserType As Integer
    Public url_downloaddate As String
#Region "Constants"
    Public Default_Row_Height As Integer = 30
    Public Search_Hint_Patient As String = "Search Patient Here"
    Public Search_Hint_Secretary As String = "Search Secretary Here"
    Public Search_Hint_Appointment As String = "Search Appointment Here"
    Public Search_Hint As String = "Search Here"
    Public Search_Hint_Medicine As String = "Search Medicine Here"
    Public NotificationCount As Integer = 0
    Public write_message_to_patient As String = "Write Comment/Message to Patient"

    Public Test_Result_Cached As String = "C:\EConsulta\TEST_RESULTS_CACHED"

    Public DownLoad_URL As String = "http://bsit701.com/E-Konsulta/EConsulta/Data_Download.php/?"
    Public UpLoad_URL As String = "http://bsit701.com/E-Konsulta/EConsulta/Data_Upload.php"
#End Region
    Public Function connect() As Boolean

        Dim dbname As String = "ece_pharmacy_tree"
        Dim dbhost As String = "SOFTWORKSPC-PM\sqlexpress"
        Dim user As String = "royette"
        Dim pass As String = "royette"
        Try
            conn.ConnectionString = String.Format("Server={0};Database={3};UID={1}; PASSWORD={2};Connect Timeout = 10000000;pooling=true", dbhost, user, pass, dbname)
            conn.Open()
            Return True
        Catch ex As Exception
            MsgBox("Cannot connect to specified server.")
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
End Module
