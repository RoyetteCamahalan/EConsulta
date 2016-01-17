<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class new_consult
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(new_consult))
        Me.btn_add_patient = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmb_doctors = New System.Windows.Forms.ComboBox()
        Me.cmb_patients = New System.Windows.Forms.ComboBox()
        Me.txt_complaints = New System.Windows.Forms.TextBox()
        Me.txt_findings = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtgv_treatments = New System.Windows.Forms.DataGridView()
        Me.Med_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medicine_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No_Generics = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Route = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Frequency = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Refills = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_last_updated = New System.Windows.Forms.Label()
        Me.dtp_date = New System.Windows.Forms.DateTimePicker()
        Me.lbl_date = New System.Windows.Forms.Label()
        Me.timer_last_update = New System.Windows.Forms.Timer(Me.components)
        Me.btn_print_presciption = New System.Windows.Forms.Button()
        Me.btn_new_treatment = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ts_save = New System.Windows.Forms.ToolStripButton()
        Me.ts_cancel = New System.Windows.Forms.ToolStripButton()
        Me.ts_edit = New System.Windows.Forms.ToolStripButton()
        Me.ts_close = New System.Windows.Forms.ToolStripButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmb_department = New System.Windows.Forms.ComboBox()
        Me.btn_saveastemplate = New System.Windows.Forms.Button()
        Me.btn_addfromtemplate = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ob_gyne = New System.Windows.Forms.TabPage()
        Me.pogs = New System.Windows.Forms.TabPage()
        Me.ob_pogs_table = New System.Windows.Forms.TabPage()
        Me.guardian_info = New System.Windows.Forms.TabPage()
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        CType(Me.dtgv_treatments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_add_patient
        '
        Me.btn_add_patient.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_add_patient.ForeColor = System.Drawing.Color.Black
        Me.btn_add_patient.Location = New System.Drawing.Point(178, 59)
        Me.btn_add_patient.Name = "btn_add_patient"
        Me.btn_add_patient.Size = New System.Drawing.Size(113, 28)
        Me.btn_add_patient.TabIndex = 22
        Me.btn_add_patient.Text = "Add Patient"
        Me.btn_add_patient.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(-1, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Select Patient :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(-1, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Select Doctor :"
        '
        'cmb_doctors
        '
        Me.cmb_doctors.FormattingEnabled = True
        Me.cmb_doctors.Location = New System.Drawing.Point(24, 131)
        Me.cmb_doctors.Name = "cmb_doctors"
        Me.cmb_doctors.Size = New System.Drawing.Size(267, 21)
        Me.cmb_doctors.TabIndex = 13
        '
        'cmb_patients
        '
        Me.cmb_patients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_patients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_patients.FormattingEnabled = True
        Me.cmb_patients.Location = New System.Drawing.Point(24, 32)
        Me.cmb_patients.Name = "cmb_patients"
        Me.cmb_patients.Size = New System.Drawing.Size(267, 21)
        Me.cmb_patients.TabIndex = 12
        '
        'txt_complaints
        '
        Me.txt_complaints.Location = New System.Drawing.Point(380, 32)
        Me.txt_complaints.Multiline = True
        Me.txt_complaints.Name = "txt_complaints"
        Me.txt_complaints.Size = New System.Drawing.Size(398, 66)
        Me.txt_complaints.TabIndex = 23
        '
        'txt_findings
        '
        Me.txt_findings.Location = New System.Drawing.Point(380, 132)
        Me.txt_findings.Multiline = True
        Me.txt_findings.Name = "txt_findings"
        Me.txt_findings.Size = New System.Drawing.Size(398, 72)
        Me.txt_findings.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(377, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 15)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Complaints :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(377, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Findings :"
        '
        'dtgv_treatments
        '
        Me.dtgv_treatments.AllowUserToAddRows = False
        Me.dtgv_treatments.AllowUserToDeleteRows = False
        Me.dtgv_treatments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_treatments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Med_Id, Me.Medicine_Name, Me.No_Generics, Me.qty, Me.Route, Me.Frequency, Me.Refills, Me.Duration, Me.Column1})
        Me.dtgv_treatments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgv_treatments.Location = New System.Drawing.Point(8, 256)
        Me.dtgv_treatments.MultiSelect = False
        Me.dtgv_treatments.Name = "dtgv_treatments"
        Me.dtgv_treatments.RowHeadersVisible = False
        Me.dtgv_treatments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgv_treatments.Size = New System.Drawing.Size(784, 128)
        Me.dtgv_treatments.TabIndex = 27
        '
        'Med_Id
        '
        Me.Med_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Med_Id.HeaderText = "Med_Id"
        Me.Med_Id.Name = "Med_Id"
        Me.Med_Id.Visible = False
        Me.Med_Id.Width = 5
        '
        'Medicine_Name
        '
        Me.Medicine_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Medicine_Name.HeaderText = "Medicine Name"
        Me.Medicine_Name.Name = "Medicine_Name"
        Me.Medicine_Name.ReadOnly = True
        '
        'No_Generics
        '
        Me.No_Generics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.No_Generics.FalseValue = "0"
        Me.No_Generics.HeaderText = "No Generics"
        Me.No_Generics.Name = "No_Generics"
        Me.No_Generics.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.No_Generics.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.No_Generics.TrueValue = "1"
        Me.No_Generics.Width = 60
        '
        'qty
        '
        Me.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.qty.DefaultCellStyle = DataGridViewCellStyle1
        Me.qty.HeaderText = "Quantity"
        Me.qty.Name = "qty"
        Me.qty.Width = 60
        '
        'Route
        '
        Me.Route.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Route.HeaderText = "Route"
        Me.Route.Name = "Route"
        Me.Route.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Route.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Frequency
        '
        Me.Frequency.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Frequency.HeaderText = "Frequency"
        Me.Frequency.Name = "Frequency"
        '
        'Refills
        '
        Me.Refills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Refills.HeaderText = "Refills"
        Me.Refills.Name = "Refills"
        Me.Refills.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Refills.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Refills.Width = 60
        '
        'Duration
        '
        Me.Duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Duration.HeaderText = "Duration"
        Me.Duration.Name = "Duration"
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.HeaderText = "Action"
        Me.Column1.Name = "Column1"
        Me.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column1.Visible = False
        Me.Column1.Width = 80
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(5, 238)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 15)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Prescriptions :"
        '
        'lbl_last_updated
        '
        Me.lbl_last_updated.AutoSize = True
        Me.lbl_last_updated.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_last_updated.Location = New System.Drawing.Point(8, 394)
        Me.lbl_last_updated.Name = "lbl_last_updated"
        Me.lbl_last_updated.Size = New System.Drawing.Size(106, 16)
        Me.lbl_last_updated.TabIndex = 30
        Me.lbl_last_updated.Text = "last_updated"
        Me.lbl_last_updated.Visible = False
        '
        'dtp_date
        '
        Me.dtp_date.CustomFormat = "MM-dd-yyyy hh:mm tt"
        Me.dtp_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_date.Location = New System.Drawing.Point(24, 205)
        Me.dtp_date.Name = "dtp_date"
        Me.dtp_date.ShowUpDown = True
        Me.dtp_date.Size = New System.Drawing.Size(267, 20)
        Me.dtp_date.TabIndex = 31
        Me.dtp_date.Visible = False
        '
        'lbl_date
        '
        Me.lbl_date.AutoSize = True
        Me.lbl_date.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.lbl_date.Location = New System.Drawing.Point(21, 190)
        Me.lbl_date.Name = "lbl_date"
        Me.lbl_date.Size = New System.Drawing.Size(101, 15)
        Me.lbl_date.TabIndex = 32
        Me.lbl_date.Text = "Date and Time :"
        Me.lbl_date.Visible = False
        '
        'timer_last_update
        '
        Me.timer_last_update.Interval = 1000
        '
        'btn_print_presciption
        '
        Me.btn_print_presciption.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_print_presciption.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_print_presciption.Location = New System.Drawing.Point(666, 221)
        Me.btn_print_presciption.Name = "btn_print_presciption"
        Me.btn_print_presciption.Size = New System.Drawing.Size(112, 32)
        Me.btn_print_presciption.TabIndex = 33
        Me.btn_print_presciption.Text = "Print Prescription"
        Me.btn_print_presciption.UseVisualStyleBackColor = True
        Me.btn_print_presciption.Visible = False
        '
        'btn_new_treatment
        '
        Me.btn_new_treatment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_new_treatment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_new_treatment.Location = New System.Drawing.Point(666, 221)
        Me.btn_new_treatment.Name = "btn_new_treatment"
        Me.btn_new_treatment.Size = New System.Drawing.Size(112, 32)
        Me.btn_new_treatment.TabIndex = 34
        Me.btn_new_treatment.Text = "New Detail"
        Me.btn_new_treatment.UseVisualStyleBackColor = True
        Me.btn_new_treatment.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ts_save, Me.ts_cancel, Me.ts_edit, Me.ts_close})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(804, 52)
        Me.ToolStrip1.TabIndex = 35
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
        '
        'ts_cancel
        '
        Me.ts_cancel.Image = CType(resources.GetObject("ts_cancel.Image"), System.Drawing.Image)
        Me.ts_cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_cancel.Name = "ts_cancel"
        Me.ts_cancel.Size = New System.Drawing.Size(47, 49)
        Me.ts_cancel.Text = "Cancel"
        Me.ts_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ts_edit
        '
        Me.ts_edit.Image = CType(resources.GetObject("ts_edit.Image"), System.Drawing.Image)
        Me.ts_edit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_edit.Name = "ts_edit"
        Me.ts_edit.Size = New System.Drawing.Size(37, 49)
        Me.ts_edit.Text = " Edit "
        Me.ts_edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ts_edit.Visible = False
        '
        'ts_close
        '
        Me.ts_close.Image = CType(resources.GetObject("ts_close.Image"), System.Drawing.Image)
        Me.ts_close.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ts_close.Name = "ts_close"
        Me.ts_close.Size = New System.Drawing.Size(40, 49)
        Me.ts_close.Text = "Close"
        Me.ts_close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ts_close.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Modern No. 20", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(-1, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 15)
        Me.Label6.TabIndex = 37
        Me.Label6.Text = "Department :"
        '
        'cmb_department
        '
        Me.cmb_department.FormattingEnabled = True
        Me.cmb_department.Location = New System.Drawing.Point(83, 155)
        Me.cmb_department.Name = "cmb_department"
        Me.cmb_department.Size = New System.Drawing.Size(208, 21)
        Me.cmb_department.TabIndex = 36
        '
        'btn_saveastemplate
        '
        Me.btn_saveastemplate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_saveastemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_saveastemplate.Location = New System.Drawing.Point(430, 221)
        Me.btn_saveastemplate.Name = "btn_saveastemplate"
        Me.btn_saveastemplate.Size = New System.Drawing.Size(112, 32)
        Me.btn_saveastemplate.TabIndex = 38
        Me.btn_saveastemplate.Text = "Save as Template"
        Me.btn_saveastemplate.UseVisualStyleBackColor = True
        Me.btn_saveastemplate.Visible = False
        '
        'btn_addfromtemplate
        '
        Me.btn_addfromtemplate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_addfromtemplate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_addfromtemplate.Location = New System.Drawing.Point(548, 221)
        Me.btn_addfromtemplate.Name = "btn_addfromtemplate"
        Me.btn_addfromtemplate.Size = New System.Drawing.Size(112, 32)
        Me.btn_addfromtemplate.TabIndex = 39
        Me.btn_addfromtemplate.Text = "Add from Template"
        Me.btn_addfromtemplate.UseVisualStyleBackColor = True
        Me.btn_addfromtemplate.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.ob_gyne)
        Me.TabControl1.Controls.Add(Me.pogs)
        Me.TabControl1.Controls.Add(Me.ob_pogs_table)
        Me.TabControl1.Controls.Add(Me.guardian_info)
        Me.TabControl1.Location = New System.Drawing.Point(0, 55)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(808, 439)
        Me.TabControl1.TabIndex = 40
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cmb_patients)
        Me.TabPage1.Controls.Add(Me.btn_addfromtemplate)
        Me.TabPage1.Controls.Add(Me.cmb_doctors)
        Me.TabPage1.Controls.Add(Me.btn_saveastemplate)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cmb_department)
        Me.TabPage1.Controls.Add(Me.btn_add_patient)
        Me.TabPage1.Controls.Add(Me.txt_complaints)
        Me.TabPage1.Controls.Add(Me.btn_new_treatment)
        Me.TabPage1.Controls.Add(Me.txt_findings)
        Me.TabPage1.Controls.Add(Me.btn_print_presciption)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lbl_date)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.dtp_date)
        Me.TabPage1.Controls.Add(Me.dtgv_treatments)
        Me.TabPage1.Controls.Add(Me.lbl_last_updated)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(800, 413)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ob_gyne
        '
        Me.ob_gyne.Location = New System.Drawing.Point(4, 22)
        Me.ob_gyne.Name = "ob_gyne"
        Me.ob_gyne.Padding = New System.Windows.Forms.Padding(3)
        Me.ob_gyne.Size = New System.Drawing.Size(800, 413)
        Me.ob_gyne.TabIndex = 1
        Me.ob_gyne.Text = "Ob-Gyne"
        Me.ob_gyne.UseVisualStyleBackColor = True
        '
        'pogs
        '
        Me.pogs.Location = New System.Drawing.Point(4, 22)
        Me.pogs.Name = "pogs"
        Me.pogs.Size = New System.Drawing.Size(800, 413)
        Me.pogs.TabIndex = 2
        Me.pogs.Text = "Pogs Obstetrical Sheet"
        Me.pogs.UseVisualStyleBackColor = True
        '
        'ob_pogs_table
        '
        Me.ob_pogs_table.Location = New System.Drawing.Point(4, 22)
        Me.ob_pogs_table.Name = "ob_pogs_table"
        Me.ob_pogs_table.Size = New System.Drawing.Size(800, 413)
        Me.ob_pogs_table.TabIndex = 3
        Me.ob_pogs_table.Text = "Ob-Gyne and Pods Table"
        Me.ob_pogs_table.UseVisualStyleBackColor = True
        '
        'guardian_info
        '
        Me.guardian_info.Location = New System.Drawing.Point(4, 22)
        Me.guardian_info.Name = "guardian_info"
        Me.guardian_info.Padding = New System.Windows.Forms.Padding(3)
        Me.guardian_info.Size = New System.Drawing.Size(800, 413)
        Me.guardian_info.TabIndex = 4
        Me.guardian_info.Text = "Guardian Information"
        Me.guardian_info.UseVisualStyleBackColor = True
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'new_consult
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 490)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "new_consult"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Consultation"
        CType(Me.dtgv_treatments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_add_patient As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmb_doctors As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_patients As System.Windows.Forms.ComboBox
    Friend WithEvents txt_complaints As System.Windows.Forms.TextBox
    Friend WithEvents txt_findings As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtgv_treatments As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_last_updated As System.Windows.Forms.Label
    Friend WithEvents dtp_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbl_date As System.Windows.Forms.Label
    Friend WithEvents timer_last_update As System.Windows.Forms.Timer
    Friend WithEvents btn_print_presciption As System.Windows.Forms.Button
    Friend WithEvents btn_new_treatment As System.Windows.Forms.Button
    Friend WithEvents Med_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Medicine_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No_Generics As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Route As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Frequency As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Refills As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ts_save As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_cancel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_edit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ts_close As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmb_department As System.Windows.Forms.ComboBox
    Friend WithEvents btn_saveastemplate As System.Windows.Forms.Button
    Friend WithEvents btn_addfromtemplate As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ob_gyne As System.Windows.Forms.TabPage
    Friend WithEvents pogs As System.Windows.Forms.TabPage
    Friend WithEvents ob_pogs_table As System.Windows.Forms.TabPage
    Friend WithEvents guardian_info As System.Windows.Forms.TabPage
    Friend WithEvents PrintForm1 As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
End Class
