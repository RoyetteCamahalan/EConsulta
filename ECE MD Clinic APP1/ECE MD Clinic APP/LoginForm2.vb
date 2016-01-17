Public Class LoginForm2

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p As New Drawing2D.GraphicsPath
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        p.AddLine(40, 0, OK.Width - 40, 0)
        p.AddArc(New Rectangle(OK.Width - 40, 0, 40, 40), -90, 90)
        p.AddLine(OK.Width, 40, OK.Width, OK.Height - 40)
        p.AddArc(New Rectangle(OK.Width - 40, OK.Height - 40, 40, 40), 0, 90)
        p.AddLine(OK.Width - 40, OK.Height, 40, OK.Height)
        p.AddArc(New Rectangle(0, OK.Height - 40, 40, 40), 90, 90)
        p.CloseFigure()
        OK.Region = New Region(p)
    End Sub
End Class
