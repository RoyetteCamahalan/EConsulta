<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_prescription
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
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.dtgv_meds = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btn_add_med = New System.Windows.Forms.Button()
        CType(Me.dtgv_meds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_search
        '
        Me.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_search.Font = New System.Drawing.Font("Hoefler Text Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_search.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_search.Location = New System.Drawing.Point(17, 23)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_search.Size = New System.Drawing.Size(297, 21)
        Me.txt_search.TabIndex = 23
        Me.txt_search.Text = "Search Medicine here"
        '
        'dtgv_meds
        '
        Me.dtgv_meds.AllowUserToAddRows = False
        Me.dtgv_meds.AllowUserToDeleteRows = False
        Me.dtgv_meds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtgv_meds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_meds.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column4, Me.Column1})
        Me.dtgv_meds.Location = New System.Drawing.Point(17, 50)
        Me.dtgv_meds.Name = "dtgv_meds"
        Me.dtgv_meds.RowHeadersVisible = False
        Me.dtgv_meds.Size = New System.Drawing.Size(409, 278)
        Me.dtgv_meds.TabIndex = 24
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column3.HeaderText = "id"
        Me.Column3.Name = "Column3"
        Me.Column3.Visible = False
        Me.Column3.Width = 5
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column4.FillWeight = 194.9239!
        Me.Column4.HeaderText = "Medicine Name"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 326
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Column1.FillWeight = 5.076142!
        Me.Column1.HeaderText = "Action"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 80
        '
        'btn_add_med
        '
        Me.btn_add_med.ForeColor = System.Drawing.Color.Black
        Me.btn_add_med.Location = New System.Drawing.Point(320, 21)
        Me.btn_add_med.Name = "btn_add_med"
        Me.btn_add_med.Size = New System.Drawing.Size(106, 23)
        Me.btn_add_med.TabIndex = 25
        Me.btn_add_med.Text = "Save to List"
        Me.btn_add_med.UseVisualStyleBackColor = True
        Me.btn_add_med.Visible = False
        '
        'add_prescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 340)
        Me.Controls.Add(Me.btn_add_med)
        Me.Controls.Add(Me.dtgv_meds)
        Me.Controls.Add(Me.txt_search)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "add_prescription"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Prescription Detail"
        CType(Me.dtgv_meds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents dtgv_meds As System.Windows.Forms.DataGridView
    Friend WithEvents btn_add_med As System.Windows.Forms.Button
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
End Class
