<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportIncom
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Type = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ShiftName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Check = New System.Windows.Forms.Button()
        Me.IncomeDetails = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Income = New System.Windows.Forms.DataGridView()
        Me.ShowReport = New System.Windows.Forms.Button()
        Me.ToDate = New System.Windows.Forms.DateTimePicker()
        Me.Shifts = New System.Windows.Forms.DataGridView()
        Me.byemp = New System.Windows.Forms.CheckBox()
        Me.emp = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FromDate = New System.Windows.Forms.DateTimePicker()
        CType(Me.IncomeDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Income, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Shifts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Type
        '
        Me.Type.Location = New System.Drawing.Point(6, 400)
        Me.Type.Name = "Type"
        Me.Type.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Type.Size = New System.Drawing.Size(587, 23)
        Me.Type.TabIndex = 33
        Me.Type.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(596, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 18)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "الوردية"
        '
        'ShiftName
        '
        Me.ShiftName.BackColor = System.Drawing.Color.LightGray
        Me.ShiftName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ShiftName.ForeColor = System.Drawing.Color.Black
        Me.ShiftName.Location = New System.Drawing.Point(155, 107)
        Me.ShiftName.Name = "ShiftName"
        Me.ShiftName.Size = New System.Drawing.Size(435, 26)
        Me.ShiftName.TabIndex = 101
        Me.ShiftName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(932, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "التاريخ من"
        '
        'Check
        '
        Me.Check.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Check.BackColor = System.Drawing.Color.Silver
        Me.Check.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Check.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Check.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Check.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Check.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check.Location = New System.Drawing.Point(916, 101)
        Me.Check.Name = "Check"
        Me.Check.Size = New System.Drawing.Size(95, 28)
        Me.Check.TabIndex = 3
        Me.Check.Text = "استعلام"
        Me.Check.UseVisualStyleBackColor = False
        '
        'IncomeDetails
        '
        Me.IncomeDetails.AllowUserToAddRows = False
        Me.IncomeDetails.AllowUserToDeleteRows = False
        Me.IncomeDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IncomeDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.IncomeDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IncomeDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.IncomeDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.IncomeDetails.DefaultCellStyle = DataGridViewCellStyle14
        Me.IncomeDetails.Location = New System.Drawing.Point(6, 429)
        Me.IncomeDetails.Name = "IncomeDetails"
        Me.IncomeDetails.ReadOnly = True
        Me.IncomeDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.IncomeDetails.RowHeadersVisible = False
        Me.IncomeDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.IncomeDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.IncomeDetails.Size = New System.Drawing.Size(587, 220)
        Me.IncomeDetails.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(535, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 18)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "الى"
        '
        'Income
        '
        Me.Income.AllowUserToAddRows = False
        Me.Income.AllowUserToDeleteRows = False
        Me.Income.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Income.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Income.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.Income.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Income.DefaultCellStyle = DataGridViewCellStyle16
        Me.Income.Location = New System.Drawing.Point(6, 168)
        Me.Income.Name = "Income"
        Me.Income.ReadOnly = True
        Me.Income.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Income.RowHeadersVisible = False
        Me.Income.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Income.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Income.Size = New System.Drawing.Size(587, 228)
        Me.Income.TabIndex = 31
        '
        'ShowReport
        '
        Me.ShowReport.BackColor = System.Drawing.Color.Silver
        Me.ShowReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ShowReport.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.ShowReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ShowReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.ShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShowReport.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShowReport.Location = New System.Drawing.Point(6, 106)
        Me.ShowReport.Name = "ShowReport"
        Me.ShowReport.Size = New System.Drawing.Size(140, 28)
        Me.ShowReport.TabIndex = 23
        Me.ShowReport.Text = "عرض التقرير"
        Me.ShowReport.UseVisualStyleBackColor = False
        '
        'ToDate
        '
        Me.ToDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(229, 25)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.RightToLeftLayout = True
        Me.ToDate.Size = New System.Drawing.Size(274, 26)
        Me.ToDate.TabIndex = 21
        '
        'Shifts
        '
        Me.Shifts.AllowUserToAddRows = False
        Me.Shifts.AllowUserToDeleteRows = False
        Me.Shifts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Shifts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Shifts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Shifts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.Shifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Shifts.DefaultCellStyle = DataGridViewCellStyle18
        Me.Shifts.Location = New System.Drawing.Point(599, 168)
        Me.Shifts.Name = "Shifts"
        Me.Shifts.ReadOnly = True
        Me.Shifts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Shifts.RowHeadersVisible = False
        Me.Shifts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.Shifts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Shifts.Size = New System.Drawing.Size(408, 481)
        Me.Shifts.TabIndex = 30
        '
        'byemp
        '
        Me.byemp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.byemp.AutoSize = True
        Me.byemp.Location = New System.Drawing.Point(932, 60)
        Me.byemp.Name = "byemp"
        Me.byemp.Size = New System.Drawing.Size(79, 22)
        Me.byemp.TabIndex = 20
        Me.byemp.Text = "بالموظف"
        Me.byemp.UseVisualStyleBackColor = True
        '
        'emp
        '
        Me.emp.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.emp.Enabled = False
        Me.emp.FormattingEnabled = True
        Me.emp.Location = New System.Drawing.Point(610, 60)
        Me.emp.Name = "emp"
        Me.emp.Size = New System.Drawing.Size(274, 26)
        Me.emp.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ShiftName)
        Me.GroupBox1.Controls.Add(Me.ShowReport)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ToDate)
        Me.GroupBox1.Controls.Add(Me.byemp)
        Me.GroupBox1.Controls.Add(Me.Check)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.emp)
        Me.GroupBox1.Controls.Add(Me.FromDate)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(1021, 142)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "معاملات التقرير"
        '
        'FromDate
        '
        Me.FromDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(610, 25)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.RightToLeftLayout = True
        Me.FromDate.Size = New System.Drawing.Size(274, 26)
        Me.FromDate.TabIndex = 13
        '
        'FrmReportIncom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1021, 666)
        Me.Controls.Add(Me.Type)
        Me.Controls.Add(Me.IncomeDetails)
        Me.Controls.Add(Me.Income)
        Me.Controls.Add(Me.Shifts)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmReportIncom"
        Me.Text = "تقرير الدخل اليومي"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.IncomeDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Income, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Shifts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Type As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ShiftName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Check As System.Windows.Forms.Button
    Friend WithEvents IncomeDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Income As System.Windows.Forms.DataGridView
    Friend WithEvents ShowReport As System.Windows.Forms.Button
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Shifts As System.Windows.Forms.DataGridView
    Friend WithEvents byemp As System.Windows.Forms.CheckBox
    Friend WithEvents emp As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker



End Class
