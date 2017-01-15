<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeesLoansPhases
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeesLoansPhases))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ShowLoan = New System.Windows.Forms.Button()
        Me.Pay = New System.Windows.Forms.Button()
        Me.Loan = New System.Windows.Forms.ComboBox()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.Phase_Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phase_Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phase_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Emp = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Value = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.DG,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.Value,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'ShowLoan
        '
        Me.ShowLoan.BackColor = System.Drawing.Color.Transparent
        Me.ShowLoan.BackgroundImage = CType(resources.GetObject("ShowLoan.BackgroundImage"),System.Drawing.Image)
        Me.ShowLoan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ShowLoan.FlatAppearance.BorderSize = 0
        Me.ShowLoan.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.ShowLoan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ShowLoan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ShowLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ShowLoan.Font = New System.Drawing.Font("Tahoma", 11!)
        Me.ShowLoan.Location = New System.Drawing.Point(33, 24)
        Me.ShowLoan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ShowLoan.Name = "ShowLoan"
        Me.ShowLoan.Size = New System.Drawing.Size(123, 36)
        Me.ShowLoan.TabIndex = 123
        Me.ShowLoan.Text = "«⁄—÷"
        Me.ShowLoan.UseVisualStyleBackColor = false
        '
        'Pay
        '
        Me.Pay.BackColor = System.Drawing.Color.Transparent
        Me.Pay.BackgroundImage = CType(resources.GetObject("Pay.BackgroundImage"),System.Drawing.Image)
        Me.Pay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Pay.Enabled = false
        Me.Pay.FlatAppearance.BorderSize = 0
        Me.Pay.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Pay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Pay.Font = New System.Drawing.Font("Tahoma", 11!)
        Me.Pay.Location = New System.Drawing.Point(592, 538)
        Me.Pay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Pay.Name = "Pay"
        Me.Pay.Size = New System.Drawing.Size(161, 35)
        Me.Pay.TabIndex = 122
        Me.Pay.Text = "«œ›⁄"
        Me.Pay.UseVisualStyleBackColor = false
        '
        'Loan
        '
        Me.Loan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Loan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Loan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Loan.Font = New System.Drawing.Font("Tahoma", 11!)
        Me.Loan.FormattingEnabled = true
        Me.Loan.Location = New System.Drawing.Point(166, 27)
        Me.Loan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Loan.Name = "Loan"
        Me.Loan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Loan.Size = New System.Drawing.Size(340, 30)
        Me.Loan.TabIndex = 121
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = false
        Me.DG.AllowUserToDeleteRows = false
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DG.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DG.ColumnHeadersHeight = 35
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Phase_Value, Me.Phase_Status, Me.Phase_Date})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle3
        Me.DG.Location = New System.Drawing.Point(22, 81)
        Me.DG.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DG.MultiSelect = false
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = true
        Me.DG.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DG.Size = New System.Drawing.Size(1149, 437)
        Me.DG.TabIndex = 119
        '
        'Phase_Value
        '
        Me.Phase_Value.HeaderText = "ﬁÌ„… «·ﬁ”ÿ"
        Me.Phase_Value.Name = "Phase_Value"
        Me.Phase_Value.ReadOnly = true
        '
        'Phase_Status
        '
        Me.Phase_Status.HeaderText = "Õ«·… «·ﬁ”ÿ"
        Me.Phase_Status.Name = "Phase_Status"
        Me.Phase_Status.ReadOnly = true
        '
        'Phase_Date
        '
        Me.Phase_Date.HeaderText = " «—ÌŒ «·ﬁ”ÿ"
        Me.Phase_Date.Name = "Phase_Date"
        Me.Phase_Date.ReadOnly = true
        '
        'Emp
        '
        Me.Emp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Emp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Emp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Emp.Font = New System.Drawing.Font("Tahoma", 11!)
        Me.Emp.FormattingEnabled = true
        Me.Emp.Location = New System.Drawing.Point(621, 28)
        Me.Emp.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Emp.Name = "Emp"
        Me.Emp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Emp.Size = New System.Drawing.Size(340, 30)
        Me.Emp.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(514, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(77, 23)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "«·”·› :"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(968, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(126, 23)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "«”„ «·„ÊŸ› :"
        '
        'Value
        '
        Me.Value.DecimalPlaces = 2
        Me.Value.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Value.Location = New System.Drawing.Point(758, 538)
        Me.Value.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Value.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.Value.Name = "Value"
        Me.Value.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Value.Size = New System.Drawing.Size(332, 30)
        Me.Value.TabIndex = 126
        Me.Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(1101, 541)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(67, 23)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "«·ﬁÌ„…:"
        '
        'EmployeesLoansPhases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer), CType(CType(64,Byte),Integer))
        Me.BackgroundImage = Global.GYM.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1193, 599)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Value)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShowLoan)
        Me.Controls.Add(Me.Pay)
        Me.Controls.Add(Me.Loan)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.Emp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "EmployeesLoansPhases"
        Me.RightToLeftLayout = true
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "”œ«œ ”·› «·⁄«„·Ì‰"
        CType(Me.DG,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.Value,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ShowLoan As System.Windows.Forms.Button
    Friend WithEvents Pay As System.Windows.Forms.Button
    Friend WithEvents Loan As System.Windows.Forms.ComboBox
    Friend WithEvents GeneralLabel2 As GYM.GeneralLabel
    Friend WithEvents DG As System.Windows.Forms.DataGridView
    Friend WithEvents Emp As System.Windows.Forms.ComboBox
    Friend WithEvents GeneralLabel1 As GYM.GeneralLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Phase_Value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phase_Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phase_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Value As NumericUpDown
    Friend WithEvents Label3 As Label
End Class
