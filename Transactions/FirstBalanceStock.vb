Public Class FirstBalanceStock

    Dim B_EndLoad As Boolean = False
    Dim BSourceItemsStocks As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Items_Stocks"
    '-------------------------------
    Dim cmdb As New SqlClient.SqlCommandBuilder
    Dim ItmID As Integer
    Dim Err As String
    Private StkTbl As New GeneralDataSet.stocksDataTable


    Private Sub FirstBalanceStock_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If MsgBox("Â·  —Ìœ  €ÌÌ— ﬁÌ„… —’Ìœ Õ”«» √Ê· «·„œÂ »‰«¡ ⁄·Ì «·ﬁÌ„Â «·Õ«·ÌÂ ··„Œ“‰", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = MsgBoxResult.Yes Then
            cmd.CommandText = "UPDATE Procedure_Master SET Balance=(SELECT ISNULL(SUM(BALANCE*PRICE),0) FROM Items_stocks) WHERE Procedure_Master_ID=13"
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        
            cls.RefreshData("select * from Stocks", StkTbl)

           

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            cls.LoadList("Item_Name", "Items", ComboItemID)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------



            StockID.DataSource = StkTbl
            StockID.DisplayMember = "Stock_Name"
            StockID.ValueMember = "Stock_ID"

            BSourceItemsStocks.DataSource = MyDs
            BSourceItemsStocks.DataMember = "Items_Stocks"

            MyDs.Tables("Items_Stocks").Rows.Clear()

            DataGridView1.DataSource = BSourceItemsStocks
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "«”„ «·„Œ“‰"
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).HeaderText = "«”„ «·’‰›"
            DataGridView1.Columns(5).HeaderText = "«·»«—ﬂÊœ"
            DataGridView1.Columns(6).HeaderText = " «—ÌŒ «·’·«ÕÌÂ"
            DataGridView1.Columns(7).HeaderText = "«·—’Ìœ"
            DataGridView1.Columns(8).HeaderText = "«· ﬂ·›Â"
            DataGridView1.Columns(9).HeaderText = "«·«Ã„«·Ì"

            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).ReadOnly = True
            DataGridView1.Columns(9).ReadOnly = True

            SSource = BSourceItemsStocks

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Gender_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            If StockID.Text = "" Then
                cls.MsgExclamation("√œŒ· «”„ «·„Œ“‰", "please select warehouse")
            ElseIf ComboItemID.Text = "" Then
                cls.MsgExclamation("√œŒ· «”„ «·’‰›", "please enter item name")
            Else
                cmd.CommandText = "Select count(*) from items  where item_name = N'" & ComboItemID.Text & "'"
                If cmd.ExecuteScalar <= 0 Then
                    cls.MsgExclamation("Â–« «·’‰› €Ì— „ÊÃÊœ")
                Else
                    cmd.CommandText = "select item_id from items where item_name = N'" & ComboItemID.Text & "'"
                    ItmID = cmd.ExecuteScalar
                    MyDs.Tables("Items_Stocks").Rows.Clear()
                    cmd.CommandText = "select * from Query_Items_Stocks where stock_id = " & StockID.SelectedValue & " and item_id = " & ItmID
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Items_Stocks"))
                    BtnNew.Enabled = True
                    BtnSave.Enabled = True
                    'MenuSave.Enabled = True
                    BtnSearch.Enabled = False
                    StockID.Enabled = False
                    ComboItemID.Enabled = False
                End If


            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells("Price").Value Is Nothing Or DataGridView1.Rows(i).Cells("Price").Value Is DBNull.Value Or DataGridView1.Rows(i).Cells("Expired_Date").Value Is Nothing Or DataGridView1.Rows(i).Cells("Expired_Date").Value Is DBNull.Value Then
                    cls.MsgComplete()
                    Exit Sub
                End If
            Next
            BSourceItemsStocks.EndEdit()
            cmd.CommandText = "select * from " & TName
            cmdb.DataAdapter = da
            da.Update(MyDs.Tables(TName))
            BtnSave.Enabled = False
            'MenuSave.Enabled = False
            BtnSearch.Enabled = True
            BtnNew.Enabled = False
            MyDs.Tables("Items_Stocks").Rows.Clear()
            StockID.Enabled = True
            ComboItemID.Enabled = True
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

   

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BSourceItemsStocks.MoveLast()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BSourceItemsStocks.MoveNext()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BSourceItemsStocks.MovePrevious()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            BSourceItemsStocks.MoveFirst()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try

            Me.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub




    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        MyDs.Tables("Items_Stocks").Columns("Stock_ID").DefaultValue = StockID.SelectedValue
        MyDs.Tables("Items_Stocks").Columns("Item_ID").DefaultValue = ItmID
        MyDs.Tables("Items_Stocks").Columns("Item_Name").DefaultValue = ComboItemID.Text
        MyDs.Tables("Items_Stocks").Columns("Stock_Name").DefaultValue = StockID.Text
        cmd.CommandText = "select barcode from items where item_id = " & ItmID
        MyDs.Tables("Items_Stocks").Columns("barcode").DefaultValue = cmd.ExecuteScalar

        BSourceItemsStocks.AddNew()
        BtnSearch.Enabled = False
    End Sub

    Private Sub DataGridView1_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowValidated
        Try
            If DataGridView1.Rows.Count > 0 Then
                TotalCost.Text = MyDs.Tables("Items_Stocks").Compute("Sum(Total)", "Stock_ID=" & StockID.SelectedValue)
            End If
        Catch ex As Exception
            Err = ""
        End Try
    End Sub

    Private Sub ComboItemID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboItemID.GotFocus
        ComboItemID.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub ComboItemID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboItemID.Leave
        ComboItemID.BackColor = Color.Gainsboro
    End Sub
End Class
