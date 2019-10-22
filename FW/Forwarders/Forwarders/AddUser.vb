
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
    End Sub
    Public Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("INSERT INTO tempUsers (userid, firstname, middlename, lastname, password) 
VALUES ('" & txtUsername.Text & "' , '" & txtFirstname.Text & "', '" & txtMiddlename.Text & "', '" &
txtLastname.Text & "', '" & txtPassword.Text & "')", mdl.conn)

        mdl.adapter.Fill(mdl.ds, "TempUsers")

        screen()
        id = txtUsername.Text

        SetScreenStatus.Show()
        SetScreenStatus.txtUserID.Text = txtUsername.Text

        Me.Close()
    End Sub

    Public Sub screen()
        Dim I As Integer

        For I = 1 To table
            mdl.ds = New DataSet
            mdl.adapter = New SqlDataAdapter("INSERT INTO tempUserScreen (userid, screenid, status) VALUES ('" & txtUsername.Text & "', '" & I & "', 'Disable')", mdl.conn)
            mdl.adapter.Fill(mdl.ds, "TempUserScreen")
        Next

    End Sub

    Public Sub screenID()
        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("SELECT * FROM UserScreen", mdl.conn)

        count = mdl.adapter.Fill(mdl.ds, "UserScreen")
    End Sub
End Class