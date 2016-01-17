<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main_menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main_menu))
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.consultation_panel = New System.Windows.Forms.Panel()
        Me.lbl_consultation = New System.Windows.Forms.Label()
        Me.lbl_today = New System.Windows.Forms.Label()
        Me.lbl_incoming = New System.Windows.Forms.Label()
        Me.btn_new_appoinment = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.incoming_bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.today_bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.consultation_bar = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TimerSync = New System.Windows.Forms.Timer(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.toolstrip_log_out = New System.Windows.Forms.ToolStripButton()
        Me.toolstrip_myprofile = New System.Windows.Forms.ToolStripButton()
        Me.toolstrip_notifs = New System.Windows.Forms.ToolStripButton()
        Me.notification_label = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.timer_isdone = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabPage2
        '
        Me.TabPage2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1138, 597)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "       PATIENTS (F3)        "
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Font = New System.Drawing.Font("Hoefler Text Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.ItemSize = New System.Drawing.Size(190, 30)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 55)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1146, 635)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 34)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1138, 597)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = " CONSULTATION (F1)"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.consultation_panel)
        Me.TabPage4.Controls.Add(Me.lbl_consultation)
        Me.TabPage4.Controls.Add(Me.lbl_today)
        Me.TabPage4.Controls.Add(Me.lbl_incoming)
        Me.TabPage4.Controls.Add(Me.btn_new_appoinment)
        Me.TabPage4.Controls.Add(Me.ShapeContainer1)
        Me.TabPage4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage4.Location = New System.Drawing.Point(4, 34)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1138, 597)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "APPOINTMENTS (F2)"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'consultation_panel
        '
        Me.consultation_panel.Font = New System.Drawing.Font("Modern No. 20", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consultation_panel.Location = New System.Drawing.Point(9, 126)
        Me.consultation_panel.Name = "consultation_panel"
        Me.consultation_panel.Size = New System.Drawing.Size(1121, 471)
        Me.consultation_panel.TabIndex = 19
        '
        'lbl_consultation
        '
        Me.lbl_consultation.AutoSize = True
        Me.lbl_consultation.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_consultation.Font = New System.Drawing.Font("News701 BT", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_consultation.ForeColor = System.Drawing.Color.Blue
        Me.lbl_consultation.Location = New System.Drawing.Point(167, 65)
        Me.lbl_consultation.Name = "lbl_consultation"
        Me.lbl_consultation.Size = New System.Drawing.Size(54, 32)
        Me.lbl_consultation.TabIndex = 18
        Me.lbl_consultation.Text = "All"
        '
        'lbl_today
        '
        Me.lbl_today.AutoSize = True
        Me.lbl_today.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_today.Font = New System.Drawing.Font("News701 BT", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_today.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_today.Location = New System.Drawing.Point(488, 65)
        Me.lbl_today.Name = "lbl_today"
        Me.lbl_today.Size = New System.Drawing.Size(125, 32)
        Me.lbl_today.TabIndex = 17
        Me.lbl_today.Text = "TODAY"
        '
        'lbl_incoming
        '
        Me.lbl_incoming.AutoSize = True
        Me.lbl_incoming.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lbl_incoming.Font = New System.Drawing.Font("News701 BT", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_incoming.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.lbl_incoming.Location = New System.Drawing.Point(839, 65)
        Me.lbl_incoming.Name = "lbl_incoming"
        Me.lbl_incoming.Size = New System.Drawing.Size(182, 32)
        Me.lbl_incoming.TabIndex = 16
        Me.lbl_incoming.Text = "INCOMING"
        '
        'btn_new_appoinment
        '
        Me.btn_new_appoinment.BackgroundImage = CType(resources.GetObject("btn_new_appoinment.BackgroundImage"), System.Drawing.Image)
        Me.btn_new_appoinment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_new_appoinment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_new_appoinment.FlatAppearance.BorderSize = 0
        Me.btn_new_appoinment.Location = New System.Drawing.Point(959, 18)
        Me.btn_new_appoinment.Name = "btn_new_appoinment"
        Me.btn_new_appoinment.Size = New System.Drawing.Size(155, 47)
        Me.btn_new_appoinment.TabIndex = 15
        Me.btn_new_appoinment.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 3)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.incoming_bar, Me.today_bar, Me.consultation_bar})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1132, 591)
        Me.ShapeContainer1.TabIndex = 20
        Me.ShapeContainer1.TabStop = False
        '
        'incoming_bar
        '
        Me.incoming_bar.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.incoming_bar.Enabled = False
        Me.incoming_bar.FillColor = System.Drawing.Color.LightGray
        Me.incoming_bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.incoming_bar.Location = New System.Drawing.Point(757, 95)
        Me.incoming_bar.Name = "incoming_bar"
        Me.incoming_bar.Size = New System.Drawing.Size(379, 16)
        '
        'today_bar
        '
        Me.today_bar.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.today_bar.Enabled = False
        Me.today_bar.FillColor = System.Drawing.Color.LightGray
        Me.today_bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.today_bar.Location = New System.Drawing.Point(377, 95)
        Me.today_bar.Name = "today_bar"
        Me.today_bar.Size = New System.Drawing.Size(379, 16)
        '
        'consultation_bar
        '
        Me.consultation_bar.BackColor = System.Drawing.Color.Cyan
        Me.consultation_bar.BorderColor = System.Drawing.SystemColors.ButtonFace
        Me.consultation_bar.Enabled = False
        Me.consultation_bar.FillColor = System.Drawing.Color.Cyan
        Me.consultation_bar.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.consultation_bar.Location = New System.Drawing.Point(-3, 95)
        Me.consultation_bar.Name = "consultation_bar"
        Me.consultation_bar.Size = New System.Drawing.Size(379, 16)
        '
        'TabPage6
        '
        Me.TabPage6.Location = New System.Drawing.Point(4, 34)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1138, 597)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "    DOCTORS (F4)   "
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Location = New System.Drawing.Point(4, 34)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1138, 597)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "    SECRETARY (F4)    "
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'TabPage7
        '
        Me.TabPage7.Location = New System.Drawing.Point(4, 34)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Size = New System.Drawing.Size(1138, 597)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "LIBRARIES (F5)"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Today's Birthday"
        Me.NotifyIcon1.Visible = True
        '
        'TimerSync
        '
        Me.TimerSync.Interval = 1000
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolstrip_log_out, Me.toolstrip_myprofile, Me.toolstrip_notifs})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1145, 52)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'toolstrip_log_out
        '
        Me.toolstrip_log_out.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.toolstrip_log_out.Image = CType(resources.GetObject("toolstrip_log_out.Image"), System.Drawing.Image)
        Me.toolstrip_log_out.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolstrip_log_out.Name = "toolstrip_log_out"
        Me.toolstrip_log_out.Size = New System.Drawing.Size(54, 49)
        Me.toolstrip_log_out.Text = "Log Out"
        Me.toolstrip_log_out.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolstrip_myprofile
        '
        Me.toolstrip_myprofile.Image = CType(resources.GetObject("toolstrip_myprofile.Image"), System.Drawing.Image)
        Me.toolstrip_myprofile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolstrip_myprofile.Name = "toolstrip_myprofile"
        Me.toolstrip_myprofile.Size = New System.Drawing.Size(65, 49)
        Me.toolstrip_myprofile.Text = "My Profile"
        Me.toolstrip_myprofile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'toolstrip_notifs
        '
        Me.toolstrip_notifs.Image = CType(resources.GetObject("toolstrip_notifs.Image"), System.Drawing.Image)
        Me.toolstrip_notifs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolstrip_notifs.Name = "toolstrip_notifs"
        Me.toolstrip_notifs.Size = New System.Drawing.Size(74, 49)
        Me.toolstrip_notifs.Text = "Notification"
        Me.toolstrip_notifs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'notification_label
        '
        Me.notification_label.AutoEllipsis = True
        Me.notification_label.AutoSize = True
        Me.notification_label.BackColor = System.Drawing.SystemColors.Window
        Me.notification_label.Font = New System.Drawing.Font("Rockwell", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.notification_label.ForeColor = System.Drawing.Color.Red
        Me.notification_label.Location = New System.Drawing.Point(984, 6)
        Me.notification_label.Name = "notification_label"
        Me.notification_label.Size = New System.Drawing.Size(0, 15)
        Me.notification_label.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(-1, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Download Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(107, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Upload Data"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(216, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBox1.Size = New System.Drawing.Size(448, 20)
        Me.TextBox1.TabIndex = 10
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 31)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Syncing"
        Me.Label1.Visible = False
        '
        'timer_isdone
        '
        '
        'main_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 689)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.notification_label)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.Name = "main_menu"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents consultation_panel As System.Windows.Forms.Panel
    Friend WithEvents lbl_consultation As System.Windows.Forms.Label
    Friend WithEvents lbl_today As System.Windows.Forms.Label
    Friend WithEvents lbl_incoming As System.Windows.Forms.Label
    Friend WithEvents btn_new_appoinment As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents incoming_bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents today_bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents consultation_bar As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents TimerSync As System.Windows.Forms.Timer
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents toolstrip_log_out As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstrip_myprofile As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstrip_notifs As System.Windows.Forms.ToolStripButton
    Friend WithEvents notification_label As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents timer_isdone As System.Windows.Forms.Timer
End Class
