<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report_Viewer
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
        Me.crptViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crptViewer
        '
        Me.crptViewer.ActiveViewIndex = -1
        Me.crptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crptViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.crptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crptViewer.Location = New System.Drawing.Point(0, 0)
        Me.crptViewer.Name = "crptViewer"
        Me.crptViewer.Size = New System.Drawing.Size(1027, 524)
        Me.crptViewer.TabIndex = 0
        Me.crptViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Report_Viewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 524)
        Me.Controls.Add(Me.crptViewer)
        Me.MaximizeBox = False
        Me.Name = "Report_Viewer"
        Me.ShowIcon = False
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
