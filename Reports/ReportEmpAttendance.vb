Public Class ReportEmpAttendance

    Dim rpt As New RptEmployeesAttendance
    Dim bsource As New BindingSource
    Dim tbl As New GeneralDataSet.EmployeesDataTable
    Dim tbl1 As New GeneralDataSet.DepartmentsDataTable
    Dim tbl2 As New GeneralDataSet.JobsDataTable
    Private Sub RPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", tbl)
        cls.RefreshData("select * from departments", tbl1)
        cls.RefreshData("select * from jobs", tbl2)

        Employee.DataSource = tbl
        Employee.DisplayMember = "employee_name"
        Employee.ValueMember = "employee_id"

        job.DataSource = tbl2
        job.DisplayMember = "job_title"
        job.ValueMember = "job_id"

        dept.DataSource = tbl1
        dept.DisplayMember = "department_name"
        dept.ValueMember = "department_id"

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 1
        Dim tod As Date
        Dim fromd As Date
        tod = ToDate.Text
        fromd = FromDate.Text

        If attended_emps.Checked = False Then

            If byall.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
            ElseIf byemp.Checked = True Then

                If Employee.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الموظف")
                End If
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where employee_id=" & Employee.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
            ElseIf byjob.Checked = True Then
                If job.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الوظيفه")
                End If

                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where job_id=" & job.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt

            Else
                If dept.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الاداره")
                End If
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where department_id=" & dept.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "'"
                da.SelectCommand = cmd
                MyDs.Tables("report_employees_attendance").Clear()
                da.Fill(MyDs.Tables("report_employees_attendance"))
                rpt.SetDataSource(MyDs.Tables("report_employees_attendance"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
            End If
        Else
            If byall.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "' and leave_time is null"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
            ElseIf byemp.Checked = True Then
                If Employee.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الموظف")
                End If
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where employee_id=" & Employee.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "' and leave_time is null"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
            ElseIf byjob.Checked = True Then
                If job.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الوظيفه")
                End If

                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where job_id=" & job.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "' and leave_time is null"
                da.SelectCommand = cmd
                MyDs.Tables("report_departments_employees_jobs").Clear()
                da.Fill(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt

            Else

                If dept.SelectedValue = Nothing Then
                    cls.MsgExclamation("برجاء ادخل اسم الاداره")
                End If
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_employees_attendance where department_id=" & dept.SelectedValue & " and attend_date>='" & fromd.ToString("MM/dd/yyyy") & "' and attend_date<='" & tod.ToString("MM/dd/yyyy") & "' and leave_time is null"
                da.SelectCommand = cmd
                MyDs.Tables("report_employees_attendance").Clear()
                da.Fill(MyDs.Tables("report_employees_attendance"))
                rpt.SetDataSource(MyDs.Tables("report_employees_attendance"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                RMeals.ReportSource = rpt
            End If
        End If




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




    
    Private Sub byemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byemp.CheckedChanged
        If byemp.Checked = True Then
            Employee.Enabled = True
            dept.Enabled = False
            job.Enabled = False
        End If
    End Sub

    Private Sub bydept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bydept.CheckedChanged
        If bydept.Checked = True Then
            Employee.Enabled = False
            dept.Enabled = True
            job.Enabled = False
        End If
    End Sub

    Private Sub byjob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byjob.CheckedChanged
        If byjob.Checked = True Then
            Employee.Enabled = False
            dept.Enabled = False
            job.Enabled = True
        End If
    End Sub

    Private Sub byall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byall.CheckedChanged
        If byall.Checked = True Then
            Employee.Enabled = False
            dept.Enabled = False
            job.Enabled = False
        End If
    End Sub
End Class
