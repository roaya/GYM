Public Class BalanceSheet

    Dim date1, date2 As Date
    Private rpt As New RptBalanceSheet
    Dim ProTbl As New GeneralDataSet.Procedure_MasterDataTable
    Dim BalanceDep, BalanceCustomers, BalanceVendors, BalanceBanks As Double

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        date1 = CDate(DateTimePicker1.Text)
        date2 = CDate(DateTimePicker2.Text)

        MyDs.Tables("BalanceSheet").Rows.Clear()

        MyDs.Tables("BalanceSheet").Columns("From_Daily_Procedure_Category").DefaultValue = "أصول ثابته"
        MyDs.Tables("BalanceSheet").Columns("To_Daily_Procedure_Category").DefaultValue = "حقوق ملكيه"

        cmd.CommandText = "SELECT A.From_Daily_Procedure_Name,dbo.Get_Any_Balance(A.A_CODE,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "') as From_Balance,B.To_Daily_Procedure_Name,dbo.Get_Any_Balance(B.B_CODE,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')as to_Balance,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as Logo FROM (SELECT ROW_NUMBER() OVER (ORDER BY Procedure_Master_ID) AS K,Procedure_Master_ID AS A_CODE,Daily_Procedure_Name AS From_Daily_Procedure_Name,Balance AS From_Balance FROM Procedure_Master WHERE Procedure_Category = N'أصول ثابته') AS A Full Outer JOIN " & _
        " (SELECT ROW_NUMBER() OVER (ORDER BY Procedure_Master_ID) AS K,Procedure_Master_ID AS B_CODE,Daily_Procedure_Name AS To_Daily_Procedure_Name,Balance AS To_Balance FROM Procedure_Master WHERE Procedure_Category = N'حقوق ملكيه') AS B ON A.K =B.K"
        da.Fill(MyDs.Tables("BalanceSheet"))

        r = MyDs.Tables("BalanceSheet").NewRow
        r("To_Daily_Procedure_Name") = "نتيجة العام"
        r("To_Balance") = CalcNetTotal()
        MyDs.Tables("BalanceSheet").Rows.Add(r)


        MyDs.Tables("BalanceSheet").Columns("To_Daily_Procedure_Category").DefaultValue = "مجمع اهلاكات"

        cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'مجمع اهلاكات'", "Procedure_Master")
        'BalanceCustomers = 0
        For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
            r = MyDs.Tables("BalanceSheet").NewRow
            r("To_Daily_Procedure_Name") = MyDs.Tables("Procedure_Master").Rows(i).Item("Daily_Procedure_Name")
            r("To_Balance") = cmd.ExecuteScalar
            cmd.CommandText = "select logo from app_preferences"
            r("logo") = cmd.ExecuteScalar
            MyDs.Tables("BalanceSheet").Rows.Add(r)
        Next

     

        MyDs.Tables("BalanceSheet").Columns("From_Daily_Procedure_Category").DefaultValue = "أصول متداوله"
        MyDs.Tables("BalanceSheet").Columns("To_Daily_Procedure_Category").DefaultValue = "خصوم متداوله"

        cmd.CommandText = "SELECT A.From_Daily_Procedure_Name,dbo.Get_Any_Balance(A.A_CODE,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "') as From_Balance,B.To_Daily_Procedure_Name,dbo.Get_Any_Balance(B.B_CODE,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')as to_Balance,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as Logo FROM (SELECT ROW_NUMBER() OVER (ORDER BY Procedure_Master_ID) AS K,Procedure_Master_ID AS A_CODE,Daily_Procedure_Name AS From_Daily_Procedure_Name,Balance AS From_Balance FROM Procedure_Master WHERE Procedure_Category = N'أصول متداوله') AS A Full Outer JOIN " & _
        " (SELECT ROW_NUMBER() OVER (ORDER BY Procedure_Master_ID) AS K,Procedure_Master_ID AS B_CODE,Daily_Procedure_Name AS To_Daily_Procedure_Name,Balance AS To_Balance FROM Procedure_Master WHERE Procedure_Category = N'خصوم متداوله') AS B ON A.K =B.K"
        da.Fill(MyDs.Tables("BalanceSheet"))


        cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'بنوك'", "Procedure_Master")
        BalanceBanks = 0
        For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
            BalanceBanks = BalanceBanks + cmd.ExecuteScalar
        Next

        r = MyDs.Tables("BalanceSheet").NewRow
        r("From_Daily_Procedure_Name") = "بنوك"
        r("From_Balance") = BalanceBanks
        cmd.CommandText = "select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ""
        r("logo") = cmd.ExecuteScalar
        MyDs.Tables("BalanceSheet").Rows.Add(r)


        cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'عملاء'", "Procedure_Master")
        BalanceCustomers = 0
        For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
            BalanceCustomers = BalanceCustomers + cmd.ExecuteScalar
        Next

        r = MyDs.Tables("BalanceSheet").NewRow
        r("From_Daily_Procedure_Name") = "عملاء"
        r("From_Balance") = BalanceCustomers
        cmd.CommandText = "select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ""
        r("logo") = cmd.ExecuteScalar
        MyDs.Tables("BalanceSheet").Rows.Add(r)


        cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'موردين'", "Procedure_Master")
        BalanceVendors = 0
        For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
            BalanceVendors = BalanceVendors + cmd.ExecuteScalar
        Next

        r = MyDs.Tables("BalanceSheet").NewRow
        r("To_Daily_Procedure_Name") = "موردين"
        r("To_Balance") = BalanceVendors
        cmd.CommandText = "select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ""
        r("logo") = cmd.ExecuteScalar
        MyDs.Tables("BalanceSheet").Rows.Add(r)

        MyDs.Tables("BalanceSheet").Columns("From_Daily_Procedure_Category").DefaultValue = "أرصده مدينه"
        MyDs.Tables("BalanceSheet").Columns("To_Daily_Procedure_Category").DefaultValue = "أرصده دائنه"

        cmd.CommandText = "SELECT A.From_Daily_Procedure_Name,dbo.Get_Any_Balance(A.A_CODE,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "') as From_Balance,B.To_Daily_Procedure_Name,dbo.Get_Any_Balance(B.B_CODE,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')as to_Balance FROM (SELECT ROW_NUMBER() OVER (ORDER BY Procedure_Master_ID) AS K,Procedure_Master_ID AS A_CODE,Daily_Procedure_Name AS From_Daily_Procedure_Name,Balance AS From_Balance ,(select logo from stocks where stock_id=" & ProjectSettings.CurrentStockID & ") as Logo FROM Procedure_Master WHERE Procedure_Category = N'أرصده مدينه') AS A Full Outer JOIN " & _
       " (SELECT ROW_NUMBER() OVER (ORDER BY Procedure_Master_ID) AS K,Procedure_Master_ID AS B_CODE,Daily_Procedure_Name AS To_Daily_Procedure_Name,Balance AS To_Balance FROM Procedure_Master WHERE Procedure_Category = N'أرصده دائنه') AS B ON A.K =B.K"
        da.Fill(MyDs.Tables("BalanceSheet"))

        'cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'أصول ثابته'", "Procedure_Master")

        'For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
        '    r = MyDs.Tables("BalanceSheetDebit").NewRow
        '    r("Daily_Procedure_Category") = "أصول ثابته"
        '    r("Daily_Procedure_Name") = MyDs.Tables("Procedure_Master").Rows(i).Item("Daily_Procedure_Name")
        '    cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        '    r("Balance") = cmd.ExecuteScalar
        '    MyDs.Tables("BalanceSheetDebit").Rows.Add(r)
        'Next


        'cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'أصول متداوله'", "Procedure_Master")

        'For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
        '    r = MyDs.Tables("BalanceSheetDebit").NewRow
        '    r("Daily_Procedure_Category") = "أصول متداوله"
        '    r("Daily_Procedure_Name") = MyDs.Tables("Procedure_Master").Rows(i).Item("Daily_Procedure_Name")
        '    cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        '    r("Balance") = cmd.ExecuteScalar
        '    MyDs.Tables("BalanceSheetDebit").Rows.Add(r)
        'Next

        'cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'عملاء'", "Procedure_Master")

        'For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
        '    r = MyDs.Tables("BalanceSheetDebit").NewRow
        '    r("Daily_Procedure_Category") = "عملاء"
        '    r("Daily_Procedure_Name") = MyDs.Tables("Procedure_Master").Rows(i).Item("Daily_Procedure_Name")
        '    cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        '    r("Balance") = cmd.ExecuteScalar
        '    MyDs.Tables("BalanceSheetDebit").Rows.Add(r)
        'Next

        'r = MyDs.Tables("BalanceSheetDebit").NewRow
        'r("Daily_Procedure_Category") = "أصول متداوله"
        'r("Daily_Procedure_Name") = "الخزينه"
        'cmd.CommandText = "select dbo.Get_Any_Balance(4,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        'r("Balance") = cmd.ExecuteScalar
        'MyDs.Tables("BalanceSheetDebit").Rows.Add(r)


        'r = MyDs.Tables("BalanceSheetDebit").NewRow
        'r("Daily_Procedure_Category") = "بنوك"
        'BalanceBanks = 0
        'For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
        '    cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        '    BalanceBanks = BalanceBanks + cmd.ExecuteScalar
        'Next
        'r("Balance") = BalanceBanks
        'MyDs.Tables("BalanceSheetDebit").Rows.Add(r)

        'cls.FillSelectedTable("select * from procedure_Master where Daily_Procedure_Name = N'رأس المال'", "Procedure_Master")

        'For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
        '    r = MyDs.Tables("BalanceSheetDebit").NewRow
        '    r("Daily_Procedure_Category") = "حقوق الملكيه"
        '    r("Daily_Procedure_Name") = MyDs.Tables("Procedure_Master").Rows(i).Item("Daily_Procedure_Name")
        '    cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        '    r("Balance") = cmd.ExecuteScalar
        '    MyDs.Tables("BalanceSheetDebit").Rows.Add(r)
        'Next

        'r = MyDs.Tables("BalanceSheetDebit").NewRow
        'r("Daily_Procedure_Category") = "نتيجة العام"
        'r("Balance") = CalcNetTotal()
        'MyDs.Tables("BalanceSheetDebit").Rows.Add(r)

        'cls.FillSelectedTable("select * from Procedure_Master where Daily_Procedure_Name like N'%مجمع اهلاك%'", "Procedure_Master")

        'r = MyDs.Tables("BalanceSheetDebit").NewRow
        'r("Daily_Procedure_Category") = "مجمع الاهلاك"
        'BalanceDep = 0
        'For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
        '    cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        '    BalanceDep = BalanceDep + cmd.ExecuteScalar
        'Next
        'r("Balance") = BalanceDep
        'MyDs.Tables("BalanceSheetDebit").Rows.Add(r)

        'cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'موردين'", "Procedure_Master")

        'For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
        '    r = MyDs.Tables("BalanceSheetDebit").NewRow
        '    r("Daily_Procedure_Category") = "موردين"
        '    r("Daily_Procedure_Name") = MyDs.Tables("Procedure_Master").Rows(i).Item("Daily_Procedure_Name")
        '    cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        '    r("Balance") = cmd.ExecuteScalar
        '    MyDs.Tables("BalanceSheetDebit").Rows.Add(r)
        'Next

        'cls.FillSelectedTable("select * from procedure_Master where PROCEDURE_category = N'خصوم متداوله'", "Procedure_Master")

        'For i As Integer = 0 To MyDs.Tables("Procedure_Master").Rows.Count - 1
        '    r = MyDs.Tables("BalanceSheetDebit").NewRow
        '    r("Daily_Procedure_Category") = "خصوم متداوله"
        '    r("Daily_Procedure_Name") = MyDs.Tables("Procedure_Master").Rows(i).Item("Daily_Procedure_Name")
        '    cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("Procedure_Master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        '    r("Balance") = cmd.ExecuteScalar
        '    MyDs.Tables("BalanceSheetDebit").Rows.Add(r)
        'Next

        rpt.SetDataSource(MyDs.Tables("BalanceSheet"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        CrystalReportViewer1.ReportSource = rpt
        TabControl1.SelectTab(1)

    End Sub



    Function CalcNetTotal() As Double
        Dim TotalExpense, NetTotal, TotalPurchase, TotalSales, FinalTotal As Double
        '===========================Sales Section===============================
        Dim FirstVar, SecondVar As Double
        cmd.CommandText = "select dbo.Get_Any_Balance(7,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        FirstVar = cmd.ExecuteScalar
        cmd.CommandText = "select dbo.Get_Any_Balance(11,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        SecondVar = cmd.ExecuteScalar

        '-------------------------------------------
        TotalSales = FirstVar - SecondVar
       
        '===========================Purchase Section===============================
        cmd.CommandText = "select dbo.Get_Any_Balance(1,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        FirstVar = cmd.ExecuteScalar
        cmd.CommandText = "select dbo.Get_Any_Balance(10,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        SecondVar = cmd.ExecuteScalar

        
        TotalPurchase = FirstVar - SecondVar
        '-------------------------------------------
        
        cls.FillSelectedTable("select * from procedure_master where Procedure_Category = N'مصاريف تسويقيه'", "Procedure_Master")
        For i As Integer = 0 To MyDs.Tables("procedure_master").Rows.Count - 1
            'r = MyDs.Tables("ResultSheet").NewRow
            'r("Field_Name") = MyDs.Tables("procedure_master").Rows(i).Item("Daily_Procedure_Name")
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("procedure_master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
            FirstVar = cmd.ExecuteScalar
            TotalExpense = TotalExpense + FirstVar
            'r("Field_Value") = FirstVar
            'MyDs.Tables("ResultSheet").Rows.Add(r)
        Next
        
        TotalPurchase = TotalPurchase + TotalExpense
        TotalExpense = 0
        '*****************-------------------------------------------
        
        cmd.CommandText = "select dbo.Get_Any_Balance(13,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        FirstVar = cmd.ExecuteScalar
        
        '-------------------------------------------
        cmd.CommandText = "select dbo.Get_Any_Balance(21,'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
        SecondVar = cmd.ExecuteScalar
        '-------------------------------------------
        NetTotal = (TotalPurchase + FirstVar) - SecondVar
        '-------------------------------------------
        FinalTotal = TotalSales - NetTotal
        '-------------------------------------------
        TotalExpense = 0
        '-------------------------------------------
        
        cls.FillSelectedTable("select * from procedure_master where Procedure_Category = N'مصاريف اداريه'", "Procedure_Master")
        For i As Integer = 0 To MyDs.Tables("procedure_master").Rows.Count - 1
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("procedure_master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
            FirstVar = cmd.ExecuteScalar
            TotalExpense = TotalExpense - FirstVar
        Next

       
        FinalTotal = FinalTotal + TotalExpense
        '-------------------------------------------

        TotalExpense = 0

        cls.FillSelectedTable("select * from procedure_master where Procedure_Category = N'ايرادات متنوعه'", "Procedure_Master")
        For i As Integer = 0 To MyDs.Tables("procedure_master").Rows.Count - 1
            cmd.CommandText = "select dbo.Get_Any_Balance(" & MyDs.Tables("procedure_master").Rows(i).Item("Procedure_Master_ID") & ",'" & date1.ToString("MM/dd/yyyy") & "','" & date2.ToString("MM/dd/yyyy") & "')"
            FirstVar = cmd.ExecuteScalar
            TotalExpense = TotalExpense + FirstVar
        Next
        
        FinalTotal = FinalTotal + TotalExpense

        Return FinalTotal

    End Function

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