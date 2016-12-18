Imports System.IO
Public Class frmLogFileViewer
    'Need for sort lsvLogDetail manually
    Dim sortColumn As Integer = -1

    Private Sub LoadLogFile(ByVal Logfile As String)
        'Declare FileStreamReader to read log file
        Dim srInfFileReader As StreamReader = New StreamReader(Logfile, System.Text.UnicodeEncoding.Default), _
            LogLine As String = "", _
            EventKeys() = {"del", "Dir", "att", "mod"}, SplittedLogLine() As String, _
            IsSpkLog = False, IsErrorMessage = False
        'Loop until EOF
        While srInfFileReader.Peek <> -1
            LogLine = srInfFileReader.ReadLine()
            'Check the header for verify. If it corrects, set IsSpkLog = True 
            'and skip to next iterations
            If LogLine = "[SpkLog]" Then
                IsSpkLog = True
                Continue While
            End If
            Try
                If IsSpkLog Then
                    'Check that it is error message. If it is error message, set IsErrorMessage = true
                    'and remove "|Error>> " out.
                    'If it not, set IsErrorMessage = False
                    If LogLine.Contains("|Error>>") Then
                        IsErrorMessage = True
                        LogLine = LogLine.Replace("|Error>> ", "")
                    Else : IsErrorMessage = False
                    End If

                    'Remove barckets
                    LogLine = LogLine.Replace("[", "") : LogLine = LogLine.Replace("]", "")

                    'Split LogLine with "|" and set it to SplitteLogLine()
                    'After that, SplitteLogLine() will look like this
                    'SplittedLogLine(0)     = Time
                    'SplittedLogLine(1)     = Event Description
                    'SplittedLogLine(2)     = " - "
                    'SplittedLogLine(3)     = File path
                    SplittedLogLine = LogLine.Split("|")
                    Dim NewLogItem As ListViewItem = New ListViewItem
                    'First, set first column a time value
                    NewLogItem.Text = SplittedLogLine(0).Trim()
                    'Then check that what action it is
                    For Each EventKey In EventKeys
                        If EventKey = "del" And SplittedLogLine(1).Contains(EventKey) Then
                            NewLogItem.SubItems.Add("Delete file")
                        ElseIf EventKey = "Dir" And SplittedLogLine(1).Contains(EventKey) Then
                            NewLogItem.SubItems.Add("Create directory")
                        ElseIf EventKey = "att" And SplittedLogLine(1).Contains(EventKey) Then
                            NewLogItem.SubItems.Add("Change Attribute")
                        ElseIf EventKey = "mod" And SplittedLogLine(1).Contains(EventKey) Then
                            NewLogItem.SubItems.Add("Modify file")
                        End If
                    Next
                    'If it is custom event message. Above loop will not add "Action" column to NewLogItem.
                    'Therefore, if you all NewLogItem.SubItems(1). It will throw an exception.
                    'Then we will add "Action" column in Catch block
                    Try
                        Dim CheckCustomEvent = NewLogItem.SubItems(1)
                    Catch ex As Exception
                        NewLogItem.SubItems.Add(SplittedLogLine(1))
                    End Try

                    'Check IsErrorMessage to add "Result" column
                    Select Case IsErrorMessage
                        Case True : NewLogItem.SubItems.Add("Error")
                        Case False : NewLogItem.SubItems.Add("Success")
                    End Select
                    'Add file name to "File" column
                    NewLogItem.SubItems.Add(SplittedLogLine(3))
                    lsvLogDetail.Items.Add(NewLogItem)
                    'Return memory to system
                    NewLogItem = Nothing
                Else
                    'If IsSpkLog = False. This line will execute
                    MessageBox.Show("Error : " & vbCrLf & Logfile & _
                                    "- This file isn't sPkAutorunKiller v." & Version & " log file", "sPkAutorunkiller v." & Version, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit While
                End If
            Catch ex As Exception
                'If exception threw. This line will execute
                MessageBox.Show("Error : " & vbCrLf & Logfile & _
                                "- This file corrupt", "sPkAutorunkiller v." & Version, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End While
        srInfFileReader.Close()
        srInfFileReader = Nothing
    End Sub

    Private Sub frmLogFileViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mnuLoadAllLogfile.PerformClick()
    End Sub

    Private Sub mnuLoadAllLogfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadAllLogfile.Click
        lsvLogDetail.Items.Clear()
        For Each Logfile In IO.Directory.GetFiles(My.Application.Info.DirectoryPath.ToString & "\Report", "*.log")
            LoadLogFile(Logfile)
        Next
    End Sub

    Private Sub mnuOpenLogFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOpenLogFile.Click
        Dim dlgOpenFile As OpenFileDialog = New OpenFileDialog
        dlgOpenFile.Filter = "Log files (*.log)|*.log"
        dlgOpenFile.InitialDirectory = My.Application.Info.DirectoryPath.ToString & "\Report"
        dlgOpenFile.Multiselect = False
        If dlgOpenFile.ShowDialog() = DialogResult.OK Then
            lsvLogDetail.Items.Clear()
            LoadLogFile(dlgOpenFile.FileName)
        End If
        dlgOpenFile = Nothing
    End Sub

    Private Sub lsvLogDetail_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lsvLogDetail.ColumnClick
        ' Determine whether the column is the same as the last column clicked.
        If e.Column <> sortColumn Then
            ' Set the sort column to the new column.
            sortColumn = e.Column
            ' Set the sort order to ascending by default.
            lsvLogDetail.Sorting = SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If lsvLogDetail.Sorting = SortOrder.Ascending Then
                lsvLogDetail.Sorting = SortOrder.Descending
            Else
                lsvLogDetail.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        lsvLogDetail.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        lsvLogDetail.ListViewItemSorter = New ListViewItemComparer(e.Column, _
                                                         lsvLogDetail.Sorting)
    End Sub

    Private Sub frmLogFileViewer_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
        FlushMemory()
    End Sub

    Private Sub mnuClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuClose.Click
        Me.Dispose()
        FlushMemory()
    End Sub
End Class

'Implements the manual sorting of items by columns.
Class ListViewItemComparer
    Implements IComparer
    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        col = 0
        order = SortOrder.Ascending
    End Sub

    Public Sub New(ByVal column As Integer, ByVal order As SortOrder)
        col = column
        Me.order = order
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
                        Implements System.Collections.IComparer.Compare
        Dim returnVal As Integer = -1
        returnVal = [String].Compare(CType(x,  _
                        ListViewItem).SubItems(col).Text, _
                        CType(y, ListViewItem).SubItems(col).Text)
        ' Determine whether the sort order is descending.
        If order = SortOrder.Descending Then
            ' Invert the value returned by String.Compare.
            returnVal *= -1
        End If

        Return returnVal
    End Function
End Class