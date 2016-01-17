<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class user_profile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(user_profile))
        Me.cmv_status = New System.Windows.Forms.ComboBox()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.btn_gcancel = New System.Windows.Forms.Button()
        Me.btn_gedit = New System.Windows.Forms.Button()
        Me.txt_fname = New System.Windows.Forms.TextBox()
        Me.txt_mname = New System.Windows.Forms.TextBox()
        Me.txt_lname = New System.Windows.Forms.TextBox()
        Me.birthdate_picker = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.idcontainer = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_uname = New System.Windows.Forms.TextBox()
        Me.txt_pword = New System.Windows.Forms.TextBox()
        Me.lbl_invalid_email = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_telno = New System.Windows.Forms.TextBox()
        Me.txt_mobileno = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_houseno = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txt_street = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txt_specialty = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_sub_specialty = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txt_prc = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnbedit = New System.Windows.Forms.Button()
        Me.btnbcancel = New System.Windows.Forms.Button()
        Me.btnbsave = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmb_barangay = New System.Windows.Forms.ComboBox()
        Me.cmb_municipality = New System.Windows.Forms.ComboBox()
        Me.cmb_province = New System.Windows.Forms.ComboBox()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnconedit = New System.Windows.Forms.Button()
        Me.btnconcancel = New System.Windows.Forms.Button()
        Me.btnconsave = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmv_status
        '
        Me.cmv_status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        resources.ApplyResources(Me.cmv_status, "cmv_status")
        Me.cmv_status.FormattingEnabled = True
        Me.cmv_status.Items.AddRange(New Object() {resources.GetString("cmv_status.Items"), resources.GetString("cmv_status.Items1"), resources.GetString("cmv_status.Items2")})
        Me.cmv_status.Name = "cmv_status"
        '
        'btn_save
        '
        Me.btn_save.AutoEllipsis = True
        resources.ApplyResources(Me.btn_save, "btn_save")
        Me.btn_save.ForeColor = System.Drawing.Color.Black
        Me.btn_save.Name = "btn_save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'btn_gcancel
        '
        resources.ApplyResources(Me.btn_gcancel, "btn_gcancel")
        Me.btn_gcancel.Name = "btn_gcancel"
        Me.btn_gcancel.UseVisualStyleBackColor = True
        '
        'btn_gedit
        '
        Me.btn_gedit.AutoEllipsis = True
        resources.ApplyResources(Me.btn_gedit, "btn_gedit")
        Me.btn_gedit.Name = "btn_gedit"
        Me.btn_gedit.UseVisualStyleBackColor = True
        '
        'txt_fname
        '
        resources.ApplyResources(Me.txt_fname, "txt_fname")
        Me.txt_fname.Name = "txt_fname"
        Me.txt_fname.ReadOnly = True
        '
        'txt_mname
        '
        resources.ApplyResources(Me.txt_mname, "txt_mname")
        Me.txt_mname.Name = "txt_mname"
        Me.txt_mname.ReadOnly = True
        '
        'txt_lname
        '
        resources.ApplyResources(Me.txt_lname, "txt_lname")
        Me.txt_lname.Name = "txt_lname"
        Me.txt_lname.ReadOnly = True
        '
        'birthdate_picker
        '
        resources.ApplyResources(Me.birthdate_picker, "birthdate_picker")
        Me.birthdate_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.birthdate_picker.Name = "birthdate_picker"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'idcontainer
        '
        resources.ApplyResources(Me.idcontainer, "idcontainer")
        Me.idcontainer.Name = "idcontainer"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txt_uname
        '
        resources.ApplyResources(Me.txt_uname, "txt_uname")
        Me.txt_uname.Name = "txt_uname"
        Me.txt_uname.ReadOnly = True
        '
        'txt_pword
        '
        resources.ApplyResources(Me.txt_pword, "txt_pword")
        Me.txt_pword.Name = "txt_pword"
        Me.txt_pword.ReadOnly = True
        Me.txt_pword.UseSystemPasswordChar = True
        '
        'lbl_invalid_email
        '
        resources.ApplyResources(Me.lbl_invalid_email, "lbl_invalid_email")
        Me.lbl_invalid_email.ForeColor = System.Drawing.Color.Red
        Me.lbl_invalid_email.Name = "lbl_invalid_email"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'txt_email
        '
        resources.ApplyResources(Me.txt_email, "txt_email")
        Me.txt_email.Name = "txt_email"
        Me.txt_email.ReadOnly = True
        '
        'txt_telno
        '
        resources.ApplyResources(Me.txt_telno, "txt_telno")
        Me.txt_telno.Name = "txt_telno"
        Me.txt_telno.ReadOnly = True
        '
        'txt_mobileno
        '
        resources.ApplyResources(Me.txt_mobileno, "txt_mobileno")
        Me.txt_mobileno.Name = "txt_mobileno"
        Me.txt_mobileno.ReadOnly = True
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'txt_houseno
        '
        resources.ApplyResources(Me.txt_houseno, "txt_houseno")
        Me.txt_houseno.Name = "txt_houseno"
        Me.txt_houseno.ReadOnly = True
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'txt_street
        '
        resources.ApplyResources(Me.txt_street, "txt_street")
        Me.txt_street.Name = "txt_street"
        Me.txt_street.ReadOnly = True
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'txt_specialty
        '
        resources.ApplyResources(Me.txt_specialty, "txt_specialty")
        Me.txt_specialty.Name = "txt_specialty"
        Me.txt_specialty.ReadOnly = True
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'txt_sub_specialty
        '
        resources.ApplyResources(Me.txt_sub_specialty, "txt_sub_specialty")
        Me.txt_sub_specialty.Name = "txt_sub_specialty"
        Me.txt_sub_specialty.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.txt_prc)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txt_sub_specialty)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txt_specialty)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'txt_prc
        '
        resources.ApplyResources(Me.txt_prc, "txt_prc")
        Me.txt_prc.Name = "txt_prc"
        Me.txt_prc.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnbedit)
        Me.Panel2.Controls.Add(Me.btnbcancel)
        Me.Panel2.Controls.Add(Me.btnbsave)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.txt_lname)
        Me.Panel2.Controls.Add(Me.cmv_status)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.txt_fname)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.txt_mname)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.birthdate_picker)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'btnbedit
        '
        Me.btnbedit.AutoEllipsis = True
        resources.ApplyResources(Me.btnbedit, "btnbedit")
        Me.btnbedit.Name = "btnbedit"
        Me.btnbedit.UseVisualStyleBackColor = True
        '
        'btnbcancel
        '
        resources.ApplyResources(Me.btnbcancel, "btnbcancel")
        Me.btnbcancel.Name = "btnbcancel"
        Me.btnbcancel.UseVisualStyleBackColor = True
        '
        'btnbsave
        '
        Me.btnbsave.AutoEllipsis = True
        resources.ApplyResources(Me.btnbsave, "btnbsave")
        Me.btnbsave.ForeColor = System.Drawing.Color.Black
        Me.btnbsave.Name = "btnbsave"
        Me.btnbsave.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel3)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cmb_barangay)
        Me.Panel3.Controls.Add(Me.cmb_municipality)
        Me.Panel3.Controls.Add(Me.cmb_province)
        Me.Panel3.Controls.Add(Me.cmb_region)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.btnconedit)
        Me.Panel3.Controls.Add(Me.btnconcancel)
        Me.Panel3.Controls.Add(Me.btnconsave)
        Me.Panel3.Controls.Add(Me.txt_houseno)
        Me.Panel3.Controls.Add(Me.Label19)
        Me.Panel3.Controls.Add(Me.txt_street)
        Me.Panel3.Controls.Add(Me.lbl_invalid_email)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txt_email)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.txt_telno)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txt_mobileno)
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'cmb_barangay
        '
        resources.ApplyResources(Me.cmb_barangay, "cmb_barangay")
        Me.cmb_barangay.FormattingEnabled = True
        Me.cmb_barangay.Name = "cmb_barangay"
        '
        'cmb_municipality
        '
        resources.ApplyResources(Me.cmb_municipality, "cmb_municipality")
        Me.cmb_municipality.FormattingEnabled = True
        Me.cmb_municipality.Name = "cmb_municipality"
        '
        'cmb_province
        '
        resources.ApplyResources(Me.cmb_province, "cmb_province")
        Me.cmb_province.FormattingEnabled = True
        Me.cmb_province.Name = "cmb_province"
        '
        'cmb_region
        '
        resources.ApplyResources(Me.cmb_region, "cmb_region")
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Name = "cmb_region"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'btnconedit
        '
        Me.btnconedit.AutoEllipsis = True
        resources.ApplyResources(Me.btnconedit, "btnconedit")
        Me.btnconedit.Name = "btnconedit"
        Me.btnconedit.UseVisualStyleBackColor = True
        '
        'btnconcancel
        '
        resources.ApplyResources(Me.btnconcancel, "btnconcancel")
        Me.btnconcancel.Name = "btnconcancel"
        Me.btnconcancel.UseVisualStyleBackColor = True
        '
        'btnconsave
        '
        Me.btnconsave.AutoEllipsis = True
        resources.ApplyResources(Me.btnconsave, "btnconsave")
        Me.btnconsave.ForeColor = System.Drawing.Color.Black
        Me.btnconsave.Name = "btnconsave"
        Me.btnconsave.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel4)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.txt_uname)
        Me.Panel4.Controls.Add(Me.txt_pword)
        Me.Panel4.Controls.Add(Me.btn_gedit)
        Me.Panel4.Controls.Add(Me.btn_gcancel)
        Me.Panel4.Controls.Add(Me.btn_save)
        Me.Panel4.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.Panel4, "Panel4")
        Me.Panel4.Name = "Panel4"
        '
        'user_profile
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.idcontainer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "user_profile"
        Me.ShowIcon = False
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmv_status As System.Windows.Forms.ComboBox
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_gcancel As System.Windows.Forms.Button
    Friend WithEvents btn_gedit As System.Windows.Forms.Button
    Friend WithEvents txt_fname As System.Windows.Forms.TextBox
    Friend WithEvents txt_mname As System.Windows.Forms.TextBox
    Friend WithEvents txt_lname As System.Windows.Forms.TextBox
    Friend WithEvents birthdate_picker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents idcontainer As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_uname As System.Windows.Forms.TextBox
    Friend WithEvents txt_pword As System.Windows.Forms.TextBox
    Friend WithEvents lbl_invalid_email As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents txt_telno As System.Windows.Forms.TextBox
    Friend WithEvents txt_mobileno As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_houseno As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txt_street As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txt_specialty As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_sub_specialty As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txt_prc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnbedit As System.Windows.Forms.Button
    Friend WithEvents btnbcancel As System.Windows.Forms.Button
    Friend WithEvents btnbsave As System.Windows.Forms.Button
    Friend WithEvents btnconedit As System.Windows.Forms.Button
    Friend WithEvents btnconcancel As System.Windows.Forms.Button
    Friend WithEvents btnconsave As System.Windows.Forms.Button
    Friend WithEvents cmb_barangay As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_municipality As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_province As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
