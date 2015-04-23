Public Class custAlerts
    Private PType As String
    Dim rpt As New RptMasterRecord


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyDs.Tables("MasterRecord").Rows.Clear()
        Dim date1 As Date
        date1 = #1/1/2000#
        MyDs.Tables("MasterRecord").Columns("Daily_Procedure_Name").DefaultValue = custname
        cmd.CommandText = "select procedure_type from procedure_master where procedure_category=N'عملاء' and reference_id = " & CustID
        PType = cmd.ExecuteScalar

        cmd.CommandText = "select procedure_master_id from procedure_master where procedure_category=N'عملاء' and reference_id = " & CustID
        CustID = cmd.ExecuteScalar

        If PType = "مدين" Then
            cmd.CommandText = "select N'رصيد أول المده' as Procedure_Desc ,dbo.Get_Any_Previous_Balance(" & CustID & " , '" & date1.ToString("MM/dd/yyyy") & "') as from_balance from procedure_Master where Procedure_Master_ID=" & CustID
        Else
            cmd.CommandText = "select N'رصيد أول المده' as Procedure_Desc ,dbo.Get_Any_Previous_Balance(" & CustID & " , '" & date1.ToString("MM/dd/yyyy") & "') as to_balance from procedure_Master where Procedure_Master_ID=" & CustID
        End If

        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("MasterRecord"))

        cmd.CommandText = "SELECT D.Procedure_Desc,D.Procedure_Date,D.Procedure_Value as To_Balance FROM Procedure_Master H,Procedure_Details D,Procedure_Master H2 WHERE H.Procedure_Master_ID = D.From_Procedure_Master_ID AND H2.Procedure_Master_ID = D.TO_Procedure_Master_ID AND D.To_Procedure_Master_ID=" & CustID & " and Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & Now.ToString("MM/dd/yyyy") & "'"
        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("MasterRecord"))
        cmd.CommandText = "SELECT D.Procedure_Desc,D.Procedure_Date,D.Procedure_Value as From_Balance FROM Procedure_Master H,Procedure_Details D,Procedure_Master H2 WHERE H.Procedure_Master_ID = D.From_Procedure_Master_ID AND H2.Procedure_Master_ID = D.TO_Procedure_Master_ID AND D.From_Procedure_Master_ID=" & CustID & " and Procedure_Date between '" & date1.ToString("MM/dd/yyyy") & "'  and   '" & Now.ToString("MM/dd/yyyy") & "'"
        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("MasterRecord"))

        cmd.CommandText = "select dbo.Get_Any_Last_Balance(" & CustID & ",'" & Now.ToString("MM/dd/yyyy") & "') as procedure_balance"
        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("MasterRecord"))
        rpt.SetDataSource(MyDs.Tables("MasterRecord"))
        Dim m As New ShowAllReports
        m.CrystalReportViewer1.ReportSource = rpt
        m.ShowDialog()
    End Sub

    
    Private Sub custAlerts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyDs.Tables("Alert_Customer_Expired_Date").Rows.Clear()
        cmd.CommandText = "select * from Alert_Customer_Expired_Date where customer_id = " & CustID
        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("Alert_Customer_Expired_Date"))
        DataGridViewReorder.DataSource = MyDs.Tables("Alert_Customer_Expired_Date")
        DataGridViewReorder.Columns(0).HeaderText = "اسم العميل"
        DataGridViewReorder.Columns(1).HeaderText = "اسم الاشتراك"
        DataGridViewReorder.Columns(2).HeaderText = "تاريخ الانتهاء"
        DataGridViewReorder.Columns(3).Visible = False

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        MyDs.Tables("alert_no_attend").Rows.Clear()
        cmd.CommandText = "select * from alert_no_attend where customer_id = " & CustID
        da.SelectCommand = cmd
        da.Fill(MyDs.Tables("alert_no_attend"))
        DataGridViewAlertBalance.DataSource = MyDs.Tables("alert_no_attend")
        DataGridViewAlertBalance.Columns(0).HeaderText = "اسم العميل"
        DataGridViewAlertBalance.Columns(1).HeaderText = "اسم الاشراك"
        DataGridViewAlertBalance.Columns(2).HeaderText = "عدد مرات الاشتراك المتبقيه"
        DataGridViewAlertBalance.Columns(3).Visible = False

    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black
    End Sub

    Private Sub Button1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White
    End Sub
End Class