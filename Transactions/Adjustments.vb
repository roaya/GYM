Public Class Adjustments

    Dim B_EndLoad As Boolean = False
    Dim B_Edited As Boolean = False
    Dim DTemp As Double
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Dim TName As String = "Adjustment_Details"
    Dim RowID, ItmID As Integer
    Dim ItmName, BarCde As String
    Dim ItmPrc As Double
    Dim BDate, BDateExpire As Date
    Dim FStkID, TStkID As Integer
    Dim RptAdj As New RptAdjustment
    Dim B_ID As Integer
    Dim Total As Integer = 0
    Dim BSourceUmDetails, BSourceItemStocks As New BindingSource
    Private TblAdj As New GeneralDataSet.adjustment_detailsDataTable
    

#Region "Order_Subs"


    Sub AddItem()
        Try
            If Quantity.Value = 0 Then
                cls.MsgExclamation("«œŒ· «·⁄œœ", "Please enter delivered quantity")

            ElseIf FromStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· „‰Â", "please select the first warehouse")

            ElseIf ToStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· «·ÌÂ", "please select the second warehouse")

            ElseIf FromStockID.Text = ToStockID.Text Then
                cls.MsgExclamation("·« Ì„ﬂ‰ ‰ﬁ· «·«’‰«› «·Ì ‰›” „‰›– «·»Ì⁄", "first warehouse cannot be the same as second warehouse")

            ElseIf ComboUmDetailID.Text = "" Then
                cls.MsgExclamation("√œŒ· ÊÕœ… «·ﬁÌ«”", "Please enter unit of measure")






                '''''For xx As Integer = 0 To DataGridView1.Rows.Count - 1
                '''''    If TblAdj.Compute("Count(Item_ID)", "Item_id=" & ItmID) > 0 Then
                '''''        cls.MsgExclamation("Â–« «·’‰› „ÊÃÊœ „”»ﬁ« ›Ì «·›« Ê—… «·Õ«·Ì…", "This item already exists at the current document")
                '''''        Exit Sub
                '''''    End If
                '''''Next
            ElseIf DataGridView2.SelectedRows.Count <= 0 Then
                cls.MsgExclamation("√Œ — «·ﬂ„ÌÂ «·„—«œ «·’—› „‰Â«", "please select a record")
            Else
                FromStockID.Enabled = False
                ToStockID.Enabled = False
                r = TblAdj.NewRow
                r("Adjustment_ID") = BillID.Text
                r("Item_ID") = ItmID
                r("Item_Name") = ComboUmDetailID.Text & " " & ItmName
                r("Barcode") = BarCde
                r("um_detail_id") = ComboUmDetailID.SelectedValue
                r("Quantity") = Quantity.Value
                r("expired_date") = DataGridView2.SelectedRows(0).Cells("expired_date").Value
                r("Price") = DataGridView2.SelectedRows(0).Cells("Price").Value

                TblAdj.Rows.Add(r)
                Quantity.Value = 0
                '  CalculateTotalBill()
                FromStockID.Enabled = False
                ToStockID.Enabled = False

                '''If MyDs.Tables("App_Preferences").Rows(0).Item("Ret_Ven_Def_Sch") = "«·«”„" Then
                '''    RadioButton1.Checked = True
                '''    ItemName.Focus()
                '''Else
                '''    RadioButton2.Checked = True
                '''    BarCode.Focus()
                '''End If
                '''Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Adj_Def_Qty")

            End If

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    'Sub CalculateTotalBill()
    '    If B_EndLoad = True Then
    '        Try
    '            If DataGridView1.Rows.Count > 0 Then
    '                CountRecords.Text = TblAdj.Compute("Count(Item_ID)", "Adjustment_ID=" & BillID.Text)
    '                'Else
    '                '    CountRecords.Text = 0
    '            End If
    '        Catch ex As Exception
    '            cls.WriteError(ex.Message, TName)
    '        End Try
    '    End If
    'End Sub

    Sub ResetOrder(ByVal IsNew As Boolean)
        Try
            'MyDs.Tables("Adjustment_Header").Rows.Clear()
            TblAdj.Rows.Clear()
            If IsNew = False Then
                BillID.Text = 0
                BtnNew.Enabled = True
                BtnSave.Enabled = False

                BtnDelete.Enabled = False
                BtnExit.Enabled = True
                B_Edited = False
                FromStockID.Enabled = True
                ToStockID.Enabled = True
                BtnSavePrint.Enabled = False
                BillDate.Text = Now
                BillTime.Text = ""
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = False
                GroupDetails.Enabled = False
                GroupAvailable.Enabled = False
                GroupItems.Enabled = False
                B_EndLoad = False
                FStkID = 0
            Else
                FromStockID.Enabled = True
                ToStockID.Enabled = True
                BtnNew.Enabled = False
                BtnSave.Enabled = True
                BtnDelete.Enabled = True
                BtnExit.Enabled = True
                B_Edited = False
                BtnSavePrint.Enabled = True
                BillDate.Text = Now
                BillTime.Text = Now.Hour & ":" & Now.Minute & ":" & Now.Second
                EmployeeID.Text = EmpNameVar
                EmployeeID.Tag = EmpIDVar
                Comments.TextBox1.Text = ""
                GroupHeader.Enabled = True
                GroupDetails.Enabled = True
                GroupAvailable.Enabled = True
                GroupItems.Enabled = True
                B_EndLoad = True
                FStkID = 0
                BSourceUmDetails.Filter = "item_id = 0"
                BSourceItemStocks.Filter = "item_id = 0 and Stock_id = 0"
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Sub Commit_Form()
        Try
            If FromStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· „‰Â", "please select the first warehouse")
            ElseIf ToStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· «·ÌÂ", "please select the second warehouse")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…", "there are no items attached to the current document")
            Else
                B_ID = BillID.Text

                ' CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & " , " & DataGridView1.Rows(i).Cells("um_detail_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & _
                        FStkID & " , '" & BDateExpire.ToString("MM/dd/yyyy") & "' )"
                    If cmd.ExecuteScalar = 1 Then
                        cls.MsgExclamation("«·—’Ìœ «·Õ«·Ì „‰ " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " ·«Ìﬂ›Ì «·ﬂ„Ì… «·„‰’—›…", "current balance from " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " dosenot fit the delivered quantity")
                        Exit Sub
                    End If
                Next

                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Adjustment_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & _
                "' , N'" & Comments.TextBox1.Text & "'," & FStkID & "," & TStkID & "," & EmpIDVar
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "Exec Commit_Adjustment_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & FStkID & "," & TStkID & "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "' , '" & BDate.ToString("MM/dd/yyyy") & "' , " & DataGridView1.Rows(i).Cells("Price").Value
                    cmd.ExecuteNonQuery()
                Next
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo(" „ Õ›Ÿ «·«–‰ »‰Ã«Õ", "Document has been saved successfully")
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
            TblAdj.Columns("Adjustment_ID").DefaultValue = BillID.Text
            ResetOrder(True)
            B_Edited = True

            '''If MyDs.Tables("App_Preferences").Rows(0).Item("Adj_Def_Sch") = "«·«”„" Then
            '''    RadioButton1.Checked = True
            '''    ItemName.Focus()
            '''Else
            '''    RadioButton2.Checked = True
            '''    BarCode.Focus()
            '''End If
            '''Quantity.Value = MyDs.Tables("App_Preferences").Rows(0).Item("Adj_Def_Qty")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Commit_Form()

    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        If MsgBox("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ì", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            'MyDs.Tables("Adjustment_Header").Rows.Clear()
            TblAdj.Rows.Clear()
            If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                cls.MsgInfo(" „ Õ–› «·›« Ê—… »‰Ã«Õ", "document has been deleted successfully")
            End If



            B_Edited = False
            Call ResetOrder(False)
        End If
    End Sub

    Private Sub Quantity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Quantity.KeyDown, DataGridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddItem()
        End If

    End Sub

    Private Sub DataGridView1_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        RowID = DataGridView1.CurrentCell.RowIndex
    End Sub

    'Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
    '    If B_EndLoad = True Then

    '        If DataGridView1.Rows.Count <= 0 Then
    '            CountRecords.Text = 0
    '        Else
    '            CalculateTotalBill()
    '            CountRecords.Text = TblAdj.Compute("Count(Item_ID)", "Adjustment_ID=" & BillID.Text)
    '        End If
    '    End If

    'End Sub



    Private Sub Adjustments_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If B_Edited = False Then
            e.Cancel = False
        Else
            e.Cancel = True
            cls.MsgExclamation("ÌÃ» Õ›Ÿ «·«–‰ «Ê Õ–›Â «Ê·«", "document must be saved or deleted first please press delete or save from the toolbar")
        End If
    End Sub

    Private Sub Adjustments_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ' cls.SetGrant(MenuItemsStocks, "‰«›–… —»ÿ «·√’‰«› »«·„Õ·« ")

            ''Dim B As New BindingSource
            ''B.DataSource = MyDs
            ''B.DataMember = "Table_Columns"
            ''B.Filter = "Table_ID ='" & TName & "'"
            ''OrderByCombo.ComboBox.DataSource = B
            ''OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            ''OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            cmd.CommandText = "select Stock_Name from Stocks"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                FromStockID.Items.Add(dr("Stock_Name"))
            Loop
            dr.Close()

            cmd.CommandText = "select Stock_Name from Stocks"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                ToStockID.Items.Add(dr("Stock_Name"))
            Loop
            dr.Close()


            DataGridView1.DataSource = TblAdj
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).HeaderText = "«”„ «·’‰›"
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(4).HeaderText = "«·»«—ﬂÊœ"
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).HeaderText = "«·⁄œœ"
            DataGridView1.Columns(7).HeaderText = " «—ÌŒ «·’·«ÕÌÂ"
            DataGridView1.Columns(8).HeaderText = "«· ﬂ·›Â"

            TblAdj.Rows.Clear()
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

            REM cls.RefreshData("Stocks")

            REM cls.RefreshData("um_details")
            cls.RefreshData("Query_Items_Um")
            BSourceUmDetails.DataSource = MyDs.Tables("Query_Items_Um")
            'BSourceUmDetails.DataMember = "Query_Items_Um"
            BSourceUmDetails.Filter = "item_id = 0"
            ComboUmDetailID.DataSource = BSourceUmDetails
            ComboUmDetailID.DisplayMember = "Equivalent_name"
            ComboUmDetailID.ValueMember = "Um_Detail_Id"

            MyDs.Tables("Items_Stocks").Columns("Total").Expression = "Balance*Price"
            cls.RefreshData(MyDs.Tables("Items_Stocks"), "Items_Stocks")
            BSourceItemStocks.DataSource = MyDs.Tables("Items_Stocks")
            'BSourceItemStocks.DataMember = "Items_Stocks"
            BSourceItemStocks.Filter = "Item_ID = 0"
            DataGridView2.DataSource = BSourceItemStocks
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(1).Visible = False
            DataGridView2.Columns(2).Visible = False
            DataGridView2.Columns(3).Visible = False
            DataGridView2.Columns(4).Visible = False
            DataGridView2.Columns(5).Visible = False
            DataGridView2.Columns(7).HeaderText = "«·—’Ìœ"
            DataGridView2.Columns(6).HeaderText = " «—ÌŒ «·’·«ÕÌÂ"
            DataGridView2.Columns(8).HeaderText = "«· ﬂ·›Â"
            DataGridView2.Columns(9).HeaderText = "«·«Ã„«·Ì"

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


    Private Sub FromStockID_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FromStockID.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                cmd.CommandText = "select Stock_id from Stocks where Stock_name = N'" & FromStockID.Text & "'"
                FStkID = cmd.ExecuteScalar

                ItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from report_Items_Stocks_balance where Stock_id = " & FStkID
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

    Private Sub ToStockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToStockID.SelectedIndexChanged
        Try
            cmd.CommandText = "select Stock_id from Stocks where Stock_name = N'" & ToStockID.Text & "'"
            TStkID = cmd.ExecuteScalar
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BarCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        Try
            If BarCode.Text <> "" Then
                If FromStockID.Text = "" Or FStkID = 0 Then
                    cls.MsgExclamation("«œŒ· «”„ „‰›– «·»Ì⁄ «·„ÕÊ· „‰Â", "please enter the first warehouse")
                    Exit Sub
                Else
                    cmd.CommandText = "select dbo.Is_Item_EXISTS(0 , NULL , N'" & BarCode.Text & "')"
                    If cmd.ExecuteScalar = 0 Then
                        cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ »Â–« «·„Œ“‰", "this item isnot attached to the current warehouse")
                        BarCode.Focus()
                        Exit Sub
                    End If
                    cmd.CommandText = "select Item_ID,item_Name from items where barcode = N'" & BarCode.Text & "'"
                    dr = cmd.ExecuteReader
                    Do While Not dr.Read = False
                        BarCde = BarCode.Text
                        ItmName = dr("Item_Name")
                        ItmID = dr("Item_ID")
                    Loop
                    dr.Close()
                    BSourceUmDetails.Filter = "item_id = " & ItmID
                    BSourceItemStocks.Filter = "item_id = " & ItmID & " and Stock_id = " & FStkID
                End If

            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            If B_EndLoad = True Then
                cmd.CommandText = "select Item_ID,barcode from items where item_name = N'" & ItemName.Text & "'"
                dr = cmd.ExecuteReader

                Do While Not dr.Read = False
                    ItmName = ItemName.Text
                    BarCde = dr("Barcode")
                    ItmID = dr("Item_ID")
                Loop
                dr.Close()

                BSourceUmDetails.Filter = "item_id = " & ItmID
                BSourceItemStocks.Filter = "item_id = " & ItmID & " and Stock_id = " & FStkID
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub BtnSavePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSavePrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            '============================
            If FromStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· „‰Â", "please select the first warehouse")
            ElseIf ToStockID.Text = "" Then
                cls.MsgExclamation("«œŒ· «”„ «·„Œ“‰ «·„ÕÊ· «·ÌÂ", "please select the second warehouse")
            ElseIf DataGridView1.Rows.Count <= 0 Then
                cls.MsgExclamation("·« ÌÊÃœ «’‰«› ›Ì «·›« Ê—…", "there are no items attached to the current document")
            Else
                B_ID = BillID.Text

                '    CalculateTotalBill()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value
                    cmd.CommandText = "select dbo.Is_Balance_Fit(" & DataGridView1.Rows(i).Cells("Item_ID").Value & " , " & DataGridView1.Rows(i).Cells("um_detail_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & " , " & _
                        FStkID & " , '" & BDateExpire.ToString("MM/dd/yyyy") & "' )"
                    If cmd.ExecuteScalar = 1 Then
                        cls.MsgExclamation("«·—’Ìœ «·Õ«·Ì „‰ " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " ·«Ìﬂ›Ì «·ﬂ„Ì… «·„‰’—›…", "current balance from " & DataGridView1.Rows(i).Cells("Item_NAME").Value & " dosenot fit the delivered quantity")
                        Exit Sub
                    End If
                Next

                BDate = BillDate.Text
                cmd.CommandText = "Exec Commit_Adjustment_Header " & BillID.Text & ", '" & BDate.ToString("MM/dd/yyyy") & "' ,'" & BillTime.Text & _
                "' , N'" & Comments.TextBox1.Text & "'," & FStkID & "," & TStkID & "," & EmpIDVar
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    BDateExpire = DataGridView1.Rows(i).Cells("Expired_Date").Value

                    cmd.CommandText = "Exec Commit_Adjustment_Details " & DataGridView1.Rows(i).Cells("Item_ID").Value & "," & DataGridView1.Rows(i).Cells("Quantity").Value & _
                    "," & FStkID & "," & TStkID & "," & BillID.Text & "," & DataGridView1.Rows(i).Cells("Um_Detail_ID").Value & ", '" & BDateExpire.ToString("MM/dd/yyyy") & "' , '" & BDate.ToString("MM/dd/yyyy") & "' , " & DataGridView1.Rows(i).Cells("Price").Value
                    cmd.ExecuteNonQuery()
                Next
                If MyDs.Tables("App_Preferences").Rows(0).Item("Gen_View_Msg") = True Then
                    cls.MsgInfo(" „ Õ›Ÿ «·«–‰ »‰Ã«Õ Ê Ã«—Ì «·ÿ»«⁄Â", "Document has been saved successfully")
                End If


                '============================

                MyDs.Tables("Report_Adjustment").Rows.Clear()
                cmd.CommandText = "select * from Report_Adjustment where Adjustment_id = " & B_ID
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Adjustment"))

                RptAdj.SetDataSource(MyDs.Tables("Report_Adjustment"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptAdj
                B_Edited = False
                Call ResetOrder(False)
                Me.Cursor = Cursors.Default
                m.ShowDialog()



            End If


        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim m As New Stocks
        m.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m As New Stocks
        m.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New Items
        m.ShowDialog()
        Try

            If B_EndLoad = True Then
                cmd.CommandText = "select Stock_id from Stocks where Stock_name = N'" & FromStockID.Text & "'"
                FStkID = cmd.ExecuteScalar

                ItemName.Items.Clear()
                cmd.CommandText = "select distinct item_name from report_Items_Stocks_balance where Stock_id = " & FStkID
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

   

    
End Class