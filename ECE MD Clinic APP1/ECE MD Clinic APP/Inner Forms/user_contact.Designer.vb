<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class user_contact
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
        Me.lbl_invalid_email = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_barangay = New System.Windows.Forms.TextBox()
        Me.txt_province = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txt_houseno = New System.Windows.Forms.TextBox()
        Me.btn_csave = New System.Windows.Forms.Button()
        Me.btn_ccancel = New System.Windows.Forms.Button()
        Me.txt_street = New System.Windows.Forms.TextBox()
        Me.btn_cedit = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txt_city = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_zip = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_mobileno = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_telno = New System.Windows.Forms.TextBox()
        Me.txt_email = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_region = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbl_invalid_email
        '
        Me.lbl_invalid_email.AutoSize = True
        Me.lbl_invalid_email.ForeColor = System.Drawing.Color.Red
        Me.lbl_invalid_email.Location = New System.Drawing.Point(217, 396)
        Me.lbl_invalid_email.Name = "lbl_invalid_email"
        Me.lbl_invalid_email.Size = New System.Drawing.Size(66, 13)
        Me.lbl_invalid_email.TabIndex = 66
        Me.lbl_invalid_email.Text = "Invalid Email"
        Me.lbl_invalid_email.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(87, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 53
        Me.Label5.Text = "Province  :"
        '
        'txt_barangay
        '
        Me.txt_barangay.Location = New System.Drawing.Point(220, 217)
        Me.txt_barangay.Name = "txt_barangay"
        Me.txt_barangay.ReadOnly = True
        Me.txt_barangay.Size = New System.Drawing.Size(274, 20)
        Me.txt_barangay.TabIndex = 20
        '
        'txt_province
        '
        Me.txt_province.Location = New System.Drawing.Point(220, 269)
        Me.txt_province.Name = "txt_province"
        Me.txt_province.ReadOnly = True
        Me.txt_province.Size = New System.Drawing.Size(274, 20)
        Me.txt_province.TabIndex = 22
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(87, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Barangay :"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(87, 169)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(64, 13)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "House No. :"
        '
        'txt_houseno
        '
        Me.txt_houseno.Location = New System.Drawing.Point(220, 166)
        Me.txt_houseno.Name = "txt_houseno"
        Me.txt_houseno.ReadOnly = True
        Me.txt_houseno.Size = New System.Drawing.Size(274, 20)
        Me.txt_houseno.TabIndex = 18
        '
        'btn_csave
        '
        Me.btn_csave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_csave.ForeColor = System.Drawing.Color.Black
        Me.btn_csave.Location = New System.Drawing.Point(198, 438)
        Me.btn_csave.Name = "btn_csave"
        Me.btn_csave.Size = New System.Drawing.Size(86, 26)
        Me.btn_csave.TabIndex = 28
        Me.btn_csave.Text = "Save"
        Me.btn_csave.UseVisualStyleBackColor = True
        Me.btn_csave.Visible = False
        '
        'btn_ccancel
        '
        Me.btn_ccancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ccancel.Location = New System.Drawing.Point(301, 438)
        Me.btn_ccancel.Name = "btn_ccancel"
        Me.btn_ccancel.Size = New System.Drawing.Size(86, 26)
        Me.btn_ccancel.TabIndex = 28
        Me.btn_ccancel.Text = "Cancel"
        Me.btn_ccancel.UseVisualStyleBackColor = True
        Me.btn_ccancel.Visible = False
        '
        'txt_street
        '
        Me.txt_street.Location = New System.Drawing.Point(220, 194)
        Me.txt_street.Name = "txt_street"
        Me.txt_street.ReadOnly = True
        Me.txt_street.Size = New System.Drawing.Size(274, 20)
        Me.txt_street.TabIndex = 19
        '
        'btn_cedit
        '
        Me.btn_cedit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_cedit.Location = New System.Drawing.Point(246, 438)
        Me.btn_cedit.Name = "btn_cedit"
        Me.btn_cedit.Size = New System.Drawing.Size(86, 26)
        Me.btn_cedit.TabIndex = 59
        Me.btn_cedit.Text = "EDIT"
        Me.btn_cedit.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(87, 376)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 13)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Email Address :"
        '
        'txt_city
        '
        Me.txt_city.Location = New System.Drawing.Point(219, 243)
        Me.txt_city.Name = "txt_city"
        Me.txt_city.ReadOnly = True
        Me.txt_city.Size = New System.Drawing.Size(274, 20)
        Me.txt_city.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(87, 350)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "Tel. No. :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(87, 323)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 56
        Me.Label8.Text = "Mobile No. :"
        '
        'txt_zip
        '
        Me.txt_zip.Location = New System.Drawing.Point(415, 294)
        Me.txt_zip.Name = "txt_zip"
        Me.txt_zip.ReadOnly = True
        Me.txt_zip.Size = New System.Drawing.Size(78, 20)
        Me.txt_zip.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(359, 297)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 55
        Me.Label7.Text = "Zip Code :"
        '
        'txt_mobileno
        '
        Me.txt_mobileno.Location = New System.Drawing.Point(220, 320)
        Me.txt_mobileno.Name = "txt_mobileno"
        Me.txt_mobileno.ReadOnly = True
        Me.txt_mobileno.Size = New System.Drawing.Size(274, 20)
        Me.txt_mobileno.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(87, 297)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 54
        Me.Label6.Text = "Region :"
        '
        'txt_telno
        '
        Me.txt_telno.Location = New System.Drawing.Point(219, 347)
        Me.txt_telno.Name = "txt_telno"
        Me.txt_telno.ReadOnly = True
        Me.txt_telno.Size = New System.Drawing.Size(274, 20)
        Me.txt_telno.TabIndex = 26
        '
        'txt_email
        '
        Me.txt_email.Location = New System.Drawing.Point(219, 373)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.ReadOnly = True
        Me.txt_email.Size = New System.Drawing.Size(274, 20)
        Me.txt_email.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(87, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "City/ Municipality :"
        '
        'cmb_region
        '
        Me.cmb_region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_region.Enabled = False
        Me.cmb_region.FormattingEnabled = True
        Me.cmb_region.Items.AddRange(New Object() {"Region I", "Region II", "Region III", "Region IV", "Region V", "Region VI", "Region VII", "Region VIII", "Region IX", "Region X", "Region XI", "Region XII", "Region XIII", "NCR", "CAR", "Bangsamoro"})
        Me.cmb_region.Location = New System.Drawing.Point(219, 294)
        Me.cmb_region.Name = "cmb_region"
        Me.cmb_region.Size = New System.Drawing.Size(134, 21)
        Me.cmb_region.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(87, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Street :"
        '
        'user_contact
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(582, 485)
        Me.Controls.Add(Me.lbl_invalid_email)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmb_region)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.txt_barangay)
        Me.Controls.Add(Me.txt_telno)
        Me.Controls.Add(Me.txt_province)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txt_mobileno)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txt_zip)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txt_houseno)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txt_city)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btn_cedit)
        Me.Controls.Add(Me.txt_street)
        Me.Controls.Add(Me.btn_csave)
        Me.Controls.Add(Me.btn_ccancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "user_contact"
        Me.ShowIcon = False
        Me.Text = "user_contact"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl_invalid_email As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_barangay As System.Windows.Forms.TextBox
    Friend WithEvents txt_province As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txt_houseno As System.Windows.Forms.TextBox
    Friend WithEvents btn_csave As System.Windows.Forms.Button
    Friend WithEvents btn_ccancel As System.Windows.Forms.Button
    Friend WithEvents txt_street As System.Windows.Forms.TextBox
    Friend WithEvents btn_cedit As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txt_city As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_zip As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_mobileno As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_telno As System.Windows.Forms.TextBox
    Friend WithEvents txt_email As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmb_region As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
