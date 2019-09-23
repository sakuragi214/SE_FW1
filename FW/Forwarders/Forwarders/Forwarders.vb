Imports System.Windows.Forms

Public Class MDIForwarders

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIForwarders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TreeView1.Nodes(0).ExpandAll()
        f = New Advances
        f.TopLevel = False
        Me.Panel1.Controls.Add(f)
        f.Dock = DockStyle.Fill
        f.Show()



    End Sub

    Private Sub StatusStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip.ItemClicked

    End Sub

    Private Sub Form_Close(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        frmLogin.Show()

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
    Private f As Form
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        Dim node As TreeNode
        node = TreeView1.SelectedNode
        Select Case node.Text
            Case "Advances"
                f.Dispose()
                f = New Advances
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Liquidation"
                f.Dispose()
                f = New Liquidation
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Main"
                f.Dispose()
                f = New MainFW
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Details"
                f.Dispose()
                f = New Details
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Custom Info"
                f.Dispose()
                f = New CustomInfo
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "History"
                f.Dispose()
                f = New History
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Certificate Of Payment"
                f.Dispose()
                f = New CertificateOfPayment
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()

            Case "Schedule Of Delivery"
                f.Dispose()
                f = New ScheduleOfDelivery
                f.TopLevel = False
                Me.Panel1.Controls.Add(f)
                f.Dock = DockStyle.Fill
                f.Show()
        End Select


    End Sub
End Class
