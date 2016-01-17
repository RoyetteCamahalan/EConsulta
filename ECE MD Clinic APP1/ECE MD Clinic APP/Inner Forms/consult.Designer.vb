<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class consult
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(consult))
        Me.dtgv_consult = New System.Windows.Forms.DataGridView()
        Me.btn_new_consult = New System.Windows.Forms.Button()
        Me.txt_search = New System.Windows.Forms.TextBox()
        CType(Me.dtgv_consult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgv_consult
        '
        Me.dtgv_consult.AllowUserToAddRows = False
        Me.dtgv_consult.AllowUserToDeleteRows = False
        Me.dtgv_consult.AllowUserToOrderColumns = True
        Me.dtgv_consult.AllowUserToResizeRows = False
        Me.dtgv_consult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Modern No. 20", 12.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgv_consult.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgv_consult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_consult.Location = New System.Drawing.Point(23, 72)
        Me.dtgv_consult.MultiSelect = False
        Me.dtgv_consult.Name = "dtgv_consult"
        Me.dtgv_consult.ReadOnly = True
        Me.dtgv_consult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgv_consult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgv_consult.Size = New System.Drawing.Size(1093, 507)
        Me.dtgv_consult.TabIndex = 7
        '
        'btn_new_consult
        '
        Me.btn_new_consult.BackgroundImage = CType(resources.GetObject("btn_new_consult.BackgroundImage"), System.Drawing.Image)
        Me.btn_new_consult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_new_consult.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_new_consult.FlatAppearance.BorderSize = 0
        Me.btn_new_consult.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btn_new_consult.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btn_new_consult.Location = New System.Drawing.Point(973, 19)
        Me.btn_new_consult.Name = "btn_new_consult"
        Me.btn_new_consult.Size = New System.Drawing.Size(143, 47)
        Me.btn_new_consult.TabIndex = 6
        Me.btn_new_consult.UseVisualStyleBackColor = True
        '
        'txt_search
        '
        Me.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_search.Font = New System.Drawing.Font("Hoefler Text Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_search.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_search.Location = New System.Drawing.Point(23, 46)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_search.Size = New System.Drawing.Size(299, 21)
        Me.txt_search.TabIndex = 5
        Me.txt_search.Text = "Search Anything here"
        '
        'consult
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1138, 597)
        Me.Controls.Add(Me.dtgv_consult)
        Me.Controls.Add(Me.btn_new_consult)
        Me.Controls.Add(Me.txt_search)
        Me.Font = New System.Drawing.Font("Modern No. 20", 12.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "consult"
        Me.Text = "consult"
        CType(Me.dtgv_consult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgv_consult As System.Windows.Forms.DataGridView
    Friend WithEvents btn_new_consult As System.Windows.Forms.Button
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
End Class
