'FILE           : modRegistryOperation.vb
'Programmer     : Sipppakron Raksakide (sPk) (spkrsk.37@gmail.com)
'                 Chayapol Limanon (Chayapol.Limanon@gmail.com) 
'                 - RegOp_WriteStartup() and RegOp_DeleteStartup() Sub-Routine
Imports Microsoft.Win32

Module modRegistryOperation

    Private Function RegOp_OpenSubkey(ByVal RootKey As String, ByVal SubKey As String) As RegistryKey
        'Method Scope Declaration
        'RegKey            : Store openned registry key
        Dim RegKey As RegistryKey = Nothing

        'Check Root registry key
        If RootKey = "HKCR" Or RootKey = "HKEY_CLASSES_ROOT" Then
            RegKey = Registry.ClassesRoot.OpenSubKey(SubKey, True)

        ElseIf RootKey = "HKCU" Or RootKey = "HKEY_CURRENT_USER" Then
            RegKey = Registry.CurrentUser.OpenSubKey(SubKey, True)

        ElseIf RootKey = "HKLM" Or RootKey = "HKEY_LOCAL_MACHINE" Then
            RegKey = Registry.LocalMachine.OpenSubKey(SubKey, True)

        ElseIf RootKey = "HKU" Or RootKey = "HKEY_USERS" Then
            RegKey = Registry.Users.OpenSubKey(SubKey, True)

        ElseIf RootKey = "HKCC" Or RootKey = "HKEY_CURRENT_CONFIG" Then
            RegKey = Registry.CurrentConfig.OpenSubKey(SubKey, True)
        End If

        'Return openned registry key
        Return RegKey
    End Function
    Public Function RegOp_DelSubKey(ByVal RootKey As String, ByVal SubKey As String, ByVal SubKeydel As String) As Boolean
        Dim RegKey As RegistryKey = RegOp_OpenSubkey(RootKey, SubKey)
        Try
            RegKey.DeleteSubKey(SubKeydel, True)
            RegKey.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function
    Public Function RegOp_DeleteValue(ByVal RootKey As String, ByVal SubKey As String, ByVal Value As String) As Boolean
        Dim RegKey As RegistryKey = RegOp_OpenSubkey(RootKey, SubKey)
        Try
            RegKey.DeleteValue(Value, True)
            RegKey.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Function RegOp_Write(ByVal RootKey As String, ByVal SubKey As String, ByVal Value As String, ByVal data As String) As Boolean
        Dim RegKey As RegistryKey = RegOp_OpenSubkey(RootKey, SubKey)
        Try
                RegKey.SetValue(Value, data)
                RegKey.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function RegOp_Read(ByVal RootKey As String, ByVal SubKey As String, ByVal Value As String) As String
        Try
            Dim RegKey As RegistryKey = RegOp_OpenSubkey(RootKey, SubKey)
            Dim Var As String = ""
                Var = RegKey.GetValue(Value)
                RegKey.Close()
            Return Var
        Catch
            Return False
        End Try
    End Function
    Public Function RegOp_CreateSubKey(ByVal RootKey As String, ByVal SubKey As String, ByVal NewSubKey As String) As Boolean
        Dim RegKey As RegistryKey = RegOp_OpenSubkey(RootKey, SubKey)
        Try
            RegKey.CreateSubKey(NewSubKey)
            RegKey.Close()
        Catch ex As Exception
            Return False
            Exit Function
        End Try
        Return True
    End Function

    Public Sub RegOp_WriteStartup()
            WriteLogFile(modUtility.Events.CustomEvent, "HKCU\Software\Microsoft\Windows\CurrentVersion\Run : sPkAutorunkiller v.3.0", _
                        RegOp_Write("HKCU", "Software\Microsoft\Windows\CurrentVersion\Run", _
                                    "sPkAutorunkiller v.3.0", Application.ExecutablePath), _
                                    "Write registry value")
    End Sub

    Public Sub RegOp_DeleteStartup()
        If RegOp_Read("HKCU", "Software\Microsoft\Windows\CurrentVersion\Run", "sPkAutorunkiller v.3.0") <> "" Then _
            WriteLogFile(modUtility.Events.CustomEvent, "HKCU\Software\Microsoft\Windows\CurrentVersion\Run : sPkAutorunkiller v.3.0", _
                        RegOp_DeleteValue("HKCU", "Software\Microsoft\Windows\CurrentVersion\Run", _
                                          "sPkAutorunkiller v.3.0"), _
                                          "Delete registry value")
    End Sub
End Module
