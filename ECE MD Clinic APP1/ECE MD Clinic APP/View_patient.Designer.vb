<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class View_patient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(View_patient))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtp_enrolled = New System.Windows.Forms.DateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lbl_invalid_email = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txt_mobileno = New System.Windows.Forms.TextBox()
        Me.txt_telno = New System.Windows.Forms.TextBox()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.txt_father = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_mother = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txt_medication = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_chief_complaint = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_barangay = New System.Windows.Forms.ComboBox()
        Me.cmb_municipality = New System.Windows.Forms.ComboBox()
        Me.cmb_province = New System.Windows.Forms.ComboBox()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_houseno = New System.Windows.Forms.TextBox()
        Me.txt_reffered_by = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_height = New System.Windows.Forms.TextBox()
        Me.txt_weight = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmv_status = New System.Windows.Forms.ComboBox()
        Me.txt_occupation = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.group_gender = New System.Windows.Forms.GroupBox()
        Me.rdbtn_female = New System.Windows.Forms.RadioButton()
        Me.rdbtn_male = New System.Windows.Forms.RadioButton()
        Me.birthdate_picker = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txt_fname = New System.Windows.Forms.TextBox()
        Me.txt_mname = New System.Windows.Forms.TextBox()
        Me.txt_lname = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl_Diagnosis = New System.Windows.Forms.Label()
        Me.lbl_history = New System.Windows.Forms.Label()
        Me.lbl_test_results = New System.Windows.Forms.Label()
        Me.patient_info_container = New System.Windows.Forms.Panel()
        Me.profile_pic = New System.Windows.Forms.PictureBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.results_bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.diagnosis_bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.history_bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.context_replace = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.changeprofile = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveProfilePictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imagedialog = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ts_save = New System.Windows.Forms.ToolStripButton()
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton()
        Me.ts_edit = New System.Windows.Forms.ToolStripButton()
        Me.ts_credentials = New System.Windows.Forms.ToolStripButton()
        Me.Panel1.SuspendLayout()
        Me.group_gender.SuspendLayout()
        CType(Me.profile_pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.context_replace.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dtp_enrolled)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.lbl_invalid_email)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me.txt_mobileno)
        Me.Panel1.Controls.Add(Me.txt_telno)
        Me.Panel1.Controls.Add(Me.txt_email)
        Me.Panel1.Controls.Add(Me.txt_father)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txt_mother)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.txt_medication)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txt_chief_complaint)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmb_barangay)
        Me.Panel1.Controls.Add(Me.cmb_municipality)
        Me.Panel1.Controls.Add(Me.cmb_province)
        Me.Panel1.Controls.Add(Me.cmb_region)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.txt_houseno)
        Me.Panel1.Controls.Add(Me.txt_reffered_by)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txt_height)
        Me.Panel1.Controls.Add(Me.txt_weight)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.cmv_status)
        Me.Panel1.Controls.Add(Me.txt_occupation)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.group_gender)
        Me.Panel1.Controls.Add(Me.birthdate_picker)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txt_fname)
        Me.Panel1.Controls.Add(Me.txt_mname)
        Me.Panel1.Controls.Add(Me.txt_lname)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.lbl_Diagnosis)
        Me.Panel1.Controls.Add(Me.lbl_history)
        Me.Panel1.Controls.Add(Me.lbl_test_results)
        Me.Panel1.Controls.Add(Me.patient_info_container)
        Me.Panel1.Controls.Add(Me.profile_pic)
        Me.Panel1.Controls.Add(Me.ShapeContainer1)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1123, 697)
        Me.Panel1.TabIndex = 7
        '
        'dtp_enrolled
        '
        Me.dtp_enrolled.Enabled = False
        Me.dtp_enrolled.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_enrolled.Location = New System.Drawing.Point(89, 226)
        Me.dtp_enrolled.Name = "dtp_enrolled"
        Me.dtp_enrolled.Size = New System.Drawing.Size(360, 20)
        Me.dtp_enrolled.TabIndex = 171
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 230)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 172
        Me.Label24.Text = "Date Enrolled :"
        '
        'lbl_invalid_email
        '
        Me.lbl_invalid_email.AutoSize = True
        Me.lbl_invalid_email.ForeColor = System.Drawing.Color.Red
        Me.lbl_invalid_email.Location = New System.Drawing.Point(855, 247)
        Me.lbl_invalid_email.Name = "lbl_invalid_email"
        Me.lbl_invalid_email.Size = New System.Drawing.Size(66, 13)
        Me.lbl_invalid_email.TabIndex = 170
        Me.lbl_invalid_email.Text = "Invalid Email"
        Me.lbl_invalid_email.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(755, 226)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 13)
        Me.Label21.TabIndex = 169
        Me.Label21.Text = "Email Address :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(753, 201)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(51, 13)
        Me.Label22.TabIndex = 168
        Me.Label22.Text = "Tel. No. :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(754, 177)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 13)
        Me.Label23.TabIndex = 167
        Me.Label23.Text = "Mobile No. :"
        '
        'txt_mobileno
        '
        Me.txt_mobileno.Location = New System.Drawing.Point(859, 174)
        Me.txt_mobileno.Name = "txt_mobileno"
        Me.txt_mobileno.ReadOnly = True
        Me.txt_mobileno.Size = New System.Drawing.Size(223, 20)
        Me.txt_mobileno.TabIndex = 164
        '
        'txt_telno
        '
        Me.txt_telno.Location = New System.Drawing.Point(858, 198)
        Me.txt_telno.Name = "txt_telno"
        Me.txt_telno.ReadOnly = True
        Me.txt_telno.Size = New System.Drawing.Size(223, 20)
        Me.txt_telno.TabIndex = 165
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(858, 224)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.ReadOnly = True
        Me.txt_email.Size = New System.Drawing.Size(223, 20)
        Me.txt_email.TabIndex = 166
        '
        'txt_father
        '
        Me.txt_father.Location = New System.Drawing.Point(540, 198)
        Me.txt_father.Name = "txt_father"
        Me.txt_father.ReadOnly = True
        Me.txt_father.Size = New System.Drawing.Size(203, 20)
        Me.txt_father.TabIndex = 162
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(456, 201)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 163
        Me.Label10.Text = "Father's Name :"
        '
        'txt_mother
        '
        Me.txt_mother.Location = New System.Drawing.Point(540, 174)
        Me.txt_mother.Name = "txt_mother"
        Me.txt_mother.ReadOnly = True
        Me.txt_mother.Size = New System.Drawing.Size(203, 20)
        Me.txt_mother.TabIndex = 160
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(456, 177)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(84, 13)
        Me.Label20.TabIndex = 161
        Me.Label20.Text = "Mother's Name :"
        '
        'txt_medication
        '
        Me.txt_medication.Location = New System.Drawing.Point(89, 200)
        Me.txt_medication.Name = "txt_medication"
        Me.txt_medication.ReadOnly = True
        Me.txt_medication.Size = New System.Drawing.Size(360, 20)
        Me.txt_medication.TabIndex = 156
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 157
        Me.Label8.Text = "Medication :"
        '
        'txt_chief_complaint
        '
        Me.txt_chief_complaint.Location = New System.Drawing.Point(89, 174)
        Me.txt_chief_complaint.Name = "txt_chief_complaint"
        Me.txt_chief_complaint.ReadOnly = True
        Me.txt_chief_complaint.Size = New System.Drawing.Size(360, 20)
        Me.txt_chief_complaint.TabIndex = 154
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 155
        Me.Label4.Text = "Chief Complaint :"
        '
        'cmb_barangay
        '
        Me.cmb_barangay.Enabled = False
        Me.cmb_barangay.FormattingEnabled = True
        Me.cmb_barangay.Location = New System.Drawing.Point(858, 149)
        Me.cmb_barangay.Name = "cmb_barangay"
        Me.cmb_barangay.Size = New System.Drawing.Size(224, 21)
        Me.cmb_barangay.TabIndex = 153
        Me.cmb_barangay.Text = "Select Barangay"
        '
        'cmb_municipality
        '
        Me.cmb_municipality.Enabled = False
        Me.cmb_municipality.FormattingEnabled = True
        Me.cmb_municipality.Location = New System.Drawing.Point(858, 122)
        Me.cmb_municipality.Name = "cmb_municipality"
        Me.cmb_municipality.Size = New System.Drawing.Size(224, 21)
        Me.cmb_municipality.TabIndex = 152
        Me.cmb_municipality.Text = "Select Municipality"
        '
        'cmb_province
        '
        Me.cmb_province.Enabled = False
        Me.cmb_province.FormattingEnabled = True
        Me.cmb_province.Location = New System.Drawing.Point(858, 94)
        Me.cmb_province.Name = "cmb_province"
        Me.cmb_province.Size = New System.Drawing.Size(224, 21)
        Me.cmb_province.TabIndex = 151
        Me.cmb_province.Text = "Select Province"
        '
        'cmb_region
        '
        Me.cmb_region.Enabled = False
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Location = New System.Drawing.Point(858, 69)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(224, 21)
        Me.cmb_region.TabIndex = 150
        Me.cmb_region.Text = "Select Region"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(755, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 147
        Me.Label5.Text = "City/ Municipality :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(755, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 13)
        Me.Label6.TabIndex = 148
        Me.Label6.Text = "Province  :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(755, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Region :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(755, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 146
        Me.Label3.Text = "Barangay :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(755, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(100, 13)
        Me.Label19.TabIndex = 144
        Me.Label19.Text = "House No. / Street:"
        '
        'txt_houseno
        '
        Me.txt_houseno.Location = New System.Drawing.Point(858, 47)
        Me.txt_houseno.Name = "txt_houseno"
        Me.txt_houseno.ReadOnly = True
        Me.txt_houseno.Size = New System.Drawing.Size(224, 20)
        Me.txt_houseno.TabIndex = 142
        '
        'txt_reffered_by
        '
        Me.txt_reffered_by.Location = New System.Drawing.Point(520, 142)
        Me.txt_reffered_by.Name = "txt_reffered_by"
        Me.txt_reffered_by.ReadOnly = True
        Me.txt_reffered_by.Size = New System.Drawing.Size(223, 20)
        Me.txt_reffered_by.TabIndex = 51
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(456, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 52
        Me.Label2.Text = "Reffered By: "
        '
        'txt_height
        '
        Me.txt_height.Location = New System.Drawing.Point(520, 95)
        Me.txt_height.Name = "txt_height"
        Me.txt_height.ReadOnly = True
        Me.txt_height.Size = New System.Drawing.Size(223, 20)
        Me.txt_height.TabIndex = 47
        '
        'txt_weight
        '
        Me.txt_weight.Location = New System.Drawing.Point(520, 119)
        Me.txt_weight.Name = "txt_weight"
        Me.txt_weight.ReadOnly = True
        Me.txt_weight.Size = New System.Drawing.Size(223, 20)
        Me.txt_weight.TabIndex = 48
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(455, 97)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 49
        Me.Label17.Text = "Height :"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(456, 122)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(47, 13)
        Me.Label18.TabIndex = 50
        Me.Label18.Text = "Weight :"
        '
        'cmv_status
        '
        Me.cmv_status.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmv_status.Enabled = False
        Me.cmv_status.FormattingEnabled = True
        Me.cmv_status.Items.AddRange(New Object() {"Single", "Married", "Widow"})
        Me.cmv_status.Location = New System.Drawing.Point(520, 70)
        Me.cmv_status.Name = "cmv_status"
        Me.cmv_status.Size = New System.Drawing.Size(223, 21)
        Me.cmv_status.TabIndex = 44
        '
        'txt_occupation
        '
        Me.txt_occupation.Location = New System.Drawing.Point(520, 47)
        Me.txt_occupation.Name = "txt_occupation"
        Me.txt_occupation.ReadOnly = True
        Me.txt_occupation.Size = New System.Drawing.Size(223, 20)
        Me.txt_occupation.TabIndex = 43
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(455, 49)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 13)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "Occupation :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(455, 72)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "Civil Status :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(154, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Gender :"
        '
        'group_gender
        '
        Me.group_gender.Controls.Add(Me.rdbtn_female)
        Me.group_gender.Controls.Add(Me.rdbtn_male)
        Me.group_gender.Enabled = False
        Me.group_gender.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.group_gender.Location = New System.Drawing.Point(232, 136)
        Me.group_gender.Name = "group_gender"
        Me.group_gender.Size = New System.Drawing.Size(217, 32)
        Me.group_gender.TabIndex = 41
        Me.group_gender.TabStop = False
        '
        'rdbtn_female
        '
        Me.rdbtn_female.AutoSize = True
        Me.rdbtn_female.Location = New System.Drawing.Point(117, 9)
        Me.rdbtn_female.Name = "rdbtn_female"
        Me.rdbtn_female.Size = New System.Drawing.Size(59, 17)
        Me.rdbtn_female.TabIndex = 1
        Me.rdbtn_female.TabStop = True
        Me.rdbtn_female.Text = "Female"
        Me.rdbtn_female.UseVisualStyleBackColor = True
        '
        'rdbtn_male
        '
        Me.rdbtn_male.AutoSize = True
        Me.rdbtn_male.Location = New System.Drawing.Point(30, 9)
        Me.rdbtn_male.Name = "rdbtn_male"
        Me.rdbtn_male.Size = New System.Drawing.Size(48, 17)
        Me.rdbtn_male.TabIndex = 0
        Me.rdbtn_male.TabStop = True
        Me.rdbtn_male.Text = "Male"
        Me.rdbtn_male.UseVisualStyleBackColor = True
        '
        'birthdate_picker
        '
        Me.birthdate_picker.Enabled = False
        Me.birthdate_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.birthdate_picker.Location = New System.Drawing.Point(232, 118)
        Me.birthdate_picker.Name = "birthdate_picker"
        Me.birthdate_picker.Size = New System.Drawing.Size(217, 20)
        Me.birthdate_picker.TabIndex = 39
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(154, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 13)
        Me.Label15.TabIndex = 40
        Me.Label15.Text = "Birthdate :"
        '
        'txt_fname
        '
        Me.txt_fname.Location = New System.Drawing.Point(232, 47)
        Me.txt_fname.Name = "txt_fname"
        Me.txt_fname.ReadOnly = True
        Me.txt_fname.Size = New System.Drawing.Size(217, 20)
        Me.txt_fname.TabIndex = 33
        '
        'txt_mname
        '
        Me.txt_mname.Location = New System.Drawing.Point(232, 70)
        Me.txt_mname.Name = "txt_mname"
        Me.txt_mname.ReadOnly = True
        Me.txt_mname.Size = New System.Drawing.Size(217, 20)
        Me.txt_mname.TabIndex = 34
        '
        'txt_lname
        '
        Me.txt_lname.Location = New System.Drawing.Point(232, 95)
        Me.txt_lname.Name = "txt_lname"
        Me.txt_lname.ReadOnly = True
        Me.txt_lname.Size = New System.Drawing.Size(217, 20)
        Me.txt_lname.TabIndex = 35
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(154, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "First Name :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(154, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Middle Name :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(154, 98)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 38
        Me.Label13.Text = "Last Name :"
        '
        'lbl_Diagnosis
        '
        Me.lbl_Diagnosis.AutoSize = True
        Me.lbl_Diagnosis.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_Diagnosis.Font = New System.Drawing.Font("News701 BT", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Diagnosis.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_Diagnosis.Location = New System.Drawing.Point(524, 257)
        Me.lbl_Diagnosis.Name = "lbl_Diagnosis"
        Me.lbl_Diagnosis.Size = New System.Drawing.Size(151, 32)
        Me.lbl_Diagnosis.TabIndex = 24
        Me.lbl_Diagnosis.Text = "Diagnosis"
        '
        'lbl_history
        '
        Me.lbl_history.AutoSize = True
        Me.lbl_history.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_history.Font = New System.Drawing.Font("News701 BT", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_history.ForeColor = System.Drawing.Color.Blue
        Me.lbl_history.Location = New System.Drawing.Point(108, 257)
        Me.lbl_history.Name = "lbl_history"
        Me.lbl_history.Size = New System.Drawing.Size(158, 32)
        Me.lbl_history.TabIndex = 23
        Me.lbl_history.Text = "HISTORY"
        '
        'lbl_test_results
        '
        Me.lbl_test_results.AutoSize = True
        Me.lbl_test_results.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_test_results.Font = New System.Drawing.Font("News701 BT", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_test_results.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_test_results.Location = New System.Drawing.Point(831, 260)
        Me.lbl_test_results.Name = "lbl_test_results"
        Me.lbl_test_results.Size = New System.Drawing.Size(250, 32)
        Me.lbl_test_results.TabIndex = 22
        Me.lbl_test_results.Text = "TEST RESULTS"
        '
        'patient_info_container
        '
        Me.patient_info_container.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.patient_info_container.Location = New System.Drawing.Point(10, 305)
        Me.patient_info_container.Name = "patient_info_container"
        Me.patient_info_container.Size = New System.Drawing.Size(1098, 385)
        Me.patient_info_container.TabIndex = 7
        '
        'profile_pic
        '
        Me.profile_pic.BackgroundImage = CType(resources.GetObject("profile_pic.BackgroundImage"), System.Drawing.Image)
        Me.profile_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.profile_pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.profile_pic.Location = New System.Drawing.Point(10, 47)
        Me.profile_pic.Name = "profile_pic"
        Me.profile_pic.Size = New System.Drawing.Size(140, 121)
        Me.profile_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.profile_pic.TabIndex = 6
        Me.profile_pic.TabStop = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.results_bar, Me.diagnosis_bar, Me.history_bar})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1121, 695)
        Me.ShapeContainer1.TabIndex = 8
        Me.ShapeContainer1.TabStop = False
        '
        'results_bar
        '
        Me.results_bar.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.results_bar.Enabled = False
        Me.results_bar.FillColor = System.Drawing.Color.LightGray
        Me.results_bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.results_bar.Location = New System.Drawing.Point(770, 291)
        Me.results_bar.Name = "results_bar"
        Me.results_bar.Size = New System.Drawing.Size(337, 12)
        '
        'diagnosis_bar
        '
        Me.diagnosis_bar.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.diagnosis_bar.Enabled = False
        Me.diagnosis_bar.FillColor = System.Drawing.Color.LightGray
        Me.diagnosis_bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.diagnosis_bar.Location = New System.Drawing.Point(384, 291)
        Me.diagnosis_bar.Name = "diagnosis_bar"
        Me.diagnosis_bar.Size = New System.Drawing.Size(385, 12)
        '
        'history_bar
        '
        Me.history_bar.BackColor = System.Drawing.Color.Cyan
        Me.history_bar.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.history_bar.Enabled = False
        Me.history_bar.FillColor = System.Drawing.Color.Cyan
        Me.history_bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.history_bar.Location = New System.Drawing.Point(13, 291)
        Me.history_bar.Name = "history_bar"
        Me.history_bar.Size = New System.Drawing.Size(370, 12)
        '
        'context_replace
        '
        Me.context_replace.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.changeprofile, Me.RemoveProfilePictureToolStripMenuItem})
        Me.context_replace.Name = "context_replace"
        Me.context_replace.Size = New System.Drawing.Size(158, 48)
        '
        'changeprofile
        '
        Me.changeprofile.Name = "changeprofile"
        Me.changeprofile.Size = New System.Drawing.Size(157, 22)
        Me.changeprofile.Text = "Update Picture"
        '
        'RemoveProfilePictureToolStripMenuItem
        '
        Me.RemoveProfilePictureToolStripMenuItem.Name = "RemoveProfilePictureToolStripMenuItem"
        Me.RemoveProfilePictureToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.RemoveProfilePictureToolStripMenuItem.Text = "Remove Picture"
        '
        'imagedialog
        '
        Me.imagedialog.FileName = "OpenFileDialog1"
        Me.imagedialog.Title = "Select Image"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(30, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_save, Me.ts_cancel, Me.ts_edit, Me.ts_credentials})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1122, 46)
        Me.ToolStrip1.TabIndex = 174
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ts_save
        '
        Me.ts_save.Image = CType(resources.GetObject("ts_save.Image"), System.Drawing.Image)
        Me.ts_save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_save.Name = "ts_save"
        Me.ts_save.Size = New System.Drawing.Size(35, 43)
        Me.ts_save.Text = "Save"
        Me.ts_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ts_save.Visible = False
        '
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Size = New System.Drawing.Size(47, 43)
        Me.ts_cancel.Text = "Cancel"
        Me.ts_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ts_cancel.Visible = False
        '
        'ts_edit
        '
        Me.ts_edit.Image = CType(resources.GetObject("ts_edit.Image"), System.Drawing.Image)
        Me.ts_edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_edit.Name = "ts_edit"
        Me.ts_edit.Size = New System.Drawing.Size(37, 43)
        Me.ts_edit.Text = " Edit "
        Me.ts_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_credentials
        '
        Me.ts_credentials.Image = CType(resources.GetObject("ts_credentials.Image"), System.Drawing.Image)
        Me.ts_credentials.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_credentials.Name = "ts_credentials"
        Me.ts_credentials.Size = New System.Drawing.Size(70, 43)
        Me.ts_credentials.Text = "Credentials"
        Me.ts_credentials.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'View_patient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 695)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.IsMdiContainer = True
        Me.Name = "View_patient"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patient Record"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.group_gender.ResumeLayout(False)
        Me.group_gender.PerformLayout()
        CType(Me.profile_pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.context_replace.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents patient_info_container As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents results_bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents diagnosis_bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents history_bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lbl_Diagnosis As System.Windows.Forms.Label
    Friend WithEvents lbl_history As System.Windows.Forms.Label
    Friend WithEvents lbl_test_results As System.Windows.Forms.Label
    Friend WithEvents context_replace As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents changeprofile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imagedialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RemoveProfilePictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents profile_pic As System.Windows.Forms.PictureBox
    Friend WithEvents txt_fname As System.Windows.Forms.TextBox
    Friend WithEvents txt_mname As System.Windows.Forms.TextBox
    Friend WithEvents txt_lname As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents birthdate_picker As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents group_gender As System.Windows.Forms.GroupBox
    Friend WithEvents rdbtn_female As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtn_male As System.Windows.Forms.RadioButton
    Friend WithEvents cmv_status As System.Windows.Forms.ComboBox
    Friend WithEvents txt_occupation As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txt_reffered_by As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt_height As System.Windows.Forms.TextBox
    Friend WithEvents txt_weight As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmb_barangay As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_municipality As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_province As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_houseno As System.Windows.Forms.TextBox
    Friend WithEvents txt_father As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_mother As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txt_medication As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_chief_complaint As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_invalid_email As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_mobileno As System.Windows.Forms.TextBox
    Friend WithEvents txt_telno As System.Windows.Forms.TextBox
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents dtp_enrolled As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_credentials As System.Windows.Forms.ToolStripButton
End Class
