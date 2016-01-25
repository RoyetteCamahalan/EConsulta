<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Me.Panel_Header = New System.Windows.Forms.Panel()
        Me.lbl_notif_context = New System.Windows.Forms.Label()
        Me.consultation_header = New System.Windows.Forms.Panel()
        Me.Menu_Consultations = New System.Windows.Forms.Label()
        Me.Appointments_Header = New System.Windows.Forms.Panel()
        Me.Menu_Appoinments = New System.Windows.Forms.Label()
        Me.patients_header = New System.Windows.Forms.Panel()
        Me.Menu_Patients = New System.Windows.Forms.Label()
        Me.doctors_header = New System.Windows.Forms.Panel()
        Me.Menu_Doctors = New System.Windows.Forms.Label()
        Me.secretaries_header = New System.Windows.Forms.Panel()
        Me.Menu_Secretaries = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.lbl_notification_counter = New System.Windows.Forms.Label()
        Me.Notification_counter_container = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.Panel_Container1 = New System.Windows.Forms.Panel()
        Me.Panel_Container2 = New System.Windows.Forms.Panel()
        Me.lbl_user_name = New System.Windows.Forms.Label()
        Me.Panel_Footer = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chk_transition = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FgffdgToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MyProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ts_sign_out = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Timer_Transition1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Transition2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_Header.SuspendLayout()
        Me.consultation_header.SuspendLayout()
        Me.Appointments_Header.SuspendLayout()
        Me.patients_header.SuspendLayout()
        Me.doctors_header.SuspendLayout()
        Me.secretaries_header.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ShapeContainer2.SuspendLayout()
        Me.Panel_Footer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_Header
        '
        Me.Panel_Header.BackColor = System.Drawing.Color.DimGray
        Me.Panel_Header.Controls.Add(Me.lbl_notif_context)
        Me.Panel_Header.Controls.Add(Me.consultation_header)
        Me.Panel_Header.Controls.Add(Me.Appointments_Header)
        Me.Panel_Header.Controls.Add(Me.patients_header)
        Me.Panel_Header.Controls.Add(Me.doctors_header)
        Me.Panel_Header.Controls.Add(Me.secretaries_header)
        Me.Panel_Header.Controls.Add(Me.Panel4)
        Me.Panel_Header.Location = New System.Drawing.Point(1, 1)
        Me.Panel_Header.Name = "Panel_Header"
        Me.Panel_Header.Size = New System.Drawing.Size(1143, 51)
        Me.Panel_Header.TabIndex = 1
        '
        'lbl_notif_context
        '
        Me.lbl_notif_context.AutoSize = True
        Me.lbl_notif_context.BackColor = System.Drawing.Color.Transparent
        Me.lbl_notif_context.ForeColor = System.Drawing.Color.White
        Me.lbl_notif_context.Location = New System.Drawing.Point(950, 38)
        Me.lbl_notif_context.Name = "lbl_notif_context"
        Me.lbl_notif_context.Size = New System.Drawing.Size(163, 13)
        Me.lbl_notif_context.TabIndex = 0
        Me.lbl_notif_context.Text = "You have no notification request!"
        Me.lbl_notif_context.Visible = False
        '
        'consultation_header
        '
        Me.consultation_header.BackColor = System.Drawing.Color.Gray
        Me.consultation_header.Controls.Add(Me.Menu_Consultations)
        Me.consultation_header.Dock = System.Windows.Forms.DockStyle.Right
        Me.consultation_header.Location = New System.Drawing.Point(620, 0)
        Me.consultation_header.Name = "consultation_header"
        Me.consultation_header.Size = New System.Drawing.Size(115, 51)
        Me.consultation_header.TabIndex = 1
        '
        'Menu_Consultations
        '
        Me.Menu_Consultations.AutoSize = True
        Me.Menu_Consultations.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu_Consultations.ForeColor = System.Drawing.Color.White
        Me.Menu_Consultations.Location = New System.Drawing.Point(4, 17)
        Me.Menu_Consultations.Name = "Menu_Consultations"
        Me.Menu_Consultations.Size = New System.Drawing.Size(109, 16)
        Me.Menu_Consultations.TabIndex = 4
        Me.Menu_Consultations.Text = "Consultations"
        '
        'Appointments_Header
        '
        Me.Appointments_Header.BackColor = System.Drawing.Color.DimGray
        Me.Appointments_Header.Controls.Add(Me.Menu_Appoinments)
        Me.Appointments_Header.Dock = System.Windows.Forms.DockStyle.Right
        Me.Appointments_Header.Location = New System.Drawing.Point(735, 0)
        Me.Appointments_Header.Name = "Appointments_Header"
        Me.Appointments_Header.Size = New System.Drawing.Size(115, 51)
        Me.Appointments_Header.TabIndex = 5
        '
        'Menu_Appoinments
        '
        Me.Menu_Appoinments.AutoSize = True
        Me.Menu_Appoinments.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu_Appoinments.ForeColor = System.Drawing.Color.Silver
        Me.Menu_Appoinments.Location = New System.Drawing.Point(4, 17)
        Me.Menu_Appoinments.Name = "Menu_Appoinments"
        Me.Menu_Appoinments.Size = New System.Drawing.Size(109, 16)
        Me.Menu_Appoinments.TabIndex = 4
        Me.Menu_Appoinments.Text = "Appointments"
        '
        'patients_header
        '
        Me.patients_header.Controls.Add(Me.Menu_Patients)
        Me.patients_header.Dock = System.Windows.Forms.DockStyle.Right
        Me.patients_header.Location = New System.Drawing.Point(850, 0)
        Me.patients_header.Name = "patients_header"
        Me.patients_header.Size = New System.Drawing.Size(73, 51)
        Me.patients_header.TabIndex = 6
        '
        'Menu_Patients
        '
        Me.Menu_Patients.AutoSize = True
        Me.Menu_Patients.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu_Patients.ForeColor = System.Drawing.Color.Silver
        Me.Menu_Patients.Location = New System.Drawing.Point(4, 17)
        Me.Menu_Patients.Name = "Menu_Patients"
        Me.Menu_Patients.Size = New System.Drawing.Size(66, 16)
        Me.Menu_Patients.TabIndex = 4
        Me.Menu_Patients.Text = "Patients"
        '
        'doctors_header
        '
        Me.doctors_header.Controls.Add(Me.Menu_Doctors)
        Me.doctors_header.Dock = System.Windows.Forms.DockStyle.Right
        Me.doctors_header.Location = New System.Drawing.Point(923, 0)
        Me.doctors_header.Name = "doctors_header"
        Me.doctors_header.Size = New System.Drawing.Size(72, 51)
        Me.doctors_header.TabIndex = 8
        '
        'Menu_Doctors
        '
        Me.Menu_Doctors.AutoSize = True
        Me.Menu_Doctors.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu_Doctors.ForeColor = System.Drawing.Color.Silver
        Me.Menu_Doctors.Location = New System.Drawing.Point(4, 17)
        Me.Menu_Doctors.Name = "Menu_Doctors"
        Me.Menu_Doctors.Size = New System.Drawing.Size(65, 16)
        Me.Menu_Doctors.TabIndex = 4
        Me.Menu_Doctors.Text = "Doctors"
        '
        'secretaries_header
        '
        Me.secretaries_header.Controls.Add(Me.Menu_Secretaries)
        Me.secretaries_header.Dock = System.Windows.Forms.DockStyle.Right
        Me.secretaries_header.Location = New System.Drawing.Point(995, 0)
        Me.secretaries_header.Name = "secretaries_header"
        Me.secretaries_header.Size = New System.Drawing.Size(96, 51)
        Me.secretaries_header.TabIndex = 7
        '
        'Menu_Secretaries
        '
        Me.Menu_Secretaries.AutoSize = True
        Me.Menu_Secretaries.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Menu_Secretaries.ForeColor = System.Drawing.Color.Silver
        Me.Menu_Secretaries.Location = New System.Drawing.Point(5, 17)
        Me.Menu_Secretaries.Name = "Menu_Secretaries"
        Me.Menu_Secretaries.Size = New System.Drawing.Size(87, 16)
        Me.Menu_Secretaries.TabIndex = 4
        Me.Menu_Secretaries.Text = "Secretaries"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(1091, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(52, 51)
        Me.Panel4.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.ShapeContainer2)
        Me.Panel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel2.Location = New System.Drawing.Point(9, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(40, 42)
        Me.Panel2.TabIndex = 1
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Controls.Add(Me.lbl_notification_counter)
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.Notification_counter_container})
        Me.ShapeContainer2.Size = New System.Drawing.Size(40, 42)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'lbl_notification_counter
        '
        Me.lbl_notification_counter.AutoSize = True
        Me.lbl_notification_counter.BackColor = System.Drawing.Color.Transparent
        Me.lbl_notification_counter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_notification_counter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbl_notification_counter.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbl_notification_counter.Location = New System.Drawing.Point(18, 2)
        Me.lbl_notification_counter.Name = "lbl_notification_counter"
        Me.lbl_notification_counter.Size = New System.Drawing.Size(15, 15)
        Me.lbl_notification_counter.TabIndex = 0
        Me.lbl_notification_counter.Text = "1"
        '
        'Notification_counter_container
        '
        Me.Notification_counter_container.BackColor = System.Drawing.Color.Red
        Me.Notification_counter_container.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.Notification_counter_container.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom
        Me.Notification_counter_container.Location = New System.Drawing.Point(14, 0)
        Me.Notification_counter_container.Name = "Notification_counter_container"
        Me.Notification_counter_container.SelectionColor = System.Drawing.Color.Transparent
        Me.Notification_counter_container.Size = New System.Drawing.Size(22, 21)
        '
        'Panel_Container1
        '
        Me.Panel_Container1.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel_Container1.BackgroundImage = CType(resources.GetObject("Panel_Container1.BackgroundImage"), System.Drawing.Image)
        Me.Panel_Container1.Location = New System.Drawing.Point(1, 52)
        Me.Panel_Container1.Name = "Panel_Container1"
        Me.Panel_Container1.Size = New System.Drawing.Size(1143, 598)
        Me.Panel_Container1.TabIndex = 2
        '
        'Panel_Container2
        '
        Me.Panel_Container2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel_Container2.BackgroundImage = CType(resources.GetObject("Panel_Container2.BackgroundImage"), System.Drawing.Image)
        Me.Panel_Container2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Container2.Location = New System.Drawing.Point(1150, 52)
        Me.Panel_Container2.Name = "Panel_Container2"
        Me.Panel_Container2.Size = New System.Drawing.Size(1143, 598)
        Me.Panel_Container2.TabIndex = 3
        '
        'lbl_user_name
        '
        Me.lbl_user_name.AutoSize = True
        Me.lbl_user_name.Dock = System.Windows.Forms.DockStyle.Right
        Me.lbl_user_name.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_user_name.ForeColor = System.Drawing.Color.White
        Me.lbl_user_name.Location = New System.Drawing.Point(298, 0)
        Me.lbl_user_name.Name = "lbl_user_name"
        Me.lbl_user_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbl_user_name.Size = New System.Drawing.Size(154, 16)
        Me.lbl_user_name.TabIndex = 5
        Me.lbl_user_name.Text = "Dr. Ragesh Valeroso"
        '
        'Panel_Footer
        '
        Me.Panel_Footer.BackColor = System.Drawing.Color.DimGray
        Me.Panel_Footer.Controls.Add(Me.TextBox1)
        Me.Panel_Footer.Controls.Add(Me.Button2)
        Me.Panel_Footer.Controls.Add(Me.Button1)
        Me.Panel_Footer.Controls.Add(Me.chk_transition)
        Me.Panel_Footer.Controls.Add(Me.Panel1)
        Me.Panel_Footer.Controls.Add(Me.Panel3)
        Me.Panel_Footer.Location = New System.Drawing.Point(1, 650)
        Me.Panel_Footer.Name = "Panel_Footer"
        Me.Panel_Footer.Size = New System.Drawing.Size(1144, 41)
        Me.Panel_Footer.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(368, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.Size = New System.Drawing.Size(448, 20)
        Me.TextBox1.TabIndex = 13
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(259, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 23)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Upload Data"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(151, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Download Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chk_transition
        '
        Me.chk_transition.AutoSize = True
        Me.chk_transition.Font = New System.Drawing.Font("Lucida Sans Unicode", 6.0!, System.Drawing.FontStyle.Bold)
        Me.chk_transition.ForeColor = System.Drawing.Color.White
        Me.chk_transition.Location = New System.Drawing.Point(11, 11)
        Me.chk_transition.Name = "chk_transition"
        Me.chk_transition.Size = New System.Drawing.Size(134, 17)
        Me.chk_transition.TabIndex = 7
        Me.chk_transition.Text = "Enable Slide Transition"
        Me.chk_transition.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1097, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(47, 41)
        Me.Panel1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FgffdgToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(3, 3)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(41, 36)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FgffdgToolStripMenuItem
        '
        Me.FgffdgToolStripMenuItem.BackColor = System.Drawing.Color.DimGray
        Me.FgffdgToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.FgffdgToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MyProfileToolStripMenuItem, Me.ts_sign_out})
        Me.FgffdgToolStripMenuItem.Image = CType(resources.GetObject("FgffdgToolStripMenuItem.Image"), System.Drawing.Image)
        Me.FgffdgToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White
        Me.FgffdgToolStripMenuItem.Name = "FgffdgToolStripMenuItem"
        Me.FgffdgToolStripMenuItem.Size = New System.Drawing.Size(28, 32)
        '
        'MyProfileToolStripMenuItem
        '
        Me.MyProfileToolStripMenuItem.BackColor = System.Drawing.Color.DimGray
        Me.MyProfileToolStripMenuItem.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.0!, System.Drawing.FontStyle.Bold)
        Me.MyProfileToolStripMenuItem.Image = CType(resources.GetObject("MyProfileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MyProfileToolStripMenuItem.Name = "MyProfileToolStripMenuItem"
        Me.MyProfileToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.MyProfileToolStripMenuItem.Text = "My Profile"
        '
        'ts_sign_out
        '
        Me.ts_sign_out.BackColor = System.Drawing.Color.DimGray
        Me.ts_sign_out.Font = New System.Drawing.Font("Lucida Sans Unicode", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ts_sign_out.Image = CType(resources.GetObject("ts_sign_out.Image"), System.Drawing.Image)
        Me.ts_sign_out.Name = "ts_sign_out"
        Me.ts_sign_out.Size = New System.Drawing.Size(141, 22)
        Me.ts_sign_out.Text = "Sign Out"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lbl_user_name)
        Me.Panel3.Location = New System.Drawing.Point(645, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(452, 18)
        Me.Panel3.TabIndex = 6
        '
        'Timer_Transition1
        '
        Me.Timer_Transition1.Interval = 10
        '
        'Timer_Transition2
        '
        Me.Timer_Transition2.Interval = 10
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 689)
        Me.Controls.Add(Me.Panel_Container2)
        Me.Controls.Add(Me.Panel_Container1)
        Me.Controls.Add(Me.Panel_Footer)
        Me.Controls.Add(Me.Panel_Header)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form_Main"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "E-Consulta Version 1.0.0"
        Me.Panel_Header.ResumeLayout(False)
        Me.Panel_Header.PerformLayout()
        Me.consultation_header.ResumeLayout(False)
        Me.consultation_header.PerformLayout()
        Me.Appointments_Header.ResumeLayout(False)
        Me.Appointments_Header.PerformLayout()
        Me.patients_header.ResumeLayout(False)
        Me.patients_header.PerformLayout()
        Me.doctors_header.ResumeLayout(False)
        Me.doctors_header.PerformLayout()
        Me.secretaries_header.ResumeLayout(False)
        Me.secretaries_header.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ShapeContainer2.ResumeLayout(False)
        Me.ShapeContainer2.PerformLayout()
        Me.Panel_Footer.ResumeLayout(False)
        Me.Panel_Footer.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel_Header As System.Windows.Forms.Panel
    Friend WithEvents Panel_Container1 As System.Windows.Forms.Panel
    Friend WithEvents Menu_Consultations As System.Windows.Forms.Label
    Friend WithEvents consultation_header As System.Windows.Forms.Panel
    Friend WithEvents patients_header As System.Windows.Forms.Panel
    Friend WithEvents Menu_Patients As System.Windows.Forms.Label
    Friend WithEvents Appointments_Header As System.Windows.Forms.Panel
    Friend WithEvents Menu_Appoinments As System.Windows.Forms.Label
    Friend WithEvents secretaries_header As System.Windows.Forms.Panel
    Friend WithEvents Menu_Secretaries As System.Windows.Forms.Label
    Friend WithEvents doctors_header As System.Windows.Forms.Panel
    Friend WithEvents Menu_Doctors As System.Windows.Forms.Label
    Friend WithEvents Panel_Footer As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FgffdgToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MyProfileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ts_sign_out As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbl_user_name As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Timer_Transition1 As System.Windows.Forms.Timer
    Friend WithEvents Panel_Container2 As System.Windows.Forms.Panel
    Friend WithEvents Timer_Transition2 As System.Windows.Forms.Timer
    Friend WithEvents chk_transition As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents lbl_notification_counter As System.Windows.Forms.Label
    Friend WithEvents Notification_counter_container As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents lbl_notif_context As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
End Class
