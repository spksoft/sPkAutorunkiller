<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.chkAutoDelete = New System.Windows.Forms.CheckBox()
        Me.chkStartup = New System.Windows.Forms.CheckBox()
        Me.chkSound = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkScanRemovableDrive = New System.Windows.Forms.CheckBox()
        Me.chkScanFixedDrive = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rtnRemoveAutorun = New System.Windows.Forms.RadioButton()
        Me.rtnRemoveOnlyExecution = New System.Windows.Forms.RadioButton()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkAutoDelete
        '
        Me.chkAutoDelete.AutoSize = True
        Me.chkAutoDelete.Location = New System.Drawing.Point(12, 12)
        Me.chkAutoDelete.Name = "chkAutoDelete"
        Me.chkAutoDelete.Size = New System.Drawing.Size(141, 17)
        Me.chkAutoDelete.TabIndex = 0
        Me.chkAutoDelete.Text = "Automatically delete files"
        Me.chkAutoDelete.UseVisualStyleBackColor = True
        '
        'chkStartup
        '
        Me.chkStartup.AutoSize = True
        Me.chkStartup.Location = New System.Drawing.Point(12, 35)
        Me.chkStartup.Name = "chkStartup"
        Me.chkStartup.Size = New System.Drawing.Size(159, 17)
        Me.chkStartup.TabIndex = 1
        Me.chkStartup.Text = "Launch on Windows startup"
        Me.chkStartup.UseVisualStyleBackColor = True
        '
        'chkSound
        '
        Me.chkSound.AutoSize = True
        Me.chkSound.Location = New System.Drawing.Point(12, 58)
        Me.chkSound.Name = "chkSound"
        Me.chkSound.Size = New System.Drawing.Size(91, 17)
        Me.chkSound.TabIndex = 2
        Me.chkSound.Text = "Enable sound"
        Me.chkSound.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkScanRemovableDrive)
        Me.GroupBox1.Controls.Add(Me.chkScanFixedDrive)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(426, 48)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Drive to scan when flashdrive plugged in"
        '
        'chkScanRemovableDrive
        '
        Me.chkScanRemovableDrive.AutoSize = True
        Me.chkScanRemovableDrive.Location = New System.Drawing.Point(91, 19)
        Me.chkScanRemovableDrive.Name = "chkScanRemovableDrive"
        Me.chkScanRemovableDrive.Size = New System.Drawing.Size(108, 17)
        Me.chkScanRemovableDrive.TabIndex = 4
        Me.chkScanRemovableDrive.Text = "Removable Drive"
        Me.chkScanRemovableDrive.UseVisualStyleBackColor = True
        '
        'chkScanFixedDrive
        '
        Me.chkScanFixedDrive.AutoSize = True
        Me.chkScanFixedDrive.Location = New System.Drawing.Point(6, 19)
        Me.chkScanFixedDrive.Name = "chkScanFixedDrive"
        Me.chkScanFixedDrive.Size = New System.Drawing.Size(79, 17)
        Me.chkScanFixedDrive.TabIndex = 5
        Me.chkScanFixedDrive.Text = "Fixed Drive"
        Me.chkScanFixedDrive.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.rtnRemoveAutorun)
        Me.GroupBox2.Controls.Add(Me.rtnRemoveOnlyExecution)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 135)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(426, 72)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Action when program detects Autorun.inf file"
        '
        'rtnRemoveAutorun
        '
        Me.rtnRemoveAutorun.AutoSize = True
        Me.rtnRemoveAutorun.Location = New System.Drawing.Point(6, 42)
        Me.rtnRemoveAutorun.Name = "rtnRemoveAutorun"
        Me.rtnRemoveAutorun.Size = New System.Drawing.Size(119, 17)
        Me.rtnRemoveAutorun.TabIndex = 1
        Me.rtnRemoveAutorun.TabStop = True
        Me.rtnRemoveAutorun.Text = "Remove Autorun.inf"
        Me.rtnRemoveAutorun.UseVisualStyleBackColor = True
        '
        'rtnRemoveOnlyExecution
        '
        Me.rtnRemoveOnlyExecution.AutoSize = True
        Me.rtnRemoveOnlyExecution.Location = New System.Drawing.Point(6, 19)
        Me.rtnRemoveOnlyExecution.Name = "rtnRemoveOnlyExecution"
        Me.rtnRemoveOnlyExecution.Size = New System.Drawing.Size(418, 17)
        Me.rtnRemoveOnlyExecution.TabIndex = 0
        Me.rtnRemoveOnlyExecution.TabStop = True
        Me.rtnRemoveOnlyExecution.Text = "Remove only execution command. Drive icon (*.ico, *.bmp) and drive label still th" & _
            "ere"
        Me.rtnRemoveOnlyExecution.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New System.Drawing.Point(284, 218)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 5
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(363, 218)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 247)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.chkSound)
        Me.Controls.Add(Me.chkStartup)
        Me.Controls.Add(Me.chkAutoDelete)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkAutoDelete As System.Windows.Forms.CheckBox
    Friend WithEvents chkStartup As System.Windows.Forms.CheckBox
    Friend WithEvents chkSound As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkScanFixedDrive As System.Windows.Forms.CheckBox
    Friend WithEvents chkScanRemovableDrive As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rtnRemoveAutorun As System.Windows.Forms.RadioButton
    Friend WithEvents rtnRemoveOnlyExecution As System.Windows.Forms.RadioButton
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
