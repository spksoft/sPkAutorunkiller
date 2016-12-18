Imports System.IO
Public Class frmMain

    'Class scope declarations
    'WM_DEVICECHANGE            : Windows message constant to notifies a change to the hardware configuration of a device or the computer
    'DBT_DEVICEARRIVAL          : Windows message parameter constant when the type of device arriving is a volume
    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000

    'WndProc Sub-Routine overrides for detect hardware changes
    Protected Overrides Sub WndProc(ByRef m As Message)
        'Method's Scope Declaration
        'Message    : receive message from ScanDrive method
        Dim Message As String = ""
        If m.Msg = WM_DEVICECHANGE Then
            If m.WParam.ToInt32() = DBT_DEVICEARRIVAL Then
                BalloonTipTextShow("Scanning in progress")
                If My.Settings.ScanRemovableDrive = True Then
                    Message += ScanDrive(DriveType.Removable)
                End If
                If My.Settings.ScanFixedDrive = True Then
                    Message += ScanDrive(DriveType.Fixed)
                End If
                If Message.Length >= 255 Then
                    Message = Mid(Message, 1, 224) & vbNewLine & "View more in view log menu..."
                End If
                BalloonTipTextShow("Scan Completed" & vbCrLf, Message)
            End If
        End If
        MyBase.WndProc(m)
        FlushMemory()
    End Sub

#Region "Drive scan and BalloonTooltip interaction methods"

    Private Function ScanDrive(ByVal DriveType As DriveType) As String

        Dim temp = "", CurrentDriveType = "", Message As String = "", IsDrivesAttached As Boolean = False
        Select Case DriveType
            Case DriveType.Fixed : CurrentDriveType = "Hard"
            Case DriveType.Removable : CurrentDriveType = "Flash"
            Case Else : CurrentDriveType = DriveType.ToString()
        End Select
        Dim AllDrives() As DriveInfo = DriveInfo.GetDrives
        For Each Drive In AllDrives
            If Drive.IsReady And Drive.DriveType = DriveType Then
                temp = DeleteLnkFile(Drive.Name.ToString)
                If (temp <> vbCrLf Or temp <> "") Then _
                    Message += temp
                temp = DeleteAutorunFile(Drive.Name.ToString)
                If (temp <> vbCrLf Or temp <> "") Then _
                    Message += temp
                IsDrivesAttached = True
            End If
        Next
        If IsDrivesAttached Then
            Message = CurrentDriveType & "drive Scan Completed" & vbCrLf & Message
        Else
            Message = "No " & CurrentDriveType & "drive attached" & vbCrLf
        End If
        Return Message
        FlushMemory()
    End Function

    Private Sub BalloonTipTextShow(ByVal Text As String, Optional ByVal Message As String = "")
        ntfMainTrayIcon.BalloonTipTitle = "sPkAutorunKiller " & Version
        ntfMainTrayIcon.BalloonTipText = Text & Message
        ntfMainTrayIcon.BalloonTipIcon = ToolTipIcon.Info
        ntfMainTrayIcon.ShowBalloonTip(1)
    End Sub

#End Region

#Region "frmMain Events"

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ntfMainTrayIcon.Text = "sPkAutorunkiller v." & Version
        'Create "Report" directory if the directory doesn't exist
        If Directory.Exists(My.Application.Info.DirectoryPath.ToString & "\Report") = False Then
            Directory.CreateDirectory(My.Application.Info.DirectoryPath.ToString & "\Report")
        End If

        'Check if program has already run 
        Dim sameProcessTotal As Integer = Process.GetProcessesByName(Process.GetCurrentProcess.ProcessName).Length
        If sameProcessTotal > 1 Then
            MessageBox.Show(My.Application.Info.AssemblyName & " has already run", _
                            My.Application.Info.AssemblyName, MessageBoxButtons.OK, _
                            MessageBoxIcon.Asterisk) : End
        End If

        'Write Startup value to registry if Settings.AutoStart = true
        If My.Settings.AutoStartup = True Then RegOp_WriteStartup()

        'Hide this form
        Me.Visible = False
        Me.ShowInTaskbar = False

        'Flush unused memory
        FlushMemory()

    End Sub

#Region "Program Menus"

    Private Sub mnuScanOnMyComputer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuScanOnMyComputer.Click
        BalloonTipTextShow("Scanning in progress")
        BalloonTipTextShow(ScanDrive(DriveType.Fixed))
    End Sub

    Private Sub mnuScanInFlashdrive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuScanInFlashdrive.Click
        BalloonTipTextShow("Scanning in progress")
        BalloonTipTextShow(ScanDrive(DriveType.Removable))
    End Sub

    Private Sub mnuSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSettings.Click
        frmSettings.ShowDialog()
    End Sub

    Private Sub mnuViewLogFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuViewLogFile.Click
        frmLogFileViewer.ShowDialog()
    End Sub

    Private Sub mnuGetVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGetVersion.Click
        Process.Start("https://www.facebook.com/sPkAutorunkiller")
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExit.Click
        End
    End Sub

#End Region

    Private Sub ntfMainTrayIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ntfMainTrayIcon.MouseDoubleClick
        'Call WndProc
        WndProc(Message.Create(Me.Handle, WM_DEVICECHANGE, DBT_DEVICEARRIVAL, Nothing))
    End Sub

#End Region

End Class