
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports ADODB
Public Class AddUser
    Dim Dataset As DataSet
    Dim DataAdapter As OleDbDataAdapter
    Dim rs As ADODB.Recordset
    Dim count As Int32
    Dim table As Int32

    Private Sub AddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("SELECT * FROM Screen", mdl.conn)

        table = mdl.adapter.Fill(mdl.ds, "Screen")
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("INSERT INTO Users (userid, firstname, middlename, lastname, password) 
VALUES ('" & txtUsername.Text & "' , '" & txtFirstname.Text & "', '" & txtMiddlename.Text & "', '" &
txtLastname.Text & "', '" & txtPassword.Text & "')", mdl.conn)

        mdl.adapter.Fill(mdl.ds, "Users")

        screen()

        MsgBox("User added successfully!")
        Me.Close()
    End Sub

    Public Sub screen()
        Dim I As Integer

        For I = 1 To table
            mdl.ds = New DataSet
            mdl.adapter = New SqlDataAdapter("INSERT INTO UserScreen (userid, screenid, status) VALUES (
'" & txtUsername.Text & "', '" & I & "', 'Disable')", mdl.conn)
            mdl.adapter.Fill(mdl.ds, "UserScreen")
        Next

    End Sub

    Public Sub screenID()
        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("SELECT * FROM UserScreen", mdl.conn)

        count = mdl.adapter.Fill(mdl.ds, "UserScreen")
    End Sub
End Class