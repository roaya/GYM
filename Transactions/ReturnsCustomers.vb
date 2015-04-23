Public Class ReturnsCustomers

    Dim TotalTemp, TotalTax As Double
    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Return_C_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate, BDateExpire As Date
    Dim RptCustRet As New RptCustomerReturns
    Dim B_ID As Integer
    Dim BSourceUmDetails, BSourceItemStocks As New BindingSource
    Private RCDetails As New GeneralDataSet.Return_C_DetailsDataTable
    Private TblCustomers As New GeneralDataSet.CustomersDataTable
    Private TblStocks As New GeneralDataSet.stocksDataTable
    Private TblItemsStocks As New GeneralDataSet.Items_stocksDataTable

#Region "Order_Subs"

    Sub AddItem()
        If Quantity.Value = 0 Then
            cls.MsgExclamation("ادخل العدد", "please enter quantity")
        ElseIf Price.Value = 0 Then
            cls.MsgExclamation("ادخل سعر الوحدة", "please enter item price")
        ElseIf ComboUmDetailID.Text = "" Then
            cls.MsgExclamation("أدخل وحدة القياس", "please select unit of measure")
        ElseIf DataGridView2.SelectedRows.Count <= 0 Then
            cls.MsgExclamation("أختر الكميه المراد الصرف منها", "please select a record")

        Else
            Try
                CustomerID.Enabled = False
                BtnNewCustomer.Enabled = False
                StockID.Enabled = False
                r = RCDetails.NewRow
                r("Bill_ID") = BillID.Text
                r("Item_Name") = ComboUmDetailID.Text & " " & ItmName
                r("Item_ID") = ItmID
                r("Barcode") = BarCde
                r("um_detail_id") = ComboUmDetailID.SelectedValue
                r("Quantity") = Quantity.Value
                r("expired_date") = DataGridView2.SelectedRows(0).Cells("expired_date").Value
                r("Price") = Price.Value
                r("Total_Item") = Price.Value * Quantity.Value
                RCDetails.Rows.Add(r)



                Quantity.Value = 0
                Price.Value = 0
                'DiscountTypeItem.Text = "لا يوجد"

                CalculateTotalBill()


            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    TotalTemp = RCDetails.Compute("sum(total_item)", "bill_id=" & BillID.Text)
                    CountRecords.Text = RCDetails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
                Else
                    TotalTemp = 0
                    CountRecords.Text = 0
                End If
                'If DiscountType.Text = "نسبة مئوية" Then
                '    TotalDiscount = (TotalTemp * DiscountValue.Value) / 100
                'ElseIf DiscountType.Text = "لا يوجد" Then
                '    TotalDiscount = 0
                'Else
                '    TotalDiscount = DiscountValue.Value
                'End If
                TotalTax = TotalTemp
                TotalBill.Text = TotalTax + (TotalTax * (Tax.Value / 100))

                '- TotalDiscount
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        Try

            ''MyDs.Tables("Return_V_Header").Rows.Clear()
            RCDetails.Rows.Clear()
            If IsNew = False Then
                BillID.Text = 0
                TblItemsStocks.Rows.Clear()
                'CashValue.Value = 0
                'CreditValue.Value = 0
                BtnNew.Enabled = True
                BtnSave.Enabled = False
                BtnDelete.Enabled = False
                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = False
                BillDate.Text = Now
                BillTime.Text = ""
                TotalBill.Text = 0
                'DiscountValue.Value = 0
                'DiscountType.Text = "لا يوجد"
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                'PayType.Text = "نقدي"
                'CashValue.Value = 0
                'CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = False
                GroupDetails.Enabled = False
                GroupItems.Enabled = False
                GroupAvailable.Enabled = False
                'DiscountTypeItem.Text = "لا يوجد"
                'DiscountValueItem.Value = 0
                'DiscountValueItem.Enabled = False
                TotalTemp = 0
                B_EndLoad = False
                ItemName.Text = ""
                BarCode.Text = ""

            Else
                ItemName.Items.Clear()
                CustomerID.Enabled = True
                BtnNewCustomer.Enabled = True
                'CashValue.Value = 0
                'CreditValue.Value = 0
                BtnNew.Enabled = False
                BtnSave.Enabled = True
                BtnDelete.Enabled = True
                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = True
                BillDate.Text = Now
                BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
                TotalBill.Text = 0
                'DiscountValue.Value = 0
                'DiscountType.Text = "لا يوجد"
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                'PayType.Text = "نقدي"
                'CashValue.Value = 0
                'CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = True
                GroupDetails.Enabled = True
                GroupItems.Enabled = True
                GroupAvailable.Enabled = True
                'DiscountTypeItem.Text = "لا يوجد"
                'DiscountValueItem.Value = 0
                'DiscountValueItem.Enabled = False
                TotalTemp = 0

                B_EndLoad = True

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub Commit_Form()
        If CustomerID.Text = "" Then
            cls.MsgExclamation("اختر اسم العميل", "please enter Customer name")
        ElseIf DataGridView1.Rows.Count <= 0 Then
            cls.MsgExclamation("لا يوجد اصناف في الفاتورة", "there are no items in the current document")
        ElseIf StockID.Text = "" Then
            cls.MsgExclamation("أدخل اسم المحل", "please enter warehouse")
        ElseIf ReturnType.Text = "" Then
            cls.MsgExclamation("أدخل طريقة الارتجاع", "")
        Else
            Try
                B_ID = BillID.Text

                CalculateTotalBill()

                BDate = BillDate.Text



                cmd.CommandText = "Exec Commit_Return_C_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & "," & EmpIDVar & ",N'" & _
                Comments.TextBox1.Text & "',N'" & ReturnType.Text & "'," & StockID.SelectedValue & "," & Tax.Value & "," & CurrentShiftID
                cmd.ExecuteNonQuery()


                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "Exec Commit_Return_C_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "' ," & _
                    DataGridView1.Rows(i).Cells("Total_Item").Value & "," & StockID.SelectedValue & ", '" & BDate.ToString("MM/dd/yyyy") & "'"
                    cmd.ExecuteNonQuery()
                Next

                cls.MsgInfo("تم حفظ الفاتورة بنجاح", "document has been saved successfully")

                B_Edited = False
                Call ResetOrder(False)
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If


    End Sub
