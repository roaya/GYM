Public Class FrmUserPreferences

    Dim cmdb As New SqlClient.SqlCommandBuilder
    Dim PwdDefault As String
    Dim BSourceAppPref As New BindingSource

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Commit_Pref()
        Me.Close()
    End Sub

    
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click


        Commit_Pref()

        'If GenRadBarcode48.Checked = True Then
        '    ProjectSettings.Gen_Print_Barcode = 48
        'Else
        '    ProjectSettings.Gen_Print_Barcode = 96
        'End If

        'If GenRadPrintCheque.Checked = True Then
        '    ProjectSettings.Gen_Print_Type = "Cheque"
        'Else
        '    ProjectSettings.Gen_Print_Type = "Normal"
        'End If

        
        '& "," & CBool(GenChkShowMsg.Checked) & _
        '                "," & CBool(GenChkShowAlert.Checked) & "," & GenCmbCurrPeriod.SelectedValue & "," & ProjectSettings.Gen_Print_Barcode & _
        '                ",'" & ProjectSettings.Gen_Print_Type & "' ," & GenPhotoDefBackGrd.BackgroundImage.ToString & "," & CBool(GenChkShowBefPrint.Checked) & _
        '"," & CBool(GenChkItemStock.Checked) & "," & CBool(GenChkItemVendor.Checked) & "," & CmbPurDefStkID.SelectedValue & ","
    End Sub

    Sub Commit_Pref()
        Try
            cmd.CommandText = "exec APPLY_PREFERENCES " & NumPurNextID.Value & "," & NumSalNextID.Value & "," & NumRetCustNextID.Value & "," & _
                    NumRetVenNextID.Value & "," & NumDepNextID.Value & "," & NumAdjNextID.Value
            cmd.ExecuteNonQuery()

            BSourceAppPref.EndEdit()
            cmd.CommandText = "select * from App_Preferences"
            cmdb.DataAdapter = da
            da.Update(MyDs.Tables("App_Preferences"))

            ''MyDs.Tables("MainBkG").Rows.Clear()
            ''cmd.CommandText = "select Gen_Back_Photo from App_Preferences where serial_pk=1"
            ''da.SelectCommand = cmd
            ''da.Fill(MyDs.Tables("MainBkG"))

            PurFooter = TxtSalFooter.Text

            If GenChkShowMsg.Checked = True Then
                cls.MsgInfo("تم تطبيق التغييرات بنجاح", "new settings has been applied successfully")
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "User Pref")
        End Try
    End Sub

    Private Sub FrmUserPreferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            cls.RefreshData("Stocks")

            cls.FillSelectedTable("select * from App_Preferences", "App_Preferences")

            BSourceAppPref.DataSource = MyDs
            BSourceAppPref.DataMember = "App_Preferences"

            GenChkShowAlert.DataBindings.Add("Checked", BSourceAppPref, "Gen_View_Alert", True)
            GenChkItemStock.DataBindings.Add("Checked", BSourceAppPref, "Gen_Attach_Item_Stk", True)
            GenChkItemVendor.DataBindings.Add("Checked", BSourceAppPref, "Gen_Attach_Item_Ven", True)
            GenChkShowMsg.DataBindings.Add("Checked", BSourceAppPref, "Gen_View_Msg", True)
            GenChkShowBefPrint.DataBindings.Add("Checked", BSourceAppPref, "Gen_View_Before_Print", True)
            SalChkShowEmpID.DataBindings.Add("Checked", BSourceAppPref, "Sal_Edit_Emp_ID", True)
            SalChkShowDate.DataBindings.Add("Checked", BSourceAppPref, "Sal_Edit_Date", True)
            GenPhotoDefBackGrd.DataBindings.Add("backgroundImage", BSourceAppPref, "Logo", True)
            P_HeaderReport.DataBindings.Add("Text", BSourceAppPref, "P_HeaderReport")

            GenCmbNoBarCodes.DataBindings.Add("Text", BSourceAppPref, "Gen_Print_Barcode")
            GenCmbPrintType.DataBindings.Add("Text", BSourceAppPref, "Gen_Print_Type")
            CmbPurSchType.DataBindings.Add("Text", BSourceAppPref, "Pur_Def_Sch")
            CmdPurDefFilter.DataBindings.Add("Text", BSourceAppPref, "Pur_Def_Filter")
            CmdPurOrdStyle.DataBindings.Add("Text", BSourceAppPref, "Pur_Def_Style")
            CmbSalSchType.DataBindings.Add("Text", BSourceAppPref, "Sal_Def_Sch")
            CmdSalDefFilter.DataBindings.Add("Text", BSourceAppPref, "Sal_Def_Filter")
            CmdSalDefOdrType.DataBindings.Add("Text", BSourceAppPref, "Sal_Def_Ord_Type")
            CmdSalOrdStyle.DataBindings.Add("Text", BSourceAppPref, "Sal_Def_Style")
            CmbRetCusSchType.DataBindings.Add("Text", BSourceAppPref, "Ret_Cus_Def_Sch")
            CmbRetVenSchType.DataBindings.Add("Text", BSourceAppPref, "Ret_Ven_Def_Sch")
            CmbDepSchType.DataBindings.Add("Text", BSourceAppPref, "Dep_Def_Sch")
            CmbAdjSchType.DataBindings.Add("Text", BSourceAppPref, "Adj_Def_Sch")


            CmbPurDefStkID.DataSource = MyDs
            CmbPurDefStkID.DisplayMember = "Stocks.Stock_Name"
            CmbPurDefStkID.ValueMember = "Stocks.Stock_ID"
            CmbPurDefStkID.DataBindings.Add("SelectedValue", BSourceAppPref, "Pur_Stk_ID")

            NumPurDefQty.DataBindings.Add("Value", BSourceAppPref, "Pur_Def_Qty")
            NumSalDefQty.DataBindings.Add("Value", BSourceAppPref, "Sal_Def_Qty")
            NumRetVenDefQty.DataBindings.Add("Value", BSourceAppPref, "Ret_Ven_Def_Qty")
            NumRetCustDefQty.DataBindings.Add("Value", BSourceAppPref, "Ret_Cus_Def_Qty")
            NumDepDefQty.DataBindings.Add("Value", BSourceAppPref, "Dep_Def_Qty")
            Extra_Subsc.DataBindings.Add("Value", BSourceAppPref, "Extra_Disc")

          
            NumAdjDefQty.DataBindings.Add("Value", BSourceAppPref, "Adj_Def_Qty")

            GenSenderEmail.DataBindings.Add("Text", BSourceAppPref, "Gen_Sender_Email")
            GenSenderPwd.DataBindings.Add("Text", BSourceAppPref, "Gen_Sender_Pwd")
            GenIsSend.DataBindings.Add("Checked", BSourceAppPref, "Gen_Is_Send", True)
            GenReceiptEmail.DataBindings.Add("Text", BSourceAppPref, "Gen_Receipt_Email")
            GenSendAction.DataBindings.Add("Text", BSourceAppPref, "Gen_Send_Action")

            TxtSalFooter.DataBindings.Add("Text", BSourceAppPref, "Sal_Footer")

            CheckSendSMS.DataBindings.Add("Checked", BSourceAppPref, "Gen_SMS_Is_Send", True)
            SMSURL.DataBindings.Add("Text", BSourceAppPref, "Gen_SMS_URL")

            LoadNumbers()
        Catch ex As Exception
            cls.WriteError(ex.Message, "User Pref")
        End Try
    End Sub

    Sub LoadNumbers()
        Try
            cmd.CommandText = "select seq_id,curr_val from seq_table"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                Select Case dr("seq_id")
                    Case 1
                        NumPurNextID.Value = dr("Curr_Val")
                    Case 2
                        NumSalNextID.Value = dr("Curr_Val")
                    Case 3
                        NumRetCustNextID.Value = dr("Curr_Val")
                    Case 4
                        NumRetVenNextID.Value = dr("Curr_Val")
                    Case 6
                        NumDepNextID.Value = dr("Curr_Val")
                    Case 7
                        NumAdjNextID.Value = dr("Curr_Val")
                End Select
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "User Pref")
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Dim Fpath As String = ""

