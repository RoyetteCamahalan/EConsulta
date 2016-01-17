<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class View_Secretary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(View_Secretary))
        Me.profile_pic = New System.Windows.Forms.PictureBox()
        Me.txt_fname = New System.Windows.Forms.TextBox()
        Me.txt_mname = New System.Windows.Forms.TextBox()
        Me.txt_lname = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_uname = New System.Windows.Forms.TextBox()
        Me.txt_pword = New System.Windows.Forms.TextBox()
        Me.lbl_invalid_email = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_telno = New System.Windows.Forms.TextBox()
        Me.txt_mobileno = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_houseno = New System.Windows.Forms.TextBox()
        Me.chk_isactive = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ts_save = New System.Windows.Forms.ToolStripButton()
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton()
        Me.ts_edit = New System.Windows.Forms.ToolStripButton()
        Me.ts_close = New System.Windows.Forms.ToolStripButton()
        Me.txt_street = New System.Windows.Forms.TextBox()
        Me.cmb_barangay = New System.Windows.Forms.ComboBox()
        Me.cmb_municipality = New System.Windows.Forms.ComboBox()
        Me.cmb_province = New System.Windows.Forms.ComboBox()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        CType(Me.profile_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'profile_pic
        '
        Me.profile_pic.BackgroundImage = CType(resources.GetObject("profile_pic.BackgroundImage"), System.Drawing.Image)
        Me.profile_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.profile_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.profile_pic.Location = New System.Drawing.Point(33, 55)
        Me.profile_pic.Name = "profile_pic"
        Me.profile_pic.Size = New System.Drawing.Size(200, 174)
        Me.profile_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.profile_pic.TabIndex = 9
        Me.profile_pic.TabStop = False
        '
        'txt_fname
        '
        Me.txt_fname.Location = New System.Drawing.Point(341, 55)
        Me.txt_fname.Name = "txt_fname"
        Me.txt_fname.ReadOnly = True
        Me.txt_fname.Size = New System.Drawing.Size(209, 20)
        Me.txt_fname.TabIndex = 36
        '
        'txt_mname
        '
        Me.txt_mname.Location = New System.Drawing.Point(341, 81)
        Me.txt_mname.Name = "txt_mname"
        Me.txt_mname.ReadOnly = True
        Me.txt_mname.Size = New System.Drawing.Size(209, 20)
        Me.txt_mname.TabIndex = 37
        '
        'txt_lname
        '
        Me.txt_lname.Location = New System.Drawing.Point(341, 107)
        Me.txt_lname.Name = "txt_lname"
        Me.txt_lname.ReadOnly = True
        Me.txt_lname.Size = New System.Drawing.Size(209, 20)
        Me.txt_lname.TabIndex = 38
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(260, 110)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "Last Name :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(260, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 42
        Me.Label12.Text = "Middle Name :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(260, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "First Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 270)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Password :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 238)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "User Name:"
        '
        'txt_uname
        '
        Me.txt_uname.Location = New System.Drawing.Point(81, 235)
        Me.txt_uname.Name = "txt_uname"
        Me.txt_uname.ReadOnly = True
        Me.txt_uname.Size = New System.Drawing.Size(152, 20)
        Me.txt_uname.TabIndex = 71
        '
        'txt_pword
        '
        Me.txt_pword.Location = New System.Drawing.Point(81, 267)
        Me.txt_pword.Name = "txt_pword"
        Me.txt_pword.ReadOnly = True
        Me.txt_pword.Size = New System.Drawing.Size(152, 20)
        Me.txt_pword.TabIndex = 72
        Me.txt_pword.UseSystemPasswordChar = True
        '
        'lbl_invalid_email
        '
        Me.lbl_invalid_email.AutoSize = True
        Me.lbl_invalid_email.ForeColor = System.Drawing.Color.Red
        Me.lbl_invalid_email.Location = New System.Drawing.Point(78, 379)
        Me.lbl_invalid_email.Name = "lbl_invalid_email"
        Me.lbl_invalid_email.Size = New System.Drawing.Size(66, 13)
        Me.lbl_invalid_email.TabIndex = 98
        Me.lbl_invalid_email.Text = "Invalid Email"
        Me.lbl_invalid_email.Visible = False
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(81, 356)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.ReadOnly = True
        Me.txt_email.Size = New System.Drawing.Size(152, 20)
        Me.txt_email.TabIndex = 94
        '
        'txt_telno
        '
        Me.txt_telno.Location = New System.Drawing.Point(81, 327)
        Me.txt_telno.Name = "txt_telno"
        Me.txt_telno.ReadOnly = True
        Me.txt_telno.Size = New System.Drawing.Size(152, 20)
        Me.txt_telno.TabIndex = 93
        '
        'txt_mobileno
        '
        Me.txt_mobileno.Location = New System.Drawing.Point(81, 298)
        Me.txt_mobileno.Name = "txt_mobileno"
        Me.txt_mobileno.ReadOnly = True
        Me.txt_mobileno.Size = New System.Drawing.Size(152, 20)
        Me.txt_mobileno.TabIndex = 92
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 298)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 95
        Me.Label10.Text = "Mobile No. :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1, 330)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 13)
        Me.Label14.TabIndex = 96
        Me.Label14.Text = "Tel. No. :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(1, 359)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(79, 13)
        Me.Label17.TabIndex = 97
        Me.Label17.Text = "Email Address :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(258, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Street :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(260, 300)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "City/ Municipality :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(260, 270)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "Province  :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(260, 242)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Region :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(260, 327)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 108
        Me.Label8.Text = "Barangay :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(258, 178)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 13)
        Me.Label19.TabIndex = 106
        Me.Label19.Text = "House No. :"
        '
        'txt_houseno
        '
        Me.txt_houseno.Location = New System.Drawing.Point(353, 175)
        Me.txt_houseno.Name = "txt_houseno"
        Me.txt_houseno.ReadOnly = True
        Me.txt_houseno.Size = New System.Drawing.Size(212, 20)
        Me.txt_houseno.TabIndex = 99
        '
        'chk_isactive
        '
        Me.chk_isactive.AutoSize = True
        Me.chk_isactive.Enabled = False
        Me.chk_isactive.ForeColor = System.Drawing.Color.Red
        Me.chk_isactive.Location = New System.Drawing.Point(261, 142)
        Me.chk_isactive.Name = "chk_isactive"
        Me.chk_isactive.Size = New System.Drawing.Size(140, 17)
        Me.chk_isactive.TabIndex = 116
        Me.chk_isactive.Text = "Allow access to my Files"
        Me.chk_isactive.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_save, Me.ts_cancel, Me.ts_edit, Me.ts_close})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(577, 52)
        Me.ToolStrip1.TabIndex = 117
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ts_save
        '
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Size = New System.Drawing.Size(35, 49)
        Me.ts_save.Text = "Save"
        Me.ts_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ts_save.Visible = False
        '
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Size = New System.Drawing.Size(47, 49)
        Me.ts_cancel.Text = "Cancel"
        Me.ts_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ts_cancel.Visible = False
        '
        'ts_edit
        '
        Me.ts_edit.Image = CType(resources.GetObject("ts_edit.Image"), System.Drawing.Image)
        Me.ts_edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_edit.Name = "ts_edit"
        Me.ts_edit.Size = New System.Drawing.Size(37, 49)
        Me.ts_edit.Text = " Edit "
        Me.ts_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_close
        '
        Me.ts_close.Image = CType(resources.GetObject("ts_close.Image"), System.Drawing.Image)
        Me.ts_close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_close.Name = "ts_close"
        Me.ts_close.Size = New System.Drawing.Size(40, 49)
        Me.ts_close.Text = "Close"
        Me.ts_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'txt_street
        '
        Me.txt_street.Location = New System.Drawing.Point(353, 207)
        Me.txt_street.Name = "txt_street"
        Me.txt_street.ReadOnly = True
        Me.txt_street.Size = New System.Drawing.Size(212, 20)
        Me.txt_street.TabIndex = 100
        '
        'cmb_barangay
        '
        Me.cmb_barangay.Enabled = False
        Me.cmb_barangay.FormattingEnabled = True
        Me.cmb_barangay.Location = New System.Drawing.Point(353, 324)
        Me.cmb_barangay.Name = "cmb_barangay"
        Me.cmb_barangay.Size = New System.Drawing.Size(212, 21)
        Me.cmb_barangay.TabIndex = 125
        Me.cmb_barangay.Text = "Select Barangay"
        '
        'cmb_municipality
        '
        Me.cmb_municipality.Enabled = False
        Me.cmb_municipality.FormattingEnabled = True
        Me.cmb_municipality.Location = New System.Drawing.Point(353, 297)
        Me.cmb_municipality.Name = "cmb_municipality"
        Me.cmb_municipality.Size = New System.Drawing.Size(212, 21)
        Me.cmb_municipality.TabIndex = 124
        Me.cmb_municipality.Text = "Select Municipality"
        '
        'cmb_province
        '
        Me.cmb_province.Enabled = False
        Me.cmb_province.FormattingEnabled = True
        Me.cmb_province.Location = New System.Drawing.Point(353, 267)
        Me.cmb_province.Name = "cmb_province"
        Me.cmb_province.Size = New System.Drawing.Size(212, 21)
        Me.cmb_province.TabIndex = 123
        Me.cmb_province.Text = "Select Province"
        '
        'cmb_region
        '
        Me.cmb_region.Enabled = False
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(353, 239)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(212, 21)
        Me.cmb_region.TabIndex = 122
        Me.cmb_region.Text = "Select Region"
        '
        'View_Secretary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 401)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmb_barangay)
        Me.Controls.Add(Me.cmb_municipality)
        Me.Controls.Add(Me.cmb_province)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.chk_isactive)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_houseno)
        Me.Controls.Add(Me.txt_street)
        Me.Controls.Add(Me.lbl_invalid_email)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.txt_telno)
        Me.Controls.Add(Me.txt_mobileno)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_uname)
        Me.Controls.Add(Me.txt_pword)
        Me.Controls.Add(Me.txt_fname)
        Me.Controls.Add(Me.txt_mname)
        Me.Controls.Add(Me.txt_lname)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.profile_pic)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "View_Secretary"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Secretary"
        CType(Me.profile_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents profile_pic As System.Windows.Forms.PictureBox
    Friend WithEvents txt_fname As System.Windows.Forms.TextBox
    Friend WithEvents txt_mname As System.Windows.Forms.TextBox
    Friend WithEvents txt_lname As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_uname As System.Windows.Forms.TextBox
    Friend WithEvents txt_pword As System.Windows.Forms.TextBox
    Friend WithEvents lbl_invalid_email As System.Windows.Forms.Label
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_telno As System.Windows.Forms.TextBox
    Friend WithEvents txt_mobileno As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_houseno As System.Windows.Forms.TextBox
    Friend WithEvents chk_isactive As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_close As System.Windows.Forms.ToolStripButton
    Friend WithEvents txt_street As System.Windows.Forms.TextBox
    Friend WithEvents cmb_barangay As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_municipality As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_province As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
End Class
