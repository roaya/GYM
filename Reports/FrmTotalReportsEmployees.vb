Public Class frmtotalreportsemployees
    Dim d1, d2 As Date
    Dim RptEmps As New RptEmployee
    Dim RptCoach As New RptCoaches
    



    Dim TblEmp As New GeneralDataSet.EmployeesDataTable
    Dim TblCoach As New GeneralDataSet.EmployeesDataTable
    Dim TblDepts As New GeneralDataSet.DepartmentsDataTable
    Dim TblJobs As New GeneralDataSet.JobsDataTable
    Private Sub ReportEmployees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cls.RefreshData("select * from employees", TblEmp)
        cls.RefreshData("select * from employees where job_id=1", TblCoach)
        cls.RefreshData("select * from departments", TblDepts)
        cls.RefreshData("select * from jobs", TblJobs)


        emp0.DataSource = TblEmp
        emp0.DisplayMember = "employee_name"
        emp0.ValueMember = "employee_id"

        dept0.DataSource = TblDepts
        dept0.DisplayMember = "department_name"
        dept0.ValueMember = "department_id"

        job0.DataSource = TblJobs
        job0.DisplayMember = "job_Title"
        job0.ValueMember = "job_id"

        coach0.DataSource = TblCoach
        coach0.DisplayMember = "employee_name"
        coach0.ValueMember = "employee_id"

    End Sub
    '===================================================Employees and Coaches

    Private Sub ByAll0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If byall0.Checked = True Then
            emp0.Enabled = False
            coach0.Enabled = False
            dept0.Enabled = False
            job0.Enabled = False
            coachg.Enabled = False
        End If
    End Sub

    Private Sub ByEmp0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByEmp0.CheckedChanged
        If ByEmp0.Checked = True Then
            Emp0.Enabled = True
            Coach0.Enabled = False
            Dept0.Enabled = False
            Job0.Enabled = False
            CoachG.Enabled = False
        End If
    End Sub
    Private Sub byjob0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byjob0.CheckedChanged
        If byjob0.Checked = True Then
            emp0.Enabled = False
            coach0.Enabled = False
            dept0.Enabled = False
            job0.Enabled = True
            coachg.Enabled = False
        End If
    End Sub
    Private Sub ByDepartment0_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByDepartment0.CheckedChanged
        If ByDepartment0.Checked = True Then
            Emp0.Enabled = False
            Coach0.Enabled = False
            Dept0.Enabled = True
            Job0.Enabled = False
            CoachG.Enabled = False
        End If
    End Sub

    Private Sub ByCoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycoach0.CheckedChanged
        If bycoach0.Checked = True Then
            emp0.Enabled = False
            coach0.Enabled = True
            dept0.Enabled = False
            job0.Enabled = False
            coachg.Enabled = True
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MyDs.Tables("Query_employees").Clear()
        If byall0.Checked = True Then

            cmd.CommandText = "select * from Query_employees"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Query_employees"))
            RptEmps.SetDataSource(MyDs.Tables("Query_employees"))
            RptEmps.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptEmps

        ElseIf byemp0.Checked = True Then
            If emp0.SelectedValue = Nothing Then
                cls.MsgComplete()
                Exit Sub
            End If

            cmd.CommandText = "select * from Query_employees where employee_id=" & emp0.SelectedValue
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Query_employees"))
            RptEmps.SetDataSource(MyDs.Tables("Query_employees"))
            RptEmps.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptEmps



        ElseIf bydepartment0.Checked = True Then
            If dept0.SelectedValue = Nothing Then
                cls.MsgComplete()
                Exit Sub
            End If

            cmd.CommandText = "select * from Query_employees where department_id=" & dept0.SelectedValue
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Query_employees"))
            RptEmps.SetDataSource(MyDs.Tables("Query_employees"))
            RptEmps.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptEmps


        ElseIf byjob0.Checked = True Then
            If job0.SelectedValue = Nothing Then
                cls.MsgComplete()
                Exit Sub
            End If

            cmd.CommandText = "select * from Query_employees where job_id=" & job0.SelectedValue
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Query_employees"))
            RptEmps.SetDataSource(MyDs.Tables("Query_employees"))
            RptEmps.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            CrystalReportViewer2.ReportSource = RptEmps


        ElseIf bycoach0.Checked = True Then
            d1 = fromdate3.Text
            d2 = todate3.Text
            If fromdate3.Text = "" Or todate3.Text = "" Or coach0.SelectedValue = Nothing Then
                cls.MsgComplete()
                Exit Sub
            End If

            cmd.CommandText = "select * from Query_employees where employee_id=" & coach0.SelectedValue
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Query_employees"))
            RptCoach.SetDataSource(MyDs.Tables("Query_employees"))
            RptCoach.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))

            cmd.CommandText = "select count(*) from customers_attendance where coach_id=" & emp0.SelectedValue & " and attend_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            RptCoach.SetParameterValue("p_Customers", cmd.ExecuteScalar)

            cmd.CommandText = "select isnull(sum(hours_Diff),0)/60 from attendance where employee_id=" & emp0.SelectedValue & " and attend_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            RptCoach.SetParameterValue("p_attendance", cmd.ExecuteScalar)

            cmd.CommandText = "select count(*) from subscriptions_details where coach_id=" & emp0.SelectedValue & " and start_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            RptCoach.SetParameterValue("p_Subscriptions", cmd.ExecuteScalar)

            cmd.CommandText = "select count(*) from special_Subscriptions where trainer_id=" & emp0.SelectedValue & " and special_Subscription_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            RptCoach.SetParameterValue("P_Special", cmd.ExecuteScalar)

            RptCoach.SetParameterValue("from_D", d1.ToString)

            RptCoach.SetParameterValue("to_D", d2.ToString)

            CrystalReportViewer2.ReportSource = RptCoach

        End If
        TabControl1.SelectedIndex = 5
    End Sub

    '========================================================================Employees Attendance And Vacations

    
    
    
End Class