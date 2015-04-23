Public Class MoneyPayments

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceMoneyPayables As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Money_Payables"
    '-------------------------------
    Dim CurID, SeqID As New SqlClient.SqlParameter
    Dim cmdPro As New SqlClient.SqlCommand
    Private TblProMstr As New GeneralDataSet.Procedure_MasterDataTable
    Dim ChqID As Integer
    Private Rpt As New RptReceivePay
    Private m As New ShowAllReports


    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            cmdPro.CommandType = CommandType.StoredProcedure
            cmdPro.Connection = cn


            CurID.DbType = DbType.Int32
            CurID.ParameterName = "CURR_ID"
            CurID.Direction = ParameterDirection.Output
            SeqID.DbType = DbType.Int32
            SeqID.ParameterName = "S_ID"
            SeqID.Direction = ParameterDirection.Input
            SeqID.Value = 13
            cmdPro.Parameters.Add(SeqID)
            cmdPro.Parameters.Add(CurID)
            cmdPro.CommandText = "UPDATE_SEQ"


            cls.RefreshData("Money_Payables")
            cls.RefreshData("select * from procedure_master", TblProMstr)

            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.DataSource = B
            OrderByCombo.DisplayMember = "Logical_Name"
            OrderByCombo.ValueMember = "Physical_Name"

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceMoneyPayables, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "ÈíÇäÇÊ ÃæÑÇÞ ÇáÏÝÚ"
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BSourceMoneyPayables, "Pay_ID")
            PayDate.DataBindings.Add("Text", BSourceMoneyPayables, "Pay_Date")
            PayType.DataBindings.Add("Text", BSourceMoneyPayables, "Pay_Type")
            PayValue.DataBindings.Add("Value", BSourceMoneyPayables, "Pay_Value")
            PayDesc.DataBindings.Add("Text", BSourceMoneyPayables, "Pay_Desc")
            TxtCheque.DataBindings.Add("Text", BSourceMoneyPayables, "Cheque_Number")

            ToProcedureMasterID.DataSource = TblProMstr
            ToProcedureMasterID.DisplayMember = "Daily_Procedure_Name"
            ToProcedureMasterID.ValueMember = "Procedure_Master_ID"
            ToProcedureMasterID.DataBindings.Add("SelectedValue", BSourceMoneyPayables, "To_Procedure_Master_ID")


            SSource = BSourceMoneyPayables

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Pay_ID"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            cmdPro.ExecuteNonQuery()
            MyDs.Tables(TName).Columns("Pay_ID").DefaultValue = CurID.Value
            MyDs.Tables(TName).Columns("shift_Detail_id").DefaultValue = CurrentShiftID
            MyDs.Tables(TName).Columns("pay_date").DefaultValue = Today
            MyDs.Tables(TName).Columns("pay_Type").DefaultValue = "äÞÏí"
            Gcls.NewRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If CurrentShiftID = 0 Then
                cls.MsgExclamation("ÈÑÌÇÁ Þã ÈÝÊÍ æÑÏíÉ ")
                Exit Sub
            End If



            If MasterField1.TextBox1.Text = "" Or PayType.Text = "" Or ToProcedureMasterID.Text = "" Then
                cls.MsgComplete()

            ElseIf PayValue.Value = 0 Then
                PayValue.BackColor = Color.Yellow
                PayValue.Focus()
                cls.MsgComplete()

            Else

                If PayType.Text = "ÈÔíß" Then
                    If TxtCheque.Text = "" Then
                        cls.MsgExclamation("ÇÏÎá ÑÞã ÇáÔíß", "")
                        Exit Sub
                    Else
                        cmd.CommandText = "select dbo.Is_Cheque_Valid('" & TxtCheque.Text & "')"
                        ChqID = cmd.ExecuteScalar
                        If ChqID = 0 Then
                            cls.MsgExclamation("ÇáÔíß ÛíÑ ÕÇáÍ ááÇÓÊÎÏÇã", "CURRENT CHEQUE NUMBER ISNOT VALID")
                            TxtCheque.Focus()
                            Exit Sub
                        Else
                            cmd.CommandText = "select cheque_value from cheques where cheque_number = " & TxtCheque.Text
                            PayValue.Value = cmd.ExecuteScalar
                        End If
                    End If
                End If

                If PayType.Text = "äÞÏí" Then
                    cmd.CommandText = "Exec Commit_Procedure_Tran " & ToProcedureMasterID.SelectedValue & ", 4 , " & PayValue.Value & ",N'" & PayDesc.Text & " - " & EmpNameVar & "'"
                    cmd.ExecuteNonQuery()
                ElseIf PayType.Text = "ÈÔíß" Then
                    REM cmd.CommandText = "select dbo.Get_Bank_Procedure_ID(" & TxtCheque.Text & ")"
                    REM FromAccID = cmd.ExecuteScalar
                    cmd.CommandText = "Exec Commit_Procedure_Tran " & ToProcedureMasterID.SelectedValue & ",24," & PayValue.Value & ",N'" & PayDesc.Text & " - " & EmpNameVar & "'"
                    cmd.ExecuteNonQuery()
                    cmd.CommandText = "UPDATE Cheques SET Cheque_Status=N'ÛíÑ ãäÕÑÝ' WHERE Cheque_Number = '" & TxtCheque.Text & "'"
                    cmd.ExecuteNonQuery()

                End If

                PayValue.BackColor = Color.Gainsboro
                Gcls.SaveRecord()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            Gcls.DeleteRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            Gcls.LastRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        Try
            Gcls.NextRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrevious.Click
        Try
            Gcls.PreviousRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirst.Click
        Try
            Gcls.FirstRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Rpt.ReportDefinition.ReportObjects.Item("TitleRecMoney").ObjectFormat.EnableSuppress = True
            Rpt.ReportDefinition.ReportObjects.Item("TitlePayMoney").ObjectFormat.EnableSuppress = False
            Rpt.ReportDefinition.ReportObjects.Item("TxtReceive").ObjectFormat.EnableSuppress = True
            Rpt.ReportDefinition.ReportObjects.Item("TxtPay").ObjectFormat.EnableSuppress = False

            MyDs.Tables("ReceivePay").Rows.Clear()
            r = MyDs.Tables("ReceivePay").NewRow
            r("Rec_ID") = MasterField1.TextBox1.Text
            r("Account_Name") = ToProcedureMasterID.Text
            r("Account_Date") = PayDate.Text
            r("Account_Value") = PayValue.Value
            r("Account_Desc") = PayDesc.Text
            If PayType.Text = "ÈÔíß" Then
                r("Account_Type") = "Ôíß"

            ElseIf PayType.Text = "äÞÏí" Then
                r("Account_Type") = "äÞÏí"
            End If
            MyDs.Tables("ReceivePay").Rows.Add(r)
            Rpt.SetDataSource(MyDs.Tables("ReceivePay"))
            m.CrystalReportViewer1.ReportSource = Rpt
            m.ShowDialog()

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    'Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CutData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.CopyData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    'Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Gcls.PasteData(ContentPanel)
    '    Catch ex As Exception
    '        cls.WriteError(ex.Message, TName)
    '    End Try
    'End Sub

    Private Sub OrderByCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderByCombo.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                Gcls.SortData(BSourceMoneyPayables, OrderByCombo.SelectedValue)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Try
            Gcls.ExitForm()
            Me.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub btnReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReload.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Gcls.ReloadData()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub BtnCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelSerach.Click
        Try
            BSourceMoneyPayables.RemoveFilter()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFile.Click
        Gcls.BtnFile()
    End Sub

    Private Sub BtnData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnData.Click
        Gcls.BtnData()
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click
        Gcls.BtnHelp()
    End Sub

    Private Sub PayValue_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayValue.GotFocus
        PayValue.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub PayValue_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayValue.Leave
        If PayValue.Value > 0 Then
            PayValue.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub ToProcedureMasterID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToProcedureMasterID.GotFocus
        ToProcedureMasterID.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub ToProcedureMasterID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToProcedureMasterID.Leave
        ToProcedureMasterID.BackColor = Color.Gainsboro
    End Sub

    Private Sub PayDesc_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayDesc.GotFocus
        PayDesc.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub PayDesc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayDesc.Leave
        PayDesc.BackColor = Color.Gainsboro
    End Sub

    Private Sub PayDate_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayDate.GotFocus
        PayDate.BackColor = Color.FromArgb(135, 180, 209)

    End Sub

    Private Sub PayDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PayDate.Leave
        PayDate.BackColor = Color.Gainsboro
    End Sub

    Private Sub TxtCheque_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCheque.GotFocus
        TxtCheque.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub TxtCheque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCheque.Leave
        TxtCheque.BackColor = Color.Gainsboro
    End Sub
End Class
