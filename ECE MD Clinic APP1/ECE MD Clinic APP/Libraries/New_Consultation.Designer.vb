﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class New_Consultation
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
        Me.cmb_patients = New System.Windows.Forms.ComboBox()
        Me.cmb_doctors = New System.Windows.Forms.ComboBox()
        Me.dtp_date = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_notes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_save = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmb_patients
        '
        Me.cmb_patients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmb_patients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmb_patients.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmb_patients.FormattingEnabled = True
        Me.cmb_patients.Location = New System.Drawing.Point(48, 43)
        Me.cmb_patients.Name = "cmb_patients"
        Me.cmb_patients.Size = New System.Drawing.Size(266, 23)
        Me.cmb_patients.TabIndex = 1
        '
        'cmb_doctors
        '
        Me.cmb_doctors.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.cmb_doctors.FormattingEnabled = True
        Me.cmb_doctors.Location = New System.Drawing.Point(48, 128)
        Me.cmb_doctors.Name = "cmb_doctors"
        Me.cmb_doctors.Size = New System.Drawing.Size(266, 23)
        Me.cmb_doctors.TabIndex = 2
        '
        'dtp_date
        '
        Me.dtp_date.CustomFormat = "MM-dd-yyyy hh:mm tt"
        Me.dtp_date.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtp_date.Location = New System.Drawing.Point(48, 175)
        Me.dtp_date.Name = "dtp_date"
        Me.dtp_date.ShowUpDown = True
        Me.dtp_date.Size = New System.Drawing.Size(266, 21)
        Me.dtp_date.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(44, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select Doctor :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(44, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Select Patient :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(44, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Date :"
        '
        'txt_notes
        '
        Me.txt_notes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.txt_notes.Location = New System.Drawing.Point(48, 241)
        Me.txt_notes.Multiline = True
        Me.txt_notes.Name = "txt_notes"
        Me.txt_notes.Size = New System.Drawing.Size(266, 77)
        Me.txt_notes.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(44, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Comment(s) :"
        '
        'btn_cancel
        '
        Me.btn_cancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_cancel.Location = New System.Drawing.Point(182, 325)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(133, 42)
        Me.btn_cancel.TabIndex = 7
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_save
        '
        Me.btn_save.Enabled = False
        Me.btn_save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btn_save.Location = New System.Drawing.Point(48, 325)
        Me.btn_save.Name = "btn_save"
        Me.btn_save.Size = New System.Drawing.Size(133, 42)
        Me.btn_save.TabIndex = 6
        Me.btn_save.Text = "Save"
        Me.btn_save.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(117, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 32)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Add Patient"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'New_Consultation
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(360, 374)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_save)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_notes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_date)
        Me.Controls.Add(Me.cmb_doctors)
        Me.Controls.Add(Me.cmb_patients)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "New_Consultation"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Consultation Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmb_patients As System.Windows.Forms.ComboBox
    Friend WithEvents cmb_doctors As System.Windows.Forms.ComboBox
    Friend WithEvents dtp_date As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_notes As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
