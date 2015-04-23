Public Class TodayIncome
    Dim rpt As New RptIncome
    Dim date1 As Date
    Dim sh As String
    Private Sub TodayIncome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        date1 = Today.ToString

        cmd.CommandText = "select start_money from shifts_details where  shift_detail_id=" & CurrentShiftID
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = cmd.ExecuteScalar
        r("In_Name") = "الرصيد الابتدائي"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

        cmd.CommandText = "SELECT s.Subscription_NAME as in_name,sc.category_name as 'desc',SUM(paid)as in_value,(select logo from app_preferences) as logo  from subscriptions s,subscriptions_details sd,subscriptions_categories sc,shifts_details sh where(s.subscription_id = sd.subscription_id) and sh.shift_detail_id=sd.shift_detail_id and sc.Category_ID=s.Category_ID and sh.shift_detail_id=" & CurrentShiftID & " and sh.start_Date='" & date1.ToString("MM/dd/yyyy") & "' group by s.Subscription_NAME,sc.category_name "
        da.Fill(MyDs.Tables("income"))

        cmd.CommandText = "SELECT sc.category_name as in_name,N'جلسات خاصه' as 'desc',SUM(s.value)as in_value from Special_Categories sc,Special_Subscriptions s,shifts_details sh where(sc.Special_Categories_ID = s.Special_Categories_ID) and sh.shift_Detail_id=s.shift_detail_id and sh.shift_detail_id=" & CurrentShiftID & " and sh.start_Date='" & date1.ToString("MM/dd/yyyy") & "' group by sc.category_name"
        da.Fill(MyDs.Tables("income"))

        cmd.CommandText = "select ISNULL(sum(total_bill),0) from sales_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID & " and s.start_Date='" & date1.ToString("MM/dd/yyyy") & "'"
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = cmd.ExecuteScalar
        r("In_Name") = "المبيعات"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

        cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_V_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID & " and s.start_Date='" & date1.ToString("MM/dd/yyyy") & "'"
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = cmd.ExecuteScalar
        r("In_Name") = "مرتجعات الموردين"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)


        cmd.CommandText = "select daily_procedure_name as in_Name,N'اذونات استلام' as 'Desc',SUM(Rec_Value) as in_value from Procedure_Master pm,Money_Receivables pr ,shifts_details sh  where pm.Procedure_Master_ID=pr.From_Procedure_Master_ID and sh.shift_Detail_id =pr.shift_Detail_id and sh.shift_detail_id=" & CurrentShiftID & " and sh.start_Date='" & date1.ToString("MM/dd/yyyy") & "' group by daily_procedure_name"
        da.Fill(MyDs.Tables("income"))

        cmd.CommandText = "select ISNULL(sum(total_bill),0) from purchase_header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID & " and s.start_Date='" & date1.ToString("MM/dd/yyyy") & "'"
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = -cmd.ExecuteScalar
        r("In_Name") = "فواتير المشتريات"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)

        cmd.CommandText = "select ISNULL(sum(total_bill),0) from Return_C_Header r,shifts_details s where r.shift_detail_id=s.shift_detail_id and s.shift_detail_id=" & CurrentShiftID & " and s.start_Date='" & date1.ToString("MM/dd/yyyy") & "'"
        r = MyDs.Tables("Income").NewRow
        r("In_Value") = -cmd.ExecuteScalar
        r("In_Name") = "مرتجعات العملاء"
        r("Desc") = "-"
        MyDs.Tables("income").Rows.Add(r)


        cmd.CommandText = "select daily_procedure_name as in_Name,N'اذونات دفع' as 'Desc',-SUM(pay_value) as in_value from Procedure_Master pm,Money_Payables pr,shifts_details sh where pm.Procedure_Master_ID=pr.to_Procedure_Master_ID and pr.shift_Detail_id=sh.shift_Detail_id and sh.shift_detail_id=" & CurrentShiftID & " and sh.start_Date='" & date1.ToString("MM/dd/yyyy") & "' group by daily_procedure_name"
        da.Fill(MyDs.Tables("income"))

        cmd.CommandText = "select replace(employee_name + ' - ' + Real_Start_Time + ' - ' + Real_End_Time,'?','') as employee_name,shift_Detail_id from query_Shifts where shift_detail_id=" & CurrentShiftID
        sh = cmd.ExecuteScalar

        rpt.SetDataSource(MyDs.Tables("income"))
        rpt.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
        rpt.SetParameterValue("Report_Type", "وردية - " & sh)
        CrystalReportViewer1.ReportSource = rpt


    End Sub
End Class