Public Class ItemsDep

    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Dep_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc, TotalDep As Double
    Dim BDate As Date
    Dim BSourceUmDetails, BSourceItemStocks As New BindingSource
    Dim BDateExpire As Date
    Dim DepType, PartID, B_ID As Integer
    Private TblEmp As New GeneralDataSet.EmployeesDataTable
    Private TblDepDetails As New GeneralDataSet.Dep_DetailsDataTable
    Private TblProMstr As New GeneralDataSet.Procedure_MasterDataTable
    Private TblItemsStocks As New GeneralDataSet.Items_stocksDataTable
    Private TblStocks As New GeneralDataSet.StocksDataTable
    Private RptDItm As New RpDepItem

#Region "Order_Subs"


    Sub AddItem()
        Try
            If Quantity.Value = 0 Then
                cls.MsgExclamation("ادخل العدد", "please enter quantity")

            ElseIf StockID.Text = "" Then
                cls.MsgExclamation("ادخل اسم المخزن/المطعم", "please enter warehouse")

            ElseIf ComboUmDetailID.Text = "" Then
                cls.MsgExclamation("أدخل وحدة القياس", "Please enter unit of measure")


                ''''''cmd.CommandText = "select dbo.Is_Item_Attached(0 , N'" & ItemName.Text & "' , 'None' , " & StockID.SelectedValue & ")"
                ''''''If cmd.ExecuteScalar = 0 Then
                ''''''    cls.MsgExclamation("هذا الصنف غير مرتبط بالمحل", "this item isnot attached to the current warehouse")
                ''''''    Exit Sub
                ''''''End If

                ''''''For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                ''''''    If TblDepDetails.Compute("Count(Item_ID)", "Item_id=" & ItmID) > 0 Then
                ''''''        cls.MsgExclamation("هذا الصنف موجود مسبقا في الفاتورة الحالية", "this item already exists in the current document")
                ''''''        Exit Sub
                ''''''    End If
                ''''''Next
            ElseIf DataGridView2.SelectedRows.Count <= 0 Then
                cls.MsgExclamation("أختر الكميه المراد الصرف منها", "please select a record")
            Else
                StockID.Enabled = False
                r = TblDepDetails.NewRow
                r("bill_ID") = BillID.Text
                r("Item_ID") = ItmID
                r("Item_Name") = ComboUmDetailID.Text & " " & ItmName
                r("Barcode") = BarCde
                r("um_detail_id") = ComboUmDetailID.SelectedValue
                r("Quantity") = Quantity.Value
                r("expired_date") = DataGridView2.SelectedRows(0).Cells("expired_date").Value
                r("Price") = DataGridView2.SelectedRows(0).Cells("Price").Value
                r("Reason") = Reason.Text
                r("Total_Item") = DataGridView2.SelectedRows(0).Cells("Price").Value * Quantity.Value
                TblDepDetails.Rows.Add(r)
                Quantity.Value = 0
                CalculateTotalBill()
                StockID.Enabled = False

                'If MyDs.Tables("App_Preferences").Rows(0).Item("Dep_Item_Def_Sch") = "الاسم" Then
                '    RadioButton1.Checked = True
                '    ItemName.Focus()
                'Else
                '    RadioButton2.Checked = True
                '    BarCode.Focus()
                'End If
                'Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Dep_Item_Def_Qty")
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub CalculateTotalBill()
        If B_EndLoad = True Then
            'Try
            If DataGridView1.Rows.Count > 0 Then
                TotalBill.Text = TblDepDetails.Compute("sum(total_item)", "bill_id=" & BillID.Text)
                CountRecords.Text = TblDepDetails.Compute("Count(Item_ID)", "Bill_ID=" & BillID.Text)
            Else
                CountRecords.Text = 0
            End If
            'Catch ex As Exception
            'cls.WriteError(ex.Message, TName)
            ' End Try
        End If
    End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        ''''''MyDs.Tables("Dep_Header").Rows.Clear()
        TblDepDetails.Rows.Clear()
        If IsNew = False Then
            BillID.Text = 0
            BtnNew.Enabled = True
            BtnSave.Enabled = False
            BtnSavePrint.Enabled = False
            BtnDelete.Enabled = False
            BtnExit.Enabled = True
            B_Edited = False
            StockID.Enabled = True
            ' BtnSavePrint.Enabled = False
            BillDate.Text = Now
            BillTime.Text = ""
            EmployeeID.Text = EmpNameVar
            EmployeeID.Tag = EmpIDVar
            Comments.TextBox1.Text = ""
            GroupHeader.Enabled = False
            GroupDetails.Enabled = False
            GroupItems.Enabled = False
            GroupAvailable.Enabled = False
            GroupUm.Enabled = False
            B_EndLoad = False
            TblItemsStocks.Rows.Clear()

            BarCode.Text = ""
            ItemName.Text = ""

        Else
            StockID.Enabled = True
            BtnNew.Enabled = False
            BtnSave.Enabled = True
            BtnSavePrint.Enabled = True
            BtnDelete.Enabled = True
            BtnExit.Enabled = True
            B_Edited = False
            'BtnSavePrint.Enabled = True
            BillDate.Text = Now
            BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
            EmployeeID.Text = EmpNameVar
            EmployeeID.Tag = EmpIDVar
            Comments.TextBox1.Text = ""
            GroupHeader.Enabled = True
            GroupDetails.Enabled = True
            GroupItems.Enabled = True
            GroupAvailable.Enabled = True
            GroupUm.Enabled = True
            B_EndLoad = True
            BSourceUmDetails.Filter = "item_id = 0"
            BSourceItemStocks.Filter = "item_id = 0 and Stock_id = 0"
        End If
    End Sub

    Sub Commit_Form()
        Try
            If StockID.Text = "" Then
                cls.MsgExclamation("ادخل اسم المخزن/المطعم", "please enter warehouse")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("لا يوجد اصناف في الفاتورة", "there are no items in the current document")
            Else

                CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & " , " & DataGridView1.Rows(i).Cells("um_detail_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & _
                        StockID.SelectedValue & " , '" & BDateExpire.ToString("MM/dd/yyyy") & "' )"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("الرصيد الحالي من " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " لايكفي الكمية المنصرفة", "current balance from " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " dosenot fit the delivered quantity")
                        Exit Sub
                    End If
                Next

                If RadioNormal.Checked = True Then
                    DepType = 1
                    PartID = 0
                ElseIf RadioEmployeeID.Checked = True Then
                    DepType = 2
                    PartID = 0
                ElseIf RadioPartnerID.Checked = True Then
                    DepType = 3
                    PartID = PartnerID.SelectedValue
                End If

                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Dep_item_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & _
                "' , N'" & Comments.TextBox1.Text & "'," & StockID.SelectedValue & "," & EmpIDVar & "," & TotalBill.Text & "," & DepType & "," & PartID & "," & TotalBill.Text & "," & CurrentShiftId
                cmd.ExecuteNonQuery()
                TotalDep = 0
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    cmd.CommandText = "select " & DataGridView1.Rows(i).Cells("Quantity").Value & " * purchase_price from items where item_id = " & DataGridView1.Rows(i).Cells("Item_ID").Value
                    TotalDep = TotalDep + cmd.ExecuteScalar
                    cmd.CommandText = "Exec Commit_Dep_Item_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & StockID.SelectedValue & "," & BillID.Text & ", N'" & DataGridView1.Rows(i).Cells("Reason").Value & "' ," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "' , '" & BDate.ToString("MM/dd/yyyy") & "'," & DataGridView1.Rows(i).Cells("Total_Item").Value & "," & DataGridView1.Rows(i).Cells("Price").Value

                    cmd.ExecuteNonQuery()
                Next

                'cmd.CommandText = "insert into procedure_details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date) values(8,1," & TotalDep & ",GetDate())"
                'cmd.ExecuteNonQuery()

                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo("تم حفظ الاذن بنجاح", "document has been saved successfully")
                End If
                B_Edited = False
                Call ResetOrder(False)

            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub
#End Region

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try

            EmployeeID.Tag = EmpIDVar
            EmployeeID.Text = EmpNameVar
            cmdPro.ExecuteNonQuery()
            BillID.Text = CurID.Value
            TblDepDetails.Columns("Bill_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True

            'If MyDs.Tables("App_Preferences").Rows(0).Item("Dep_Item_Def_Sch") = "الاسم" Then
            '    RadioButton1.Checked = True
            '    ItemName.Focus()
            'Else
            '    RadioButton2.Checked = True
            '    BarCode.Focus()
            'End If
            'Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Dep_Item_Def_Qty")

            cls.RefreshData("select * from Items_Stocks", TblItemsStocks)
            BSourceItemStocks.DataSource = TblItemsStocks

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If CurrentShiftId = 0 Then
            cls.MsgExclamation("برجاء قم بفتح وردية ")
            Exit Sub
        End If
        Commit_Form()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        ''''''''AssistantSound.Speak("do you want to delete current document")
        If MsgBox("هل تريد حذف السجل الحالي", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            'MyDs.Tables("Dep_Header").Rows.Clear()
            TblDepDetails.Rows.Clear()
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo("تم حذف الفاتورة بنجاح", "document has been deleted successfully")
            End If
            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown, Reason.KeyDown, DataGridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddItem()
        End If

    End Sub



    Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                CountRecords.Text = 0
            Else
                CalculateTotalBill()
                CountRecords.Text = TblDepDetails.Compute("Count(Item_ID)", "Bill_ID=" & BillID.Text)
            End If
        End If

    End Sub



    Private Sub Adjustments_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("يجب حفظ الاذن او حذفه اولا", "document must be saved or deleted first please select save of delete icon from the toolbar")
        End If
    End Sub

    Private Sub Adjustments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("select * from Stocks", TblStocks)
            cls.RefreshData("select * from Employees", TblEmp)
            cls.FillSelectedTable("select * from procedure_master where procedure_category=N'جاري الشريك'", TblProMstr)

            'Dim B As New BindingSource
            'B.DataSource = MyDs
            'B.DataMember = "Table_Columns"
            'B.Filter = "Table_ID ='" & TName & "'"
            'OrderByCombo.ComboBox.DataSource = B
            'OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            'OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            StockID.DataSource = TblStocks
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"

            EmployeeIDDep.DataSource = TblEmp
            EmployeeIDDep.DisplayMember = "Employee_Name"
            EmployeeIDDep.ValueMember = "Employee_ID"

            PartnerID.DataSource = TblProMstr
            PartnerID.DisplayMember = "Daily_Procedure_Name"
            PartnerID.ValueMember = "Procedure_Master_ID"

            DataGridView1.DataSource = TblDepDetails
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "اسم الصنف"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "الباركود"
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).HeaderText = "العدد"
            DataGridView1.Columns(7).HeaderText = "السبب"
            DataGridView1.Columns(8).HeaderText = "تاريخ الصلاحيه"
            DataGridView1.Columns(9).HeaderText = "التكلفه"
            DataGridView1.Columns(10).HeaderText = "الاجمالي"

            TblDepDetails.Rows.Clear()
            'MyDs.Tables("Dep_Header").Rows.Clear()

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 6
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
            DataGridView2.Columns(9).HeaderText = "اجمالي التكلفه"


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



    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        Try

            If BarCode.Text <> "" Then
                cls.RefreshData("select * from Items_Stocks", TblItemsStocks)
                BSourceItemStocks.DataSource = TblItemsStocks
                cmd.CommandText = "select dbo.Is_Item_EXISTS(0 , NULL , N'" & BarCode.Text & "')"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المخزن", "this item isnot attached to the current warehouse")
                    BarCode.Focus()
                Else

                    cmd.CommandText = "select Item_ID,item_Name from items where barcode = N'" & BarCode.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        BarCde = BarCode.Text
                        ItmName = dr("Item_Name")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                    BSourceUmDetails.Filter = "item_id = " & ItmID
                    BSourceItemStocks.Filter = "item_id = " & ItmID & " and Stock_id = " & StockID.SelectedValue

                End If
                'Else
                '    TblItemsStocks.Rows.Clear()
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            If ItemName.Text <> "" Then
                cls.RefreshData("select * from Items_Stocks", TblItemsStocks)
                BSourceItemStocks.DataSource = TblItemsStocks
                cmd.CommandText = "select dbo.Is_Item_EXISTS(1 ,N'" & ItemName.Text & "' , NULL )"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgExclamation("هذا الصنف غير موجود بهذا المخزن", "this item isnot attached to the current warehouse")
                    BarCode.Focus()
                Else
                    cmd.CommandText = "select Item_ID,barcode from items where item_name = N'" & ItemName.Text & "'"
                    dr = cmd.ExecuteReader

                    Do While Not dr.Read = False
                        ItmName = ItemName.Text
                        BarCde = dr("Barcode")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                    BSourceUmDetails.Filter = "item_id = " & ItmID
                    BSourceItemStocks.Filter = "item_id = " & ItmID & " and Stock_id = " & StockID.SelectedValue

                End If
                'Else
                '    TblItemsStocks.Rows.Clear()
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub StockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockID.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                ItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from Query_Items_Stocks where Stock_id = " & StockID.SelectedValue
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

    Private Sub DataGridView1_CellBeginEdit1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        cls.MsgExclamation("أدخل البيانات بطريقه صحيحه", "")
    End Sub

    Private Sub DataGridView1_RowsRemoved1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        If B_EndLoad = True Then

            If DataGridView1.Rows.Count <= 0 Then
                TotalBill.Text = 0
                'TotalTemp.Text = 0
                CountRecords.Text = 0
            Else
                CalculateTotalBill()

                CountRecords.Text = TblDepDetails.Compute("Count(Item_ID)", "bill_id=" & BillID.Text)
            End If
        End If
    End Sub

    Private Sub DataGridView1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.Validated
        Try
            If DataGridView1.Rows.Count <> 0 Then
                DataGridView1.Rows(RowID).Cells("Total_Item").Value = DataGridView1.Rows(RowID).Cells("Price").Value * DataGridView1.Rows(RowID).Cells("Quantity").Value
                CalculateTotalBill()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        Try
            If StockID.Text = "" Then
                cls.MsgExclamation("ادخل اسم المخزن/المطعم", "please enter warehouse")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("لا يوجد اصناف في الفاتورة", "there are no items in the current document")
            ElseIf CurrentShiftId = 0 Then
                    cls.MsgExclamation("برجاء قم بفتح وردية ")
                    Exit Sub
            Else
                CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & " , " & DataGridView1.Rows(i).Cells("um_detail_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & _
                        StockID.SelectedValue & " , '" & BDateExpire.ToString("MM/dd/yyyy") & "' )"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("الرصيد الحالي من " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " لايكفي الكمية المنصرفة", "current balance from " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " dosenot fit the delivered quantity")
                        Exit Sub
                    End If
                Next

                B_ID = BillID.Text

                If RadioNormal.Checked = True Then
                    DepType = 1
                    PartID = 0
                ElseIf RadioEmployeeID.Checked = True Then
                    DepType = 2
                    PartID = 0
                ElseIf RadioPartnerID.Checked = True Then
                    DepType = 3
                    PartID = PartnerID.SelectedValue
                End If

                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Dep_item_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & _
                "' , N'" & Comments.TextBox1.Text & "'," & StockID.SelectedValue & "," & EmpIDVar & "," & TotalBill.Text & "," & DepType & "," & PartID & "," & TotalBill.Text & "," & CurrentShiftId
                cmd.ExecuteNonQuery()
                TotalDep = 0
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    cmd.CommandText = "select " & DataGridView1.Rows(i).Cells("Quantity").Value & " * purchase_price from items where item_id = " & DataGridView1.Rows(i).Cells("Item_ID").Value
                    TotalDep = TotalDep + cmd.ExecuteScalar
                    cmd.CommandText = "Exec Commit_Dep_Item_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & StockID.SelectedValue & "," & BillID.Text & ", N'" & DataGridView1.Rows(i).Cells("Reason").Value & "' ," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "' , '" & BDate.ToString("MM/dd/yyyy") & "'," & DataGridView1.Rows(i).Cells("Total_Item").Value & "," & DataGridView1.Rows(i).Cells("Price").Value

                    cmd.ExecuteNonQuery()
                Next

                'cmd.CommandText = "insert into procedure_details(From_Procedure_Master_ID,To_Procedure_Master_ID,Procedure_Value,Procedure_Date) values(8,1," & TotalDep & ",GetDate())"
                'cmd.ExecuteNonQuery()

                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo("تم حفظ الاذن بنجاح و جاري الطباعه", "document has been saved successfully")
                End If
                B_Edited = False
                Call ResetOrder(False)

                Me.Cursor = Cursors.WaitCursor

                MyDs.Tables("Report_Dep_Items").Rows.Clear()
                cmd.CommandText = "select * from Report_Dep_Items where bill_id = " & B_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Dep_Items"))


                RptDItm.SetDataSource(MyDs.Tables("Report_Dep_Items"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptDItm
                m.ShowDialog()
                Me.Cursor = Cursors.Default
            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            ItemName.Enabled = True
            BarCode.Enabled = False
            BarCode.Text = ""

            TblItemsStocks.Rows.Clear()



        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ItemName.Enabled = False
            BarCode.Enabled = True
            ItemName.Text = ""

            TblItemsStocks.Rows.Clear()

        End If
    End Sub
End Class