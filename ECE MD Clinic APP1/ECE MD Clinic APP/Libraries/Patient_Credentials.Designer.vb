<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Patient_Credentials
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Patient_Credentials))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_uname = New System.Windows.Forms.TextBox()
        Me.txt_pword = New System.Windows.Forms.TextBox()
        Me.btn_generate = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ts_save = New System.Windows.Forms.ToolStripButton()
        Me.ts_close = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Password :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "User Name:"
        '
        'txt_uname
        '
        Me.txt_uname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_uname.Location = New System.Drawing.Point(137, 72)
        Me.txt_uname.Name = "txt_uname"
        Me.txt_uname.ReadOnly = True
        Me.txt_uname.Size = New System.Drawing.Size(134, 21)
        Me.txt_uname.TabIndex = 75
        '
        'txt_pword
        '
        Me.txt_pword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_pword.Location = New System.Drawing.Point(137, 99)
        Me.txt_pword.Name = "txt_pword"
        Me.txt_pword.ReadOnly = True
        Me.txt_pword.Size = New System.Drawing.Size(134, 21)
        Me.txt_pword.TabIndex = 76
        '
        'btn_generate
        '
        Me.btn_generate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_generate.Location = New System.Drawing.Point(137, 126)
        Me.btn_generate.Name = "btn_generate"
        Me.btn_generate.Size = New System.Drawing.Size(134, 40)
        Me.btn_generate.TabIndex = 79
        Me.btn_generate.Text = "Generate New Credential"
        Me.btn_generate.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_save, Me.ts_close})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(307, 52)
        Me.ToolStrip1.TabIndex = 118
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ts_save
        '
        Me.ts_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Size = New System.Drawing.Size(38, 49)
        Me.ts_save.Text = "Save"
        Me.ts_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ts_save.Visible = False
        '
        'ts_close
        '
        Me.ts_close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ts_close.Image = CType(resources.GetObject("ts_close.Image"), System.Drawing.Image)
        Me.ts_close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_close.Name = "ts_close"
        Me.ts_close.Size = New System.Drawing.Size(42, 49)
        Me.ts_close.Text = "Close"
        Me.ts_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Patient_Credentials
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(307, 178)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btn_generate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_uname)
        Me.Controls.Add(Me.txt_pword)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Patient_Credentials"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patient Credentials"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_uname As System.Windows.Forms.TextBox
    Friend WithEvents txt_pword As System.Windows.Forms.TextBox
    Friend WithEvents btn_generate As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_close As System.Windows.Forms.ToolStripButton
End Class
