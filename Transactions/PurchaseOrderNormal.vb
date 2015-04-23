Public Class PurchaseOrderNormal

    Dim TotalTemp, TotalDiscount, TotalTax As Double
    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Purchase_Details"
    Dim RowID, ItmID, ChqID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate, BDate1 As Date
    Dim d As Date
    Dim B_ID As Integer
    Dim BSourceUmDetails As New BindingSource
    Dim RptPur As New RptPurchaseOrder
    Private TblPuretails As New GeneralDataSet.purchase_detailsDataTable
    Private TblVendors As New GeneralDataSet.vendorsDataTable
    Private TblStocks As New GeneralDataSet.StocksDataTable
    Dim Eq_quantity As Double


#Region "Order_Subs"

    Sub AddItem()
        Try
            If Quantity.Value = 0 Then
                cls.MsgExclamation("«œŒ· «·⁄œœ", "please enter quantity")
            ElseIf DiscountTypeItem.Text <> "·« ÌÊÃœ" And DiscountValueItem.Value = 0 Then
                cls.MsgExclamation("«œŒ· ‰”»… «·Œ’„ ··’‰› «·„Õœœ", "please enter discount value for the specified item")
            ElseIf Price.Value = 0 Then
                cls.MsgExclamation("«œŒ· ”⁄— «·ÊÕœ…", "please enter item price")
            ElseIf ComboUmDetailID.Text = "" Then
                cls.MsgExclamation("√œŒ· ÊÕœ… «·ﬁÌ«”", "please select unit of measure")
            Else

                VendorID.Enabled = False
                BtnNewVendor.Enabled = False
                r = TblPuretails.NewRow
                r("Bill_ID") = BillID.Text
                r("Item_Name") = ComboUmDetailID.Text & " " & ItmName
                r("Item_ID") = ItmID
                r("Barcode") = BarCde
                r("um_detail_id") = ComboUmDetailID.SelectedValue
                r("expired_date") = ComboExpiredDate.Text
                r("Quantity") = Quantity.Value
                r("Discount_Type") = DiscountTypeItem.Text
                r("Discount_Value") = DiscountValueItem.Value




                Select Case DiscountTypeItem.Text
                    Case "„»·€ À«» "
                        If DiscountValueItem.Value >= Price.Value Then
                            cls.MsgExclamation("⁄›Ê «·Œ’„ ·« Ì„ﬂ‰ «‰ Ì ”«ÊÏ «Ê Ì“Ìœ ⁄‰ ”⁄— «·’‰›")
                            DiscountValueItem.Focus()

                            Exit Sub
                        Else
                            ItmPrc = Price.Value - DiscountValueItem.Value
                        End If
                    Case "‰”»… „∆ÊÌ…"
                        If DiscountValueItem.Value = 100 Then
                            cls.MsgExclamation("⁄›Ê ·« Ì„ﬂ‰ «⁄ÿ«¡ Œ’„ 100%")
                            DiscountValueItem.Focus()


                            Exit Sub
                        Else
                            ItmPrc = (Price.Value - (Price.Value * (DiscountValueItem.Value / 100)))
                        End If
                    Case "·« ÌÊÃœ"
                        ItmPrc = Price.Value
                End Select
                r("Price") = Price.Value
                r("Total_Item") = ItmPrc * Quantity.Value
                TblPuretails.Rows.Add(r)

                Quantity.Value = 0
                Price.Value = 0
                DiscountTypeItem.Text = "·« ÌÊÃœ"
                BarCode.Text = ""
                ItemName.Text = ""
                CalculateTotalBill()


            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            Try
                If DataGridView1.Rows.Count > 0 Then
                    TotalTemp = TblPuretails.Compute("sum(total_item)", "bill_id=" & BillID.Text)
                    CountRecords.Text = TblPuretails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
                Else
                    TotalTemp = 0
                    CountRecords.Text = 0
                End If
                'If DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                '    TotalDiscount = (TotalTemp * DiscountValue.Value) / 100
                'ElseIf DiscountType.Text = "·« ÌÊÃœ" Then
                '    TotalDiscount = 0
                'Else
                '    TotalDiscount = DiscountValue.Value
                'End If
                If DiscountType.Text = "‰”»… „∆ÊÌ…" Then

                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("⁄›Ê ·« Ì„ﬂ‰ «⁄ÿ«¡ Œ’„ 100%")
                        'DiscountValue.Focus()
                        DiscountType.Text = "·« ÌÊÃœ"
                        'Exit Sub
                    Else
                        TotalDiscount = (TotalTemp * DiscountValue.Value) / 100

                    End If

                ElseIf DiscountType.Text = "·« ÌÊÃœ" Then
                    TotalDiscount = 0
                Else
                    TotalDiscount = DiscountValue.Value
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("⁄›Ê «·Œ’„ ·« Ì„ﬂ‰ «‰ Ì ”«ÊÏ «Ê Ì“Ìœ ⁄‰ «Ã„«·Ï «·›« Ê—Â")
                        'DiscountValue.Focus()
                        DiscountType.Text = "·« ÌÊÃœ"
                        'Exit Sub

                    End If
                End If
                TotalTax = TotalTemp - TotalDiscount
                TotalBill.Text = TotalTax + (TotalTax * (Tax.Value / 100))

                RemainingValue.Text = PayedValue.Value - CDbl(TotalBill.Text)



            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If
    End Sub

    Sub CalcPayType()
        If B_EndLoad = True Then
            Select Case DiscountType.Text
                Case "„»·€ À«» "
                    DTemp = DiscountValue.Value
                Case "‰”»… „∆ÊÌ…"
                    DTemp = DiscountValue.Value * CDbl(TotalBill.Text)
                Case "·« ÌÊÃœ"
                    DTemp = 0
            End Select

            Select Case PayType.Text


                Case "‰ﬁœÌ"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
                Case "«Ã·"
                    CreditValue.Value = TotalBill.Text '- DTemp
                    CashValue.Value = 0
                    CashValue.Enabled = False
                    CreditValue.Enabled = True
                Case "»‘Ìﬂ"
                    CashValue.Value = TotalBill.Text '- DTemp
                    CreditValue.Value = 0
                    CreditValue.Enabled = False
                    CashValue.Enabled = True
                Case "‰ﬁœÌ Ê «Ã·"
                    CashValue.Value = 0
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
                Case "‘Ìﬂ Ê «Ã·"
                    CashValue.Value = 0
                    CreditValue.Value = 0
                    CreditValue.Enabled = True
                    CashValue.Enabled = True
                    ChequeID.Enabled = True
                    ChequeID.Text = ""
                    ChequeID.Tag = 0
            End Select
        End If

        ChequeID.Enabled = True
        ChequeID.Text = ""
        ChequeID.Tag = 0

    End Sub

    Sub resetOrder(ByVal IsNew As Boolean)
        TblPuretails.Rows.Clear()
        If IsNew = False Then
            BillID.Text = 0
            CashValue.Value = 0
            CreditValue.Value = 0
            BtnNew.Enabled = True
            BtnSave.Enabled = False
            BtnDelete.Enabled = False
            BtnExit.Enabled = True
            B_Edited = False
            BtnSavePrint.Enabled = False
            BillDate.Text = Now
            BillTime.Text = ""
            TotalBill.Text = 0
            DiscountValue.Value = 0
            DiscountType.Text = "·« ÌÊÃœ"
            EmployeeID.Text = EmpNameVar
            EmployeeID.Tag = EmpIDVar
            PayType.Text = "‰ﬁœÌ"
            CashValue.Value = 0
            CreditValue.Value = 0
            Comments.TextBox1.Text = ""
            GroupHeader.Enabled = False
            GroupDetails.Enabled = False
            GroupItems.Enabled = False
            DiscountTypeItem.Text = "·« ÌÊÃœ"
            DiscountValueItem.Value = 0
            DiscountValueItem.Enabled = False
            TotalTemp = 0
            B_EndLoad = False

            ChequeID.Enabled = False
            ChequeID.Tag = 0
        Else
            ItemName.Items.Clear()
            VendorID.Enabled = True
            BtnNewVendor.Enabled = True
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
            DiscountType.Text = "·« ÌÊÃœ"
            EmployeeID.Text = EmpNameVar
            EmployeeID.Tag = EmpIDVar
            PayType.Text = "‰ﬁœÌ"
            CashValue.Value = 0
            CreditValue.Value = 0
            Comments.TextBox1.Text = ""
            GroupHeader.Enabled = True
            GroupDetails.Enabled = True
            GroupItems.Enabled = True
            DiscountTypeItem.Text = "·« ÌÊÃœ"
            DiscountValueItem.Value = 0
            DiscountValueItem.Enabled = False
            TotalTemp = 0
            ChequeID.Enabled = False
            ChequeID.Tag = 0
            '-------------------------------------
            PayedValue.Value = 0
            RemainingValue.Text = 0
            '-------------------------------------
            B_EndLoad = True

        End If
    End Sub

    Sub DiscountChangeTypes(ByVal IsGeneralDiscount As Boolean)
        If B_EndLoad = True Then
            If IsGeneralDiscount = True Then
                If DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    DiscountValue.Enabled = True
                    DiscountValue.Value = 0
                    DiscountValue.Maximum = 100
                ElseIf DiscountType.Text = "„»·€ À«» " Then
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

                If DiscountTypeItem.Text = "‰”»… „∆ÊÌ…" Then
                    DiscountValueItem.Enabled = True
                    DiscountValueItem.Value = 0
                    DiscountValueItem.Maximum = 100
                ElseIf DiscountTypeItem.Text = "„»·€ À«» " Then
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
        cmd.CommandText = "select count(*) from purchase_header where bill_id = " & BillID.Text
        If cmd.ExecuteScalar > 0 Then
            cls.MsgExclamation("—ﬁ„ «·›« Ê—… „” Œœ„ „”»ﬁ« √⁄œ ÷»ÿ «⁄œ«œ«  «·‰Ÿ«„", "order id of the current document has been used before please modify documents numbers from the system settings")
            Exit Sub
        End If

        If (PayType.Text = "»‘Ìﬂ" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And ChequeID.Text = "" Then
            cls.MsgExclamation("√œŒ· —ﬁ„ «·‘Ìﬂ", "please enter cheque no")
            Exit Sub
        Else
            If ChequeID.Text <> "" Then
                cmd.CommandText = "select dbo.Is_Cheque_Valid('" & ChequeID.Text & "')"
                ChqID = cmd.ExecuteScalar
                If ChqID = 0 Then
                    cls.MsgExclamation("«·‘Ìﬂ €Ì— ’«·Õ ··«” Œœ«„", "CURRENT CHEQUE NUMBER ISNOT VALID")
                    ChequeID.Focus()
                    Exit Sub
                Else
                    ChequeID.Tag = ChqID
                End If

            End If
        End If

        If (PayType.Text = "‰ﬁœÌ Ê «Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
            cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄", "please enter payed value")
        ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
            cls.MsgExclamation("ÌÃ» «‰   ”«ÊÌ ﬁÌ„… «·„œ›Ê⁄ „⁄ «Ã„«·Ì «·›« Ê—…", "cash value plus credit value must be equal to total document")
        ElseIf VendorID.Text = "" Then
            cls.MsgExclamation("«Œ — «”„ «·„Ê—œ", "please enter vendor name")
        ElseIf PayType.Text = "" Then
            cls.MsgExclamation("«Œ — ÿ—Ìﬁ… «·œ›⁄", "please enter pay type")
        ElseIf DataGridView1.Rows.Count <= 0 Then
            cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…", "there are no items in the current document")

        Else

            Try
                B_ID = BillID.Text
                CalculateTotalBill()

                If DiscountType.Text = "„»·€ À«» " Then
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("⁄›Ê «·Œ’„ ·« Ì„ﬂ‰ «‰ Ì ”«ÊÏ «Ê Ì“Ìœ ⁄‰ «Ã„«·Ï «·›« Ê—Â")
                        'DiscountValue.Focus()
                        'Exit Sub
                        DiscountType.Text = "·« ÌÊÃœ"
                    End If

                ElseIf DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    If DiscountValue.Value = 100 Then
                        'cls.MsgExclamation("⁄›Ê ·« Ì„ﬂ‰ «⁄ÿ«¡ Œ’„ 100%")
                        'DiscountValue.Focus()
                        DiscountType.Text = "·« ÌÊÃœ"
                        Exit Sub

                    End If

                End If

                ' ''''''''''''''''''''''''''''''''''''''''
                'If MyDs.Tables("Ven_Sch_Payments").Rows.Count > 0 Then
                '    For x As Integer = 0 To MyDs.Tables("Ven_Sch_Payments").Rows.Count - 1
                '        d = MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Date")
                '        cmd.CommandText = "exec Vendor_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Vendor_ID") & " , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Value")
                '        cmd.ExecuteNonQuery()
                '    Next
                'End If
                ' ''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text

                'Vendor Transactions-----------------------------------------
                '''If CreditValue.Value > 0 Then
                '''    cmd.CommandText = "Exec COMMIT_VEN_TRAN " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,N'›« Ê—… „‘ —Ì«  - «Ã·'," & TotalBill.Text & "," & _
                '''    CreditValue.Value & "," & VendorID.SelectedValue
                '''    cmd.ExecuteNonQuery()
                '''End If
                '''If CashValue.Value > 0 Then
                '''    cmd.CommandText = "Exec COMMIT_VEN_TRAN " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,N'›« Ê—… „‘ —Ì«  - ‰ﬁœÌ'," & TotalBill.Text & "," & _
                '''    CashValue.Value & "," & VendorID.SelectedValue
                '''    cmd.ExecuteNonQuery()
                '''End If
                '-----------------------------------------


                cmd.CommandText = "Exec Commit_Purchase_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & VendorID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmpIDVar & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.SelectedValue & "," & ChequeID.Tag & "," & Tax.Value & "," & CurrentShiftID
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1

                    'cmd.CommandText = "Exec Commit_Purchase_Order_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    '"," & StockID.SelectedValue & "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    '"N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value
                    'cmd.ExecuteNonQuery()

                    '''cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE + " & DataGridView1.Rows(i).Cells("Quantity").Value & " WHERE ITEM_ID = " & DataGridView1.Rows(i).Cells("Item_ID").Value & " AND STOCK_ID = " & StockID.SelectedValue
                    '''cmd.ExecuteNonQuery()

                    BDate1 = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "Exec Commit_Purchase_Details " & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & _
                    "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & _
                    "," & StockID.SelectedValue & ", '" & BDate1.ToString("MM/dd/yyyy") & "' , '" & BDate.ToString("MM/dd/yyyy") & "'"
                    cmd.ExecuteNonQuery()

                    ''''''''''''''''''''''''''''''''''log report
                    '''cmd.CommandText = "insert into inventory_log(doc_id,doc_date,doc_Type,total_doc,item_id,quantity,Stock_ID) values(" & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,N'›« Ê—… „‘ —Ì« ' , " & TotalBill.Text & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & StockID.SelectedValue & ")"
                    '''cmd.ExecuteNonQuery()
                    '''''''''''''''''''''''''''''''''''''''''
                Next
                ''''''If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                '''''''''If ChqID <> 0 Then
                '''''''''    cmd.CommandText = "update cheques set cheque_status = N'„— »ÿ »›« Ê—Â' , direction = N'„‘ —Ì« ' where cheque_id = " & ChqID
                '''''''''    cmd.ExecuteNonQuery()
                '''''''''End If

                cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ", "document has been saved successfully")
                ''''''End If
                B_Edited = False
                Call ResetOrder(False)
            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If


    End Sub
#End Region

    Private Sub PurchaseOrderNormal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If B_Edited = True Then

            Commit_Form()
        End If
    End Sub

    Private Sub PurchaseOrderNormal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("ÌÃ» Õ›Ÿ «·›« Ê—… «Ê Õ–›Â« «Ê·«", "document must be saved or deleted first")
        End If

    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            EmployeeID.Tag = EmpIDVar
            EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            DiscountValue.Enabled = False
            CreditValue.Enabled = False
            TblPuretails.Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True


        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If CurrentShiftID = 0 Then
            cls.MsgExclamation("»—Ã«¡ ﬁ„ »› Õ Ê—œÌ… ")
            Exit Sub
        End If

        Commit_Form()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        '''''AssistantSound.Speak("do you want to delete current document")

        If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            TblPuretails.Rows.Clear()
            cls.MsgInfo(" „ Õ–› «·›« Ê—… »‰Ã«Õ", "document has been deleted successfully")
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown, Price.KeyDown, DiscountTypeItem.KeyDown, DiscountValueItem.KeyDown
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
                CountRecords.Text = TblPuretails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
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
        Try
            If DataGridView1.Rows.Count <> 0 Then
                Select Case DataGridView1.Rows(RowID).Cells("Discount_Type").Value
                    Case "„»·€ À«» "
                        DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value - DataGridView1.Rows(RowID).Cells("Discount_Value").Value
                    Case "‰”»… „∆ÊÌ…"
                        DataGridView1.Rows(RowID).Cells("Price").Value = (DataGridView1.Rows(RowID).Cells("Price").Value - (DataGridView1.Rows(RowID).Cells("Price").Value * (DataGridView1.Rows(RowID).Cells("Discount_Value").Value / 100)))
                    Case "·« ÌÊÃœ"
                        DataGridView1.Rows(RowID).Cells("Price").Value = DataGridView1.Rows(RowID).Cells("Price").Value
                End Select
                DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value
                CalculateTotalBill()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    '''Private Sub ItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ItemName.KeyDown
    '''    If e.KeyCode = Keys.Enter Then
    '''        Try
    '''            If ItemName.Text <> "" Then
    '''                cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.SelectedValue & ")"
    '''                If cmd.ExecuteScalar = 0 Then
    '''                    cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·", "this item isnot attached to the current warehouse")
    '''                Else
    '''                    cmd.CommandText = "select Purchase_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
    '''                    dr = cmd.ExecuteReader
    '''                    Do While Not dr.Read = False
    '''                        Price.Value = dr("Purchase_Price")
    '''                        ItmName = ItemName.Text
    '''                        BarCde = dr("Barcode")
    '''                        ItmID = dr("Item_ID")
    '''                    Loop
    '''                    dr.Close()
    '''                    Quantity.Value = 1
    '''                    AddItem()
    '''                End If
    '''            Else
    '''                cls.MsgExclamation("«œŒ· «”„ «·’‰›", "please enter item name")
    '''            End If
    '''        Catch ex As Exception
    '''            cls.WriteError(ex.Message, TName)
    '''        End Try
    '''    End If
    '''End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            If ItemName.Text <> "" Then
                cmd.CommandText = "select count(*) from items where item_name = N'" & ItemName.Text & "'"
                If cmd.ExecuteScalar <= 0 Then
                    cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ «⁄œ «œŒ«· «”„ «·’‰›", "Invalid Item Name")
                Else


                    cmd.CommandText = "select Purchase_price,Item_ID,Barcode from items where item_name = N'" & ItemName.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        Price.Value = dr("Purchase_Price")
                        ItmName = ItemName.Text
                        BarCde = dr("Barcode")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()

                    BSourceUmDetails.Filter = "item_id = " & ItmID
                    BSourceItemStocks.Filter = "item_id = " & ItmID & " and stock_id = " & StockID.SelectedValue

                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    '''Private Sub BarCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BarCode.KeyDown
    '''    Try
    '''        If e.KeyCode = Keys.Enter Then
    '''            If BarCode.Text <> "" Then
    '''                cmd.CommandText = "select dbo.Is_Item_Attached(0 , 'None' , '" & BarCode.Text & "' , " & StockID.SelectedValue & ")"
    '''                If cmd.ExecuteScalar = 0 Then
    '''                    cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Õ·", "this item isnot attached to the current warehouse")

    '''                Else
    '''                    cmd.CommandText = "select Purchase_price,Item_ID,item_name from items where Barcode = N'" & BarCode.Text & "'"
    '''                    dr = cmd.ExecuteReader
    '''                    Do While Not dr.Read = False
    '''                        Price.Value = dr("Purchase_Price")
    '''                        BarCde = BarCode.Text
    '''                        ItmName = dr("Item_Name")
    '''                        ItmID = dr("Item_ID")
    '''                    Loop
    '''                    dr.Close()
    '''                    Quantity.Value = 1
    '''                    AddItem()
    '''                End If
    '''            Else
    '''                cls.MsgExclamation("«œŒ· ﬂÊœ «·’‰›", "please enter barcode")
    '''            End If
    '''        End If
    '''    Catch ex As Exception
    '''        cls.WriteError(ex.Message, TName)
    '''    End Try
    '''End Sub

    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        Try
            If BarCode.Text <> "" Then

                cmd.CommandText = "select dbo.Is_Item_EXISTS(0 , NULL , N'" & BarCode.Text & "')"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Œ“‰", "this item isnot attached to the current warehouse")
                    BarCode.Focus()
                    Exit Sub
                End If
                cmd.CommandText = "select dbo.Checked_Vendor_Items(" & VendorID.SelectedValue & ",0,'" & BarCode.Text & "')"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("Â–« «·’‰› €Ì— „— »ÿ »Â–« «·„Ê—œ", "this item isnot attached to the current vendor")
                    Exit Sub
                End If
            End If

            cmd.CommandText = "select Purchase_price,Item_ID,item_Name from items where barcode = N'" & BarCode.Text & "'"
            dr = cmd.ExecuteReader

            Do While Not dr.Read = False
                Price.Value = dr("Purchase_Price")
                BarCde = BarCode.Text
                ItmName = dr("Item_Name")
                ItmID = dr("Item_ID")
            Loop
            dr.Close()

            BSourceUmDetails.Filter = "item_id = " & ItmID
            BSourceItemStocks.Filter = "item_id = " & ItmID & " and stock_id = " & StockID.SelectedValue

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub VendorID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VendorID.SelectedIndexChanged
        Try
            If B_EndLoad = True And IsVendorAdded = True Then
                cmd.CommandText = "select item_name from Query_Items_Vendors where vendor_id = " & VendorID.SelectedValue
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    ItemName.Items.Add(dr("Item_Name"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub RadioItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioItemName.CheckedChanged
        If RadioItemName.Checked = True Then
            BarCode.Enabled = False
            ItemName.Enabled = True
            ItemName.Text = ""
            BarCode.Text = ""
        End If
    End Sub

    Private Sub RadioBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBarcode.CheckedChanged
        If RadioBarcode.Checked = True Then
            BarCode.Enabled = True
            ItemName.Enabled = False
            ItemName.Text = ""
            BarCode.Text = ""
        End If
    End Sub


    Private Sub PurchaseOrderNormal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Try
        cls.RefreshData("select * from Stocks", TblStocks)
        cls.RefreshData("select * from Vendors order by vendor_name", TblVendors)

        ''Dim B As New BindingSource
        ''B.DataSource = MyDs
        ''B.DataMember = "Table_Columns"
        ''B.Filter = "Table_ID ='" & TName & "'"
        ''OrderByCombo.ComboBox.DataSource = B
        ''OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
        ''OrderByCombo.ComboBox.ValueMember = "Physical_Name"

        VendorID.DataSource = TblVendors
        VendorID.DisplayMember = "Vendor_Name"
        VendorID.ValueMember = "Vendor_ID"

        StockID.DataSource = TblStocks
        StockID.DisplayMember = "Stock_Name"
        StockID.ValueMember = "Stock_ID"


        DataGridView1.DataSource = TblPuretails
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).Visible = False
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).HeaderText = "«”„ «·’‰›"
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).HeaderText = "«·»«—ﬂÊœ"
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).HeaderText = " «—ÌŒ «·’·«ÕÌÂ"
        DataGridView1.Columns(7).HeaderText = "«·⁄œœ"
        DataGridView1.Columns(8).HeaderText = "”⁄— «·ÊÕœ…"
        DataGridView1.Columns(9).HeaderText = "‰Ê⁄ «·Œ’„"
        DataGridView1.Columns(9).ReadOnly = True
        DataGridView1.Columns(10).HeaderText = "ﬁÌ„… «·Œ’„ ⁄‰ «·’‰› «·Ê«Õœ"
        DataGridView1.Columns(10).ReadOnly = True
        DataGridView1.Columns(11).HeaderText = "«Ã„«·Ì «·’‰›"
        DataGridView1.Columns(11).ReadOnly = True


        TblPuretails.Rows.Clear()

        cmdPro.CommandType = CommandType.StoredProcedure
        cmdPro.Connection = cn


        CurID.DbType = DbType.Int32
        CurID.ParameterName = "CURR_ID"
        CurID.Direction = ParameterDirection.Output
        SeqID.DbType = DbType.Int32
        SeqID.ParameterName = "S_ID"
        SeqID.Direction = ParameterDirection.Input
        SeqID.Value = 1
        cmdPro.Parameters.Add(SeqID)
        cmdPro.Parameters.Add(CurID)
        cmdPro.CommandText = "UPDATE_SEQ"

        'cls.RefreshData("um_details")
        cls.RefreshData("Query_Items_Um")
        BSourceUmDetails.DataSource = MyDs
        BSourceUmDetails.DataMember = "Query_Items_Um"
        BSourceUmDetails.Filter = "item_id = 0"
        ComboUmDetailID.DataSource = BSourceUmDetails
        ComboUmDetailID.DisplayMember = "Equivalent_name"
        ComboUmDetailID.ValueMember = "Um_Detail_Id"

        'Catch ex As Exception
        '    cls.WriteError(ex.Message, TName)
        'End Try
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCalculator.Click
        Shell("Calc.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNewVendor.Click
        IsVendorAdded = False
        Dim m As New Vendors
        m.ShowDialog()
    End Sub


    Private Sub DiscountTypeItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DiscountTypeItem.TextChanged
        DiscountChangeTypes(False)
    End Sub

    'Private Sub BtnSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSchedule.Click
    '    Try
    '        Dim m As New VenPaymentSchedule
    '        If MyDs.Tables("Ven_Sch_Payments").Rows.Count > 0 Then
    '            For i As Integer = 0 To MyDs.Tables("Ven_Sch_Payments").Rows.Count - 1
    '                Select Case i
    '                    Case 0
    '                        m.FirstDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
    '                        m.CheckFirstPayment.Checked = True
    '                        m.FirstPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
    '                    Case 1
    '                        m.SecondDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
    '                        m.CheckSecondPayment.Checked = True
    '                        m.SecondPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
    '                    Case 2
    '                        m.ThirdDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
    '                        m.CheckThirdPayment.Checked = True
    '                        m.ThirdPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
    '                    Case 3
    '                        m.ForthDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
    '                        m.CheckForthPayment.Checked = True
    '                        m.ForthPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
    '                    Case 4
    '                        m.FifthDate.Text = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Date")
    '                        m.CheckFifthPayment.Checked = True
    '                        m.FifthPayment.Value = MyDs.Tables("Ven_Sch_Payments").Rows(i).Item("Payment_Value")
    '                End Select

    '            Next
    '        End If

    '        m.VenID = VendorID.SelectedValue
    '        m.TotalPayments.Text = CreditValue.Value
    '        m.ShowDialog()
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    Private Sub BtnSavePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        If CurrentShiftID = 0 Then
            cls.MsgExclamation("»—Ã«¡ ﬁ„ »› Õ Ê—œÌ… ")
            Exit Sub
        End If

        cmd.CommandText = "select count(*) from purchase_header where bill_id = " & BillID.Text
        If cmd.ExecuteScalar > 0 Then
            cls.MsgExclamation("—ﬁ„ «·›« Ê—… „” Œœ„ „”»ﬁ« √⁄œ ÷»ÿ «⁄œ«œ«  «·‰Ÿ«„", "order id of the current document has been used before please modify documents numbers from the system settings")
            Exit Sub
        End If

        If (PayType.Text = "»‘Ìﬂ" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And ChequeID.Text = "" Then
            cls.MsgExclamation("√œŒ· —ﬁ„ «·‘Ìﬂ", "please enter cheque no")
            Exit Sub
        Else
            If ChequeID.Text <> "" Then
                cmd.CommandText = "select dbo.Is_Cheque_Valid('" & ChequeID.Text & "')"
                ChqID = cmd.ExecuteScalar
                If ChqID = 0 Then
                    cls.MsgExclamation("«·‘Ìﬂ €Ì— ’«·Õ ··«” Œœ«„", "CURRENT CHEQUE NUMBER ISNOT VALID")
                    ChequeID.Focus()
                    Exit Sub
                Else
                    ChequeID.Tag = ChqID
                End If

            End If
        End If

        If (PayType.Text = "‰ﬁœÌ Ê «Ã·" Or PayType.Text = "‘Ìﬂ Ê «Ã·") And (CashValue.Value = 0 Or CreditValue.Value = 0) Then
            cls.MsgExclamation("«œŒ· ﬁÌ„… «·„œ›Ê⁄", "please enter payed value")
        ElseIf CashValue.Value + CreditValue.Value <> TotalBill.Text Then
            cls.MsgExclamation("ÌÃ» «‰   ”«ÊÌ ﬁÌ„… «·„œ›Ê⁄ „⁄ «Ã„«·Ì «·›« Ê—…", "cash value plus credit value must be equal to total document")
        ElseIf VendorID.Text = "" Then
            cls.MsgExclamation("«Œ — «”„ «·„Ê—œ", "please enter vendor name")
        ElseIf PayType.Text = "" Then
            cls.MsgExclamation("«Œ — ÿ—Ìﬁ… «·œ›⁄", "please enter pay type")
        ElseIf DataGridView1.Rows.Count <= 0 Then
            cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…", "there are no items in the current document")

        Else

            Try
                B_ID = BillID.Text
                CalculateTotalBill()

                If DiscountType.Text = "„»·€ À«» " Then
                    If TotalDiscount >= TotalTemp Then
                        cls.MsgExclamation("⁄›Ê «·Œ’„ ·« Ì„ﬂ‰ «‰ Ì ”«ÊÏ «Ê Ì“Ìœ ⁄‰ «Ã„«·Ï «·›« Ê—Â")
                        DiscountType.Text = ""

                    End If

                ElseIf DiscountType.Text = "‰”»… „∆ÊÌ…" Then
                    If DiscountValue.Value = 100 Then
                        cls.MsgExclamation("⁄›Ê ·« Ì„ﬂ‰ «⁄ÿ«¡ Œ’„ 100%")

                        DiscountType.Text = ""

                    End If

                End If

                ' ''''''''''''''''''''''''''''''''''''''''
                'If MyDs.Tables("Ven_Sch_Payments").Rows.Count > 0 Then
                '    For x As Integer = 0 To MyDs.Tables("Ven_Sch_Payments").Rows.Count - 1
                '        d = MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Date")
                '        cmd.CommandText = "exec Vendor_Schedule_Payments '" & d.ToString("MM/dd/yyyy") & "' , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Vendor_ID") & " , " & MyDs.Tables("Ven_Sch_Payments").Rows(x).Item("Payment_Value")
                '        cmd.ExecuteNonQuery()
                '    Next
                'End If
                ' ''''''''''''''''''''''''''''''''''''''''

                BDate = BillDate.Text

                'Vendor Transactions-----------------------------------------
                '''If CreditValue.Value > 0 Then
                '''    cmd.CommandText = "Exec COMMIT_VEN_TRAN " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,N'›« Ê—… „‘ —Ì«  - «Ã·'," & TotalBill.Text & "," & _
                '''    CreditValue.Value & "," & VendorID.SelectedValue
                '''    cmd.ExecuteNonQuery()
                '''End If
                '''If CashValue.Value > 0 Then
                '''    cmd.CommandText = "Exec COMMIT_VEN_TRAN " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,N'›« Ê—… „‘ —Ì«  - ‰ﬁœÌ'," & TotalBill.Text & "," & _
                '''    CashValue.Value & "," & VendorID.SelectedValue
                '''    cmd.ExecuteNonQuery()
                '''End If
                '-----------------------------------------


                cmd.CommandText = "Exec Commit_Purchase_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & "'," & VendorID.SelectedValue & "," & _
        TotalBill.Text & ",N'" & DiscountType.Text & "'," & DiscountValue.Value & "," & EmpIDVar & "," & CashValue.Value & "," & CreditValue.Value & ",N'" & PayType.Text & "',N'" & _
                Comments.TextBox1.Text & "',N'" & PurFooter & "'," & StockID.SelectedValue & "," & ChequeID.Tag & "," & Tax.Value & "," & CurrentShiftID
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1

                    'cmd.CommandText = "Exec Commit_Purchase_Order_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    '"," & StockID.SelectedValue & "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    '"N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value
                    'cmd.ExecuteNonQuery()

                    '''cmd.CommandText = "UPDATE ITEMS_STOCKS SET BALANCE = BALANCE + " & DataGridView1.Rows(i).Cells("Quantity").Value & " WHERE ITEM_ID = " & DataGridView1.Rows(i).Cells("Item_ID").Value & " AND STOCK_ID = " & StockID.SelectedValue
                    '''cmd.ExecuteNonQuery()

                    BDate1 = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "Exec Commit_Purchase_Details " & DataGridView1.Rows(i).Cells("Bill_ID").Value & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & _
                    "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & DataGridView1.Rows(i).Cells("Price").Value & "," & _
                    "N'" & DataGridView1.Rows(i).Cells("Discount_Type").Value & "'," & DataGridView1.Rows(i).Cells("Discount_Value").Value & "," & DataGridView1.Rows(i).Cells("Total_Item").Value & _
                    "," & StockID.SelectedValue & ", '" & BDate1.ToString("MM/dd/yyyy") & "' , '" & BDate.ToString("MM/dd/yyyy") & "'"
                    cmd.ExecuteNonQuery()

                    ''''''''''''''''''''''''''''''''''log report
                    '''cmd.CommandText = "insert into inventory_log(doc_id,doc_date,doc_Type,total_doc,item_id,quantity,Stock_ID) values(" & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,N'›« Ê—… „‘ —Ì« ' , " & TotalBill.Text & "," & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & "," & StockID.SelectedValue & ")"
                    '''cmd.ExecuteNonQuery()
                    '''''''''''''''''''''''''''''''''''''''''
                Next
                ''''''If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                ''''''If ChqID <> 0 Then
                ''''''    cmd.CommandText = "update cheques set cheque_status = N'„— »ÿ »›« Ê—Â' , direction = N'„‘ —Ì« ' where cheque_id = " & ChqID
                ''''''    cmd.ExecuteNonQuery()
                ''''''End If

                cls.MsgInfo(" „ Õ›Ÿ «·›« Ê—… »‰Ã«Õ ÊÃ«—Ì «·ÿ»«⁄Â", "document has been saved successfully please wait until printing")

                Me.Cursor = Cursors.WaitCursor

                MyDs.Tables("report_purchase").Rows.Clear()
                cmd.CommandText = "select * from report_purchase where bill_id = " & B_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("report_purchase"))
                RptPur.SetDataSource(MyDs.Tables("report_purchase"))
                'RptPur.ReportDefinition.ReportObjects(0).ObjectFormat.
                B_Edited = False
                Call ResetOrder(False)

                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptPur
                Me.Cursor = Cursors.Default
                m.ShowDialog()

                ''''''End If



            Catch ex As Exception
                cls.WriteError(ex.Message, TName)
            End Try
        End If


    End Sub

    Private Sub PayedValue_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayedValue.Validated
        CalculateTotalBill()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim m As New Cheques
        m.ShowDialog()
    End Sub

    Private Sub Tax_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tax.Leave
        CalculateTotalBill()
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
