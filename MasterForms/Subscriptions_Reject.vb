Public Class Subscriptions_Reject
    Dim bsource As New BindingSource
    Dim tbl As New GeneralDataSet.CustomersDataTable
    Dim tbl2 As New GeneralDataSet.Report_Customers_SubscriptionsDataTable
    Private Sub Subscriptions_Reject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        cls.RefreshData("select * from customers", tbl)

        Cust.DataSource = tbl
        Cust.DisplayMember = "customer_name"
        Cust.ValueMember = "customer_id"
        bsource.DataSource = MyDs
        bsource.DataMember = "Report_Customers_Subscriptions"



        DataGridView1.DataSource = bsource
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).HeaderText = "بند الاشتراك"
        DataGridView1.Columns(4).Width = 150
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).HeaderText = "اسم الاشتراك"
        DataGridView1.Columns(6).Width = 200
        DataGridView1.Columns(7).HeaderText = "نوع الاشتراك"
        DataGridView1.Columns(8).HeaderText = "ثمن الاشتراك"
        DataGridView1.Columns(9).HeaderText = "المدفوع مقدما"
        DataGridView1.Columns(10).HeaderText = "المتبقي"
        DataGridView1.Columns(11).HeaderText = "سعر الدفع"
        DataGridView1.Columns(12).Visible = False
        DataGridView1.Columns(13).Visible = False

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Try
            MyDs.Tables("Report_Customers_Subscriptions").Rows.Clear()
            cmd.CommandText = "select * from Report_Customers_Subscriptions where subscription_status=N'مفتوحه'"
            da.Fill(MyDs.Tables("Report_Customers_Subscriptions"))
            bsource.Filter = "customer_id=" & Cust.SelectedValue
            DataGridView1.DataSource = bsource
        Catch
            cls.MsgExclamation("هذا العميل غير موجود برجاء اعادة الاختيار")
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Total As Decimal
        Dim Count As Integer
        Dim N As Integer
        Dim subs_Value As Decimal
        Dim Exp As Decimal
        Dim Pro_ID As Integer
        Dim pro_Subs As Integer
        Dim Extra_Training As Integer
        Dim status As String
        Dim Balance As Integer
        Dim Extra_Disc As Integer

        Try
            If CurrentShiftId = 0 Then
                cls.MsgExclamation("برجاء قم بفتح وردية ")
                Exit Sub
            End If

            cmd.CommandText = "select Extra_disc from app_preferences"
            Extra_Disc = cmd.ExecuteScalar

            cmd.CommandText = "select procedure_master_id from procedure_master where procedure_Category = N'ايرادات متنوعه' and reference_id=" & DataGridView1.SelectedRows(0).Cells("subscription_id").Value.ToString()
            pro_Subs = cmd.ExecuteScalar

            cmd.CommandText = "select procedure_master_id from procedure_master where procedure_Category=N'عملاء' and reference_id=" & DataGridView1.SelectedRows(0).Cells("customer_id").Value.ToString()
            Pro_ID = cmd.ExecuteScalar

            cmd.CommandText = "select extra_training from subscriptions where subscription_id=" & DataGridView1.SelectedRows(0).Cells("subscription_id").Value.ToString()
            Extra_Training = cmd.ExecuteScalar

            cmd.CommandText = "select count(*) from customers_attendance where subscription_id=" & DataGridView1.SelectedRows(0).Cells("Subscription_detail_id").Value.ToString()
            Count = cmd.ExecuteScalar

            cmd.CommandText = "select no_Training-(no_subscriptions*" & Extra_Training & ") from subscriptions_details where subscription_detail_id=" & DataGridView1.SelectedRows(0).Cells("Subscription_detail_id").Value.ToString()
            N = cmd.ExecuteScalar

            cmd.CommandText = "select paid+remaining from subscriptions_details where subscription_detail_id=" & DataGridView1.SelectedRows(0).Cells("Subscription_detail_id").Value.ToString()
            Total = cmd.ExecuteScalar


            If Count = N Then
                cls.MsgExclamation("لا يمكنك الغاء هذا الاشتراك لقد تم هذا العميل بالفعل الجلسات المفترضه")
                Exit Sub
            End If

            subs_Value = Total / N

            cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & Pro_ID & ",getdate())"
            Balance = cmd.ExecuteScalar


            Exp = subs_Value * Count


            '   ElseIf Total - Exp - Extra_Disc < Balance Then
            'cls.MsgExclamation("عفوا لا يمكنك اجراء هذه العمليه الأن قيمة المرتجع اقل من رصيد العميل")
            'Exit Sub

            If Exp = 0 Then
                If Balance > Total Then
                    status = "Balance"
                ElseIf Balance = Total Then
                    status = "BalanceTotal"
                Else
                    status = "Total"
                End If
            Else
                If Total - Exp - Extra_Disc = Balance Then
                    status = "Equal"
                Else
                    status = "TotalAndPaid"
                End If
            End If


            If status = "Total" Then
                If MessageBox.Show("هل انت متأكد هل تريد ارجاع هذا الاشتراك هذا العميل له باقي و قدره" & Total - Balance & " جنيه", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    cmd.CommandText = "update subscriptions_Details set subscription_Status=N'مرتجع',end_date=getdate() where subscription_detail_id=" & DataGridView1.SelectedRows(0).Cells("Subscription_detail_id").Value.ToString()
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "insert into money_payables(to_procedure_master_id,pay_date,pay_Type,pay_value,pay_desc,shift_detail_id) values(" & Pro_ID & ",getdate(),N'نقدي'," & Total - Balance & ",N'ارجاع اشتراك عميل'," & CurrentShiftId & ")"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Procedure_Tran " & pro_Subs & ", " & Pro_ID & " , " & Total - Exp & ",N'ارتجاع اشتراك عميل'"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Procedure_Tran " & Pro_ID & ",4, " & Total - Balance & ",N'دفع مستحقات العميل بعد طلب العميل لارجاع الاشتراك'"
                    cmd.ExecuteNonQuery()

                    cls.MsgInfo("لقد تم ارجاع الاشتراك للعميل بنجاح")
                End If
            ElseIf status = "Balance" Then
                If MessageBox.Show("هل انت متأكد هل تريد ارجاع هذا الاشتراك. لا يوجد اي اموال اضافيه للعميل", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                    cmd.CommandText = "update subscriptions_Details set subscription_Status=N'مرتجع',end_date=getdate() where subscription_detail_id=" & DataGridView1.SelectedRows(0).Cells("Subscription_detail_id").Value.ToString()
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Procedure_Tran " & pro_Subs & ", " & Pro_ID & " , " & Total & ",N'ارتجاع اشتراك عميل'"
                    cmd.ExecuteNonQuery()

                    cls.MsgInfo("لقد تم ارجاع الاشتراك للعميل بنجاح")

                End If
            ElseIf status = "BalanceTotal" Then
                If MessageBox.Show("هل انت متأكد هل تريد ارجاع هذا الاشتراك. لا يوجد اي اموال اضافيه للعميل", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                    cmd.CommandText = "update subscriptions_Details set subscription_Status=N'مرتجع',end_date=getdate() where subscription_detail_id=" & DataGridView1.SelectedRows(0).Cells("Subscription_detail_id").Value.ToString()
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Procedure_Tran " & pro_Subs & ", " & Pro_ID & " , " & Total & ",N'ارتجاع اشتراك عميل'"
                    cmd.ExecuteNonQuery()

                    cls.MsgInfo("لقد تم ارجاع الاشتراك للعميل بنجاح")
                End If
            ElseIf status = "Equal" Then
                If MessageBox.Show("هل انت متأكد هل تريد ارجاع هذا الاشتراك. لا يوجد اي اموال اضافيه للعميل", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then

                    cmd.CommandText = "update subscriptions_Details set subscription_Status=N'مرتجع',end_date=getdate() where subscription_detail_id=" & DataGridView1.SelectedRows(0).Cells("Subscription_detail_id").Value.ToString()
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Procedure_Tran " & pro_Subs & ", " & Pro_ID & " , " & Total - Extra_Disc - Exp & ",N'ارتجاع اشتراك عميل'"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Procedure_Tran " & pro_Subs & ",5, " & Extra_Disc & ",N'مصاريف اداريه جزاء ارجاع الاشتراك'"
                    cmd.ExecuteNonQuery()

                    cls.MsgInfo("لقد تم ارجاع الاشتراك للعميل بنجاح")
                End If

            ElseIf status = "TotalAndPaid" Then
                If MessageBox.Show("هل انت متأكد هل تريد ارجاع هذا الاشتراك هذا العميل له باقي و قدره" & Total - Extra_Disc - Exp - Balance & " جنيه", "Gym", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    cmd.CommandText = "update subscriptions_Details set subscription_Status=N'مرتجع',end_date=getdate() where subscription_detail_id=" & DataGridView1.SelectedRows(0).Cells("Subscription_detail_id").Value.ToString()
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "insert into money_payables(to_procedure_master_id,pay_date,pay_Type,pay_value,pay_desc,shift_detail_id) values(" & Pro_ID & ",getdate(),N'نقدي'," & Total - Extra_Disc - Exp - Balance & ",N'ارجاع اشتراك عميل'," & CurrentShiftId & ")"
                    cmd.ExecuteNonQuery()


                    cmd.CommandText = "Exec Commit_Procedure_Tran " & pro_Subs & ", " & Pro_ID & " , " & Total - Extra_Disc - Exp & ",N'ارتجاع اشتراك عميل'"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Procedure_Tran " & pro_Subs & ",5, " & Extra_Disc & ",N'مصاريف اداريه جزاء ارجاع اشتراك'"
                    cmd.ExecuteNonQuery()

                    cmd.CommandText = "Exec Commit_Procedure_Tran " & Pro_ID & ",4, " & Total - Extra_Disc - Exp - Balance & ",N'دفع مستحقات العميل بعد طلب العميل لارجاع الاشتراك'"
                    cmd.ExecuteNonQuery()

                    cls.MsgInfo("لقد تم ارجاع الاشتراك للعميل بنجاح")
                End If
            End If






                Try
                    MyDs.Tables("Report_Customers_Subscriptions").Rows.Clear()
                    cmd.CommandText = "select * from Report_Customers_Subscriptions where subscription_status=N'مفتوحه'"
                    da.Fill(MyDs.Tables("Report_Customers_Subscriptions"))
                    bsource.Filter = "customer_id=" & Cust.SelectedValue
                    DataGridView1.DataSource = bsource
                Catch
                    DataGridView1.DataSource = bsource
                End Try

        Catch

        End Try

    End Sub
End Class