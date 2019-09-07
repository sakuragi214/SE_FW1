Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim chk As New Security

        If (chk.fCHK(txtUsername.Text, txtUsername.Text)) Then
            MDIForwarders.Show()
        Else
            MsgBox("Login not successful!")
        End If
    End Sub
End Class
