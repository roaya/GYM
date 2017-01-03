Public Class PaySalary

    Dim d1, d2, d3 As Date
    Dim b As Boolean = False
    Dim AttValue As Double
    Dim ExtraSubsc As Decimal
    Private Sub PaySalary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            cls.RefreshData("Employees")
            cls.RefreshData("Pay_Salary")

            DataGridView1.DataSource = MyDs.Tables("Pay_Salary")
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "تاريخ الدفع"
            DataGridView1.Columns(3).HeaderText = "المرتب الاساسي"
            DataGridView1.Columns(4).HeaderText = "المرتب المتغير"
            DataGridView1.Columns(5).HeaderText = "اضافي الجلسات"
            DataGridView1.Columns(6).HeaderText = "المكافأة"
            DataGridView1.Columns(7).HeaderText = "قيمة الخصم"
            DataGridView1.Columns(8).HeaderText = "قيمة خصم الغياب"
            DataGridView1.Columns(9).HeaderText = "قيمة السلفه"
            DataGridView1.Columns(10).HeaderText = "الساعات الاضافيه"
            DataGridView1.Columns(11).HeaderText = "قيمة البدلات"
            DataGridView1.Columns(12).HeaderText = "نسبة الحضور"
            DataGridView1.Columns(13).HeaderText = "الجلسات الخاصه"
            DataGridView1.Columns(14).HeaderText = "الاشتراكات"
            DataGridView1.Columns(15).HeaderText = "عدد الجلسات"
            DataGridView1.Columns(16).HeaderText = "صافي المرتب"
            DataGridView1.Columns(17).HeaderText = "ملاحظات"

            EmployeeID.DataSource = MyDs
            EmployeeID.DisplayMember = "Employees.Employee_Name"
            EmployeeID.ValueMember = "Employees.Employee_ID"

            b = True

        Catch ex As Exception
            cls.WriteError(ex.Message, "Pay salary")
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            If b = True Then
                Dim DayValue As Double = 0
                Dim AbsentVal As Double = 0

                If Not EmployeeID.Text = "" Then

                    cmd.CommandText = "select isnull(sum(Basic_Salary),0) from Employees where Employee_ID = " & EmployeeID.SelectedValue
                    BasicSalary.Text = cmd.ExecuteScalar()

                    cmd.CommandText = "select isnull(sum(Variable_Salary),0) from Employees where Employee_ID = " & EmployeeID.SelectedValue
                    VarSalary.Text = cmd.ExecuteScalar()

                    DayValue = BasicSalary.Text / Date.DaysInMonth(CInt(PayMonth.Value.Year), CInt(PayMonth.Value.Month))
                    d1 = "01/" & PayMonth.Text
                    d2 = Date.DaysInMonth(CInt(PayMonth.Value.Year), CInt(PayMonth.Value.Month)) & "/" & PayMonth.Text


                    cmd.CommandText = "select job_id from employees where employee_id = " & EmployeeID.SelectedValue
                    If cmd.ExecuteScalar = 1 Then
                        cmd.CommandText = "select dbo.Get_Employee_Salary(" & EmployeeID.SelectedValue & ", '" & d1.ToString("MM/dd/yyyy") & "' , 'attend_discounts')"
                        AbsentValue.Text = cmd.ExecuteScalar

                        cmd.CommandText = "SELECT dbo.Get_Special_Sub_Value(" & EmployeeID.SelectedValue & ",'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
                        SpeSubValue.Text = cmd.ExecuteScalar

                        cmd.CommandText = "select dbo.Get_Employee_Salary(" & EmployeeID.SelectedValue & ", '" & d1.ToString("MM/dd/yyyy") & "' , 'attend_percent')"
                        If cmd.ExecuteScalar > 0 Then
                            AttValueTxt.ForeColor = Color.Black
                        Else
                            AttValueTxt.ForeColor = Color.Red
                        End If
                        AttValueTxt.Text = cmd.ExecuteScalar & " %"


                        cmd.CommandText = "select dbo.Get_Employee_Salary(" & EmployeeID.SelectedValue & ", '" & d1.ToString("MM/dd/yyyy") & "' , 'no_custs')"
                        NumSubscriptions.Text = cmd.ExecuteScalar

                        cmd.CommandText = "select dbo.Get_Employee_Salary(" & EmployeeID.SelectedValue & ", '" & d1.ToString("MM/dd/yyyy") & "' , 'attend_rewards')"
                        AddedHours.Text = cmd.ExecuteScalar

                        cmd.CommandText = "select dbo.Get_Employee_Salary(" & EmployeeID.SelectedValue & ", '" & d1.ToString("MM/dd/yyyy") & "' , 'custs_cash')"
                        Dim result = cmd.ExecuteScalar
                        If result > 0 Then
                            ExtraSubscription.ForeColor = Color.Black
                            NumSubscriptions.ForeColor = Color.Black
                            ExtraSubsc = result
                            ExtraSubscription.Text = result
                        Else
                            ExtraSubscription.ForeColor = Color.Red
                            NumSubscriptions.ForeColor = Color.Red
                            ExtraSubsc = result
                            ExtraSubscription.Text = result * (-1)
                        End If


                        cmd.CommandText = "select dbo.Get_Employee_Salary(" & EmployeeID.SelectedValue & ", '" & d1.ToString("MM/dd/yyyy") & "' , 'subscriptions')"
                        subsc.Text = cmd.ExecuteScalar

                    Else
                        AddedHours.Text = 0
                        SpeSubValue.Text = 0
                        NumSubscriptions.Text = 0
                        AttValueTxt.Text = 0
                        ExtraSubscription.Text = 0
                        subsc.Text = 0
                        '========================================
                        AbsentVal = 0
                        For i As Integer = 1 To Date.DaysInMonth(CInt(PayMonth.Value.Year), CInt(PayMonth.Value.Month))
                            d3 = i & "/" & PayMonth.Text

                            cmd.CommandText = "select count(*) from Attendance where Attend_Date = '" & d3.ToString("MM/dd/yyyy") & "'"
                            If cmd.ExecuteScalar <= 0 Then
                                cmd.CommandText = "select count(*) from Employees_Vacations where '" & d3.ToString("MM/dd/yyyy") & "' BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and employee_id = " & EmployeeID.SelectedValue
                                If cmd.ExecuteScalar <= 0 Then
                                    AbsentVal = AbsentVal + DayValue
                                End If
                            End If
                        Next
                        AbsentValue.Text = AbsentVal
                        '========================================
                    End If

                    cmd.CommandText = "select isnull(sum(reward_value),0) from Employees_rewards where employee_id = " & EmployeeID.SelectedValue & " and reward_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    EmpRewards.Text = cmd.ExecuteScalar

                    cmd.CommandText = "select isnull(sum(Extra_value),0) from Employees_Extra where employee_id = " & EmployeeID.SelectedValue & " and Extra_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    ExtraValue.Text = cmd.ExecuteScalar

                    cmd.CommandText = "select isnull(sum(Discount_value),0) from Employees_Discounts where Employee_ID = " & EmployeeID.SelectedValue & " and discount_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    EmpDiscounts.Text = cmd.ExecuteScalar

                    cmd.CommandText = "SELECT ISNULL(sum(D.PHASE_VALUE),0) FROM LOANS L , LOANS_DETAILS D WHERE L.LOAN_ID = D.LOAN_ID AND L.EMPLOYEE_ID = " & EmployeeID.SelectedValue & " and d.Pay_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
                    LoanValue.Text = cmd.ExecuteScalar

                    

                    
                    NetSalary.Text = (CDbl(BasicSalary.Text) + CDbl(subsc.Text) + CDbl(VarSalary.Text) + CDbl(ExtraSubsc) + CDbl(EmpRewards.Text) + CDbl(AddedHours.Text) + CDbl(ExtraValue.Text) + CDbl(SpeSubValue.Text)) - (CDbl(EmpDiscounts.Text) + CDbl(AbsentValue.Text) + CDbl(LoanValue.Text))


                    MyDs.Tables("Pay_Salary").Rows.Clear()
                    cmd.CommandText = "select * from pay_salary where employee_id = " & EmployeeID.SelectedValue
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Pay_Salary"))
                Else
                    cls.MsgExclamation("أدخل اسم الموظف", "please enter employee name")
                End If


            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Pay Salary")
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim b As Boolean
            cmd.CommandText = "SELECT dbo.Check_Pay_Salary(" & EmployeeID.SelectedValue & ",'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
            b = cmd.ExecuteScalar
            If b = True Then
                cls.MsgCritical("لقد تم دفع مرتب هذا الموظف في نفس الشهر برجاء اختيار موظف اخر او تغيير الشهر")
                Exit Sub
            End If

            cmd.CommandText = "EXEC EMP_PAYMENTS " & EmployeeID.SelectedValue & "," & BasicSalary.Text & "," & VarSalary.Text & "," & ExtraSubscription.Text & "," & EmpRewards.Text & "," & EmpDiscounts.Text & "," & AbsentValue.Text & "," & LoanValue.Text & "," & AddedHours.Text & "," & AttValueTxt.Text & "," & SpeSubValue.Text & "," & ExtraValue.Text & "," & NumSubscriptions.Text & "," & NetSalary.Text & ", N'" & Notes.Text & "' ," & subsc.Text
            cmd.ExecuteNonQuery()
            MyDs.Tables("Pay_Salary").Rows.Clear()

            cmd.CommandText = "select * from pay_salary where employee_id = " & EmployeeID.SelectedValue
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Pay_Salary"))

            cls.MsgInfo("تم حفظ البيانات بنجاح", "data has been saved successfully")
        Catch ex As Exception
            cls.WriteError(ex.Message, "Pay Salary")
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
End Class