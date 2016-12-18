<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.ctsMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuScanOnMyComputer = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuScanInFlashdrive = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewLogFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGetVersion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ntfMainTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ctsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctsMain
        '
        Me.ctsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuScanOnMyComputer, Me.mnuScanInFlashdrive, Me.mnuSettings, Me.mnuViewLogFile, Me.mnuGetVersion, Me.mnuAbout, Me.mnuExit})
        Me.ctsMain.Name = "ContextMenuStrip1"
        Me.ctsMain.Size = New System.Drawing.Size(192, 158)
        Me.ctsMain.Text = "dsad"
        '
        'mnuScanOnMyComputer
        '
        Me.mnuScanOnMyComputer.Name = "mnuScanOnMyComputer"
        Me.mnuScanOnMyComputer.Size = New System.Drawing.Size(191, 22)
        Me.mnuScanOnMyComputer.Text = "Scan on my &computer"
        '
        'mnuScanInFlashdrive
        '
        Me.mnuScanInFlashdrive.Name = "mnuScanInFlashdrive"
        Me.mnuScanInFlashdrive.Size = New System.Drawing.Size(191, 22)
        Me.mnuScanInFlashdrive.Text = "Scan in &flashdrive"
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(191, 22)
        Me.mnuSettings.Text = "&Settings"
        '
        'mnuViewLogFile
        '
        Me.mnuViewLogFile.Name = "mnuViewLogFile"
        Me.mnuViewLogFile.Size = New System.Drawing.Size(191, 22)
        Me.mnuViewLogFile.Text = "&View log file"
        '
        'mnuGetVersion
        '
        Me.mnuGetVersion.Name = "mnuGetVersion"
        Me.mnuGetVersion.Size = New System.Drawing.Size(191, 22)
        Me.mnuGetVersion.Text = "&Get version"
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(191, 22)
        Me.mnuAbout.Text = "&About and Help"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(191, 22)
        Me.mnuExit.Text = "&Exit"
        '
        'ntfMainTrayIcon
        '
        Me.ntfMainTrayIcon.ContextMenuStrip = Me.ctsMain
        Me.ntfMainTrayIcon.Icon = CType(resources.GetObject("ntfMainTrayIcon.Icon"), System.Drawing.Icon)
        Me.ntfMainTrayIcon.Visible = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(116, 0)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.ctsMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ctsMain As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuScanOnMyComputer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuScanInFlashdrive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuGetVersion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ntfMainTrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents mnuViewLogFile As System.Windows.Forms.ToolStripMenuItem

End Class
