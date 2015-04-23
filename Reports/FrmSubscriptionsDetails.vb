Public Class FrmSubscriptionsDetails
    Dim rpt As New RptSubscriptionsDetails
    Dim tbl1 As New GeneralDataSet.CustomersDataTable
    Dim tbl2 As New GeneralDataSet.EmployeesDataTable
    Dim tbl3 As New GeneralDataSet.SubscriptionsDataTable
    Dim tbl4 As New GeneralDataSet.Subscriptions_CategoriesDataTable
    Dim tbl5 As New GeneralDataSet.EmployeesDataTable
    Dim type As String
    Dim d1, d2 As Date

    Private Sub FrmSubscriptionsDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("Select * from customers", tbl1)
        cls.RefreshData("Select * from Employees", tbl2)
        cls.RefreshData("Select * from subscriptions", tbl3)
        cls.RefreshData("Select * from subscriptions_Categories", tbl4)
        cls.RefreshData("select * from employees e,jobs j where e.job_id=j.job_id and j.Job_Title=N'مدرب'", tbl5)

        coach.DataSource = tbl5
        coach.DisplayMember = "employee_name"
        coach.ValueMember = "employee_id"


        Custid.DataSource = tbl1
        Custid.DisplayMember = "Customer_Name"
        Custid.ValueMember = "customer_ID"

        EmpID.DataSource = tbl2
        EmpID.DisplayMember = "employee_Name"
        EmpID.ValueMember = "employee_ID"

        SubscriptionID.DataSource = tbl3
        SubscriptionID.DisplayMember = "subscription_Name"
        SubscriptionID.ValueMember = "subscription_ID"

        CategoryID.DataSource = tbl4
        CategoryID.DisplayMember = "category_Name"
        CategoryID.ValueMember = "category_ID"
    End Sub

    Private Sub RadCust_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCust.CheckedChanged
        If RadCust.Checked = True Then
            Custid.Enabled = True
            EmpID.Enabled = False
            coach.Enabled = False
            SubscriptionID.Enabled = False
            CategoryID.Enabled = False
        End If
    End Sub

    Private Sub Rademp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rademp.CheckedChanged
        If Rademp.Checked = True Then
            Custid.Enabled = False
            EmpID.Enabled = True
            coach.Enabled = False
            SubscriptionID.Enabled = False
            CategoryID.Enabled = False
        End If
    End Sub

    Private Sub RadSub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadSub.CheckedChanged
        If RadSub.Checked = True Then
            Custid.Enabled = False
            EmpID.Enabled = False
            coach.Enabled = False
            SubscriptionID.Enabled = True
            CategoryID.Enabled = False
        End If
    End Sub

    Private Sub RadCategory_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCategory.CheckedChanged
        If RadCategory.Checked = True Then
            Custid.Enabled = False
            EmpID.Enabled = False
            coach.Enabled = False
            SubscriptionID.Enabled = False
            CategoryID.Enabled = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        d1 = CDate(fromdate.Text)
        d2 = CDate(todate.Text)
        If Open.Checked = True Then
            Type = "مفتوحه"
        ElseIf Closed.Checked = True Then
            type = "مغلقه"
        ElseIf Ret.Checked = True Then
            type = "مرتجع"
        Else
            type = "All"
        End If

        MyDs.Tables("Report_Subscriptions_Details").Rows.Clear()

        If fromdate.Value = Nothing Or todate.Value = Nothing Then
            MsgBox("برجاء ادخل الفتره")
            Exit Sub
        End If

        If type <> "All" Then
            If RadAll.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"

            ElseIf RadCust.Checked = True Then
                If Custid.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم العميل")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where Customer_ID= " & Custid.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status='" & type & "'"

                End If



            ElseIf Rademp.Checked = True Then
                If EmpID.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم الموظف")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where employee_id= " & EmpID.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"

                End If



            ElseIf RadCoach.Checked = True Then
                If coach.SelectedValue = Nothing Then
                    MsgBox("برجاء ادخل اسم الموظف")
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where coach_id= " & coach.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"
                End If


            ElseIf RadSub.Enabled = True Then
                If SubscriptionID.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم الاشتراك")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where subscription_id= " & SubscriptionID.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"

                End If


            ElseIf RadCategory.Checked = True Then
                If CategoryID.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر نوع الاشتراك")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where category_id= " & CategoryID.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and Subscription_Status=N'" & type & "'"
                End If

            End If
        Else


            If RadAll.Checked = True Then
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

            ElseIf RadCust.Checked = True Then
                If Custid.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم العميل")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where Customer_ID= " & Custid.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

                End If



            ElseIf Rademp.Checked = True Then
                If EmpID.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم الموظف")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where employee_id= " & EmpID.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

                End If



            ElseIf RadCoach.Checked = True Then
                If coach.SelectedValue = Nothing Then
                    MsgBox("برجاء ادخل اسم الموظف")
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where coach_id= " & coach.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                End If


            ElseIf RadSub.Enabled = True Then
                If SubscriptionID.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر اسم الاشتراك")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where subscription_id= " & SubscriptionID.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"

                End If


            ElseIf RadCategory.Checked = True Then
                If CategoryID.SelectedValue = Nothing Then
                    MsgBox("من فضلك اختر نوع الاشتراك")
                    Exit Sub
                Else
                    cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Subscriptions_Details where category_id= " & CategoryID.SelectedValue & " and start_date between N'" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                End If

            End If


        End If


        da.Fill(MyDs.Tables("Report_Subscriptions_Details"))
        rpt.SetDataSource(MyDs.Tables("Report_Subscriptions_Details"))
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


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadAll.CheckedChanged
        If RadAll.Checked = True Then
            Custid.Enabled = False
            EmpID.Enabled = False
            coach.Enabled = False
            SubscriptionID.Enabled = False
            CategoryID.Enabled = False
        End If
    End Sub

    Private Sub RadCoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCoach.CheckedChanged
        If RadCoach.Checked = True Then
            Custid.Enabled = False
            EmpID.Enabled = False
            coach.Enabled = True
            SubscriptionID.Enabled = False
            CategoryID.Enabled = False
        End If
        
    End Sub

 
End Class

