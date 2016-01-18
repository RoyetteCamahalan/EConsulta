<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Patients
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Patients))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.btn_add_patient = New System.Windows.Forms.Button()
        Me.dtgv_patients = New System.Windows.Forms.DataGridView()
        CType(Me.dtgv_patients, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_search
        '
        Me.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_search.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_search.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_search.Location = New System.Drawing.Point(25, 76)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_search.Size = New System.Drawing.Size(274, 20)
        Me.txt_search.TabIndex = 1
        '
        'btn_add_patient
        '
        Me.btn_add_patient.BackgroundImage = CType(resources.GetObject("btn_add_patient.BackgroundImage"), System.Drawing.Image)
        Me.btn_add_patient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btn_add_patient.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_add_patient.FlatAppearance.BorderSize = 0
        Me.btn_add_patient.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control
        Me.btn_add_patient.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.btn_add_patient.Location = New System.Drawing.Point(975, 49)
        Me.btn_add_patient.Name = "btn_add_patient"
        Me.btn_add_patient.Size = New System.Drawing.Size(143, 47)
        Me.btn_add_patient.TabIndex = 3
        Me.btn_add_patient.UseVisualStyleBackColor = True
        '
        'dtgv_patients
        '
        Me.dtgv_patients.AllowUserToAddRows = False
        Me.dtgv_patients.AllowUserToDeleteRows = False
        Me.dtgv_patients.AllowUserToOrderColumns = True
        Me.dtgv_patients.AllowUserToResizeRows = False
        Me.dtgv_patients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgv_patients.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgv_patients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_patients.Location = New System.Drawing.Point(25, 102)
        Me.dtgv_patients.MultiSelect = False
        Me.dtgv_patients.Name = "dtgv_patients"
        Me.dtgv_patients.ReadOnly = True
        Me.dtgv_patients.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dtgv_patients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgv_patients.Size = New System.Drawing.Size(1093, 485)
        Me.dtgv_patients.TabIndex = 2
        '
        'Patients
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1138, 611)
        Me.Controls.Add(Me.dtgv_patients)
        Me.Controls.Add(Me.btn_add_patient)
        Me.Controls.Add(Me.txt_search)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Patients"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Patients"
        CType(Me.dtgv_patients, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents btn_add_patient As System.Windows.Forms.Button
    Friend WithEvents dtgv_patients As System.Windows.Forms.DataGridView
End Class
