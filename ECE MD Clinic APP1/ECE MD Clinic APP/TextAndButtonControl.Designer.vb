<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextAndButtonControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_decline = New System.Windows.Forms.Button()
        Me.btn_accept = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_decline
        '
        Me.btn_decline.BackColor = System.Drawing.Color.Red
        Me.btn_decline.Location = New System.Drawing.Point(81, 0)
        Me.btn_decline.Name = "btn_decline"
        Me.btn_decline.Size = New System.Drawing.Size(100, 23)
        Me.btn_decline.TabIndex = 1
        Me.btn_decline.Text = "Decline"
        Me.btn_decline.UseVisualStyleBackColor = False
        '
        'btn_accept
        '
        Me.btn_accept.BackColor = System.Drawing.Color.LimeGreen
        Me.btn_accept.Location = New System.Drawing.Point(0, 0)
        Me.btn_accept.Name = "btn_accept"
        Me.btn_accept.Size = New System.Drawing.Size(82, 23)
        Me.btn_accept.TabIndex = 2
        Me.btn_accept.Text = "Accept"
        Me.btn_accept.UseVisualStyleBackColor = False
        '
        'TextAndButtonControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.btn_accept)
        Me.Controls.Add(Me.btn_decline)
        Me.Name = "TextAndButtonControl"
        Me.Size = New System.Drawing.Size(181, 24)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_decline As System.Windows.Forms.Button
    Friend WithEvents btn_accept As System.Windows.Forms.Button

End Class
