
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports ADODB
Public Class AddUser
    Dim Dataset As DataSet
    Dim DataAdapter As OleDbDataAdapter
    Dim rs As ADODB.Recordset
    Dim count As Int32
    Dim table As Int32
    Public id As String

    Public Sub AddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("SELECT * FROM Screen", mdl.conn)

        table = mdl.adapter.Fill(mdl.ds, "Screen")

        buttonID()
    End Sub
    Public Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("INSERT INTO tempUsers (userid, firstname, middlename, lastname, password) 
VALUES ('" & txtUsername.Text & "' , '" & txtFirstname.Text & "', '" & txtMiddlename.Text & "', '" &
txtLastname.Text & "', '" & txtPassword.Text & "')", mdl.conn)

        mdl.adapter.Fill(mdl.ds, "TempUsers")

        screen()
        button()

        id = txtUsername.Text

        SetScreenStatus.Show()
        SetScreenStatus.txtUserID.Text = txtUsername.Text

        Me.Dispose()
    End Sub

    Private Sub Form_Close(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("All changes will not be save, continue exit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            truncate1()
            truncate2()
            Me.Dispose()
            'Application.Exit()
        End If

    End Sub

    'Public Shared Sub CenterForm(ByVal frm As Form, Optional ByVal parent As Form = Nothing)
    '    '' Note: call this from frm's Load event!
    '    Dim r As Rectangle
    '    If parent IsNot Nothing Then
    '        r = parent.RectangleToScreen(parent.ClientRectangle)
    '    Else
    '        r = screen.FromPoint(frm.Location).WorkingArea
    '    End If

    '    Dim x = r.Left + (r.Width - frm.Width) \ 2
    '    Dim y = r.Top + (r.Height - frm.Height) \ 2
    '    frm.Location = New Point(x, y)
    'End Sub

    Public Sub screen()
        Dim I As Integer

        For I = 1 To table
            mdl.ds = New DataSet
            mdl.adapter = New SqlDataAdapter("INSERT INTO tempUserScreen (userid, screenid, status) VALUES ('" & txtUsername.Text & "', '" & I & "', 'Disable')", mdl.conn)
            mdl.adapter.Fill(mdl.ds, "TempUserScreen")
        Next

    End Sub

    Public Sub button()
        Dim I As Integer

        For I = 1 To count
            mdl.ds = New DataSet
            mdl.adapter = New SqlDataAdapter("INSERT INTO tempUserButton (userid, buttonid, status) VALUES ('" & txtUsername.Text & "', '" & I & "', 'Disable')", mdl.conn)
            mdl.adapter.Fill(mdl.ds, "TempUserButton")
        Next

    End Sub

    Public Sub buttonID()
        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("SELECT * FROM UserButton", mdl.conn)

        count = mdl.adapter.Fill(mdl.ds, "UserButton")
    End Sub

    Public Sub truncate1()
        Dim query As String = "TRUNCATE TABLE TempUsers"

        Using conn As New SqlClient.SqlConnection(mdl.connectionString)
            Dim cmd As New SqlClient.SqlCommand(query, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
    End Sub

    Public Sub truncate2()
        Dim query As String = "TRUNCATE TABLE TempUserScreen"

        Using conn As New SqlClient.SqlConnection(mdl.connectionString)
            Dim cmd As New SqlClient.SqlCommand(query, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
    End Sub
End Class