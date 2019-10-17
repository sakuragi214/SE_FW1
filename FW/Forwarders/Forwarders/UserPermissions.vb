Imports System.Data.OleDb
Imports ADODB

Public Class UserPermissions
    Dim Dataset As DataSet
    Dim DataAdapter As OleDbDataAdapter
    Dim rs As ADODB.Recordset

    Private Sub UserPermissions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim Dataset As New DataSet
        'Dim DataAdapter As New OleDbDataAdapter
        'Dim rs As New ADODB.Recordset
        'rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        'rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        'rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        'rs.Open("SELECT UserID FROM USERS", gs_Conn, 1)

        'DataAdapter.Fill(Dataset, rs, "Users")
        'UserAccountsDataGrid.DataSource = Dataset.Tables(0)
        'UserAccountsDataGrid.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'UserAccountsDataGrid.ReadOnly = True
        'UserAccountsDataGrid.RowHeadersVisible = False
        'Search = UserAccountsDataGrid.CurrentRow.Cells(0).Value.ToString


        DataGridView1.RowHeadersVisible = False
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToResizeRows = False
        FilterData("")
    End Sub

    Public Sub FilterData(valueToSearch As String)
        Dim Dataset As New DataSet
        Dim DataAdapter As New OleDbDataAdapter
        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        rs.Open("Select Screen.ScreenID, Screen.FormName, UserScreen.Status From Users Inner Join UserScreen On Users.UserID=UserScreen.UserID Inner Join Screen On Screen.ScreenID=UserScreen.ScreenID Where Users.UserID='" + TextBox1.Text + "'", gs_Conn, 3)

        DataAdapter.Fill(Dataset, rs, "Screen")
        DataGridView1.DataSource = Dataset.Tables(0)
        DataGridView1.ReadOnly = True
        DataGridView1.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridView1.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub


    Private Sub UserAccountsDataGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        If Not String.IsNullOrEmpty(DataGridView1.Item(0, i).Value.ToString) Then
            TextBox2.Text = DataGridView1.Item(0, i).Value
            TextBox3.Text = DataGridView1.Item(1, i).Value
            ComboBox1.Text = DataGridView1.Item(2, i).Value

        Else
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox1.Text = ""
        End If


    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FilterData(TextBox1.Text)
        TextBox2.Text = ""
        TextBox3.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FilterData(TextBox1.Text)

        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        rs.Open("UPDATE
    UserScreen
SET
    UserScreen.Status='" + ComboBox1.Text + "'
FROM 
    Users Inner Join UserScreen On Users.UserID=UserScreen.UserID Inner Join Screen On Screen.ScreenID=UserScreen.ScreenID
WHERE
        UserScreen.UserID ='" + TextBox1.Text + "' And UserScreen.ScreenID='" + TextBox2.Text + "'", gs_Conn, 3)
        FilterData(TextBox1.Text)
        MessageBox.Show("Please Re-Log In to Take Effect Changes")


    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

End Class