Public Class SalesOrderNormal

    Dim TotalTemp, TotalDiscount, TotalTaxSales As Double
    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Sales_Details"
    Dim RowID, ItmID, ChqID, VsID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc, PurPrice As Double
    Dim BDate, BDateExpire As Date
    Dim d As Date
    Dim RptPur As New RptSalesOrder
    Dim RptPur2 As New RptSalesOrder2
    'Dim RptChk As New RptSalBill
    Dim B_ID As Integer
    '''' Dim BSourceUmDetails, BSourceItemStocks As New BindingSource
    Private TblCustomers As New GeneralDataSet.CustomersDataTable
    Private TblStocks As New GeneralDataSet.stocksDataTable
    Private TblEmployees As New GeneralDataSet.EmployeesDataTable
    Private TblSalesDetails As New GeneralDataSet.Sales_DetailsDataTable
    Private TblItemsStocks As New GeneralDataSet.Items_stocksDataTable
    Private SalOfferID As Integer
    Dim eq_quantity As Double
#Region "Order_Subs"

    Sub AddItem()
        If Quantity.Value = 0 Then
            cls.MsgExclamation("ادخل العدد", "please enter quantity")
        ElseIf DiscountTypeItem.Text <> "لا يوجد" And DiscountValueItem.Value = 0 Then
            cls.MsgExclamation("ادخل نسبة الخصم للصنف المحدد", "please enter discount value for the specified item")
        ElseIf Price.Value = 0 Then
            cls.MsgExclamation("ادخل سعر الوحدة", "please enter item price")

        ElseIf CustomerID.Text = "" Then
            cls.MsgExclamation("اختر اسم العميل", "please select customer name")
        ElseIf DataGridView2.SelectedRows.Count <= 0 Then
            cls.MsgExclamation("اختر الكميه المراد الصرف منها", "please select a record")
        Else
            Try

                CustomerID.Enabled = False
                BtnNewCustomer.Enabled = False


                r = TblSalesDetails.NewRow

                r("Bill_ID") = BillID.Text
                r("Item_Name") = ComboUmDetailID.Text & " " & ItmName
                r("Item_ID") = ItmID
                r("Barcode") = BarCde
                r("Trade_Name") = ComboUmDetailID.Text & " " & ItmName
                r("um_detail_id") = ComboUmDetailID.SelectedValue
                r("Item_Type") = "صنف مخزني"
                'r("Trade_Name") = ComboUmDetailID.Text & " " & ItmName
                r("expired_date") = DataGridView2.SelectedRows(0).Cells("expired_date").Value
                r("Quantity") = Quantity.Value
                r("Discount_Type") = DiscountTypeItem.Text
                r("Discount_Value") = DiscountValueItem.Value
                Select Case DiscountTypeItem.Text
                    Case "مبلغ ثابت"
                        If DiscountValueItem.Value >= Price.Value Then
                            cls.MsgExclamation("عفو الخصم لا يمكن ان يتساوى او يزيد عن سعر الصنف")
                            DiscountValueItem.Focus()

                            Exit Sub
                        Else
                            ItmPrc = Price.Value - DiscountValueItem.Value
                        End If
                    Case "نسبة مئوية"
                        If DiscountValueItem.Value = 100 Then
                            cls.MsgExclamation("عفو لا يمكن اعطاء خصم 100%")
                            DiscountValueItem.Focus()


                            Exit Sub
                        Else
                            ItmPrc = (Price.Value - (Price.Value * (DiscountValueItem.Value / 100)))
                        End If
                    Case "لا يوجد"
                        ItmPrc = Price.Value
                End Select

                r("Price") = Price.Value
                r("Total_Item") = ItmPrc * Quantity.Value
                r("Total_Cost") = DataGridView2.SelectedRows(0).Cells("Price").Value * Quantity.Value

                TblSalesDetails.Rows.Add(r)

                ''''If MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Ven_Def_Sch") = "الاسم" Then
                ''''RadioItemName.Checked = True
                ''''ItemName.Focus()
                ''''''''Else
                ''''RadioBarcode.Checked = True
                ''''BarCode.Focus()
                ''''End If

                Quantity.Value = 0
                Price.Value = 0
                DiscountTypeItem.Text = "لا يوجد"
                ItemName.Text = ""
                BarCode.Text = ""
                CalculateTotalBill()

                ''''''Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    TotalTemp = TblSalesDetails.Compute("sum(total_item)", "bill_id=" & BillID.Text)
                    CountRecords.Text = TblSalesDetails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
                Else
                    TotalTemp = 0
                    CountRecords.Text = 0
                End If
                If DiscountType.Text = "نسبة مئوية" Then

                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("عفو لا يمكن اعطاء خصم 100%")
                        'DiscountValue.Focus()
                        DiscountType.Text = "لا يوجد"
                        'Exit Sub
                    Else
                        TotalDiscount = (TotalTemp * DiscountValue.Value) / 100

                    End If

                ElseIf DiscountType.Text = "لا يوجد" Then
                    TotalDiscount = 0
                Else
                    TotalDiscount = DiscountValue.Value
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("عفو الخصم لا يمكن ان يتساوى او يزيد عن اجمالى الفاتوره")
                        'DiscountValue.Focus()
                        DiscountType.Text = "لا يوجد"
                        'Exit Sub

                    End If
                End If


                TotalBill.Text = TotalTemp - (TotalDiscount) ' + TotalTax) ' + CDbl(CardValue.Text))


                TotalTemp = TotalBill.Text


                TotalTaxSales = TotalTemp
                TotalBill.Text = TotalTaxSales + (TotalTaxSales * (Tax.Value / 100))

                RemainingValue.Text = PayedValue.Value - CDbl(TotalBill.Text)




            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalcPayType()
        If B_EndLoad = True Then
            Select Case DiscountType.Text
                Case "مبلغ ثابت"
                    DTemp = DiscountValue.Value
                Case "نسبة مئوية"
                    DTemp = DiscountValue.Value * CDbl(TotalBill.Text)
                Case "لا يوجد"
                    DTemp = 0
            End Select

            Select Case PayType.Text


                Case "نقدي"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
                Case "اجل"
                    CreditValue.Value = TotalBill.Text '- DTemp
                    CashValue.Value = 0
                    CashValue.Enabled = False
                    CreditValue.Enabled = True
                Case "بشيك"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
                Case "نقدي و اجل"
                    CashValue.Value = 0
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
                Case "شيك و اجل"
                    CashValue.Value = 0
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
                Case "فيزا"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
            End Select

            ChequeID.Enabled = True
            ChequeID.Text = ""
            ChequeID.Tag = 0

            VisaID.Enabled = True
            VisaID.Text = ""
            VisaID.Tag = 0
        End If

    End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        Try
            'MyDs.Tables("Sales_Header").Rows.Clear()
            TblSalesDetails.Rows.Clear()
            ''''''''''''''''
            cls.RefreshData("select * from Items_Stocks", TblItemsStocks)



            'StockID.Tag = ProjectSettings.CurrentStockID
            'StockID.Text = ProjectSettings.CurrentStockName
            If IsNew = False Then
                BillID.Text = 0
                CashValue.Value = 0
                CreditValue.Value = 0
                BtnNew.Enabled = True
                TblItemsStocks.Rows.Clear()
                BtnSave.Enabled = False
                BtnDelete.Enabled = False
                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = False
                BillDate.Text = Now
                BillTime.Text = ""
                Price.Value = 0
                TotalBill.Text = 0
                DiscountValue.Value = 0
                DiscountType.Text = "لا يوجد"
                'EmployeeID.Text = EmpNameVar
                'EmployeeID.Tag = EmpIDVar
                PayType.Text = "نقدي"
                CashValue.Value = 0
                CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = False
                GroupAvailable.Enabled = False
                GroupDetails.Enabled = False
                GroupItems.Enabled = False
                DiscountTypeItem.Text = "لا يوجد"
                DiscountValueItem.Value = 0
                DiscountValueItem.Enabled = False
                TotalTemp = 0
                BarCode.Text = ""
                ItemName.Text = ""
                B_EndLoad = False

                ChequeID.Enabled = False
                VisaID.Enabled = False
                ChequeID.Tag = 0
                VisaID.Tag = 0
            Else
                ItemName.Items.Clear()
                CustomerID.Enabled = True

                BtnNewCustomer.Enabled = True
                CashValue.Value = 0
                CreditValue.Value = 0
                BtnNew.Enabled = False

                BtnSave.Enabled = True
                BtnDelete.Enabled = True
                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = True
                BillDate.Text = Now
                BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
                TotalBill.Text = 0
                DiscountValue.Value = 0
                DiscountType.Text = "لا يوجد"
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                PayType.Text = "نقدي"
                CashValue.Value = 0
                CreditValue.Value = 0
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = True
                GroupDetails.Enabled = True
                GroupAvailable.Enabled = True
                GroupItems.Enabled = True
                DiscountTypeItem.Text = "لا يوجد"
                DiscountValueItem.Value = 0
                DiscountValueItem.Enabled = False

                ChequeID.Enabled = False
                VisaID.Enabled = False
                ChequeID.Tag = 0
                VisaID.Tag = 0

                If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Sch") = "الاسم" Then
                    RadioItemName.Checked = True
                    ItemName.Focus()
                Else
                    RadioBarcode.Checked = True
                    BarCode.Focus()
                End If

                If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Edit_Emp_ID") = True Then
                    EmployeeID.Enabled = True
                Else
                    EmployeeID.SelectedValue = EmpIDVar
                    EmployeeID.Enabled = False
                End If

                If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Edit_Date") = True Then
                    BillDate.Enabled = True
                Else
                    BillDate.Text = Now
                    BillDate.Enabled = False
                End If

                B_EndLoad = True

                '-------------------------------------
                PayedValue.Value = 0
                RemainingValue.Text = 0

                TotalTemp = 0

                '-------------------------------------
                BSourceUmDetails.Filter = "item_id = 0"
                BSourceItemStocks.Filter = "item_id = 0 and stock_id = 0"


            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub DiscountChangeTypes(ByVal IsGeneralDiscount As Boolean)
        If B_EndLoad = True Then
            If IsGeneralDiscount = True Then
                If DiscountType.Text = "نسبة مئوية" Then
                    DiscountValue.Enabled = True
                    DiscountValue.Value = 0
                    DiscountValue.Maximum = 100
                ElseIf DiscountType.Text = "مبلغ ثابت" Then
                    DiscountValue.Enabled = True
                    DiscountValue.Maximum = 1000000
                    DiscountValue.Value = 0
                Else
                    DiscountValue.Enabled = False
                    DiscountValue.Maximum = 0
                    DiscountValue.Value = 0
                End If
                CalculateTotalBill()
                CalcPayType()
            Else

                If DiscountTypeItem.Text = "نسبة مئوية" Then
                    DiscountValueItem.Enabled = True
                    DiscountValueItem.Value = 0
                    DiscountValueItem.Maximum = 100
                ElseIf DiscountTypeItem.Text = "مبلغ ثابت" Then
                    DiscountValueItem.Enabled = True
                    DiscountValueItem.Maximum = 1000000
                    DiscountValueItem.Value = 0
                Else
                    DiscountValueItem.Enabled = False
                    DiscountValueItem.Maximum = 0
                    DiscountValueItem.Value = 0
                End If

            End If
        End If
    End Sub

    Sub Commit_Form()
        Try

            cmd.CommandText = "select count(*) from sales_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("رقم الفاتورة مستخدم مسبقا أعد ضبط اعدادات النظام", "order id of the current document has been used before please modify documents numbers from the system settings")
                Exit Sub
            End If

            If (PayType.Text = "بشيك" Or PayType.Text = "شيك و اجل") And ChequeID.Text = "" Then
                cls.MsgExclamation("أدخل رقم الشيك", "please enter cheque no")
                Exit Sub
            Else
                If ChequeID.Text <> "" Then
                    cmd.CommandText = "select dbo.Is_Cheque_Valid('" & ChequeID.Text & "')"
                    ChqID = cmd.ExecuteScalar
                    If ChqID = 0 Then
                        cls.MsgExclamation("الشيك غير صالح للاستخدام", "CURRENT CHEQUE NUMBER ISNOT VALID")
                        ChequeID.Tag = 0
                        ChequeID.Focus()
                        Exit Sub
                    Else
                        ChequeID.Tag = ChqID
                    End If

                End If
            End If

            If (PayType.Text = "فيزا" And VisaID.Text = "") Then
                cls.MsgExclamation("أدخل رقم الفيزا", "please enter cheque no")
                Exit Sub
            Else
                If VisaID.Text <> "" Then
                    cmd.CommandText = "select dbo.Is_Visa_Valid('" & VisaID.Text & "')"
                    VsID = cmd.ExecuteScalar
                    If VsID = 0 Then
                        cls.MsgExclamation("الفيزا غير صالحه للاستخدام", "CURRENT Visa NUMBER ISNOT VALID")
                        VisaID.Tag = 0
                        VisaID.Focus()
                        Exit Sub
                    Else
                        VisaID.Tag = VsID
                    End If

                End If
            End If

            If (PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
                cls.MsgExclamation("ادخل قيمة المدفوع", "please enter payed value")
            ElseIf PayType.Text = "فيزا" And CashValue.Value = 0 Then
                cls.MsgExclamation("ادخل قيمة المدفوع", "please enter payed value")
            ElseIf PayType.Text = "نقدي" And CashValue.Value = 0 Then
                cls.MsgExclamation("ادخل قيمة المدفوع", "please enter payed value")
            ElseIf PayType.Text = "اجل" And CreditValue.Value = 0 Then
                cls.MsgExclamation("ادخل قيمة المدفوع", "please enter credit value")
            ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
                cls.MsgExclamation("يجب ان تتساوي قيمة المدفوع مع اجمالي الفاتورة", "cash value plus credit value must be equal to total document")
            ElseIf CustomerID.Text = "" Then
                cls.MsgExclamation("اختر اسم العميل", "please enter customer name")
            ElseIf PayType.Text = "" Then
                cls.MsgExclamation("اختر طريقة الدفع", "please enter pay type")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("لا يوجد اصناف في الفاتورة", "there are no items in the current document")

            Else





                B_ID = BillID.Text
                CalculateTotalBill()

                For z As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(z).Cells("Expired_Date").Value
                    cmd.CommandText = "select dbo.Check_Item_In_Stock(" & StockID.SelectedValue & "," & DataGridView1.Rows(z).Cells("Item_ID").Value & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "')"
                    'MsgBox(cmd.ExecuteScalar)
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("هذا الصنف غير موجود بتاريخ الصلاحيه المحدد", "")
                        Exit Sub
                    End If
                Next

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & " , " & DataGridView1.Rows(i).Cells("um_detail_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & _
                        StockID.SelectedValue & " , '" & BDateExpire.ToString("MM/dd/yyyy") & "' )"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("الرصيد الحالي من " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " لايكفي الكمية المنصرفة", "current balance from " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " dosenot fit the delivered quantity")
                        Exit Sub
                    End If

                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''
                If DiscountType.Text = "مبلغ ثابت" Then
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("عفو الخصم لا يمكن ان يتساوى او يزيد عن اجمالى الفاتوره")
                        DiscountType.Text = ""

                    End If

                ElseIf DiscountType.Text = "نسبة مئوية" Then
                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("عفو لا يمكن اعطاء خصم 100%")

                        DiscountType.Text = ""

                    End If

                End If
                BDate = BillDate.Text
                cmd.CommandText = "Exec commit_sales_header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmpIDVar & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.SelectedValue & "," & _
                  ChequeID.Tag & "," & VisaID.Tag & "," & Tax.Value & "," & CurrentShiftID
                cmd.ExecuteNonQuery()


                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "Exec Commit_SALES_DETAILS " & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & _
        "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
        "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & _
        "," & StockID.SelectedValue & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "' , '" & BDate.ToString("MM/dd/yyyy") & "', N'" & DataGridView1.Rows(i).Cells("Trade_Name").Value & "' ," & _
        " N'" & DataGridView1.Rows(i).Cells("Item_Type").Value & "'"

                    cmd.ExecuteNonQuery()

                Next



                cls.MsgInfo("تم حفظ الفاتورة بنجاح", "document has been saved successfully")
                '''''''End If
                B_Edited = False
                Call ResetOrder(False)
                '-----------------------------------------
                'MyDs.Tables("Sch_Payments").Rows.Clear()
                '-----------------------------------------
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub
#End Region

    Private Sub SalesOrderNormal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If B_Edited = True Then

            Commit_Form()
        End If
    End Sub

    Private Sub SalesOrderNormal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("يجب حفظ الفاتورة او حذفها اولا", "document must be saved or deleted first")
        End If

    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            'EmployeeID.Tag = EmpIDVar
            'EmployeeID.Text = EmpNameVar
            SeqID.Value = 2
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            DiscountValue.Enabled = False
            CreditValue.Enabled = False
            TblSalesDetails.Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True
           
            ''''''If MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Sch") = "الاسم" Then
            ''''''    RadioItemName.Checked = True
            ''''''    ItemName.Focus()
            ''''''Else
            ''''''    RadioBarcode.Checked = True
            ''''''    BarCode.Focus()
            ''''''End If
            ''''''OrderType.Text = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Ord_Type")

            ''''''Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Sal_Def_Qty")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If CurrentShiftID = 0 Then
            cls.MsgExclamation("برجاء قم بفتح وردية ")
            Exit Sub
        End If
        Commit_Form()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        '''''''AssistantSound.Speak("do you want to delete current document")
        If MsgBox("هل تريد حذف السجل الحالي", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            '''MyDs.Tables("Sales_Header").Rows.Clear()
            TblSalesDetails.Rows.Clear()
            '''''' If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
            cls.MsgInfo("تم حذف الفاتورة بنجاح", "document has been deleted successfully")
            '''''''End If
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown, Price.KeyDown, DataGridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddItem()
        End If

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
                CalculateTotalBill()
                CalcPayType()
                CountRecords.Text = TblSalesDetails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
            End If
        End If

    End Sub

    Private Sub DiscountValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountValue.Leave
        If DataGridView1.Rows.Count > 0 Then
            CalculateTotalBill()
        End If

    End Sub

    Private Sub DiscountType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountType.SelectedIndexChanged
        DiscountChangeTypes(True)
    End Sub

    Private Sub PayType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayType.SelectedIndexChanged

        CalcPayType()

    End Sub

    Private Sub DataGridView1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Validated
        If DataGridView1.Rows.Count <> 0 Then
            Select Case DataGridView1.Rows(RowID).Cells("Discount_Type").Value
                Case "مبلغ ثابت"
                    DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value - DataGridView1.Rows(RowID).Cells("Discount_Value").Value
                Case "نسبة مئوية"
                    DataGridView1.Rows(RowID).Cells("Price").Value = (DataGridView1.Rows(RowID).Cells("Price").Value - (DataGridView1.Rows(RowID).Cells("Price").Value * (DataGridView1.Rows(RowID).Cells("Discount_Value").Value / 100)))
                Case "لا يوجد"
                    DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value
            End Select
            DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value
        End If
        CalculateTotalBill()
    End Sub

    ''''Private Sub ItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyDown
    ''''    If e.KeyCode = Keys.Enter Then
    ''''        Try
    ''''            If ItemName.Text <> "" Then
    ''''                cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.Tag & ")"
    ''''                If cmd.ExecuteScalar = 0 Then
    ''''                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل", "this item isnot attached to the current warehouse")
    ''''                Else
    ''''                    cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
    ''''                    dr = cmd.ExecuteReader
    ''''                    Do While Not dr.Read = False
    ''''                        If OrderType.Text = "جملة" Then
    ''''                            Price.Value = dr("Sale_Total_Price")
    ''''                        Else
    ''''                            Price.Value = dr("Sale_Price")
    ''''                        End If
    ''''                        ItmName = ItemName.Text
    ''''                        BarCde = dr("Barcode")
    ''''                        ItmID = dr("Item_ID")
    ''''                    Loop
    ''''                    dr.Close()
    ''''                    Quantity.Value = 1
    ''''                    AddItem()
    ''''                End If
    ''''            Else
    ''''                cls.MsgExclamation("ادخل اسم الصنف", "please enter item name")
    ''''            End If
    ''''        Catch ex As Exception
    ''''            cls.WriteError(ex.Message, TName)
    ''''        End Try
    ''''    End If
    ''''End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        If ItemName.Text <> "" Then
            Try
                cls.RefreshData("select * from Items_Stocks", TblItemsStocks)
                BSourceItemStocks.DataSource = TblItemsStocks
                cmd.CommandText = "select dbo.Is_Item_EXISTS(1 ,N'" & ItemName.Text & "' , NULL )"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل", "this item isnot attached to the current warehouse")
                    ItemName.Focus()
                Else
                    cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,Purchase_price,Barcode from items where item_name = N'" & ItemName.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False

                        Price.Value = dr("Sale_Price")

                        ItmName = ItemName.Text
                        BarCde = dr("Barcode")
                        ItmID = dr("Item_ID")
                        PurPrice = dr("Purchase_Price")
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

    ''''Private Sub BarCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarCode.KeyDown
    ''''    If e.KeyCode = Keys.Enter Then
    ''''        Try
    ''''            If BarCode.Text <> "" Then
    ''''                cmd.CommandText = "select dbo.dbo.Is_Item_EXISTS(0 , NULL , N'" & BarCode.Text & "')"
    ''''                If cmd.ExecuteScalar = 0 Then
    ''''                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المخزن", "this item isnot attached to the current warehouse")

    ''''                Else
    ''''                    cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,item_name from items where Barcode = N'" & BarCode.Text & "'"
    ''''                    dr = cmd.ExecuteReader
    ''''                    Do While Not dr.Read = False
    ''''                        If OrderType.Text = "جملة" Then
    ''''                            Price.Value = dr("Sale_Total_Price")
    ''''                        Else
    ''''                            Price.Value = dr("Sale_Price")
    ''''                        End If
    ''''                        BarCde = BarCode.Text
    ''''                        ItmName = dr("Item_Name")
    ''''                        ItmID = dr("Item_ID")
    ''''                    Loop
    ''''                    dr.Close()
    ''''                    Quantity.Value = 1
    ''''                    AddItem()
    ''''                End If
    ''''            Else
    ''''                cls.MsgExclamation("ادخل كود الصنف", "please enter barcode")
    ''''            End If
    ''''        Catch ex As Exception
    ''''            cls.WriteError(ex.Message, TName)
    ''''        End Try
    ''''    End If
    ''''End Sub

    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        Try
            If BarCode.Text <> "" Then
                cls.RefreshData("select * from Items_Stocks", TblItemsStocks)
                BSourceItemStocks.DataSource = TblItemsStocks
                cmd.CommandText = "select dbo.Is_Item_EXISTS(0 ,NULL, N'" & BarCode.Text & "' )"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المحل", "this item isnot attached to the current warehouse")
                    BarCode.Focus()
                    Exit Sub
                End If
                'cmd.CommandText = "select dbo.Checked_Customer_Items(" & CustomerID.SelectedValue & ",0,'" & BarCode.Text & "')"
                'If cmd.ExecuteScalar = 0 Then
                '    cls.MsgExclamation("هذا الصنف غير مرتبط بهذا المورد")
                '    Exit Sub
                'End If
            End If

            cmd.CommandText = "select Sale_Total_Price,Sale_price,Item_ID,Purchase_price,item_name from items where barcode = N'" & BarCode.Text & "'"
            dr = cmd.ExecuteReader

            Do While Not dr.Read = False
               
                    Price.Value = dr("Sale_Price")

                BarCde = BarCode.Text
                ItmName = dr("Item_Name")
                ItmID = dr("Item_ID")
                PurPrice = dr("Purchase_Price")
            Loop
            dr.Close()

            BSourceUmDetails.Filter = "item_id = " & ItmID
            BSourceItemStocks.Filter = "item_id = " & ItmID & " and stock_id = " & StockID.SelectedValue

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    'Private Sub CustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerID.SelectedIndexChanged
    '    If B_EndLoad = True And IsCustomerAdded = True Then
    '        cmd.CommandText = "select item_name from Query_Items_Customers where Customer_id = " & CustomerID.SelectedValue
    '        dr = cmd.ExecuteReader
    '        Do While Not dr.Read = False
    '            ItemName.Items.Add(dr("Item_Name"))
    '        Loop
    '        dr.Close()
    '    End If
    'End Sub

    Private Sub RadioItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioItemName.CheckedChanged
        If RadioItemName.Checked = True Then
            BarCode.Enabled = False

            ItemName.Enabled = True
            ItemName.Text = ""
            BarCode.Text = ""
            TblItemsStocks.Rows.Clear()

        End If
    End Sub

    Private Sub RadioBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBarcode.CheckedChanged
        If RadioBarcode.Checked = True Then
            BarCode.Enabled = True
            ItemName.Enabled = False

            ItemName.Text = ""
            BarCode.Text = ""
            TblItemsStocks.Rows.Clear()

        End If
    End Sub


    Private Sub SalesOrderNormal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select * from Customers order by customer_name", TblCustomers)
            cls.RefreshData("select * from Employees order by employee_name", TblEmployees)
            cls.RefreshData("select * from Stocks order by stock_name", TblStocks)
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

            EmployeeID.DataSource = TblEmployees
            EmployeeID.DisplayMember = "Employee_Name"
            EmployeeID.ValueMember = "Employee_ID"

            StockID.DataSource = TblStocks
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"

            DataGridView1.DataSource = TblSalesDetails
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "اسم الصنف"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "الباركود"
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).HeaderText = "الاسم التجاري"
            DataGridView1.Columns(5).ReadOnly = True
            DataGridView1.Columns(6).HeaderText = "نوع الصنف"
            DataGridView1.Columns(6).ReadOnly = True
            DataGridView1.Columns(7).Visible = False
            DataGridView1.Columns(8).HeaderText = "تاريخ الصلاحيه"
            DataGridView1.Columns(9).HeaderText = "العدد"
            DataGridView1.Columns(10).HeaderText = "سعر الوحدة"
            DataGridView1.Columns(11).HeaderText = "نوع الخصم"
            DataGridView1.Columns(11).ReadOnly = True
            DataGridView1.Columns(12).HeaderText = "قيمة الخصم عن الصنف الواحد"
            DataGridView1.Columns(12).ReadOnly = True
            DataGridView1.Columns(13).HeaderText = "اجمالي الصنف"
            DataGridView1.Columns(13).ReadOnly = True
            DataGridView1.Columns(14).HeaderText = "اجمالي التكلفه"

            TblSalesDetails.Rows.Clear()
            ''''''MyDs.Tables("Sales_Header").Rows.Clear()

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 2
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
            REM BSourceItemStocks.DataMember = "Items_Stocks"
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
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Shell("Calc.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewCustomer.Click
        IsCustomerAdded = False
        Dim m As New Customers
        m.ShowDialog()
    End Sub


    Private Sub DiscountTypeItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountTypeItem.TextChanged
        DiscountChangeTypes(False)
    End Sub

    Private Sub PayedValue_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayedValue.Validated
        CalculateTotalBill()
    End Sub

    Private Sub BtnSavePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        If CurrentShiftID = 0 Then
            cls.MsgExclamation("برجاء قم بفتح وردية ")
            Exit Sub
        End If
        CommitPrint()
    End Sub

    Sub CommitPrint()
        Try

            cmd.CommandText = "select count(*) from sales_header where bill_id = " & BillID.Text
            If cmd.ExecuteScalar > 0 Then
                cls.MsgExclamation("رقم الفاتورة مستخدم مسبقا أعد ضبط اعدادات النظام", "order id of the current document has been used before please modify documents numbers from the system settings")
                Exit Sub
            End If

            If (PayType.Text = "بشيك" Or PayType.Text = "شيك و اجل") And ChequeID.Text = "" Then
                cls.MsgExclamation("أدخل رقم الشيك", "please enter cheque no")
                Exit Sub
            Else
                If ChequeID.Text <> "" Then
                    cmd.CommandText = "select dbo.Is_Cheque_Valid('" & ChequeID.Text & "')"
                    ChqID = cmd.ExecuteScalar
                    If ChqID = 0 Then
                        cls.MsgExclamation("الشيك غير صالح للاستخدام", "CURRENT CHEQUE NUMBER ISNOT VALID")
                        ChequeID.Tag = 0
                        ChequeID.Focus()
                        Exit Sub
                    Else
                        ChequeID.Tag = ChqID
                    End If

                End If
            End If

            If (PayType.Text = "فيزا" And VisaID.Text = "") Then
                cls.MsgExclamation("أدخل رقم الفيزا", "please enter cheque no")
                Exit Sub
            Else
                If VisaID.Text <> "" Then
                    cmd.CommandText = "select dbo.Is_Visa_Valid('" & VisaID.Text & "')"
                    VsID = cmd.ExecuteScalar
                    If VsID = 0 Then
                        cls.MsgExclamation("الفيزا غير صالحه للاستخدام", "CURRENT Visa NUMBER ISNOT VALID")
                        VisaID.Tag = 0
                        VisaID.Focus()
                        Exit Sub
                    Else
                        VisaID.Tag = VsID
                    End If

                End If
            End If

            If (PayType.Text = "نقدي و اجل" Or PayType.Text = "شيك و اجل") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
                cls.MsgExclamation("ادخل قيمة المدفوع", "please enter payed value")
            ElseIf PayType.Text = "فيزا" And CashValue.Value = 0 Then
                cls.MsgExclamation("ادخل قيمة المدفوع", "please enter payed value")
            ElseIf PayType.Text = "نقدي" And CashValue.Value = 0 Then
                cls.MsgExclamation("ادخل قيمة المدفوع", "please enter payed value")
            ElseIf PayType.Text = "اجل" And CreditValue.Value = 0 Then
                cls.MsgExclamation("ادخل قيمة المدفوع", "please enter credit value")
            ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
                cls.MsgExclamation("يجب ان تتساوي قيمة المدفوع مع اجمالي الفاتورة", "cash value plus credit value must be equal to total document")
            ElseIf CustomerID.Text = "" Then
                cls.MsgExclamation("اختر اسم العميل", "please enter customer name")
            ElseIf PayType.Text = "" Then
                cls.MsgExclamation("اختر طريقة الدفع", "please enter pay type")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("لا يوجد اصناف في الفاتورة", "there are no items in the current document")

            Else





                B_ID = BillID.Text
                CalculateTotalBill()

                For z As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(z).Cells("Expired_Date").Value
                    cmd.CommandText = "select dbo.Check_Item_In_Stock(" & StockID.SelectedValue & "," & DataGridView1.Rows(z).Cells("Item_ID").Value & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "')"
                    'MsgBox(cmd.ExecuteScalar)
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("هذا الصنف غير موجود بتاريخ الصلاحيه المحدد", "")
                        Exit Sub
                    End If
                Next

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & " , " & DataGridView1.Rows(i).Cells("um_detail_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & _
                        StockID.SelectedValue & " , '" & BDateExpire.ToString("MM/dd/yyyy") & "' )"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("الرصيد الحالي من " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " لايكفي الكمية المنصرفة", "current balance from " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " dosenot fit the delivered quantity")
                        Exit Sub
                    End If

                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''
                If DiscountType.Text = "مبلغ ثابت" Then
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("عفو الخصم لا يمكن ان يتساوى او يزيد عن اجمالى الفاتوره")
                        DiscountType.Text = ""

                    End If

                ElseIf DiscountType.Text = "نسبة مئوية" Then
                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("عفو لا يمكن اعطاء خصم 100%")

                        DiscountType.Text = ""

                    End If

                End If
                BDate = BillDate.Text
                cmd.CommandText = "Exec commit_sales_header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & CustomerID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmpIDVar & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.SelectedValue & "," & _
                  ChequeID.Tag & "," & VisaID.Tag & "," & Tax.Value & "," & CurrentShiftID
                cmd.ExecuteNonQuery()


                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "Exec Commit_SALES_DETAILS " & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & _
        "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
        "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & _
        "," & StockID.SelectedValue & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "' , '" & BDate.ToString("MM/dd/yyyy") & "', N'" & DataGridView1.Rows(i).Cells("Trade_Name").Value & "' ," & _
        " N'" & DataGridView1.Rows(i).Cells("Item_Type").Value & "'"

                    cmd.ExecuteNonQuery()

                Next



                cls.MsgInfo("تم حفظ الفاتورة بنجاح", "document has been saved successfully")
                '''''''End If
                B_Edited = False
                Call ResetOrder(False)
            End If

                Me.Cursor = Cursors.WaitCursor

                MyDs.Tables("Report_Sales").Rows.Clear()
            cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Sales where bill_id = " & B_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Sales"))
                If ComboBoxPrintType.ComboBox.Text = "نسختين" Then
                    RptPur2.SetDataSource(MyDs.Tables("Report_Sales"))
                    If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Before_Print") = False Then
                        RptPur2.PrintToPrinter(1, True, 0, 0)
                    Else
                        Dim m As New ShowAllReports
                        m.CrystalReportViewer1.ReportSource = RptPur2
                        m.ShowDialog()
                    End If
                Else
                    RptPur.SetDataSource(MyDs.Tables("Report_Sales"))
                    If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Before_Print") = False Then
                        RptPur.PrintToPrinter(1, True, 0, 0)
                    Else
                        Dim m As New ShowAllReports
                        m.CrystalReportViewer1.ReportSource = RptPur
                        m.ShowDialog()
                    End If
                End If
                Me.Cursor = Cursors.Default


            '''''''If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then


        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try

    End Sub

    

   
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New Cheques
        m.ShowDialog()
    End Sub

    Private Sub Tax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tax.Leave
        CalculateTotalBill()
    End Sub


    Private Sub StockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged

        If B_EndLoad = True Then
            ItemName.Items.Clear()
            cmd.CommandText = "select distinct item_name from Query_Items_stocks where stock_id =" & StockID.SelectedValue
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                ItemName.Items.Add(dr("Item_Name"))
            Loop
            dr.Close()
        End If

    End Sub

    Private Sub CashValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CashValue.Leave
        If B_EndLoad = True Then
            If PayType.Text = "نقدي و اجل" Then
                CreditValue.Value = CDbl(TotalBill.Text) - CashValue.Value
            End If
        End If
    End Sub

    Private Sub CreditValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreditValue.Leave
        If B_EndLoad = True Then
            If PayType.Text = "نقدي و اجل" Then
                CashValue.Value = CDbl(TotalBill.Text) - CreditValue.Value
            End If
        End If

    End Sub
    Private Sub ComboUmDetailID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboUmDetailID.Leave
        Try
            If ComboUmDetailID.Text <> "" Then
                cmd.CommandText = "select equivalent_quantity from um_details where um_detail_id=" & ComboUmDetailID.SelectedValue
                Eq_quantity = cmd.ExecuteScalar
                Price.Value = Price.Value * Eq_quantity
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub
End Class