#End Region


    Private Sub ReturnsCustomers_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If B_Edited = True Then

            Commit_Form()
        End If
    End Sub

    Private Sub ReturnsCustomers_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("يجب حفظ الفاتورة او حذفها اولا", "document must be saved or deleted first")
        End If
    End Sub

    Private Sub ReturnsCustomers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ' cls.SetGrant(MenuItemsStocks, "نافذة ربط الأصناف بالمحلات")

            cls.RefreshData("select * from Customers order by customer_name", TblCustomers)
            cls.RefreshData("select * from Stocks", TblStocks)

            ''Dim B As New BindingSource
            ''B.DataSource = MyDs
            ''B.DataMember = "Table_Columns"
            ''B.Filter = "Table_ID ='" & TName & "'"
            ''OrderByCombo.ComboBox.DataSource = B
            ''OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            ''OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            CustomerID.DataSource = TblCustomers
            CustomerID.DisplayMember = "Customer_Name"
            CustomerID.ValueMember = "Customer_ID"

            StockID.DataSource = TblStocks
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"



            DataGridView1.DataSource = RCDetails
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "اسم الصنف"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "الباركود"
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).HeaderText = "تاريخ الصلاحيه"
            DataGridView1.Columns(7).HeaderText = "العدد"
            DataGridView1.Columns(8).HeaderText = "السعر"
            DataGridView1.Columns(9).HeaderText = "اجمالي الصنف"



            RCDetails.Rows.Clear()
            'MyDs.Tables("Adjustment_Header").Rows.Clear()

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 7
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"


            REM cls.RefreshData("um_details")
            cls.RefreshData("Query_Items_Um")
            BSourceUmDetails.DataSource = MyDs
            BSourceUmDetails.DataMember = "Query_Items_Um"
            BSourceUmDetails.Filter = "item_id = 0"
            ComboUmDetailID.DataSource = BSourceUmDetails
            ComboUmDetailID.DisplayMember = "Equivalent_name"
            ComboUmDetailID.ValueMember = "Um_Detail_Id"

            TblItemsStocks.Columns("Total").Expression = "Balance*Price"

            cls.RefreshData("select * from Items_Stocks", TblItemsStocks)
            BSourceItemStocks.DataSource = TblItemsStocks
            'BSourceItemStocks.DataMember = "Items_Stocks"
            BSourceItemStocks.Filter = "Item_ID = 0"
            DataGridView2.DataSource = BSourceItemStocks
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(1).Visible = False
            DataGridView2.Columns(2).Visible = False
            DataGridView2.Columns(3).Visible = False
            DataGridView2.Columns(4).Visible = False
            DataGridView2.Columns(5).Visible = False
            DataGridView2.Columns(7).HeaderText = "الرصيد"
            DataGridView2.Columns(6).HeaderText = "تاريخ الصلاحيه"
            DataGridView2.Columns(8).HeaderText = "تكلفة الوحده"
            DataGridView2.Columns(9).HeaderText = "الاجمالي"

        Catch ex As Exception
            cls.WriteError(ex.Message, "Return Customers")
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            EmployeeID.Tag = EmpIDVar
            EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            'DiscountValue.Enabled = False
            'CreditValue.Enabled = False
            RCDetails.Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True
            TblItemsStocks.Rows.Clear()


        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                TotalBill.Text = 0
                'TotalTemp.Text = 0
                CountRecords.Text = 0
            Else
                Try
                    CalculateTotalBill()
                    'CalcPayType()
                    CountRecords.Text = RCDetails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
                Catch ex As Exception
                    cls.WriteError(ex.Message, TName)
                End Try

            End If

        End If
    End Sub

    Private Sub DataGridView1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Validated
        CalculateTotalBill()
    End Sub

    Private Sub BtnSavePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        If CurrentShiftID = 0 Then
            cls.MsgExclamation("برجاء قم بفتح وردية ")
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        If CustomerID.Text = "" Then
            cls.MsgExclamation("اختر اسم العميل", "please enter Customer name")
        ElseIf DataGridView1.Rows.Count <= 0 Then
            cls.MsgExclamation("لا يوجد اصناف في الفاتورة", "there are no items in the current document")
        ElseIf StockID.Text = "" Then
            cls.MsgExclamation("أدخل اسم المحل", "please enter warehouse")
        ElseIf ReturnType.Text = "" Then
            cls.MsgExclamation("أدخل طريقة الارتجاع", "")
        Else
            Try
                B_ID = BillID.Text

                CalculateTotalBill()

                BDate = BillDate.Text



                cmd.CommandText = "Exec Commit_Return_C_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & "," & EmpIDVar & ",N'" & _
                Comments.TextBox1.Text & "',N'" & ReturnType.Text & "'," & StockID.SelectedValue & "," & Tax.Value & "," & CurrentShiftID
                cmd.ExecuteNonQuery()


                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "Exec Commit_Return_C_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "' ," & _
                    DataGridView1.Rows(i).Cells("Total_Item").Value & "," & StockID.SelectedValue & ", '" & BDate.ToString("MM/dd/yyyy") & "'"
                    cmd.ExecuteNonQuery()
                Next


                cls.MsgInfo("تم حفظ الفاتوره و جاري الطباعه", "document has been saved successfully")

                MyDs.Tables("Report_Customers_Returns").Rows.Clear()
                cmd.CommandText = "select * from Report_Customers_Returns where bill_id = " & B_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Customers_Returns"))
                RptCustRet.SetDataSource(MyDs.Tables("Report_Customers_Returns"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptCustRet

                B_Edited = False
                Call ResetOrder(False)
                Me.Cursor = Cursors.Default
                m.ShowDialog()


            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub BtnCalculator_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Shell("Calc.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub RadioBarCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBarCode.CheckedChanged
        If RadioBarCode.Checked = True Then
            TblItemsStocks.Rows.Clear()
            BarCode.Enabled = True
            ItemName.Enabled = False
            ItemName.Text = ""
            BarCode.Text = ""

        End If

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        If ItemName.Text <> "" Then
            Try
                cls.RefreshData("select * from Items_Stocks", TblItemsStocks)
                BSourceItemStocks.DataSource = TblItemsStocks
                cmd.CommandText = "select dbo.Is_Item_EXISTS(1 ,N'" & ItemName.Text & "' , NULL )"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المخزن", "this item isnot attached to the current warehouse")

                    ItemName.Focus()
                Else
                    cmd.CommandText = "select sale_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        Price.Value = dr("sale_Price")
                        ItmName = ItemName.Text
                        BarCde = dr("Barcode")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                    BSourceUmDetails.Filter = "item_id = " & ItmID
                    BSourceItemStocks.Filter = "item_id = " & ItmID & " and stock_id = " & StockID.SelectedValue
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If

    End Sub




    Private Sub RadioItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioItemName.CheckedChanged
        If RadioItemName.Checked = True Then
            TblItemsStocks.Rows.Clear()
            BarCode.Enabled = False
            ItemName.Enabled = True
            ItemName.Text = ""
            BarCode.Text = ""

        End If

    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If CurrentShiftID = 0 Then
            cls.MsgExclamation("برجاء قم بفتح وردية ")
            Exit Sub
        End If
        Commit_Form()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        ''''''AssistantSound.Speak("do you want to delete current document")
        If MsgBox("هل تريد حذف السجل الحالي", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then

            RCDetails.Rows.Clear()
            ''''''''If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
            cls.MsgInfo("تم حذف الفاتورة بنجاح", "document has been deleted successfully")
            ''''''''End If
            B_Edited = False
            Call ResetOrder(False)
        End If

    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown, Price.KeyDown, DataGridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddItem()
        End If
    End Sub

    Private Sub StockID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged
        If B_EndLoad = True Then
            cmd.CommandText = "select distinct item_name from Query_Items_Stocks where stock_id = " & StockID.SelectedValue
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                ItemName.Items.Add(dr("Item_Name"))
            Loop
            dr.Close()
        End If
    End Sub

    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        If BarCode.Text <> "" Then
            Try
                cls.RefreshData("select * from Items_Stocks", TblItemsStocks)
                BSourceItemStocks.DataSource = TblItemsStocks
                cmd.CommandText = "select dbo.Is_Item_EXISTS(0 , NULL , N'" & BarCode.Text & "')"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المخزن", "this item isnot attached to the current warehouse")
                    TblItemsStocks.Rows.Clear()

                    BarCode.Focus()
                Else

                    cmd.CommandText = "select sale_price,Item_ID,item_name from items where BARCODE = N'" & BarCode.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        Price.Value = dr("sale_Price")
                        BarCde = BarCode.Text
                        ItmName = dr("Item_Name")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                    BSourceUmDetails.Filter = "item_id = " & ItmID
                    BSourceItemStocks.Filter = "item_id = " & ItmID & " and stock_id = " & StockID.SelectedValue
                End If
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Private Sub BtnNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewCustomer.Click
        Dim m As New Customers
        m.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m As New Stocks
        m.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New Items
        m.ShowDialog()
    End Sub

    Private Sub Tax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tax.Leave
        CalculateTotalBill()
    End Sub

    
End Class