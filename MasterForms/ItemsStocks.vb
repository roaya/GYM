Public Class ItemsStocks

    'Dim T, TB As System.Threading.Thread
    Dim BSourceItemsStocks As New BindingSource
    Dim cmdb As New SqlClient.SqlCommandBuilder


    Private Sub ItemsVendors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            cls.RefreshData("Stocks")
            ComboStocks.ComboBox.DataSource = MyDs
            ComboStocks.ComboBox.DisplayMember = "Stocks.Stock_Name"
            ComboStocks.ComboBox.ValueMember = "Stocks.Stock_ID"

            cls.RefreshData("Items", "Item_Name")
            cls.RefreshData("Items_Stocks")

            SourceList.DataSource = MyDs
            SourceList.DisplayMember = "Items.Item_Name"
            SourceList.ValueMember = "Items.Item_ID"


            BSourceItemsStocks.DataSource = MyDs
            BSourceItemsStocks.DataMember = "Items_Stocks"
            BSourceItemsStocks.Filter = "stock_id=0"

            DataGridView1.DataSource = BSourceItemsStocks

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "«”„ «·„Œ“‰"
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).HeaderText = "«”„ «·’‰›"
            DataGridView1.Columns(5).HeaderText = "«·»«—ﬂÊœ"
            DataGridView1.Columns(6).HeaderText = "«·—’Ìœ"
            DataGridView1.Columns(7).HeaderText = " «—ÌŒ «·‘—«¡"

            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(4).ReadOnly = True
            DataGridView1.Columns(5).ReadOnly = True

            DataGridView1.Columns(4).CellTemplate.Style.Format = "dd/MM/yyyy"

        Catch ex As Exception
            cls.WriteError(ex.Message, "Items Stocks")
        End Try
    End Sub

    
    'Sub RunWorker()
    '    ProgressBar1.Visible = True
    '    ' TabControl1.SelectTab(1)
    'End Sub

    'Sub RunWorkerBefore()
    '    BeforeBar.Visible = True
    '    ' TabControl1.SelectTab(1)
    'End Sub

   

    
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    
    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        BSourceItemsStocks.AddNew()

    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click

        MyDs.Tables("Items_Stocks").Columns("Stock_ID").DefaultValue = ComboStocks.ComboBox.SelectedValue
        MyDs.Tables("Items_Stocks").Columns("Item_ID").DefaultValue = SourceList.SelectedValue

        BSourceItemsStocks.Filter = "stock_id = " & ComboStocks.ComboBox.SelectedValue & " and item_id = " & SourceList.SelectedValue

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        BSourceItemsStocks.EndEdit()
        cmd.CommandText = "select * from items_stocks"
        cmdb.DataAdapter = da
        da.Update(MyDs.Tables("items_stocks"))
        cls.MsgInfo(" „ Õ›Ÿ «·»Ì«‰«  »‰Ã«Õ")
        cls.RefreshData("Items_Stocks")
        'BtnNew.Enabled = True
        'BtnSearch.Enabled = True
    End Sub
End Class