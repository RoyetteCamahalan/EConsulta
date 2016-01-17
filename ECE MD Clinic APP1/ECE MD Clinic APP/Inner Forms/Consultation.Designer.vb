<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Consultation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Consultation))
        Me.dtgv_allappointment = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.Consult_now = New System.Windows.Forms.ToolStripMenuItem()
        Me.edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.context_options = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.view_details = New System.Windows.Forms.ToolStripMenuItem()
        Me.cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.unpostpone = New System.Windows.Forms.ToolStripMenuItem()
        Me.edit_result = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btn_next = New System.Windows.Forms.Button()
        Me.btn_back = New System.Windows.Forms.Button()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.patient_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.patient_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tran_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doc_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Doctor_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.created_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.updated_at = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.patient_record_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dtgv_allappointment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.context_options.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgv_allappointment
        '
        Me.dtgv_allappointment.AllowUserToAddRows = False
        Me.dtgv_allappointment.AllowUserToDeleteRows = False
        Me.dtgv_allappointment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgv_allappointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_allappointment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.patient_id, Me.patient_name, Me.tran_date, Me.doc_id, Me.Doctor_name, Me.comments, Me.created_at, Me.stat, Me.actions, Me.updated_at, Me.patient_record_id})
        Me.dtgv_allappointment.Location = New System.Drawing.Point(65, 44)
        Me.dtgv_allappointment.MultiSelect = False
        Me.dtgv_allappointment.Name = "dtgv_allappointment"
        Me.dtgv_allappointment.ReadOnly = True
        Me.dtgv_allappointment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgv_allappointment.Size = New System.Drawing.Size(995, 346)
        Me.dtgv_allappointment.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 20
        '
        'txt_search
        '
        Me.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_search.Font = New System.Drawing.Font("Hoefler Text Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_search.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_search.Location = New System.Drawing.Point(65, 17)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_search.Size = New System.Drawing.Size(274, 21)
        Me.txt_search.TabIndex = 3
        Me.txt_search.Text = "Search Patient here"
        '
        'Consult_now
        '
        Me.Consult_now.Name = "Consult_now"
        Me.Consult_now.Size = New System.Drawing.Size(144, 22)
        Me.Consult_now.Text = "Consult Now"
        '
        'edit
        '
        Me.edit.AutoSize = False
        Me.edit.Name = "edit"
        Me.edit.Size = New System.Drawing.Size(152, 22)
        Me.edit.Text = "Edit"
        '
        'context_options
        '
        Me.context_options.BackColor = System.Drawing.Color.LightBlue
        Me.context_options.DropShadowEnabled = False
        Me.context_options.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.context_options.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.view_details, Me.Consult_now, Me.edit, Me.cancel, Me.unpostpone, Me.edit_result})
        Me.context_options.Name = "ContextMenuStrip1"
        Me.context_options.Size = New System.Drawing.Size(145, 136)
        '
        'view_details
        '
        Me.view_details.Name = "view_details"
        Me.view_details.Size = New System.Drawing.Size(144, 22)
        Me.view_details.Text = "View Details"
        '
        'cancel
        '
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(144, 22)
        Me.cancel.Text = "Postpone"
        '
        'unpostpone
        '
        Me.unpostpone.Name = "unpostpone"
        Me.unpostpone.Size = New System.Drawing.Size(144, 22)
        Me.unpostpone.Text = "Unpostpone"
        '
        'edit_result
        '
        Me.edit_result.Name = "edit_result"
        Me.edit_result.Size = New System.Drawing.Size(144, 22)
        Me.edit_result.Text = "Edit Result"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ToolStripMenuItem1.Text = "Activate"
        '
        'btn_next
        '
        Me.btn_next.BackgroundImage = CType(resources.GetObject("btn_next.BackgroundImage"), System.Drawing.Image)
        Me.btn_next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_next.Location = New System.Drawing.Point(958, 396)
        Me.btn_next.Name = "btn_next"
        Me.btn_next.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_next.Size = New System.Drawing.Size(102, 44)
        Me.btn_next.TabIndex = 4
        Me.btn_next.UseVisualStyleBackColor = True
        '
        'btn_back
        '
        Me.btn_back.BackgroundImage = CType(resources.GetObject("btn_back.BackgroundImage"), System.Drawing.Image)
        Me.btn_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_back.Location = New System.Drawing.Point(65, 396)
        Me.btn_back.Name = "btn_back"
        Me.btn_back.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btn_back.Size = New System.Drawing.Size(102, 44)
        Me.btn_back.TabIndex = 5
        Me.btn_back.UseVisualStyleBackColor = True
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Visible = False
        '
        'patient_id
        '
        Me.patient_id.HeaderText = "patient_id"
        Me.patient_id.Name = "patient_id"
        Me.patient_id.ReadOnly = True
        Me.patient_id.Visible = False
        '
        'patient_name
        '
        Me.patient_name.HeaderText = "Patient Name"
        Me.patient_name.Name = "patient_name"
        Me.patient_name.ReadOnly = True
        '
        'tran_date
        '
        Me.tran_date.HeaderText = "Date"
        Me.tran_date.Name = "tran_date"
        Me.tran_date.ReadOnly = True
        '
        'doc_id
        '
        Me.doc_id.HeaderText = "Doc_id"
        Me.doc_id.Name = "doc_id"
        Me.doc_id.ReadOnly = True
        Me.doc_id.Visible = False
        '
        'Doctor_name
        '
        Me.Doctor_name.HeaderText = "Doctor Name"
        Me.Doctor_name.Name = "Doctor_name"
        Me.Doctor_name.ReadOnly = True
        '
        'comments
        '
        Me.comments.HeaderText = "Comment/s"
        Me.comments.Name = "comments"
        Me.comments.ReadOnly = True
        Me.comments.Visible = False
        '
        'created_at
        '
        Me.created_at.HeaderText = "Encoded Date"
        Me.created_at.Name = "created_at"
        Me.created_at.ReadOnly = True
        '
        'stat
        '
        Me.stat.HeaderText = "Status"
        Me.stat.Name = "stat"
        Me.stat.ReadOnly = True
        '
        'actions
        '
        Me.actions.HeaderText = "Actions"
        Me.actions.Name = "actions"
        Me.actions.ReadOnly = True
        '
        'updated_at
        '
        Me.updated_at.HeaderText = "updated_at"
        Me.updated_at.Name = "updated_at"
        Me.updated_at.ReadOnly = True
        Me.updated_at.Visible = False
        '
        'patient_record_id
        '
        Me.patient_record_id.HeaderText = "patient_record_id"
        Me.patient_record_id.Name = "patient_record_id"
        Me.patient_record_id.ReadOnly = True
        Me.patient_record_id.Visible = False
        '
        'Consultation
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1121, 471)
        Me.Controls.Add(Me.btn_back)
        Me.Controls.Add(Me.btn_next)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.dtgv_allappointment)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Consultation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Consultation"
        CType(Me.dtgv_allappointment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.context_options.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgv_allappointment As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents Consult_now As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents context_options As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents unpostpone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents view_details As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents edit_result As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_next As System.Windows.Forms.Button
    Friend WithEvents btn_back As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patient_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patient_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tran_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doc_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Doctor_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comments As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents created_at As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents actions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents updated_at As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents patient_record_id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
