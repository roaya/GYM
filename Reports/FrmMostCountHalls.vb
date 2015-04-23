Public Class FrmMostCountHalls
    Dim rpt As New RptMostCountHalls
    Dim d1, d2 As Date
    Dim tbl1 As New GeneralDataSet.HallsDataTable

    Private Sub FrmMostCountHalls_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from halls", tbl1)
        hallID.DataSource = tbl1
        hallID.DisplayMember = "hall_Name"
        hallID.ValueMember = "hall_ID"
    End Sub

    Private Sub Radall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radall.CheckedChanged
        If Radall.Checked = True Then
            hallID.Enabled = False

        End If
    End Sub

    Private Sub RadHall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadHall.CheckedChanged
        If RadHall.Checked = True Then
            hallID.Enabled = True


        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        d1 = CDate(fromdate.Text)
        d2 = CDate(todate.Text)
        MyDs.Tables("most_count_halls").Rows.Clear()
        If Radall.Checked = True Then
            cmd.CommandText = "Select * from most_count_halls where attend_Date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        Else
            If hallID.Text = "" Then
                MsgBox("من فضلك اختر اسم الصاله")
                Exit Sub
            Else
                cmd.CommandText = "Select * from most_count_halls where attend_Date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and hall_ID =" & hallID.SelectedValue
            End If
        End If
        da.Fill(MyDs.Tables("most_count_halls"))
        rpt.SetDataSource(MyDs.Tables("most_count_halls"))
        CrystalReportViewer2.ReportSource = rpt
        TabControl1.SelectTab(1)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub


End Class