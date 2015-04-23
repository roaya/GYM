Public Class Statistics
    Dim TblEmps As New GeneralDataSet.EmployeesDataTable
    Dim TblCoaches As New GeneralDataSet.EmployeesDataTable
    Dim TblSubsc As New GeneralDataSet.SubscriptionsDataTable
    Dim TblCat As New GeneralDataSet.Subscriptions_CategoriesDataTable
    Dim TblSpecial As New GeneralDataSet.Special_CategoriesDataTable

    Dim D1, D2 As Date

    Private Sub Statistics_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.RefreshData("select * from employees", TblEmps)
        cls.RefreshData("select * from employees where job_id=1", TblCoaches)
        cls.RefreshData("select * from subscriptions", TblSubsc)
        cls.RefreshData("select * from subscriptions_categories", TblCat)
        cls.RefreshData("select * from special_categories", TblSpecial)

        Emps.DataSource = TblEmps
        Emps.DisplayMember = "employee_name"
        Emps.ValueMember="employee_id"

        CustsCoach.DataSource = TblCoaches
        CustsCoach.DisplayMember = "employee_name"
        CustsCoach.ValueMember = "employee_id"

        Coachs.DataSource = TblCoaches
        Coachs.DisplayMember = "employee_name"
        Coachs.ValueMember = "employee_id"

        SpecialCoach.DataSource = TblCoaches
        SpecialCoach.DisplayMember = "employee_name"
        SpecialCoach.ValueMember = "employee_id"

        CustsSubsc.DataSource = TblSubsc
        CustsSubsc.DisplayMember = "subscription_name"
        CustsSubsc.ValueMember = "subscription_id"

        Subsc.DataSource = TblSubsc
        Subsc.DisplayMember = "subscription_name"
        Subsc.ValueMember = "subscription_id"

        Special.DataSource = TblSpecial
        Special.DisplayMember = "category_name"
        Special.ValueMember = "special_categories_id"

        Cat.DataSource = TblCat
        Cat.DisplayMember = "category_Name"
        Cat.ValueMember = "category_id"

       





    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        D1 = FromDate.Text
        D2 = ToDate.Text
        If all.Checked = True Then
            cmd.CommandText = "select count(*) from customers_attendance where attend_Date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : عدد حضور العملاء في هذه الفتره ")

        ElseIf CustByCoach.Checked = True Then
            If CustsCoach.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم المدرب")
                Exit Sub
            End If
            cmd.CommandText = "select count(*) from customers_attendance where coach_id=" & CustsCoach.SelectedValue & " and attend_Date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : عدد حضور العملاء على المدرب")
        ElseIf CustBySubsc.Checked = True Then
            If CustsSubsc.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الاشتراك")
                Exit Sub
            End If

            cmd.CommandText = "select count(*) from customers_attendance ca,subscriptions_details sd where sd.subscription_detail_id=ca.subscription_id and sd.subscription_id=" & CustsSubsc.SelectedValue & " and attend_Date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & ": عدد حضور العملاء على الاشتراك")

        End If
    End Sub






    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        D1 = FromDate.Text
        D2 = ToDate.Text
      
        If Emps.SelectedValue = Nothing Then
            cls.MsgExclamation("برجاء ادخل اسم الموظف")
            Exit Sub
        End If
        cmd.CommandText = "select isnull(sum(hours_diff/60),0) from attendance where employee_id=" & Emps.SelectedValue & " and attend_Date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
        cls.MsgInfo(cmd.ExecuteScalar & " : عدد ساعات حضور الموظف في الفترة المحدده ")



    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        D1 = FromDate.Text
        D2 = ToDate.Text
        If all.Checked = True Then
            cmd.CommandText = "select count(*) from subscriptions_details where start_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : عدد الاشتراكات المسجله في هذه الفتره")
        ElseIf ByCat.Checked = True Then
            If Cat.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم البند")
                Exit Sub
            End If

            cmd.CommandText = "select count(*) from subscriptions_details sd,subscriptions s where s.subscription_id=sd.subscription_id and s.category_id=" & Cat.SelectedValue & "and start_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : عدد الاشتراكات المسجله على البند  ")

        ElseIf ByCoach.Checked = True Then
            If Coachs.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم المدرب")
                Exit Sub
            End If
            cmd.CommandText = "select count(*) from subscriptions_details where coach_id=" & Coachs.SelectedValue & " and start_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : عدد الاشتراكات المسجله على هذا المدرب  ")

        ElseIf BySubsc.Checked = True Then
            If Subsc.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الاشتراك")
                Exit Sub
            End If

            cmd.CommandText = "select count(*) from subscriptions_details where subscription_id=" & Subsc.SelectedValue & " and start_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & ": عدد حضور العملاء على الاشتراك")

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        D1 = FromDate.Text
        D2 = ToDate.Text
        If all.Checked = True Then
            cmd.CommandText = "select isnull(sum(paid),0) from subscriptions_details where start_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & ": اجمالي المبلغ المدفوع على جميع الاشتراكات في خلال الفتره")
        ElseIf ByCat.Checked = True Then
            If Cat.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم البند")
                Exit Sub
            End If

            cmd.CommandText = "select isnull(sum(paid),0) from subscriptions_details sd,subscriptions s where s.subscription_id=sd.subscription_id and s.category_id=" & Cat.SelectedValue & "and start_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & ": اجمالي المبلغ المدفوع على البند")

        ElseIf ByCoach.Checked = True Then
            If Coachs.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم المدرب")
                Exit Sub
            End If
            cmd.CommandText = "select isnull(sum(paid),0) from subscriptions_details where coach_id=" & Coachs.SelectedValue & " and start_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & ": اجمالي المبلغ المدفوع على الاشتراكات الخاصه للمدرب")

        ElseIf BySubsc.Checked = True Then
            If Subsc.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم الاشتراك")
                Exit Sub
            End If

            cmd.CommandText = "select isnull(sum(paid),0) from subscriptions_details where subscription_id=" & Subsc.SelectedValue & " and start_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & ": اجمالي المبلغ المدفوع على الاشتراك")

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        D1 = FromDate.Text
        D2 = ToDate.Text
        If all.Checked = True Then
            cmd.CommandText = "select count(*) from special_subscriptions where special_subscription_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : عدد الجلسات الخاصه المسجله في هذه الفتره ")

        ElseIf BySpecialCoach.Checked = True Then
            If SpecialCoach.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم المدرب")
                Exit Sub
            End If
            cmd.CommandText = "select count(*) from special_subscriptions where trainer_id=" & SpecialCoach.SelectedValue & " and special_subscription_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : عدد الجلسات الخاصه المسجله على هذا المدرب")
        ElseIf BySpecial.Checked = True Then
            If Special.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل نوع الجلسه الخاصه")
                Exit Sub
            End If

            cmd.CommandText = "select count(*) from special_subscriptions where special_categories_id=" & Special.SelectedValue & " and special_subscription_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & ": عدد الجلسات الخاصه المسجله للبند")

        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        D1 = FromDate.Text
        D2 = ToDate.Text
        If all.Checked = True Then
            cmd.CommandText = "select isnull(sum(value),0) from special_subscriptions where special_subscription_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : اجمالي قيمة الجلسات الخاصه في هذه الفتره ")

        ElseIf BySpecialCoach.Checked = True Then
            If SpecialCoach.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل اسم المدرب")
                Exit Sub
            End If
            cmd.CommandText = "select isnull(sum(value),0) from special_subscriptions where trainer_id=" & SpecialCoach.SelectedValue & " and special_subscription_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & " : اجمالي قيمة الجلسات الخاصه على هذا المدرب")
        ElseIf BySpecial.Checked = True Then
            If Special.SelectedValue = Nothing Then
                cls.MsgExclamation("برجاء ادخل نوع الجلسه الخاصه")
                Exit Sub
            End If

            cmd.CommandText = "select isnull(sum(value),0) from special_subscriptions where special_categories_id=" & Special.SelectedValue & " and special_subscription_date between'" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "'"
            cls.MsgInfo(cmd.ExecuteScalar & ": اجمالي قيمة الجلسات الخاصه للبند")

        End If
    End Sub

    Private Sub all_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles all.CheckedChanged
        If all.Checked = True Then
            Customers.Enabled = False
            Subscriptions.Enabled = False
            SpecialSubscriptions.Enabled = False
        Else
            Customers.Enabled = True
            Subscriptions.Enabled = True
            SpecialSubscriptions.Enabled = True
        End If
    End Sub

    Private Sub CustByCoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustByCoach.CheckedChanged
        If CustByCoach.Checked = True Then
            CustsCoach.Enabled = True
            CustsSubsc.Enabled = False
        End If
    End Sub

    Private Sub CustBySubsc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustBySubsc.CheckedChanged
        If CustBySubsc.Checked = True Then
            CustsCoach.Enabled = False
            CustsSubsc.Enabled = True
        End If
    End Sub

    Private Sub BySpecial_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BySpecial.CheckedChanged
        If BySpecial.Checked = True Then
            Special.Enabled = True
            SpecialCoach.Enabled = False
        End If
    End Sub

    Private Sub BySpecialCoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BySpecialCoach.CheckedChanged
        If BySpecialCoach.Checked = True Then
            Special.Enabled = False
            SpecialCoach.Enabled = True
        End If
    End Sub

    Private Sub ByCat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByCat.CheckedChanged
        If ByCat.Enabled = True Then
            Cat.Enabled = True
            Coachs.Enabled = False
            Subsc.Enabled = False
        End If
    End Sub

    Private Sub BySubsc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BySubsc.CheckedChanged
        If BySubsc.Enabled = True Then
            Cat.Enabled = False
            Coachs.Enabled = False
            Subsc.Enabled = True
        End If
    End Sub

    Private Sub ByCoach_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByCoach.CheckedChanged
        If ByCoach.Enabled = True Then
            Cat.Enabled = False
            Coachs.Enabled = True
            Subsc.Enabled = False
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            D1 = FromDate.Text
            D2 = ToDate.Text
            cmd.CommandText = "select employee_name from employees e,Attendance a where e.Employee_Id=a.employee_id group by employee_name having sum(hours_diff)=(SELECT distinct  max(sum(Hours_Diff)) OVER () FROM attendance where attend_Date between '" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "' GROUP BY Employee_ID)"

            If cmd.ExecuteScalar = Nothing Then
                cls.MsgExclamation("عفوا لم يحضر احد في هذه الفتره")
                Exit Sub
            End If
            MessageBox.Show(cmd.ExecuteScalar, "الموظف الأكثر حضورا", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch
        End Try
    End Sub


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            D1 = FromDate.Text
            D2 = ToDate.Text
            cmd.CommandText = "select Customer_name from customers c,Customers_attendance ca where ca.customer_id=c.customer_id group by customer_name having count(*)=(SELECT distinct  max(count(*)) OVER () FROM customers_attendance where attend_Date between '" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "' GROUP BY customer_ID)"

            If cmd.ExecuteScalar = Nothing Then
                cls.MsgExclamation("عفوا لم يحضر احد في هذه الفتره")
                Exit Sub
            End If
            MessageBox.Show(cmd.ExecuteScalar, "العميل الأكثر حضورا", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch
        End Try
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            D1 = FromDate.Text
            D2 = ToDate.Text
            cmd.CommandText = "select Employee_name from employees e,Customers_attendance ca where ca.coach_id=e.employee_id group by employee_name having count(*)=(SELECT distinct  max(count(*)) OVER () FROM customers_attendance where attend_Date between '" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "' GROUP BY coach_ID)"

            If cmd.ExecuteScalar = Nothing Then
                cls.MsgExclamation("عفوا لم يحضر احد في هذه الفتره")
                Exit Sub
            End If
            MessageBox.Show(cmd.ExecuteScalar, "المدرب صاحب اكبر حضور من العملاء", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            D1 = FromDate.Text
            D2 = ToDate.Text
            cmd.CommandText = "select Subscription_name from subscriptions s,subscriptions_details sd where sd.subscription_id=s.subscription_id group by subscription_name having sum(paid+remaining)=(SELECT distinct  max(sum(paid+remaining)) OVER () FROM subscriptions_details where start_date between '" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "' GROUP BY subscription_id)"

            If cmd.ExecuteScalar = Nothing Then
                cls.MsgExclamation("عفوا لا يوجد اي اشتراكات في هذه الفتره")
                Exit Sub
            End If
            MessageBox.Show(cmd.ExecuteScalar, "الاشتراك صاحب اكبر استهلاك", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch
        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            D1 = FromDate.Text
            D2 = ToDate.Text
            cmd.CommandText = "select employee_name from employees e,subscriptions_details sd where sd.coach_id=e.employee_id group by employee_name having count(*)=(SELECT distinct  max(count(*)) OVER () FROM subscriptions_details where start_date between '" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "' and coach_id is not null GROUP BY coach_id)"

            If cmd.ExecuteScalar = Nothing Then
                cls.MsgExclamation("عفوا لا يوجد اي اشتراكات خاصه في هذه الفتره")
                Exit Sub
            End If
            MessageBox.Show(cmd.ExecuteScalar, "المدرب صاحب اكبر عدد من الاشتراكات الخاصه", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            D1 = FromDate.Text
            D2 = ToDate.Text
            cmd.CommandText = "select category_name from special_subscriptions s,special_categories sc where sc.special_categories_id=s.special_categories_id group by category_name having sum(s.value)=(SELECT distinct  max(sum(value)) OVER () FROM special_subscriptions where special_subscription_date between '" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "' GROUP BY special_categories_id)"

            If cmd.ExecuteScalar = Nothing Then
                cls.MsgExclamation("عفوا لا يوجد اي جلسات خاصه في هذه الفتره")
                Exit Sub
            End If
            MessageBox.Show(cmd.ExecuteScalar, "الجلسة الخاصه صاحبة اكبر استهلاك", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch
        End Try
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Try
            D1 = FromDate.Text
            D2 = ToDate.Text
            Dim n As Integer
            cmd.CommandText = "select employee_name from special_subscriptions s,employees e where s.trainer_id=e.employee_id group by employee_name having count(*)=(SELECT distinct  max(count(*)) OVER () FROM special_subscriptions where special_subscription_date between '" & D1.ToString("MM/dd/yyyy") & "' and '" & D2.ToString("MM/dd/yyyy") & "' GROUP BY trainer_id)"

            If cmd.ExecuteScalar = Nothing Then
                cls.MsgExclamation("عفوا لا يوجد اي جلسات خاصه في هذه الفتره")
                Exit Sub
            End If
            MessageBox.Show(cmd.ExecuteScalar, "المدرب صاحب اكبر عدد جلسات خاصه", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch
        End Try
    End Sub
End Class