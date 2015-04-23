Public Class Subscriptions

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceSubscriptions As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Subscriptions"
    '-------------------------------
    Dim tbl1 As New GeneralDataSet.Subscriptions_CategoriesDataTable
    Public SearchSubscriptionId As Integer
    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MasterField1.TextBox1.MaxLength = 50

            cls.RefreshData(TName)
            cls.RefreshData("select * From Subscriptions_Categories", tbl1)
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

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceSubscriptions, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
            Gcls.SetWTitle = "»Ì«‰«  «·«‘ —«ﬂ"
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BSourceSubscriptions, "Subscription_Name")
            Category_ID.DataSource = tbl1
            Category_ID.DisplayMember = "Category_Name"
            Category_ID.ValueMember = "Category_ID"
            Category_ID.DataBindings.Add("selectedvalue", BSourceSubscriptions, "category_ID")
            Value_Group.DataBindings.Add("value", BSourceSubscriptions, "value_group")
            GenericDesc.TextBox1.DataBindings.Add("text", BSourceSubscriptions, "generic_Desc")
            NoTrainig.DataBindings.Add("Value", BSourceSubscriptions, "no_training")
            ExtraTraining.DataBindings.Add("Value", BSourceSubscriptions, "extra_Training")
            value_Single.DataBindings.Add("Value", BSourceSubscriptions, "value_single")
            months.DataBindings.Add("Value", BSourceSubscriptions, "months")
            SSource = BSourceSubscriptions

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Job_Title"

            B_EndLoad = True


        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            Gcls.NewRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If MasterField1.TextBox1.Text = "" Then
                cls.MsgComplete()
                MasterField1.TextBox1.Focus()
                MasterField1.TextBox1.BackColor = Color.Red

            ElseIf Category_ID.Text = "" Then
                cls.MsgComplete()

            ElseIf NoTrainig.Value <= 0 Then
                cls.MsgComplete()
                NoTrainig.Focus()
                NoTrainig.BackColor = Color.Red
    
            ElseIf months.Value <= 0 Then
                cls.MsgComplete()
                months.Focus()
                months.BackColor = Color.Red

            ElseIf Value_Group.Value <= 0 Then
                cls.MsgComplete()
                Value_Group.Focus()

                Value_Group.BackColor = Color.Red
            ElseIf value_Single.Value <= 0 Then
                cls.MsgComplete()
                value_Single.Focus()
                value_Single.BackColor = Color.Red


            Else
                If NoTrainig.Value = 1 Then
                    months.Value = 1
                    ExtraTraining.Value = 0
                End If
              

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
            Gcls.EditRecord()
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
                Gcls.SortData(BSourceSubscriptions, OrderByCombo.SelectedValue)
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
            BSourceSubscriptions.RemoveFilter()
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

   

    Private Sub NoTrainig_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NoTrainig.GotFocus
        NoTrainig.BackColor = Color.FromArgb(135, 180, 209)

    End Sub

    Private Sub NoTrainig_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles NoTrainig.Leave
        NoTrainig.BackColor = Color.Gainsboro
    End Sub

    Private Sub months_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles months.GotFocus
        months.BackColor = Color.FromArgb(135, 180, 209)
    End Sub
    Private Sub months_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles months.Leave
        months.BackColor = Color.Gainsboro
    End Sub

    Private Sub Value_Group_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Value_Group.GotFocus
        Value_Group.BackColor = Color.FromArgb(135, 180, 209)
    End Sub
    Private Sub Value_Group_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Value_Group.Leave
        Value_Group.BackColor = Color.Gainsboro
    End Sub

    Private Sub value_Single_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles value_Single.GotFocus
        value_Single.BackColor = Color.FromArgb(135, 180, 209)
    End Sub
    Private Sub value_Single_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles value_Single.Leave
        value_Single.BackColor = Color.Gainsboro
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim m As New SubscriptionsCategories
        m.ShowDialog()
        cls.RefreshData("Subscriptions")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New SubscriptionDetails
        m.ShowDialog()
        cls.RefreshData("Subscriptions")
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim m As New Customers
        m.ShowDialog()
        cls.RefreshData("Customers", "Customer_Name")
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim m As New Halls
        m.ShowDialog()
        cls.RefreshData("Subscriptions")
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim m As New ReportSubscription
        m.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim m As New SubscriptionsCategories
        m.ShowDialog()
        cls.RefreshData("Subscriptions_Categories")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim m As New FrmSubscriptionsDetails
        m.ShowDialog()
    End Sub

    Private Sub ExtraTraining_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraTraining.Enter
        ExtraTraining.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub ExtraTraining_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraTraining.Leave
        ExtraTraining.BackColor = Color.Gainsboro
    End Sub
End Class
