<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Appointments
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Appointments))
        Me.dtgv_Appointments = New System.Windows.Forms.DataGridView()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.btn_new_appoinment = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmn_filter_by = New System.Windows.Forms.ComboBox()
        Me.context_options = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.view_details = New System.Windows.Forms.ToolStripMenuItem()
        Me.Consult_now = New System.Windows.Forms.ToolStripMenuItem()
        Me.edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cancel = New System.Windows.Forms.ToolStripMenuItem()
        Me.unpostpone = New System.Windows.Forms.ToolStripMenuItem()
        Me.edit_result = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dtgv_Appointments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.context_options.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtgv_Appointments
        '
        Me.dtgv_Appointments.AllowUserToAddRows = False
        Me.dtgv_Appointments.AllowUserToDeleteRows = False
        Me.dtgv_Appointments.AllowUserToOrderColumns = True
        Me.dtgv_Appointments.AllowUserToResizeRows = False
        Me.dtgv_Appointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgv_Appointments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dtgv_Appointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_Appointments.Location = New System.Drawing.Point(25, 102)
        Me.dtgv_Appointments.MultiSelect = False
        Me.dtgv_Appointments.Name = "dtgv_Appointments"
        Me.dtgv_Appointments.ReadOnly = True
        Me.dtgv_Appointments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgv_Appointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgv_Appointments.Size = New System.Drawing.Size(1093, 485)
        Me.dtgv_Appointments.TabIndex = 5
        '
        'txt_search
        '
        Me.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.txt_search.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_search.Location = New System.Drawing.Point(25, 76)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_search.Size = New System.Drawing.Size(274, 20)
        Me.txt_search.TabIndex = 4
        '
        'btn_new_appoinment
        '
        Me.btn_new_appoinment.BackgroundImage = CType(resources.GetObject("btn_new_appoinment.BackgroundImage"), System.Drawing.Image)
        Me.btn_new_appoinment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_new_appoinment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_new_appoinment.FlatAppearance.BorderSize = 0
        Me.btn_new_appoinment.Location = New System.Drawing.Point(963, 49)
        Me.btn_new_appoinment.Name = "btn_new_appoinment"
        Me.btn_new_appoinment.Size = New System.Drawing.Size(155, 47)
        Me.btn_new_appoinment.TabIndex = 16
        Me.btn_new_appoinment.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.Label1.Location = New System.Drawing.Point(305, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Filter By:"
        '
        'cmn_filter_by
        '
        Me.cmn_filter_by.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmn_filter_by.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.cmn_filter_by.FormattingEnabled = True
        Me.cmn_filter_by.Items.AddRange(New Object() {"All", "Today", "Done", "Pending", "Poseponed"})
        Me.cmn_filter_by.Location = New System.Drawing.Point(355, 76)
        Me.cmn_filter_by.Name = "cmn_filter_by"
        Me.cmn_filter_by.Size = New System.Drawing.Size(134, 21)
        Me.cmn_filter_by.TabIndex = 18
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
        'Appointments
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1138, 611)
        Me.Controls.Add(Me.cmn_filter_by)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_new_appoinment)
        Me.Controls.Add(Me.dtgv_Appointments)
        Me.Controls.Add(Me.txt_search)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Appointments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Appointments"
        CType(Me.dtgv_Appointments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.context_options.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgv_Appointments As System.Windows.Forms.DataGridView
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents btn_new_appoinment As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmn_filter_by As System.Windows.Forms.ComboBox
    Friend WithEvents context_options As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents view_details As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Consult_now As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cancel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents unpostpone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents edit_result As System.Windows.Forms.ToolStripMenuItem
End Class
