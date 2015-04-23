Public Class FirstBalanceItemBarcode

    Dim B_EndLoad As Boolean = False
    Dim BSourceItemsStocks As New BindingSource
    '-------------------------------
    'Set The Data Table Name
    Dim TName As String = "Items_Stocks"
    '-------------------------------
    Dim cmdb As New SqlClient.SqlCommandBuilder


    Private Sub Customers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
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


            '-------------------------------
            'Must Specify Window Title 
            '-------------------------------


            BSourceItemsStocks.DataSource = MyDs
            BSourceItemsStocks.DataMember = TName

            MyDs.Tables(TName).Rows.Clear()

            DataGridView1.DataSource = BSourceItemsStocks
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False
            DataGridView1.Columns(2).HeaderText = "اسم الصنف"
            DataGridView1.Columns(3).HeaderText = "الباركود"
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).HeaderText = "اسم المحل"
            DataGridView1.Columns(6).HeaderText = "الرصيد"

            DataGridView1.Columns(2).ReadOnly = True
            DataGridView1.Columns(3).ReadOnly = True
            DataGridView1.Columns(5).ReadOnly = True

            'SSource = BSourceGenders

            '-------------------------------
            'Must Specify search field
            '-------------------------------

            RVal = "Gender_Name"

            B_EndLoad = True

        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        Try
            If Barcode.Text = "" Then
                cls.MsgExclamation("أدخل الباركود", "please enter barcode")
            Else
                cmd.CommandText = "SELECT DBO.Check_Barcode_Exists('" & Barcode.Text & "')"
                If cmd.ExecuteScalar = 0 Then
                    cls.MsgCritical("هذا الصنف غير موجود", "invalid barcode")
                Else
                    MyDs.Tables("Items_Stocks").Rows.Clear()
                    cmd.CommandText = "select * from Query_Items_Stocks where barcode = '" & Barcode.Text & "'"
                    da.SelectCommand = cmd
                    da.Fill(MyDs.Tables("Items_Stocks"))
                    If MyDs.Tables("Items_Stocks").Rows.Count > 0 Then
                        BtnSave.Enabled = True
                        MenuSave.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            BSourceItemsStocks.EndEdit()
            cmd.CommandText = "select * from " & TName
            cmdb.DataAdapter = da
            da.Update(MyDs.Tables(TName))
            BtnSave.Enabled = False
            MenuSave.Enabled = False
            MyDs.Tables("Items_Stocks").Rows.Clear()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub



    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLast.Click
        Try
            BSourceItemsStocks.MoveLast()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNext.Click
        Try
            BSourceItemsStocks.MoveNext()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnPervious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPervious.Click
        Try
            BSourceItemsStocks.MovePrevious()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFirst.Click
        Try
            BSourceItemsStocks.MoveFirst()
        Catch ex As Exception
            cls.WriteError(ex.Message, TName)
        End Try
    End Sub

    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click, MenuExit.Click


        Me.Close()
        
    End Sub

End Class