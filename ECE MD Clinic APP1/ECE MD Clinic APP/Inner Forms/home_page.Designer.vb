<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class home_page
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(home_page))
        Me.btn_logout = New System.Windows.Forms.Button()
        Me.contact_bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.personal_bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.lbl_personal = New System.Windows.Forms.Label()
        Me.lbl_contact = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.patient_info_container = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_logout
        '
        Me.btn_logout.BackgroundImage = CType(resources.GetObject("btn_logout.BackgroundImage"), System.Drawing.Image)
        Me.btn_logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_logout.FlatAppearance.BorderSize = 0
        Me.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_logout.Location = New System.Drawing.Point(67, 12)
        Me.btn_logout.Name = "btn_logout"
        Me.btn_logout.Size = New System.Drawing.Size(148, 66)
        Me.btn_logout.TabIndex = 0
        Me.btn_logout.UseVisualStyleBackColor = True
        '
        'contact_bar
        '
        Me.contact_bar.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.contact_bar.Enabled = False
        Me.contact_bar.FillColor = System.Drawing.Color.LightGray
        Me.contact_bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.contact_bar.Location = New System.Drawing.Point(748, 114)
        Me.contact_bar.Name = "contact_bar"
        Me.contact_bar.Size = New System.Drawing.Size(377, 12)
        '
        'personal_bar
        '
        Me.personal_bar.BackColor = System.Drawing.Color.Cyan
        Me.personal_bar.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.personal_bar.Enabled = False
        Me.personal_bar.FillColor = System.Drawing.Color.Cyan
        Me.personal_bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.personal_bar.Location = New System.Drawing.Point(371, 114)
        Me.personal_bar.Name = "personal_bar"
        Me.personal_bar.Size = New System.Drawing.Size(376, 12)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.contact_bar, Me.personal_bar})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1138, 651)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'lbl_personal
        '
        Me.lbl_personal.AutoSize = True
        Me.lbl_personal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_personal.Font = New System.Drawing.Font("News701 BT", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_personal.ForeColor = System.Drawing.Color.Blue
        Me.lbl_personal.Location = New System.Drawing.Point(426, 80)
        Me.lbl_personal.Name = "lbl_personal"
        Me.lbl_personal.Size = New System.Drawing.Size(272, 32)
        Me.lbl_personal.TabIndex = 21
        Me.lbl_personal.Text = "PERSONAL INFO"
        '
        'lbl_contact
        '
        Me.lbl_contact.AutoSize = True
        Me.lbl_contact.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_contact.Font = New System.Drawing.Font("News701 BT", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_contact.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_contact.Location = New System.Drawing.Point(807, 81)
        Me.lbl_contact.Name = "lbl_contact"
        Me.lbl_contact.Size = New System.Drawing.Size(254, 32)
        Me.lbl_contact.TabIndex = 20
        Me.lbl_contact.Text = "CONTACT INFO"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(102, 79)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(226, 225)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 22
        Me.PictureBox1.TabStop = False
        '
        'patient_info_container
        '
        Me.patient_info_container.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.patient_info_container.Location = New System.Drawing.Point(371, 126)
        Me.patient_info_container.Name = "patient_info_container"
        Me.patient_info_container.Size = New System.Drawing.Size(755, 485)
        Me.patient_info_container.TabIndex = 23
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(849, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(123, 66)
        Me.Button2.TabIndex = 24
        Me.Button2.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Today's Birthday"
        Me.NotifyIcon1.Visible = True
        '
        'home_page
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1138, 651)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.patient_info_container)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lbl_personal)
        Me.Controls.Add(Me.lbl_contact)
        Me.Controls.Add(Me.btn_logout)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "home_page"
        Me.Text = "home_page"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_logout As System.Windows.Forms.Button
    Friend WithEvents contact_bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents personal_bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents lbl_personal As System.Windows.Forms.Label
    Friend WithEvents lbl_contact As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents patient_info_container As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
End Class
