Public Class Alerts

    Dim TblReorder, TblAlert, TblCards, TblCust, TblVen, TblEmpTasks, TblReq, TblChq As New DataTable

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            TblReorder.Rows.Clear()
            cmd.CommandText = "select S.STOCK_NAME AS 'اسم المخزن' , C.CATEGORY_NAME AS 'اسم البند', I.ITEM_NAME AS 'اسم الصنف' ,IST.Balance AS 'الرصيد' FROM CATEGORIES C , ITEMS I , ITEMS_STOCKS IST , Stocks S " & _
            "where S.STOCK_ID = IST.STOCK_ID And C.Category_Id = I.Category_Id And I.ITEM_ID = IST.ITEM_Id And IST.Balance <= i.Order_Balance"
            da.SelectCommand = cmd
            da.Fill(TblReorder)
            DataGridViewReorder.DataSource = TblReorder
            'DataGridViewReorder.Columns(0).HeaderText = "اسم المحل"
            'DataGridViewReorder.Columns(1).HeaderText = "اسم البند"
            'DataGridViewReorder.Columns(2).HeaderText = "المقاس"
            'DataGridViewReorder.Columns(3).HeaderText = "اسم الفئة"
            'DataGridViewReorder.Columns(4).HeaderText = "اسم الصنف"
            'DataGridViewReorder.Columns(5).HeaderText = "حد اعادة الطلب"
            'DataGridViewReorder.Columns(6).HeaderText = "الرصيد"

            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = True

            TabControl1.SelectTab(0)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            TblAlert.Rows.Clear()
            cmd.CommandText = "select S.STOCK_NAME AS 'اسم المخزن' , C.CATEGORY_NAME AS 'اسم البند', I.ITEM_NAME AS 'اسم الصنف' ,IST.Balance AS 'الرصيد' FROM CATEGORIES C , ITEMS I , ITEMS_STOCKS IST , Stocks S " & _
            " where S.STOCK_ID = IST.STOCK_ID And C.Category_Id = I.Category_Id And I.ITEM_ID = IST.ITEM_Id And IST.Balance <= I.Alert_Balance "

            da.SelectCommand = cmd
            da.Fill(TblAlert)
            DataGridViewAlertBalance.DataSource = TblAlert
            'DataGridViewAlertBalance.Columns(0).HeaderText = "اسم المحل"
            'DataGridViewAlertBalance.Columns(1).HeaderText = "اسم البند"
            'DataGridViewAlertBalance.Columns(2).HeaderText = "المقاس"
            'DataGridViewAlertBalance.Columns(3).HeaderText = "اسم الفئة"
            'DataGridViewAlertBalance.Columns(4).HeaderText = "اسم الصنف"
            'DataGridViewAlertBalance.Columns(5).HeaderText = "حد التحذير"
            'DataGridViewAlertBalance.Columns(6).HeaderText = "الرصيد"

            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewAlertBalance.Visible = True
            DataGridViewReorder.Visible = False

            TabControl1.SelectTab(1)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            MyDs.Tables("Alert_subscriptions_Expired_Date").Rows.Clear()
            cmd.CommandText = "select * from Alert_subscriptions_Expired_Date where end_Date-GETDATE() <= 7"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Alert_subscriptions_Expired_Date"))
            DataGridViewCards.DataSource = MyDs.Tables("Alert_subscriptions_Expired_Date")

            DataGridViewCards.Columns(0).HeaderText = "اسم العميل"
            DataGridViewCards.Columns(1).HeaderText = "اسم الاشتراك"
            DataGridViewCards.Columns(2).HeaderText = "نوع الاشتراك"
            DataGridViewCards.Columns(3).HeaderText = "تاريخ الانتهاء"

            DataGridViewCards.Visible = True
            DataGridViewTask.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = False

            TabControl1.SelectTab(3)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            MyDs.Tables("Alert_subscription").Rows.Clear()
            cmd.CommandText = "SELECT * from Alert_subscription"
            da.SelectCommand = cmd
            da.Fill(MyDs.Tables("Alert_subscription"))
            DataGridViewCust.DataSource = MyDs.Tables("Alert_subscription")
            DataGridViewCust.Columns(0).HeaderText = "اسم العميل"
            DataGridViewCust.Columns(1).HeaderText = "اسم الاشتراك"
            DataGridViewCust.Columns(2).HeaderText = "نوع الاشتراك"
            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = False
            DataGridViewCust.Visible = True

            TabControl1.SelectTab(2)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Try
    '        TblVen.Rows.Clear()
    '        cmd.CommandText = "SELECT Vendor_Name as 'اسم المورد',Bill_Date as 'التاريخ واجب الدفع',Payed_Date as 'تاريخ الدفع',Pay_Value as 'القيمة واجبة الدفع',Status as 'الحالة' FROM Report_Vendors_Payments where status = N'مجدولة' and Bill_Date-GETDATE() <= 7"
    '        da.SelectCommand = cmd
    '        da.Fill(TblVen)
    '        DataGridViewVen.DataSource = TblVen


    '        DataGridViewVen.Visible = True
    '        DataGridViewTask.Visible = False
    '        DataGridViewCards.Visible = False
    '        DataGridViewCust.Visible = False
    '        DataGridViewAlertBalance.Visible = False
    '        DataGridViewReorder.Visible = False

    '        TabControl1.SelectTab(3)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, "Alerts")
    '    End Try
    'End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            TblEmpTasks.Rows.Clear()
            cmd.CommandText = "SELECT Task_Code as 'كود المهمة',Employee_Name as 'الراسل',Title as 'عنوان المهمة',Task_Desc as 'الوصف',Task_Date as 'التاريخ' FROM Query_Employees_Tasks where approved=0 and To_Employee = " & EmpIDVar
            da.SelectCommand = cmd
            da.Fill(TblEmpTasks)
            DataGridViewTask.DataSource = TblEmpTasks


            DataGridViewTask.Visible = True
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = False


            TabControl1.SelectTab(4)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    Try
    '        cmd.CommandText = "select request_id as 'رقم الاذن', Request_Date as 'تاريخ الحجز',Request_Time as 'وقت الحجز',Expired_Date as 'تاريخ الانتهاء',Customer_Name as 'اسم العميل',Item_Name as 'اسم الصنف' , Quantity as 'الكميه' from report_requests where Expired_Date-GETDATE() <= 7"
    '        da.SelectCommand = cmd
    '        da.Fill(TblReq)
    '        DataGridViewReq.DataSource = TblReq


    '        DataGridViewTask.Visible = False
    '        DataGridViewCards.Visible = False
    '        DataGridViewCust.Visible = False
    '        DataGridViewAlertBalance.Visible = False
    '        DataGridViewReq.Visible = True


    '        TabControl1.SelectTab(3)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, "Alerts")
    '    End Try
    'End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            cmd.CommandText = "select Cheque_Number as 'رقم الشيك', Received_Date as 'تاريخ الاستحقاق',Payed_Date as 'تاريخ الدفع',Cheque_Value as 'قيمة الشيك' from cheques where Received_Date > GETDATE() "
            da.SelectCommand = cmd
            da.Fill(TblChq)
            DataGridCheques.DataSource = TblChq

            DataGridViewTask.Visible = False
            DataGridViewCards.Visible = False
            DataGridViewCust.Visible = False
            DataGridViewAlertBalance.Visible = False
            DataGridViewReorder.Visible = False

            DataGridCheques.Visible = True


            TabControl1.SelectTab(5)
        Catch ex As Exception
            cls.WriteError(ex.Message, "Alerts")
        End Try
    End Sub

    
  
    
   
End Class