'FILE           : modHelper.vb
'Programmer     : Sipppakron Raksakide (sPk) (spkrsk.37@gmail.com)
'                 Chayapol Limanon (Chayapol.Limanon@gmail.com) 
Imports System.IO

Module modUtility
    'Module scope declaration
    'Version            : Store App. version
    'AutorunFileName    : Autorun.inf. Stored as String constant 
    Public Version As String = My.Application.Info.Version.ToString()
    Public Const AutorunFileName As String = "Autorun.inf"
    Public Const AutorunINIFileName As String = "Autorun.ini"

#Region "Memory Flush"

    Private Declare Function SetProcessWorkingSetSize Lib "kernel32.dll" ( _
        ByVal process As IntPtr, _
        ByVal minimumWorkingSetSize As Integer, _
        ByVal maximumWorkingSetSize As Integer) As Integer

    Public Sub FlushMemory()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        If (Environment.OSVersion.Platform = PlatformID.Win32NT) Then
            SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1)
        End If
    End Sub

#End Region

#Region "File Operation methods"
    'These methods are file operation methods and they will return a Boolean value (IsSuccess)
    'If operation success, it will return True. If not, it will return false 

    Private Function DeleteFile(ByVal FilePath As String) As Boolean
        'Method's Scope Declaration
        'IsSuccess      : for return a value
        Dim IsSuccess As Boolean
        'Check if file exists
        If File.Exists(FilePath) Then
            Try
                'Change file attribute before delete
                If ChangeFileAttribute(FilePath, FileAttribute.Normal) Then
                    'Delete file after change attribute
                    File.Delete(FilePath)
                    IsSuccess = True
                Else
                    IsSuccess = False
                End If
            Catch ex As Exception
                'In case of exception threw
                IsSuccess = False
            End Try
        Else
            IsSuccess = True
        End If
        'Return IsSuccess value to caller
        Return IsSuccess
    End Function

    Private Function CreateDirectory(ByVal DirectoryPath As String, ByVal DirectoryAttributes As FileAttributes) As Boolean
        'Method's Scope Declaration
        'IsSuccess      : for return a value
        Dim IsSuccess As Boolean
        Try
            'Create directory
            Directory.CreateDirectory(DirectoryPath)
            Dim NewDirectory As New DirectoryInfo(DirectoryPath) 'Create DirectoryInfo object
            NewDirectory.Attributes = DirectoryAttributes
            IsSuccess = True
        Catch ex As Exception
            'In case of exception threw
            IsSuccess = False
        End Try
        'Return IsSuccess value to caller
        Return IsSuccess
    End Function

    Private Function ChangeFileAttribute(ByVal FilePath As String, ByVal FileAttrib As FileAttribute) As Boolean
        'Method's Scope Declaration
        'IsSuccess      : for return a value
        Dim IsSuccess As Boolean
        Try
            File.SetAttributes(FilePath, FileAttrib)
            IsSuccess = True
        Catch ex As Exception
            'In case of exception threw
            IsSuccess = False
        End Try
        'Return IsSuccess value to caller
        Return IsSuccess
    End Function

    Private Function ModifyAutorunFile(ByVal AutoRunFilePath As String, ByVal SuspiciousFileList() As String) As Boolean
        'Method's Scope Declaration
        'IsSuccess      : for return a value
        'Autorun        : Collect all of Autorun.inf Contents
        Dim IsSuccess As Boolean, Autorun() As String

        'Action for Autorun.inf's Contents
        '----------------------------------------------------
        'Read Autorun.inf file for check suspicious files
        Autorun = File.ReadAllLines(AutoRunFilePath)
        'Remove lines that contain suspicious files
        If (SuspiciousFileList Is Nothing) = False Then
            For i = 0 To Autorun.Length - 1 Step 1
                For Each SuspiciousFileName In SuspiciousFileList
                    If SuspiciousFileName <> "" And UCase(Autorun(i)).Contains(UCase(SuspiciousFileName)) Then Autorun(i) = ""
                Next
            Next
        End If
        '----------------------------------------------------

        'Action for Autorun.inf file
        '----------------------------------------------------
        Try
            'Delete Autorun.inf file first
            IsSuccess = DeleteFile(AutoRunFilePath)
            'Write all contents excepts empty lines
            For Each Line In Autorun
                If Line <> "" Then My.Computer.FileSystem.WriteAllText(AutoRunFilePath, Line, True)
            Next
            IsSuccess = True
        Catch ex As Exception
            'In case of exception threw
            IsSuccess = False
        End Try
        '----------------------------------------------------
        'Return IsSuccess value to caller
        Return IsSuccess
    End Function

