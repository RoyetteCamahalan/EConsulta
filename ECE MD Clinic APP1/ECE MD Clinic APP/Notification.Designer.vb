<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Notification
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtgcv_notifs = New System.Windows.Forms.DataGridView()
        Me.server_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clinic_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.patient_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.date_appoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgcv_notifs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgcv_notifs
        '
        Me.dtgcv_notifs.AllowUserToAddRows = False
        Me.dtgcv_notifs.AllowUserToDeleteRows = False
        Me.dtgcv_notifs.AllowUserToOrderColumns = True
        Me.dtgcv_notifs.AllowUserToResizeRows = False
        Me.dtgcv_notifs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgcv_notifs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.server_id, Me.clinic_name, Me.doctor, Me.patient_name, Me.date_appoint, Me.Time, Me.Comment, Me.Column2, Me.Column1, Me.status})
        Me.dtgcv_notifs.Location = New System.Drawing.Point(12, 56)
        Me.dtgcv_notifs.Name = "dtgcv_notifs"
        Me.dtgcv_notifs.ReadOnly = True
        Me.dtgcv_notifs.RowHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dtgcv_notifs.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgcv_notifs.RowTemplate.Height = 30
        Me.dtgcv_notifs.Size = New System.Drawing.Size(1043, 433)
        Me.dtgcv_notifs.TabIndex = 0
        '
        'server_id
        '
        Me.server_id.HeaderText = "Column1"
        Me.server_id.Name = "server_id"
        Me.server_id.ReadOnly = True
        Me.server_id.Visible = False
        '
        'clinic_name
        '
        Me.clinic_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.clinic_name.HeaderText = "Clinic"
        Me.clinic_name.Name = "clinic_name"
        Me.clinic_name.ReadOnly = True
        Me.clinic_name.Width = 130
        '
        'doctor
        '
        Me.doctor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.doctor.HeaderText = "Doctor"
        Me.doctor.Name = "doctor"
        Me.doctor.ReadOnly = True
        Me.doctor.Width = 130
        '
        'patient_name
        '
        Me.patient_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.patient_name.HeaderText = "Patient"
        Me.patient_name.Name = "patient_name"
        Me.patient_name.ReadOnly = True
        Me.patient_name.Width = 130
        '
        'date_appoint
        '
        Me.date_appoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.date_appoint.HeaderText = "Date"
        Me.date_appoint.Name = "date_appoint"
        Me.date_appoint.ReadOnly = True
        Me.date_appoint.Width = 80
        '
        'Time
        '
        Me.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Time.HeaderText = "Time"
        Me.Time.Name = "Time"
        Me.Time.ReadOnly = True
        Me.Time.Width = 80
        '
        'Comment
        '
        Me.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Comment.HeaderText = "Clinic's Comment"
        Me.Comment.Name = "Comment"
        Me.Comment.ReadOnly = True
        Me.Comment.Width = 150
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column2.HeaderText = "Patient's Comment"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.HeaderText = "Patient's Acceptance"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'status
        '
        Me.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.status.HeaderText = "Status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.status.Width = 110
        '
        'Notification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 501)
        Me.Controls.Add(Me.dtgcv_notifs)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Notification"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notification"
        CType(Me.dtgcv_notifs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtgcv_notifs As System.Windows.Forms.DataGridView
    Friend WithEvents server_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clinic_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patient_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents date_appoint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Comment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
