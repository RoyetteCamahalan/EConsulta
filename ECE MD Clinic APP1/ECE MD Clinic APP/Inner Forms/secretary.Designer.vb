<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class secretary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(secretary))
        Me.dtgv_secretaries = New System.Windows.Forms.DataGridView()
        Me.btn_new_secretary = New System.Windows.Forms.Button()
        Me.txt_search = New System.Windows.Forms.TextBox()
        CType(Me.dtgv_secretaries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgv_secretaries
        '
        Me.dtgv_secretaries.AllowUserToAddRows = False
        Me.dtgv_secretaries.AllowUserToDeleteRows = False
        Me.dtgv_secretaries.AllowUserToOrderColumns = True
        Me.dtgv_secretaries.AllowUserToResizeRows = False
        Me.dtgv_secretaries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgv_secretaries.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgv_secretaries.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgv_secretaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_secretaries.Location = New System.Drawing.Point(22, 102)
        Me.dtgv_secretaries.MultiSelect = False
        Me.dtgv_secretaries.Name = "dtgv_secretaries"
        Me.dtgv_secretaries.ReadOnly = True
        Me.dtgv_secretaries.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgv_secretaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgv_secretaries.Size = New System.Drawing.Size(1093, 485)
        Me.dtgv_secretaries.TabIndex = 7
        '
        'btn_new_secretary
        '
        Me.btn_new_secretary.BackgroundImage = CType(resources.GetObject("btn_new_secretary.BackgroundImage"), System.Drawing.Image)
        Me.btn_new_secretary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_new_secretary.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_new_secretary.FlatAppearance.BorderSize = 0
        Me.btn_new_secretary.Location = New System.Drawing.Point(974, 49)
        Me.btn_new_secretary.Name = "btn_new_secretary"
        Me.btn_new_secretary.Size = New System.Drawing.Size(143, 47)
        Me.btn_new_secretary.TabIndex = 6
        Me.btn_new_secretary.UseVisualStyleBackColor = True
        '
        'txt_search
        '
        Me.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.txt_search.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_search.Location = New System.Drawing.Point(22, 76)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_search.Size = New System.Drawing.Size(274, 20)
        Me.txt_search.TabIndex = 5
        '
        'secretary
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1138, 611)
        Me.Controls.Add(Me.dtgv_secretaries)
        Me.Controls.Add(Me.btn_new_secretary)
        Me.Controls.Add(Me.txt_search)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "secretary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "secretary"
        CType(Me.dtgv_secretaries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgv_secretaries As System.Windows.Forms.DataGridView
    Friend WithEvents btn_new_secretary As System.Windows.Forms.Button
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
End Class
