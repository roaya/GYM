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
        Me.Show = New System.Windows.Forms.Button()
        Me.Pay = New System.Windows.Forms.Button()
        Me.Loan = New System.Windows.Forms.ComboBox()
        Me.DG = New System.Windows.Forms.DataGridView()
        Me.Emp = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Phase_Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phase_Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phase_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Show
        '
        Me.Show.BackColor = System.Drawing.Color.Transparent
        Me.Show.BackgroundImage = CType(resources.GetObject("Show.BackgroundImage"), System.Drawing.Image)
        Me.Show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Show.FlatAppearance.BorderSize = 0
        Me.Show.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Show.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Show.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Show.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Show.Location = New System.Drawing.Point(589, 526)
        Me.Show.Name = "Show"
        Me.Show.Size = New System.Drawing.Size(138, 45)
        Me.Show.TabIndex = 123
        Me.Show.Text = "«⁄—÷"
        Me.Show.UseVisualStyleBackColor = False
        '
        'Pay
        '
        Me.Pay.BackColor = System.Drawing.Color.Transparent
        Me.Pay.BackgroundImage = CType(resources.GetObject("Pay.BackgroundImage"), System.Drawing.Image)
        Me.Pay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Pay.Enabled = False
        Me.Pay.FlatAppearance.BorderSize = 0
        Me.Pay.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Pay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Pay.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Pay.Location = New System.Drawing.Point(295, 526)
        Me.Pay.Name = "Pay"
        Me.Pay.Size = New System.Drawing.Size(138, 45)
        Me.Pay.TabIndex = 122
        Me.Pay.Text = "«œ›⁄"
        Me.Pay.UseVisualStyleBackColor = False
        '
        'Loan
        '
        Me.Loan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Loan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Loan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Loan.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Loan.FormattingEnabled = True
        Me.Loan.Location = New System.Drawing.Point(93, 23)
        Me.Loan.Name = "Loan"
        Me.Loan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Loan.Size = New System.Drawing.Size(292, 26)
        Me.Loan.TabIndex = 121
        '
        'DG
        '
        Me.DG.AllowUserToAddRows = False
        Me.DG.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue
        Me.DG.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DG.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DG.ColumnHeadersHeight = 35
        Me.DG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Phase_Value, Me.Phase_Status, Me.Phase_Date})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DG.DefaultCellStyle = DataGridViewCellStyle3
        Me.DG.Location = New System.Drawing.Point(19, 66)
        Me.DG.MultiSelect = False
        Me.DG.Name = "DG"
        Me.DG.ReadOnly = True
        Me.DG.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DG.Size = New System.Drawing.Size(985, 426)
        Me.DG.TabIndex = 119
        '
        'Emp
        '
        Me.Emp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Emp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Emp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Emp.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Emp.FormattingEnabled = True
        Me.Emp.Location = New System.Drawing.Point(532, 23)
        Me.Emp.Name = "Emp"
        Me.Emp.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Emp.Size = New System.Drawing.Size(292, 26)
        Me.Emp.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Gainsboro
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(391, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(61, 18)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "«·”·› :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(830, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(100, 18)
        Me.Label2.TabIndex = 125
        Me.Label2.Text = "«”„ «·„ÊŸ› :"
        '
        'Phase_Value
        '
        Me.Phase_Value.HeaderText = "ﬁÌ„… «·ﬁ”ÿ"
        Me.Phase_Value.Name = "Phase_Value"
        Me.Phase_Value.ReadOnly = True
        '
        'Phase_Status
        '
        Me.Phase_Status.HeaderText = "Õ«·… «·ﬁ”ÿ"
        Me.Phase_Status.Name = "Phase_Status"
        Me.Phase_Status.ReadOnly = True
        '
        'Phase_Date
        '
        Me.Phase_Date.HeaderText = " «—ÌŒ «·ﬁ”ÿ"
        Me.Phase_Date.Name = "Phase_Date"
        Me.Phase_Date.ReadOnly = True
        '
        'EmployeesLoansPhases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.GYM.My.Resources.Resources.enter_screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1023, 591)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Show)
        Me.Controls.Add(Me.Pay)
        Me.Controls.Add(Me.Loan)
        Me.Controls.Add(Me.DG)
        Me.Controls.Add(Me.Emp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EmployeesLoansPhases"
        Me.RightToLeftLayout = True
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "”œ«œ ”·› «·⁄«„·Ì‰"
        CType(Me.DG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Show As System.Windows.Forms.Button
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
End Class
