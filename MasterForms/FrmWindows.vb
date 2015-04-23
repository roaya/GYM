Public Class FrmWindows
    Dim t As New DataTable
    
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If RadioDDL.Checked = True Then
                cmd.CommandText = TxtDDL.Text
                cmd.ExecuteNonQuery()
                cls.MsgInfo("Successfully Compiled", "command has been executed successfully")
            ElseIf RadioDML.Checked = True Then
                t.Rows.Clear()
                t.Columns.Clear()
                cmd.CommandText = TxtDML.Text
                da.SelectCommand = cmd
                da.Fill(t)
                DataGridView1.DataSource = t
            End If
        Catch ex As Exception
            cls.MsgCritical(ex.Message)
        End Try
    End Sub

    Private Sub RadioDML_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDML.CheckedChanged
        If RadioDML.Checked = True Then
            TxtDML.Enabled = True
            TxtDDL.Enabled = False
        End If
    End Sub

    Private Sub RadioDDL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDDL.CheckedChanged
        If RadioDDL.Checked = True Then
            TxtDML.Enabled = False
            TxtDDL.Enabled = True
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
End Class