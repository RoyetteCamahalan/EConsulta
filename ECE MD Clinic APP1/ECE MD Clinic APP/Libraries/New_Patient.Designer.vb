<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class New_Patient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(New_Patient))
        Me.btn_next_geninfo = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btn_remove = New System.Windows.Forms.Button()
        Me.btn_browse = New System.Windows.Forms.Button()
        Me.profile_pic = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_reffered_by = New System.Windows.Forms.TextBox()
        Me.cmv_status = New System.Windows.Forms.ComboBox()
        Me.txt_weight = New System.Windows.Forms.TextBox()
        Me.txt_height = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbtn_female = New System.Windows.Forms.RadioButton()
        Me.rbtn_male = New System.Windows.Forms.RadioButton()
        Me.birthdate_picker = New System.Windows.Forms.DateTimePicker()
        Me.txt_occupation = New System.Windows.Forms.TextBox()
        Me.txt_lname = New System.Windows.Forms.TextBox()
        Me.txt_mname = New System.Windows.Forms.TextBox()
        Me.txt_fname = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmb_barangay = New System.Windows.Forms.ComboBox()
        Me.cmb_municipality = New System.Windows.Forms.ComboBox()
        Me.cmb_province = New System.Windows.Forms.ComboBox()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.lbl_invalid_email = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_telno = New System.Windows.Forms.TextBox()
        Me.txt_mobileno = New System.Windows.Forms.TextBox()
        Me.txt_street = New System.Windows.Forms.TextBox()
        Me.txt_houseno = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_next_contact_info = New System.Windows.Forms.Button()
        Me.imagedialog = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.profile_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_next_geninfo
        '
        Me.btn_next_geninfo.Enabled = False
        Me.btn_next_geninfo.Location = New System.Drawing.Point(242, 329)
        Me.btn_next_geninfo.Name = "btn_next_geninfo"
        Me.btn_next_geninfo.Size = New System.Drawing.Size(76, 26)
        Me.btn_next_geninfo.TabIndex = 1
        Me.btn_next_geninfo.Text = "Next"
        Me.btn_next_geninfo.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(324, 329)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 26)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(414, 387)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btn_remove)
        Me.TabPage1.Controls.Add(Me.btn_browse)
        Me.TabPage1.Controls.Add(Me.profile_pic)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_reffered_by)
        Me.TabPage1.Controls.Add(Me.cmv_status)
        Me.TabPage1.Controls.Add(Me.txt_weight)
        Me.TabPage1.Controls.Add(Me.txt_height)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.birthdate_picker)
        Me.TabPage1.Controls.Add(Me.txt_occupation)
        Me.TabPage1.Controls.Add(Me.txt_lname)
        Me.TabPage1.Controls.Add(Me.txt_mname)
        Me.TabPage1.Controls.Add(Me.txt_fname)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.btn_next_geninfo)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(406, 361)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General Patient Info"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btn_remove
        '
        Me.btn_remove.Location = New System.Drawing.Point(236, 94)
        Me.btn_remove.Name = "btn_remove"
        Me.btn_remove.Size = New System.Drawing.Size(60, 27)
        Me.btn_remove.TabIndex = 34
        Me.btn_remove.Text = "Remove"
        Me.btn_remove.UseVisualStyleBackColor = True
        Me.btn_remove.Visible = False
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(301, 94)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(60, 27)
        Me.btn_browse.TabIndex = 33
        Me.btn_browse.Text = "Browse..."
        Me.btn_browse.UseVisualStyleBackColor = True
        Me.btn_browse.Visible = False
        '
        'profile_pic
        '
        Me.profile_pic.Image = CType(resources.GetObject("profile_pic.Image"), System.Drawing.Image)
        Me.profile_pic.Location = New System.Drawing.Point(232, 6)
        Me.profile_pic.Name = "profile_pic"
        Me.profile_pic.Size = New System.Drawing.Size(133, 88)
        Me.profile_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.profile_pic.TabIndex = 32
        Me.profile_pic.TabStop = False
        Me.profile_pic.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(170, 276)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Reffered By:"
        '
        'txt_reffered_by
        '
        Me.txt_reffered_by.Location = New System.Drawing.Point(172, 292)
        Me.txt_reffered_by.Multiline = True
        Me.txt_reffered_by.Name = "txt_reffered_by"
        Me.txt_reffered_by.Size = New System.Drawing.Size(155, 31)
        Me.txt_reffered_by.TabIndex = 30
        '
        'cmv_status
        '
        Me.cmv_status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmv_status.FormattingEnabled = True
        Me.cmv_status.Items.AddRange(New Object() {"Single", "Married", "Widow"})
        Me.cmv_status.Location = New System.Drawing.Point(75, 248)
        Me.cmv_status.Name = "cmv_status"
        Me.cmv_status.Size = New System.Drawing.Size(253, 21)
        Me.cmv_status.TabIndex = 27
        Me.cmv_status.Text = "Civil Status"
        '
        'txt_weight
        '
        Me.txt_weight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_weight.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_weight.Location = New System.Drawing.Point(75, 304)
        Me.txt_weight.Name = "txt_weight"
        Me.txt_weight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_weight.Size = New System.Drawing.Size(89, 20)
        Me.txt_weight.TabIndex = 29
        Me.txt_weight.Text = "Weight"
        '
        'txt_height
        '
        Me.txt_height.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_height.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_height.Location = New System.Drawing.Point(75, 278)
        Me.txt_height.Name = "txt_height"
        Me.txt_height.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_height.Size = New System.Drawing.Size(89, 20)
        Me.txt_height.TabIndex = 28
        Me.txt_height.Text = "Height"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdbtn_female)
        Me.GroupBox1.Controls.Add(Me.rbtn_male)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(73, 189)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(255, 53)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sex"
        '
        'rdbtn_female
        '
        Me.rdbtn_female.AutoSize = True
        Me.rdbtn_female.Location = New System.Drawing.Point(117, 20)
        Me.rdbtn_female.Name = "rdbtn_female"
        Me.rdbtn_female.Size = New System.Drawing.Size(73, 17)
        Me.rdbtn_female.TabIndex = 1
        Me.rdbtn_female.TabStop = True
        Me.rdbtn_female.Text = "FEMALE"
        Me.rdbtn_female.UseVisualStyleBackColor = True
        '
        'rbtn_male
        '
        Me.rbtn_male.AutoSize = True
        Me.rbtn_male.Location = New System.Drawing.Point(33, 20)
        Me.rbtn_male.Name = "rbtn_male"
        Me.rbtn_male.Size = New System.Drawing.Size(58, 17)
        Me.rbtn_male.TabIndex = 0
        Me.rbtn_male.TabStop = True
        Me.rbtn_male.Text = "MALE"
        Me.rbtn_male.UseVisualStyleBackColor = True
        '
        'birthdate_picker
        '
        Me.birthdate_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.birthdate_picker.Location = New System.Drawing.Point(73, 162)
        Me.birthdate_picker.Name = "birthdate_picker"
        Me.birthdate_picker.Size = New System.Drawing.Size(255, 20)
        Me.birthdate_picker.TabIndex = 25
        '
        'txt_occupation
        '
        Me.txt_occupation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_occupation.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_occupation.Location = New System.Drawing.Point(74, 125)
        Me.txt_occupation.Name = "txt_occupation"
        Me.txt_occupation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_occupation.Size = New System.Drawing.Size(253, 20)
        Me.txt_occupation.TabIndex = 24
        Me.txt_occupation.Text = "Occupation"
        '
        'txt_lname
        '
        Me.txt_lname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_lname.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_lname.Location = New System.Drawing.Point(74, 74)
        Me.txt_lname.Name = "txt_lname"
        Me.txt_lname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_lname.Size = New System.Drawing.Size(253, 20)
        Me.txt_lname.TabIndex = 23
        Me.txt_lname.Text = "Last Name"
        '
        'txt_mname
        '
        Me.txt_mname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_mname.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_mname.Location = New System.Drawing.Point(74, 48)
        Me.txt_mname.Name = "txt_mname"
        Me.txt_mname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_mname.Size = New System.Drawing.Size(253, 20)
        Me.txt_mname.TabIndex = 22
        Me.txt_mname.Text = "Middle Name"
        '
        'txt_fname
        '
        Me.txt_fname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_fname.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_fname.Location = New System.Drawing.Point(74, 19)
        Me.txt_fname.Name = "txt_fname"
        Me.txt_fname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_fname.Size = New System.Drawing.Size(253, 20)
        Me.txt_fname.TabIndex = 21
        Me.txt_fname.Text = "First Name"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(72, 146)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Birthdate :"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cmb_barangay)
        Me.TabPage2.Controls.Add(Me.cmb_municipality)
        Me.TabPage2.Controls.Add(Me.cmb_province)
        Me.TabPage2.Controls.Add(Me.cmb_region)
        Me.TabPage2.Controls.Add(Me.lbl_invalid_email)
        Me.TabPage2.Controls.Add(Me.txt_email)
        Me.TabPage2.Controls.Add(Me.txt_telno)
        Me.TabPage2.Controls.Add(Me.txt_mobileno)
        Me.TabPage2.Controls.Add(Me.txt_street)
        Me.TabPage2.Controls.Add(Me.txt_houseno)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.btn_next_contact_info)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(406, 361)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Contact Info"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmb_barangay
        '
        Me.cmb_barangay.FormattingEnabled = True
        Me.cmb_barangay.Location = New System.Drawing.Point(83, 191)
        Me.cmb_barangay.Name = "cmb_barangay"
        Me.cmb_barangay.Size = New System.Drawing.Size(238, 21)
        Me.cmb_barangay.TabIndex = 137
        Me.cmb_barangay.Text = "Select Barangay"
        '
        'cmb_municipality
        '
        Me.cmb_municipality.FormattingEnabled = True
        Me.cmb_municipality.Location = New System.Drawing.Point(83, 158)
        Me.cmb_municipality.Name = "cmb_municipality"
        Me.cmb_municipality.Size = New System.Drawing.Size(238, 21)
        Me.cmb_municipality.TabIndex = 136
        Me.cmb_municipality.Text = "Select Municipality"
        '
        'cmb_province
        '
        Me.cmb_province.FormattingEnabled = True
        Me.cmb_province.Location = New System.Drawing.Point(83, 124)
        Me.cmb_province.Name = "cmb_province"
        Me.cmb_province.Size = New System.Drawing.Size(238, 21)
        Me.cmb_province.TabIndex = 135
        Me.cmb_province.Text = "Select Province"
        '
        'cmb_region
        '
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(83, 92)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(238, 21)
        Me.cmb_region.TabIndex = 134
        Me.cmb_region.Text = "Select Region"
        '
        'lbl_invalid_email
        '
        Me.lbl_invalid_email.AutoSize = True
        Me.lbl_invalid_email.ForeColor = System.Drawing.Color.Red
        Me.lbl_invalid_email.Location = New System.Drawing.Point(80, 308)
        Me.lbl_invalid_email.Name = "lbl_invalid_email"
        Me.lbl_invalid_email.Size = New System.Drawing.Size(66, 13)
        Me.lbl_invalid_email.TabIndex = 18
        Me.lbl_invalid_email.Text = "Invalid Email"
        Me.lbl_invalid_email.Visible = False
        '
        'txt_email
        '
        Me.txt_email.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_email.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_email.Location = New System.Drawing.Point(83, 285)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_email.Size = New System.Drawing.Size(238, 20)
        Me.txt_email.TabIndex = 14
        Me.txt_email.Text = "E-mail Address"
        '
        'txt_telno
        '
        Me.txt_telno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_telno.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_telno.Location = New System.Drawing.Point(83, 254)
        Me.txt_telno.Name = "txt_telno"
        Me.txt_telno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_telno.Size = New System.Drawing.Size(238, 20)
        Me.txt_telno.TabIndex = 13
        Me.txt_telno.Text = "Telephone No."
        '
        'txt_mobileno
        '
        Me.txt_mobileno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_mobileno.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_mobileno.Location = New System.Drawing.Point(83, 223)
        Me.txt_mobileno.Name = "txt_mobileno"
        Me.txt_mobileno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_mobileno.Size = New System.Drawing.Size(238, 20)
        Me.txt_mobileno.TabIndex = 12
        Me.txt_mobileno.Text = "Mobile No."
        '
        'txt_street
        '
        Me.txt_street.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_street.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_street.Location = New System.Drawing.Point(83, 61)
        Me.txt_street.Name = "txt_street"
        Me.txt_street.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_street.Size = New System.Drawing.Size(238, 20)
        Me.txt_street.TabIndex = 6
        Me.txt_street.Text = "Street"
        '
        'txt_houseno
        '
        Me.txt_houseno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_houseno.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_houseno.Location = New System.Drawing.Point(83, 31)
        Me.txt_houseno.Name = "txt_houseno"
        Me.txt_houseno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_houseno.Size = New System.Drawing.Size(238, 20)
        Me.txt_houseno.TabIndex = 5
        Me.txt_houseno.Text = "House No."
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(160, 329)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(76, 26)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "Previous"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(324, 329)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 26)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btn_next_contact_info
        '
        Me.btn_next_contact_info.Enabled = False
        Me.btn_next_contact_info.Location = New System.Drawing.Point(242, 329)
        Me.btn_next_contact_info.Name = "btn_next_contact_info"
        Me.btn_next_contact_info.Size = New System.Drawing.Size(76, 26)
        Me.btn_next_contact_info.TabIndex = 16
        Me.btn_next_contact_info.Text = "Finish"
        Me.btn_next_contact_info.UseVisualStyleBackColor = True
        '
        'imagedialog
        '
        Me.imagedialog.FileName = "OpenFileDialog1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(232, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(133, 88)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'New_Patient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(417, 386)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "New_Patient"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Patient Entry"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.profile_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_next_geninfo As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_next_contact_info As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_weight As System.Windows.Forms.TextBox
    Friend WithEvents txt_height As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbtn_female As System.Windows.Forms.RadioButton
    Friend WithEvents rbtn_male As System.Windows.Forms.RadioButton
    Friend WithEvents birthdate_picker As System.Windows.Forms.DateTimePicker
    Friend WithEvents txt_occupation As System.Windows.Forms.TextBox
    Friend WithEvents txt_lname As System.Windows.Forms.TextBox
    Friend WithEvents txt_mname As System.Windows.Forms.TextBox
    Friend WithEvents txt_fname As System.Windows.Forms.TextBox
    Friend WithEvents txt_street As System.Windows.Forms.TextBox
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_telno As System.Windows.Forms.TextBox
    Friend WithEvents txt_mobileno As System.Windows.Forms.TextBox
    Friend WithEvents cmv_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_reffered_by As System.Windows.Forms.TextBox
    Friend WithEvents imagedialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btn_remove As System.Windows.Forms.Button
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents profile_pic As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txt_houseno As System.Windows.Forms.TextBox
    Friend WithEvents lbl_invalid_email As System.Windows.Forms.Label
    Friend WithEvents cmb_barangay As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_municipality As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_province As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
End Class
