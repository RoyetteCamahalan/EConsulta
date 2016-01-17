<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class test_result
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(test_result))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btn_add_photo = New System.Windows.Forms.Button()
        Me.imagedialog = New System.Windows.Forms.OpenFileDialog()
        Me.context_options = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.rename = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.context_options.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(422, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Submitted Test Results"
        '
        'ListView1
        '
        Me.ListView1.Activation = System.Windows.Forms.ItemActivation.TwoClick
        Me.ListView1.AutoArrange = False
        Me.ListView1.BackColor = System.Drawing.SystemColors.Control
        Me.ListView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListView1.GridLines = True
        Me.ListView1.LabelEdit = True
        Me.ListView1.LargeImageList = Me.ImageList1
        Me.ListView1.Location = New System.Drawing.Point(42, 69)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1044, 304)
        Me.ListView1.TabIndex = 2
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(100, 100)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'btn_add_photo
        '
        Me.btn_add_photo.BackgroundImage = CType(resources.GetObject("btn_add_photo.BackgroundImage"), System.Drawing.Image)
        Me.btn_add_photo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_add_photo.FlatAppearance.BorderSize = 0
        Me.btn_add_photo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_add_photo.Location = New System.Drawing.Point(1014, 12)
        Me.btn_add_photo.Name = "btn_add_photo"
        Me.btn_add_photo.Size = New System.Drawing.Size(63, 64)
        Me.btn_add_photo.TabIndex = 4
        Me.btn_add_photo.UseVisualStyleBackColor = True
        '
        'imagedialog
        '
        Me.imagedialog.FileName = "OpenFileDialog1"
        Me.imagedialog.Title = "Select Image"
        '
        'context_options
        '
        Me.context_options.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.rename})
        Me.context_options.Name = "context_options"
        Me.context_options.Size = New System.Drawing.Size(118, 26)
        '
        'rename
        '
        Me.rename.Name = "rename"
        Me.rename.Size = New System.Drawing.Size(117, 22)
        Me.rename.Text = "Rename"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 500)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(696, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Note: Test Results such as X-Rays and Ultrasounds are not recommended here to pre" & _
            "vent wrong interpretation"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 517)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(198, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "due to some case of distortion."
        '
        'test_result
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1098, 385)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_add_photo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "test_result"
        Me.Text = "test_result"
        Me.context_options.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btn_add_photo As System.Windows.Forms.Button
    Friend WithEvents imagedialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents context_options As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents rename As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
