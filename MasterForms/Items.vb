Public Class Items

    Dim Gcls As GeneralSp.NewMasterForms
    Dim B_EndLoad As Boolean = False
    Dim BSourceItems As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Items"
    '-------------------------------
    Public SearchItemID As Integer

    Private Sub Categories_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Gcls.ExitForm()
    End Sub

    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            '  Me.Cursor = Cursors.WaitCursor
            MasterField1.TextBox1.MaxLength = 50

            cls.RefreshData(TName)
            cls.RefreshData("Categories")
            cls.RefreshData("um_master")
            cls.RefreshData("Corporations")

       

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

            Gcls = New GeneralSp.NewMasterForms(TName, BSourceItems, BtnNew, BtnSave, BtnDelete, BtnSearch, BtnExit, BtnReload, BtnCancelSerach, BtnFirst, BtnPrevious, BtnNext, BtnLast, BtnFile, BtnData, BtnHelp, OrderByCombo, ContentPanel, MasterField1, CountRecords)

            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------
            Gcls.SetWTitle = "«·«’‰«›"
            Me.Text = Gcls.SetWTitle

            MasterField1.TextBox1.DataBindings.Add("Text", BSourceItems, "Item_Name")
            BarCode.DataBindings.Add("Text", BSourceItems, "BarCode")
            SalePrice.DataBindings.Add("Value", BSourceItems, "Sale_Price")
            SaleTotalPrice.DataBindings.Add("Value", BSourceItems, "Sale_Total_Price")
            PurchasePrice.DataBindings.Add("Value", BSourceItems, "Purchase_Price")
            AlertBalance.DataBindings.Add("Value", BSourceItems, "Alert_Balance")
            'MaxOrder.DataBindings.Add("Value", BSourceItems, "Max_Order")
            'MinOrder.DataBindings.Add("Value", BSourceItems, "Min_Order")
            Photo.DataBindings.Add("backgroundImage", BSourceItems, "Photo", True)

            CategoryID.DataSource = MyDs
            CategoryID.DisplayMember = "Categories.Category_Name"
            CategoryID.ValueMember = "Categories.Category_ID"
            CategoryID.DataBindings.Add("SelectedValue", BSourceItems, "Category_ID")

            UmID.DataSource = MyDs
            UmID.DisplayMember = "um_master.um_Name"
            UmID.ValueMember = "um_master.um_ID"
            UmID.DataBindings.Add("SelectedValue", BSourceItems, "um_ID")

            CorporationID.DataSource = MyDs
            CorporationID.DisplayMember = "Corporations.Corporation_Name"
            CorporationID.ValueMember = "Corporations.Corporation_ID"
            CorporationID.DataBindings.Add("SelectedValue", BSourceItems, "Corporation_ID")

        

            SSource = BSourceItems


            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Item_Name"

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
            ElseIf BarCode.Text = "" Then

                BarCode.Focus()
                cls.MsgComplete()
                BarCode.BackColor = Color.Red
            ElseIf CorporationID.Text = "" Or CategoryID.Text = "" Or UmID.Text = "" Then
                cls.MsgComplete()
                CorporationID.Focus()
            Else

                Gcls.SaveRecord()
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            BarCode.BackColor = Color.Gainsboro
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
                Gcls.SortData(BSourceItems, OrderByCombo.SelectedValue)
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
            BSourceItems.RemoveFilter()
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

  
    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim a As New Categories
    '    a.ShowDialog()

    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim b As New UmMaster
        b.ShowDialog()
        cls.RefreshData("Um_Master")
    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim c As New Corporations
        c.ShowDialog()
        cls.RefreshData("Corporations")
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        Try
            Dim Fpath As String = ""

l:
            OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            OpenFileDialog1.Title = "«Œ — ’Ê—… ·⁄—÷Â« ⁄·Ì «·‰«›–…"
            OpenFileDialog1.Filter = "Image Files|*.JPG;*.JPEG;*.png;*.Gif;"
            If OpenFileDialog1.ShowDialog() = DialogResult.Cancel Then
                If MsgBox("·„ Ì „ «Œ Ì«— «·’Ê—… Â·  —Ìœ «⁄«œ… «·«Œ Ì«— ø", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, ProjectTitle) = DialogResult.Yes Then
                    GoTo l
                End If
            Else
                Fpath = OpenFileDialog1.FileName
            End If

            Photo.BackgroundImage = Image.FromFile(Fpath)
        Catch ex As Exception
            Dim s As String = ""
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Photo.BackgroundImage = Nothing
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Process.Start(My.Application.Info.DirectoryPath & "\LoadData.exe")
    End Sub

    'Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim m As New Coeff
    '    m.ShowDialog()
    'End Sub

    ''Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim m As New ProductRange
    ''    m.ShowDialog()
    ''End Sub

    ''Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ''    Dim m As New Logistics
    ''    m.ShowDialog()
    'End Sub

    Private Sub BarCode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BarCode.GotFocus
        BarCode.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub BarCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarCode.Leave
        If BarCode.Text <> "" Then

            BarCode.BackColor = Color.Gainsboro
        End If
    End Sub

    Private Sub SalePrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SalePrice.GotFocus
        SalePrice.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub SalePrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SalePrice.Leave
        SalePrice.BackColor = Color.Gainsboro
    End Sub


    Private Sub SaleTotalPrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaleTotalPrice.GotFocus
        SaleTotalPrice.BackColor = Color.FromArgb(135, 180, 209)


    End Sub

    Private Sub SaleTotalPrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaleTotalPrice.Leave
        SaleTotalPrice.BackColor = Color.Gainsboro
    End Sub

    Private Sub PurchasePrice_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PurchasePrice.GotFocus
        PurchasePrice.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub PurchasePrice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PurchasePrice.Leave
        PurchasePrice.BackColor = Color.Gainsboro
    End Sub

    Private Sub AlertBalance_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlertBalance.GotFocus
        AlertBalance.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub AlertBalance_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlertBalance.Leave
        AlertBalance.BackColor = Color.Gainsboro
    End Sub

    Private Sub OrderBalance_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderBalance.GotFocus
        OrderBalance.BackColor = Color.FromArgb(135, 180, 209)
    End Sub

    Private Sub OrderBalance_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderBalance.Leave
        OrderBalance.BackColor = Color.Gainsboro
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim m As New Categories
        m.ShowDialog()
        cls.RefreshData("Categories")

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim m As New Categories
        m.ShowDialog()
        cls.RefreshData("Categories")
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim m As New Corporations
        m.ShowDialog()
        cls.RefreshData("Corporations")
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim m As New Items
        m.ShowDialog()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Dim m As New UmMaster
        m.ShowDialog()
        cls.RefreshData("Um_Master")
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim m As New UmDetails
        m.ShowDialog()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Dim m As New FirstBalanceStock
        m.ShowDialog()
    End Sub

End Class
