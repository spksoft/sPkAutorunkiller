Public Class frmSettings

    'Sub-Routine to load user settings to a form
    Private Sub LoadSettings()
        chkAutoDelete.Checked = My.Settings.AutoDelete
        chkStartup.Checked = My.Settings.AutoStartup
        chkSound.Checked = My.Settings.SoundEnabled
        chkScanFixedDrive.Checked = My.Settings.ScanFixedDrive
        chkScanRemovableDrive.Checked = My.Settings.ScanRemovableDrive
        Select Case My.Settings.RemoveAutorun
            Case True : rtnRemoveAutorun.Checked = True
            Case False : rtnRemoveOnlyExecution.Checked = True
        End Select
    End Sub

    'Sub-Routine to save user settings to a setting class
    Private Sub SaveSettings()
        My.Settings.AutoDelete = chkAutoDelete.Checked
        'Write Startup value if chkStartup was checked
        My.Settings.AutoStartup = chkStartup.Checked
        If chkStartup.Checked = True Then
            RegOp_WriteStartup()
        Else : RegOp_DeleteStartup()
        End If
        My.Settings.SoundEnabled = chkSound.Checked
        My.Settings.ScanFixedDrive = chkScanFixedDrive.Checked
        My.Settings.ScanRemovableDrive = chkScanRemovableDrive.Checked
        Select Case rtnRemoveOnlyExecution.Checked
            Case True : My.Settings.RemoveAutorun = False
            Case False : My.Settings.RemoveAutorun = True
        End Select
        My.Settings.Save()
    End Sub

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "sPkAutorunkiller v." & Version
        LoadSettings()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        SaveSettings()
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub frmSettings_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        FlushMemory()
    End Sub
End Class