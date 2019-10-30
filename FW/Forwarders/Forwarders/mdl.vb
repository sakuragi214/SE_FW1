Imports System.Data.SqlClient

Module mdl
    Public conn As New SqlConnection("Data Source=khel;Initial Catalog=FW;User ID=sa;")
    Public adapter As New SqlDataAdapter
    Public ds As DataSet
    Public connStr As String

    Public connectionString As String = "Data Source=khel;Initial Catalog=FW;User ID=sa;"
    Public log As String = ""
End Module
