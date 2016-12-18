<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogFileViewer
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
            GC.RemoveMemoryPressure(Int32.MaxValue)
            GC.SuppressFinalize(Me)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogFileViewer))
        Me.lsvLogDetail = New System.Windows.Forms.ListView()
        Me.Time = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Action = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Result = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.File = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.msMainMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLoadAllLogfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpenLogFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvLogDetail
        '
        Me.lsvLogDetail.AutoArrange = False
        Me.lsvLogDetail.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Time, Me.Action, Me.Result, Me.File})
        Me.lsvLogDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lsvLogDetail.FullRowSelect = True
        Me.lsvLogDetail.GridLines = True
        Me.lsvLogDetail.Location = New System.Drawing.Point(0, 24)
        Me.lsvLogDetail.MultiSelect = False
        Me.lsvLogDetail.Name = "lsvLogDetail"
        Me.lsvLogDetail.Size = New System.Drawing.Size(590, 301)
        Me.lsvLogDetail.TabIndex = 0
        Me.lsvLogDetail.UseCompatibleStateImageBehavior = False
        Me.lsvLogDetail.View = System.Windows.Forms.View.Details
        '
        'Time
        '
        Me.Time.Text = "Time"
        Me.Time.Width = 135
        '
        'Action
        '
        Me.Action.Text = "Action"
        Me.Action.Width = 90
        '
        'Result
        '
        Me.Result.Text = "Result"
        Me.Result.Width = 56
        '
        'File
        '
        Me.File.Text = "File"
        Me.File.Width = 304
        '
        'msMainMenu
        '
        Me.msMainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.msMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMainMenu.Name = "msMainMenu"
        Me.msMainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.msMainMenu.Size = New System.Drawing.Size(590, 24)
        Me.msMainMenu.TabIndex = 1
        Me.msMainMenu.Text = "Menu bar"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLoadAllLogfile, Me.mnuOpenLogFile, Me.mnuClose})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'mnuLoadAllLogfile
        '
        Me.mnuLoadAllLogfile.Name = "mnuLoadAllLogfile"
        Me.mnuLoadAllLogfile.Size = New System.Drawing.Size(154, 22)
        Me.mnuLoadAllLogfile.Text = "&Load all log file"
        '
        'mnuOpenLogFile
        '
        Me.mnuOpenLogFile.Name = "mnuOpenLogFile"
        Me.mnuOpenLogFile.Size = New System.Drawing.Size(154, 22)
        Me.mnuOpenLogFile.Text = "&Open Log File"
        '
        'mnuClose
        '
        Me.mnuClose.Name = "mnuClose"
        Me.mnuClose.Size = New System.Drawing.Size(154, 22)
        Me.mnuClose.Text = "&Close"
        '
        'frmLogFileViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 325)
        Me.Controls.Add(Me.lsvLogDetail)
        Me.Controls.Add(Me.msMainMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.msMainMenu
        Me.Name = "frmLogFileViewer"
        Me.Text = "Log Viewer"
        Me.msMainMenu.ResumeLayout(False)
        Me.msMainMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lsvLogDetail As System.Windows.Forms.ListView
    Friend WithEvents Time As System.Windows.Forms.ColumnHeader
    Friend WithEvents Action As System.Windows.Forms.ColumnHeader
    Friend WithEvents File As System.Windows.Forms.ColumnHeader
    Friend WithEvents EventDetail As System.Windows.Forms.ColumnHeader
    Friend WithEvents Result As System.Windows.Forms.ColumnHeader
    Friend WithEvents msMainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuOpenLogFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLoadAllLogfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuClose As System.Windows.Forms.ToolStripMenuItem
End Class
