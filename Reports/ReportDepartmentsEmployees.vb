Public Class ReportDepartmentsEmployees
    Dim rpt As New RptDepartmentsEmployees
    Dim bsource As New BindingSource
    Dim tbl1 As New GeneralDataSet.JobsDataTable
    Dim tbl2 As New GeneralDataSet.EmployeesDataTable
    Dim tbl3 As New GeneralDataSet.DepartmentsDataTable
    Private Sub RPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", tbl2)
        cls.RefreshData("select * from departments", tbl3)
        cls.RefreshData("select * from jobs", tbl1)

        Job.DataSource = tbl1
        Job.DisplayMember = "job_title"
        Job.ValueMember = "job_id"

        Employee.DataSource = tbl2
        Employee.DisplayMember = "employee_name"
        Employee.ValueMember = "employee_id"

        Dept.DataSource = tbl3
        Dept.DisplayMember = "department_name"
        Dept.ValueMember = "department_id"

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectedIndex = 1

        If bydept.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_departments_employees_jobs where department_id=" & Dept.SelectedValue
            da.SelectCommand = cmd
            MyDs.Tables("report_departments_employees_jobs").Clear()
            da.Fill(MyDs.Tables("report_departments_employees_jobs"))
            rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RMeals.ReportSource = rpt

        ElseIf byemp.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_departments_employees_jobs where restaurant_id=" & Employee.SelectedValue
            da.SelectCommand = cmd
            MyDs.Tables("report_departments_employees_jobs").Clear()
            da.Fill(MyDs.Tables("report_departments_employees_jobs"))
            rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RMeals.ReportSource = rpt
        ElseIf byjob.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_departments_employees_jobs where job_id=" & Job.SelectedValue
            da.SelectCommand = cmd
            MyDs.Tables("report_departments_employees_jobs").Clear()
            da.Fill(MyDs.Tables("report_departments_employees_jobs"))
            rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RMeals.ReportSource = rpt
        Else
            cmd.CommandText = "select *,(select logo from app_preferences) as Logo from report_departments_employees_jobs where basic_salary>" & BasicSalary.Value
            da.SelectCommand = cmd
            MyDs.Tables("report_departments_employees_jobs").Clear()
            da.Fill(MyDs.Tables("report_departments_employees_jobs"))
            rpt.SetDataSource(MyDs.Tables("report_departments_employees_jobs"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RMeals.ReportSource = rpt
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




    Private Sub bydept_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bydept.CheckedChanged
        Employee.Enabled = False
        BasicSalary.Enabled = False
        Dept.Enabled = True
        Job.Enabled = False
    End Sub

    Private Sub byemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byemp.CheckedChanged
        Employee.Enabled = True
        BasicSalary.Enabled = False
        Dept.Enabled = False
        Job.Enabled = False
    End Sub

    Private Sub bysalary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bysalary.CheckedChanged
        Employee.Enabled = False
        BasicSalary.Enabled = True
        Dept.Enabled = False
        Job.Enabled = False
    End Sub

    Private Sub byjob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byjob.CheckedChanged
        Employee.Enabled = False
        BasicSalary.Enabled = False
        Dept.Enabled = False
        Job.Enabled = True
    End Sub
End Class