#End Region

#Region "Logging Helper"
    'This method is created for write a log file in format
    '[SpkLog]
    '****IF SUCCESS
    '[Time] |Event Description| - |File|
    '****IF ERROR
    '[Time] |Error>> |Event Description| - |File|
    Public Function WriteLogFile(ByVal _Event As Events, ByVal FilePath As String, _
                                 ByVal IsSuccess As Boolean, Optional ByVal CustomText As String = "") As String

        'Generate logfile name
        Dim LogFileName As String = My.Application.Info.DirectoryPath.ToString & _
            "\Report\" & Date.Today.Day & "-" & Date.Today.Month & "-" & Date.Today.Year & ".log"
        Dim EventText As String = ""

        'Check that logfile exists. If it doesn't, Create a new one
        If File.Exists(LogFileName) = False Then _
            My.Computer.FileSystem.WriteAllText(LogFileName, "[SpkLog]" & vbCrLf, False)

        'Switch using _Event and isSuccess to generate Event text
        Select Case _Event
            Case Events.FileDelete And IsSuccess = True
                EventText = "File deleted"
            Case Events.FileDelete And IsSuccess = False
                EventText = "File deletion failed"
            Case Events.CreateDirectory And IsSuccess = True
                EventText = "Directory created"
            Case Events.CreateDirectory And IsSuccess = False
                EventText = "Directory creation Failed"
            Case Events.ChangeFileAttribute And IsSuccess = True
                EventText = "Attribute changed"
            Case Events.ChangeFileAttribute And IsSuccess = True
                EventText = "Attribute changing failed"
            Case Events.ModifyFile And IsSuccess = True
                EventText = "File modified"
            Case Events.ModifyFile And IsSuccess = False
                EventText = "File modifying failed"
            Case Events.CustomEvent
                EventText = CustomText

        End Select

        'Write logfile
        Try
            'Format Eventext and write to file
            Select Case IsSuccess
                Case True
                    EventText = String.Format("[{0}] |{1}| - |{2}", DateTime.Now.ToString(), EventText, FilePath) & vbCrLf
                    My.Computer.FileSystem.WriteAllText(LogFileName, EventText, True)
                Case False
                    EventText = String.Format("[{0}] |Error>> |{1}| - |{2}", DateTime.Now.ToString(), EventText, FilePath) & vbCrLf
                    My.Computer.FileSystem.WriteAllText(LogFileName, EventText, True)
            End Select
            'On error, show Messagebox alert
        Catch ex As Exception
            MessageBox.Show("Error : " & vbCrLf & ex.Message, "sPkAutorunkiller v." & Version, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return EventText
        FlushMemory()
    End Function

    'Enumumeration of event type
    Public Enum Events
        FileDelete
        CreateDirectory
        ChangeFileAttribute
        ModifyFile
        CustomEvent
    End Enum

#End Region

    Public Function DeleteLnkFile(ByVal Drive As String) As String
        'Method Scope Declaration
        'Message            : Receive message from file operation
        'Root               : Store directory info
        'Files              : Store .lnk files list
        Dim Root As New DirectoryInfo(Drive)
        Dim Files As FileInfo() = Root.GetFiles("*.lnk")
        Dim Message As String = ""
        Dim lnkList As New ArrayList 'list of lnk file
        Dim i As Integer
        'Delete all *.lnk files in root directory
        For Each FileObject In Files
            Dim FilePath As String = FileObject.FullName
            If My.Settings.AutoDelete = False Then _
                If MsgBox("Do you want to delete " & FilePath, MsgBoxStyle.YesNo) = DialogResult.No Then Continue For
            Message += WriteLogFile(Events.FileDelete, FilePath, DeleteFile(FilePath))
            Message += WriteLogFile(Events.CreateDirectory, FilePath, CreateDirectory(FilePath, FileAttributes.Hidden))
            Dim FolderPath As String = FilePath.Replace(".lnk", "")
            lnkList.Add(FolderPath)
            If Directory.Exists(FolderPath) = True Then
                Dim Folder As New DirectoryInfo(FolderPath)
                Message += WriteLogFile(Events.ChangeFileAttribute, FolderPath, ChangeFileAttribute(FolderPath, FileAttribute.Normal))
                Message += WriteLogFile(Events.CreateDirectory, FilePath, CreateDirectory(FilePath, FileAttributes.Hidden))
            End If
        Next
        'ChangeFileAttribute file in main directory on flashdrive to normal
        For i = 0 To lnkList.Count - 1
            Files = Root.GetFiles(lnkList.Item(i).ToString.Replace(Drive, "") & ".*")
            For Each FileObject In Files
                Dim FilePath As String = FileObject.FullName
                If File.Exists(FilePath) = True Then
                    Message += WriteLogFile(Events.ChangeFileAttribute, FilePath, ChangeFileAttribute(FilePath, FileAttribute.Normal))
                End If
            Next
        Next
        'End of ChangeFileAttribute all file in flashdrive to normal
        Message = Message.Replace("|", "")
        Return Message
    End Function

    Public Function DeleteAutorunFile(ByVal Drive As String) As String
        'Method Scope Declaration
        'Message            : Receive message from file operation
        'temp               : Temporary string
        'AutorunFilePath    : Store an Autorun file path (Concat. with Drive & AutorunFilename constant
        'SuspiciousFileList : String array of Suspicious files list
        Dim Message = "", temp = "", AutorunFilePath = (Drive & AutorunFileName), SuspiciousFilesList() As String
        SuspiciousFilesList = Nothing
        'Action for Autorun.inf(.ini)'s Contents
        '2 loop for check autorun.inf and autorun.ini
        Dim i As Integer
        For i = 1 To 2
            'check i if i is 1 set AutorunFilePath = drive + autorun.inf else AutorunFilePath = drive + autorun.ini
            If (i = 1) Then AutorunFilePath = (Drive & AutorunFileName) Else AutorunFilePath = (Drive & AutorunINIFileName)
            '----------------------------------------------------
            'Read Autorun.inf(and autonrun.ini) file for check suspicious files
            If File.Exists(AutorunFilePath) Then
                'Declare FileStreamReader to read Autorun.inf file
                Dim srInfFileReader As StreamReader = New StreamReader(AutorunFilePath, System.Text.UnicodeEncoding.Default)
                'Loop until EOF
                While srInfFileReader.Peek <> -1
                    'Add suspicious file name to temporary String (Concat. with "|" as splitter)
                    temp += CheckSuspiciousFileName(srInfFileReader.ReadLine().ToLower) & "|"
                End While
                srInfFileReader.Close()
            End If

            'Parse temporary String to the suspicious files list
            'Temporary string Validation
            If temp <> "" And temp <> "|" Then
                'Re-declare SuspiciousFilesList with dedicated size
                Dim tempLength As Integer = temp.Split("|").Length
                Dim SuspiciousFilePath As String
                ReDim SuspiciousFilesList(tempLength)

                'Copy splitted temporary string to SuspiciousFilesList
                Array.Copy(temp.Split("|"), SuspiciousFilesList, tempLength)

                'Delete all file in suspicious file list
                For Each FilePath As String In SuspiciousFilesList
                    If FilePath <> "" Then
                        SuspiciousFilePath = Drive & FilePath
                        'Check file exists
                        If File.Exists(SuspiciousFilePath) = True Then
                            'Require user confirmation before delete
                            If My.Settings.AutoDelete = False Then
                                If MsgBox("Do you want to delete " & SuspiciousFilePath, MsgBoxStyle.YesNo) = DialogResult.No Then
                                    Continue For 'Skip to next step
                                Else
                                    'Delete suspicious file if user click "Yes"
                                    Message += WriteLogFile(Events.FileDelete, FilePath, DeleteFile(SuspiciousFilePath))
                                    If Directory.Exists(SuspiciousFilePath) = False Then
                                        Message += WriteLogFile(Events.CreateDirectory, FilePath, CreateDirectory(SuspiciousFilePath, FileAttributes.Hidden))
                                    End If
                                End If
                            Else
                                'Delete file automatically if AutoDelete setting = True
                                Message += WriteLogFile(Events.FileDelete, FilePath, DeleteFile(SuspiciousFilePath))
                                If Directory.Exists(SuspiciousFilePath) = False Then
                                    Message += WriteLogFile(Events.CreateDirectory, FilePath, CreateDirectory(SuspiciousFilePath, FileAttributes.Hidden))
                                End If
                            End If
                        End If
                    End If
                Next
            End If
            '----------------------------------------------------

            'Action for Autorun.inf(and autonrun.ini) file
            '----------------------------------------------------
            If File.Exists(AutorunFilePath) = True Then
                'Refer to user's settings
                If My.Settings.RemoveAutorun = True Then
                    If My.Settings.AutoDelete = False Then
                        'Require user confirmation before delete
                        If MsgBox("Do you want to delete " & AutorunFilePath, MsgBoxStyle.YesNo) = DialogResult.Yes Then
                            'Delete Autorun.inf(and autonrun.ini) file
                            Message += WriteLogFile(Events.FileDelete, AutorunFilePath, DeleteFile(AutorunFilePath))
                            'Create Autorun.inf(and autonrun.ini) directory
                            If Directory.Exists(AutorunFilePath) = False Then _
                                Message += WriteLogFile(Events.CreateDirectory, AutorunFilePath, CreateDirectory(AutorunFilePath, FileAttributes.Hidden))
                        End If
                    Else
                        'In case of Settings.AutoDelete = False
                        'Delete Autorun.inf file and create Autorun.inf(and autonrun.ini) directory
                        Message += WriteLogFile(Events.FileDelete, AutorunFilePath, DeleteFile(AutorunFilePath))
                        If Directory.Exists(AutorunFilePath) = False Then
                            Message += WriteLogFile(Events.CreateDirectory, AutorunFilePath, CreateDirectory(AutorunFilePath, FileAttributes.Hidden))
                        End If
                    End If
                Else
                    'Modify Autorun.inf(and autonrun.ini) to prevent threat executions 
                    '(this will allow user to create Autorun.inf file but only contains icon with *.ico or *.bmp and set custom drive label)
                    If File.Exists(AutorunFilePath) = True Then
                        Message += WriteLogFile(Events.ModifyFile, AutorunFilePath, ModifyAutorunFile(AutorunFilePath, SuspiciousFilesList))
                    End If
                End If
            End If
        Next
        'Return a message to caller
        Message = Message.Replace("|", "")
        Return Message
    End Function

    Private Function CheckSuspiciousFileName(ByVal Input As String) As String
        'Method Scope Declaration
        'AutorunValue           : Contains Autorun.inf keys to detect
        'FilePath               : Stores parsed file path
        Dim AutorunKeys() As String = _
            { _
                "ICON=", _
                "SHELL\INSTALL=", _
                "shell\open\COmManD=", _
                "shell\AutoplaY\coMmand=", _
                "sheLl\opeN\comMAnd", _
                "SHELLEXECUTE=", _
                "OPEN=", _
                "SHELL\VERB=", _
                "ACTION=" _
            }, _
            FilePath As String = ""
        'Convert to upper case
        Input = UCase(Input)
        For Each AutorunKey As String In AutorunKeys
            'Check that input contains each Autorun.inf keys
            'And check for nested file extension to prevent "*.ICO.EXE" or "*.BMP.EXE" file
            If Input.Contains(AutorunKey) And (Input.Contains(".ICO.") Or Input.Contains(".BMP.") = False) Then
                If Input.Contains(".ICO") Or Input.Contains(".BMP") Then
                    FilePath = ""
                Else
                    FilePath = (Input.Replace(AutorunKey, ""))  'Replace key name with a "" value
                    FilePath = FilePath.Split(",")(0)           'Remove ResourceID in case of icon from .EXE/.DLL resources
                    FilePath = FilePath.Split("/")(0)           '<< PLEASE FIX THIS. It's for remove command line argument
                End If
            End If
        Next
        'Return file path to caller
        Return FilePath
    End Function

End Module
