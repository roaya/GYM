<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportDepItems
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportDepItems))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Item_ID = New System.Windows.Forms.ComboBox()
        Me.RadMeal = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadioDates = New System.Windows.Forms.RadioButton()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.TotalBill = New System.Windows.Forms.NumericUpDown()
        Me.RadioTotalBill = New System.Windows.Forms.RadioButton()
        Me.StockID = New System.Windows.Forms.ComboBox()
        Me.RadioStockID = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmployeeID = New System.Windows.Forms.ComboBox()
        Me.BillID = New System.Windows.Forms.ComboBox()
        Me.RadioEmployeeID = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TotalBill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Item_ID)
        Me.GroupBox1.Controls.Add(Me.RadMeal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.RadioDates)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.TotalBill)
        Me.GroupBox1.Controls.Add(Me.RadioTotalBill)
        Me.GroupBox1.Controls.Add(Me.StockID)
        Me.GroupBox1.Controls.Add(Me.RadioStockID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.EmployeeID)
        Me.GroupBox1.Controls.Add(Me.BillID)
        Me.GroupBox1.Controls.Add(Me.RadioEmployeeID)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(455, 329)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'Item_ID
        '
        Me.Item_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Item_ID.Enabled = False
        Me.Item_ID.FormattingEnabled = True
        Me.Item_ID.Location = New System.Drawing.Point(28, 127)
        Me.Item_ID.Name = "Item_ID"
        Me.Item_ID.Size = New System.Drawing.Size(261, 26)
        Me.Item_ID.TabIndex = 56
        '
        'RadMeal
        '
        Me.RadMeal.Location = New System.Drawing.Point(290, 128)
        Me.RadMeal.Name = "RadMeal"
        Me.RadMeal.Size = New System.Drawing.Size(137, 25)
        Me.RadMeal.TabIndex = 55
        Me.RadMeal.Text = "اسم الصنف"
        Me.RadMeal.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(140, 219)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 18)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "الي :"
        '
        'RadioDates
        '
        Me.RadioDates.Location = New System.Drawing.Point(290, 215)
        Me.RadioDates.Name = "RadioDates"
        Me.RadioDates.Size = New System.Drawing.Size(137, 26)
        Me.RadioDates.TabIndex = 53
        Me.RadioDates.Text = "بين تاريخين"
        Me.RadioDates.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(181, 215)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(108, 26)
        Me.DateTimePicker1.TabIndex = 52
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(28, 215)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(108, 26)
        Me.DateTimePicker2.TabIndex = 51
        '
        'TotalBill
        '
        Me.TotalBill.DecimalPlaces = 2
        Me.TotalBill.Location = New System.Drawing.Point(28, 169)
        Me.TotalBill.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.TotalBill.Name = "TotalBill"
        Me.TotalBill.Size = New System.Drawing.Size(261, 26)
        Me.TotalBill.TabIndex = 50
        Me.TotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RadioTotalBill
        '
        Me.RadioTotalBill.Location = New System.Drawing.Point(290, 169)
        Me.RadioTotalBill.Name = "RadioTotalBill"
        Me.RadioTotalBill.Size = New System.Drawing.Size(137, 26)
        Me.RadioTotalBill.TabIndex = 49
        Me.RadioTotalBill.Text = "اجمالي الفاتورة أكبر من"
        Me.RadioTotalBill.UseVisualStyleBackColor = True
        '
        'StockID
        '
        Me.StockID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StockID.Enabled = False
        Me.StockID.FormattingEnabled = True
        Me.StockID.Location = New System.Drawing.Point(28, 34)
        Me.StockID.Name = "StockID"
        Me.StockID.Size = New System.Drawing.Size(261, 26)
        Me.StockID.TabIndex = 48
        '
        'RadioStockID
        '
        Me.RadioStockID.Checked = True
        Me.RadioStockID.Location = New System.Drawing.Point(290, 35)
        Me.RadioStockID.Name = "RadioStockID"
        Me.RadioStockID.Size = New System.Drawing.Size(137, 25)
        Me.RadioStockID.TabIndex = 47
        Me.RadioStockID.TabStop = True
        Me.RadioStockID.Text = "اسم المخزن"
        Me.RadioStockID.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(281, 278)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 18)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "رقم المستند :"
        '
        'EmployeeID
        '
        Me.EmployeeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.EmployeeID.Enabled = False
        Me.EmployeeID.FormattingEnabled = True
        Me.EmployeeID.Location = New System.Drawing.Point(28, 82)
        Me.EmployeeID.Name = "EmployeeID"
        Me.EmployeeID.Size = New System.Drawing.Size(261, 26)
        Me.EmployeeID.TabIndex = 44
        '
        'BillID
        '
        Me.BillID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.BillID.FormattingEnabled = True
        Me.BillID.Location = New System.Drawing.Point(92, 278)
        Me.BillID.Name = "BillID"
        Me.BillID.Size = New System.Drawing.Size(162, 26)
        Me.BillID.TabIndex = 41
        '
        'RadioEmployeeID
        '
        Me.RadioEmployeeID.Location = New System.Drawing.Point(290, 82)
        Me.RadioEmployeeID.Name = "RadioEmployeeID"
        Me.RadioEmployeeID.Size = New System.Drawing.Size(137, 25)
        Me.RadioEmployeeID.TabIndex = 40
        Me.RadioEmployeeID.Text = "اسم الموظف"
        Me.RadioEmployeeID.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(268, 374)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 37)
        Me.Button1.TabIndex = 39
        Me.Button1.Text = "استعلام"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(99, 374)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 37)
        Me.Button2.TabIndex = 40
        Me.Button2.Text = "خروج"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ReportDepItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(471, 423)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ReportDepItems"
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير اهلاك الأصناف"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TotalBill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RadioDates As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TotalBill As System.Windows.Forms.NumericUpDown
    Friend WithEvents RadioTotalBill As System.Windows.Forms.RadioButton
    Friend WithEvents StockID As System.Windows.Forms.ComboBox
    Friend WithEvents RadioStockID As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmployeeID As System.Windows.Forms.ComboBox
    Friend WithEvents BillID As System.Windows.Forms.ComboBox
    Friend WithEvents RadioEmployeeID As System.Windows.Forms.RadioButton
    Friend WithEvents Item_ID As System.Windows.Forms.ComboBox
    Friend WithEvents RadMeal As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
