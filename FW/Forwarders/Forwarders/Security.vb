Imports System.Data.OleDb
Imports ADODB
Public Class Security
    Function fCHK(ByVal uname As String, ByVal pword As String) As Boolean
        Dim da As New System.Data.OleDb.OleDbDataAdapter()
        Dim ds As New DataSet()


        Dim rsLogin As New ADODB.Recordset
        Dim logstr = ("SELECT userid, password From USERS WHERE userid='" & uname & "' and password='" & pword & "'")

        With rsLogin
            .CursorLocation = ADODB.CursorLocationEnum.adUseClient
            .CursorType = ADODB.CursorTypeEnum.adOpenStatic
            .LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
            .Open(logstr, gs_Conn)
        End With



        With rsLogin

            If .EOF Then
                fCHK = False
            Else

                fCHK = True
            End If

        End With

    End Function
End Class
