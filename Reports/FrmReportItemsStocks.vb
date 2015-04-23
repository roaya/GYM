Public Class FrmReportItemsStocks

    Dim rpt As New RptItemsStocks

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            MyDs.Tables("Query_Items_Stocks").Rows.Clear()
            If Radstock.Checked = True Then
                If Cmbstocks.Text = "" Then
                    cls.MsgInfo("من فضلك اختر السم المخزن", "")
                Else
                    cmd.CommandText = "select * from Query_Items_Stocks where stock_name = N'" & Cmbstocks.Text & "' order by stock_name,item_name asc"
                    da.Fill(MyDs.Tables("Query_Items_Stocks"))
                    rpt.SetDataSource(MyDs.Tables("Query_Items_Stocks"))
                    CrystalReportViewer1.ReportSource = rpt
                    tabcontrol1.SelectTab(1)
                End If


            ElseIf Raditem.Checked = True Then
                If Cmbitem.Text = "" Then
                    MsgBox(" من فضلك اختر اسم الصنف ")
                Else
                    cmd.CommandText = "select * from Query_Items_Stocks where item_name = N'" & Cmbitem.Text & "' order by item_name asc"
                    da.Fill(MyDs.Tables("Query_Items_Stocks"))
                    rpt.SetDataSource(MyDs.Tables("Query_Items_Stocks"))
                    CrystalReportViewer1.ReportSource = rpt
                    tabcontrol1.SelectTab(1)
                End If

            ElseIf RadBarcode.Checked = True Then
                If TxtBarcode.Text = "" Then
                    MsgBox(" من فضلك اختر الباركود")
                Else
                    cmd.CommandText = "select * from Query_Items_Stocks where barcode = N'" & TxtBarcode.Text & "'"
                    da.Fill(MyDs.Tables("Query_Items_Stocks"))
                    rpt.SetDataSource(MyDs.Tables("Query_Items_Stocks"))
                    CrystalReportViewer1.ReportSource = rpt
                    tabcontrol1.SelectTab(1)
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Query items um")
        End Try


    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Raditem.CheckedChanged
        If Raditem.Checked = True Then
            Cmbitem.Enabled = True
            TxtBarcode.Enabled = False
            Cmbstocks.Enabled = False
        End If
    End Sub

    Private Sub FrmReportItemsStocks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        cmd.CommandText = "select item_name from items"
        dr = cmd.ExecuteReader
        Do While dr.Read = True
            Cmbitem.Items.Add(dr("item_name"))
        Loop
        dr.Close()

        cmd.CommandText = "select stock_name from stocks"
        dr = cmd.ExecuteReader
        Do While dr.Read = True
            Cmbstocks.Items.Add(dr("stock_name"))
        Loop
        dr.Close()
    End Sub

    Private Sub RadBarcode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadBarcode.CheckedChanged
        If RadBarcode.Checked = True Then
            TxtBarcode.Enabled = True
            Cmbitem.Enabled = False
            Cmbstocks.Enabled = False
        End If
    End Sub



    Private Sub Radstock_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radstock.CheckedChanged
        If Radstock.Checked = True Then
            Cmbstocks.Enabled = True
            Cmbitem.Enabled = False
            TxtBarcode.Enabled = False

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
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

    Private Sub Cmbstocks_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbstocks.GotFocus
        Cmbstocks.BackColor = Color.FromArgb(135, 180, 209)

    End Sub

    Private Sub Cmbstocks_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbstocks.Leave

        Cmbstocks.BackColor = Color.Gainsboro
    End Sub

    Private Sub Cmbitem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbitem.GotFocus
        Cmbitem.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub Cmbitem_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmbitem.Leave
        Cmbitem.BackColor = Color.Gainsboro
    End Sub

    Private Sub TxtBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBarcode.GotFocus
        TxtBarcode.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub TxtBarcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBarcode.Leave
        TxtBarcode.BackColor = Color.Gainsboro

    End Sub
    Private Sub Button1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.GotFocus
        Button1.BackgroundImage = My.Resources._end
        Button1.ForeColor = Color.White
    End Sub

    Private Sub Button1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Leave
        Button1.BackgroundImage = My.Resources.enter
        Button1.ForeColor = Color.Black

    End Sub

    Private Sub Button2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Leave
        Button2.BackgroundImage = My.Resources.enter
        Button2.ForeColor = Color.Black
    End Sub

    Private Sub Button2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.GotFocus
        Button2.BackgroundImage = My.Resources._end
        Button2.ForeColor = Color.White
    End Sub
End Class