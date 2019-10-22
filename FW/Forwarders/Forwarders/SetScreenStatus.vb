Imports System.Data.OleDb
Imports ADODB
Public Class SetScreenStatus
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

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
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
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub

    Private Sub cboStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatus.SelectedIndexChanged
        FilterData(txtUserID.Text)

        Dim rs As New ADODB.Recordset
        rs.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        rs.CursorType = ADODB.CursorTypeEnum.adOpenStatic
        rs.LockType = ADODB.LockTypeEnum.adLockBatchOptimistic
        rs.Open("UPDATE TempUserScreen SET TempUserScreen.Status='" + cboStatus.Text + "' FROM  TempUsers Inner Join 
TempUserScreen On TempUsers.UserID=TempUserScreen.UserID Inner Join Screen On Screen.ScreenID=TempUserScreen.ScreenID
WHERE TempUserScreen.UserID ='" + txtUserID.Text + "' And TempUserScreen.ScreenID='" + txtScreenID.Text + "'", gs_Conn, 3)

        formLoad()
    End Sub

    Private Sub cboStatus_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboStatus.SelectionChangeCommitted

    End Sub

    Public Sub formLoad()
        DataGridView1.RowHeadersVisible = False
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToResizeRows = False
        FilterData(txtUserID.Text)
    End Sub

    Public Sub truncate1()
        Dim query As String = "TRUNCATE TABLE TempUsers"

        Using conn As New SqlClient.SqlConnection("Data Source=khel;Initial Catalog=FW;User ID=sa")
            Dim cmd As New SqlClient.SqlCommand(query, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
    End Sub

    Public Sub truncate2()
        Dim query As String = "TRUNCATE TABLE TempUserScreen"

        Using conn As New SqlClient.SqlConnection("Data Source=khel;Initial Catalog=FW;User ID=sa")
            Dim cmd As New SqlClient.SqlCommand(query, conn)
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
        End Using
    End Sub

    Private Sub SetScreenStatus_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

    End Sub
End Class