l:
            OpenFileDialog1.Title = "اختر صورة لعرضها علي النافذة"
            OpenFileDialog1.Filter = "Image Files|*.JPG;*.JPEG;*.png;*.Gif;"

            If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
                If MsgBox("لم يتم اختيار الصورة هل تريد اعادة الاختيار ؟", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = DialogResult.Yes Then
                    GoTo l
                End If
            Else
                Fpath = OpenFileDialog1.FileName
            End If

            GenPhotoDefBackGrd.BackgroundImage = Image.FromFile(Fpath)
        Catch ex As Exception
            Dim s As String = ""
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        MyDs.Tables("App_Preferences").RejectChanges()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectTab(0)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TabControl1.SelectTab(1)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TabControl1.SelectTab(2)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TabControl1.SelectTab(3)

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TabControl1.SelectTab(4)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TabControl1.SelectTab(5)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TabControl1.SelectTab(6)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        TabControl1.SelectTab(7)

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        'Dim m As New CreateDB
        'm.RadioNewDB.Enabled = False
        'm.RadioRecreate.Enabled = True
        'm.RadioRecreate.CheckAlign = True
        'm.ShowDialog()

        Try
            PwdDefault = InputBox("أدخل كلمة السر الخاصة بالنظام", ProjectTitle)
            If PwdDefault = "roaya123" Then
                cls.MsgInfo("برجاء الانتظار حتي يتم الانتهاء", "process has been started please donot shutdown your system")
                Me.Cursor = Cursors.WaitCursor
                cmd.CommandText = "DELETE FROM Adjustment_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Purchase_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Request_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_C_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_V_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Sales_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Dep_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Vendors_Payments"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customers_Payments"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customer_Discount_Level"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customer_Levels"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Attendance"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Check_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Check_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM Sales_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Purchase_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Request_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_C_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Return_V_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM Adjustment_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Dep_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Cards"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Discounts"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Added_Hours"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Rewards"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Tasks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Employees_Vacations"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Expenses_Details"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Expenses_Header"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Stocks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Vendors"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Pay_Salary"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Vendors"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Customers"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Ages"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Gender"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Item_Sizes"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Items_Types"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Discount_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Corporations"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Rewards_Categories"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "DELETE FROM dbo.Stocks"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE Security_Group_Details SET Granted =1"
                cmd.ExecuteNonQuery()
                cmd.CommandText = "UPDATE Seq_Table SET Curr_Val = 1"
                cmd.ExecuteNonQuery()
                Me.Cursor = Cursors.Default
                cls.MsgInfo("تم اعادة النظام للوضع الافتراضي برجاء اعادة التشغيل", "system has been returned to default settings please restart your system")
                End
            Else
                cls.MsgCritical("خطأ في ادخال كلمة السر الخاصة بالنظام", "invalid password please contact your system administrator")
            End If
        Catch ex As Exception
            cls.MsgCritical("خطأ في ادخال كلمة السر الخاصة بالنظام", "invalid password please contact your system administrator")
        End Try
    End Sub

    
End Class