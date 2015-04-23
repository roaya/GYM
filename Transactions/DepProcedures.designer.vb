<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DepProcedures
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DepProcedures))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DepDate = New System.Windows.Forms.DateTimePicker()
        Me.DepDesc = New System.Windows.Forms.TextBox()
        Me.ComboProcedureID = New System.Windows.Forms.ComboBox()
        Me.DepValue = New System.Windows.Forms.NumericUpDown()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GeneralLabel1 = New Gym.GeneralLabel()
        Me.GeneralLabel2 = New Gym.GeneralLabel()
        Me.GeneralLabel6 = New Gym.GeneralLabel()
        Me.GeneralLabel3 = New Gym.GeneralLabel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DepValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Button1.Location = New System.Drawing.Point(132, 329)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(132, 36)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "خروج"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GeneralLabel3)
        Me.GroupBox1.Controls.Add(Me.GeneralLabel6)
        Me.GroupBox1.Controls.Add(Me.GeneralLabel2)
        Me.GroupBox1.Controls.Add(Me.GeneralLabel1)
        Me.GroupBox1.Controls.Add(Me.DepDate)
        Me.GroupBox1.Controls.Add(Me.DepDesc)
        Me.GroupBox1.Controls.Add(Me.ComboProcedureID)
        Me.GroupBox1.Controls.Add(Me.DepValue)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(24, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(546, 299)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات التعاملات"
        '
        'DepDate
        '
        Me.DepDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DepDate.Location = New System.Drawing.Point(78, 216)
        Me.DepDate.Name = "DepDate"
        Me.DepDate.RightToLeftLayout = True
        Me.DepDate.Size = New System.Drawing.Size(284, 26)
        Me.DepDate.TabIndex = 4
        '
        'DepDesc
        '
        Me.DepDesc.Location = New System.Drawing.Point(78, 163)
        Me.DepDesc.Name = "DepDesc"
        Me.DepDesc.Size = New System.Drawing.Size(284, 26)
        Me.DepDesc.TabIndex = 3
        '
        'ComboProcedureID
        '
        Me.ComboProcedureID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboProcedureID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboProcedureID.FormattingEnabled = True
        Me.ComboProcedureID.Location = New System.Drawing.Point(78, 57)
        Me.ComboProcedureID.Name = "ComboProcedureID"
        Me.ComboProcedureID.Size = New System.Drawing.Size(284, 26)
        Me.ComboProcedureID.TabIndex = 1
        '
        'DepValue
        '
        Me.DepValue.DecimalPlaces = 5
        Me.DepValue.Location = New System.Drawing.Point(78, 110)
        Me.DepValue.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.DepValue.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.DepValue.Name = "DepValue"
        Me.DepValue.Size = New System.Drawing.Size(284, 26)
        Me.DepValue.TabIndex = 2
        Me.DepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.DepValue.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Transparent
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(331, 329)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(132, 36)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "حفظ البيانات"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GeneralLabel1
        '
        Me.GeneralLabel1.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel1.BackgroundImage = Global.Gym.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel1.IsRequired = True
        Me.GeneralLabel1.Location = New System.Drawing.Point(367, 57)
        Me.GeneralLabel1.Name = "GeneralLabel1"
        Me.GeneralLabel1.SetLabelTxt = "اسم الحساب :"
        Me.GeneralLabel1.Size = New System.Drawing.Size(129, 27)
        Me.GeneralLabel1.TabIndex = 52
        Me.GeneralLabel1.TabStop = False
        '
        'GeneralLabel2
        '
        Me.GeneralLabel2.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel2.BackgroundImage = Global.Gym.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel2.IsRequired = True
        Me.GeneralLabel2.Location = New System.Drawing.Point(368, 110)
        Me.GeneralLabel2.Name = "GeneralLabel2"
        Me.GeneralLabel2.SetLabelTxt = "القيمه :"
        Me.GeneralLabel2.Size = New System.Drawing.Size(129, 26)
        Me.GeneralLabel2.TabIndex = 53
        Me.GeneralLabel2.TabStop = False
        '
        'GeneralLabel6
        '
        Me.GeneralLabel6.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel6.BackgroundImage = Global.Gym.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel6.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel6.IsRequired = False
        Me.GeneralLabel6.Location = New System.Drawing.Point(367, 163)
        Me.GeneralLabel6.Name = "GeneralLabel6"
        Me.GeneralLabel6.SetLabelTxt = "الوصف :"
        Me.GeneralLabel6.Size = New System.Drawing.Size(129, 26)
        Me.GeneralLabel6.TabIndex = 54
        Me.GeneralLabel6.TabStop = False
        '
        'GeneralLabel3
        '
        Me.GeneralLabel3.BackColor = System.Drawing.Color.Gainsboro
        Me.GeneralLabel3.BackgroundImage = Global.Gym.My.Resources.Resources.conatin_box_03
        Me.GeneralLabel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GeneralLabel3.Font = New System.Drawing.Font("Tahoma", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GeneralLabel3.IsRequired = True
        Me.GeneralLabel3.Location = New System.Drawing.Point(368, 215)
        Me.GeneralLabel3.Name = "GeneralLabel3"
        Me.GeneralLabel3.SetLabelTxt = "تاريخ الإهلاك :"
        Me.GeneralLabel3.Size = New System.Drawing.Size(129, 27)
        Me.GeneralLabel3.TabIndex = 55
        Me.GeneralLabel3.TabStop = False
        '
        'DepProcedures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Gym.My.Resources.Resources.Bigbg
        Me.ClientSize = New System.Drawing.Size(595, 379)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "DepProcedures"
        Me.RightToLeftLayout = True
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اهلاك الأصول الثابته"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DepValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DepDesc As System.Windows.Forms.TextBox
    Friend WithEvents ComboProcedureID As System.Windows.Forms.ComboBox
    Friend WithEvents DepValue As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DepDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GeneralLabel2 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel1 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel3 As GYM.GeneralLabel
    Friend WithEvents GeneralLabel6 As GYM.GeneralLabel
End Class
