Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim chk As New Security

        If (chk.fCHK(txtUsername.Text, txtPassword.Text)) Then
            gs_User = txtUsername.Text
            MDIForwarders.Show()
            txtUsername.Clear()
            txtPassword.Clear()
            Me.Hide()

        Else
            MsgBox("Login not successful!")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form_Close(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Dim dialog As DialogResult
        dialog = MessageBox.Show("Do you really want to close the app", "Exit", MessageBoxButtons.YesNo)
        If dialog = DialogResult.No Then
            e.Cancel = True
        Else
            Application.ExitThread()

        End If

    End Sub
End Class
