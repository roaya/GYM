Public Class ReportAdjustments


    Dim RptAdj As New Report_Adjustments
    Private b As Boolean = False

    Private Sub ReportAdjustments_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        b = False
    End Sub

    Private Sub QueryItemsDep_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("Items")
            ItemName.DataSource = MyDs
            ItemName.DisplayMember = "Items.Item_Name"
            ItemName.ValueMember = "Items.Item_ID"


            FromStockID.Items.Clear()
            cmd.CommandText = "select stock_name from stocks"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                FromStockID.Items.Add(dr("stock_name"))
            Loop
            dr.Close()

            ToStockID.Items.Clear()
            cmd.CommandText = "select stock_name from stocks"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                ToStockID.Items.Add(dr("stock_name"))
            Loop
            dr.Close()

            b = True
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Adj")
        End Try
    End Sub

    Private Sub RadioToStockID_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioToStockID.CheckedChanged
        If RadioToStockID.Checked = True Then
            ToStockID.Enabled = True
            ItemName.Enabled = False
            Barcode.Enabled = False
            FromStockID.Enabled = False
        End If
    End Sub

    Private Sub RadioItemName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioItemName.CheckedChanged
        If RadioItemName.Checked = True Then
            ToStockID.Enabled = False
            ItemName.Enabled = True
            Barcode.Enabled = False
            FromStockID.Enabled = False
        End If
    End Sub

    Private Sub RadioBarCode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBarCode.CheckedChanged
        If RadioBarCode.Checked = True Then
            ToStockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = True
            FromStockID.Enabled = False
        End If
    End Sub

    Private Sub RadioStockName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioStockName.CheckedChanged
        If RadioStockName.Checked = True Then
            ToStockID.Enabled = False
            ItemName.Enabled = False
            Barcode.Enabled = False
            FromStockID.Enabled = True
        End If
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If BillID.Text = "" Then
                cls.MsgExclamation("اختر رقم الفاتورة", "please enter document ID")
            Else
                MyDs.Tables("Report_Adjustments").Rows.Clear()
                cmd.CommandText = "select *,(select logo from app_preferences) as logo from Report_Adjustments where Adjustment_id = " & BillID.Text
                da.SelectCommand = cmd
                da.Fill(MyDs.Tables("Report_Adjustments"))

                RptAdj.SetDataSource(MyDs.Tables("Report_Adjustments"))
                RptAdj.SetParameterValue("P_HeaderReport", MyDs.Tables("App_Preferences").Rows(0).Item("P_HeaderReport"))
                Dim m As New ShowAllReports
                m.CrystalReportViewer1.ReportSource = RptAdj
                m.ShowDialog()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Adj")
        End Try
    End Sub

    Private Sub ToStockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToStockID.SelectedIndexChanged
        Try
            If b = True Then
                cmd.CommandText = "select distinct adjustment_id from Report_Adjustments where to_stock = N'" & ToStockID.Text & "'"
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("adjustment_id"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Adj")
        End Try
    End Sub

    Private Sub FromStockID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FromStockID.SelectedIndexChanged
        Try
            If b = True Then

                cmd.CommandText = "select distinct  adjustment_id from Report_Adjustments where from_stock = N'" & FromStockID.Text & "'"
                BillID.Items.Clear()
                dr = cmd.ExecuteReader
                Do While Not dr.Read = False
                    BillID.Items.Add(dr("adjustment_id"))
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Adj")
        End Try
    End Sub

    Private Sub ItemName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ItemName.Leave
        Try
            cmd.CommandText = "select distinct adjustment_id from Report_Adjustments where item_id = " & ItemName.SelectedValue
            BillID.Items.Clear()
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                BillID.Items.Add(dr("adjustment_id"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Adj")
        End Try
    End Sub

    Private Sub Barcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Barcode.Leave
        Try
            cmd.CommandText = "select distinct adjustment_id from Report_Adjustments where barcode = N'" & Barcode.Text & "'"
            BillID.Items.Clear()
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                BillID.Items.Add(dr("adjustment_id"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Rpt Adj")
        End Try
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White

    End Sub

    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub

    Private Sub Button1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class