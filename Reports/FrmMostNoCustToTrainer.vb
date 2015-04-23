Public Class FrmMostNoCustToTrainer
    Dim rpt As New RptMostNoCustToTrainer
    Dim d1, d2 As Date
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable

    Private Sub FrmMostNoCustToTrainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from Employees e  ,jobs j where  j.Job_Title <> N'مدرب' and j.Job_id=e.Job_Id ", tbl1)
        TrainerID.DataSource = tbl1
        TrainerID.DisplayMember = "employee_name"
        TrainerID.ValueMember = "employee_id"

    End Sub

    Private Sub Radall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radall.CheckedChanged
        If Radall.Checked = True Then
            TrainerID.Enabled = False
        End If
    End Sub

    Private Sub RadTrainer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadTrainer.CheckedChanged
        If RadTrainer.Checked = True Then
            TrainerID.Enabled = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        d1 = CDate(fromdate.Text)
        d2 = CDate(todate.Text)
        MyDs.Tables("most_no_cust_to_trainer").Rows.Clear()
        If Radall.Checked = True Then
            cmd.CommandText = "Select * from most_no_cust_to_trainer where attend_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
        Else
            If TrainerID.Text = "" Then
                MsgBox("من فضلك اختر اسم المدرب")
                Exit Sub
            Else
                cmd.CommandText = "Select * from most_no_cust_to_trainer where attend_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and employee_id =" & TrainerID.SelectedValue
            End If
        End If
        da.Fill(MyDs.Tables("most_no_cust_to_trainer"))
        rpt.SetDataSource(MyDs.Tables("most_no_cust_to_trainer"))
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