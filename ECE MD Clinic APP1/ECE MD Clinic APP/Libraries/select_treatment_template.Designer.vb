<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class select_treatment_template
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txt_search = New System.Windows.Forms.TextBox()
        Me.lst_templates = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtgv_treatments = New System.Windows.Forms.DataGridView()
        Me.Med_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Medicine_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.No_Generics = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Route = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Frequency = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Refills = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_add = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgv_treatments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txt_search)
        Me.Panel1.Controls.Add(Me.lst_templates)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(139, 297)
        Me.Panel1.TabIndex = 0
        '
        'txt_search
        '
        Me.txt_search.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txt_search.Font = New System.Drawing.Font("Hoefler Text Black", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_search.ForeColor = System.Drawing.SystemColors.GrayText
        Me.txt_search.Location = New System.Drawing.Point(0, 26)
        Me.txt_search.Name = "txt_search"
        Me.txt_search.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt_search.Size = New System.Drawing.Size(139, 21)
        Me.txt_search.TabIndex = 24
        Me.txt_search.Text = "Search here"
        '
        'lst_templates
        '
        Me.lst_templates.FormattingEnabled = True
        Me.lst_templates.Location = New System.Drawing.Point(0, 46)
        Me.lst_templates.Name = "lst_templates"
        Me.lst_templates.Size = New System.Drawing.Size(139, 251)
        Me.lst_templates.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(41, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Templates"
        '
        'dtgv_treatments
        '
        Me.dtgv_treatments.AllowUserToAddRows = False
        Me.dtgv_treatments.AllowUserToDeleteRows = False
        Me.dtgv_treatments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgv_treatments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Med_Id, Me.Medicine_Name, Me.No_Generics, Me.qty, Me.Route, Me.Frequency, Me.Refills, Me.Duration})
        Me.dtgv_treatments.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtgv_treatments.Location = New System.Drawing.Point(142, 25)
        Me.dtgv_treatments.MultiSelect = False
        Me.dtgv_treatments.Name = "dtgv_treatments"
        Me.dtgv_treatments.ReadOnly = True
        Me.dtgv_treatments.RowHeadersVisible = False
        Me.dtgv_treatments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgv_treatments.Size = New System.Drawing.Size(732, 271)
        Me.dtgv_treatments.TabIndex = 28
        '
        'Med_Id
        '
        Me.Med_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Med_Id.HeaderText = "Med_Id"
        Me.Med_Id.Name = "Med_Id"
        Me.Med_Id.ReadOnly = True
        Me.Med_Id.Visible = False
        Me.Med_Id.Width = 5
        '
        'Medicine_Name
        '
        Me.Medicine_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Medicine_Name.HeaderText = "Medicine Name"
        Me.Medicine_Name.Name = "Medicine_Name"
        Me.Medicine_Name.ReadOnly = True
        '
        'No_Generics
        '
        Me.No_Generics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.No_Generics.FalseValue = "0"
        Me.No_Generics.HeaderText = "No Generics"
        Me.No_Generics.Name = "No_Generics"
        Me.No_Generics.ReadOnly = True
        Me.No_Generics.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.No_Generics.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.No_Generics.TrueValue = "1"
        Me.No_Generics.Width = 60
        '
        'qty
        '
        Me.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.qty.DefaultCellStyle = DataGridViewCellStyle3
        Me.qty.HeaderText = "Quantity"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 60
        '
        'Route
        '
        Me.Route.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Route.HeaderText = "Route"
        Me.Route.Name = "Route"
        Me.Route.ReadOnly = True
        Me.Route.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Route.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Frequency
        '
        Me.Frequency.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.Frequency.HeaderText = "Frequency"
        Me.Frequency.Name = "Frequency"
        Me.Frequency.ReadOnly = True
        '
        'Refills
        '
        Me.Refills.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Refills.HeaderText = "Refills"
        Me.Refills.Name = "Refills"
        Me.Refills.ReadOnly = True
        Me.Refills.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Refills.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Refills.Width = 60
        '
        'Duration
        '
        Me.Duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Duration.HeaderText = "Duration"
        Me.Duration.Name = "Duration"
        Me.Duration.ReadOnly = True
        '
        'btn_add
        '
        Me.btn_add.Location = New System.Drawing.Point(793, 268)
        Me.btn_add.Name = "btn_add"
        Me.btn_add.Size = New System.Drawing.Size(81, 28)
        Me.btn_add.TabIndex = 29
        Me.btn_add.Text = "Add"
        Me.btn_add.UseVisualStyleBackColor = True
        '
        'select_treatment_template
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 295)
        Me.Controls.Add(Me.btn_add)
        Me.Controls.Add(Me.dtgv_treatments)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "select_treatment_template"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Select Treatment Template"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgv_treatments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lst_templates As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_search As System.Windows.Forms.TextBox
    Friend WithEvents dtgv_treatments As System.Windows.Forms.DataGridView
    Friend WithEvents Med_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Medicine_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents No_Generics As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Route As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Frequency As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Refills As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btn_add As System.Windows.Forms.Button
End Class
