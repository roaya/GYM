Public Class ReportPaySalary


    Dim rpt As New RptPaySalary
    Dim bsource As New BindingSource
    Private Sub RPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls.RefreshData("departments")
        cls.RefreshData("employees")
        thename.DataSource = MyDs
        thename.DisplayMember = "departments.department_name"
        thename.ValueMember = "departments.department_id"
        EmpName.DataSource = MyDs
        EmpName.DisplayMember = "employees.employee_name"
        EmpName.ValueMember = "employees.employee_id"

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim To_D As Date
        Dim From_D As Date
        To_D = toDate.Text
        From_D = fromdate.Text

        If ByDept.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_pay_salary where department_id=" & thename.SelectedValue & " and pay_date between '" & From_D.ToString("MM/dd/yyyy") & "'" & " and '" & To_D.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("report_pay_salary").Clear()
            da.Fill(MyDs.Tables("report_pay_salary"))
            rpt.SetDataSource(MyDs.Tables("report_pay_salary"))
            RMeals.ReportSource = rpt
        ElseIf ByEmp.Checked = True Then
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_pay_salary where employee_id=" & EmpName.SelectedValue & " and pay_date between '" & From_D.ToString("MM/dd/yyyy") & "' and '" & To_D.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("report_pay_salary").Clear()
            da.Fill(MyDs.Tables("report_pay_salary"))
            rpt.SetDataSource(MyDs.Tables("report_pay_salary"))
            RMeals.ReportSource = rpt
        Else
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_pay_salary where pay_date between '" & From_D.ToString("MM/dd/yyyy") & "' and '" & To_D.ToString("MM/dd/yyyy") & "'"
            da.SelectCommand = cmd
            MyDs.Tables("report_pay_salary").Clear()
            da.Fill(MyDs.Tables("report_pay_salary"))
            rpt.SetDataSource(MyDs.Tables("report_pay_salary"))
            rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
            RMeals.ReportSource = rpt
        End If

        TabControl1.SelectTab(1)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub byname_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByDept.CheckedChanged
        thename.Enabled = True
        EmpName.Enabled = False
    End Sub

    Private Sub byall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByEmp.CheckedChanged
        thename.Enabled = False
        EmpName.Enabled = True
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

  
    Private Sub ByAllEmps_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByAllEmps.CheckedChanged
        thename.Enabled = False
        EmpName.Enabled = False
    End Sub
End Class

