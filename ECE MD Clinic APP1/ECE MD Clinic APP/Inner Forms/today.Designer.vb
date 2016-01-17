<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class today
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
        Me.dtgv_today = New System.Windows.Forms.DataGridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.context_options = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.view_details = New System.Windows.Forms.ToolStripMenuItem()
        Me.Consult_now = New System.Windows.Forms.ToolStripMenuItem()
        Me.edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.unpostpone = New System.Windows.Forms.ToolStripMenuItem()
        Me.edit_result = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtgv_today, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.context_options.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgv_today
        '
        Me.dtgv_today.AllowUserToAddRows = False
        Me.dtgv_today.AllowUserToDeleteRows = False
        Me.dtgv_today.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtgv_today.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgv_today.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_today.Location = New System.Drawing.Point(65, 44)
        Me.dtgv_today.Name = "dtgv_today"
        Me.dtgv_today.ReadOnly = True
        Me.dtgv_today.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgv_today.Size = New System.Drawing.Size(995, 365)
        Me.dtgv_today.TabIndex = 0
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
        'today
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1121, 471)
        Me.Controls.Add(Me.txt_search)
        Me.Controls.Add(Me.dtgv_today)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "today"
        Me.Text = "today"
        CType(Me.dtgv_today, System.ComponentModel.ISupportInitialize).EndInit()
        Me.context_options.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgv_today As System.Windows.Forms.DataGridView
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents context_options As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents view_details As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Consult_now As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents unpostpone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents edit_result As System.Windows.Forms.ToolStripMenuItem
End Class
