Option Explicit On
Imports System.Data
Imports System.Data.OleDb
Imports ADODB
Imports System.IO

Module FW
    Public gs_Conn As String = "FILE NAME=" & App_Path() & "\FW.udl"
    Public gs_User As String
    Public Function App_Path() As String
        App_Path = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName
    End Function
End Module
