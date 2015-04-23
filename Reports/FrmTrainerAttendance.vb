Public Class FrmTrainerAttendance
    Dim rpt As New RptTrainerAttendance
    Dim tbl1 As New GeneralDataSet.HallsDataTable
    Dim tbl2 As New GeneralDataSet.EmployeesDataTable
    Dim tbl3 As New GeneralDataSet.ShiftsDataTable
    Dim tbl4 As New GeneralDataSet.Shifts_DetailsDataTable
    Private Sub RadHall_Checked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadHall.CheckedChanged
        If RadHall.Checked = True Then
            HallID.Enabled = True
            EmpID.Enabled = False
            ShiftDetailID.Enabled = False
            ShiftID.Enabled = False
        End If
    End Sub

    Private Sub Rademp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rademp.CheckedChanged
        If Rademp.Checked = True Then
            HallID.Enabled = False
            EmpID.Enabled = True
            ShiftDetailID.Enabled = False
            ShiftID.Enabled = False
        End If
    End Sub

    Private Sub RadShift_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadShift.CheckedChanged
        If RadShift.Checked = True Then
            HallID.Enabled = False
            EmpID.Enabled = False
            ShiftDetailID.Enabled = False
            ShiftID.Enabled = True
        End If
    End Sub

    Private Sub RadShiftDetails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadShiftDetails.CheckedChanged
        If RadShiftDetails.Checked = True Then
            HallID.Enabled = False
            EmpID.Enabled = False
            ShiftDetailID.Enabled = True
            ShiftID.Enabled = False
        End If
    End Sub

    Private Sub FrmTrainerAttendance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from Employees e , jobs j Where e.job_Id=j.Job_ID and j.Job_Title = N'مدرب' ", tbl2)
        cls.RefreshData("select * from shifts ", tbl3)
        cls.RefreshData("select * from halls ", tbl1)
        cls.RefreshData("select * from shifts_details", tbl4)

        HallID.DataSource = tbl1
        HallID.DisplayMember = "Hall_Name"
        HallID.ValueMember = "Hall_id"

        EmpID.DataSource = tbl2
        EmpID.DisplayMember = "Employee_Name"
        EmpID.ValueMember = "Employee_ID"

        ShiftID.DataSource = tbl3
        ShiftID.DisplayMember = "Shift_Name"
        ShiftID.ValueMember = "Shift_Id"

        ShiftDetailID.DataSource = tbl4
        ShiftDetailID.DisplayMember = "Shift_Details_Name"
        ShiftDetailID.ValueMember = "Shift_Details_id"

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyDs.Tables("Report_trainer_Attendance").Rows.Clear()
        If RadHall.Checked = True Then
            If HallID.Text = "" Then
                MsgBox("من فضلك اختر اسم الصاله")
                Exit Sub
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_trainer_Attendance where hall_Id= " & HallID.SelectedValue

            End If

        ElseIf Rademp.Checked = True Then
            If EmpID.Text = "" Then
                MsgBox("من فضلك اختر اسم الموظف")
                Exit Sub
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_trainer_Attendance where Employee_ID= " & EmpID.SelectedValue

            End If
        ElseIf RadShift.Enabled = True Then
            If ShiftID.Text = "" Then
                MsgBox("من فضلك اختر نوع الورديه")
                Exit Sub
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_trainer_Attendance where Shift_ID= " & ShiftID.SelectedValue

            End If
        Else
            If ShiftDetailID.Text = "" Then
                MsgBox("من فضلك اختر اسم الورديه")
                Exit Sub
            Else
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_trainer_Attendance where Shift_Details_id= " & ShiftDetailID.SelectedValue
            End If
        End If
        da.Fill(MyDs.Tables("Report_trainer_Attendance"))
        rpt.SetDataSource(MyDs.Tables("Report_trainer_Attendance"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        crystalreportviewer1.ReportSource = rpt
        TabControl1.SelectTab(1)
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