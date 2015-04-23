Public Class FrmCustomersAttendace
    Dim rpt As New RptCustomersAttendance
    Dim d1, d2 As Date
    Dim tbl As New GeneralDataSet.CustomersDataTable
    Dim tbl1 As New GeneralDataSet.EmployeesDataTable
    Dim tbl2 As New GeneralDataSet.SubscriptionsDataTable

    Private Sub FrmCustomersAttendace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from  customers", tbl)
        cls.RefreshData("select * from employees where job_id=1", tbl1)
        cls.RefreshData("select * from subscriptions", tbl2)

        CustID.DataSource = tbl
        CustID.DisplayMember = "Customer_Name"
        CustID.ValueMember = "Customer_ID"


        emp.DataSource = tbl1
        emp.DisplayMember = "employee_name"
        emp.ValueMember = "employee_id"


        subsc.DataSource = tbl2
        subsc.DisplayMember = "subscription_name"
        subsc.ValueMember = "subscription_id"

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        d1 = CDate(DateTimePicker1.Text)
        d2 = CDate(DateTimePicker2.Text)
        MyDs.Tables("Report_customers_attendance").Rows.Clear()

        If BySubsc.Checked = False Then
            If byall.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by Attend_Date"
                da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                rpt.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                crystalreportviewer1.ReportSource = rpt
                TabControl1.SelectTab(1)
            ElseIf RadCust.Checked = True Then
                If CustID.Text = "" Then
                    MsgBox("من فضلك اختر اسم العميل")
                Else

                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where customer_Id= " & CustID.SelectedValue & " and Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by Attend_Date"
                    da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                    rpt.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                    rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    crystalreportviewer1.ReportSource = rpt
                    TabControl1.SelectTab(1)
                End If
            ElseIf bycoach.Checked = True Then
                If emp.Text = "" Then
                    MsgBox("من فضلك اختر اسم المدرب")
                Else

                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where coach_id= " & emp.SelectedValue & " and Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' order by Attend_Date"
                    da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                    rpt.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                    rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    crystalreportviewer1.ReportSource = rpt
                    TabControl1.SelectTab(1)
                End If

            End If
        Else
            If subsc.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الاشتراك")
            End If


            If byall.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and subscription_id=" & subsc.SelectedValue & " order by Attend_Date"
                da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                rpt.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                crystalreportviewer1.ReportSource = rpt
                TabControl1.SelectTab(1)
            ElseIf RadCust.Checked = True Then
                If CustID.Text = "" Then
                    MsgBox("من فضلك اختر اسم العميل")
                Else

                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where customer_Id= " & CustID.SelectedValue & " and Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and subscription_id=" & subsc.SelectedValue & " order by Attend_Date"
                    da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                    rpt.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                    rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    crystalreportviewer1.ReportSource = rpt
                    TabControl1.SelectTab(1)
                End If
            ElseIf bycoach.Checked = True Then
                If emp.Text = "" Then
                    MsgBox("من فضلك اختر اسم المدرب")
                Else

                    cmd.CommandText = "select *,(select logo from app_preferences) as Logo from Report_Customers_Attendance where coach_id= " & emp.SelectedValue & " and Attend_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and subscription_id=" & subsc.SelectedValue & "order by Attend_Date"
                    da.Fill(MyDs.Tables("Report_Customers_Attendance"))
                    rpt.SetDataSource(MyDs.Tables("Report_Customers_Attendance"))
                    rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                    crystalreportviewer1.ReportSource = rpt
                    TabControl1.SelectTab(1)
                End If

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

    
    Private Sub BySubsc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BySubsc.CheckedChanged
        If BySubsc.Checked = True Then
            subsc.Enabled = True
        Else
            subsc.Enabled = False
        End If
    End Sub

    Private Sub byall_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles byall.CheckedChanged
        If byall.Checked = True Then
            emp.Enabled = False
            CustID.Enabled = False
        End If
    End Sub

    Private Sub RadCust_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCust.CheckedChanged
        If RadCust.Checked = True Then
            emp.Enabled = False
            CustID.Enabled = True
        End If
    End Sub

    Private Sub bycoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bycoach.CheckedChanged
        If bycoach.Checked = True Then
            emp.Enabled = True
            CustID.Enabled = False
        End If
    End Sub

End Class