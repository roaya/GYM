Public Class SearchWindow

    Dim B As New BindingSource
    Public DsMember, ValMember As String

    Sub FillList()
        B.DataSource = MyDs
        SearchBox.DataSource = B
        SearchBox.DisplayMember = DsMember
        SearchBox.ValueMember = ValMember
    End Sub

    Private Sub SearchWindow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillList()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FilterDetails = True Then
            SSource.Filter = RVal & " = '" & SearchBox.Text & "'"
            DSource.Filter = RVal & " = '" & SearchBox.Text & "'"
        Else
            SSource.Filter = RVal & " = '" & SearchBox.Text & "'"
        End If
        Me.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SSource.RemoveFilter()
        Me.Close()
    End Sub
End Class