Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.StringBuilder
Imports System.IO
Public Class test_result
    Private da As New SqlDataAdapter
    Private cmd As New SqlCommand
    Private DT As New DataTable
    Public patient_id As Integer = 0
    Private Current_Direct As String = ""
#Region "Methods"
    Private Sub DisplayTestResults()
        Try
            Dim Param_Name As String() = {"@action_type", "@sub_action", "@patient_id", "@secretary_id", "@doctor_id"}
            Dim Param_Value As String()
            Dim MyAdapter As New Custom_Adapters
            If UserType = 0 Then 'secretary
                Param_Value = {2, 1, patient_id, UserId, ""}
            Else 'doctor
                Param_Value = {2, 2, patient_id, "", UserId}
            End If
            DT = MyAdapter.CUSTOM_RETRIEVE("SP_TestResults", Param_Name, Param_Value)
            ImageList1.Images.Clear()
            ListView1.Items.Clear()
            Try
                For i As Integer = 0 To DT.Rows.Count - 1
                    Dim buffer As Byte() = DT.Rows(i).Item(3)
                    Dim Img As New MemoryStream
                    Dim RealImage As System.Drawing.Image
                    Img = New MemoryStream(buffer)
                    RealImage = System.Drawing.Image.FromStream(Img)
                    ImageList1.Images.Add(DT.Rows(i).Item(0).ToString, RealImage)
                    Dim LViewItem As New ListViewItem
                    LViewItem.ImageKey = DT.Rows(i).Item(0).ToString
                    LViewItem.Text = DT.Rows(i).Item(4).ToString
                    ListView1.Items.Add(LViewItem)
                Next
            Catch ex As Exception

            End Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Public Sub InsertTestResult(ByRef doctor_id As Integer)
        If imagedialog.ShowDialog = DialogResult.OK Then
            Try
                Dim com As New SqlCommand
                com.CommandText = "SP_TestResults"
                com.CommandType = CommandType.StoredProcedure
                com.Connection = conn

                Dim buffer As Byte() = File.ReadAllBytes(imagedialog.FileName)
                Dim filename As String = System.IO.Path.GetFileName(imagedialog.FileName)

                com.Parameters.AddWithValue("@action_type", 0)
                com.Parameters.AddWithValue("@patient_id", patient_id)
                com.Parameters.AddWithValue("@doctor_id", doctor_id)
                com.Parameters.AddWithValue("@photo", buffer)
                com.Parameters.AddWithValue("@name", filename)
                com.ExecuteNonQuery()
                DisplayTestResults()
            Catch ex As Exception

            End Try
        End If
    End Sub
#End Region
    Private Sub test_result_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Current_Direct = Test_Result_Cached & "\" & patient_id.ToString
        If My.Computer.FileSystem.DirectoryExists(Current_Direct) Then
            My.Computer.FileSystem.DeleteDirectory(Current_Direct, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End If
        My.Computer.FileSystem.CreateDirectory(Current_Direct)
        imagedialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        DisplayTestResults()
    End Sub
    

    Private Sub ListView1_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.ItemActivate
        Try
            Dim idx As Integer = ListView1.SelectedItems(0).Index

            Dim FirstImage As String = Current_Direct & "\Image-ID-" & DT.Rows(idx).Item(0).ToString & ".jpg"

            For i As Integer = 0 To DT.Rows.Count - 1
                Dim buffer As Byte() = DT.Rows(i).Item(3)
                Dim Img As New MemoryStream
                Img = New MemoryStream(buffer)
                Image.FromStream(Img).Save(Current_Direct & "\Image-ID-" & DT.Rows(i).Item(0).ToString & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
            Next
            System.Diagnostics.Process.Start(FirstImage)
        Catch ex As Exception
            MsgBox("Preview Failed")
        End Try
    End Sub

    Private Sub btn_add_photo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_photo.Click
        Try
            If UserType = 0 Then
                Dim tstres As test_result = Me
                select_doctor_test.testresult = tstres
                select_doctor_test.ShowDialog()
            Else
                InsertTestResult(UserId)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ListView1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView1.MouseUp
        Try
            If e.Button = MouseButtons.Right Then
                Dim hit As ListViewHitTestInfo = ListView1.HitTest(e.X, e.Y)
                If hit.Item IsNot Nothing Then
                    context_options.Show(Cursor.Position)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub rename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rename.Click
        ListView1.SelectedItems.Item(0).BeginEdit()
    End Sub

    Private Sub ListView1_AfterLabelEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles ListView1.AfterLabelEdit
        Try
            If e.Label.ToString = "" Then
                MsgBox("Invalid File Name", MsgBoxStyle.OkOnly, "Warning")
                e.CancelEdit = True
            Else
                Dim Param_Name As String() = {"@action_type", "@sub_action", "@id", "@name"}
                Dim Param_Value As String() = {1, 1, ListView1.Items(e.Item).ImageKey.ToString, e.Label.ToString}
                Dim MyAdapter As New Custom_Adapters
                If Not MyAdapter.CUSTOM_TRANSACT("SP_TestResults", Param_Name, Param_Value) Then
                    MsgBox("Renaming Failed")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub test_result_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If My.Computer.FileSystem.DirectoryExists(Current_Direct) Then
                My.Computer.FileSystem.DeleteDirectory(Current_Direct, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class