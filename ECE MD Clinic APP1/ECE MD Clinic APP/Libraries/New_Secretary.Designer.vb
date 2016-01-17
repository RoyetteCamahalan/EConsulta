<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class New_Secretary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(New_Secretary))
        Me.profile_pic = New System.Windows.Forms.PictureBox()
        Me.txt_lname = New System.Windows.Forms.TextBox()
        Me.txt_mname = New System.Windows.Forms.TextBox()
        Me.txt_fname = New System.Windows.Forms.TextBox()
        Me.btn_remove = New System.Windows.Forms.Button()
        Me.btn_browse = New System.Windows.Forms.Button()
        Me.lbl_invalid_email = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_telno = New System.Windows.Forms.TextBox()
        Me.txt_mobileno = New System.Windows.Forms.TextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.txt_confirmpword = New System.Windows.Forms.TextBox()
        Me.txt_pword = New System.Windows.Forms.TextBox()
        Me.txt_uname = New System.Windows.Forms.TextBox()
        Me.txt_street = New System.Windows.Forms.TextBox()
        Me.txt_houseno = New System.Windows.Forms.TextBox()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.cmb_province = New System.Windows.Forms.ComboBox()
        Me.cmb_municipality = New System.Windows.Forms.ComboBox()
        Me.cmb_barangay = New System.Windows.Forms.ComboBox()
        Me.chk_isactive = New System.Windows.Forms.CheckBox()
        CType(Me.profile_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'profile_pic
        '
        Me.profile_pic.BackgroundImage = CType(resources.GetObject("profile_pic.BackgroundImage"), System.Drawing.Image)
        Me.profile_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.profile_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.profile_pic.Location = New System.Drawing.Point(241, 12)
        Me.profile_pic.Name = "profile_pic"
        Me.profile_pic.Size = New System.Drawing.Size(137, 123)
        Me.profile_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.profile_pic.TabIndex = 10
        Me.profile_pic.TabStop = False
        '
        'txt_lname
        '
        Me.txt_lname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_lname.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_lname.Location = New System.Drawing.Point(26, 88)
        Me.txt_lname.Name = "txt_lname"
        Me.txt_lname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_lname.Size = New System.Drawing.Size(212, 20)
        Me.txt_lname.TabIndex = 27
        Me.txt_lname.Text = "Last Name"
        '
        'txt_mname
        '
        Me.txt_mname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_mname.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_mname.Location = New System.Drawing.Point(26, 62)
        Me.txt_mname.Name = "txt_mname"
        Me.txt_mname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_mname.Size = New System.Drawing.Size(212, 20)
        Me.txt_mname.TabIndex = 26
        Me.txt_mname.Text = "Middle Name"
        '
        'txt_fname
        '
        Me.txt_fname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_fname.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_fname.Location = New System.Drawing.Point(26, 33)
        Me.txt_fname.Name = "txt_fname"
        Me.txt_fname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_fname.Size = New System.Drawing.Size(212, 20)
        Me.txt_fname.TabIndex = 25
        Me.txt_fname.Text = "First Name"
        '
        'btn_remove
        '
        Me.btn_remove.Location = New System.Drawing.Point(244, 141)
        Me.btn_remove.Name = "btn_remove"
        Me.btn_remove.Size = New System.Drawing.Size(60, 27)
        Me.btn_remove.TabIndex = 36
        Me.btn_remove.Text = "Remove"
        Me.btn_remove.UseVisualStyleBackColor = True
        '
        'btn_browse
        '
        Me.btn_browse.Location = New System.Drawing.Point(314, 141)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(59, 27)
        Me.btn_browse.TabIndex = 35
        Me.btn_browse.Text = "Browse..."
        Me.btn_browse.UseVisualStyleBackColor = True
        '
        'lbl_invalid_email
        '
        Me.lbl_invalid_email.AutoSize = True
        Me.lbl_invalid_email.ForeColor = System.Drawing.Color.Red
        Me.lbl_invalid_email.Location = New System.Drawing.Point(307, 331)
        Me.lbl_invalid_email.Name = "lbl_invalid_email"
        Me.lbl_invalid_email.Size = New System.Drawing.Size(66, 13)
        Me.lbl_invalid_email.TabIndex = 47
        Me.lbl_invalid_email.Text = "Invalid Email"
        Me.lbl_invalid_email.Visible = False
        '
        'txt_email
        '
        Me.txt_email.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_email.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_email.Location = New System.Drawing.Point(26, 328)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_email.Size = New System.Drawing.Size(275, 20)
        Me.txt_email.TabIndex = 46
        Me.txt_email.Text = "E-mail Address"
        '
        'txt_telno
        '
        Me.txt_telno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_telno.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_telno.Location = New System.Drawing.Point(26, 302)
        Me.txt_telno.Name = "txt_telno"
        Me.txt_telno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_telno.Size = New System.Drawing.Size(347, 20)
        Me.txt_telno.TabIndex = 45
        Me.txt_telno.Text = "Telephone No."
        '
        'txt_mobileno
        '
        Me.txt_mobileno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_mobileno.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_mobileno.Location = New System.Drawing.Point(26, 276)
        Me.txt_mobileno.Name = "txt_mobileno"
        Me.txt_mobileno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_mobileno.Size = New System.Drawing.Size(347, 20)
        Me.txt_mobileno.TabIndex = 44
        Me.txt_mobileno.Text = "Mobile No."
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(297, 428)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(76, 26)
        Me.Button7.TabIndex = 49
        Me.Button7.Text = "Cancel"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btn_save.ForeColor = System.Drawing.Color.Gray
        Me.btn_save.Location = New System.Drawing.Point(215, 428)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(76, 26)
        Me.btn_save.TabIndex = 48
        Me.btn_save.Text = "Finish"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'txt_confirmpword
        '
        Me.txt_confirmpword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_confirmpword.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_confirmpword.Location = New System.Drawing.Point(26, 406)
        Me.txt_confirmpword.Name = "txt_confirmpword"
        Me.txt_confirmpword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_confirmpword.Size = New System.Drawing.Size(347, 20)
        Me.txt_confirmpword.TabIndex = 52
        Me.txt_confirmpword.Text = "Confirm Password"
        '
        'txt_pword
        '
        Me.txt_pword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_pword.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_pword.Location = New System.Drawing.Point(26, 380)
        Me.txt_pword.Name = "txt_pword"
        Me.txt_pword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_pword.Size = New System.Drawing.Size(347, 20)
        Me.txt_pword.TabIndex = 51
        Me.txt_pword.Text = "Password"
        '
        'txt_uname
        '
        Me.txt_uname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_uname.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_uname.Location = New System.Drawing.Point(26, 354)
        Me.txt_uname.Name = "txt_uname"
        Me.txt_uname.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_uname.Size = New System.Drawing.Size(347, 20)
        Me.txt_uname.TabIndex = 50
        Me.txt_uname.Text = "User Name"
        '
        'txt_street
        '
        Me.txt_street.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_street.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_street.Location = New System.Drawing.Point(26, 251)
        Me.txt_street.Name = "txt_street"
        Me.txt_street.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_street.Size = New System.Drawing.Size(347, 20)
        Me.txt_street.TabIndex = 38
        Me.txt_street.Text = "Street"
        '
        'txt_houseno
        '
        Me.txt_houseno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_houseno.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_houseno.Location = New System.Drawing.Point(26, 225)
        Me.txt_houseno.Name = "txt_houseno"
        Me.txt_houseno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_houseno.Size = New System.Drawing.Size(347, 20)
        Me.txt_houseno.TabIndex = 37
        Me.txt_houseno.Text = "House No."
        '
        'cmb_region
        '
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(26, 114)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(212, 21)
        Me.cmb_region.TabIndex = 53
        Me.cmb_region.Text = "Select Region"
        '
        'cmb_province
        '
        Me.cmb_province.FormattingEnabled = True
        Me.cmb_province.Location = New System.Drawing.Point(26, 141)
        Me.cmb_province.Name = "cmb_province"
        Me.cmb_province.Size = New System.Drawing.Size(212, 21)
        Me.cmb_province.TabIndex = 54
        Me.cmb_province.Text = "Select Province"
        '
        'cmb_municipality
        '
        Me.cmb_municipality.FormattingEnabled = True
        Me.cmb_municipality.Location = New System.Drawing.Point(26, 170)
        Me.cmb_municipality.Name = "cmb_municipality"
        Me.cmb_municipality.Size = New System.Drawing.Size(347, 21)
        Me.cmb_municipality.TabIndex = 55
        Me.cmb_municipality.Text = "Select Municipality"
        '
        'cmb_barangay
        '
        Me.cmb_barangay.FormattingEnabled = True
        Me.cmb_barangay.Location = New System.Drawing.Point(26, 197)
        Me.cmb_barangay.Name = "cmb_barangay"
        Me.cmb_barangay.Size = New System.Drawing.Size(347, 21)
        Me.cmb_barangay.TabIndex = 56
        Me.cmb_barangay.Text = "Select Barangay"
        '
        'chk_isactive
        '
        Me.chk_isactive.AutoSize = True
        Me.chk_isactive.ForeColor = System.Drawing.Color.Red
        Me.chk_isactive.Location = New System.Drawing.Point(26, 12)
        Me.chk_isactive.Name = "chk_isactive"
        Me.chk_isactive.Size = New System.Drawing.Size(140, 17)
        Me.chk_isactive.TabIndex = 117
        Me.chk_isactive.Text = "Allow access to my Files"
        Me.chk_isactive.UseVisualStyleBackColor = True
        '
        'New_Secretary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 458)
        Me.Controls.Add(Me.chk_isactive)
        Me.Controls.Add(Me.cmb_barangay)
        Me.Controls.Add(Me.cmb_municipality)
        Me.Controls.Add(Me.cmb_province)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.txt_confirmpword)
        Me.Controls.Add(Me.txt_pword)
        Me.Controls.Add(Me.txt_uname)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.lbl_invalid_email)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.txt_telno)
        Me.Controls.Add(Me.txt_mobileno)
        Me.Controls.Add(Me.txt_street)
        Me.Controls.Add(Me.txt_houseno)
        Me.Controls.Add(Me.btn_remove)
        Me.Controls.Add(Me.btn_browse)
        Me.Controls.Add(Me.txt_lname)
        Me.Controls.Add(Me.txt_mname)
        Me.Controls.Add(Me.txt_fname)
        Me.Controls.Add(Me.profile_pic)
        Me.Name = "New_Secretary"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Secretary"
        CType(Me.profile_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents profile_pic As System.Windows.Forms.PictureBox
    Friend WithEvents txt_lname As System.Windows.Forms.TextBox
    Friend WithEvents txt_mname As System.Windows.Forms.TextBox
    Friend WithEvents txt_fname As System.Windows.Forms.TextBox
    Friend WithEvents btn_remove As System.Windows.Forms.Button
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents lbl_invalid_email As System.Windows.Forms.Label
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_telno As System.Windows.Forms.TextBox
    Friend WithEvents txt_mobileno As System.Windows.Forms.TextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents txt_confirmpword As System.Windows.Forms.TextBox
    Friend WithEvents txt_pword As System.Windows.Forms.TextBox
    Friend WithEvents txt_uname As System.Windows.Forms.TextBox
    Friend WithEvents txt_street As System.Windows.Forms.TextBox
    Friend WithEvents txt_houseno As System.Windows.Forms.TextBox
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_province As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_municipality As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_barangay As System.Windows.Forms.ComboBox
    Friend WithEvents chk_isactive As System.Windows.Forms.CheckBox
End Class
