Public Class DailyProcedures

    Dim Gcls As GeneralSp.MasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceDailyProcedures As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Procedure_Master"
    '-------------------------------
    Public SearchProID As Integer
    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Dim g As Integer = InputBox("")
            'cls.FillSelectedTable("select * from procedure_master where procedure_master_id < " & g, "procedure_master")
            cls.RefreshData("Procedure_Master")
            
            Dim B As New BindingSource
            B.DataSource = MyDs
            B.DataMember = "Table_Columns"
            B.Filter = "Table_ID ='" & TName & "'"
            OrderByCombo.ComboBox.DataSource = B
            OrderByCombo.ComboBox.DisplayMember = "Logical_Name"
            OrderByCombo.ComboBox.ValueMember = "Physical_Name"

            '-------------------------------
            'Must Specify Data Table Name
            '-------------------------------

            Gcls = New GeneralSp.MasterForms(TName, BSourceDailyProcedures, MenuNew, MenuSave, MenuDelete, MenuSearch, MenuExit, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, NavigationBar, ContentPanel, NavigationMenu, , CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------

            Gcls.SetWTitle = "ÃÓãÇÁ ÇáÍÓÇÈÇÊ"
            Me.Text = Gcls.SetWTitle


            SSource = BSourceDailyProcedures

            Col_Procedure_Master_ID.DataPropertyName = "Procedure_Master_ID"
            Col_Daily_Procedure_Name.DataPropertyName = "Daily_Procedure_Name"
            Col_Reference_ID.DataPropertyName = "Reference_ID"
            Col_Generic_Desc.DataPropertyName = "Generic_Desc"
            Col_Balance.DataPropertyName = "Balance"
            Col_Procedure_Category.DataPropertyName = "Procedure_Category"
            Col_Procedure_Type.DataPropertyName = "Procedure_Type"

            DataGridView1.DataSource = BSourceDailyProcedures
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).HeaderText = "ÇÓã ÇáÍÓÇÈ"
            DataGridView1.Columns(2).HeaderText = "ßæÏ ÇáÍÓÇÈ"
            DataGridView1.Columns(3).HeaderText = "ÇáæÕÝ"
            DataGridView1.Columns(4).HeaderText = "ÇáÑÕíÏ ÇáÇÝÊÊÇÍí"

            ''''For x As Integer = 0 To 22
            ''''    DataGridView1.Rows(x).Cells("Col_Procedure_Category").ReadOnly = True
            ''''    DataGridView1.Rows(x).Cells("Col_Procedure_Type").ReadOnly = True
            ''''Next
            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Gender_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click, MenuNew.Click
        Try
            Gcls.NewRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click, MenuSave.Click
        Try
            Gcls.SaveRecord()
            BtnSave.Enabled = True
            MenuSave.Enabled = True
            MenuExit.Enabled = True
            BtnExit.Enabled = True
            cls.FillSelectedTable("select * from Procedure_Master", "Procedure_Master")
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click, MenuDelete.Click
        Try
            'If DataGridView1.SelectedRows.Count <= 21 Then
            '    cls.MsgExclamation("ÈÑÌÇÁ ÇÎÊíÇÑ ÇáÓÌá ÇáãÑÇÏ ÍÐÝå")
            'ElseIf DataGridView1.SelectedRows(0).Index = 0 Then
            '    cls.MsgExclamation("áÇ íãßä ÍÐÝ ÇáÈíÇäÇÊ ÇáÇÝÊÑÇÖíå")
            'Else
            Gcls.DeleteRecord()
            'End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuLast.Click, BtnLast.Click
        Try
            Gcls.LastRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuNext.Click, BtnNext.Click
        Try
            Gcls.NextRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPrevious.Click, BtnPervious.Click
        Try
            Gcls.PreviousRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFirst.Click, BtnFirst.Click
        Try
            Gcls.FirstRec()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click, MenuSearch.Click
        Try
            Gcls.EditRecord()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        Try
            Gcls.CutData(ContentPanel)
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        Try
            Gcls.CopyData(ContentPanel)
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        Try
            Gcls.PasteData(ContentPanel)
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub OrderByCombo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderByCombo.SelectedIndexChanged
        Try
            If B_EndLoad = True Then
                Gcls.SortData(BSourceDailyProcedures, OrderByCombo.ComboBox.SelectedValue)
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click
        Try
            Gcls.ExitForm()
            Me.Close()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub MenuReload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuReload.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            cls.FillSelectedTable("select * from " & TName, TName)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub


    Private Sub MenuCancelSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuCancelSearch.Click
        Try
            BSourceDailyProcedures.RemoveFilter()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    'Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
    '    cls.MsgExclamation("ÇÏÎá ÇáÈíÇäÇÊ ÈØÑíÞå ÕÍíÍå", "")
    'End Sub

    'Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
    '    cls.MsgExclamation("ÃÏÎá ÇáÈíÇäÇÊ ÈØÑíÞå ÕÍíÍå")
    'End Sub
End Class
