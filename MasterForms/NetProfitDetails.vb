Public Class NetProfitDetails

    Dim d1, d2 As Date
    Dim Rpt As New RptNetIncome


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            d1 = DateTimePicker1.Text
            d2 = DateTimePicker2.Text
            Me.Cursor = Cursors.WaitCursor
            'ProgressOperation.Value = 0

            'MyDs.Tables("Income_Details").Rows.Clear()

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "فواتير المشتريات"
            'cmd.CommandText = "SELECT Doc_ID,Doc_Date,ISNULL(Doc_VALUE,0) as Doc_Value FROM Vendors_Transactions WHERE Doc_Date  between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "' and doc_type = N'اذن دفع'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "ساعات العمل الاضافية"
            'cmd.CommandText = "SELECT serial_pk as doc_id , hours_date as doc_date , ISNULL(REWARD_VALUE,0) as doc_value FROM Employees_Added_Hours WHERE Hours_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "المصروفات العمومية"
            'cmd.CommandText = "SELECT Expense_Detail_ID as doc_id , expense_date as doc_date , ISNULL(EXPENSE_VALUE,0) as doc_value FROM Expenses_Details WHERE EXPENSE_Date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "مدفوعات المرتبات"
            'cmd.CommandText = "SELECT serial_pk as doc_id,pay_date as doc_date,ISNULL(NET_SALARY,0) as doc_value FROM PAY_SALARY WHERE PAY_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "فواتير المشتريات"
            'cmd.CommandText = "SELECT bill_id as doc_id , bill_date as doc_date , ISNULL(Cash_Value,0) as doc_value FROM Purchase_Header  WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "مرتجع العملاء"
            'cmd.CommandText = "SELECT bill_id as doc_id , bill_date as doc_date ,ISNULL(Total_Bill,0) as doc_value FROM return_c_Header  WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "فواتير المبيعات - كاش/بنك"
            'cmd.CommandText = "SELECT  bill_id as doc_id , bill_date as doc_date ,ISNULL(Cash_Value,0) as doc_value FROM Sales_Header WHERE (Pay_Type = N'نقدي' OR Pay_Type =N'نقدي و اجل' OR Pay_Type = N'بشيك' OR Pay_Type = N'شيك و اجل') and Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "فواتير المبيعات - فيزا"
            'cmd.CommandText = "SELECT  bill_id as doc_id , bill_date as doc_date ,ISNULL(Cash_Value,0) as doc_value FROM Sales_Header WHERE Pay_Type = N'فيزا' and Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "مرتجع الموردين"
            'cmd.CommandText = "SELECT bill_id as doc_id , bill_date as doc_date ,ISNULL(Total_Bill,0) as doc_value FROM return_v_Header  WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'ProgressOperation.Value = ProgressOperation.Value + 10

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "مدفوعات العملاء"
            'cmd.CommandText = "SELECT pay_c_id as doc_id , bill_date as doc_date , ISNULL(PAY_VALUE,0) as doc_value FROM Customers_Payments WHERE Bill_Date BETWEEN '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))


            ''========================******************============================
            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "شيكات محصله"
            'cmd.CommandText = "SELECT cheque_number as doc_id , Received_Date as doc_date , ISNULL(Cheque_VALUE,0) as doc_value FROM cheques WHERE direction = N'مبيعات' and cheque_status = N'منصرف'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "شيكات مدفوعه"
            'cmd.CommandText = "SELECT cheque_number as doc_id , Received_Date as doc_date , ISNULL(Cheque_VALUE,0) as doc_value FROM cheques WHERE direction = N'مشتريات' and cheque_status = N'منصرف'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "دفع نقديه للعميل"
            'cmd.CommandText = " select doc_id , doc_date , isnull(doc_value,0) from Customers_Transactions where doc_type = N'دفع نقديه للعميل' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "دفع نقديه من المورد"
            'cmd.CommandText = " select isnull(doc_value,0) from Vendors_Transactions where doc_type = N'دفع نقديه من المورد' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "اذن دفع كاش"
            'cmd.CommandText = " select isnull(doc_value,0) from Money_Payments where doc_type = N'اذن دفع كاش' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))

            'MyDs.Tables("Income_Details").Columns("Doc_Type").DefaultValue = "اذن استلام كاش"
            'cmd.CommandText = " select isnull(doc_value,0) from Money_Payments where doc_type = N'اذن استلام كاش' and  doc_date between '" & d1.ToString("MM/dd/yyyy") & "' and '" & d2.ToString("MM/dd/yyyy") & "'"
            'da.SelectCommand = cmd
            'da.Fill(MyDs.Tables("Income_Details"))
            ''========================******************============================
            CalcNetTotal()
            '--------------------------------------------------------------
            Rpt.SetDataSource(MyDs.Tables("ResultSheet"))
            CrystalReportViewer1.ReportSource = Rpt

            '--------------------------------------------------------------
            ' ProgressOperation.Value = ProgressOperation.Value + 10

            'ProgressOperation.Value = 100

            Me.Cursor = Cursors.Default

            TabControl1.SelectTab(1)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Net Profit Details")
        End Try
    End Sub

    Sub CalcNetTotal()
        Dim TotalExpense, NetTotal, TotalPurchase, TotalSales, FinalTotal As Double
        MyDs.Tables("ResultSheet").Rows.Clear()
        '===========================Sales Section===============================
        Dim FirstVar, SecondVar As Double
        cmd.CommandText = "select dbo.Get_Any_Balance(7,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        FirstVar = cmd.ExecuteScalar
        cmd.CommandText = "select dbo.Get_Any_Balance(11,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        SecondVar = cmd.ExecuteScalar

        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "المبيعات"
        r("Field_Value1") = FirstVar
        MyDs.Tables("ResultSheet").Rows.Add(r)
        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "مردودات المبيعات"
        r("Field_Value1") = SecondVar
        MyDs.Tables("ResultSheet").Rows.Add(r)
        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "صافي المبيعات"
        r("Field_Value2") = FirstVar - SecondVar
        MyDs.Tables("ResultSheet").Rows.Add(r)
        TotalSales = FirstVar - SecondVar
        '=======================================================================
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "يخصم تكلفة المبيعات"
        MyDs.Tables("ResultSheet").Rows.Add(r)

        '===========================Purchase Section===============================
        cmd.CommandText = "select dbo.Get_Any_Balance(1,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        FirstVar = cmd.ExecuteScalar
        cmd.CommandText = "select dbo.Get_Any_Balance(10,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        SecondVar = cmd.ExecuteScalar

        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "المشتريات"
        r("Field_Value") = FirstVar
        MyDs.Tables("ResultSheet").Rows.Add(r)

        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "مردودات المشتريات"
        r("Field_Value") = SecondVar
        MyDs.Tables("ResultSheet").Rows.Add(r)
        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "صافي المشتريات"
        r("Field_Value1") = FirstVar - SecondVar
        MyDs.Tables("ResultSheet").Rows.Add(r)
        TotalPurchase = FirstVar - SecondVar
        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "مصاريف تسويقيه"
        'MyDs.Tables("ResultSheet").Rows.Add(r)
        '-------------------------------------------
        cls.FillSelectedTable("select * from procedure_master where Procedure_Category = N'مصاريف تسويقيه'", "Procedure_Master")
        For i As Integer = 0 To MyDs.Tables("procedure_master").Rows.Count - 1
            'r = MyDs.Tables("ResultSheet").NewRow
            'r("Field_Name") = MyDs.Tables("procedure_master").Rows(i).Item("Daily_Procedure_Name")
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("procedure_master").Rows(i).Item("Procedure_Master_ID") & ",'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
            FirstVar = cmd.ExecuteScalar
            TotalExpense = TotalExpense + FirstVar
            'r("Field_Value") = FirstVar
            'MyDs.Tables("ResultSheet").Rows.Add(r)
        Next
        r("Field_Value1") = TotalExpense
        MyDs.Tables("ResultSheet").Rows.Add(r)

        TotalPurchase = TotalPurchase + TotalExpense
        TotalExpense = 0
        '*****************-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "بضاعة أول المده"
        cmd.CommandText = "select dbo.Get_Any_Balance(13,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        FirstVar = cmd.ExecuteScalar
        r("Field_Value1") = FirstVar
        MyDs.Tables("ResultSheet").Rows.Add(r)

        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "بضاعة أخر المده"
        cmd.CommandText = "select dbo.Get_Any_Balance(21,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        SecondVar = cmd.ExecuteScalar
        r("Field_Value1") = SecondVar
        MyDs.Tables("ResultSheet").Rows.Add(r)
        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "تكلفة المبيعات"
        NetTotal = (TotalPurchase + FirstVar) - SecondVar
        r("Field_Value2") = NetTotal
        MyDs.Tables("ResultSheet").Rows.Add(r)
        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "مجمل الربح"
        FinalTotal = TotalSales - NetTotal
        r("Field_Value2") = FinalTotal
        MyDs.Tables("ResultSheet").Rows.Add(r)
        '-------------------------------------------
        '''r = MyDs.Tables("ResultSheet").NewRow
        '''r("Field_Name") = "عمولات دائنه"
        '''cmd.CommandText = "select dbo.Get_Any_Balance(22,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        '''FirstVar = cmd.ExecuteScalar
        '''r("Field_Value") = FirstVar
        '''MyDs.Tables("ResultSheet").Rows.Add(r)
        TotalExpense = 0
        '''TotalExpense = TotalExpense + FirstVar
        '-------------------------------------------
        '''r = MyDs.Tables("ResultSheet").NewRow
        '''r("Field_Name") = "خصم كميه مشتريات"
        '''cmd.CommandText = "select dbo.Get_Any_Balance(14,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        '''FirstVar = cmd.ExecuteScalar
        '''r("Field_Value") = FirstVar
        '''MyDs.Tables("ResultSheet").Rows.Add(r)
        '''TotalExpense = TotalExpense + FirstVar
        '-------------------------------------------
        '''r = MyDs.Tables("ResultSheet").NewRow
        '''r("Field_Name") = "خصم مسموح به"
        '''cmd.CommandText = "select dbo.Get_Any_Balance(15,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        '''FirstVar = cmd.ExecuteScalar
        '''r("Field_Value") = FirstVar
        '''MyDs.Tables("ResultSheet").Rows.Add(r)
        '''TotalExpense = TotalExpense - FirstVar
        ''''-------------------------------------------
        '''r = MyDs.Tables("ResultSheet").NewRow
        '''r("Field_Name") = "زياده مخزنيه"
        '''cmd.CommandText = "select dbo.Get_Any_Balance(20,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        '''FirstVar = cmd.ExecuteScalar
        '''r("Field_Value") = FirstVar
        '''MyDs.Tables("ResultSheet").Rows.Add(r)
        '''TotalExpense = TotalExpense + FirstVar
        ''-------------------------------------------
        'r = MyDs.Tables("ResultSheet").NewRow
        'r("Field_Name") = "عملاء عائلي"
        'cmd.CommandText = "select dbo.Get_Any_Balance(19,'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
        'r("Field_Value") = cmd.ExecuteScalar
        'MyDs.Tables("ResultSheet").Rows.Add(r)
        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "مصاريف اداريه" 'MyDs.Tables("procedure_master").Rows(i).Item("Daily_Procedure_Name")

        cls.FillSelectedTable("select * from procedure_master where Procedure_Category = N'مصاريف اداريه'", "Procedure_Master")
        For i As Integer = 0 To MyDs.Tables("procedure_master").Rows.Count - 1
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("procedure_master").Rows(i).Item("Procedure_Master_ID") & ",'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
            FirstVar = cmd.ExecuteScalar
            TotalExpense = TotalExpense - FirstVar
        Next

        r("Field_Value2") = TotalExpense 'FirstVar
        MyDs.Tables("ResultSheet").Rows.Add(r)

        FinalTotal = FinalTotal + TotalExpense
        '-------------------------------------------

        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "ايرادات متنوعه"
        MyDs.Tables("ResultSheet").Rows.Add(r)


        TotalExpense = 0

        cls.FillSelectedTable("select * from procedure_master where Procedure_Category = N'ايرادات متنوعه'", "Procedure_Master")
        For i As Integer = 0 To MyDs.Tables("procedure_master").Rows.Count - 1

            r = MyDs.Tables("ResultSheet").NewRow
            r("Field_Name") = MyDs.Tables("procedure_master").Rows(i).Item("Daily_Procedure_Name")
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("procedure_master").Rows(i).Item("Procedure_Master_ID") & ",'" & d1.ToString("MM/dd/yyyy") & "','" & d2.ToString("MM/dd/yyyy") & "')"
            FirstVar = cmd.ExecuteScalar

            r("Field_Value2") = FirstVar
            MyDs.Tables("ResultSheet").Rows.Add(r)

            TotalExpense = TotalExpense + FirstVar
        Next
        

        '-------------------------------------------
        r = MyDs.Tables("ResultSheet").NewRow
        r("Field_Name") = "صافي الربح"
        r("Field_Value2") = FinalTotal
        MyDs.Tables("ResultSheet").Rows.Add(r)
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
    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Leave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Leave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Button2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.GotFocus
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub


End Class