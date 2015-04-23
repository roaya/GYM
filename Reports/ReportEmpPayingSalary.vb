Public Class ReportEmpPayingSalary
    Dim rpt As New RptEmpPayingSlip
    Dim bsource As New BindingSource
    Private Sub RPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cls.RefreshData("employees")
        thename.DataSource = MyDs
        thename.DisplayMember = "employees.employee_name"
        thename.ValueMember = "employees.employee_id"


    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim n As Integer
        Dim the_date As Date
        Dim To_DSTR As String
        Dim From_DSTR As String
        the_date = TheDate.Text
        n = Date.DaysInMonth(TheDate.Value.Year, TheDate.Value.Month)
        To_DSTR = the_date.ToString("MM/" & n & "/yyyy")
        From_DSTR = the_date.ToString("MM/01/yyyy")


        cmd.CommandText = "select *,(select logo from app_preferences) as logo from report_pay_salary where employee_id=" & thename.SelectedValue & " and pay_date>'" & From_DSTR & "'" & " and pay_date<'" & To_DSTR & "'"
        da.SelectCommand = cmd
        MyDs.Tables("report_pay_salary").Clear()
        da.Fill(MyDs.Tables("report_pay_salary"))
        rpt.SetDataSource(MyDs.Tables("report_pay_salary"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        rpt.SetParameterValue("tod", To_DSTR)
        rpt.SetParameterValue("fromd", From_DSTR)
        RMeals.ReportSource = rpt
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