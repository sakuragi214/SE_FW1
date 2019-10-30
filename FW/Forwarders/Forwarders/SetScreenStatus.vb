Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports ADODB
Public Class SetScreenStatus
    Dim id As String
    Dim table As Int32
    Dim count As Int32
    Dim ScreenStatus As Int16 = 0 '0 - Screen; 1 - Button
    Private Sub UserPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim Dataset As New DataSet
        'Dim DataAdapter As New OleDbDataAdapter
        'Dim rs As New ADODB.Recordset
        'Dim cbo As String
        'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        'rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        'rs.Open("SELECT Status FROM TempUserScreen WHERE userid='" & txtUserID.Text & "'", gs_Conn, 1)

        'DataAdapter.Fill(Dataset, rs, "TempUserScreen")

        'UserAccountsDataGrid.DataSource = Dataset.Tables(0)
        'UserAccountsDataGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'UserAccountsDataGrid.ReadOnly = True
        'UserAccountsDataGrid.RowHeadersVisible = False
        'Search = UserAccountsDataGrid.CurrentRow.Cells(0).Value.ToString
        screen()
        button()

        formLoad()
    End Sub

    Private Sub Form_Close(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("All changes will not be save, continue exit?", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            truncate1()
            truncate2()
            truncate3()
            Me.Dispose()
            'Application.Exit()
        End If

    End Sub

    Public Sub FilterData(valueToSearch As String)
        Dim Dataset As New DataSet
        Dim DataAdapter As New OleDbDataAdapter
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        'rs.Open("Select Screen.ScreenID, Screen.FormName, UserScreen.Status From Users Inner Join UserScreen On Users.UserID=UserScreen.UserID Inner Join Screen On Screen.ScreenID=UserScreen.ScreenID Where Users.UserID='" + TextBox1.Text + "'", gs_Conn, 3)
        rs.Open("Select Screen.ScreenID, Screen.FormName, TempUserScreen.Status From TempUsers Inner Join TempUserScreen On TempUsers.UserID=TempUserScreen.UserID Inner Join Screen On Screen.ScreenID=TempUserScreen.ScreenID Where TempUsers.UserID='" + AddUser.id + "'", gs_Conn, 3)

        DataAdapter.Fill(Dataset, rs, "Screen")
        DataGridView1.DataSource = Dataset.Tables(0)
        DataGridView1.ReadOnly = True
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'cboStatus.SelectedItem = DataGridView1.Item(2, i).Value.ToString()
    End Sub

    Public Sub FilterData1(valueToSearch As String)
        Dim Dataset As New DataSet
        Dim DataAdapter As New OleDbDataAdapter
        Dim rs3 As New ADODB.Recordset
        rs3.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs3.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs3.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        'rs.Open("Select Screen.ScreenID, Screen.FormName, UserScreen.Status From Users Inner Join UserScreen On Users.UserID=UserScreen.UserID Inner Join Screen On Screen.ScreenID=UserScreen.ScreenID Where Users.UserID='" + TextBox1.Text + "'", gs_Conn, 3)
        rs3.Open("Select Button.ButtonID, Button.ButtonName, TempUserButton.Status From TempUsers Inner Join TempUserButton On TempUsers.UserID=TempUserButton.UserID Inner Join Button On Button.ButtonID=TempUserButton.ButtonID Where TempUsers.UserID='" + txtUserID.Text.ToString + "'", gs_Conn, 3)

        DataAdapter.Fill(Dataset, rs3, "Button")
        DataGridView1.DataSource = Dataset.Tables(0)
        DataGridView1.ReadOnly = True
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'cboStatus.SelectedItem = DataGridView1.Item(2, i).Value.ToString()
    End Sub
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        'If ScreenStatus = 0 Then
        Dim i As Integer
            i = DataGridView1.CurrentRow.Index

            If Not String.IsNullOrEmpty(DataGridView1.Item(0, i).Value.ToString) Then
                txtScreenID.Text = DataGridView1.Item(0, i).Value
                txtFormName.Text = DataGridView1.Item(1, i).Value
                cboStatus.Text = DataGridView1.Item(2, i).Value
            Else
                txtScreenID.Text = ""
                txtFormName.Text = ""
                cboStatus.Text = ""
            End If
        'End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim Dataset As New DataSet
        Dim DataAdapter As New OleDbDataAdapter
        Dim rs As New ADODB.Recordset

        Dim userid As String, password As String, firstname As String, middlename As String, lastname As String
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic

        rs.Open("SELECT userid, password, firstname, middlename, lastname FROM TempUsers", gs_Conn, 3)
        userid = rs.Fields("userid").Value
        password = rs.Fields("password").Value
        firstname = rs.Fields("firstname").Value
        middlename = rs.Fields("middlename").Value
        lastname = rs.Fields("lastname").Value

        'MsgBox(userid)

        id = userid

        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("INSERT INTO Users (userid, firstname, middlename, lastname, password) 
VALUES ('" & userid & "' , '" & password & "', '" & firstname & "', '" &
middlename & "', '" & lastname & "')", mdl.conn)

        mdl.adapter.Fill(mdl.ds, "Users")

        userScreen()
        userButton()

        MsgBox("Saved successfully!")

        truncate1()
        truncate2()
        truncate3()

        Me.Dispose()
    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        '        FilterData(txtUserID.Text)

        '        Dim rs As New ADODB.Recordset
        '        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        '        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        '        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        '        rs.Open("UPDATE TempUserScreen Set TempUserScreen.Status='" + cboStatus.Text + "' FROM  TempUsers Inner Join 
        'TempUserScreen On TempUsers.UserID=TempUserScreen.UserID Inner Join Screen On Screen.ScreenID=TempUserScreen.ScreenID
        'WHERE TempUserScreen.UserID ='" + txtUserID.Text + "' And TempUserScreen.ScreenID='" + txtScreenID.Text + "'", gs_Conn, 3)

        '        formLoad()
    End Sub

    Public Sub formLoad()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToResizeRows = False
        FilterData("")
    End Sub

    Public Sub butt()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToResizeRows = False
        FilterData1("")
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

    Public Sub truncate3()
        Dim query As String = "TRUNCATE TABLE TempUserButton"

        Using conn As New SqlClient.SqlConnection(mdl.connectionString)
            Dim cmd As New SqlClient.SqlCommand(query, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
    End Sub

    Public Sub userScreen()
        Dim rs1 As New ADODB.Recordset
        Dim userid1 As String, screenid As String, status As String

        rs1.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs1.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs1.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic

        For I = 1 To table
            rs1.Open("SELECT userid, screenid, status FROM TempUserScreen WHERE screenid = '" & I & "'", gs_Conn, 3)
            userid1 = rs1.Fields("userid").Value
            screenid = rs1.Fields("screenid").Value
            status = rs1.Fields("status").Value

            mdl.ds = New DataSet
            mdl.adapter = New SqlDataAdapter("INSERT INTO UserScreen(userid, screenid, status) VALUES('" & userid1 & "', 
        '" & screenid & "', '" & status & "')", mdl.conn)

            mdl.ds = New DataSet
            mdl.adapter.Fill(mdl.ds, "UserScreen")

            rs1.Close()
        Next
    End Sub

    Public Sub userButton()
        Dim rs1 As New ADODB.Recordset
        Dim userid1 As String, buttonid As String, status As String

        rs1.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs1.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs1.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic

        For I = 1 To count
            rs1.Open("SELECT userid, buttonid, status FROM TempUserButton WHERE buttonid = '" & I & "'", gs_Conn, 3)
            userid1 = rs1.Fields("userid").Value
            buttonid = rs1.Fields("buttonid").Value
            status = rs1.Fields("status").Value

            mdl.ds = New DataSet
            mdl.adapter = New SqlDataAdapter("INSERT INTO UserButton(userid, buttonid, status) VALUES('" & userid1 & "', 
        '" & buttonid & "', '" & status & "')", mdl.conn)

            mdl.ds = New DataSet
            mdl.adapter.Fill(mdl.ds, "UserButton")

            rs1.Close()
        Next
    End Sub

    Public Sub screen()
        'Dim I As Integer

        'For I = 1 To table
        '    mdl.ds = New DataSet
        '    mdl.adapter = New SqlDataAdapter("INSERT INTO UserScreen (userid, screenid, status) VALUES ('" & txtUserID.Text & "', '" & I & "', 'Disable')", mdl.conn)
        '    mdl.adapter.Fill(mdl.ds, "TempUserScreen")
        'Next

        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("SELECT * FROM Screen", mdl.conn)

        table = mdl.adapter.Fill(mdl.ds, "Screen")

    End Sub

    Public Sub button()
        'Dim I As Integer

        'For I = 1 To count
        '    mdl.ds = New DataSet
        '    mdl.adapter = New SqlDataAdapter("INSERT INTO UserButton (userid, buttonid, status) VALUES ('" & txtUserID.Text & "', '" & I & "', 'Disable')", mdl.conn)
        '    mdl.adapter.Fill(mdl.ds, "TempUserButton")
        'Next

        mdl.ds = New DataSet
        mdl.adapter = New SqlDataAdapter("SELECT * FROM Button", mdl.conn)

        count = mdl.adapter.Fill(mdl.ds, "Button")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ScreenStatus = 0 Then
            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
            rs.Open("UPDATE TempUserScreen SET TempUserScreen.Status='" + cboStatus.Text + "' FROM  Screen Inner Join 
        TempUserScreen On Screen.ScreenID=TempUserScreen.screenid
        WHERE TempUserScreen.UserID ='" + txtUserID.Text + "' And TempUserScreen.ScreenID='" + txtScreenID.Text + "'", gs_Conn, 3)

            Dim Dataset As New DataSet
            Dim DataAdapter As New OleDbDataAdapter
            Dim rs1 As New ADODB.Recordset
            rs1.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs1.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs1.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
            rs1.Open("Select TempUserScreen.screenid, Screen.FormName, TempUserScreen.Status From Screen Inner Join TempUserScreen On Screen.screenid=TempUserScreen.screenid WHERE TempUserScreen.UserID ='" + txtUserID.Text + "'", gs_Conn, 3)

            DataAdapter.Fill(Dataset, rs1, "TempUserScreen")
            DataGridView1.DataSource = Dataset.Tables(0)
            DataGridView1.ReadOnly = True
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Else
            Dim rs As New ADODB.Recordset
            rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
            rs.Open("UPDATE TempUserButton SET TempUserButton.Status='" + cboStatus.Text + "' FROM Button Inner Join 
        TempUserButton On Button.ButtonID=TempUserButton.ButtonId
        WHERE TempUserButton.UserID ='" + txtUserID.Text + "' And TempUserButton.ButtonID='" + txtScreenID.Text + "'", gs_Conn, 3)

            Dim Dataset As New DataSet
            Dim DataAdapter As New OleDbDataAdapter
            Dim rs1 As New ADODB.Recordset
            rs1.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            rs1.CursorType = ADODB.CursorTypeEnum.adOpenStatic
            rs1.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
            rs1.Open("Select TempUserButton.ButtonID, Button.ButtonName, TempUserButton.Status From Button Inner Join TempUserButton On Button.ButtonID=TempUserButton.ButtonID WHERE TempUserButton.UserID ='" + txtUserID.Text + "'", gs_Conn, 3)

            DataAdapter.Fill(Dataset, rs1, "TempUserButton")
            DataGridView1.DataSource = Dataset.Tables(0)
            DataGridView1.ReadOnly = True
            DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ScreenStatus = 1

        txtScreenID.Text = ""
        txtFormName.Text = ""

        butt()
    End Sub
End Class