﻿Imports System.Data.OleDb
Imports ADODB

Public Class File_Number_List
    Private Sub txtSearch_KeyUp(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyUp
        FilterData(txtSearch.Text)

        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
    End Sub

    Private Sub FilterData(text As String)
        Throw New NotImplementedException()
    End Sub

    Private Sub File_Number_List_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class