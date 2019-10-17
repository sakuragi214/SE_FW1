Public Class Details
    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim table As DataTable = New DataTable("TABLE")
        ' Declare variables for DataColumn and DataRow objects. 
        Dim column As DataColumn

        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Col 1"
        ' Add the column to the table.
        table.Columns.Add(column)

        column = New DataColumn()
        column.DataType = Type.GetType("System.String")
        column.ColumnName = "Col 2"
        ' Add the column to the table.
        table.Columns.Add(column)

        table.Rows.Add("Row 1", "Row 1")
        table.Rows.Add("Row 2", "Row 2")
        table.Rows.Add("Row 3", "Row 3")

        DataGridView1.DataSource = table

        With DataGridView1

            ' Set property values appropriate for read-only display and  
            ' limited interactivity. 
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .AllowUserToResizeColumns = False
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .AllowUserToResizeRows = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            ' Special Appearance
            .RowHeadersVisible = False
            .Font = New Font("CourierNew", 10)

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            .Columns("Col 1").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Col 1").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Col 2").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Col 2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        DataGridView1.Rows(0).Selected = True
        updateDB()
    End Sub
    Private Sub updateDB()
        Dim chk As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn
        chk.HeaderText = "OK"
        chk.Name = "Check"
        DataGridView2.Columns.Add(chk)
        DataGridView2.ColumnCount = 6
        DataGridView2.Columns(1).Name = "Container No"
        DataGridView2.Columns(2).Name = "NOP"
        DataGridView2.Columns(3).Name = "TOP"
        DataGridView2.Columns(4).Name = "Refund"
        DataGridView2.Columns(5).Name = "Size"
        DataGridView2.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView2.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView2.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView2.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView2.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView2.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView2.Columns(0).AutoSizeMode = vbYes
        DataGridView2.Columns(1).AutoSizeMode = vbYes
        DataGridView2.Columns(2).AutoSizeMode = vbYes
        DataGridView2.Columns(3).AutoSizeMode = vbYes
        DataGridView2.Columns(4).AutoSizeMode = vbYes
        DataGridView2.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Dim row As ArrayList = New ArrayList
        DataGridView2.Rows.Add(row.ToArray())
        row = New ArrayList
        DataGridView2.Rows.Add(row.ToArray())

        row = New ArrayList
        DataGridView2.Rows.Add(row.ToArray())

        row = New ArrayList
        DataGridView2.Rows.Add(row.ToArray())

        row = New ArrayList
        DataGridView2.Rows.Add(row.ToArray())


        DataGridView3.ColumnCount = 2
        DataGridView3.Columns(0).Name = "Count"
        DataGridView3.Columns(1).Name = "Size"
        DataGridView3.Columns(0).AutoSizeMode = vbYes
        DataGridView3.RowHeadersVisible = False
        DataGridView3.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        DataGridView3.Rows.Add(row.ToArray())
        row = New ArrayList
        DataGridView3.Rows.Add(row.ToArray())
        row = New ArrayList
        DataGridView3.Rows.Add(row.ToArray())
        row = New ArrayList
        DataGridView3.Rows.Add(row.ToArray())
        row = New ArrayList
        DataGridView3.Rows.Add(row.ToArray())


    End Sub

    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        DataGridView2.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)

    End Sub

    Private Sub txtFileNo_TextChanged(sender As Object, e As EventArgs) Handles txtFileNo.TextChanged

    End Sub
End Class