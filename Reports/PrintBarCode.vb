Public Class PrintBarCode
    Dim s As String
    Dim VU As New DataView(MyDs.Tables("Customers"))
    Dim RptPrintBarCode As New RptBarCode
    'Dim RptSecondPrintBarcode As New SecondRptBarCode
    Dim C As Integer

    Private Sub PrintBarCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cls.RefreshData("Customers")

            'TotalItemsSel.Text = CInt(MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Print_Barcode"))
            cmd.CommandText = "select Customer_Name from Customers"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                SourceList.Items.Add(dr("Customer_Name"))
                Cust.Items.Add(dr("Customer_Name"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Print BarCode")
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If SourceList.SelectedItem Is Nothing Then
                cls.MsgExclamation("«œŒ· «·⁄„Ì· «·„Õœœ", "please enter Customer_name")
            Else
                'If ItemsCount.Text + AddedValue.Value > CInt(MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Print_Barcode")) Then
                'cls.MsgExclamation("«·ﬂ—Ê  «·„÷«›… «ﬂ»— „‰ «·ﬂ„Ì… «·„Õœœ…", "number of Customers if bigger than allowed Customers")
                'Else
                ViewedList.Items.Add(SourceList.Items(SourceList.SelectedIndices(0)))
                Dim i As Integer
                For i = 0 To SourceList.SelectedIndices.Count - 1
                    For x As Integer = 0 To AddedValue.Value - 1
                        ViewedList.Items.Add(SourceList.Items(SourceList.SelectedIndices(0)))
                    Next
                    SourceList.Items.Remove(SourceList.Items(SourceList.SelectedIndices(0)))
                Next
                ItemsCount.Text = CInt(ItemsCount.Text) + AddedValue.Value
                AddedValue.Value = 0
                'End If
                'ItemsCount.Text = CInt(ItemsCount.Text) + AddedValue.Value
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Print BarCode")
        End Try

        ''======================================

        'If AddedValue.Value = 0 Then
        '    cls.MsgExclamation("«œŒ· «·⁄œœ «·„—«œ ÿ»«⁄ Â")
        'Else
        '    If ItemsCount.Text + AddedValue.Value > 96 Then
        '        cls.MsgExclamation("«·«’‰«› «·„÷«›… «ﬂ»— „‰ «·ﬂ„Ì… «·„Õœœ…")
        '    Else
        '        Dim i As Integer
        '        For i = 0 To SourceList.SelectedIndices.Count - 1
        '            DestinationList.Items.Add(AddedValue.Value & "-" & SourceList.Items(SourceList.SelectedIndices(0)))
        '            SourceList.Items.Remove(SourceList.Items(SourceList.SelectedIndices(0)))
        '        Next
        '        AddedValue.Value = 0
        '        ItemsCount.Text = CInt(ItemsCount.Text) + AddedValue.Value
        '    End If
        'End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'SourceList.Items.AddRange(DestinationList.Items)
        Try
            ViewedList.Items.Clear()
            SourceList.Items.Clear()
            ViewedList.Items.Clear()
            ItemsCount.Text = 0
            cmd.CommandText = "select Customer_Name from Customers"
            dr = cmd.ExecuteReader
            Do While Not dr.Read = False
                SourceList.Items.Add(dr("Customer_Name"))
            Loop
            dr.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, "Print BarCode")
        End Try

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

        'MyDs.Tables("barcodetable").Clear()
        'Dim C As Integer = 1
        'For i As Integer = 0 To DestinationList.Items.Count - 1
        '    DestinationList.SetSelected(i, True)
        '    s = DestinationList.SelectedItem
        '    VU.RowFilter = "Item_Name = '" & s.Substring(s.IndexOf("-") + 1) & "'"
        '    '  MsgBox(VU.RowFilter)
        '    MsgBox(s.Substring(0, s.IndexOf("-") - 1))
        '    For x As Integer = 0 To s.Substring(0, s.IndexOf("-") - 1)
        '        MsgBox(x)
        '        If C = 1 Then
        '            r = MyDs.Tables("barcodetable").NewRow
        '        End If
        '        r("barcode" & C) = VU(0).Item("BarCode")
        '        r("Price" & C) = VU(0).Item("Sale_Price")
        '        MsgBox(VU(0).Item("BarCode"))
        '        'MsgBox(VU(0).Item("Sale_Price"))
        '        C = C + 1
        '        'MsgBox(C)
        '        If C = 7 Then
        '            MyDs.Tables("barcodetable").Rows.Add(r)
        '            C = 1
        '            MsgBox("added")
        '        End If
        '    Next
        '    VU.RowFilter = "item_id > 0"
        'Next
        'MsgBox(MyDs.Tables("barcodetable").Rows.Count)
        'RptPrintBarCode.SetDataSource(MyDs.Tables("barcodetable"))

        'CrystalReportViewer1.ReportSource = RptPrintBarCode

        ''=======================================


        '   If ItemsCount.Text <> TotalItemsSel.Text Then
        'cls.MsgExclamation("")
        C = 1
        Try
            MyDs.Tables("barcodetable").Clear()
            For i As Integer = 0 To ViewedList.Items.Count - 1
                ViewedList.SetSelected(i, True)
                s = ViewedList.SelectedItem
                VU.RowFilter = "Customer_Name = '" & ViewedList.SelectedItem & "'"
               
                If C = 1 Then
                    r = MyDs.Tables("barcodetable").NewRow
                End If
                r("Customer_Name" & C) = VU(0).Item("Customer_Name")
                r("Customer_Code" & C) = "*" & VU(0).Item("Customer_Code") & "*"
                r("Photo" & C) = VU(0).Item("Photo")

                If C = 1 Then
                    MyDs.Tables("barcodetable").Rows.Add(r)
                End If

                If C = 1 Then
                    C = 2
                Else
                    C = 1
                End If
            Next
            VU.RowFilter = "Customer_ID > 0"
            'Next
            ''MsgBox(MyDs.Tables("barcodetable").Rows.Count)
            'If CInt(MyDs.Tables("App_Preferences").Rows(0).Item("Gen_Print_Barcode")) = 48 Then

            '    RptSecondPrintBarcode.SetDataSource(MyDs.Tables("barcodetable"))
            '    CrystalReportViewer1.ReportSource = RptSecondPrintBarcode
            '    CrystalReportViewer1.Visible = True
            '    TabControl1.SelectTab(1)

            'Else

            RptPrintBarCode.SetDataSource(MyDs.Tables("barcodetable"))
            CrystalReportViewer1.ReportSource = RptPrintBarCode
            CrystalReportViewer1.Visible = True
            TabControl1.SelectTab(1)

            'End If

        Catch ex As Exception
            cls.WriteError(ex.Message, "Print BarCode")
        End Try

    End Sub

    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If ViewedList.SelectedItem Is Nothing Then
                cls.MsgExclamation("«œŒ· «·„ÊŸ› «·„Õœœ", "please enter Employee Name")
            Else
                SourceList.Items.Add(ViewedList.Items(ViewedList.SelectedIndices(0)))
                Dim i As Integer
                For i = 0 To ViewedList.SelectedIndices.Count - 1
                    For x As Integer = 0 To AddedValue.Value - 1
                        SourceList.Items.Add(ViewedList.Items(ViewedList.SelectedIndices(0)))
                    Next
                    ViewedList.Items.Remove(ViewedList.Items(ViewedList.SelectedIndices(0)))
                Next
                'ItemsCount.Text = CInt(ItemsCount.Text) + AddedValue.Value
                'AddedValue.Value = 0
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, "Print BarCode")
        End Try
    End Sub


    Private Sub Cust_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cust.SelectedIndexChanged
        Try
            Dim i As Integer = 0

            While i <= SourceList.Items.Count - 1 And Cust.Text <> SourceList.Text
                SourceList.SelectedIndex = i
                i = i + 1
            End While

        Catch

        End Try
    End Sub

End Class