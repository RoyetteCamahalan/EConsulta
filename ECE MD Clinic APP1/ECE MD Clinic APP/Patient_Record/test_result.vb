Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Text.StringBuilder
Imports System.IO
Public Class test_result
    Private da As New MySqlDataAdapter
    Private cmd As New MySqlCommand
    Private ds As New DataSet
    Public patient_id As Integer = 1
    Private tempfolder As String
    Private Sub test_result_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        
        imagedialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
        tempfolder = "C:\ECE MD Clinic APP\TEST_RESULTS_CACHED\" + randomstring("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz")
        If Not (Directory.Exists(tempfolder) Or File.Exists(tempfolder)) Then
            Directory.CreateDirectory(tempfolder)
        End If
        get_imagelocationindb()
    End Sub
    Private Sub get_imagelocationindb()
        Try
            ds.Clear()
            Dim str As String
            If UserType = 0 Then 'secretary
                str = "SELECT t.`id`, t.`patient_id`, t.`doctor_id`, t.`photo`, `name`, t.`created_at`, t.`updated_at` FROM `test_results` t inner join secretary_access sc on sc.doctor_id=t.doctor_id WHERE sc.secretary_id=" + UserId.ToString + " and t.patient_id=" + patient_id.ToString
            Else
                str = "SELECT t.`id`, t.`patient_id`, t.`doctor_id`, t.`photo`, t.`name`, t.`created_at`, t.`updated_at` FROM `test_results` t  where t.doctor_id=" + UserId.ToString + " and t.patient_id=" + patient_id.ToString
            End If
            da = New MySqlDataAdapter(str, conn)
            da.Fill(ds)
            ImageList1.Images.Clear()
            ListView1.Items.Clear()
            If File.Exists(tempfolder) Then
                My.Computer.FileSystem.DeleteDirectory(tempfolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                load_images(ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(3).ToString, ds.Tables(0).Rows(i).Item(4).ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Private Sub load_images(ByRef id As String, ByRef location As String, ByRef name As String)
        Try
            Dim img2 As Image = Image.FromFile("C:\ECE MD Clinic APP\TEST_RESULTS\" + location)
            Dim item2 As New ListViewItem

            ImageList1.Images.Add(id, img2)
            item2.ImageKey = id
            item2.Text = name
            item2.Tag = tempfolder + "\" + location
            My.Computer.FileSystem.CopyFile("C:\ECE MD Clinic APP\TEST_RESULTS\" + location, tempfolder + "\" + location)
            ListView1.Items.Add(item2)
            'Dim img As Image = Image.FromFile("C:\ECE MD Clinic APP\TEST_RESULTS\" + location)
            'Dim img As Image = Image.FromFile("D:\Files\my files\Pictures\download.jpg")
            'Dim item As New ListViewItem

            'ImageList1.Images.Add("IMAGE1", img)
            'item.ImageKey = id
            'item.Text = name
            'ListView1.Items.Add(item)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListView1_ItemActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.ItemActivate
        Try
            ''MsgBox(ListView1.SelectedItems.Item(0).ImageKey.ToString)
            If Not File.Exists(ListView1.SelectedItems.Item(0).Tag.ToString) Then
                My.Computer.FileSystem.CopyFile("C:\ECE MD Clinic APP\TEST_RESULTS\" + System.IO.Path.GetFileName(ListView1.SelectedItems.Item(0).Tag.ToString), ListView1.SelectedItems.Item(0).Tag.ToString)
            End If
            Process.Start("C:\windows\system32\rundll32.exe", "C:\WINDOWS\System32\shimgvw.dll,ImageView_Fullscreen " & ListView1.SelectedItems.Item(0).Tag.ToString)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btn_add_photo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add_photo.Click
        Try
            If UserType = 0 Then
                Dim tstres As test_result = Me
                select_doctor_test.testresult = tstres
                select_doctor_test.ShowDialog()
            Else
                If imagedialog.ShowDialog = DialogResult.OK Then
                    Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(imagedialog.FileName)
                    Dim extention As String = System.IO.Path.GetExtension(imagedialog.FileName)
                    Dim filepath As String = imagedialog.FileName
                    Dim newfilename As String = randomstring(filename) + extention
                    While File.Exists("C:\ECE MD Clinic APP\TEST_RESULTS\" + newfilename)
                        newfilename = randomstring(filename) + extention
                    End While
                    'cmd = New MySqlCommand("INSERT INTO `test_results`(`patient_id`, `photo`,name) VALUES (" + patient_id.ToString + ",'" + MySqlHelper.EscapeString(newfilename) + "','" + MySqlHelper.EscapeString(filename) + "')", conn)
                    cmd = New MySqlCommand("INSERT INTO `test_results`(`patient_id`,`doctor_id`, `photo`,name) VALUES (" + patient_id.ToString + "," + UserId.ToString + ",@param1,@param2)", conn)
                    cmd.Parameters.AddWithValue("param1", newfilename)
                    cmd.Parameters.AddWithValue("param2", filename)
                    cmd.ExecuteNonQuery()
                    My.Computer.FileSystem.CopyFile(filepath, "C:\ECE MD Clinic APP\TEST_RESULTS\" + newfilename)
                    get_imagelocationindb()
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Public Sub addfromsecretary(ByRef doc_id As Integer)
        If imagedialog.ShowDialog = DialogResult.OK Then
            Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(imagedialog.FileName)
            Dim extention As String = System.IO.Path.GetExtension(imagedialog.FileName)
            Dim filepath As String = imagedialog.FileName
            Dim newfilename As String = randomstring(filename) + extention
            While File.Exists("C:\ECE MD Clinic APP\TEST_RESULTS\" + newfilename)
                newfilename = randomstring(filename) + extention
            End While
            'cmd = New MySqlCommand("INSERT INTO `test_results`(`patient_id`, `photo`,name) VALUES (" + patient_id.ToString + ",'" + MySqlHelper.EscapeString(newfilename) + "','" + MySqlHelper.EscapeString(filename) + "')", conn)
            cmd = New MySqlCommand("INSERT INTO `test_results`(`patient_id`,`doctor_id`, `photo`,name) VALUES (" + patient_id.ToString + "," + doc_id.ToString + ",@param1,@param2)", conn)
            cmd.Parameters.AddWithValue("param1", newfilename)
            cmd.Parameters.AddWithValue("param2", filename)
            cmd.ExecuteNonQuery()
            My.Computer.FileSystem.CopyFile(filepath, "C:\ECE MD Clinic APP\TEST_RESULTS\" + newfilename)
            get_imagelocationindb()
        End If
    End Sub
    Private Function randomstring(ByRef s As String) As String
        Dim r As New Random
        Dim sb As New System.Text.StringBuilder
        Dim cnt As Integer = r.Next(15, 33)
        For i As Integer = 1 To cnt
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function

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

    Private Sub test_result_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Directory.Exists(tempfolder) Then
            My.Computer.FileSystem.DeleteDirectory(tempfolder, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End If
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
                cmd = New MySqlCommand("UPDATE `test_results` SET `name`=@param1 where id=" + ListView1.Items(e.Item).ImageKey.ToString, conn)
                cmd.Parameters.AddWithValue("param1", e.Label.ToString)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class